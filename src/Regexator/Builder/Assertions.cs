// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static class Assertions
    {
        public static QuantifiableExpression Lookahead(Expression value)
        {
            return new AssertionExpression(AssertionKind.Lookahead, value);
        }

        public static QuantifiableExpression Lookahead(string value)
        {
            return new AssertionExpression(AssertionKind.Lookahead, value);
        }

        public static QuantifiableExpression Lookahead(char value)
        {
            return new CharAssertion(AssertionKind.Lookahead, value);
        }

        public static QuantifiableExpression Lookahead(int charCode)
        {
            return new CharCodeAssertion(AssertionKind.Lookahead, charCode);
        }

        public static QuantifiableExpression Lookahead(AsciiChar value)
        {
            return new AsciiCharAssertion(AssertionKind.Lookahead, value);
        }

        public static QuantifiableExpression Lookahead(CharClass value)
        {
            return new CharClassAssertion(AssertionKind.Lookahead, value);
        }

        public static QuantifiableExpression Lookahead(NamedBlock block)
        {
            return new NamedBlockAssertion(AssertionKind.Lookahead, block);
        }

        public static QuantifiableExpression Lookahead(UnicodeCategory category)
        {
            return new UnicodeCategoryAssertion(AssertionKind.Lookahead, category);
        }

        public static QuantifiableExpression NotLookahead(Expression value)
        {
            return new AssertionExpression(AssertionKind.NotLookahead, value);
        }

        public static QuantifiableExpression NotLookahead(string value)
        {
            return new AssertionExpression(AssertionKind.NotLookahead, value);
        }

        public static QuantifiableExpression NotLookahead(char value)
        {
            return new CharAssertion(AssertionKind.NotLookahead, value);
        }

        public static QuantifiableExpression NotLookahead(int charCode)
        {
            return new CharCodeAssertion(AssertionKind.NotLookahead, charCode);
        }

        public static QuantifiableExpression NotLookahead(AsciiChar value)
        {
            return new AsciiCharAssertion(AssertionKind.NotLookahead, value);
        }

        public static QuantifiableExpression NotLookahead(CharClass value)
        {
            return new CharClassAssertion(AssertionKind.NotLookahead, value);
        }

        public static QuantifiableExpression NotLookahead(NamedBlock block)
        {
            return new NamedBlockAssertion(AssertionKind.NotLookahead, block);
        }

        public static QuantifiableExpression NotLookahead(UnicodeCategory category)
        {
            return new UnicodeCategoryAssertion(AssertionKind.NotLookahead, category);
        }

        public static QuantifiableExpression Lookbehind(Expression value)
        {
            return new AssertionExpression(AssertionKind.Lookbehind, value);
        }

        public static QuantifiableExpression Lookbehind(string value)
        {
            return new AssertionExpression(AssertionKind.Lookbehind, value);
        }

        public static QuantifiableExpression Lookbehind(char value)
        {
            return new CharAssertion(AssertionKind.Lookbehind, value);
        }

        public static QuantifiableExpression Lookbehind(int charCode)
        {
            return new CharCodeAssertion(AssertionKind.Lookbehind, charCode);
        }

        public static QuantifiableExpression Lookbehind(AsciiChar value)
        {
            return new AsciiCharAssertion(AssertionKind.Lookbehind, value);
        }

        public static QuantifiableExpression Lookbehind(CharClass value)
        {
            return new CharClassAssertion(AssertionKind.Lookbehind, value);
        }

        public static QuantifiableExpression Lookbehind(NamedBlock block)
        {
            return new NamedBlockAssertion(AssertionKind.Lookbehind, block);
        }

        public static QuantifiableExpression Lookbehind(UnicodeCategory category)
        {
            return new UnicodeCategoryAssertion(AssertionKind.Lookbehind, category);
        }

        public static QuantifiableExpression NotLookbehind(Expression value)
        {
            return new AssertionExpression(AssertionKind.NotLookbehind, value);
        }

        public static QuantifiableExpression NotLookbehind(string value)
        {
            return new AssertionExpression(AssertionKind.NotLookbehind, value);
        }

        public static QuantifiableExpression NotLookbehind(char value)
        {
            return new CharAssertion(AssertionKind.NotLookbehind, value);
        }

        public static QuantifiableExpression NotLookbehind(int charCode)
        {
            return new CharCodeAssertion(AssertionKind.NotLookbehind, charCode);
        }

        public static QuantifiableExpression NotLookbehind(AsciiChar value)
        {
            return new AsciiCharAssertion(AssertionKind.NotLookbehind, value);
        }

        public static QuantifiableExpression NotLookbehind(CharClass value)
        {
            return new CharClassAssertion(AssertionKind.NotLookbehind, value);
        }

        public static QuantifiableExpression NotLookbehind(NamedBlock block)
        {
            return new NamedBlockAssertion(AssertionKind.NotLookbehind, block);
        }

        public static QuantifiableExpression NotLookbehind(UnicodeCategory category)
        {
            return new UnicodeCategoryAssertion(AssertionKind.NotLookbehind, category);
        }
    }
}
