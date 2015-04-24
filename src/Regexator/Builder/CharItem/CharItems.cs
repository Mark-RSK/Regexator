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
            return Range('a', 'z').Range('A', 'Z').Range('0', '9');
        }
    }
}
