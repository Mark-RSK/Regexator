// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class TextExpression
        : Expression
    {
        private readonly string _value;
        private readonly bool _escape;

        internal TextExpression()
            : this(null)
        {
        }

        internal TextExpression(string value)
            : this(value, true)
        {
        }

        internal TextExpression(string value, bool escape)
        {
            _value = value;
            _escape = escape;
        }

        public bool Escape
        {
            get { return _escape; }
        }

        internal override string Value
        {
            get { return (_escape && _value != null) ? Utilities.Escape(_value) : _value; }
        }
    }
}
