// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal abstract class GroupExpression
        : QuantifiableExpression
    {
        private readonly Expression _expression;
        private readonly string _text;

        internal GroupExpression()
            : base()
        {
        }

        internal GroupExpression(string text)
            : base()
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            _text = text;
        }

        internal GroupExpression(Expression expression)
            : base()
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            _expression = expression;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            if (ChildExpression != null)
            {
                foreach (var value in ChildExpression.EnumerateValues(context))
                {
                    yield return value;
                }
            }
            string s = Value(context);
            if (s != null)
            {
                yield return s;
            }
        }

        internal override string Value(BuildContext context)
        {
            return (_text != null) ? RegexUtilities.Escape(_text) : null;
        }

        internal virtual Expression ChildExpression
        {
            get { return _expression; }
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
