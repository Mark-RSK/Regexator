// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class QuantifiedExpression
        : Expression
    {
        public QuantifiedExpression()
        {
        }

        protected abstract string Content { get; }

        internal abstract QuantifierKind QuantifierKind { get; }

        internal override void BuildContent(BuildContext context)
        {
            context.Write(Content);
        }

        public Expression Lazy()
        {
            return ConcatInternal(new LazyQuantifierExpression());
        }
    }
}
