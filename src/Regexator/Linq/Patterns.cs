// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Patterns
    {
        public static Expression LeadingWhiteSpace()
        {
            return Anchors.StartOfLine().WhiteSpaceExceptNewLine().OneMany();
        }

        public static QuantifiableExpression TrailingWhiteSpace()
        {
            return Chars.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn();
        }

        public static QuantifiableExpression LeadingTrailingWhiteSpace()
        {
            return Expressions.Any(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        public static QuantifiableExpression WhiteSpaceLines()
        {
            return Expressions.Any(
                Anchors.StartOfLineInvariant().WhiteSpace().MaybeMany().NewLine(),
                Expressions.NewLine().WhiteSpace().MaybeMany().End());
        }

        public static QuantifiableExpression EmptyLines()
        {
            return Expressions.Any(
                Anchors.StartOfLineInvariant().NewLine(),
                Expressions.NewLine().OneMany().End());
        }

        public static Expression FirstLine()
        {
            return Anchors
                .Start()
                .NotNewLineChar().MaybeMany();
        }

        internal static Expression ValidGroupName()
        {
            return Expressions.Any(
                Chars.Range('1', '9').ArabicDigit().MaybeMany().AsGroup(),
                Chars.WordChar().Except(Chars.ArabicDigit()).WordChar().MaybeMany()
            ).AsEntireInput();
        }

        internal static Expression TrimInlineComment()
        {
            return Anchors.Start().WhileNot(')');
        }
    }
}
