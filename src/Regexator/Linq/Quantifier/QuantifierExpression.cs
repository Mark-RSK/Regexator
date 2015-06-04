// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class QuantifierExpression
        : Expression
    {
        private bool _isLazy;

        public Expression Lazy()
        {
            _isLazy = true;
            return this;
        }

        protected abstract string Content { get; }

        internal abstract QuantifierKind QuantifierKind { get; }

        internal override string Value(BuildContext context)
        {
            return IsLazy ? Content + Syntax.Lazy : Content;
        }

        internal bool IsLazy
        {
            get { return _isLazy; }
        }
    }
}
