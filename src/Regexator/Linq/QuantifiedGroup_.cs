// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class QuantifiedGroup
    {
        internal sealed class CountQuantifiedGroup
            : QuantifiedGroup
        {
            private readonly int _count1;
            private readonly int _count2;

            public CountQuantifiedGroup(int exactCount, object content)
                : base(content)
            {
                if (exactCount < 0)
                {
                    throw new ArgumentOutOfRangeException("exactCount");
                }

                _count1 = exactCount;
                _count2 = -1;
            }

            public CountQuantifiedGroup(int minCount, int maxCount, object content)
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

        internal sealed class CountFromQuantifiedGroup
            : QuantifiedGroup
        {
            private readonly int _minCount;

            public CountFromQuantifiedGroup(int minCount, object content)
                : base(content)
            {
                if (minCount < 0)
                {
                    throw new ArgumentOutOfRangeException("minCount");
                }

                _minCount = minCount;
            }

            protected override void WriteQuantifierTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteCountFromInternal(_minCount);
            }
        }

        internal sealed class MaybeQuantifiedGroup
            : QuantifiedGroup
        {
            public MaybeQuantifiedGroup(object content)
                : base(content)
            {
            }

            protected override void WriteQuantifierTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteMaybe();
            }
        }

        internal sealed class MaybeManyQuantifiedGroup
            : QuantifiedGroup
        {
            public MaybeManyQuantifiedGroup(object content)
                : base(content)
            {
            }

            protected override void WriteQuantifierTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteMaybeMany();
            }
        }

        internal sealed class OneManyQuantifiedGroup
            : QuantifiedGroup
        {
            public OneManyQuantifiedGroup(object content)
                : base(content)
            {
            }

            protected override void WriteQuantifierTo(PatternWriter writer)
            {
                if (writer == null)
                {
                    throw new ArgumentNullException("writer");
                }

                writer.WriteOneMany();
            }
        }
    }
}
