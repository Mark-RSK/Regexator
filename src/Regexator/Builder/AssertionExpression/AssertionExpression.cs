// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal class AssertionExpression
        : GroupExpression
    {
        private readonly AssertionKind _assertionKind;

        protected AssertionExpression(AssertionKind kind)
            : base()
        {
            _assertionKind = kind;
        }

        internal AssertionExpression(AssertionKind kind, Expression value)
            : base(value)
        {
            _assertionKind = kind;
        }

        internal AssertionExpression(AssertionKind kind, string value)
            : base(value)
        {
            _assertionKind = kind;
        }

        internal override string Opening(BuildContext context)
        {
            switch (AssertionKind)
            {
                case AssertionKind.Lookahead:
                    return Syntax.LookaheadStart;
                case AssertionKind.Lookbehind:
                    return Syntax.LookbehindStart;
                case AssertionKind.NotLookahead:
                    return Syntax.NotLookaheadStart;
                case AssertionKind.NotLookbehind:
                    return Syntax.NotLookbehindStart;
            }
            return string.Empty;
        }

        public AssertionKind AssertionKind
        {
            get { return _assertionKind; }
        }

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.Assertion; }
        }
    }
}