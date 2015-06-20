// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CountRangeQuantifier
        : Quantifier
    {
        private readonly int _minCount;
        private readonly int _maxCount;

        internal CountRangeQuantifier(int minCount, int maxCount)
            : base()
        {
            if (minCount < 0)
            {
                throw new ArgumentOutOfRangeException("minCount");
            }

            if (maxCount < minCount)
            {
                throw new ArgumentOutOfRangeException("maxCount");
            }

            _minCount = minCount;
            _maxCount = maxCount;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteCountRangeInternal(_minCount, _maxCount);
        }
    }
}
