// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class QuantifierExpression
        : Expression
    {
        protected QuantifierExpression()
        {
        }

        protected abstract string Content { get; }

        internal abstract QuantifierKind QuantifierKind { get; }

        internal override void BuildContent(PatternWriter writer)
        {
            writer.Write(Content);
        }

        public Expression Lazy()
        {
            return ConcatInternal(new LazyQuantifierExpression());
        }
    }
}
