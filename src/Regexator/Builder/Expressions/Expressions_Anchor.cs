// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Expressions
    {
        public static QuantifiableExpression Start()
        {
            return new Anchor(Syntax.Start);
        }

        public static QuantifiableExpression StartOfLine()
        {
            return new Anchor(Syntax.StartOfLine);
        }

        public static QuantifiableExpression EndOfLine()
        {
            return new Anchor(Syntax.EndOfLine);
        }

        public static QuantifiableExpression EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true);
        }

        internal static QuantifiableExpression EndOfLine(bool beforeCarriageReturn)
        {
            if (beforeCarriageReturn)
            {
                return CarriageReturn().Maybe().EndOfLine().AsLookahead();
            }
            else
            {
                return EndOfLine();
            }
        }

        public static QuantifiableExpression End()
        {
            return new Anchor(Syntax.End);
        }

        public static QuantifiableExpression EndOrBeforeEndingNewLine()
        {
            return new Anchor(Syntax.EndOrBeforeEndingNewLine);
        }

        public static QuantifiableExpression PreviousMatchEnd()
        {
            return new Anchor(Syntax.PreviousMatchEnd);
        }

        public static QuantifiableExpression WordBoundary()
        {
            return new Anchor(Syntax.WordBoundary);
        }

        public static QuantifiableExpression NotWordBoundary()
        {
            return new Anchor(Syntax.NotWordBoundary);
        }
    }
}
