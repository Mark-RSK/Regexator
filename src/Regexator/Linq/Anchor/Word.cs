// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class Word
        : QuantifiablePattern
    {
        private readonly object _content;

        public Word()
            : this(Patterns.WordChars())
        {
        }

        public Word(string value)
            : this((object)value)
        {
        }

        public Word(params string[] values)
            : this((object)values)
        {
        }

        private Word(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteNoncapturingGroupStart();
            writer.WriteWordBoundary();
            writer.Write(_content);
            writer.WriteWordBoundary();
            writer.WriteGroupEnd();
        }
    }
}
