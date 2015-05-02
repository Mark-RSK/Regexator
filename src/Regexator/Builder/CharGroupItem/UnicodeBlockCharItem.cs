// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal class UnicodeBlockCharItem
        : CharGroupItem
    {
        private readonly UnicodeBlock _block;

        public UnicodeBlockCharItem(UnicodeBlock block)
        {
            _block = block;
        }

        public virtual bool Negative
        {
            get { return false; }
        }

        internal override string Content
        {
            get { return Syntax.UnicodeBlock(_block, Negative); }
        }
    }
}
