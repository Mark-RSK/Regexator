// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class TextExpression
        : Expression
    {
        private readonly string _text;
        private readonly bool _ignoreCase;

        internal TextExpression()
            : this(null)
        {
        }

        internal TextExpression(string text)
            : this(text, false)
        {
        }

        internal TextExpression(string text, bool ignoreCase)
        {
            _text = text;
            _ignoreCase = ignoreCase;
        }

        internal override void BuildContent(PatternWriter writer)
        {
            if (!string.IsNullOrEmpty(_text))
            {
                if (_ignoreCase)
                {
                    writer.WriteGroupOptions(InlineOptions.IgnoreCase, _text);
                }
                else
                {
                    writer.WriteEscaped(_text);
                }
            }
        }
    }
}
