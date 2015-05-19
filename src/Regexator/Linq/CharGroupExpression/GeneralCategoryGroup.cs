// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Linq
{
    internal class GeneralCategoryGroup
        : CharGroupExpression
    {
        private readonly IEnumerable<GeneralCategory> _values;
        private readonly GeneralCategory _value;

        public GeneralCategoryGroup(GeneralCategory value)
        {
            _value = value;
        }

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
            get
            {
                if (_values != null)
                {
                    return Syntax.GeneralCategories(_values);
                }
                else
                {
                    return Syntax.GeneralCategory(_value);
                }
            }
        }
    }
}
