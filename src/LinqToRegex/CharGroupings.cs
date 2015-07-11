// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Exposes static methods that returns instance of <see cref="CharGrouping"/> class. <see cref="CharGrouping"/> class represents a character group content.
    /// </summary>
    public static class CharGroupings
    {
        /// <summary>
        /// Returns a pattern that matches a character from the specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        /// <returns></returns>
        public static CharGrouping NamedBlock(NamedBlock block)
        {
            return CharGrouping.Create(block);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from the specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        /// <returns></returns>
        public static CharGrouping NotNamedBlock(NamedBlock block)
        {
            return CharGrouping.Create(block, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character from the specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        /// <returns></returns>
        public static CharGrouping GeneralCategory(GeneralCategory category)
        {
            return CharGrouping.Create(category);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from the specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        /// <returns></returns>
        public static CharGrouping NotGeneralCategory(GeneralCategory category)
        {
            return CharGrouping.Create(category, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character from the digit character class.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Digit()
        {
            return CharGrouping.Create(CharClass.Digit);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from the digit character class.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping NotDigit()
        {
            return CharGrouping.Create(CharClass.NotDigit);
        }

        /// <summary>
        /// Returns a pattern that matches a character from the white-space character class.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping WhiteSpace()
        {
            return CharGrouping.Create(CharClass.WhiteSpace);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from the digit character class.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping NotWhiteSpace()
        {
            return CharGrouping.Create(CharClass.NotWhiteSpace);
        }

        /// <summary>
        /// Returns a pattern that matches a character from the word character class.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping WordChar()
        {
            return CharGrouping.Create(CharClass.WordChar);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from the word character class.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping NotWordChar()
        {
            return CharGrouping.Create(CharClass.NotWordChar);
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
        /// Appends a pattern that matches a lower-case alphanumeric character. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also match upper-case latin letter.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping AlphanumericLower()
        {
            return LatinLetterLower().ArabicDigit();
        }

        /// <summary>
        /// Appends a pattern that matches an upper-case alphanumeric character. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also match lower-case latin letter.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping AlphanumericUpper()
        {
            return LatinLetterUpper().ArabicDigit();
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
            return LatinLetterLower().LatinLetterUpper();
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet lower-case letter. If the "ignore case" option is applied the pattern will also match upper-case latin letter.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping LatinLetterLower()
        {
            return CharGrouping.Create('a', 'z');
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet upper-case letter. If the "ignore case" option is applied the pattern will also match lower-case latin letter.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping LatinLetterUpper()
        {
            return CharGrouping.Create('A', 'Z');
        }

        /// <summary>
        /// Appends a pattern that matches a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// If the "ignore case" option is applied the pattern will also match a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping LetterLower()
        {
            return CharGrouping.Create(Linq.GeneralCategory.LetterLowercase);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// If the "ignore case" option is applied the pattern will also not match a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping NotLetterLower()
        {
            return CharGrouping.Create(Linq.GeneralCategory.LetterLowercase, true);
        }

        /// <summary>
        /// Appends a pattern that matches a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// If the "ignore case" option is applied the pattern will also match a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping LetterUpper()
        {
            return CharGrouping.Create(Linq.GeneralCategory.LetterUppercase);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// If the "ignore case" option is applied the pattern will also not match a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping NotLetterUpper()
        {
            return CharGrouping.Create(Linq.GeneralCategory.LetterUppercase, true);
        }

        /// <summary>
        /// Returns a pattern that matches an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping ArabicDigit()
        {
            return CharGrouping.Create('0', '9');
        }

        /// <summary>
        /// Returns a pattern that matches a hexadecimal digit.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping HexadecimalDigit()
        {
            return ArabicDigit().Concat('a', 'f').Concat('A', 'F');
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
            return CharGrouping.Create(AsciiChar.Tab);
        }

        /// <summary>
        /// Returns a pattern that matches a linefeed.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Linefeed()
        {
            return CharGrouping.Create(AsciiChar.Linefeed);
        }

        /// <summary>
        /// Returns a pattern that matches a carriage return.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping CarriageReturn()
        {
            return CharGrouping.Create(AsciiChar.CarriageReturn);
        }

        /// <summary>
        /// Returns a pattern that matches a space character.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Space()
        {
            return CharGrouping.Create(AsciiChar.Space);
        }

        /// <summary>
        /// Returns a pattern that matches exclamation mark.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping ExclamationMark()
        {
            return CharGrouping.Create(AsciiChar.ExclamationMark);
        }

        /// <summary>
        /// Returns a pattern that matches a quotation mark.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping QuoteMark()
        {
            return CharGrouping.Create(AsciiChar.QuoteMark);
        }

        /// <summary>
        /// Returns a pattern that matches a number sign.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping NumberSign()
        {
            return CharGrouping.Create(AsciiChar.NumberSign);
        }

        /// <summary>
        /// Returns a pattern that matches a dollar character.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Dollar()
        {
            return CharGrouping.Create(AsciiChar.Dollar);
        }

        /// <summary>
        /// Returns a pattern that matches a percent sign.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Percent()
        {
            return CharGrouping.Create(AsciiChar.Percent);
        }

        /// <summary>
        /// Returns a pattern that matches an ampersand.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Ampersand()
        {
            return CharGrouping.Create(AsciiChar.Ampersand);
        }

        /// <summary>
        /// Returns a pattern that matches apostrophe.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Apostrophe()
        {
            return CharGrouping.Create(AsciiChar.Apostrophe);
        }

        /// <summary>
        /// Returns a pattern that matches start parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping StartParenthesis()
        {
            return CharGrouping.Create(AsciiChar.StartParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches end parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping EndParenthesis()
        {
            return CharGrouping.Create(AsciiChar.EndParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches an asterisk.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Asterisk()
        {
            return CharGrouping.Create(AsciiChar.Asterisk);
        }

        /// <summary>
        /// Returns a pattern that matches a plus sign.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Plus()
        {
            return CharGrouping.Create(AsciiChar.Plus);
        }

        /// <summary>
        /// Returns a pattern that matches a comma.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Comma()
        {
            return CharGrouping.Create(AsciiChar.Comma);
        }

        /// <summary>
        /// Returns a pattern that matches a hyphen.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Hyphen()
        {
            return CharGrouping.Create(AsciiChar.Hyphen);
        }

        /// <summary>
        /// Returns a pattern that matches a period.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Dot()
        {
            return CharGrouping.Create(AsciiChar.Dot);
        }

        /// <summary>
        /// Returns a pattern that matches a slash.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Slash()
        {
            return CharGrouping.Create(AsciiChar.Slash);
        }

        /// <summary>
        /// Returns a pattern that matches a colon.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Colon()
        {
            return CharGrouping.Create(AsciiChar.Colon);
        }

        /// <summary>
        /// Returns a pattern that matches a semicolon.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Semicolon()
        {
            return CharGrouping.Create(AsciiChar.Semicolon);
        }

        /// <summary>
        /// Returns a pattern that matches a start angle bracket (less-than sign).
        /// </summary>
        /// <returns></returns>
        public static CharGrouping StartAngleBracket()
        {
            return CharGrouping.Create(AsciiChar.StartAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches an equals sign.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping EqualsSign()
        {
            return CharGrouping.Create(AsciiChar.EqualsSign);
        }

        /// <summary>
        /// Returns a pattern that matches an end angle bracket (greater-than sign).
        /// </summary>
        /// <returns></returns>
        public static CharGrouping EndAngleBracket()
        {
            return CharGrouping.Create(AsciiChar.EndAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a question mark.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping QuestionMark()
        {
            return CharGrouping.Create(AsciiChar.QuestionMark);
        }

        /// <summary>
        /// Returns a pattern that matches an at sign.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping AtSign()
        {
            return CharGrouping.Create(AsciiChar.AtSign);
        }

        /// <summary>
        /// Returns a pattern that matches start square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping StartSquareBracket()
        {
            return CharGrouping.Create(AsciiChar.StartSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a backslash.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Backslash()
        {
            return CharGrouping.Create(AsciiChar.Backslash);
        }

        /// <summary>
        /// Returns a pattern that matches right square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping EndSquareBracket()
        {
            return CharGrouping.Create(AsciiChar.EndSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a circumflex accent.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping CircumflexAccent()
        {
            return CharGrouping.Create(AsciiChar.CircumflexAccent);
        }

        /// <summary>
        /// Returns a pattern that matches an underscore.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Underscore()
        {
            return CharGrouping.Create(AsciiChar.Underscore);
        }

        /// <summary>
        /// Returns a pattern that matches a grave accent.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping GraveAccent()
        {
            return CharGrouping.Create(AsciiChar.GraveAccent);
        }

        /// <summary>
        /// Returns a pattern that matches left curly bracket
        /// </summary>
        /// <returns></returns>
        public static CharGrouping StartCurlyBracket()
        {
            return CharGrouping.Create(AsciiChar.StartCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a vertical line.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping VerticalLine()
        {
            return CharGrouping.Create(AsciiChar.VerticalLine);
        }

        /// <summary>
        /// Returns a pattern that matches right curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping EndCurlyBracket()
        {
            return CharGrouping.Create(AsciiChar.EndCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a tilde.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Tilde()
        {
            return CharGrouping.Create(AsciiChar.Tilde);
        }

        /// <summary>
        /// Returns a pattern that matches start or end parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping Parenthesis()
        {
            return StartParenthesis().EndParenthesis();
        }

        /// <summary>
        /// Returns a pattern that matches start or end square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping SquareBracket()
        {
            return StartSquareBracket().EndSquareBracket();
        }

        /// <summary>
        /// Returns a pattern that matches start or end curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGrouping CurlyBracket()
        {
            return StartCurlyBracket().EndCurlyBracket();
        }
    }
}
