// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Linq
{
    internal sealed class NotNamedBlockGroup
        : NamedBlockGroup
    {
        public NotNamedBlockGroup(IEnumerable<NamedBlock> values)
            : base(values)
        {
        }

        public override bool Negative
        {
            get { return true; }
        }
    }
}
