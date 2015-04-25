// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Start()
        {
            return Append(Anchors.Start());
        }

        public QuantifiableExpression StartOfLine()
        {
            return Append(Anchors.StartOfLine());
        }

        public QuantifiableExpression EndOfLine()
        {
            return Append(Anchors.EndOfLine());
        }

        public QuantifiableExpression EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true);
        }

        internal QuantifiableExpression EndOfLine(bool beforeCarriageReturn)
        {
            return Append(Anchors.EndOfLine(beforeCarriageReturn));
        }

        public QuantifiableExpression End()
        {
            return Append(Anchors.End());
        }

        public QuantifiableExpression EndOrBeforeEndingNewLine()
        {
            return Append(Anchors.EndOrBeforeEndingNewLine());
        }

        public QuantifiableExpression PreviousMatchEnd()
        {
            return Append(Anchors.PreviousMatchEnd());
        }

        public QuantifiableExpression WordBoundary()
        {
            return Append(Anchors.WordBoundary());
        }

        public QuantifiableExpression NotWordBoundary()
        {
            return Append(Anchors.NotWordBoundary());
        }

        public QuantifiableExpression AsLine()
        {
            return Anchors.StartOfLine().Append(this).EndOfLine();
        }

        public QuantifiableExpression AsEntireInput()
        {
            return Anchors.Start().Append(this).End();
        }
    }
}
