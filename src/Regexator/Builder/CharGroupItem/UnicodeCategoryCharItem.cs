﻿// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal class UnicodeCategoryCharItem
        : CharGroupItem
    {
        private readonly UnicodeCategory _category;

        public UnicodeCategoryCharItem(UnicodeCategory category)
        {
            _category = category;
        }

        public virtual bool Negative
        {
            get { return false; }
        }

        internal override string Content
        {
            get { return Syntax.UnicodeCategory(_category, Negative); }
        }
    }
}
