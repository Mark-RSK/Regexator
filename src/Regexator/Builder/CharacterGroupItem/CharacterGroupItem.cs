// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Pihrtsoft.Regexator.Builder
{
    public abstract partial class CharacterGroupItem
        : IBaseGroup, IExcludedGroup
    {
        private CharacterGroupItem _previous;

        protected CharacterGroupItem()
        {
        }

        private CharacterGroupItem Append(CharacterGroupItem item)
        {
            if (item == null) { throw new ArgumentNullException("item"); }
            CharacterGroupItem first = item;
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
                var items = new Stack<CharacterGroupItem>(this.EnumerateExpressions());
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

        private IEnumerable<CharacterGroupItem> EnumerateExpressions()
        {
            CharacterGroupItem item = this;
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

        public CharacterGroupItem Chars(params char[] values)
        {
            return Append(CharacterItem.Chars(values));
        }

        public CharacterGroupItem Chars(params int[] values)
        {
            return Append(CharacterItem.Chars(values));
        }

        public CharacterGroupItem Chars(params AsciiChar[] values)
        {
            return Append(CharacterItem.Chars(values));
        }

        public CharacterGroupItem Chars(params CharClass[] values)
        {
            return Append(CharacterItem.Chars(values));
        }

        public CharacterGroupItem Chars(string value)
        {
            return Append(CharacterItem.Chars(value));
        }

        public CharacterGroupItem Range(char first, char last)
        {
            return Append(CharacterItem.Range(first, last));
        }

        public CharacterGroupItem Range(int first, int last)
        {
            return Append(CharacterItem.Range(first, last));
        }

        public CharacterGroupItem UnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return Append(CharacterItem.UnicodeBlocks(blocks));
        }

        public CharacterGroupItem NotUnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return Append(CharacterItem.NotUnicodeBlocks(blocks));
        }

        public CharacterGroupItem UnicodeCategories(params UnicodeCategory[] categories)
        {
            return Append(CharacterItem.UnicodeCategories(categories));
        }

        public CharacterGroupItem NotUnicodeCategories(params UnicodeCategory[] categories)
        {
            return Append(CharacterItem.NotUnicodeCategories(categories));
        }

        public CharacterGroupItem Digit()
        {
            return Append(CharacterItem.Digit());
        }

        public CharacterGroupItem NotDigit()
        {
            return Append(CharacterItem.NotDigit());
        }

        public CharacterGroupItem WhiteSpace()
        {
            return Append(CharacterItem.WhiteSpace());
        }

        public CharacterGroupItem NotWhiteSpace()
        {
            return Append(CharacterItem.NotWhiteSpace());
        }

        public CharacterGroupItem Word()
        {
            return Append(CharacterItem.Word());
        }

        public CharacterGroupItem NotWord()
        {
            return Append(CharacterItem.NotWord());
        }

        public CharacterGroupItem Alphanumeric()
        {
            return Append(CharacterItem.Alphanumeric());
        }

        public CharacterGroupItem LatinAlphabet()
        {
            return Append(CharacterItem.LatinAlphabet());
        }

        public CharacterGroupItem DigitAsRange()
        {
            return Append(CharacterItem.DigitAsRange());
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

        internal CharacterGroupItem Previous
        {
            get { return _previous; }
            set { _previous = value; }
        }
    }
}
