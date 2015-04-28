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
            return Append(CharItems.Chars(values));
        }

        public CharGroupItem Chars(params int[] values)
        {
            return Append(CharItems.Chars(values));
        }

        public CharGroupItem Chars(params AsciiChar[] values)
        {
            return Append(CharItems.Chars(values));
        }

        public CharGroupItem Chars(params CharClass[] values)
        {
            return Append(CharItems.Chars(values));
        }

        public CharGroupItem Chars(string value)
        {
            return Append(CharItems.Chars(value));
        }

        public CharGroupItem Range(char first, char last)
        {
            return Append(CharItems.Range(first, last));
        }

        public CharGroupItem Range(int first, int last)
        {
            return Append(CharItems.Range(first, last));
        }

        public CharGroupItem UnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return Append(CharItems.UnicodeBlocks(blocks));
        }

        public CharGroupItem NotUnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return Append(CharItems.NotUnicodeBlocks(blocks));
        }

        public CharGroupItem UnicodeCategories(params UnicodeCategory[] categories)
        {
            return Append(CharItems.UnicodeCategories(categories));
        }

        public CharGroupItem NotUnicodeCategories(params UnicodeCategory[] categories)
        {
            return Append(CharItems.NotUnicodeCategories(categories));
        }

        public CharGroupItem Digit()
        {
            return Append(CharItems.Digit());
        }

        public CharGroupItem NotDigit()
        {
            return Append(CharItems.NotDigit());
        }

        public CharGroupItem WhiteSpace()
        {
            return Append(CharItems.WhiteSpace());
        }

        public CharGroupItem NotWhiteSpace()
        {
            return Append(CharItems.NotWhiteSpace());
        }

        public CharGroupItem Word()
        {
            return Append(CharItems.Word());
        }

        public CharGroupItem NotWord()
        {
            return Append(CharItems.NotWord());
        }

        public CharGroupItem Alphanumeric()
        {
            return Append(CharItems.Alphanumeric());
        }

        public CharGroupItem LatinAlphabet()
        {
            return Append(CharItems.LatinAlphabet());
        }

        public CharGroupItem DigitAsRange()
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
            get { return string.Concat(EnumerateValues()); }
        }

        internal CharGroupItem Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }
    }
}
