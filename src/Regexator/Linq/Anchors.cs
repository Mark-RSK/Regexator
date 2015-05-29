// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Anchors
    {
        public static QuantifiableExpression Assert(object content)
        {
            return new AssertionExpression(AssertionKind.Assert, content);
        }

        public static QuantifiableExpression Assert(Expression expression)
        {
            return new AssertionExpression(AssertionKind.Assert, expression);
        }

        public static QuantifiableExpression Assert(string text)
        {
            return new AssertionExpression(AssertionKind.Assert, text);
        }

        public static QuantifiableExpression Assert(params Expression[] expressions)
        {
            return Assert(new AnyExpression(AnyGroupMode.None, expressions));
        }

        public static QuantifiableExpression Assert(params string[] values)
        {
            return Assert(new AnyExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression Assert(CharGroupItem item)
        {
            return new CharGroupAssertion(AssertionKind.Assert, item);
        }

        public static QuantifiableExpression NotAssert(object content)
        {
            return new AssertionExpression(AssertionKind.NotAssert, content);
        }

        public static QuantifiableExpression NotAssert(Expression expression)
        {
            return new AssertionExpression(AssertionKind.NotAssert, expression);
        }

        public static QuantifiableExpression NotAssert(string text)
        {
            return new AssertionExpression(AssertionKind.NotAssert, text);
        }

        public static QuantifiableExpression NotAssert(params Expression[] expressions)
        {
            return NotAssert(new AnyExpression(AnyGroupMode.None, expressions));
        }

        public static QuantifiableExpression NotAssert(params string[] values)
        {
            return NotAssert(new AnyExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression NotAssert(CharGroupItem item)
        {
            return new CharGroupAssertion(AssertionKind.NotAssert, item);
        }

        public static QuantifiableExpression AssertBack(object content)
        {
            return new AssertionExpression(AssertionKind.AssertBack, content);
        }

        public static QuantifiableExpression AssertBack(Expression expression)
        {
            return new AssertionExpression(AssertionKind.AssertBack, expression);
        }

        public static QuantifiableExpression AssertBack(string text)
        {
            return new AssertionExpression(AssertionKind.AssertBack, text);
        }

        public static QuantifiableExpression AssertBack(params Expression[] expressions)
        {
            return AssertBack(new AnyExpression(AnyGroupMode.None, expressions));
        }

        public static QuantifiableExpression AssertBack(params string[] values)
        {
            return AssertBack(new AnyExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression AssertBack(CharGroupItem item)
        {
            return new CharGroupAssertion(AssertionKind.AssertBack, item);
        }

        public static QuantifiableExpression NotAssertBack(object content)
        {
            return new AssertionExpression(AssertionKind.NotAssertBack, content);
        }

        public static QuantifiableExpression NotAssertBack(Expression expression)
        {
            return new AssertionExpression(AssertionKind.NotAssertBack, expression);
        }

        public static QuantifiableExpression NotAssertBack(string text)
        {
            return new AssertionExpression(AssertionKind.NotAssertBack, text);
        }

        public static QuantifiableExpression NotAssertBack(params Expression[] expressions)
        {
            return NotAssertBack(new AnyExpression(AnyGroupMode.None, expressions));
        }

        public static QuantifiableExpression NotAssertBack(params string[] values)
        {
            return NotAssertBack(new AnyExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression NotAssertBack(CharGroupItem item)
        {
            return new CharGroupAssertion(AssertionKind.NotAssertBack, item);
        }

        public static Expression AssertSurround(object value, object surroundValue)
        {
            return Expressions.Surround(value, Anchors.AssertBack(surroundValue), Anchors.Assert(surroundValue));
        }

        public static Expression NotAssertSurround(object value, object surroundValue)
        {
            return Expressions.Surround(value, Anchors.NotAssertBack(surroundValue), Anchors.NotAssert(surroundValue));
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
            return StartOfLine().WithOptions(InlineOptions.Multiline);

            //return Alternations.Any(Start(), AssertBack(Chars.Linefeed()));
        }

        public static QuantifiableExpression EndOfLine()
        {
            return new EndOfLine();
        }

        public static QuantifiableExpression EndOfLineInvariant()
        {
            return EndOfLine().WithOptions(InlineOptions.Multiline);

            //return Alternations.Any(Assert(Chars.Linefeed()), End());
        }

        public static QuantifiableExpression EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true, false);
        }

        public static QuantifiableExpression EndOfLineOrBeforeCarriageReturnInvariant()
        {
            return EndOfLine(true, true);
        }

        internal static QuantifiableExpression EndOfLine(bool beforeCarriageReturn, bool invariant)
        {
            if (beforeCarriageReturn)
            {
                if (invariant)
                {
                    return NotAssertBack(Chars.CarriageReturn()).Assert(Chars.CarriageReturn().Maybe().EndOfLineInvariant());
                }
                else
                {
                    return NotAssertBack(Chars.CarriageReturn()).Assert(Chars.CarriageReturn().Maybe().EndOfLine());
                }
            }
            else
            {
                return invariant ? EndOfLineInvariant() : EndOfLine();
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
