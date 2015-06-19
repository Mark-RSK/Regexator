// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class InlineComment
        : Pattern
    {
        private readonly string _comment;

        public InlineComment(string comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }

            _comment = comment;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteInlineComment(_comment);
        }
    }
}
