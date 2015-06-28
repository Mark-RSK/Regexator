// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

//TODO add xml comments

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class CharGroupings
    {
        public static CharGrouping NamedBlock(NamedBlock block)
        {
            return CharGrouping.Create(block);
        }

        public static CharGrouping NotNamedBlock(NamedBlock block)
        {
            return CharGrouping.Create(block, true);
        }

        public static CharGrouping GeneralCategory(GeneralCategory category)
        {
            return CharGrouping.Create(category);
        }

        public static CharGrouping NotGeneralCategory(GeneralCategory category)
        {
            return CharGrouping.Create(category, true);
        }

        public static CharGrouping Digit()
        {
            return CharGrouping.Create(CharClass.Digit);
        }

        public static CharGrouping NotDigit()
        {
            return CharGrouping.Create(CharClass.NotDigit);
        }

        public static CharGrouping WhiteSpace()
        {
            return CharGrouping.Create(CharClass.WhiteSpace);
        }

        public static CharGrouping NotWhiteSpace()
        {
            return CharGrouping.Create(CharClass.NotWhiteSpace);
        }

        public static CharGrouping WordChar()
        {
            return CharGrouping.Create(CharClass.WordChar);
        }

        public static CharGrouping NotWordChar()
        {
            return CharGrouping.Create(CharClass.NotWordChar);
        }

        public static CharGrouping Alphanumeric()
        {
            return LatinLetter().ArabicDigit();
        }

        public static CharGrouping AlphanumericLower()
        {
            return LatinLetterLower().ArabicDigit();
        }

        public static CharGrouping AlphanumericUpper()
        {
            return LatinLetterUpper().ArabicDigit();
        }

        public static CharGrouping AlphanumericUnderscore()
        {
            return Alphanumeric().Underscore();
        }

        public static CharGrouping LatinLetter()
        {
            return LatinLetterLower().LatinLetterUpper();
        }

        public static CharGrouping LatinLetterLower()
        {
            return CharGrouping.Create('a', 'z');
        }

        public static CharGrouping LatinLetterUpper()
        {
            return CharGrouping.Create('A', 'Z');
        }

        public static CharGrouping ArabicDigit()
        {
            return CharGrouping.Create('0', '9');
        }

        public static CharGrouping HexadecimalDigit()
        {
            return ArabicDigit().Concat('a', 'f').Concat('A', 'F');
        }

        public static CharGrouping NewLineChar()
        {
            return CarriageReturn().Linefeed();
        }

        public static CharGrouping Tab()
        {
            return CharGrouping.Create(AsciiChar.Tab);
        }

        public static CharGrouping Linefeed()
        {
            return CharGrouping.Create(AsciiChar.Linefeed);
        }

        public static CharGrouping CarriageReturn()
        {
            return CharGrouping.Create(AsciiChar.CarriageReturn);
        }

        public static CharGrouping Space()
        {
            return CharGrouping.Create(AsciiChar.Space);
        }

        public static CharGrouping ExclamationMark()
        {
            return CharGrouping.Create(AsciiChar.ExclamationMark);
        }

        public static CharGrouping QuoteMark()
        {
            return CharGrouping.Create(AsciiChar.QuoteMark);
        }

        public static CharGrouping NumberSign()
        {
            return CharGrouping.Create(AsciiChar.NumberSign);
        }

        public static CharGrouping Dollar()
        {
            return CharGrouping.Create(AsciiChar.Dollar);
        }

        public static CharGrouping Percent()
        {
            return CharGrouping.Create(AsciiChar.Percent);
        }

        public static CharGrouping Ampersand()
        {
            return CharGrouping.Create(AsciiChar.Ampersand);
        }

        public static CharGrouping Apostrophe()
        {
            return CharGrouping.Create(AsciiChar.Apostrophe);
        }

        public static CharGrouping LeftParenthesis()
        {
            return CharGrouping.Create(AsciiChar.LeftParenthesis);
        }

        public static CharGrouping RightParenthesis()
        {
            return CharGrouping.Create(AsciiChar.RightParenthesis);
        }

        public static CharGrouping Asterisk()
        {
            return CharGrouping.Create(AsciiChar.Asterisk);
        }

        public static CharGrouping Plus()
        {
            return CharGrouping.Create(AsciiChar.Plus);
        }

        public static CharGrouping Comma()
        {
            return CharGrouping.Create(AsciiChar.Comma);
        }

        public static CharGrouping Hyphen()
        {
            return CharGrouping.Create(AsciiChar.Hyphen);
        }

        public static CharGrouping Period()
        {
            return CharGrouping.Create(AsciiChar.Period);
        }

        public static CharGrouping Slash()
        {
            return CharGrouping.Create(AsciiChar.Slash);
        }

        public static CharGrouping Colon()
        {
            return CharGrouping.Create(AsciiChar.Colon);
        }

        public static CharGrouping Semicolon()
        {
            return CharGrouping.Create(AsciiChar.Semicolon);
        }

        public static CharGrouping LessThan()
        {
            return CharGrouping.Create(AsciiChar.LessThan);
        }

        public static CharGrouping EqualsSign()
        {
            return CharGrouping.Create(AsciiChar.EqualsSign);
        }

        public static CharGrouping GreaterThan()
        {
            return CharGrouping.Create(AsciiChar.GreaterThan);
        }

        public static CharGrouping QuestionMark()
        {
            return CharGrouping.Create(AsciiChar.QuestionMark);
        }

        public static CharGrouping AtSign()
        {
            return CharGrouping.Create(AsciiChar.AtSign);
        }

        public static CharGrouping LeftSquareBracket()
        {
            return CharGrouping.Create(AsciiChar.LeftSquareBracket);
        }

        public static CharGrouping Backslash()
        {
            return CharGrouping.Create(AsciiChar.Backslash);
        }

        public static CharGrouping RightSquareBracket()
        {
            return CharGrouping.Create(AsciiChar.RightSquareBracket);
        }

        public static CharGrouping CircumflexAccent()
        {
            return CharGrouping.Create(AsciiChar.CircumflexAccent);
        }

        public static CharGrouping Underscore()
        {
            return CharGrouping.Create(AsciiChar.Underscore);
        }

        public static CharGrouping GraveAccent()
        {
            return CharGrouping.Create(AsciiChar.GraveAccent);
        }

        public static CharGrouping LeftCurlyBracket()
        {
            return CharGrouping.Create(AsciiChar.LeftCurlyBracket);
        }

        public static CharGrouping VerticalLine()
        {
            return CharGrouping.Create(AsciiChar.VerticalLine);
        }

        public static CharGrouping RightCurlyBracket()
        {
            return CharGrouping.Create(AsciiChar.RightCurlyBracket);
        }

        public static CharGrouping Tilde()
        {
            return CharGrouping.Create(AsciiChar.Tilde);
        }

        public static CharGrouping Parenthesis()
        {
            return LeftParenthesis().RightParenthesis();
        }

        public static CharGrouping SquareBracket()
        {
            return LeftSquareBracket().RightSquareBracket();
        }

        public static CharGrouping CurlyBracket()
        {
            return LeftCurlyBracket().RightCurlyBracket();
        }
    }
}
