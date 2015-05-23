// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Linq
{
    public static class CharGroupItems
    {
        public static CharGroupItem Char(char value)
        {
            return new CharCharItem(value);
        }

        public static CharGroupItem Char(int value)
        {
            return new CharCodeCharItem(value);
        }

        public static CharGroupItem Char(AsciiChar value)
        {
            return new AsciiCharItem(value);
        }

        public static CharGroupItem Char(string chars)
        {
            return new CharsCharItem(chars);
        }

        public static CharGroupItem Range(char first, char last)
        {
            return new RangeCharItem(first, last);
        }

        public static CharGroupItem Range(int firstCharCode, int lastCharCode)
        {
            return new CodeRangeCharItem(firstCharCode, lastCharCode);
        }

        public static CharGroupItem NamedBlock(NamedBlock block)
        {
            return new NamedBlockCharItem(block);
        }

        public static CharGroupItem NotNamedBlock(NamedBlock block)
        {
            return new NotNamedBlockCharItem(block);
        }

        public static CharGroupItem GeneralCategory(GeneralCategory category)
        {
            return new GeneralCategoryCharItem(category);
        }

        public static CharGroupItem NotGeneralCategory(GeneralCategory category)
        {
            return new NotGeneralCategoryCharItem(category);
        }

        public static CharGroupItem Digit()
        {
            return new CharClassCharItem(CharClass.Digit);
        }

        public static CharGroupItem NotDigit()
        {
            return new CharClassCharItem(CharClass.NotDigit);
        }

        public static CharGroupItem WhiteSpace()
        {
            return new CharClassCharItem(CharClass.WhiteSpace);
        }

        public static CharGroupItem NotWhiteSpace()
        {
            return new CharClassCharItem(CharClass.NotWhiteSpace);
        }

        public static CharGroupItem WordChar()
        {
            return new CharClassCharItem(CharClass.WordChar);
        }

        public static CharGroupItem NotWordChar()
        {
            return new CharClassCharItem(CharClass.NotWordChar);
        }

        public static CharGroupItem Alphanumeric()
        {
            return LatinLetter().ArabicDigit();
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
            return Range('a', 'z');
        }

        public static CharGroupItem LatinLetterUpper()
        {
            return Range('A', 'Z');
        }

        public static CharGroupItem ArabicDigit()
        {
            return Range('0', '9');
        }

        public static CharGroupItem HexadecimalDigit()
        {
            return ArabicDigit().Range('a', 'f').Range('A', 'F');
        }

        public static CharGroupItem NewLineChar()
        {
            return CarriageReturn().Linefeed();
        }

        public static CharGroupItem Tab()
        {
            return new AsciiCharItem(AsciiChar.Tab);
        }

        public static CharGroupItem Linefeed()
        {
            return new AsciiCharItem(AsciiChar.Linefeed);
        }

        public static CharGroupItem CarriageReturn()
        {
            return new AsciiCharItem(AsciiChar.CarriageReturn);
        }

        public static CharGroupItem Space()
        {
            return new AsciiCharItem(AsciiChar.Space);
        }

        public static CharGroupItem ExclamationMark()
        {
            return new AsciiCharItem(AsciiChar.ExclamationMark);
        }

        public static CharGroupItem QuoteMark()
        {
            return new AsciiCharItem(AsciiChar.QuoteMark);
        }

        public static CharGroupItem NumberSign()
        {
            return new AsciiCharItem(AsciiChar.NumberSign);
        }

        public static CharGroupItem Dollar()
        {
            return new AsciiCharItem(AsciiChar.Dollar);
        }

        public static CharGroupItem Percent()
        {
            return new AsciiCharItem(AsciiChar.Percent);
        }

        public static CharGroupItem Ampersand()
        {
            return new AsciiCharItem(AsciiChar.Ampersand);
        }

        public static CharGroupItem Apostrophe()
        {
            return new AsciiCharItem(AsciiChar.Apostrophe);
        }

        public static CharGroupItem LeftParenthesis()
        {
            return new AsciiCharItem(AsciiChar.LeftParenthesis);
        }

        public static CharGroupItem RightParenthesis()
        {
            return new AsciiCharItem(AsciiChar.RightParenthesis);
        }

        public static CharGroupItem Asterisk()
        {
            return new AsciiCharItem(AsciiChar.Asterisk);
        }

        public static CharGroupItem Plus()
        {
            return new AsciiCharItem(AsciiChar.Plus);
        }

        public static CharGroupItem Comma()
        {
            return new AsciiCharItem(AsciiChar.Comma);
        }

        public static CharGroupItem Hyphen()
        {
            return new AsciiCharItem(AsciiChar.Hyphen);
        }

        public static CharGroupItem Period()
        {
            return new AsciiCharItem(AsciiChar.Period);
        }

        public static CharGroupItem Slash()
        {
            return new AsciiCharItem(AsciiChar.Slash);
        }

        public static CharGroupItem Colon()
        {
            return new AsciiCharItem(AsciiChar.Colon);
        }

        public static CharGroupItem Semicolon()
        {
            return new AsciiCharItem(AsciiChar.Semicolon);
        }

        public static CharGroupItem LessThan()
        {
            return new AsciiCharItem(AsciiChar.LessThan);
        }

        public static CharGroupItem EqualsSign()
        {
            return new AsciiCharItem(AsciiChar.EqualsSign);
        }

        public static CharGroupItem GreaterThan()
        {
            return new AsciiCharItem(AsciiChar.GreaterThan);
        }

        public static CharGroupItem QuestionMark()
        {
            return new AsciiCharItem(AsciiChar.QuestionMark);
        }

        public static CharGroupItem At()
        {
            return new AsciiCharItem(AsciiChar.At);
        }

        public static CharGroupItem LeftSquareBracket()
        {
            return new AsciiCharItem(AsciiChar.LeftSquareBracket);
        }

        public static CharGroupItem Backslash()
        {
            return new AsciiCharItem(AsciiChar.Backslash);
        }

        public static CharGroupItem RightSquareBracket()
        {
            return new AsciiCharItem(AsciiChar.RightSquareBracket);
        }

        public static CharGroupItem CircumflexAccent()
        {
            return new AsciiCharItem(AsciiChar.CircumflexAccent);
        }

        public static CharGroupItem Underscore()
        {
            return new AsciiCharItem(AsciiChar.Underscore);
        }

        public static CharGroupItem GraveAccent()
        {
            return new AsciiCharItem(AsciiChar.GraveAccent);
        }

        public static CharGroupItem LeftCurlyBracket()
        {
            return new AsciiCharItem(AsciiChar.LeftCurlyBracket);
        }

        public static CharGroupItem VerticalLine()
        {
            return new AsciiCharItem(AsciiChar.VerticalLine);
        }

        public static CharGroupItem RightCurlyBracket()
        {
            return new AsciiCharItem(AsciiChar.RightCurlyBracket);
        }

        public static CharGroupItem Tilde()
        {
            return new AsciiCharItem(AsciiChar.Tilde);
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
