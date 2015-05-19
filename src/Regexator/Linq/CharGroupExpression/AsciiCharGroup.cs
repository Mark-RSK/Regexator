// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Linq
{
    internal class AsciiCharGroup
        : CharGroupExpression
    {
        private readonly IEnumerable<AsciiChar> _values;
        private readonly AsciiChar _value;

        public AsciiCharGroup(AsciiChar value)
        {
            _value = value;
        }

        public AsciiCharGroup(IEnumerable<AsciiChar> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            _values = values;
        }

        public override string Content
        {
            get
            {
                if (_values != null)
                {
                    return Syntax.Char(_values, true);
                }
                else
                {
                    return Syntax.Char(_value, true);
                }
            }
        }
    }
}
