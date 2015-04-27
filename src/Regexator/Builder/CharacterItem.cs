// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static class CharacterItem
    {
        public static CharacterGroupItem Chars(params char[] values)
        {
            return new CharsCharItem(values);
        }

        public static CharacterGroupItem Chars(params int[] values)
        {
            return new CharCodeCharItem(values);
        }

        public static CharacterGroupItem Chars(params AsciiChar[] values)
        {
            return new AsciiCharItem(values);
        }

        public static CharacterGroupItem Chars(params CharClass[] values)
        {
            return new CharClassCharItem(values);
        }

        public static CharacterGroupItem Chars(string value)
        {
            return new TextCharItem(value);
        }

        public static CharacterGroupItem Range(char first, char last)
        {
            return new RangeCharItem(first, last);
        }

        public static CharacterGroupItem Range(int first, int last)
        {
            return new CodeRangeCharItem(first, last);
        }

        public static CharacterGroupItem UnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return new UnicodeBlockCharItem(blocks);
        }

        public static CharacterGroupItem NotUnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return new NotUnicodeBlockCharItem(blocks);
        }

        public static CharacterGroupItem UnicodeCategories(params UnicodeCategory[] categories)
        {
            return new UnicodeCategoryCharItem(categories);
        }

        public static CharacterGroupItem NotUnicodeCategories(params UnicodeCategory[] categories)
        {
            return new NotUnicodeCategoryCharItem(categories);
        }

        public static CharacterGroupItem Digit()
        {
            return new CharClassCharItem(CharClass.Digit);
        }

        public static CharacterGroupItem NotDigit()
        {
            return new CharClassCharItem(CharClass.NotDigit);
        }

        public static CharacterGroupItem WhiteSpace()
        {
            return new CharClassCharItem(CharClass.WhiteSpace);
        }

        public static CharacterGroupItem NotWhiteSpace()
        {
            return new CharClassCharItem(CharClass.NotWhiteSpace);
        }

        public static CharacterGroupItem Word()
        {
            return new CharClassCharItem(CharClass.Word);
        }

        public static CharacterGroupItem NotWord()
        {
            return new CharClassCharItem(CharClass.NotWord);
        }

        public static CharacterGroupItem Alphanumeric()
        {
            return LatinAlphabet().DigitAsRange();
        }

        public static CharacterGroupItem LatinAlphabet()
        {
            return Range('a', 'z').Range('A', 'Z');
        }

        public static CharacterGroupItem DigitAsRange()
        {
            return Range('0', '9');
        }

        public static CharacterGroupItem Tab()
        {
            return new AsciiCharItem(AsciiChar.Tab);
        }

        public static CharacterGroupItem Linefeed()
        {
            return new AsciiCharItem(AsciiChar.Linefeed);
        }

        public static CharacterGroupItem CarriageReturn()
        {
            return new AsciiCharItem(AsciiChar.CarriageReturn);
        }

        public static CharacterGroupItem Space()
        {
            return new AsciiCharItem(AsciiChar.Space);
        }

        public static CharacterGroupItem ExclamationMark()
        {
            return new AsciiCharItem(AsciiChar.ExclamationMark);
        }

        public static CharacterGroupItem QuotationMark()
        {
            return new AsciiCharItem(AsciiChar.QuotationMark);
        }

        public static CharacterGroupItem NumberSign()
        {
            return new AsciiCharItem(AsciiChar.NumberSign);
        }

        public static CharacterGroupItem Dollar()
        {
            return new AsciiCharItem(AsciiChar.Dollar);
        }

        public static CharacterGroupItem Percent()
        {
            return new AsciiCharItem(AsciiChar.Percent);
        }

        public static CharacterGroupItem Ampersand()
        {
            return new AsciiCharItem(AsciiChar.Ampersand);
        }

        public static CharacterGroupItem Apostrophe()
        {
            return new AsciiCharItem(AsciiChar.Apostrophe);
        }

        public static CharacterGroupItem LeftParenthesis()
        {
            return new AsciiCharItem(AsciiChar.LeftParenthesis);
        }

        public static CharacterGroupItem RightParenthesis()
        {
            return new AsciiCharItem(AsciiChar.RightParenthesis);
        }

        public static CharacterGroupItem Asterisk()
        {
            return new AsciiCharItem(AsciiChar.Asterisk);
        }

        public static CharacterGroupItem Plus()
        {
            return new AsciiCharItem(AsciiChar.Plus);
        }

        public static CharacterGroupItem Comma()
        {
            return new AsciiCharItem(AsciiChar.Comma);
        }

        public static CharacterGroupItem Hyphen()
        {
            return new AsciiCharItem(AsciiChar.Hyphen);
        }

        public static CharacterGroupItem Period()
        {
            return new AsciiCharItem(AsciiChar.Period);
        }

        public static CharacterGroupItem Slash()
        {
            return new AsciiCharItem(AsciiChar.Slash);
        }

        public static CharacterGroupItem Colon()
        {
            return new AsciiCharItem(AsciiChar.Colon);
        }

        public static CharacterGroupItem Semicolon()
        {
            return new AsciiCharItem(AsciiChar.Semicolon);
        }

        public static CharacterGroupItem LessThan()
        {
            return new AsciiCharItem(AsciiChar.LessThan);
        }

        public static CharacterGroupItem EqualsSign()
        {
            return new AsciiCharItem(AsciiChar.EqualsSign);
        }

        public static CharacterGroupItem GreaterThan()
        {
            return new AsciiCharItem(AsciiChar.GreaterThan);
        }

        public static CharacterGroupItem QuestionMark()
        {
            return new AsciiCharItem(AsciiChar.QuestionMark);
        }

        public static CharacterGroupItem At()
        {
            return new AsciiCharItem(AsciiChar.At);
        }

        public static CharacterGroupItem LeftSquareBracket()
        {
            return new AsciiCharItem(AsciiChar.LeftSquareBracket);
        }

        public static CharacterGroupItem Backslash()
        {
            return new AsciiCharItem(AsciiChar.Backslash);
        }

        public static CharacterGroupItem RightSquareBracket()
        {
            return new AsciiCharItem(AsciiChar.RightSquareBracket);
        }

        public static CharacterGroupItem CircumflexAccent()
        {
            return new AsciiCharItem(AsciiChar.CircumflexAccent);
        }

        public static CharacterGroupItem Underscore()
        {
            return new AsciiCharItem(AsciiChar.Underscore);
        }

        public static CharacterGroupItem GraveAccent()
        {
            return new AsciiCharItem(AsciiChar.GraveAccent);
        }

        public static CharacterGroupItem LeftCurlyBracket()
        {
            return new AsciiCharItem(AsciiChar.LeftCurlyBracket);
        }

        public static CharacterGroupItem VerticalLine()
        {
            return new AsciiCharItem(AsciiChar.VerticalLine);
        }

        public static CharacterGroupItem RightCurlyBracket()
        {
            return new AsciiCharItem(AsciiChar.RightCurlyBracket);
        }

        public static CharacterGroupItem Tilde()
        {
            return new AsciiCharItem(AsciiChar.Tilde);
        }
    }
}
