// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal class UnicodeBlockExpression
        : QuantifiableExpression
    {
        private readonly UnicodeBlock _block;

        internal UnicodeBlockExpression(UnicodeBlock block)
        {
            _block = block;
        }

        public UnicodeBlock Block
        {
            get { return _block; }
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.UnicodeBlock(_block);
        }
    }
}
