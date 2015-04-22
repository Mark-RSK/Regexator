// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NotCharGroup
        : CharGroup
    {
        internal NotCharGroup(string value)
            : base(value)
        {
        }

        internal NotCharGroup(CharItem item)
            : base(item)
        {
        }

        internal NotCharGroup(params char[] values)
            : base(values)
        {
        }

        internal NotCharGroup(params int[] charCodes)
            : base(charCodes)
        {
        }

        internal NotCharGroup(params AsciiChar[] values)
            : base(values)
        {
        }

        internal NotCharGroup(params UnicodeBlock[] blocks)
            : base(blocks)
        {
        }

        internal NotCharGroup(params UnicodeCategory[] categories)
            : base(categories)
        {
        }

        public override bool Negative
        {
            get { return true; }
        }
    }
}
