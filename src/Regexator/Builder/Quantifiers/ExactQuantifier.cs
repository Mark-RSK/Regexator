// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class ExactQuantifier
        : Quantifier
    {
        private readonly int _count;

        internal ExactQuantifier(int count)
            : base()
        {
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
