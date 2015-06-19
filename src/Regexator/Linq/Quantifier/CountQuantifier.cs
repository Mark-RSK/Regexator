// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CountQuantifier
        : Quantifier
    {
        private readonly int _count;

        internal CountQuantifier(int count)
            : base()
        {
            if (count < 0)
            {
                throw new ArgumentOutOfRangeException("count");
            }

            _count = count;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteCountInternal(_count);
        }
    }
}
