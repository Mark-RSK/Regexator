// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Exposes static methods that returns instance of <see cref="CharGrouping"/> class. <see cref="CharGrouping"/> class represents a character group content.
    /// </summary>
    public static class CharGroupings
    {
        /// <summary>
        /// Returns a pattern that matches any one of the specified characters.
        /// </summary>
        /// <param name="characters">A set of Unicode characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static CharGrouping Character(string characters)
        {
            return new CharGrouping.CharactersCharGrouping(characters);
        }

        /// <summary>
        /// Returns a pattern that matches specified Unicode character.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns></returns>
        public static CharGrouping Character(char value)
        {
            return new CharGrouping.CharacterCharGrouping(value);
        }

        /// <summary>
        /// Returns a pattern that matches specified Unicode character.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public static CharGrouping Character(AsciiChar value)
        {
            return new CharGrouping.AsciiCharacterCharGrouping(value);
        }

        /// <summary>
        /// Returns a pattern that matches a character from the specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        /// <returns></returns>
        public static CharGrouping Character(NamedBlock block)
        {
            return Character(block, false);
        }

        internal static CharGrouping Character(NamedBlock block, bool negative)
        {
            return new CharGrouping.NamedBlockCharGrouping(block, negative);
        }

        /// <summary>
        /// Returns a pattern that matches a character from the specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        /// <returns></returns>
        public static CharGrouping Character(GeneralCategory category)
        {
            return Character(category, false);
        }

        internal static CharGrouping Character(GeneralCategory category, bool negative)
        {
            return new CharGrouping.GeneralCategoryCharGrouping(category, negative);
        }

        internal static CharGrouping Character(CharClass value)
        {
            return new CharGrouping.CharacterClassCharGrouping(value);
        }

        internal static CharGrouping Character(CharGrouping value)
        {
            return new CharGrouping.CharGroupingCharGrouping(value);
        }

        /// <summary>
        /// Returns a pattern that matches any one character from the specified range.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        public static CharGrouping Range(char first, char last)
        {
            return new CharGrouping.CharacterRangeCharGrouping(first, last);
        }

        /// <summary>
        /// Returns a pattern that matches a character from the specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        /// <returns></returns>
        public static CharGrouping NamedBlock(NamedBlock block)
        {
            return Character(block);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from the specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        /// <returns></returns>
        public static CharGrouping Not(NamedBlock block)
        {
            return Character(block, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character from the specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        /// <returns></returns>
        public static CharGrouping GeneralCategory(GeneralCategory category)
        {
            return Character(category);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from the specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        /// <returns></returns>
        public static CharGrouping Not(GeneralCategory category)
        {
            return Character(category, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character from the digit character class.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Digit()
        {
            return Character(CharClass.Digit);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from the digit character class.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping NotDigit()
        {
            return Character(CharClass.NotDigit);
        }

        /// <summary>
        /// Returns a pattern that matches a character from the white-space character class.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping WhiteSpace()
        {
            return Character(CharClass.WhiteSpace);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from the digit character class.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping NotWhiteSpace()
        {
            return Character(CharClass.NotWhiteSpace);
        }

        /// <summary>
        /// Returns a pattern that matches a character from the word character class.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping WordChar()
        {
            return Character(CharClass.WordChar);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from the word character class.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping NotWordChar()
        {
            return Character(CharClass.NotWordChar);
        }

        /// <summary>
        /// Returns a pattern that matches a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Alphanumeric()
        {
            return LatinLetter().ArabicDigit();
        }

        /// <summary>
        /// Returns a pattern that matches a latin alphabet letter, an arabic digit or an underscore.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping AlphanumericUnderscore()
        {
            return Alphanumeric().Underscore();
        }

        /// <summary>
        /// Returns a pattern that matches a latin alphabet letter.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping LatinLetter()
        {
            return Range('a', 'z').Range('A', 'Z');
        }

        /// <summary>
        /// Returns a pattern that matches an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping ArabicDigit()
        {
            return Range('0', '9');
        }

        /// <summary>
        /// Returns a pattern that matches a hexadecimal digit.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping HexadecimalDigit()
        {
            return ArabicDigit().Range('a', 'f').Range('A', 'F');
        }

        /// <summary>
        /// Returns a pattern that matches a new line character, i.e. a linefeed character or a carriage return character.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping NewLineChar()
        {
            return CarriageReturn().Linefeed();
        }

        /// <summary>
        /// Returns a pattern that matches a tab.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Tab()
        {
            return Character(AsciiChar.Tab);
        }

        /// <summary>
        /// Returns a pattern that matches a linefeed.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Linefeed()
        {
            return Character(AsciiChar.Linefeed);
        }

        /// <summary>
        /// Returns a pattern that matches a carriage return.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping CarriageReturn()
        {
            return Character(AsciiChar.CarriageReturn);
        }

        /// <summary>
        /// Returns a pattern that matches a space character.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Space()
        {
            return Character(AsciiChar.Space);
        }

        /// <summary>
        /// Returns a pattern that matches exclamation mark.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping ExclamationMark()
        {
            return Character(AsciiChar.ExclamationMark);
        }

        /// <summary>
        /// Returns a pattern that matches a quotation mark.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping QuoteMark()
        {
            return Character(AsciiChar.QuoteMark);
        }

        /// <summary>
        /// Returns a pattern that matches a number sign.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping NumberSign()
        {
            return Character(AsciiChar.NumberSign);
        }

        /// <summary>
        /// Returns a pattern that matches a dollar character.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Dollar()
        {
            return Character(AsciiChar.Dollar);
        }

        /// <summary>
        /// Returns a pattern that matches a percent sign.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Percent()
        {
            return Character(AsciiChar.Percent);
        }

        /// <summary>
        /// Returns a pattern that matches an ampersand.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Ampersand()
        {
            return Character(AsciiChar.Ampersand);
        }

        /// <summary>
        /// Returns a pattern that matches apostrophe.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Apostrophe()
        {
            return Character(AsciiChar.Apostrophe);
        }

        /// <summary>
        /// Returns a pattern that matches left parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping LeftParenthesis()
        {
            return Character(AsciiChar.LeftParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches right parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping RightParenthesis()
        {
            return Character(AsciiChar.RightParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches an asterisk.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Asterisk()
        {
            return Character(AsciiChar.Asterisk);
        }

        /// <summary>
        /// Returns a pattern that matches a plus sign.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Plus()
        {
            return Character(AsciiChar.Plus);
        }

        /// <summary>
        /// Returns a pattern that matches a comma.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Comma()
        {
            return Character(AsciiChar.Comma);
        }

        /// <summary>
        /// Returns a pattern that matches a hyphen.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Hyphen()
        {
            return Character(AsciiChar.Hyphen);
        }

        /// <summary>
        /// Returns a pattern that matches a period.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Dot()
        {
            return Character(AsciiChar.Dot);
        }

        /// <summary>
        /// Returns a pattern that matches a slash.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Slash()
        {
            return Character(AsciiChar.Slash);
        }

        /// <summary>
        /// Returns a pattern that matches a colon.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Colon()
        {
            return Character(AsciiChar.Colon);
        }

        /// <summary>
        /// Returns a pattern that matches a semicolon.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Semicolon()
        {
            return Character(AsciiChar.Semicolon);
        }

        /// <summary>
        /// Returns a pattern that matches a left angle bracket (less-than sign).
        /// </summary>
        /// <returns></returns>
        public static CharGrouping LeftAngleBracket()
        {
            return Character(AsciiChar.LeftAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches an equals sign.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping EqualsSign()
        {
            return Character(AsciiChar.EqualsSign);
        }

        /// <summary>
        /// Returns a pattern that matches a right angle bracket (greater-than sign).
        /// </summary>
        /// <returns></returns>
        public static CharGrouping RightAngleBracket()
        {
            return Character(AsciiChar.RightAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a question mark.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping QuestionMark()
        {
            return Character(AsciiChar.QuestionMark);
        }

        /// <summary>
        /// Returns a pattern that matches an at sign.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping AtSign()
        {
            return Character(AsciiChar.AtSign);
        }

        /// <summary>
        /// Returns a pattern that matches left square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping LeftSquareBracket()
        {
            return Character(AsciiChar.LeftSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a backslash.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Backslash()
        {
            return Character(AsciiChar.Backslash);
        }

        /// <summary>
        /// Returns a pattern that matches right square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping RightSquareBracket()
        {
            return Character(AsciiChar.RightSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a circumflex accent.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping CircumflexAccent()
        {
            return Character(AsciiChar.CircumflexAccent);
        }

        /// <summary>
        /// Returns a pattern that matches an underscore.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Underscore()
        {
            return Character(AsciiChar.Underscore);
        }

        /// <summary>
        /// Returns a pattern that matches a grave accent.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping GraveAccent()
        {
            return Character(AsciiChar.GraveAccent);
        }

        /// <summary>
        /// Returns a pattern that matches left curly bracket
        /// </summary>
        /// <returns></returns>
        public static CharGrouping LeftCurlyBracket()
        {
            return Character(AsciiChar.LeftCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a vertical bar.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping VerticalBar()
        {
            return Character(AsciiChar.VerticalBar);
        }

        /// <summary>
        /// Returns a pattern that matches right curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping RightCurlyBracket()
        {
            return Character(AsciiChar.RightCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a tilde.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Tilde()
        {
            return Character(AsciiChar.Tilde);
        }

        /// <summary>
        /// Returns a pattern that matches left or right parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Parenthesis()
        {
            return LeftParenthesis().RightParenthesis();
        }

        /// <summary>
        /// Returns a pattern that matches left or right square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping SquareBracket()
        {
            return LeftSquareBracket().RightSquareBracket();
        }

        /// <summary>
        /// Returns a pattern that matches left or right curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping CurlyBracket()
        {
            return LeftCurlyBracket().RightCurlyBracket();
        }
    }
}
