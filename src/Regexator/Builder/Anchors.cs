// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static class Anchors
    {
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

        public static Expression WordBoundary(string value)
        {
            return Expressions.Surround(value, WordBoundary(), WordBoundary());
        }

        public static Expression WordBoundary(Expression expression)
        {
            return Expressions.Surround(expression, WordBoundary(), WordBoundary());
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
