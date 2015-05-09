// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal class GeneralCategoryGroup
        : CharGroupExpression
    {
        private readonly IEnumerable<GeneralCategory> _values;

        public GeneralCategoryGroup(IEnumerable<GeneralCategory> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            _values = values;
        }

        public override string Content
        {
            get { return Syntax.GeneralCategories(_values); }
        }
    }
}
