// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class CharCodeExpression
        : QuantifiableExpression
    {
        private readonly int _charCode;

        internal CharCodeExpression(int charCode)
        {
            if (charCode < 0 || charCode > 0xFFFF) { throw new ArgumentOutOfRangeException("charCode"); }
            _charCode = charCode;
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.CharInternal(_charCode);
        }
    }
}
