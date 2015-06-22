// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class LiteralPattern
        : Pattern
    {
        private readonly string _text;
        private readonly bool _ignoreCase;

        internal LiteralPattern()
            : this(null)
        {
        }

        internal LiteralPattern(string text)
            : this(text, false)
        {
        }

        internal LiteralPattern(string text, bool ignoreCase)
        {
            _text = text;
            _ignoreCase = ignoreCase;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            if (!string.IsNullOrEmpty(_text))
            {
                if (_ignoreCase)
                {
                    writer.WriteOptions(InlineOptions.IgnoreCase, _text);
                }
                else
                {
                    writer.Write(_text);
                }
            }
        }
    }
}