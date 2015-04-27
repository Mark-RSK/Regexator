// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal class UnicodeCategoryGroup
        : CharacterGroupExpression
    {
        private readonly UnicodeCategory[] _values;

        public UnicodeCategoryGroup(params UnicodeCategory[] values)
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
