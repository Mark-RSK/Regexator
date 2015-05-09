// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal class NamedBlockExpression
        : QuantifiableExpression
    {
        private readonly NamedBlock _block;

        internal NamedBlockExpression(NamedBlock block)
        {
            _block = block;
        }

        public NamedBlock Block
        {
            get { return _block; }
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.UnicodeBlock(_block);
        }
    }
}
