// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class UnicodeCategoryAssertion
        : AssertionExpression
    {
        private readonly UnicodeCategory _category;

        internal UnicodeCategoryAssertion(AssertionKind kind, UnicodeCategory category)
            : base(kind)
        {
            _category = category;
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.UnicodeCategory(_category);
        }
    }
}