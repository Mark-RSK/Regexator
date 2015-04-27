// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class AsciiCharAssertion
        : AssertionExpression
    {
        private readonly AsciiChar[] _values;

        internal AsciiCharAssertion(AssertionKind kind, params AsciiChar[] values)
            : base(kind)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            _values = values;
        }

        internal override Expression ChildExpression
        {
            get { return ((_values.Length > 0) ? Grouping.Chars(_values) : Expressions.Empty()); }
        }
    }
}