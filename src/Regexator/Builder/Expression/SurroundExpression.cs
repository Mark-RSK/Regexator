// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class SurroundExpression
        : Expression
    {
        private readonly Expression _expression;
        private readonly Expression _before;
        private readonly Expression _after;

        public SurroundExpression(string value, Expression beforeExpression, Expression afterExpression)
            : this(new TextExpression(value), beforeExpression, afterExpression)
        {
        }

        public SurroundExpression(Expression expression, Expression beforeExpression, Expression afterExpression)
        {
            if (expression == null) { throw new ArgumentNullException("expression"); }
            if (beforeExpression == null) { throw new ArgumentNullException("beforeExpression"); }
            if (afterExpression == null) { throw new ArgumentNullException("afterExpression"); }
            _expression = expression;
            _before = beforeExpression;
            _after = afterExpression;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            foreach (var value in _before.EnumerateValues(context))
            {
                yield return value;
            }
            foreach (var value in _expression.EnumerateValues(context))
            {
                yield return value;
            }
            foreach (var value in _after.EnumerateValues(context))
            {
                yield return value;
            }
        }
    }
}
