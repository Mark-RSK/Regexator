// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Anchors
    {
        public static QuantifiableExpression Assert(object content)
        {
            return new AssertionExpression(AssertionKind.Assert, content);
        }

        public static QuantifiableExpression Assert(params object[] content)
        {
            return Assert(new AnyExpression(AnyGroupMode.None, content));
        }

        public static QuantifiableExpression Assert(CharGroupItem item)
        {
            return new AssertionExpression(AssertionKind.Assert, item);
        }

        public static QuantifiableExpression NotAssert(object content)
        {
            return new AssertionExpression(AssertionKind.NotAssert, content);
        }

        public static QuantifiableExpression NotAssert(params object[] content)
        {
            return NotAssert(new AnyExpression(AnyGroupMode.None, content));
        }

        public static QuantifiableExpression NotAssert(CharGroupItem item)
        {
            return new AssertionExpression(AssertionKind.NotAssert, item);
        }

        public static QuantifiableExpression AssertBack(object content)
        {
            return new AssertionExpression(AssertionKind.AssertBack, content);
        }

        public static QuantifiableExpression AssertBack(params object[] content)
        {
            return AssertBack(new AnyExpression(AnyGroupMode.None, content));
        }

        public static QuantifiableExpression AssertBack(CharGroupItem item)
        {
            return new AssertionExpression(AssertionKind.AssertBack, item);
        }

        public static QuantifiableExpression NotAssertBack(object content)
        {
            return new AssertionExpression(AssertionKind.NotAssertBack, content);
        }

        public static QuantifiableExpression NotAssertBack(params object[] content)
        {
            return NotAssertBack(new AnyExpression(AnyGroupMode.None, content));
        }

        public static QuantifiableExpression NotAssertBack(CharGroupItem item)
        {
            return new AssertionExpression(AssertionKind.NotAssertBack, item);
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
            return Groups.Options(InlineOptions.Multiline, Anchors.StartOfLine());

            //return Alternations.Any(Start(), AssertBack(Chars.Linefeed()));
        }

        public static QuantifiableExpression EndOfLine()
        {
            return new EndOfLine();
        }

        public static QuantifiableExpression EndOfLineInvariant()
        {
            return Groups.Options(InlineOptions.Multiline, Anchors.EndOfLine());

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

        public static Expression Word(object content)
        {
            return Expressions.Surround(content, WordBoundary());
        }

        public static QuantifiableExpression NotWordBoundary()
        {
            return new NotWordBoundary();
        }

        public static Expression Line(object content)
        {
            return Expressions.Surround(content, StartOfLine(), EndOfLine());
        }

        public static Expression LineInvariant(object content)
        {
            return Expressions.Surround(content, StartOfLineInvariant(), EndOfLineInvariant());
        }

        public static Expression EntireInput(object content)
        {
            return Expressions.Surround(content, Start(), End());
        }
    }
}
