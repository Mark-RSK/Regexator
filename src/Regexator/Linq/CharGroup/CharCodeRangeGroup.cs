// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharCodeRangeGroup
        : CharGroupExpression
    {
        private readonly int _first;
        private readonly int _last;
        private readonly bool _negative;

        public CharCodeRangeGroup(int firstCharCode, int lastCharCode)
            : this(firstCharCode, lastCharCode, false)
        {
        }

        public CharCodeRangeGroup(int firstCharCode, int lastCharCode, bool negative)
        {
            if (firstCharCode < 0 || firstCharCode > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("firstCharCode");
            }

            if (lastCharCode < firstCharCode || lastCharCode > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("lastCharCode");
            }

            _first = firstCharCode;
            _last = lastCharCode;
            _negative = negative;
        }

        public override bool Negative
        {
            get { return _negative; }
        }

        internal override void BuildContent(PatternWriter writer)
        {
            writer.Write(Syntax.RangeInternal(_first, _last));
        }
    }
}
