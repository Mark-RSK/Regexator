// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class CharClassAssertion
        : AssertionExpression
    {
        private readonly CharClass _value;

        internal CharClassAssertion(AssertionKind kind, CharClass value)
            : base(kind)
        {
            _value = value;
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.CharClass(_value);
        }
    }
}