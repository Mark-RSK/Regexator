// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class SurroundExpression
        : Expression
    {
        private readonly object _content;
        private readonly object _contentBefore;
        private readonly object _contentAfter;

        public SurroundExpression(object content, object contentBefore, object contentAfter)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (contentBefore == null)
            {
                throw new ArgumentNullException("contentBefore");
            }

            if (contentAfter == null)
            {
                throw new ArgumentNullException("contentAfter");
            }

            _content = content;
            _contentBefore = contentBefore;
            _contentAfter = contentAfter;
        }

        internal override void BuildContent(PatternContext context)
        {
            Expression.Build(_contentBefore, context);

            Expression.Build(_content, context);

            Expression.Build(_contentAfter, context);
        }
    }
}
