// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NamedBlockCharGroup
        : CharacterGroup
    {
        private readonly NamedBlock _block;
        private readonly bool _negative;

        public NamedBlockCharGroup(NamedBlock block, bool negative)
        {
            _block = block;
            _negative = negative;
        }

        internal override void WriteContentTo(PatternWriter writer)
        {
            writer.WriteNamedBlock(_block, Negative);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteCharGroup(_block, Negative);
        }

        public override bool Negative
        {
            get { return _negative;}
        }
    }
}
