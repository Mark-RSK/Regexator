// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class QuantifiedExpression
        : Expression
    {
        private readonly QuantifiableExpression _expression;

        public QuantifiedExpression(QuantifiableExpression expression)
        {
            _expression = expression;
        }

        protected abstract string Content { get; }

        internal abstract QuantifierKind QuantifierKind { get; }

        internal override void BuildContent(BuildContext context)
        {
            _expression.BuildContent(context);

            context.Write(Content);
        }

        public LazyQuantifiedExpression Lazy()
        {
            return new LazyQuantifiedExpression(this);
        }
    }
}
