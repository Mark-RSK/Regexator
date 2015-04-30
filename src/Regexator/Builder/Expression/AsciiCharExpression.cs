// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class AsciiCharExpression
        : QuantifiableExpression
    {
        private readonly AsciiChar _value;

        internal AsciiCharExpression(AsciiChar value)
        {
            _value = value;
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.Char(_value);
        }
    }
}
