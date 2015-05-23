// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NotCharCodeGroup
        : CharCodeGroup
    {
        public NotCharCodeGroup(int charCode)
            : base(charCode)
        {
        }

        public NotCharCodeGroup(IEnumerable<int> charCodes)
            : base(charCodes)
        {
        }

        public override bool Negative
        {
            get { return true; }
        }
    }
}
