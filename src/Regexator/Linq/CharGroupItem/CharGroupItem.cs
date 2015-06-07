// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class CharGroupItem
        : IBaseGroup, IExcludedGroup
    {

        protected CharGroupItem()
        {
        }

        private CharGroupItem Concat(CharGroupItem item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            CharGroupItem first = item;
            while (first.Previous != null)
            {
                first = first.Previous;
            }

            first.Previous = this;
            return item;
        }

        internal IEnumerable<string> GetValues()
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
            return Value;
        }

        public CharGroupItem Char(char value)
        {
            return Concat(CharGroupItems.Char(value));
        }

        public CharGroupItem Char(int value)
        {
            return Concat(CharGroupItems.Char(value));
        }

        public CharGroupItem Char(AsciiChar value)
        {
            return Concat(CharGroupItems.Char(value));
        }

        public CharGroupItem Char(string chars)
        {
            return Concat(CharGroupItems.Char(chars));
        }

        public CharGroupItem Range(char first, char last)
        {
            return Concat(CharGroupItems.Range(first, last));
        }

        public CharGroupItem Range(int firstCharCode, int lastCharCode)
        {
            return Concat(CharGroupItems.Range(firstCharCode, lastCharCode));
        }

        public CharGroupItem NamedBlock(NamedBlock block)
        {
            return Concat(CharGroupItems.NamedBlock(block));
        }

        public CharGroupItem NotNamedBlock(NamedBlock block)
        {
            return Concat(CharGroupItems.NotNamedBlock(block));
        }

        public CharGroupItem GeneralCategory(GeneralCategory category)
        {
            return Concat(CharGroupItems.GeneralCategory(category));
        }

        public CharGroupItem NotGeneralCategory(GeneralCategory category)
        {
            return Concat(CharGroupItems.NotGeneralCategory(category));
        }

        public CharGroupItem Digit()
        {
            return Concat(CharGroupItems.Digit());
        }

        public CharGroupItem NotDigit()
        {
            return Concat(CharGroupItems.NotDigit());
        }

        public CharGroupItem WhiteSpace()
        {
            return Concat(CharGroupItems.WhiteSpace());
        }

        public CharGroupItem NotWhiteSpace()
        {
            return Concat(CharGroupItems.NotWhiteSpace());
        }

        public CharGroupItem WordChar()
        {
            return Concat(CharGroupItems.WordChar());
        }

        public CharGroupItem NotWordChar()
        {
            return Concat(CharGroupItems.NotWordChar());
        }

        public CharGroupItem Alphanumeric()
        {
            return Concat(CharGroupItems.Alphanumeric());
        }

        public CharGroupItem AlphanumericLower()
        {
            return Concat(CharGroupItems.AlphanumericLower());
        }

        public CharGroupItem AlphanumericUpper()
        {
            return Concat(CharGroupItems.AlphanumericUpper());
        }

        public CharGroupItem LatinLetter()
        {
            return Concat(CharGroupItems.LatinLetter());
        }

        public CharGroupItem LatinLetterLower()
        {
            return Concat(CharGroupItems.LatinLetterLower());
        }

        public CharGroupItem LatinLetterUpper()
        {
            return Concat(CharGroupItems.LatinLetterUpper());
        }

        public CharGroupItem ArabicDigit()
        {
            return Concat(CharGroupItems.ArabicDigit());
        }

        public CharGroupItem NewLineChar()
        {
            return Concat(CharGroupItems.NewLineChar());
        }

        public CharGroupExpression ToGroup()
        {
            return new CharItemGroup(this);
        }

        public CharGroupExpression ToNegativeGroup()
        {
            return new CharItemGroup(this, true);
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
            get { return string.Concat(GetValues()); }
        }

        internal CharGroupItem Previous { get; set; }
    }
}
