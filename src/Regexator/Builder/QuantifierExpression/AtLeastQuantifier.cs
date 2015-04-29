// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class AtLeastQuantifier
        : QuantifierExpression
    {
        private readonly int _minCount;

        internal AtLeastQuantifier(int minCount)
            : base()
        {
            if (minCount < 0) { throw new ArgumentOutOfRangeException("minCount"); }
            _minCount = minCount;
        }

        protected override string Content
        {
            get { return Syntax.AtLeast(_minCount); }
        }

        public override QuantifierKind QuantifierKind
        {
            get { return QuantifierKind.AtLeast; }
        }
    }
}