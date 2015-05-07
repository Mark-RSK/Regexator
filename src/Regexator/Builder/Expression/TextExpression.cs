// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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

        internal override string Value(BuildContext context)
        {
            return (_escape && _value != null) ? RegexUtilities.Escape(_value) : _value;
        }
    }
}
