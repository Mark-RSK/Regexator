// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class CharGroupItems
    {
        public static CharGroupItem NamedBlock(NamedBlock block)
        {
            return CharGroupItem.Create(block);
        }

        public static CharGroupItem NotNamedBlock(NamedBlock block)
        {
            return CharGroupItem.Create(block, true);
        }

        public static CharGroupItem GeneralCategory(GeneralCategory category)
        {
            return CharGroupItem.Create(category);
        }

        public static CharGroupItem NotGeneralCategory(GeneralCategory category)
        {
            return CharGroupItem.Create(category, true);
        }

        public static CharGroupItem Digit()
        {
            return CharGroupItem.Create(CharClass.Digit);
        }

        public static CharGroupItem NotDigit()
        {
            return CharGroupItem.Create(CharClass.NotDigit);
        }

        public static CharGroupItem WhiteSpace()
        {
            return CharGroupItem.Create(CharClass.WhiteSpace);
        }

        public static CharGroupItem NotWhiteSpace()
        {
            return CharGroupItem.Create(CharClass.NotWhiteSpace);
        }

        public static CharGroupItem WordChar()
        {
            return CharGroupItem.Create(CharClass.WordChar);
        }

        public static CharGroupItem NotWordChar()
        {
            return CharGroupItem.Create(CharClass.NotWordChar);
        }

        public static CharGroupItem Alphanumeric()
        {
            return LatinLetter().ArabicDigit();
        }

        public static CharGroupItem AlphanumericLower()
        {
            return LatinLetterLower().ArabicDigit();
        }

        public static CharGroupItem AlphanumericUpper()
        {
            return LatinLetterUpper().ArabicDigit();
        }

        public static CharGroupItem AlphanumericUnderscore()
        {
            return Alphanumeric().Underscore();
        }

        public static CharGroupItem LatinLetter()
        {
            return LatinLetterLower().LatinLetterUpper();
        }

        public static CharGroupItem LatinLetterLower()
        {
            return CharGroupItem.Create('a', 'z');
        }

        public static CharGroupItem LatinLetterUpper()
        {
            return CharGroupItem.Create('A', 'Z');
        }

        public static CharGroupItem ArabicDigit()
        {
            return CharGroupItem.Create('0', '9');
        }

        public static CharGroupItem HexadecimalDigit()
        {
            return ArabicDigit().Concat('a', 'f').Concat('A', 'F');
        }

        public static CharGroupItem NewLineChar()
        {
            return CarriageReturn().Linefeed();
        }

        public static CharGroupItem Tab()
        {
            return CharGroupItem.Create(AsciiChar.Tab);
        }

        public static CharGroupItem Linefeed()
        {
            return CharGroupItem.Create(AsciiChar.Linefeed);
        }

        public static CharGroupItem CarriageReturn()
        {
            return CharGroupItem.Create(AsciiChar.CarriageReturn);
        }

        public static CharGroupItem Space()
        {
            return CharGroupItem.Create(AsciiChar.Space);
        }

        public static CharGroupItem ExclamationMark()
        {
            return CharGroupItem.Create(AsciiChar.ExclamationMark);
        }

        public static CharGroupItem QuoteMark()
        {
            return CharGroupItem.Create(AsciiChar.QuoteMark);
        }

        public static CharGroupItem NumberSign()
        {
            return CharGroupItem.Create(AsciiChar.NumberSign);
        }

        public static CharGroupItem Dollar()
        {
            return CharGroupItem.Create(AsciiChar.Dollar);
        }

        public static CharGroupItem Percent()
        {
            return CharGroupItem.Create(AsciiChar.Percent);
        }

        public static CharGroupItem Ampersand()
        {
            return CharGroupItem.Create(AsciiChar.Ampersand);
        }

        public static CharGroupItem Apostrophe()
        {
            return CharGroupItem.Create(AsciiChar.Apostrophe);
        }

        public static CharGroupItem LeftParenthesis()
        {
            return CharGroupItem.Create(AsciiChar.LeftParenthesis);
        }

        public static CharGroupItem RightParenthesis()
        {
            return CharGroupItem.Create(AsciiChar.RightParenthesis);
        }

        public static CharGroupItem Asterisk()
        {
            return CharGroupItem.Create(AsciiChar.Asterisk);
        }

        public static CharGroupItem Plus()
        {
            return CharGroupItem.Create(AsciiChar.Plus);
        }

        public static CharGroupItem Comma()
        {
            return CharGroupItem.Create(AsciiChar.Comma);
        }

        public static CharGroupItem Hyphen()
        {
            return CharGroupItem.Create(AsciiChar.Hyphen);
        }

        public static CharGroupItem Period()
        {
            return CharGroupItem.Create(AsciiChar.Period);
        }

        public static CharGroupItem Slash()
        {
            return CharGroupItem.Create(AsciiChar.Slash);
        }

        public static CharGroupItem Colon()
        {
            return CharGroupItem.Create(AsciiChar.Colon);
        }

        public static CharGroupItem Semicolon()
        {
            return CharGroupItem.Create(AsciiChar.Semicolon);
        }

        public static CharGroupItem LessThan()
        {
            return CharGroupItem.Create(AsciiChar.LessThan);
        }

        public static CharGroupItem EqualsSign()
        {
            return CharGroupItem.Create(AsciiChar.EqualsSign);
        }

        public static CharGroupItem GreaterThan()
        {
            return CharGroupItem.Create(AsciiChar.GreaterThan);
        }

        public static CharGroupItem QuestionMark()
        {
            return CharGroupItem.Create(AsciiChar.QuestionMark);
        }

        public static CharGroupItem AtSign()
        {
            return CharGroupItem.Create(AsciiChar.AtSign);
        }

        public static CharGroupItem LeftSquareBracket()
        {
            return CharGroupItem.Create(AsciiChar.LeftSquareBracket);
        }

        public static CharGroupItem Backslash()
        {
            return CharGroupItem.Create(AsciiChar.Backslash);
        }

        public static CharGroupItem RightSquareBracket()
        {
            return CharGroupItem.Create(AsciiChar.RightSquareBracket);
        }

        public static CharGroupItem CircumflexAccent()
        {
            return CharGroupItem.Create(AsciiChar.CircumflexAccent);
        }

        public static CharGroupItem Underscore()
        {
            return CharGroupItem.Create(AsciiChar.Underscore);
        }

        public static CharGroupItem GraveAccent()
        {
            return CharGroupItem.Create(AsciiChar.GraveAccent);
        }

        public static CharGroupItem LeftCurlyBracket()
        {
            return CharGroupItem.Create(AsciiChar.LeftCurlyBracket);
        }

        public static CharGroupItem VerticalLine()
        {
            return CharGroupItem.Create(AsciiChar.VerticalLine);
        }

        public static CharGroupItem RightCurlyBracket()
        {
            return CharGroupItem.Create(AsciiChar.RightCurlyBracket);
        }

        public static CharGroupItem Tilde()
        {
            return CharGroupItem.Create(AsciiChar.Tilde);
        }

        public static CharGroupItem Parenthesis()
        {
            return LeftParenthesis().RightParenthesis();
        }

        public static CharGroupItem SquareBracket()
        {
            return LeftSquareBracket().RightSquareBracket();
        }

        public static CharGroupItem CurlyBracket()
        {
            return LeftCurlyBracket().RightCurlyBracket();
        }
    }
}
