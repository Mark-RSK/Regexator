// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class CharGroup
        : QuantifiableExpression, IBaseGroup, IExcludedGroup
    {
        private readonly string _value;
        private readonly CharItem _item;

        internal CharGroup(string value)
        {
            _value = value;
        }

        internal CharGroup(CharItem item)
        {
            _item = item;
        }

        internal CharGroup(params char[] values)
        {
            _value = Syntax.Chars(values, true);
        }

        internal CharGroup(params int[] charCodes)
        {
            _value = Syntax.Chars(charCodes, true);
        }

        internal CharGroup(params AsciiChar[] values)
        {
            _value = Syntax.Chars(values, true);
        }

        internal CharGroup(params CharClass[] values)
        {
            _value = Syntax.CharClasses(values);
        }

        internal CharGroup(params UnicodeBlock[] blocks)
        {
            _value = Syntax.UnicodeBlocks(blocks);
        }

        internal CharGroup(params UnicodeCategory[] categories)
        {
            _value = Syntax.UnicodeCategories(categories);
        }

        public string BaseGroupValue
        {
            get { return (_item != null) ? _item.Value : _value; }
        }

        public string ExcludedGroupValue
        {
            get { return Value; }
        }

        internal override string Value
        {
            get { return Syntax.CharGroup((_item != null) ? _item.Value : _value, Negative); }
        }

        public virtual bool Negative
        {
            get { return false; }
        }

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.CharGroup; }
        }
    }
}
