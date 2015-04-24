// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public class NotCharCodeGroup
        : CharCodeGroup
    {
        public NotCharCodeGroup(params int[] values)
            : base(values)
        {
        }

        public override bool Negative
        {
            get { return true; }
        }
    }
}
