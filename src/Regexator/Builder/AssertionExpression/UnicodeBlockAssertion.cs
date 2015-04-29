// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class UnicodeBlockAssertion
        : AssertionExpression
    {
        private readonly UnicodeBlock[] _blocks;

        internal UnicodeBlockAssertion(AssertionKind kind, params UnicodeBlock[] blocks)
            : base(kind)
        {
            if (blocks == null) { throw new ArgumentNullException("blocks"); }
            _blocks = blocks;
        }

        internal override Expression ChildExpression
        {
            get { return ((_blocks.Length > 0) ? Characters.Group(_blocks) : Expressions.Empty()); }
        }
    }
}