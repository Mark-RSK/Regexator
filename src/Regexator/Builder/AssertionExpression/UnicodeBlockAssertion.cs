// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class UnicodeBlockAssertion
        : AssertionExpression
    {
        private readonly UnicodeBlock _block;

        internal UnicodeBlockAssertion(AssertionKind kind, UnicodeBlock block)
            : base(kind)
        {
            _block = block;
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.UnicodeBlock(_block);
        }
    }
}