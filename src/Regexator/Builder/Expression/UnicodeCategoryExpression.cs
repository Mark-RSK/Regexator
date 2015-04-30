// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal class UnicodeCategoryExpression
        : QuantifiableExpression
    {
        private readonly UnicodeCategory _category;

        internal UnicodeCategoryExpression(UnicodeCategory category)
        {
            _category = category;
        }

        public UnicodeCategory Category
        {
            get { return _category; }
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.UnicodeCategory(_category);
        }
    }
}
