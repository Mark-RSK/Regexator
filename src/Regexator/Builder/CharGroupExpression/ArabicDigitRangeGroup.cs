// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal class ArabicDigitRangeGroup
        : CharGroupExpression
    {
        private readonly int _first;
        private readonly int _last;

        public ArabicDigitRangeGroup(int first, int last)
        {
            if (first < 0 || first > 9) { throw new ArgumentOutOfRangeException("first"); }
            if (last < 0 || last > 9 || last < first) { throw new ArgumentOutOfRangeException("last"); }
            _first = first;
            _last = last;
        }

        public override string Content
        {
            get { return Syntax.ArabicDigitRangeInternal(_first, _last); }
        }
    }
}
