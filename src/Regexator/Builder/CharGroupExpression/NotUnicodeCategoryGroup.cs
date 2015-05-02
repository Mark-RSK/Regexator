// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NotUnicodeCategoryGroup
        : UnicodeCategoryGroup
    {
        public NotUnicodeCategoryGroup(IEnumerable<UnicodeCategory> values)
            : base(values)
        {
        }

        public override bool Negative
        {
            get { return true; }
        }
    }
}
