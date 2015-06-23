// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CountTo
        : QuantifiedGroup
    {
        private readonly int _maxCount;

        public CountTo(int maxCount, object content)
            : base(content)
        {
            if (maxCount < 0)
            {
                throw new ArgumentOutOfRangeException("maxCount");
            }

            _maxCount = maxCount;
        }

        public CountTo(int maxCount, params object[] content)
            : this(maxCount, (object)content)
        {
        }

        protected override void WriteQuantifierTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteCountToInternal(_maxCount);
        }
    }
}
