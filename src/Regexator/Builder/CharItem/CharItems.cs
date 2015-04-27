// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class CharItems
    {
        public static CharItem Chars(params char[] values)
        {
            return new CharsCharItem(values);
        }

        public static CharItem Chars(params int[] values)
        {
            return new CharCodeCharItem(values);
        }

        public static CharItem Chars(params AsciiChar[] values)
        {
            return new AsciiCharItem(values);
        }

        public static CharItem Chars(params CharClass[] values)
        {
            return new CharClassCharItem(values);
        }

        public static CharItem Chars(string value)
        {
            return new TextCharItem(value);
        }

        public static CharItem Range(char first, char last)
        {
            return new RangeCharItem(first, last);
        }

        public static CharItem Range(int first, int last)
        {
            return new CodeRangeCharItem(first, last);
        }

        public static CharItem UnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return new UnicodeBlockCharItem(blocks);
        }

        public static CharItem NotUnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return new NotUnicodeBlockCharItem(blocks);
        }

        public static CharItem UnicodeCategories(params UnicodeCategory[] categories)
        {
            return new UnicodeCategoryCharItem(categories);
        }

        public static CharItem NotUnicodeCategories(params UnicodeCategory[] categories)
        {
            return new NotUnicodeCategoryCharItem(categories);
        }

        public static CharItem Digit()
        {
            return new CharClassCharItem(CharClass.Digit);
        }

        public static CharItem NotDigit()
        {
            return new CharClassCharItem(CharClass.NotDigit);
        }

        public static CharItem WhiteSpace()
        {
            return new CharClassCharItem(CharClass.WhiteSpace);
        }

        public static CharItem NotWhiteSpace()
        {
            return new CharClassCharItem(CharClass.NotWhiteSpace);
        }

        public static CharItem Word()
        {
            return new CharClassCharItem(CharClass.Word);
        }

        public static CharItem NotWord()
        {
            return new CharClassCharItem(CharClass.NotWord);
        }

        public static CharItem Alphanumeric()
        {
            return LatinAlphabet().DigitAsRange();
        }

        public static CharItem LatinAlphabet()
        {
            return Range('a', 'z').Range('A', 'Z');
        }

        public static CharItem DigitAsRange()
        {
            return Range('0', '9');
        }

        public static CharItem Tab()
        {
            return new AsciiCharItem(AsciiChar.Tab);
        }

        public static CharItem Linefeed()
        {
            return new AsciiCharItem(AsciiChar.Linefeed);
        }

        public static CharItem CarriageReturn()
        {
            return new AsciiCharItem(AsciiChar.CarriageReturn);
        }

        public static CharItem Space()
        {
            return new AsciiCharItem(AsciiChar.Space);
        }

        public static CharItem ExclamationMark()
        {
            return new AsciiCharItem(AsciiChar.ExclamationMark);
        }

        public static CharItem QuotationMark()
        {
            return new AsciiCharItem(AsciiChar.QuotationMark);
        }

        public static CharItem NumberSign()
        {
            return new AsciiCharItem(AsciiChar.NumberSign);
        }

        public static CharItem Dollar()
        {
            return new AsciiCharItem(AsciiChar.Dollar);
        }

        public static CharItem Percent()
        {
            return new AsciiCharItem(AsciiChar.Percent);
        }

        public static CharItem Ampersand()
        {
            return new AsciiCharItem(AsciiChar.Ampersand);
        }

        public static CharItem Apostrophe()
        {
            return new AsciiCharItem(AsciiChar.Apostrophe);
        }

        public static CharItem LeftParenthesis()
        {
            return new AsciiCharItem(AsciiChar.LeftParenthesis);
        }

        public static CharItem RightParenthesis()
        {
            return new AsciiCharItem(AsciiChar.RightParenthesis);
        }

        public static CharItem Asterisk()
        {
            return new AsciiCharItem(AsciiChar.Asterisk);
        }

        public static CharItem Plus()
        {
            return new AsciiCharItem(AsciiChar.Plus);
        }

        public static CharItem Comma()
        {
            return new AsciiCharItem(AsciiChar.Comma);
        }

        public static CharItem Hyphen()
        {
            return new AsciiCharItem(AsciiChar.Hyphen);
        }

        public static CharItem Period()
        {
            return new AsciiCharItem(AsciiChar.Period);
        }

        public static CharItem Slash()
        {
            return new AsciiCharItem(AsciiChar.Slash);
        }

        public static CharItem Colon()
        {
            return new AsciiCharItem(AsciiChar.Colon);
        }

        public static CharItem Semicolon()
        {
            return new AsciiCharItem(AsciiChar.Semicolon);
        }

        public static CharItem LessThan()
        {
            return new AsciiCharItem(AsciiChar.LessThan);
        }

        public static CharItem EqualsSign()
        {
            return new AsciiCharItem(AsciiChar.EqualsSign);
        }

        public static CharItem GreaterThan()
        {
            return new AsciiCharItem(AsciiChar.GreaterThan);
        }

        public static CharItem QuestionMark()
        {
            return new AsciiCharItem(AsciiChar.QuestionMark);
        }

        public static CharItem At()
        {
            return new AsciiCharItem(AsciiChar.At);
        }

        public static CharItem LeftSquareBracket()
        {
            return new AsciiCharItem(AsciiChar.LeftSquareBracket);
        }

        public static CharItem Backslash()
        {
            return new AsciiCharItem(AsciiChar.Backslash);
        }

        public static CharItem RightSquareBracket()
        {
            return new AsciiCharItem(AsciiChar.RightSquareBracket);
        }

        public static CharItem CircumflexAccent()
        {
            return new AsciiCharItem(AsciiChar.CircumflexAccent);
        }

        public static CharItem Underscore()
        {
            return new AsciiCharItem(AsciiChar.Underscore);
        }

        public static CharItem GraveAccent()
        {
            return new AsciiCharItem(AsciiChar.GraveAccent);
        }

        public static CharItem LeftCurlyBracket()
        {
            return new AsciiCharItem(AsciiChar.LeftCurlyBracket);
        }

        public static CharItem VerticalLine()
        {
            return new AsciiCharItem(AsciiChar.VerticalLine);
        }

        public static CharItem RightCurlyBracket()
        {
            return new AsciiCharItem(AsciiChar.RightCurlyBracket);
        }

        public static CharItem Tilde()
        {
            return new AsciiCharItem(AsciiChar.Tilde);
        }
    }
}
