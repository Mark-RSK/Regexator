// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class GroupingExpression
        : QuantifiableExpression
    {
        private readonly object _content;

        protected GroupingExpression()
            : base()
        {
        }

        protected GroupingExpression(object content)
            : base()
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content;
        }

        internal object Content
        {
            get { return _content; }
        }
    }
}
