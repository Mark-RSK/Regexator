// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CountFrom
        : QuantifierGroup
    {
        private readonly int _minCount;

        public CountFrom(int minCount, object content)
            : base(content)
        {
            if (minCount < 0)
            {
                throw new ArgumentOutOfRangeException("minCount");
            }

            _minCount = minCount;
        }

        public CountFrom(int minCount, params object[] content)
            : this(minCount, (object)content)
        {
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
}
