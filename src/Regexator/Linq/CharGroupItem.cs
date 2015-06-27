// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents the content of the character group. Content can be a base group or an excluded group.
    /// </summary>
    public abstract partial class CharGroupItem
        : IBaseGroup, IExcludedGroup
    {
        protected CharGroupItem()
        {
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a set of characters to it./>
        /// </summary>
        /// <param name="characters">A set of characters.</param>
        /// <returns></returns>
        public static CharGroupItem Create(string characters)
        {
            return new CharactersItem(characters);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a character literal to it./>
        /// </summary>
        /// <param name="value">The character.</param>
        /// <returns></returns>
        public static CharGroupItem Create(char value)
        {
            return new CharacterItem(value);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a character range to it./>
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        public static CharGroupItem Create(char first, char last)
        {
            return new RangeCharItem(first, last);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a character to it./>
        /// </summary>
        /// <param name="charCode">The character code.</param>
        /// <returns></returns>
        public static CharGroupItem Create(int charCode)
        {
            return new CharCodeCharItem(charCode);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a character range to it./>
        /// </summary>
        /// <param name="firstCharCode">The first character code of the range.</param>
        /// <param name="lastCharCode">The last character code of the range.</param>
        /// <returns></returns>
        public static CharGroupItem Create(int firstCharCode, int lastCharCode)
        {
            return new CodeRangeCharItem(firstCharCode, lastCharCode);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a character to it./>
        /// </summary>
        /// <param name="value">An enumerated constant that identifies an ASCII character literal.</param>
        /// <returns></returns>
        public static CharGroupItem Create(AsciiChar value)
        {
            return new AsciiCharItem(value);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a Unicode named block to it./>
        /// </summary>
        /// <param name="block">An enumerated constant that identifies an Unicode named block.</param>
        /// <returns></returns>
        public static CharGroupItem Create(NamedBlock block)
        {
            return Create(block, false);
        }

        public static CharGroupItem Create(NamedBlock block, bool negative)
        {
            return new NamedBlockCharItem(block, negative);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds an Unicode general category to it./>
        /// </summary>
        /// <param name="category">An enumerated constant that identifies an Unicode general category.</param>
        /// <returns></returns>
        public static CharGroupItem Create(GeneralCategory category)
        {
            return Create(category, false);
        }

        public static CharGroupItem Create(GeneralCategory category, bool negative)
        {
            return new GeneralCategoryCharItem(category, negative);
        }

        internal static CharGroupItem Create(CharClass value)
        {
            return new CharClassCharItem(value);
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
                WriteContentTo(writer);
                return writer.ToString();
            }
        }

        /// <summary>
        /// Appends a character literal to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <param name="value">The character.</param>
        /// <returns></returns>
        public CharGroupItem Concat(char value)
        {
            return Concat(Create(value));
        }

        /// <summary>
        /// Appends a character literal to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <param name="value">The character code.</param>
        /// <returns></returns>
        public CharGroupItem Concat(int value)
        {
            return Concat(Create(value));
        }

        /// <summary>
        /// Appends a character literal to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies an ASCII character literal.</param>
        /// <returns></returns>
        public CharGroupItem Concat(AsciiChar value)
        {
            return Concat(Create(value));
        }

        /// <summary>
        /// Appends a character literal to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <param name="value">A set of characters.</param>
        /// <returns></returns>
        public CharGroupItem Concat(string characters)
        {
            return Concat(Create(characters));
        }

        /// <summary>
        /// Appends a character range to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        public CharGroupItem Concat(char first, char last)
        {
            return Concat(Create(first, last));
        }

        /// <summary>
        /// Appends a character range to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <param name="firstCharCode">The first character code of the range.</param>
        /// <param name="lastCharCode">The last character code of the range.</param>
        /// <returns></returns>
        public CharGroupItem Concat(int firstCharCode, int lastCharCode)
        {
            return Concat(Create(firstCharCode, lastCharCode));
        }

        /// <summary>
        /// Appends an Unicode named block pattern to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies an Unicode named block.</param>
        /// <returns></returns>
        public CharGroupItem Concat(NamedBlock block)
        {
            return Concat(Create(block));
        }

        /// <summary>
        /// Appends an Unicode general category pattern to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies an Unicode general category.</param>
        /// <returns></returns>
        public CharGroupItem Concat(GeneralCategory category)
        {
            return Concat(Create(category));
        }

        /// <summary>
        /// Appends a negative Unicode named block pattern to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies an Unicode named block.</param>
        /// <returns></returns>
        public CharGroupItem Not(NamedBlock block)
        {
            return Concat(CharGroupItems.NotNamedBlock(block));
        }

        /// <summary>
        /// Appends a negative Unicode general category pattern to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies an Unicode general category.</param>
        /// <returns></returns>
        public CharGroupItem Not(GeneralCategory category)
        {
            return Concat(CharGroupItems.NotGeneralCategory(category));
        }

        /// <summary>
        /// Appends a digit character class to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <returns></returns>
        public CharGroupItem Digit()
        {
            return Concat(CharGroupItems.Digit());
        }

        /// <summary>
        /// Appends a non-digit character class to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <returns></returns>
        public CharGroupItem NotDigit()
        {
            return Concat(CharGroupItems.NotDigit());
        }

        /// <summary>
        /// Appends a white-space character class to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <returns></returns>
        public CharGroupItem WhiteSpace()
        {
            return Concat(CharGroupItems.WhiteSpace());
        }

        /// <summary>
        /// Appends a non-white-space character class to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <returns></returns>
        public CharGroupItem NotWhiteSpace()
        {
            return Concat(CharGroupItems.NotWhiteSpace());
        }

        /// <summary>
        /// Appends a word character class to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <returns></returns>
        public CharGroupItem WordChar()
        {
            return Concat(CharGroupItems.WordChar());
        }

        /// <summary>
        /// Appends a non-word character class to the current instance of the <see cref="CharGroupItem"/>.
        /// </summary>
        /// <returns></returns>
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

        public CharGroupItem NamedBlock(NamedBlock block)
        {
            return Concat(CharGroupItems.NamedBlock(block));
        }

        public CharGroupItem NotNamedBlock(NamedBlock block)
        {
            return Concat(CharGroupItems.NotNamedBlock(block));
        }

        public CharGroupItem GeneralCategory(GeneralCategory category)
        {
            return Concat(CharGroupItems.GeneralCategory(category));
        }

        public CharGroupItem NotGeneralCategory(GeneralCategory category)
        {
            return Concat(CharGroupItems.NotGeneralCategory(category));
        }

        public CharGroupItem Tab()
        {
            return Concat(CharGroupItems.Tab());
        }

        public CharGroupItem Linefeed()
        {
            return Concat(CharGroupItems.Linefeed());
        }

        public CharGroupItem CarriageReturn()
        {
            return Concat(CharGroupItems.CarriageReturn());
        }

        public CharGroupItem Space()
        {
            return Concat(CharGroupItems.Space());
        }

        public CharGroupItem ExclamationMark()
        {
            return Concat(CharGroupItems.ExclamationMark());
        }

        public CharGroupItem QuoteMark()
        {
            return Concat(CharGroupItems.QuoteMark());
        }

        public CharGroupItem NumberSign()
        {
            return Concat(CharGroupItems.NumberSign());
        }

        public CharGroupItem Dollar()
        {
            return Concat(CharGroupItems.Dollar());
        }

        public CharGroupItem Percent()
        {
            return Concat(CharGroupItems.Percent());
        }

        public CharGroupItem Ampersand()
        {
            return Concat(CharGroupItems.Ampersand());
        }

        public CharGroupItem Apostrophe()
        {
            return Concat(CharGroupItems.Apostrophe());
        }

        public CharGroupItem LeftParenthesis()
        {
            return Concat(CharGroupItems.LeftParenthesis());
        }

        public CharGroupItem RightParenthesis()
        {
            return Concat(CharGroupItems.RightParenthesis());
        }

        public CharGroupItem Asterisk()
        {
            return Concat(CharGroupItems.Asterisk());
        }

        public CharGroupItem Plus()
        {
            return Concat(CharGroupItems.Plus());
        }

        public CharGroupItem Comma()
        {
            return Concat(CharGroupItems.Comma());
        }

        public CharGroupItem Hyphen()
        {
            return Concat(CharGroupItems.Hyphen());
        }

        public CharGroupItem Period()
        {
            return Concat(CharGroupItems.Period());
        }

        public CharGroupItem Slash()
        {
            return Concat(CharGroupItems.Slash());
        }

        public CharGroupItem Colon()
        {
            return Concat(CharGroupItems.Colon());
        }

        public CharGroupItem Semicolon()
        {
            return Concat(CharGroupItems.Semicolon());
        }

        public CharGroupItem LessThan()
        {
            return Concat(CharGroupItems.LessThan());
        }

        public CharGroupItem EqualsSign()
        {
            return Concat(CharGroupItems.EqualsSign());
        }

        public CharGroupItem GreaterThan()
        {
            return Concat(CharGroupItems.GreaterThan());
        }

        public CharGroupItem QuestionMark()
        {
            return Concat(CharGroupItems.QuestionMark());
        }

        public CharGroupItem AtSign()
        {
            return Concat(CharGroupItems.AtSign());
        }

        public CharGroupItem LeftSquareBracket()
        {
            return Concat(CharGroupItems.LeftSquareBracket());
        }

        public CharGroupItem Backslash()
        {
            return Concat(CharGroupItems.Backslash());
        }

        public CharGroupItem RightSquareBracket()
        {
            return Concat(CharGroupItems.RightSquareBracket());
        }

        public CharGroupItem CircumflexAccent()
        {
            return Concat(CharGroupItems.CircumflexAccent());
        }

        public CharGroupItem Underscore()
        {
            return Concat(CharGroupItems.Underscore());
        }

        public CharGroupItem GraveAccent()
        {
            return Concat(CharGroupItems.GraveAccent());
        }

        public CharGroupItem LeftCurlyBracket()
        {
            return Concat(CharGroupItems.LeftCurlyBracket());
        }

        public CharGroupItem VerticalLine()
        {
            return Concat(CharGroupItems.VerticalLine());
        }

        public CharGroupItem RightCurlyBracket()
        {
            return Concat(CharGroupItems.RightCurlyBracket());
        }

        public CharGroupItem Tilde()
        {
            return Concat(CharGroupItems.Tilde());
        }

        /// <summary>
        /// Transforms the current instance of the <see cref="CharGroupItem" to the positive character group./>
        /// </summary>
        /// <returns></returns>
        public CharacterGroup ToGroup()
        {
            return new CharGroupItemGroup(this);
        }

        /// <summary>
        /// Transforms the current instance of the <see cref="CharGroupItem" to the negative character group./>
        /// </summary>
        /// <returns></returns>
        public CharacterGroup ToNegativeGroup()
        {
            return new CharGroupItemGroup(this, true);
        }

        protected abstract void WriteItemContentTo(PatternWriter writer);

        /// <summary>
        /// Writes the current instance to the output.
        /// </summary>
        /// <param name="writer">The output to be written to.</param>
        public void WriteBaseGroupTo(PatternWriter writer)
        {
            WriteContentTo(writer);
        }

        /// <summary>
        /// A character group containing the current instance is written to the output.
        /// </summary>
        /// <param name="writer">The output to be written to.</param>
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
        public static CharacterGroup operator !(CharGroupItem value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return Patterns.NotCharacter(value);
        }

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
