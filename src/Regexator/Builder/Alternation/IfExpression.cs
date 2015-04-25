// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class IfExpression
        : AlternationConstruct
    {
        private readonly Expression _condition;

        internal IfExpression(Expression condition, string yes)
            : this(condition, yes, null)
        {
        }

        internal IfExpression(Expression condition, string yes, string no)
            : base(yes, no)
        {
            _condition = condition;
        }

        internal IfExpression(Expression condition, Expression yes)
            : this(condition, yes, null)
        {
        }

        internal IfExpression(Expression condition, Expression yes, Expression no)
            : base(yes, no)
        {
            _condition = condition;
        }

        protected override IEnumerable<string> EnumerateCondition(BuildContext context)
        {
            if (_condition != null)
            {
                yield return context.Settings.ConditionWithAssertion ? Syntax.LookaheadStart : Syntax.SubexpressionStart;
                foreach (var value in _condition.EnumerateValues(context))
                {
                    yield return value;
                }
                yield return Syntax.GroupEnd;
            }
        }
    }
}