// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class InlineCommentExpression
        : Expression
    {
        private readonly string _comment;

        internal InlineCommentExpression(string comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }

            _comment = comment;
        }

        internal override string Value(PatternContext context)
        {
            return Syntax.InlineComment(_comment);
        }
    }
}
