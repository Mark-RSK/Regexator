// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class IfExpression
        : AlternationExpression
    {
        private readonly object _condition;

        internal IfExpression(object condition, object trueContent)
            : this(condition, trueContent, null)
        {
        }

        internal IfExpression(object condition, object trueContent, object falseContent)
            : base(trueContent, falseContent)
        {
            if (condition == null)
            {
                throw new ArgumentNullException("condition");
            }

            _condition = condition;
        }

        protected override IEnumerable<string> EnumerateCondition(BuildContext context)
        {
            if (_condition != null)
            {
                yield return context.Settings.ConditionWithAssertion ? Syntax.AssertStart : Syntax.CapturingGroupStart;

                foreach (var value in Expression.EnumerateValues(_condition, context))
                {
                    yield return value;
                }

                yield return Syntax.GroupEnd;
            }
        }
    }
}
