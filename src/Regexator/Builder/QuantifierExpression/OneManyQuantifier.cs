// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class OneManyQuantifier
        : QuantifierExpression
    {
        protected override string Content
        {
            get { return Syntax.OneMany; }
        }

        public override QuantifierKind QuantifierKind
        {
            get { return QuantifierKind.OneMany; }
        }
    }
}
