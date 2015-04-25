// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Expressions
    {
        public static QuantifiableExpression Lookahead(Expression value)
        {
            return new Assertion(AssertionKind.Lookahead, value);
        }

        public static QuantifiableExpression Lookahead(string value)
        {
            return new Assertion(AssertionKind.Lookahead, value);
        }

        public static QuantifiableExpression Lookahead(params char[] values)
        {
            return new CharAssertion(AssertionKind.Lookahead, values);
        }

        public static QuantifiableExpression Lookahead(params int[] charCodes)
        {
            return new CharCodeAssertion(AssertionKind.Lookahead, charCodes);
        }

        public static QuantifiableExpression Lookahead(params AsciiChar[] values)
        {
            return new AsciiCharAssertion(AssertionKind.Lookahead, values);
        }

        public static QuantifiableExpression Lookahead(params CharClass[] values)
        {
            return new CharClassAssertion(AssertionKind.Lookahead, values);
        }

        public static QuantifiableExpression Lookahead(params UnicodeBlock[] blocks)
        {
            return new UnicodeBlockAssertion(AssertionKind.Lookahead, blocks);
        }

        public static QuantifiableExpression Lookahead(params UnicodeCategory[] categories)
        {
            return new UnicodeCategoryAssertion(AssertionKind.Lookahead, categories);
        }

        public static QuantifiableExpression NotLookahead(Expression value)
        {
            return new Assertion(AssertionKind.NotLookahead, value);
        }

        public static QuantifiableExpression NotLookahead(string value)
        {
            return new Assertion(AssertionKind.NotLookahead, value);
        }

        public static QuantifiableExpression NotLookahead(params char[] values)
        {
            return new CharAssertion(AssertionKind.NotLookahead, values);
        }

        public static QuantifiableExpression NotLookahead(params int[] charCodes)
        {
            return new CharCodeAssertion(AssertionKind.NotLookahead, charCodes);
        }

        public static QuantifiableExpression NotLookahead(params AsciiChar[] values)
        {
            return new AsciiCharAssertion(AssertionKind.NotLookahead, values);
        }

        public static QuantifiableExpression NotLookahead(params CharClass[] values)
        {
            return new CharClassAssertion(AssertionKind.NotLookahead, values);
        }

        public static QuantifiableExpression NotLookahead(params UnicodeBlock[] blocks)
        {
            return new UnicodeBlockAssertion(AssertionKind.NotLookahead, blocks);
        }

        public static QuantifiableExpression NotLookahead(params UnicodeCategory[] categories)
        {
            return new UnicodeCategoryAssertion(AssertionKind.NotLookahead, categories);
        }

        public static QuantifiableExpression Lookbehind(Expression value)
        {
            return new Assertion(AssertionKind.Lookbehind, value);
        }

        public static QuantifiableExpression Lookbehind(string value)
        {
            return new Assertion(AssertionKind.Lookbehind, value);
        }

        public static QuantifiableExpression Lookbehind(params char[] values)
        {
            return new CharAssertion(AssertionKind.Lookbehind, values);
        }

        public static QuantifiableExpression Lookbehind(params int[] charCodes)
        {
            return new CharCodeAssertion(AssertionKind.Lookbehind, charCodes);
        }

        public static QuantifiableExpression Lookbehind(params AsciiChar[] values)
        {
            return new AsciiCharAssertion(AssertionKind.Lookbehind, values);
        }

        public static QuantifiableExpression Lookbehind(params CharClass[] values)
        {
            return new CharClassAssertion(AssertionKind.Lookbehind, values);
        }

        public static QuantifiableExpression Lookbehind(params UnicodeBlock[] blocks)
        {
            return new UnicodeBlockAssertion(AssertionKind.Lookbehind, blocks);
        }

        public static QuantifiableExpression Lookbehind(params UnicodeCategory[] categories)
        {
            return new UnicodeCategoryAssertion(AssertionKind.Lookbehind, categories);
        }

        public static QuantifiableExpression NotLookbehind(Expression value)
        {
            return new Assertion(AssertionKind.NotLookbehind, value);
        }

        public static QuantifiableExpression NotLookbehind(string value)
        {
            return new Assertion(AssertionKind.NotLookbehind, value);
        }

        public static QuantifiableExpression NotLookbehind(params char[] values)
        {
            return new CharAssertion(AssertionKind.NotLookbehind, values);
        }

        public static QuantifiableExpression NotLookbehind(params int[] charCodes)
        {
            return new CharCodeAssertion(AssertionKind.NotLookbehind, charCodes);
        }

        public static QuantifiableExpression NotLookbehind(params AsciiChar[] values)
        {
            return new AsciiCharAssertion(AssertionKind.NotLookbehind, values);
        }

        public static QuantifiableExpression NotLookbehind(params CharClass[] values)
        {
            return new CharClassAssertion(AssertionKind.NotLookbehind, values);
        }

        public static QuantifiableExpression NotLookbehind(params UnicodeBlock[] blocks)
        {
            return new UnicodeBlockAssertion(AssertionKind.NotLookbehind, blocks);
        }

        public static QuantifiableExpression NotLookbehind(params UnicodeCategory[] categories)
        {
            return new UnicodeCategoryAssertion(AssertionKind.NotLookbehind, categories);
        }
    }
}
