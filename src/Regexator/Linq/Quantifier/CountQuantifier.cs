// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CountQuantifier
        : QuantifierExpression
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

        protected override string Content
        {
            get { return Syntax.Count(_count); }
        }

        internal override QuantifierKind QuantifierKind
        {
            get { return QuantifierKind.Count; }
        }
    }
}
