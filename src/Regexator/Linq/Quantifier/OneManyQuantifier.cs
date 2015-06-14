// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class OneManyQuantifier
        : QuantifierExpression
    {
        public OneManyQuantifier()
            : base()
        {
        }

        internal override void BuildContent(PatternWriter writer)
        {
            writer.WriteOneMany();
        }

        internal override QuantifierKind QuantifierKind
        {
            get { return QuantifierKind.OneMany; }
        }
    }
}
