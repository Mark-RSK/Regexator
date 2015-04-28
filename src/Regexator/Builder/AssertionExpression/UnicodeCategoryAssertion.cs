// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class UnicodeCategoryAssertion
        : AssertionExpression
    {
        private readonly UnicodeCategory[] _categories;

        internal UnicodeCategoryAssertion(AssertionKind kind, params UnicodeCategory[] categories)
            : base(kind)
        {
            if (categories == null) { throw new ArgumentNullException("categories"); }
            _categories = categories;
        }

        internal override Expression ChildExpression
        {
            get { return ((_categories.Length > 0) ? Character.Group(_categories) : Expressions.Empty()); }
        }
    }
}