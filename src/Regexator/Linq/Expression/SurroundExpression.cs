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

        public SurroundExpression(object contentBefore, object content, object contentAfter)
        {
            if (contentBefore == null)
            {
                throw new ArgumentNullException("contentBefore");
            }

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (contentAfter == null)
            {
                throw new ArgumentNullException("contentAfter");
            }

            _contentBefore = contentBefore;
            _content = content;
            _contentAfter = contentAfter;
        }

        internal override void WriteContentTo(PatternWriter writer)
        {
            writer.Write(_contentBefore);

            writer.Write(_content);

            writer.Write(_contentAfter);
        }
    }
}
