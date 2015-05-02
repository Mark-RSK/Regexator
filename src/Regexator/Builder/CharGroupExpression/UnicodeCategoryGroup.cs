// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal class UnicodeCategoryGroup
        : CharGroupExpression
    {
        private readonly IEnumerable<UnicodeCategory> _values;

        public UnicodeCategoryGroup(IEnumerable<UnicodeCategory> values)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            _values = values;
        }

        public override string Content
        {
            get { return Syntax.UnicodeCategories(_values); }
        }
    }
}
