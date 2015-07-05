// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents an immutable content of the character group. Content can be a base group or an excluded group. This class is abstract.
    /// </summary>
    public abstract partial class CharGrouping
        : IBaseGroup, IExcludedGroup
    {
        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> class.
        /// </summary>
        protected CharGrouping()
        {
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> class containing specified characters.
        /// </summary>
        /// <param name="characters">A set of characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static CharGrouping Create(string characters)
        {
            return new CharactersCharGrouping(characters);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> class containing a specified character.
        /// </summary>
        /// <param name="value">The character.</param>
        /// <returns></returns>
        public static CharGrouping Create(char value)
        {
            return new CharacterCharGrouping(value);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> class containing a specified character range.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        public static CharGrouping Create(char first, char last)
        {
            return new CharacterRangeCharGrouping(first, last);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> class containing a specified character.
        /// </summary>
        /// <param name="charCode">The character interpreted as <see cref="System.Int32"/> object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CharGrouping Create(int charCode)
        {
            return new CharacterCodeCharGrouping(charCode);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> class containing a specified character range.
        /// </summary>
        /// <param name="firstCharCode">The first character code of the range.</param>
        /// <param name="lastCharCode">The last character code of the range.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CharGrouping Create(int firstCharCode, int lastCharCode)
        {
            return new CharacterCodeRangeCharGrouping(firstCharCode, lastCharCode);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> class containing a specified character.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public static CharGrouping Create(AsciiChar value)
        {
            return new AsciiCharacterCharGrouping(value);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> class containing a specified Unicode named block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode named block.</param>
        /// <returns></returns>
        public static CharGrouping Create(NamedBlock block)
        {
            return Create(block, false);
        }

        internal static CharGrouping Create(NamedBlock block, bool negative)
        {
            return new NamedBlockCharGrouping(block, negative);
        }

        /// <summary>
        /// Creates and returns a new instance of the <see cref="CharGrouping"/> class containing a specified Unicode general category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode general category.</param>
        /// <returns></returns>
        public static CharGrouping Create(GeneralCategory category)
        {
            return Create(category, false);
        }

        internal static CharGrouping Create(GeneralCategory category, bool negative)
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

        /// <summary>
        /// Returns the text representation of this instance.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            var builder = new PatternBuilder();
            AppendContentTo(builder);
            return builder.ToString();
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

        /// <summary>
        /// Appends a pattern that matches specified Unicode character.
        /// </summary>
        /// <param name="value">The character.</param>
        /// <returns></returns>
        public CharGrouping Concat(char value)
        {
            return Concat(Create(value));
        }

        /// <summary>
        /// Appends a pattern that matches specified Unicode character.
        /// </summary>
        /// <param name="value">The character code.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CharGrouping Concat(int value)
        {
            return Concat(Create(value));
        }

        /// <summary>
        /// Appends a pattern that matches specified Unicode character.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies a character literal.</param>
        /// <returns></returns>
        public CharGrouping Concat(AsciiChar value)
        {
            return Concat(Create(value));
        }

        /// <summary>
        /// Appends a pattern that matches any one of the specified characters.
        /// </summary>
        /// <param name="characters">A set of characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public CharGrouping Concat(string characters)
        {
            return Concat(Create(characters));
        }

        /// <summary>
        /// Appends a pattern that matches any one character from the specified range.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        public CharGrouping Concat(char first, char last)
        {
            return Concat(Create(first, last));
        }

        /// <summary>
        /// Appends a pattern that matches any one character from the specified range.
        /// </summary>
        /// <param name="firstCharCode">The first character code of the range.</param>
        /// <param name="lastCharCode">The last character code of the range.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public CharGrouping Concat(int firstCharCode, int lastCharCode)
        {
            return Concat(Create(firstCharCode, lastCharCode));
        }

        /// <summary>
        /// Appends a pattern that matches a character from the specified Unicode named block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode named block.</param>
        /// <returns></returns>
        public CharGrouping Concat(NamedBlock block)
        {
            return Concat(Create(block));
        }

        /// <summary>
        /// Appends a pattern that matches a character from the specified Unicode general category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode general category.</param>
        /// <returns></returns>
        public CharGrouping Concat(GeneralCategory category)
        {
            return Concat(Create(category));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not from the specified Unicode named block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode named block.</param>
        /// <returns></returns>
        public CharGrouping Not(NamedBlock block)
        {
            return Concat(CharGroupings.NotNamedBlock(block));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not from the specified Unicode general category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode general category.</param>
        /// <returns></returns>
        public CharGrouping Not(GeneralCategory category)
        {
            return Concat(CharGroupings.NotGeneralCategory(category));
        }

        /// <summary>
        /// Appends a pattern that matches a character from the digit character class.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Digit()
        {
            return Concat(CharGroupings.Digit());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not from the digit character class.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotDigit()
        {
            return Concat(CharGroupings.NotDigit());
        }

        /// <summary>
        /// Appends a pattern that matches a character from the white-space character class.
        /// </summary>
        /// <returns></returns>
        public CharGrouping WhiteSpace()
        {
            return Concat(CharGroupings.WhiteSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not from the white-space character class.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotWhiteSpace()
        {
            return Concat(CharGroupings.NotWhiteSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a character from the word character class.
        /// </summary>
        /// <returns></returns>
        public CharGrouping WordChar()
        {
            return Concat(CharGroupings.WordChar());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not from the word character class.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotWordChar()
        {
            return Concat(CharGroupings.NotWordChar());
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Alphanumeric()
        {
            return Concat(CharGroupings.Alphanumeric());
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet lower-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGrouping AlphanumericLower()
        {
            return Concat(CharGroupings.AlphanumericLower());
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet upper-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGrouping AlphanumericUpper()
        {
            return Concat(CharGroupings.AlphanumericUpper());
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet letter, an arabic digit or an underscore.
        /// </summary>
        /// <returns></returns>
        public CharGrouping AlphanumericUnderscore()
        {
            return Concat(CharGroupings.AlphanumericUnderscore());
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet letter.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LatinLetter()
        {
            return Concat(CharGroupings.LatinLetter());
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet lower-case letter.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LatinLetterLower()
        {
            return Concat(CharGroupings.LatinLetterLower());
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet upper-case letter.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LatinLetterUpper()
        {
            return Concat(CharGroupings.LatinLetterUpper());
        }

        /// <summary>
        /// Appends a pattern that matches a lower-case letter, i.e. a letter from Unicode general category LetterLowercase.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LetterLower()
        {
            return Concat(CharGroupings.LetterLower());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a lower-case letter. i.e. a character that is not from Unicode general category LetterLowercase.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotLetterLower()
        {
            return Concat(CharGroupings.NotLetterLower());
        }

        /// <summary>
        /// Appends a pattern that matches a upper-case letter. i.e. a letter from Unicode general category LetterUppercase.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LetterUpper()
        {
            return Concat(CharGroupings.LetterUpper());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a upper-case letter. i.e. a character that is not from Unicode general category LetterUppercase.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NotLetterUpper()
        {
            return Concat(CharGroupings.NotLetterUpper());
        }

        /// <summary>
        /// Matches an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGrouping ArabicDigit()
        {
            return Concat(CharGroupings.ArabicDigit());
        }

        /// <summary>
        /// Appends a pattern that matches a new line character, i.e. a linefeed character or a carriage return character.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NewLineChar()
        {
            return Concat(CharGroupings.NewLineChar());
        }

        /// <summary>
        /// Appends a pattern that matches a tab.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Tab()
        {
            return Concat(CharGroupings.Tab());
        }

        /// <summary>
        /// Appends a pattern that matches a linefeed.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Linefeed()
        {
            return Concat(CharGroupings.Linefeed());
        }

        /// <summary>
        /// Appends a pattern that matches a carriage return.
        /// </summary>
        /// <returns></returns>
        public CharGrouping CarriageReturn()
        {
            return Concat(CharGroupings.CarriageReturn());
        }

        /// <summary>
        /// Appends a pattern that matches a space character.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Space()
        {
            return Concat(CharGroupings.Space());
        }

        /// <summary>
        /// Appends a pattern that matches an exclamation mark.
        /// </summary>
        /// <returns></returns>
        public CharGrouping ExclamationMark()
        {
            return Concat(CharGroupings.ExclamationMark());
        }

        /// <summary>
        /// Appends a pattern that matches a quotation mark.
        /// </summary>
        /// <returns></returns>
        public CharGrouping QuoteMark()
        {
            return Concat(CharGroupings.QuoteMark());
        }

        /// <summary>
        /// Appends a pattern that matches a number sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping NumberSign()
        {
            return Concat(CharGroupings.NumberSign());
        }

        /// <summary>
        /// Appends a pattern that matches a dollar character.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Dollar()
        {
            return Concat(CharGroupings.Dollar());
        }

        /// <summary>
        /// Appends a pattern that matches a percent sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Percent()
        {
            return Concat(CharGroupings.Percent());
        }

        /// <summary>
        /// Matches an ampersand.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Ampersand()
        {
            return Concat(CharGroupings.Ampersand());
        }

        /// <summary>
        /// Appends a pattern that matches an apostrophe.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Apostrophe()
        {
            return Concat(CharGroupings.Apostrophe());
        }

        /// <summary>
        /// Appends a pattern that matches start parenthesis.
        /// </summary>
        /// <returns></returns>
        public CharGrouping StartParenthesis()
        {
            return Concat(CharGroupings.StartParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches end parenthesis.
        /// </summary>
        /// <returns></returns>
        public CharGrouping EndParenthesis()
        {
            return Concat(CharGroupings.EndParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches an asterisk.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Asterisk()
        {
            return Concat(CharGroupings.Asterisk());
        }

        /// <summary>
        /// Appends a pattern that matches a plus sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Plus()
        {
            return Concat(CharGroupings.Plus());
        }

        /// <summary>
        /// Appends a pattern that matches a comma.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Comma()
        {
            return Concat(CharGroupings.Comma());
        }

        /// <summary>
        /// Appends a pattern that matches a hyphen.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Hyphen()
        {
            return Concat(CharGroupings.Hyphen());
        }

        /// <summary>
        /// Appends a pattern that matches a period.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Dot()
        {
            return Concat(CharGroupings.Dot());
        }

        /// <summary>
        /// Appends a pattern that matches a slash.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Slash()
        {
            return Concat(CharGroupings.Slash());
        }

        /// <summary>
        /// Appends a pattern that matches a colon.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Colon()
        {
            return Concat(CharGroupings.Colon());
        }

        /// <summary>
        /// Appends a pattern that matches a semicolon.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Semicolon()
        {
            return Concat(CharGroupings.Semicolon());
        }

        /// <summary>
        /// Appends a pattern that matches a less-than sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping LessThan()
        {
            return Concat(CharGroupings.LessThan());
        }

        /// <summary>
        /// Appends a pattern that matches an equals sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping EqualsSign()
        {
            return Concat(CharGroupings.EqualsSign());
        }

        /// <summary>
        /// Appends a pattern that matches a greater-than sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping GreaterThan()
        {
            return Concat(CharGroupings.GreaterThan());
        }

        /// <summary>
        /// Appends a pattern that matches a question mark.
        /// </summary>
        /// <returns></returns>
        public CharGrouping QuestionMark()
        {
            return Concat(CharGroupings.QuestionMark());
        }

        /// <summary>
        /// Appends a pattern that matches an at sign.
        /// </summary>
        /// <returns></returns>
        public CharGrouping AtSign()
        {
            return Concat(CharGroupings.AtSign());
        }

        /// <summary>
        /// Appends a pattern that matches start square bracket.
        /// </summary>
        /// <returns></returns>
        public CharGrouping StartSquareBracket()
        {
            return Concat(CharGroupings.StartSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a backslash.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Backslash()
        {
            return Concat(CharGroupings.Backslash());
        }

        /// <summary>
        /// Appends a pattern that matches end square bracket.
        /// </summary>
        /// <returns></returns>
        public CharGrouping EndSquareBracket()
        {
            return Concat(CharGroupings.EndSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a circumflex accent.
        /// </summary>
        /// <returns></returns>
        public CharGrouping CircumflexAccent()
        {
            return Concat(CharGroupings.CircumflexAccent());
        }

        /// <summary>
        /// Appends a pattern that matches an underscore.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Underscore()
        {
            return Concat(CharGroupings.Underscore());
        }

        /// <summary>
        /// Appends a pattern that matches a grave accent.
        /// </summary>
        /// <returns></returns>
        public CharGrouping GraveAccent()
        {
            return Concat(CharGroupings.GraveAccent());
        }

        /// <summary>
        /// Appends a pattern that matches start curly bracket.
        /// </summary>
        /// <returns></returns>
        public CharGrouping StartCurlyBracket()
        {
            return Concat(CharGroupings.StartCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a vertical line.
        /// </summary>
        /// <returns></returns>
        public CharGrouping VerticalLine()
        {
            return Concat(CharGroupings.VerticalLine());
        }

        /// <summary>
        /// Appends a pattern that matches end curly bracket.
        /// </summary>
        /// <returns></returns>
        public CharGrouping EndCurlyBracket()
        {
            return Concat(CharGroupings.EndCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches start or end parenthesis.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Parenthesis()
        {
            return Concat(CharGroupings.Parenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches start or end square bracket.
        /// </summary>
        /// <returns></returns>
        public CharGrouping SquareBracket()
        {
            return Concat(CharGroupings.SquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches start or end curly bracket.
        /// </summary>
        /// <returns></returns>
        public CharGrouping CurlyBracket()
        {
            return Concat(CharGroupings.CurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a tilde.
        /// </summary>
        /// <returns></returns>
        public CharGrouping Tilde()
        {
            return Concat(CharGroupings.Tilde());
        }

        /// <summary>
        /// Converts the current instance of the <see cref="CharGrouping"/> to the positive character group.
        /// </summary>
        /// <returns></returns>
        public CharGroup ToGroup()
        {
            return CharGroup.Create(this, false);
        }

        /// <summary>
        /// Converts the current instance of the <see cref="CharGrouping"/> to the negative character group.
        /// </summary>
        /// <returns></returns>
        public CharGroup ToNegativeGroup()
        {
            return CharGroup.Create(this, true);
        }

        /// <summary>
        /// Appends a core content of the current instance to a specified <see cref="PatternBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to use for appending the core content.</param>
        protected abstract void AppendItemContentTo(PatternBuilder builder);

        /// <summary>
        /// Appends the text representation of the current instance of the character grouping to the specified <see cref="PatternBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to use for appending the character grouping text.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AppendBaseGroupTo(PatternBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            AppendContentTo(builder);
        }

        /// <summary>
        /// Appends the text representation of the character group containing the current instance to the specified <see cref="PatternBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to use for appending the character group text.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AppendExcludedGroupTo(PatternBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            builder.Append(this);
        }

        internal void AppendContentTo(PatternBuilder builder)
        {
            if (Previous != null)
            {
                Stack<CharGrouping> stack = builder.CharGroupings;
                int cnt = stack.Count;
                CharGrouping item = this;

                do
                {
                    stack.Push(item);
                    item = item.Previous;
                } while (item != null);

                while (stack.Count > cnt)
                {
                    stack.Pop().AppendItemContentTo(builder);
                }
            }
            else
            {
                AppendItemContentTo(builder);
            }
        }

        /// <summary>
        /// Concatenate two elements into a new <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="left">The first element to concatenate.</param>
        /// <param name="right">The second element to concatenate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Concatenate two elements into a new <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="left">The first element to concatenate.</param>
        /// <param name="right">The second element to concatenate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Concatenate two elements into a new <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="left">The first element to concatenate.</param>
        /// <param name="right">The second element to concatenate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Concatenate two elements into a new <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="left">The first element to concatenate.</param>
        /// <param name="right">The second element to concatenate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Concatenate two elements into a new <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="left">The first element to concatenate.</param>
        /// <param name="right">The second element to concatenate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Converts the current instance to the negative character group.
        /// </summary>
        /// <param name="value">A value</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroup operator !(CharGrouping value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return Patterns.NotCharacter(value);
        }

        /// <summary>
        /// Converts specified characters to an instance of the <see cref="CharGrouping"/> class.
        /// </summary>
        /// <param name="characters">A set of characters.</param>
        /// <returns></returns>
        public static explicit operator CharGrouping(string characters)
        {
            return Create(characters);
        }

        /// <summary>
        /// Converts specified character to an instance of the <see cref="CharGrouping"/> class.
        /// </summary>
        /// <param name="value">The character.</param>
        /// <returns></returns>
        public static explicit operator CharGrouping(char value)
        {
            return Create(value);
        }

        internal CharGrouping Previous { get; set; }
    }
}
