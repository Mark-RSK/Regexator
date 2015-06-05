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

        internal override string Value(BuildContext context)
        {
            if (!string.IsNullOrEmpty(_text))
            {
                string text = RegexUtilities.Escape(_text);

                return _ignoreCase
                    ? Syntax.GroupOptions(InlineOptions.IgnoreCase, text)
                    : text;
            }

            return string.Empty;
        }
    }
}
