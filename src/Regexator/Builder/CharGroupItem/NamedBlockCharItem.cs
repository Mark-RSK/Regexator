// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal class NamedBlockCharItem
        : CharGroupItem
    {
        private readonly NamedBlock _block;

        public NamedBlockCharItem(NamedBlock block)
        {
            _block = block;
        }

        public virtual bool Negative
        {
            get { return false; }
        }

        internal override string Content
        {
            get { return Syntax.NamedBlock(_block, Negative); }
        }
    }
}
