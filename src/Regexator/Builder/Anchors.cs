// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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
            return Alternations.Any(Start(), Characters.Linefeed().AsLookbehind());
        }

        public static QuantifiableExpression EndOfLine()
        {
            return new EndOfLine();
        }

        public static QuantifiableExpression EndOfLineInvariant()
        {
            return Alternations.Any(Characters.Linefeed().AsLookahead(), End());
        }

        public static QuantifiableExpression EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true);
        }

        internal static QuantifiableExpression EndOfLine(bool beforeCarriageReturn)
        {
            if (beforeCarriageReturn)
            {
                return Characters.CarriageReturn().Maybe().EndOfLine().AsLookahead();
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

        public static QuantifiableExpression WordBoundary(string value)
        {
            return new EnclosingExpression(value, WordBoundary(), WordBoundary());
        }

        public static QuantifiableExpression WordBoundary(Expression expression)
        {
            return new EnclosingExpression(expression, WordBoundary(), WordBoundary());
        }

        public static QuantifiableExpression NotWordBoundary()
        {
            return new NotWordBoundary();
        }

        public static QuantifiableExpression Line(Expression expression)
        {
            return new EnclosingExpression(expression, StartOfLine(), EndOfLine());
        }

        public static QuantifiableExpression LineInvariant(Expression expression)
        {
            return new EnclosingExpression(expression, StartOfLineInvariant(), EndOfLineInvariant());
        }

        public static QuantifiableExpression EntireInput(Expression expression)
        {
            return new EnclosingExpression(expression, Start(), End());
        }
    }
}
