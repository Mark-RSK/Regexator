// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class NamedBlockCharItem
        : CharGroupItem
    {
        private readonly NamedBlock _block;
        private readonly bool _negative;

        public NamedBlockCharItem(NamedBlock block)
            : this(block, false)
        {
        }

        public NamedBlockCharItem(NamedBlock block, bool negative)
        {
            _block = block;
            _negative = negative;
        }

        public virtual bool Negative
        {
            get { return _negative; }
        }

        protected override void WriteItemContentTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteNamedBlock(_block, Negative);
        }
    }
}
