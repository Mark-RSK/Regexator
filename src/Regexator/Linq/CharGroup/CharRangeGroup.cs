// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharRangeGroup
        : CharGroupExpression
    {
        private readonly char _first;
        private readonly char _last;
        private readonly bool _negative;

        public CharRangeGroup(char first, char last)
            : this(first, last, false)
        {
        }

        public CharRangeGroup(char first, char last, bool negative)
        {
            _first = first;
            _last = last;
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
