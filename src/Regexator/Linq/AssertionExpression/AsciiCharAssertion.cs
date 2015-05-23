// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AsciiCharAssertion
        : AssertionExpression
    {
        private readonly AsciiChar _value;

        internal AsciiCharAssertion(AssertionKind kind, AsciiChar value)
            : base(kind)
        {
            _value = value;
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.Char(_value);
        }
    }
}