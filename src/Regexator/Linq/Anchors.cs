// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Linq
{
    public static class Anchors
    {
        public static QuantifiableExpression Assert(Expression expression)
        {
            return new AssertionExpression(AssertionKind.Assert, expression);
        }

        public static QuantifiableExpression Assert(string text)
        {
            return new AssertionExpression(AssertionKind.Assert, text);
        }

        public static QuantifiableExpression Assert(CharGroupItem item)
        {
            return new CharGroupAssertion(AssertionKind.Assert, item);
        }

        public static QuantifiableExpression Assert(char value)
        {
            return new CharAssertion(AssertionKind.Assert, value);
        }

        public static QuantifiableExpression Assert(int charCode)
        {
            return new CharCodeAssertion(AssertionKind.Assert, charCode);
        }

        public static QuantifiableExpression Assert(AsciiChar value)
        {
            return new AsciiCharAssertion(AssertionKind.Assert, value);
        }

        public static QuantifiableExpression Assert(NamedBlock block)
        {
            return new NamedBlockAssertion(AssertionKind.Assert, block);
        }

        public static QuantifiableExpression Assert(GeneralCategory category)
        {
            return new GeneralCategoryAssertion(AssertionKind.Assert, category);
        }

        public static QuantifiableExpression NotAssert(Expression expression)
        {
            return new AssertionExpression(AssertionKind.NotAssert, expression);
        }

        public static QuantifiableExpression NotAssert(string text)
        {
            return new AssertionExpression(AssertionKind.NotAssert, text);
        }

        public static QuantifiableExpression NotAssert(CharGroupItem item)
        {
            return new CharGroupAssertion(AssertionKind.NotAssert, item);
        }

        public static QuantifiableExpression NotAssert(char value)
        {
            return new CharAssertion(AssertionKind.NotAssert, value);
        }

        public static QuantifiableExpression NotAssert(int charCode)
        {
            return new CharCodeAssertion(AssertionKind.NotAssert, charCode);
        }

        public static QuantifiableExpression NotAssert(AsciiChar value)
        {
            return new AsciiCharAssertion(AssertionKind.NotAssert, value);
        }

        public static QuantifiableExpression NotAssert(NamedBlock block)
        {
            return new NamedBlockAssertion(AssertionKind.NotAssert, block);
        }

        public static QuantifiableExpression NotAssert(GeneralCategory category)
        {
            return new GeneralCategoryAssertion(AssertionKind.NotAssert, category);
        }

        public static QuantifiableExpression AssertBack(Expression expression)
        {
            return new AssertionExpression(AssertionKind.AssertBack, expression);
        }

        public static QuantifiableExpression AssertBack(string text)
        {
            return new AssertionExpression(AssertionKind.AssertBack, text);
        }

        public static QuantifiableExpression AssertBack(CharGroupItem item)
        {
            return new CharGroupAssertion(AssertionKind.AssertBack, item);
        }

        public static QuantifiableExpression AssertBack(char value)
        {
            return new CharAssertion(AssertionKind.AssertBack, value);
        }

        public static QuantifiableExpression AssertBack(int charCode)
        {
            return new CharCodeAssertion(AssertionKind.AssertBack, charCode);
        }

        public static QuantifiableExpression AssertBack(AsciiChar value)
        {
            return new AsciiCharAssertion(AssertionKind.AssertBack, value);
        }

        public static QuantifiableExpression AssertBack(NamedBlock block)
        {
            return new NamedBlockAssertion(AssertionKind.AssertBack, block);
        }

        public static QuantifiableExpression AssertBack(GeneralCategory category)
        {
            return new GeneralCategoryAssertion(AssertionKind.AssertBack, category);
        }

        public static QuantifiableExpression NotAssertBack(Expression expression)
        {
            return new AssertionExpression(AssertionKind.NotAssertBack, expression);
        }

        public static QuantifiableExpression NotAssertBack(string text)
        {
            return new AssertionExpression(AssertionKind.NotAssertBack, text);
        }

        public static QuantifiableExpression NotAssertBack(CharGroupItem item)
        {
            return new CharGroupAssertion(AssertionKind.NotAssertBack, item);
        }

        public static QuantifiableExpression NotAssertBack(char value)
        {
            return new CharAssertion(AssertionKind.NotAssertBack, value);
        }

        public static QuantifiableExpression NotAssertBack(int charCode)
        {
            return new CharCodeAssertion(AssertionKind.NotAssertBack, charCode);
        }

        public static QuantifiableExpression NotAssertBack(AsciiChar value)
        {
            return new AsciiCharAssertion(AssertionKind.NotAssertBack, value);
        }

        public static QuantifiableExpression NotAssertBack(NamedBlock block)
        {
            return new NamedBlockAssertion(AssertionKind.NotAssertBack, block);
        }

        public static QuantifiableExpression NotAssertBack(GeneralCategory category)
        {
            return new GeneralCategoryAssertion(AssertionKind.NotAssertBack, category);
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
            return Alternations.Any(Start(), Chars.Linefeed().AsAssertBack());
        }

        public static QuantifiableExpression EndOfLine()
        {
            return new EndOfLine();
        }

        public static QuantifiableExpression EndOfLineInvariant()
        {
            return Alternations.Any(Chars.Linefeed().AsAssert(), End());
        }

        public static QuantifiableExpression EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true);
        }

        internal static QuantifiableExpression EndOfLine(bool beforeCarriageReturn)
        {
            if (beforeCarriageReturn)
            {
                return Chars.CarriageReturn().Maybe().EndOfLine().AsAssert();
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

        public static Expression Word(string text)
        {
            return Expressions.Surround(text, WordBoundary());
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
