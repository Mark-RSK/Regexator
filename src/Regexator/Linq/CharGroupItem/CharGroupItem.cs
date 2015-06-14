// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
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
            return new CharsCharItem(characters);
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

        //todo zkontrolovat
        public override string ToString()
        {
            using (var writer = new PatternWriter())
            {
                BuildExcludedGroup(writer);
                return writer.ToString();
            }
        }

        public CharGroupItem Concat(char value)
        {
            return Concat(CharGroupItem.Create(value));
        }

        public CharGroupItem Concat(int value)
        {
            return Concat(CharGroupItem.Create(value));
        }

        public CharGroupItem Concat(AsciiChar value)
        {
            return Concat(CharGroupItem.Create(value));
        }

        public CharGroupItem Concat(string characters)
        {
            return Concat(CharGroupItem.Create(characters));
        }

        public CharGroupItem Concat(char first, char last)
        {
            return Concat(CharGroupItem.Create(first, last));
        }

        public CharGroupItem Concat(int firstCharCode, int lastCharCode)
        {
            return Concat(CharGroupItem.Create(firstCharCode, lastCharCode));
        }

        public CharGroupItem Concat(NamedBlock block)
        {
            return Concat(CharGroupItem.Create(block));
        }

        public CharGroupItem Concat(GeneralCategory category)
        {
            return Concat(CharGroupItem.Create(category));
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

        public CharGroupExpression ToGroup()
        {
            return new CharItemGroup(this);
        }

        public CharGroupExpression ToNegativeGroup()
        {
            return new CharItemGroup(this, true);
        }

        internal abstract void BuildItemContent(PatternWriter writer);

        public void BuildBaseGroup(PatternWriter writer)
        {
            BuildContent(writer);
        }

        public void BuildExcludedGroup(PatternWriter writer)
        {
            BuildGroup(writer);
        }

        internal void BuildGroup(PatternWriter writer)
        {
            writer.WriteCharGroupStart();
            
            //todo check empty
            BuildContent(writer);

            writer.WriteCharGroupEnd();
        }

        internal void BuildContent(PatternWriter writer)
        {
            if (Previous != null)
            {
                CharGroupItem[] items = GetItems().ToArray();
                for (int i = (items.Length - 1); i >= 0; i--)
                {
                    items[i].BuildItemContent(writer);
                }
            }
            else
            {
                BuildItemContent(writer);
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

        #region + operator

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Expression operator +(CharGroupItem left, CharGroupItem right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return Expression.Concat(left, right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Expression operator +(CharGroupItem left, string right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return Expression.Concat(left, right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Expression operator +(string left, CharGroupItem right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return Expression.Concat(left, right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Expression operator +(CharGroupItem left, char right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            return Expression.Concat(left, right.ToString());
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static Expression operator +(char left, CharGroupItem right)
        {
            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return Expression.Concat(left.ToString(), right);
        }

        #endregion

        internal CharGroupItem Previous { get; set; }
    }
}
