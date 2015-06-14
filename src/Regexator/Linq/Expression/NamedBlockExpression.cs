﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class NamedBlockExpression
        : CharacterExpression
    {
        private readonly NamedBlock _block;

        internal NamedBlockExpression(NamedBlock block)
        {
            _block = block;
        }

        public override CharGroupExpression ToGroup()
        {
            return new NamedBlockGroup(_block);
        }

        internal override void BuildContent(PatternWriter writer)
        {
            writer.WriteNamedBlock(_block);
        }

        public NamedBlock Block
        {
            get { return _block; }
        }
    }
}
