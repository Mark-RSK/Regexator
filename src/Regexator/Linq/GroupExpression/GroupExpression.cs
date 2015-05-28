// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal abstract class GroupExpression
        : QuantifiableExpression
    {
        private readonly object _value;
        //private readonly Expression _expression;
        //private readonly string _text;

        internal GroupExpression()
            : base()
        {
        }

        internal GroupExpression(object value)
            : base()
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            _value = value;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            Expression child = ChildExpression;
            if (child != null)
            {
                foreach (var value in child.EnumerateValues(context))
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
            string text = _value as string;
            return (text != null) ? RegexUtilities.Escape(text) : null;
        }

        internal virtual Expression ChildExpression
        {
            get { return _value as Expression; }
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
