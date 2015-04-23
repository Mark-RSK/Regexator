// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class Assertion
        : GroupingConstruct
    {
        private readonly AssertionKind _assertionKind;

        internal Assertion(AssertionKind kind, params char[] values)
            : this(kind, Utilities.CharGroupOrEmpty(values))
        {
        }

        internal Assertion(AssertionKind kind, params int[] charCodes)
            : this(kind, Utilities.CharGroupOrEmpty(charCodes))
        {
        }

        internal Assertion(AssertionKind kind, params AsciiChar[] values)
            : this(kind, Utilities.CharGroupOrEmpty(values))
        {
        }

        internal Assertion(AssertionKind kind, params CharClass[] values)
            : this(kind, Utilities.CharGroupOrEmpty(values))
        {
        }

        internal Assertion(AssertionKind kind, params UnicodeBlock[] blocks)
            : this(kind, Utilities.CharGroupOrEmpty(blocks))
        {
        }

        internal Assertion(AssertionKind kind, params UnicodeCategory[] categories)
            : this(kind, Utilities.CharGroupOrEmpty(categories))
        {
        }

        internal Assertion(AssertionKind kind, Expression value)
            : base(value)
        {
            _assertionKind = kind;
        }

        internal Assertion(AssertionKind kind, string value)
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