// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal class CharGroup
        : CharGroupExpression
    {
        private readonly IEnumerable<char> _values;
        private readonly char _value;

        public CharGroup(char value)
        {
            _value = value;
        }

        public CharGroup(IEnumerable<char> values)
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
                    return Syntax.Chars(_values, true);
                }
                else
                {
                    return Syntax.Char(_value, true);
                }
            }
        }
    }
}
