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
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> and adds a set of characters to it.
        /// </summary>
        /// <param name="characters">A set of characters.</param>
        /// <returns></returns>
        public static CharGrouping Create(string characters)
        {
            return new CharactersCharGrouping(characters);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> and adds a character literal to it.
        /// </summary>
        /// <param name="value">The character.</param>
        /// <returns></returns>
        public static CharGrouping Create(char value)
        {
            return new CharacterCharGrouping(value);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> and adds a character range to it.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        public static CharGrouping Create(char first, char last)
        {
            return new CharacterRangeCharGrouping(first, last);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> and adds a character to it.
        /// </summary>
        /// <param name="charCode">The character code.</param>
        /// <returns></returns>
        public static CharGrouping Create(int charCode)
        {
            return new CharacterCodeCharGrouping(charCode);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> and adds a character range to it.
        /// </summary>
        /// <param name="firstCharCode">The first character code of the range.</param>
        /// <param name="lastCharCode">The last character code of the range.</param>
        /// <returns></returns>
        public static CharGrouping Create(int firstCharCode, int lastCharCode)
        {
            return new CharacterCodeRangeCharGrouping(firstCharCode, lastCharCode);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> and adds a character to it.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies an ASCII character literal.</param>
        /// <returns></returns>
        public static CharGrouping Create(AsciiChar value)
        {
            return new AsciiCharacterCharGrouping(value);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> and adds Unicode named block to it.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode named block.</param>
        /// <returns></returns>
        public static CharGrouping Create(NamedBlock block)
        {
            return Create(block, false);
        }

        public static CharGrouping Create(NamedBlock block, bool negative)
        {
            return new NamedBlockCharGrouping(block, negative);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> and adds Unicode general category to it.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode general category.</param>
        /// <returns></returns>
        public static CharGrouping Create(GeneralCategory category)
        {
            return Create(category, false);
        }

        public static CharGrouping Create(GeneralCategory category, bool negative)
        {
            return new GeneralCategoryCharGrouping(category, negative);
        }

        internal static CharGrouping Create(CharClass value)
        {
            return new CharacterClassCharGrouping(value);
        }

        internal static CharGrouping Create(CharGrouping value)
        {
            return new CharGroupingCharGrouping(value);
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
        /// Matches Unicode character.
        /// </summary>
        /// <param name="value">The character.</param>
        /// <returns></returns>
        public CharGrouping Concat(char value)
        {
            return Concat(Create(value));
        }

        /// <summary>
        /// Matches Unicode character.
        /// </summary>
        /// <param name="value">The character code.</param>
        /// <returns></returns>
        public CharGrouping Concat(int value)
        {
            return Concat(Create(value));
        }

        /// <summary>
        /// Matches Unicode character.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies a character literal.</param>
        /// <returns></returns>
        public CharGrouping Concat(AsciiChar value)
        {
            return Concat(Create(value));
        }

        /// <summary>
        /// Matches any one of the characters.
        /// </summary>
        /// <param name="value">A set of characters.</param>
        /// <returns></returns>
        public CharGrouping Concat(string characters)
        {
            return Concat(Create(characters));
        }

        /// <summary>
        /// Matches any one character from the range.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        public CharGrouping Concat(char first, char last)
        {
            return Concat(Create(first, last));
        }

        /// <summary>
        /// Matches any one character from the range.
        /// </summary>
        /// <param name="firstCharCode">The first character code of the range.</param>
        /// <param name="lastCharCode">The last character code of the range.</param>
        /// <returns></returns>
        public CharGrouping Concat(int firstCharCode, int lastCharCode)
        {
            return Concat(Create(firstCharCode, lastCharCode));
        }

        /// <summary>
        /// Matches a character from a particular Unicode named block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode named block.</param>
        /// <returns></returns>
        public CharGrouping Concat(NamedBlock block)
        {
            return Concat(Create(block));
        }

        /// <summary>
        /// Matches a character from a particular Unicode general category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode general category.</param>
        /// <returns></returns>
        public CharGrouping Concat(GeneralCategory category)
        {
            return Concat(Create(category));
        }

        /// <summary>
        /// Matches a character that is not from a particular Unicode named block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode named block.</param>
        /// <returns></returns>
        public CharGrouping Not(NamedBlock block)
        {
            return Concat(CharGroupings.NotNamedBlock(block));
        }

        /// <summary>
        /// Matches a character that is not from a particular Unicode general category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode general category.</param>
        /// <returns></returns>
        public CharGrouping Not(GeneralCategory category)
        {
            return Concat(CharGroupings.NotGeneralCategory(category));
        }

        /// <summary>
        /// Matches a character from the digit character class.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Digit()
        {
            return Concat(CharGroupings.Digit());
        }

        /// <summary>
        /// Matches a character that is not from the digit character class.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotDigit()
        {
            return Concat(CharGroupings.NotDigit());
        }

        /// <summary>
        /// Matches a character from the white-space character class.
        /// </summary>
        /// <returns></returns>
        public CharGrouping WhiteSpace()
        {
            return Concat(CharGroupings.WhiteSpace());
        }

        /// <summary>
        /// Matches a character that is not from the white-space character class.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotWhiteSpace()
        {
            return Concat(CharGroupings.NotWhiteSpace());
        }

        /// <summary>
        /// Matches a character from the word character class.
        /// </summary>
        /// <returns></returns>
        public CharGrouping WordChar()
        {
            return Concat(CharGroupings.WordChar());
        }

        /// <summary>
        /// Matches a character that is not from the word character class.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotWordChar()
        {
            return Concat(CharGroupings.NotWordChar());
        }

        /// <summary>
        /// Matches a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Alphanumeric()
        {
            return Concat(CharGroupings.Alphanumeric());
        }

        /// <summary>
        /// Matches a latin alphabet lower-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGrouping AlphanumericLower()
        {
            return Concat(CharGroupings.AlphanumericLower());
        }

        /// <summary>
        /// Matches a latin alphabet upper-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGrouping AlphanumericUpper()
        {
            return Concat(CharGroupings.AlphanumericUpper());
        }

        /// <summary>
        /// Matches a latin alphabet letter.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LatinLetter()
        {
            return Concat(CharGroupings.LatinLetter());
        }

        /// <summary>
        /// Matches a latin alphabet lower-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LatinLetterLower()
        {
            return Concat(CharGroupings.LatinLetterLower());
        }

        /// <summary>
        /// Matches a latin alphabet upper-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LatinLetterUpper()
        {
            return Concat(CharGroupings.LatinLetterUpper());
        }

        /// <summary>
        /// Matches a lower-case letter. That is, a letter from the general category LetterLowercase.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LetterLower()
        {
            return Concat(CharGroupings.LetterLower());
        }

        /// <summary>
        /// Matches a character that is not a lower-case letter. That is, a character that is not from the general category LetterLowercase.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotLetterLower()
        {
            return Concat(CharGroupings.NotLetterLower());
        }

        /// <summary>
        /// Matches a upper-case letter. That is, a letter from the general category LetterUppercase.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LetterUpper()
        {
            return Concat(CharGroupings.LetterUpper());
        }

        /// <summary>
        /// Matches a character that is not a upper-case letter. That is, a character that is not from the general category LetterUppercase.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotLetterUpper()
        {
            return Concat(CharGroupings.NotLetterUpper());
        }

        /// <summary>
        /// Matches an arabic digit. This can be a digit in range from 0 to 9.
        /// </summary>
        /// <returns></returns>
        public CharGrouping ArabicDigit()
        {
            return Concat(CharGroupings.ArabicDigit());
        }

        /// <summary>
        /// Matches a new line character. This can be a linefeed character or a carriage return character.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NewLineChar()
        {
            return Concat(CharGroupings.NewLineChar());
        }

        /// <summary>
        /// Matches a tab.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Tab()
        {
            return Concat(CharGroupings.Tab());
        }

        /// <summary>
        /// Matches a linefeed.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Linefeed()
        {
            return Concat(CharGroupings.Linefeed());
        }

        /// <summary>
        /// Matches a carriage return.
        /// </summary>
        /// <returns></returns>
        public CharGrouping CarriageReturn()
        {
            return Concat(CharGroupings.CarriageReturn());
        }

        /// <summary>
        /// Matches a space character.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Space()
        {
            return Concat(CharGroupings.Space());
        }

        /// <summary>
        /// Matches an exclamation mark.
        /// </summary>
        /// <returns></returns>
        public CharGrouping ExclamationMark()
        {
            return Concat(CharGroupings.ExclamationMark());
        }

        /// <summary>
        /// Matches a quotation mark.
        /// </summary>
        /// <returns></returns>
        public CharGrouping QuoteMark()
        {
            return Concat(CharGroupings.QuoteMark());
        }

        /// <summary>
        /// Matches a number sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NumberSign()
        {
            return Concat(CharGroupings.NumberSign());
        }

        /// <summary>
        /// Matches a dollar character.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Dollar()
        {
            return Concat(CharGroupings.Dollar());
        }

        /// <summary>
        /// Matches a percent sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Percent()
        {
            return Concat(CharGroupings.Percent());
        }

        /// <summary>
        /// Matches an ampersand character.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Ampersand()
        {
            return Concat(CharGroupings.Ampersand());
        }

        /// <summary>
        /// Matches an apostrophe.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Apostrophe()
        {
            return Concat(CharGroupings.Apostrophe());
        }

        /// <summary>
        /// Matches a left parenthesis.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LeftParenthesis()
        {
            return Concat(CharGroupings.LeftParenthesis());
        }

        /// <summary>
        /// Matches a right parenthesis.
        /// </summary>
        /// <returns></returns>
        public CharGrouping RightParenthesis()
        {
            return Concat(CharGroupings.RightParenthesis());
        }

        /// <summary>
        /// Matches an asterisk.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Asterisk()
        {
            return Concat(CharGroupings.Asterisk());
        }

        /// <summary>
        /// Matches a plus sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Plus()
        {
            return Concat(CharGroupings.Plus());
        }

        /// <summary>
        /// Matches a comma.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Comma()
        {
            return Concat(CharGroupings.Comma());
        }

        /// <summary>
        /// Matches a hyphen
        /// </summary>
        /// <returns></returns>
        public CharGrouping Hyphen()
        {
            return Concat(CharGroupings.Hyphen());
        }

        /// <summary>
        /// Matches a period.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Period()
        {
            return Concat(CharGroupings.Period());
        }

        /// <summary>
        /// Matches a slash.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Slash()
        {
            return Concat(CharGroupings.Slash());
        }

        /// <summary>
        /// Matches a colon.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Colon()
        {
            return Concat(CharGroupings.Colon());
        }

        /// <summary>
        /// Matches a semicolon.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Semicolon()
        {
            return Concat(CharGroupings.Semicolon());
        }

        /// <summary>
        /// Matches a less-than sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LessThan()
        {
            return Concat(CharGroupings.LessThan());
        }

        /// <summary>
        /// Matches an equals sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping EqualsSign()
        {
            return Concat(CharGroupings.EqualsSign());
        }

        /// <summary>
        /// Matches a greater-than sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping GreaterThan()
        {
            return Concat(CharGroupings.GreaterThan());
        }

        /// <summary>
        /// Matches a question mark.
        /// </summary>
        /// <returns></returns>
        public CharGrouping QuestionMark()
        {
            return Concat(CharGroupings.QuestionMark());
        }

        /// <summary>
        /// Matches at sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping AtSign()
        {
            return Concat(CharGroupings.AtSign());
        }

        /// <summary>
        /// Matches left square bracket.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LeftSquareBracket()
        {
            return Concat(CharGroupings.LeftSquareBracket());
        }

        /// <summary>
        /// Matches a backslash.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Backslash()
        {
            return Concat(CharGroupings.Backslash());
        }

        /// <summary>
        /// Matches right square bracket.
        /// </summary>
        /// <returns></returns>
        public CharGrouping RightSquareBracket()
        {
            return Concat(CharGroupings.RightSquareBracket());
        }

        /// <summary>
        /// Matches a circumflex accent.
        /// </summary>
        /// <returns></returns>
        public CharGrouping CircumflexAccent()
        {
            return Concat(CharGroupings.CircumflexAccent());
        }

        /// <summary>
        /// Matches an underscore.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Underscore()
        {
            return Concat(CharGroupings.Underscore());
        }

        /// <summary>
        /// Matches a grave accent.
        /// </summary>
        /// <returns></returns>
        public CharGrouping GraveAccent()
        {
            return Concat(CharGroupings.GraveAccent());
        }

        /// <summary>
        /// Matches a left curly bracket.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LeftCurlyBracket()
        {
            return Concat(CharGroupings.LeftCurlyBracket());
        }

        /// <summary>
        /// Matches a vertical line.
        /// </summary>
        /// <returns></returns>
        public CharGrouping VerticalLine()
        {
            return Concat(CharGroupings.VerticalLine());
        }

        /// <summary>
        /// Matches a right curly bracket.
        /// </summary>
        /// <returns></returns>
        public CharGrouping RightCurlyBracket()
        {
            return Concat(CharGroupings.RightCurlyBracket());
        }

        /// <summary>
        /// Matches a tilde.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Tilde()
        {
            return Concat(CharGroupings.Tilde());
        }

        /// <summary>
        /// Transforms the current instance of the <see cref="CharGrouping" to the positive character group./>
        /// </summary>
        /// <returns></returns>
        public CharacterGroup ToGroup()
        {
            return CharacterGroup.Create(this, false);
        }

        /// <summary>
        /// Transforms the current instance of the <see cref="CharGrouping" to the negative character group./>
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
                CharGrouping item = this;
                Stack<CharGrouping> stack = writer.CharGroupings;

                do
                {
                    stack.Push(item);
                    item = item.Previous;
                } while (item != null);

                while (stack.Count > 0)
                {
                    stack.Pop().WriteItemContentTo(writer);
                }
            }
            else
            {
                WriteItemContentTo(writer);
            }
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

            return left.Concat(Create(right));
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

            return CharGrouping.Create(left).Concat(Create(right));
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

            return CharGrouping.Create(left).Concat(Create(right));
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
