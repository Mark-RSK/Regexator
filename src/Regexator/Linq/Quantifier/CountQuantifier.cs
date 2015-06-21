// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CountQuantifier
        : QuantifiedPattern
    {
        private readonly int _count1;
        private readonly int _count2;

        internal CountQuantifier(int exactCount)
            : base()
        {
            if (exactCount < 0)
            {
                throw new ArgumentOutOfRangeException("exactCount");
            }

            _count1 = exactCount;
            _count2 = -1;
        }

        internal CountQuantifier(int minCount, int maxCount)
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

            _count1 = minCount;
            _count2 = maxCount;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            if (_count2 == -1)
            {
                writer.WriteCountInternal(_count1);
            }
            else
            {
                writer.WriteCountInternal(_count1, _count2);
            }
        }
    }
}
