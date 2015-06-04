// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal abstract class GroupExpression
        : QuantifiableExpression
    {
        private readonly object _content;

        public GroupExpression()
            : base()
        {
        }

        public GroupExpression(object content)
            : base()
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            return Expression.EnumerateValues(_content, context);
        }

        internal object Content
        {
            get { return _content; }
        }

        internal override string Closing(BuildContext context)
        {
            return Syntax.GroupEnd;
        }
    }
}
