// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class CharClassAssertion
        : Assertion
    {
        private readonly CharClass[] _values;

        internal CharClassAssertion(AssertionKind kind, params CharClass[] values)
            : base(kind)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            _values = values;
        }

        internal override Expression ChildExpression
        {
            get { return ((_values.Length > 0) ? Expressions.Chars(_values) : Expression.Create()); }
        }
    }
}