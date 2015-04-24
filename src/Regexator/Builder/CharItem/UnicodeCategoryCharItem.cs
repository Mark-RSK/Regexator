// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal class UnicodeCategoryCharItem
        : CharItem
    {
        private readonly UnicodeCategory[] _categories;

        public UnicodeCategoryCharItem(params UnicodeCategory[] categories)
        {
            if (categories == null) { throw new ArgumentNullException("categories"); }
            _categories = categories;
        }

        public virtual bool Negative
        {
            get { return false; }
        }

        internal override string Content
        {
            get { return Syntax.UnicodeCategories(Negative, _categories); }
        }
    }
}
