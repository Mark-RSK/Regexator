// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharCodeGroup
        : CharGroupExpression
    {
        private readonly int _charCode;
        private readonly bool _negative;

        public CharCodeGroup(int charCode)
            : this(charCode, false)
        {
        }

        public CharCodeGroup(int charCode, bool negative)
        {
            if (charCode < 0 || charCode > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("charCode");
            }

            _charCode = charCode;
            _negative = negative;
        }

        public override bool Negative
        {
            get { return _negative; }
        }

        public override string Content
        {
            get { return Syntax.CharInternal(_charCode, true); }
        }
    }
}
