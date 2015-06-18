// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class AssertSurroundExpression
        : Expression
    {
        private readonly object _content;
        private readonly object _contentBefore;
        private readonly object _contentAfter;
        private readonly bool _negative;

        public AssertSurroundExpression(object contentBefore, object content, object contentAfter)
            : this(contentBefore, content, contentAfter, false)
        { 
        }

        public AssertSurroundExpression(object contentBefore, object content, object contentAfter, bool negative)
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
            _negative = negative;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            if (_negative)
            {
                writer.WriteNotAssertBack(_contentBefore);
            }
            else
            {
                writer.WriteAssertBack(_contentBefore);
            }

            writer.Write(_content);

            if (_negative)
            {
                writer.WriteNotAssert(_contentAfter);
            }
            else
            {
                writer.WriteAssert(_contentAfter);
            }
        }
    }
}
