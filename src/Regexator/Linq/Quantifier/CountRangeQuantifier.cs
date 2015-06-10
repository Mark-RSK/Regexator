// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CountRangeQuantifier
        : QuantifiedExpression
    {
        private readonly int _minCount;
        private readonly int _maxCount;

        internal CountRangeQuantifier(QuantifiableExpression expression, int minCount, int maxCount)
            : base(expression)
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

        protected override string Content
        {
            get { return Syntax.CountRange(_minCount, _maxCount); }
        }

        internal override QuantifierKind QuantifierKind
        {
            get { return QuantifierKind.CountRange; }
        }
    }
}
