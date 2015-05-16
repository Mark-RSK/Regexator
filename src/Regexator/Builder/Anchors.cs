// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static class Anchors
    {
        public static QuantifiableExpression Lookahead(Expression value)
        {
            return new AssertionExpression(AssertionKind.Lookahead, value);
        }

        public static QuantifiableExpression Lookahead(string value)
        {
            return new AssertionExpression(AssertionKind.Lookahead, value);
        }

        public static QuantifiableExpression Lookahead(CharGroupItem item)
        {
            return new CharGroupAssertion(AssertionKind.Lookahead, item);
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

        public static QuantifiableExpression Lookahead(NamedBlock block)
        {
            return new NamedBlockAssertion(AssertionKind.Lookahead, block);
        }

        public static QuantifiableExpression Lookahead(GeneralCategory category)
        {
            return new GeneralCategoryAssertion(AssertionKind.Lookahead, category);
        }

        public static QuantifiableExpression NotLookahead(Expression value)
        {
            return new AssertionExpression(AssertionKind.NotLookahead, value);
        }

        public static QuantifiableExpression NotLookahead(string value)
        {
            return new AssertionExpression(AssertionKind.NotLookahead, value);
        }

        public static QuantifiableExpression NotLookahead(CharGroupItem item)
        {
            return new CharGroupAssertion(AssertionKind.NotLookahead, item);
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

        public static QuantifiableExpression NotLookahead(NamedBlock block)
        {
            return new NamedBlockAssertion(AssertionKind.NotLookahead, block);
        }

        public static QuantifiableExpression NotLookahead(GeneralCategory category)
        {
            return new GeneralCategoryAssertion(AssertionKind.NotLookahead, category);
        }

        public static QuantifiableExpression Lookbehind(Expression value)
        {
            return new AssertionExpression(AssertionKind.Lookbehind, value);
        }

        public static QuantifiableExpression Lookbehind(string value)
        {
            return new AssertionExpression(AssertionKind.Lookbehind, value);
        }

        public static QuantifiableExpression Lookbehind(CharGroupItem item)
        {
            return new CharGroupAssertion(AssertionKind.Lookbehind, item);
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

        public static QuantifiableExpression Lookbehind(NamedBlock block)
        {
            return new NamedBlockAssertion(AssertionKind.Lookbehind, block);
        }

        public static QuantifiableExpression Lookbehind(GeneralCategory category)
        {
            return new GeneralCategoryAssertion(AssertionKind.Lookbehind, category);
        }

        public static QuantifiableExpression NotLookbehind(Expression value)
        {
            return new AssertionExpression(AssertionKind.NotLookbehind, value);
        }

        public static QuantifiableExpression NotLookbehind(string value)
        {
            return new AssertionExpression(AssertionKind.NotLookbehind, value);
        }

        public static QuantifiableExpression NotLookbehind(CharGroupItem item)
        {
            return new CharGroupAssertion(AssertionKind.NotLookbehind, item);
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

        public static QuantifiableExpression NotLookbehind(NamedBlock block)
        {
            return new NamedBlockAssertion(AssertionKind.NotLookbehind, block);
        }

        public static QuantifiableExpression NotLookbehind(GeneralCategory category)
        {
            return new GeneralCategoryAssertion(AssertionKind.NotLookbehind, category);
        }

        public static QuantifiableExpression Start()
        {
            return new StartOfInput();
        }

        public static QuantifiableExpression StartOfLine()
        {
            return new StartOfLine();
        }

        public static QuantifiableExpression StartOfLineInvariant()
        {
            return Alternations.Any(Start(), Chars.Linefeed().AsLookbehind());
        }

        public static QuantifiableExpression EndOfLine()
        {
            return new EndOfLine();
        }

        public static QuantifiableExpression EndOfLineInvariant()
        {
            return Alternations.Any(Chars.Linefeed().AsLookahead(), End());
        }

        public static QuantifiableExpression EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true);
        }

        internal static QuantifiableExpression EndOfLine(bool beforeCarriageReturn)
        {
            if (beforeCarriageReturn)
            {
                return Chars.CarriageReturn().Maybe().EndOfLine().AsLookahead();
            }
            else
            {
                return EndOfLine();
            }
        }

        public static QuantifiableExpression End()
        {
            return new EndOfInput();
        }

        public static QuantifiableExpression EndOrBeforeEndingNewLine()
        {
            return new EndOrBeforeEndingNewLine();
        }

        public static QuantifiableExpression PreviousMatchEnd()
        {
            return new PreviousMatchEnd();
        }

        public static QuantifiableExpression WordBoundary()
        {
            return new WordBoundary();
        }

        public static Expression Word(string value)
        {
            return Expressions.Surround(value, WordBoundary());
        }

        public static Expression Word(Expression expression)
        {
            return Expressions.Surround(expression, WordBoundary());
        }

        public static QuantifiableExpression NotWordBoundary()
        {
            return new NotWordBoundary();
        }

        public static Expression Line(Expression expression)
        {
            return Expressions.Surround(expression, StartOfLine(), EndOfLine());
        }

        public static Expression LineInvariant(Expression expression)
        {
            return Expressions.Surround(expression, StartOfLineInvariant(), EndOfLineInvariant());
        }

        public static Expression EntireInput(Expression expression)
        {
            return Expressions.Surround(expression, Start(), End());
        }
    }
}
