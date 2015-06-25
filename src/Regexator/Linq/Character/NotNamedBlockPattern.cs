// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NotNamedBlockPattern
        : NamedBlockPattern
    {
        internal NotNamedBlockPattern(NamedBlock block)
            : base(block)
        {
        }

        public override CharGroup Invert()
        {
            return new NamedBlockCharGroup(Block, false);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteNotNamedBlock(Block);
        }
    }
}
