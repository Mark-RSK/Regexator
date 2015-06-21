// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class Count
        : QuantifiedGroup
    {
        private readonly int _count1;
        private readonly int _count2;

        public Count(int exactCount, object content)
            : base(content)
        {
            if (exactCount < 0)
            {
                throw new ArgumentOutOfRangeException("exactCount");
            }

            _count1 = exactCount;
            _count2 = -1;
        }

        public Count(int minCount, int maxCount, object content)
            : base(content)
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

        public Count(int minCount, int maxCount, params object[] content)
            : this(minCount, maxCount, (object)content)
        {
        }

        protected override void WriteQuantifierTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

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
