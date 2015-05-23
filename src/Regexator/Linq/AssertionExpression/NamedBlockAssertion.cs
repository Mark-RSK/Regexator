// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NamedBlockAssertion
        : AssertionExpression
    {
        private readonly NamedBlock _block;

        internal NamedBlockAssertion(AssertionKind kind, NamedBlock block)
            : base(kind)
        {
            _block = block;
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.NamedBlock(_block);
        }
    }
}