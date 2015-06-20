// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CountFromQuantifier
        : Quantifier
    {
        private readonly int _minCount;

        internal CountFromQuantifier(int minCount)
            : base()
        {
            if (minCount < 0)
            {
                throw new ArgumentOutOfRangeException("minCount");
            }

            _minCount = minCount;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteCountFromInternal(_minCount);
        }
    }
}
