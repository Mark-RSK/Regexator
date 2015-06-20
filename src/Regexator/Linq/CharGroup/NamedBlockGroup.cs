// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class NamedBlockGroup
        : CharGroup
    {
        private readonly NamedBlock _block;

        public NamedBlockGroup(NamedBlock block)
        {
            _block = block;
        }

        protected override void WriteContentTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteNamedBlock(_block, Negative);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteCharGroup(_block, Negative);
        }
    }
}
