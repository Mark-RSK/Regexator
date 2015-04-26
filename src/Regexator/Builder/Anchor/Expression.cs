// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Start()
        {
            return AppendInternal(Anchors.Start());
        }

        public QuantifiableExpression StartOfLine()
        {
            return AppendInternal(Anchors.StartOfLine());
        }

        public QuantifiableExpression StartOfLineInvariant()
        {
            return AppendInternal(Anchors.StartOfLineInvariant());
        }

        public QuantifiableExpression EndOfLine()
        {
            return AppendInternal(Anchors.EndOfLine());
        }

        public QuantifiableExpression EndOfLineInvariant()
        {
            return AppendInternal(Anchors.EndOfLineInvariant());
        }

        public QuantifiableExpression EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true);
        }

        internal QuantifiableExpression EndOfLine(bool beforeCarriageReturn)
        {
            return AppendInternal(Anchors.EndOfLine(beforeCarriageReturn));
        }

        public QuantifiableExpression End()
        {
            return AppendInternal(Anchors.End());
        }

        public QuantifiableExpression EndOrBeforeEndingNewLine()
        {
            return AppendInternal(Anchors.EndOrBeforeEndingNewLine());
        }

        public QuantifiableExpression PreviousMatchEnd()
        {
            return AppendInternal(Anchors.PreviousMatchEnd());
        }

        public QuantifiableExpression WordBoundary()
        {
            return AppendInternal(Anchors.WordBoundary());
        }

        public QuantifiableExpression NotWordBoundary()
        {
            return AppendInternal(Anchors.NotWordBoundary());
        }

        public QuantifiableExpression AsLine()
        {
            return Anchors.StartOfLine().AppendInternal(this).EndOfLine();
        }

        public QuantifiableExpression AsEntireInput()
        {
            return Anchors.Start().AppendInternal(this).End();
        }
    }
}
