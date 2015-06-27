// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class QuantifiedPattern
    {
        internal sealed class CountQuantifiedPattern
            : QuantifiedPattern
        {
            private readonly int _count1;
            private readonly int _count2;

            internal CountQuantifiedPattern(int exactCount)
                : base()
            {
                if (exactCount < 0)
                {
                    throw new ArgumentOutOfRangeException("exactCount");
                }

                _count1 = exactCount;
                _count2 = -1;
            }

            internal CountQuantifiedPattern(int minCount, int maxCount)
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

        internal sealed class CountFromQuantifiedPattern
            : QuantifiedPattern
        {
            private readonly int _minCount;

            internal CountFromQuantifiedPattern(int minCount)
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

        internal sealed class MaybeQuantifiedPattern
            : QuantifiedPattern
        {
            public MaybeQuantifiedPattern()
                : base()
            {
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteMaybe();
            }
        }

        internal sealed class MaybeManyQuantifiedPattern
            : QuantifiedPattern
        {
            public MaybeManyQuantifiedPattern()
                : base()
            {
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteMaybeMany();
            }
        }

        internal sealed class OneManyQuantifiedPattern
            : QuantifiedPattern
        {
            public OneManyQuantifiedPattern()
                : base()
            {
            }

            internal override void WriteTo(PatternWriter writer)
            {
                writer.WriteOneMany();
            }
        }
    }
}
