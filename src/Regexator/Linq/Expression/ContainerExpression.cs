// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class ContainerExpression
        : Expression
    {
        private readonly object _value;

        public ContainerExpression(object value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            _value = value;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            return Expression.EnumerateValues(_value, context);
        }
    }
}
