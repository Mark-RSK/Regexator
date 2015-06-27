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
    public abstract partial class CharGrouping
        : IBaseGroup, IExcludedGroup
    {
        protected CharGrouping()
        {
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a set of characters to it./>
        /// </summary>
        /// <param name="characters">A set of characters.</param>
        /// <returns></returns>
        public static CharGrouping Create(string characters)
        {
            return new Characters(characters);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a character literal to it./>
        /// </summary>
        /// <param name="value">The character.</param>
        /// <returns></returns>
        public static CharGrouping Create(char value)
        {
            return new Character(value);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a character range to it./>
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        public static CharGrouping Create(char first, char last)
        {
            return new CharacterRange(first, last);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a character to it./>
        /// </summary>
        /// <param name="charCode">The character code.</param>
        /// <returns></returns>
        public static CharGrouping Create(int charCode)
        {
            return new CharacterCode(charCode);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a character range to it./>
        /// </summary>
        /// <param name="firstCharCode">The first character code of the range.</param>
        /// <param name="lastCharCode">The last character code of the range.</param>
        /// <returns></returns>
        public static CharGrouping Create(int firstCharCode, int lastCharCode)
        {
            return new CharacterCodeRange(firstCharCode, lastCharCode);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a character to it./>
        /// </summary>
        /// <param name="value">An enumerated constant that identifies an ASCII character literal.</param>
        /// <returns></returns>
        public static CharGrouping Create(AsciiChar value)
        {
            return new AsciiCharacter(value);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds a Unicode named block to it./>
        /// </summary>
        /// <param name="block">An enumerated constant that identifies an Unicode named block.</param>
        /// <returns></returns>
        public static CharGrouping Create(NamedBlock block)
        {
            return Create(block, false);
        }

        public static CharGrouping Create(NamedBlock block, bool negative)
        {
            return new UnicodeNamedBlock(block, negative);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGroupItem" and adds an Unicode general category to it./>
        /// </summary>
        /// <param name="category">An enumerated constant that identifies an Unicode general category.</param>
        /// <returns></returns>
        public static CharGrouping Create(GeneralCategory category)
        {
            return Create(category, false);
        }

        public static CharGrouping Create(GeneralCategory category, bool negative)
        {
            return new UnicodeGeneralCategory(category, negative);
        }

        internal static CharGrouping Create(CharClass value)
        {
            return new CharacterClass(value);
        }

        private CharGrouping Concat(CharGrouping value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            CharGrouping first = value;
            while (first.Previous != null)
            {
                first = first.Previous;
            }

            first.Previous = this;
            return value;
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
        /// Appends a character literal to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">The character.</param>
        /// <returns></returns>
        public CharGrouping Concat(char value)
        {
            return Concat(Create(value));
        }

        /// <summary>
        /// Appends a character literal to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">The character code.</param>
        /// <returns></returns>
        public CharGrouping Concat(int value)
        {
            return Concat(Create(value));
        }

        /// <summary>
        /// Appends a character literal to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies an ASCII character literal.</param>
        /// <returns></returns>
        public CharGrouping Concat(AsciiChar value)
        {
            return Concat(Create(value));
        }

        /// <summary>
        /// Appends a character literal to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">A set of characters.</param>
        /// <returns></returns>
        public CharGrouping Concat(string characters)
        {
            return Concat(Create(characters));
        }

        /// <summary>
        /// Appends a character range to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        public CharGrouping Concat(char first, char last)
        {
            return Concat(Create(first, last));
        }

        /// <summary>
        /// Appends a character range to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="firstCharCode">The first character code of the range.</param>
        /// <param name="lastCharCode">The last character code of the range.</param>
        /// <returns></returns>
        public CharGrouping Concat(int firstCharCode, int lastCharCode)
        {
            return Concat(Create(firstCharCode, lastCharCode));
        }

        /// <summary>
        /// Appends an Unicode named block pattern to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies an Unicode named block.</param>
        /// <returns></returns>
        public CharGrouping Concat(NamedBlock block)
        {
            return Concat(Create(block));
        }

        /// <summary>
        /// Appends an Unicode general category pattern to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies an Unicode general category.</param>
        /// <returns></returns>
        public CharGrouping Concat(GeneralCategory category)
        {
            return Concat(Create(category));
        }

        /// <summary>
        /// Appends a negative Unicode named block pattern to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies an Unicode named block.</param>
        /// <returns></returns>
        public CharGrouping Not(NamedBlock block)
        {
            return Concat(CharGroupings.NotNamedBlock(block));
        }

        /// <summary>
        /// Appends a negative Unicode general category pattern to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies an Unicode general category.</param>
        /// <returns></returns>
        public CharGrouping Not(GeneralCategory category)
        {
            return Concat(CharGroupings.NotGeneralCategory(category));
        }

        /// <summary>
        /// Appends a digit character class to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Digit()
        {
            return Concat(CharGroupings.Digit());
        }

        /// <summary>
        /// Appends a non-digit character class to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotDigit()
        {
            return Concat(CharGroupings.NotDigit());
        }

        /// <summary>
        /// Appends a white-space character class to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <returns></returns>
        public CharGrouping WhiteSpace()
        {
            return Concat(CharGroupings.WhiteSpace());
        }

        /// <summary>
        /// Appends a non-white-space character class to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotWhiteSpace()
        {
            return Concat(CharGroupings.NotWhiteSpace());
        }

        /// <summary>
        /// Appends a word character class to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <returns></returns>
        public CharGrouping WordChar()
        {
            return Concat(CharGroupings.WordChar());
        }

        /// <summary>
        /// Appends a non-word character class to the current instance of the <see cref="CharGrouping"/>.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotWordChar()
        {
            return Concat(CharGroupings.NotWordChar());
        }

        public CharGrouping Alphanumeric()
        {
            return Concat(CharGroupings.Alphanumeric());
        }

        public CharGrouping AlphanumericLower()
        {
            return Concat(CharGroupings.AlphanumericLower());
        }

        public CharGrouping AlphanumericUpper()
        {
            return Concat(CharGroupings.AlphanumericUpper());
        }

        public CharGrouping LatinLetter()
        {
            return Concat(CharGroupings.LatinLetter());
        }

        public CharGrouping LatinLetterLower()
        {
            return Concat(CharGroupings.LatinLetterLower());
        }

        public CharGrouping LatinLetterUpper()
        {
            return Concat(CharGroupings.LatinLetterUpper());
        }

        public CharGrouping ArabicDigit()
        {
            return Concat(CharGroupings.ArabicDigit());
        }

        public CharGrouping NewLineChar()
        {
            return Concat(CharGroupings.NewLineChar());
        }

        public CharGrouping NamedBlock(NamedBlock block)
        {
            return Concat(CharGroupings.NamedBlock(block));
        }

        public CharGrouping NotNamedBlock(NamedBlock block)
        {
            return Concat(CharGroupings.NotNamedBlock(block));
        }

        public CharGrouping GeneralCategory(GeneralCategory category)
        {
            return Concat(CharGroupings.GeneralCategory(category));
        }

        public CharGrouping NotGeneralCategory(GeneralCategory category)
        {
            return Concat(CharGroupings.NotGeneralCategory(category));
        }

        public CharGrouping Tab()
        {
            return Concat(CharGroupings.Tab());
        }

        public CharGrouping Linefeed()
        {
            return Concat(CharGroupings.Linefeed());
        }

        public CharGrouping CarriageReturn()
        {
            return Concat(CharGroupings.CarriageReturn());
        }

        public CharGrouping Space()
        {
            return Concat(CharGroupings.Space());
        }

        public CharGrouping ExclamationMark()
        {
            return Concat(CharGroupings.ExclamationMark());
        }

        public CharGrouping QuoteMark()
        {
            return Concat(CharGroupings.QuoteMark());
        }

        public CharGrouping NumberSign()
        {
            return Concat(CharGroupings.NumberSign());
        }

        public CharGrouping Dollar()
        {
            return Concat(CharGroupings.Dollar());
        }

        public CharGrouping Percent()
        {
            return Concat(CharGroupings.Percent());
        }

        public CharGrouping Ampersand()
        {
            return Concat(CharGroupings.Ampersand());
        }

        public CharGrouping Apostrophe()
        {
            return Concat(CharGroupings.Apostrophe());
        }

        public CharGrouping LeftParenthesis()
        {
            return Concat(CharGroupings.LeftParenthesis());
        }

        public CharGrouping RightParenthesis()
        {
            return Concat(CharGroupings.RightParenthesis());
        }

        public CharGrouping Asterisk()
        {
            return Concat(CharGroupings.Asterisk());
        }

        public CharGrouping Plus()
        {
            return Concat(CharGroupings.Plus());
        }

        public CharGrouping Comma()
        {
            return Concat(CharGroupings.Comma());
        }

        public CharGrouping Hyphen()
        {
            return Concat(CharGroupings.Hyphen());
        }

        public CharGrouping Period()
        {
            return Concat(CharGroupings.Period());
        }

        public CharGrouping Slash()
        {
            return Concat(CharGroupings.Slash());
        }

        public CharGrouping Colon()
        {
            return Concat(CharGroupings.Colon());
        }

        public CharGrouping Semicolon()
        {
            return Concat(CharGroupings.Semicolon());
        }

        public CharGrouping LessThan()
        {
            return Concat(CharGroupings.LessThan());
        }

        public CharGrouping EqualsSign()
        {
            return Concat(CharGroupings.EqualsSign());
        }

        public CharGrouping GreaterThan()
        {
            return Concat(CharGroupings.GreaterThan());
        }

        public CharGrouping QuestionMark()
        {
            return Concat(CharGroupings.QuestionMark());
        }

        public CharGrouping AtSign()
        {
            return Concat(CharGroupings.AtSign());
        }

        public CharGrouping LeftSquareBracket()
        {
            return Concat(CharGroupings.LeftSquareBracket());
        }

        public CharGrouping Backslash()
        {
            return Concat(CharGroupings.Backslash());
        }

        public CharGrouping RightSquareBracket()
        {
            return Concat(CharGroupings.RightSquareBracket());
        }

        public CharGrouping CircumflexAccent()
        {
            return Concat(CharGroupings.CircumflexAccent());
        }

        public CharGrouping Underscore()
        {
            return Concat(CharGroupings.Underscore());
        }

        public CharGrouping GraveAccent()
        {
            return Concat(CharGroupings.GraveAccent());
        }

        public CharGrouping LeftCurlyBracket()
        {
            return Concat(CharGroupings.LeftCurlyBracket());
        }

        public CharGrouping VerticalLine()
        {
            return Concat(CharGroupings.VerticalLine());
        }

        public CharGrouping RightCurlyBracket()
        {
            return Concat(CharGroupings.RightCurlyBracket());
        }

        public CharGrouping Tilde()
        {
            return Concat(CharGroupings.Tilde());
        }

        /// <summary>
        /// Transforms the current instance of the <see cref="CharGroupItem" to the positive character group./>
        /// </summary>
        /// <returns></returns>
        public CharacterGroup ToGroup()
        {
            return CharacterGroup.Create(this, false);
        }

        /// <summary>
        /// Transforms the current instance of the <see cref="CharGroupItem" to the negative character group./>
        /// </summary>
        /// <returns></returns>
        public CharacterGroup ToNegativeGroup()
        {
            return CharacterGroup.Create(this, true);
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
                CharGrouping[] items = GetItems().ToArray();
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

        private IEnumerable<CharGrouping> GetItems()
        {
            CharGrouping item = this;
            do
            {
                yield return item;
                item = item.Previous;
            } while (item != null);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGrouping operator +(CharGrouping left, CharGrouping right)
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
        public static CharGrouping operator +(CharGrouping left, string right)
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
        public static CharGrouping operator +(string left, CharGrouping right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return CharGrouping.Create(left).Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGrouping operator +(CharGrouping left, char right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            return left.Concat(right);
        }

        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGrouping operator +(char left, CharGrouping right)
        {
            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return CharGrouping.Create(left).Concat(right);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharacterGroup operator !(CharGrouping value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return Patterns.NotCharacter(value);
        }

        public static explicit operator CharGrouping(string characters)
        {
            return Create(characters);
        }

        public static explicit operator CharGrouping(char value)
        {
            return Create(value);
        }

        internal CharGrouping Previous { get; set; }
    }
}
