// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NotCharCodeRangeGroup
        : CharCodeRangeGroup
    {
        public NotCharCodeRangeGroup(int firstCharCode, int lastCharCode)
            : base(firstCharCode, lastCharCode)
        {
        }

        public override bool Negative
        {
            get { return true; }
        }
    }
}
