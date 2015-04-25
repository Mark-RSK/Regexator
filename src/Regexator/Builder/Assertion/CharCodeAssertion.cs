// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class CharCodeAssertion
        : Assertion
    {
        private readonly int[] _charCodes;

        internal CharCodeAssertion(AssertionKind kind, params int[] charCodes)
            : base(kind)
        {
            if (charCodes == null) { throw new ArgumentNullException("charCodes"); }
            _charCodes = charCodes;
        }

        internal override Expression ChildExpression
        {
            get { return ((_charCodes.Length > 0) ? Expressions.Chars(_charCodes) : Expression.Create()); }
        }
    }
}