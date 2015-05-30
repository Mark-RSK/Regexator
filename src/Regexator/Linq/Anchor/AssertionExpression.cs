// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AssertionExpression
        : GroupExpression
    {
        private readonly AssertionKind _assertionKind;

        internal AssertionExpression(AssertionKind kind, object content)
            : base(content)
        {
            _assertionKind = kind;
        }

        internal override string Opening(BuildContext context)
        {
            switch (AssertionKind)
            {
                case AssertionKind.Assert:
                    return Syntax.AssertStart;
                case AssertionKind.AssertBack:
                    return Syntax.AssertBackStart;
                case AssertionKind.NotAssert:
                    return Syntax.NotAssertStart;
                case AssertionKind.NotAssertBack:
                    return Syntax.NotAssertBackStart;
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