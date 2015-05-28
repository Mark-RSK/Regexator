// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class SurroundExpression
        : Expression
    {
        private readonly object _value;
        private readonly object _before;
        private readonly object _after;

        public SurroundExpression(object value, object valueBefore, object valueAfter)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (valueBefore == null)
            {
                throw new ArgumentNullException("valueBefore");
            }

            if (valueAfter == null)
            {
                throw new ArgumentNullException("valueAfter");
            }

            _value = value;
            _before = valueBefore;
            _after = valueAfter;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            foreach (var value in Expression.EnumerateValues(_before, context))
            {
                yield return value;
            }

            foreach (var value in Expression.EnumerateValues(_value, context))
            {
                yield return value;
            }

            foreach (var value in Expression.EnumerateValues(_after, context))
            {
                yield return value;
            }
        }
    }
}
