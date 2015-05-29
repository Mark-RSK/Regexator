// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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
            _first = firstCharCode;
            _last = lastCharCode;
            _negative = negative;
        }

        public override bool Negative
        {
            get { return _negative; }
        }

        public override string Content
        {
            get { return Syntax.Range(_first, _last); }
        }
    }
}
