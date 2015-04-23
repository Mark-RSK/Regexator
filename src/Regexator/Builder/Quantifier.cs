// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public abstract class Quantifier
        : Expression
    {
        private bool _isLazy;

        public Expression Lazy()
        {
            _isLazy = true;
            return this;
        }

        protected abstract string QuantifierValue { get; }

        public abstract QuantifierKind QuantifierKind { get; }

        internal override string Value
        {
            get { return IsLazy ? QuantifierValue + Syntax.Lazy : QuantifierValue; }
        }

        internal bool IsLazy
        {
            get { return _isLazy; }
        }

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.Quantifier; }
        }
    }
}
