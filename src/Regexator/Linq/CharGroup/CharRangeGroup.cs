// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharRangeGroup
        : CharGroupExpression
    {
        private readonly char _firstChar;
        private readonly char _lastChar;
        private readonly bool _negative;

        public CharRangeGroup(char firstChar, char lastChar)
            : this(firstChar, lastChar, false)
        {
        }

        public CharRangeGroup(char firstChar, char lastChar, bool negative)
        {
            _firstChar = firstChar;
            _lastChar = lastChar;
            _negative = negative;
        }

        public override bool Negative
        {
            get { return _negative; }
        }

        public override string Content
        {
            get { return Syntax.CharRange(_firstChar, _lastChar); }
        }
    }
}
