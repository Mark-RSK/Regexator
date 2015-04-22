// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal abstract class GroupingConstruct
        : QuantifiableExpression
    {
        private readonly Expression _childExpression;

        internal GroupingConstruct(string value)
            : base(value, true)
        {
        }

        internal GroupingConstruct(Expression childExpression)
            : base()
        {
            _childExpression = childExpression;
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
            else if (Value != null)
            {
                yield return Value;
            }
        }

        internal Expression ChildExpression
        {
            get { return _childExpression; }
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
