// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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
            _minCount = minCount;
            _maxCount = maxCount;
        }

        protected override string Content
        {
            get { return Syntax.Count(_minCount, _maxCount); }
        }

        public override QuantifierKind QuantifierKind
        {
            get { return QuantifierKind.FromTo; }
        }
    }
}
