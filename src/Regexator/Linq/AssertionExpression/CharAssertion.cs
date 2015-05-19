// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Linq
{
    internal sealed class CharAssertion
        : AssertionExpression
    {
        private readonly char _value;

        internal CharAssertion(AssertionKind kind, char value)
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