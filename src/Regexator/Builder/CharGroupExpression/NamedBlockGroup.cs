// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal class NamedBlockGroup
        : CharGroupExpression
    {
        private readonly IEnumerable<NamedBlock> _values;

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
            get { return Syntax.NamedBlocks(_values); }
        }
    }
}
