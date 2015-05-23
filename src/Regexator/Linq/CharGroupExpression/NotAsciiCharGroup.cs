// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NotAsciiCharGroup
        : AsciiCharGroup
    {
        public NotAsciiCharGroup(AsciiChar value)
            : base(value)
        {
        }

        public NotAsciiCharGroup(IEnumerable<AsciiChar> values)
            : base(values)
        {
        }

        public override bool Negative
        {
            get { return true; }
        }
    }
}
