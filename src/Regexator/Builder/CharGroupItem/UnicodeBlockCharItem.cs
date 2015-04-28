// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal class UnicodeBlockCharItem
        : CharGroupItem
    {
        private readonly UnicodeBlock[] _blocks;

        public UnicodeBlockCharItem(params UnicodeBlock[] blocks)
        {
            if (blocks == null) { throw new ArgumentNullException("blocks"); }
            _blocks = blocks;
        }

        public virtual bool Negative
        {
            get { return false; }
        }

        internal override string Content
        {
            get { return Syntax.UnicodeBlocks(Negative, _blocks); }
        }
    }
}
