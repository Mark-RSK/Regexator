// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Linq
{
    internal class NamedBlockGroup
        : CharGroupExpression
    {
        private readonly IEnumerable<NamedBlock> _values;
        private readonly NamedBlock _value;

        public NamedBlockGroup(NamedBlock value)
        {
            _value = value;
        }

        public NamedBlockGroup(IEnumerable<NamedBlock> values)
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
                    return Syntax.NamedBlocks(_values);
                }
                else
                {
                    return Syntax.NamedBlock(_value);
                }
            }
        }
    }
}
