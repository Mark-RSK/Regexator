﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NotGeneralCategoryCharItem
        : GeneralCategoryCharItem
    {
        public NotGeneralCategoryCharItem(GeneralCategory category)
            : base(category)
        {
        }

        public override bool Negative
        {
            get { return true; }
        }
    }
}