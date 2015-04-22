// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class FromToQuantifier
        : Quantifier
    {
        private readonly int _minCount;
        private readonly int _maxCount;

        internal FromToQuantifier(int minCount, int maxCount)
            : base()
        {
            if (minCount < 0) { throw new ArgumentOutOfRangeException("minCount"); }
            if (maxCount < minCount) { throw new ArgumentOutOfRangeException("maxCount"); }
            _minCount = minCount;
            _maxCount = maxCount;
        }

        protected override string QuantifierValue
        {
            get { return Syntax.Count(_minCount, _maxCount); }
        }

        public override QuantifierKind QuantifierKind
        {
            get { return QuantifierKind.FromTo; }
        }
    }
}
