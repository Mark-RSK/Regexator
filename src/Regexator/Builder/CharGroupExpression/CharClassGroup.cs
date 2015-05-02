// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal class CharClassGroup
        : CharGroupExpression
    {
        private readonly IEnumerable<CharClass> _values;

        public CharClassGroup(IEnumerable<CharClass> values)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            _values = values;
        }

        public override string Content
        {
            get { return Syntax.CharClasses(_values); }
        }
    }
}
