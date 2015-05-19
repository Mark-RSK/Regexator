// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Linq
{
    internal sealed class NotCharGroup
        : CharGroup
    {
        public NotCharGroup(char value)
            : base(value)
        {
        }

        public NotCharGroup(IEnumerable<char> values)
            : base(values)
        {
        }

        public override bool Negative
        {
            get { return true; }
        }
    }
}
