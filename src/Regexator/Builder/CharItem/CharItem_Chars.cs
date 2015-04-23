// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public sealed partial class CharItem
    {
        public CharItem Chars(params char[] values)
        {
            return Append(CharItems.Chars(values));
        }

        public CharItem Chars(params int[] values)
        {
            return Append(CharItems.Chars(values));
        }

        public CharItem Chars(params AsciiChar[] values)
        {
            return Append(CharItems.Chars(values));
        }

        public CharItem Chars(params CharClass[] values)
        {
            return Append(CharItems.Chars(values));
        }

        public CharItem Chars(string value)
        {
            return Append(CharItems.Chars(value));
        }

        public CharItem Range(char first, char last)
        {
            return Append(CharItems.Range(first, last));
        }

        public CharItem Range(int first, int last)
        {
            return Append(CharItems.Range(first, last));
        }

        public CharItem UnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return Append(CharItems.UnicodeBlocks(blocks));
        }

        public CharItem NotUnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return Append(CharItems.NotUnicodeBlocks(blocks));
        }

        public CharItem UnicodeCategories(params UnicodeCategory[] categories)
        {
            return Append(CharItems.UnicodeCategories(categories));
        }

        public CharItem NotUnicodeCategories(params UnicodeCategory[] categories)
        {
            return Append(CharItems.NotUnicodeCategories(categories));
        }

        public CharItem Alphanumeric()
        {
            return Append(CharItems.Alphanumeric());
        }
    }
}
