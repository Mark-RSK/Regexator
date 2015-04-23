// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using System.Diagnostics;

namespace Pihrtsoft.Regexator.Builder
{
    public sealed partial class CharItem
        : IBaseGroup, IExcludedGroup
    {
        private Collection<CharItem> _items;
        private readonly string _value;

        private CharItem(string value)
        {
            Debug.Assert(value != null);
            _value = value;
        }

        internal static CharItem Create(params char[] values)
        {
            return new CharItem(Syntax.Chars(values, true));
        }

        internal static CharItem Create(params int[] values)
        {
            return new CharItem(Syntax.Chars(values, true));
        }

        internal static CharItem Create(params AsciiChar[] values)
        {
            return new CharItem(Syntax.Chars(values, true));
        }

        internal static CharItem Create(params CharClass[] values)
        {
            return new CharItem(Syntax.CharClasses(values));
        }

        internal static CharItem Create(string value)
        {
            return new CharItem(Utilities.Escape(value, true));
        }

        internal static CharItem Create(char first, char last)
        {
            return new CharItem(Syntax.Range(first, last));
        }

        internal static CharItem Create(int first, int last)
        {
            return new CharItem(Syntax.Range(first, last));
        }

        internal static CharItem Create(params UnicodeBlock[] blocks)
        {
            return Create(false, blocks);
        }

        internal static CharItem Create(bool negative, params UnicodeBlock[] blocks)
        {
            return new CharItem(Syntax.UnicodeBlocks(negative, blocks));
        }

        internal static CharItem Create(params UnicodeCategory[] categories)
        {
            return Create(false, categories);
        }

        internal static CharItem Create(bool negative, params UnicodeCategory[] categories)
        {
            return new CharItem(Syntax.UnicodeCategories(negative, categories));
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
            return _value;
        }

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
                    return _value + string.Concat(_items);
                }
                return _value;
            }
        }
    }
}
