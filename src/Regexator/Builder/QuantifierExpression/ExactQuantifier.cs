// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class ExactQuantifier
        : QuantifierExpression
    {
        private readonly int _count;

        internal ExactQuantifier(int count)
            : base()
        {
            if (count < 0) { throw new ArgumentOutOfRangeException("count"); }
            _count = count;
        }

        protected override string Content
        {
            get { return Syntax.Count(_count); }
        }

        public override QuantifierKind QuantifierKind
        {
            get { return QuantifierKind.Exact; }
        }
    }
}
