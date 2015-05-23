// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class TextExpression
        : Expression
    {
        private readonly string _text;
        private readonly bool _escape;

        internal TextExpression()
            : this(null)
        {
        }

        internal TextExpression(string text)
            : this(text, true)
        {
        }

        internal TextExpression(string text, bool escape)
        {
            _text = text;
            _escape = escape;
        }

        internal override string Value(BuildContext context)
        {
            return (_escape && _text != null) ? RegexUtilities.Escape(_text) : _text;
        }
    }
}
