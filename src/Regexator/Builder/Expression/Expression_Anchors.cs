// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Start()
        {
            return Append(Expressions.Start());
        }

        public QuantifiableExpression StartOfLine()
        {
            return Append(Expressions.StartOfLine());
        }

        public QuantifiableExpression EndOfLine()
        {
            return Append(Expressions.EndOfLine());
        }

        public QuantifiableExpression EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true);
        }

        internal QuantifiableExpression EndOfLine(bool beforeCarriageReturn)
        {
            return Append(Expressions.EndOfLine(beforeCarriageReturn));
        }

        public QuantifiableExpression End()
        {
            return Append(Expressions.End());
        }

        public QuantifiableExpression EndOrBeforeEndingNewLine()
        {
            return Append(Expressions.EndOrBeforeEndingNewLine());
        }

        public QuantifiableExpression PreviousMatchEnd()
        {
            return Append(Expressions.PreviousMatchEnd());
        }

        public QuantifiableExpression WordBoundary()
        {
            return Append(Expressions.WordBoundary());
        }

        public QuantifiableExpression NotWordBoundary()
        {
            return Append(Expressions.NotWordBoundary());
        }

        public QuantifiableExpression AsLine()
        {
            return Expressions.StartOfLine().Append(First).EndOfLine();
        }

        public QuantifiableExpression AsEntireInput()
        {
            return Expressions.Start().Append(First).End();
        }
    }
}
