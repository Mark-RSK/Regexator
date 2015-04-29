// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    public abstract partial class CharGroupItem
        : IBaseGroup, IExcludedGroup
    {
        private CharGroupItem _previous;

        protected CharGroupItem()
        {
        }

        private CharGroupItem Append(CharGroupItem item)
        {
            if (item == null) { throw new ArgumentNullException("item"); }
            CharGroupItem first = item;
            while (first.Previous != null)
            {
                first = first.Previous;
            }
            first.Previous = this;
            return item;
        }

        internal IEnumerable<string> EnumerateValues()
        {
            if (Previous != null)
            {
                var items = new Stack<CharGroupItem>(this.EnumerateExpressions());
                while (items.Count > 0)
                {
                    yield return items.Pop().Content;
                }
            }
            else
            {
                yield return Content;
            }
        }

        private IEnumerable<CharGroupItem> EnumerateExpressions()
        {
            CharGroupItem item = this;
            do
            {
                yield return item;
                item = item.Previous;
            } while (item != null);
        }

        public override string ToString()
        {
            return Content;
        }

        public CharGroupItem Chars(params char[] values)
        {
            return Append(CharGroupItems.Chars(values));
        }

        public CharGroupItem Chars(params int[] values)
        {
            return Append(CharGroupItems.Chars(values));
        }

        public CharGroupItem Chars(params AsciiChar[] values)
        {
            return Append(CharGroupItems.Chars(values));
        }

        public CharGroupItem Chars(params CharClass[] values)
        {
            return Append(CharGroupItems.Chars(values));
        }

        public CharGroupItem Chars(string value)
        {
            return Append(CharGroupItems.Chars(value));
        }

        public CharGroupItem Range(char first, char last)
        {
            return Append(CharGroupItems.Range(first, last));
        }

        public CharGroupItem Range(int first, int last)
        {
            return Append(CharGroupItems.Range(first, last));
        }

        public CharGroupItem UnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return Append(CharGroupItems.UnicodeBlocks(blocks));
        }

        public CharGroupItem NotUnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return Append(CharGroupItems.NotUnicodeBlocks(blocks));
        }

        public CharGroupItem UnicodeCategories(params UnicodeCategory[] categories)
        {
            return Append(CharGroupItems.UnicodeCategories(categories));
        }

        public CharGroupItem NotUnicodeCategories(params UnicodeCategory[] categories)
        {
            return Append(CharGroupItems.NotUnicodeCategories(categories));
        }

        public CharGroupItem Digit()
        {
            return Append(CharGroupItems.Digit());
        }

        public CharGroupItem NotDigit()
        {
            return Append(CharGroupItems.NotDigit());
        }

        public CharGroupItem WhiteSpace()
        {
            return Append(CharGroupItems.WhiteSpace());
        }

        public CharGroupItem NotWhiteSpace()
        {
            return Append(CharGroupItems.NotWhiteSpace());
        }

        public CharGroupItem Word()
        {
            return Append(CharGroupItems.Word());
        }

        public CharGroupItem NotWord()
        {
            return Append(CharGroupItems.NotWord());
        }

        public CharGroupItem Alphanumeric()
        {
            return Append(CharGroupItems.Alphanumeric());
        }

        public CharGroupItem LatinAlphabet()
        {
            return Append(CharGroupItems.LatinAlphabet());
        }

        public CharGroupItem DigitAsRange()
        {
            return Append(CharGroupItems.DigitAsRange());
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
            get { return string.Concat(EnumerateValues()); }
        }

        internal CharGroupItem Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }
    }
}
