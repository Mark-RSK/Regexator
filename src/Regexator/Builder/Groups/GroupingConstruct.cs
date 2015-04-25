// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal abstract class GroupingConstruct
        : QuantifiableExpression
    {
        private readonly Expression _expression;
        private readonly string _value;

        internal GroupingConstruct(string value)
            : base()
        {
            _value = value;
        }

        internal GroupingConstruct(Expression expression)
            : base()
        {
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
            else if (_value != null)
            {
                yield return Value;
            }
        }

        internal sealed override string Value
        {
            get { return (_value != null) ? Utilities.Escape(_value) : null; }
        }

        internal Expression ChildExpression
        {
            get { return _expression; }
        }

        internal override string Closing
        {
            get { return Syntax.GroupEnd; }
        }

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.Group; }
        }
    }
}
