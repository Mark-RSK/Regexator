// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal abstract class GroupExpression
        : QuantifiableExpression
    {
        private readonly object _content;

        internal GroupExpression()
            : base()
        {
        }

        internal GroupExpression(object content)
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
            Expression expression = _content as Expression;
            if (expression != null)
            {
                foreach (var value in expression.EnumerateValues(context))
                {
                    yield return value;
                }
            }
            else
            {
                string s = Value(context);
                if (s != null)
                {
                    yield return s;
                }
            }
            
        }

        internal override string Value(BuildContext context)
        {
            string text = _content as string;

            return (text != null) 
                ? RegexUtilities.Escape(text) 
                : null;
        }

        internal object Content
        {
            get { return _content; }
        }

        internal override string Closing(BuildContext context)
        {
            return Syntax.GroupEnd;
        }

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.Group; }
        }
    }
}
