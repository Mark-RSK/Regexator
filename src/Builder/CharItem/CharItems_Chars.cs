// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class CharItems
    {
        public static CharItem Chars(params char[] values)
        {
            return CharItem.Create(values);
        }

        public static CharItem Chars(params int[] values)
        {
            return CharItem.Create(values);
        }

        public static CharItem Chars(params AsciiChar[] values)
        {
            return CharItem.Create(values);
        }

        public static CharItem Chars(params CharClass[] values)
        {
            return CharItem.Create(values);
        }

        public static CharItem Chars(string value)
        {
            return CharItem.Create(value);
        }

        public static CharItem Range(char first, char last)
        {
            return CharItem.Create(first, last);
        }

        public static CharItem Range(int first, int last)
        {
            return CharItem.Create(first, last);
        }

        public static CharItem UnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return CharItem.Create(blocks);
        }

        public static CharItem NotUnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return CharItem.Create(true, blocks);
        }

        public static CharItem UnicodeCategories(params UnicodeCategory[] categories)
        {
            return CharItem.Create(categories);
        }

        public static CharItem NotUnicodeCategories(params UnicodeCategory[] categories)
        {
            return CharItem.Create(true, categories);
        }

        public static CharItem Alphanumeric()
        {
            return Range('a', 'z').Range('A', 'Z').Range('0', '9');
        }
    }
}
