// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class Count
        : QuantifierGroup
    {
        private readonly int _count;

        public Count(int exactCount, object content)
            : base(content)
        {
            if (exactCount < 0)
            {
                throw new ArgumentOutOfRangeException("exactCount");
            }

            _count = exactCount;
        }

        public Count(int exactCount, params object[] content)
            : this(exactCount, (object)content)
        {
        }

        protected override void WriteQuantifierTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteCountInternal(_count);
        }
    }
}
