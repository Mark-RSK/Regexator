﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class NamedBlockPattern
        : CharacterPattern
    {
        private readonly NamedBlock _block;

        internal NamedBlockPattern(NamedBlock block)
        {
            _block = block;
        }

        public override CharacterGroup Invert()
        {
            return new NamedBlockCharGroup(_block, true);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteNamedBlock(_block);
        }

        public NamedBlock Block
        {
            get { return _block; }
        }
    }
}
