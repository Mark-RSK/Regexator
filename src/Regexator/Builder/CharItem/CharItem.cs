// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.ObjectModel;

namespace Pihrtsoft.Regexator.Builder
{
    public abstract partial class CharItem
        : IBaseGroup, IExcludedGroup
    {
        private Collection<CharItem> _items;

        protected CharItem()
        {
        }

        private CharItem Append(CharItem item)
        {
            if (_items == null)
            {
                _items = new Collection<CharItem>();
            }
            _items.Add(item);
            return this;
        }

        public override string ToString()
        {
            return Content;
        }

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

        public CharItem Digit()
        {
            return Append(CharItems.Digit());
        }

        public CharItem NotDigit()
        {
            return Append(CharItems.NotDigit());
        }

        public CharItem WhiteSpace()
        {
            return Append(CharItems.WhiteSpace());
        }

        public CharItem NotWhiteSpace()
        {
            return Append(CharItems.NotWhiteSpace());
        }

        public CharItem Word()
        {
            return Append(CharItems.Word());
        }

        public CharItem NotWord()
        {
            return Append(CharItems.NotWord());
        }

        public CharItem Alphanumeric()
        {
            return Append(CharItems.Alphanumeric());
        }

        public CharItem LatinAlphabet()
        {
            return Append(CharItems.LatinAlphabet());
        }

        public CharItem DigitAsRange()
        {
            return Append(CharItems.DigitAsRange());
        }

        internal abstract string Content { get; }

        public string BaseGroupValue
        {
            get { return Value; }
        }

        public string ExcludedGroupValue
        {
            get { return Syntax.CharGroup(Value); }
        }

        internal string Value
        {
            get
            {
                if (_items != null)
                {
                    return Content + string.Concat(_items);
                }
                return Content;
            }
        }
    }
}
