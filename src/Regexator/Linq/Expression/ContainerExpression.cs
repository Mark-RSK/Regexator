// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Linq
{
    internal sealed class ContainerExpression
        : Expression
    {
        private readonly Expression _expression;

        public ContainerExpression(Expression expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }
            _expression = expression;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            foreach (var value in _expression.EnumerateValues(context))
            {
                yield return value;
            }
        }
    }
}
