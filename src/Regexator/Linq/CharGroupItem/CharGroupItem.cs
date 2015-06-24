// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class CharGroupItem
        : IBaseGroup, IExcludedGroup
    {
        protected CharGroupItem()
        {
        }

        public static CharGroupItem Create(string characters)
        {
            return new CharactersItem(characters);
        }

        public static CharGroupItem Create(char value)
        {
            return new CharacterItem(value);
        }

        public static CharGroupItem Create(char first, char last)
        {
            return new RangeCharItem(first, last);
        }

        public static CharGroupItem Create(int charCode)
        {
            return new CharCodeCharItem(charCode);
        }

        public static CharGroupItem Create(int firstCharCode, int lastCharCode)
        {
            return new CodeRangeCharItem(firstCharCode, lastCharCode);
        }

        public static CharGroupItem Create(AsciiChar value)
        {
            return new AsciiCharItem(value);
        }

        public static CharGroupItem Create(NamedBlock block)
        {
            return new NamedBlockCharItem(block);
        }

        public static CharGroupItem Create(GeneralCategory category)
        {
            return new GeneralCategoryCharItem(category);
        }

        private CharGroupItem Concat(CharGroupItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            CharGroupItem first = item;
            while (first.Previous != null)
            {
                first = first.Previous;
            }

            first.Previous = this;
            return item;
        }

        public override string ToString()
        {
            return ToString(CultureInfo.CurrentCulture);
        }

        public string ToString(IFormatProvider formatProvider)
        {
            using (var writer = new PatternWriter(formatProvider))
            {
                writer.Write(this);
                return writer.ToString();
            }
        }

        public CharGroupItem Concat(char value)
        {
            return Concat(Create(value));
        }

        public CharGroupItem Concat(int value)
        {
            return Concat(Create(value));
        }

        public CharGroupItem Concat(AsciiChar value)
        {
            return Concat(Create(value));
        }

        public CharGroupItem Concat(string characters)
        {
            return Concat(Create(characters));
        }

        public CharGroupItem Concat(char first, char last)
        {
            return Concat(Create(first, last));
        }

        public CharGroupItem Concat(int firstCharCode, int lastCharCode)
        {
            return Concat(Create(firstCharCode, lastCharCode));
        }

        public CharGroupItem Concat(NamedBlock block)
        {
            return Concat(Create(block));
        }

        public CharGroupItem Concat(GeneralCategory category)
        {
            return Concat(Create(category));
        }

        public CharGroupItem Not(NamedBlock block)
        {
            return Concat(CharGroupItems.NotNamedBlock(block));
        }

        public CharGroupItem Not(GeneralCategory category)
        {
            return Concat(CharGroupItems.NotGeneralCategory(category));
        }

        public CharGroupItem Digit()
        {
            return Concat(CharGroupItems.Digit());
        }

        public CharGroupItem NotDigit()
        {
            return Concat(CharGroupItems.NotDigit());
        }

        public CharGroupItem WhiteSpace()
        {
            return Concat(CharGroupItems.WhiteSpace());
        }

        public CharGroupItem NotWhiteSpace()
        {
            return Concat(CharGroupItems.NotWhiteSpace());
        }

        public CharGroupItem WordChar()
        {
            return Concat(CharGroupItems.WordChar());
        }

        public CharGroupItem NotWordChar()
        {
            return Concat(CharGroupItems.NotWordChar());
        }

        public CharGroupItem Alphanumeric()
        {
            return Concat(CharGroupItems.Alphanumeric());
        }

        public CharGroupItem AlphanumericLower()
        {
            return Concat(CharGroupItems.AlphanumericLower());
        }

        public CharGroupItem AlphanumericUpper()
        {
            return Concat(CharGroupItems.AlphanumericUpper());
        }

        public CharGroupItem LatinLetter()
        {
            return Concat(CharGroupItems.LatinLetter());
        }

        public CharGroupItem LatinLetterLower()
        {
            return Concat(CharGroupItems.LatinLetterLower());
        }

        public CharGroupItem LatinLetterUpper()
        {
            return Concat(CharGroupItems.LatinLetterUpper());
        }

        public CharGroupItem ArabicDigit()
        {
            return Concat(CharGroupItems.ArabicDigit());
        }

        public CharGroupItem NewLineChar()
        {
            return Concat(CharGroupItems.NewLineChar());
        }

        public CharGroup ToGroup()
        {
            return new CharGroupItemGroup(this);
        }

        public CharGroup ToNegativeGroup()
        {
            return new CharGroupItemGroup(this, true);
        }

        protected abstract void WriteItemContentTo(PatternWriter writer);

        public void WriteBaseGroupTo(PatternWriter writer)
        {
            WriteContentTo(writer);
        }

        public void WriteExcludedGroupTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.Write(this);
        }

        internal void WriteContentTo(PatternWriter writer)
        {
            if (Previous != null)
            {
                CharGroupItem[] items = GetItems().ToArray();
                for (int i = (items.Length - 1); i >= 0; i--)
                {
                    items[i].WriteItemContentTo(writer);
                }
            }
            else
            {
                WriteItemContentTo(writer);
            }
        }

        private IEnumerable<CharGroupItem> GetItems()
        {
            CharGroupItem item = this;
            do
            {
                yield return item;
                item = item.Previous;
            } while (item != null);
        }

        #region + and ! operators

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroupItem operator +(CharGroupItem left, CharGroupItem right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return left.Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroupItem operator +(CharGroupItem left, string right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return left.Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroupItem operator +(string left, CharGroupItem right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return CharGroupItem.Create(left).Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroupItem operator +(CharGroupItem left, char right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            return left.Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroupItem operator +(char left, CharGroupItem right)
        {
            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return CharGroupItem.Create(left).Concat(right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroup operator !(CharGroupItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            return Patterns.NotCharacter(item);
        }

        #endregion

        public static explicit operator CharGroupItem(string characters)
        {
            return Create(characters);
        }

        public static explicit operator CharGroupItem(char value)
        {
            return Create(value);
        }

        internal CharGroupItem Previous { get; set; }
    }
}
