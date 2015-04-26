// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal abstract class EnclosingExpression
        : QuantifiableExpression
    {
        private readonly Expression _expression;

        protected EnclosingExpression(Expression expression)
        {
            if (expression == null) { throw new ArgumentNullException("expression"); }
            _expression = expression;
        }

        protected abstract IEnumerable<string> EnumerateStart(BuildContext context);

        protected abstract IEnumerable<string> EnumerateEnd(BuildContext context);

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            foreach (var value in EnumerateStart(context))
            {
                yield return value;
            }
            foreach (var value in _expression.EnumerateValues(context))
            {
                yield return value;
            }
            foreach (var value in EnumerateEnd(context))
            {
                yield return value;
            }
        }
    }
}
