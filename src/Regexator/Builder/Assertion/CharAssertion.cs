// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class CharAssertion
        : Assertion
    {
        private readonly char[] _values;

        internal CharAssertion(AssertionKind kind, params char[] values)
            : base(kind)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            _values = values;
        }

        internal override Expression ChildExpression
        {
            get { return Utilities.CharGroupOrEmpty(_values); }
        }
    }
}