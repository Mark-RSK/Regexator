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
            return Alternations.Any(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        public static QuantifiableExpression WhiteSpaceLines()
        {
            return Alternations.Any(
                Anchors.StartOfLineInvariant().WhiteSpace().MaybeMany().NewLine(),
                Expressions.NewLine().WhiteSpace().MaybeMany().EndOfInput());
        }

        public static QuantifiableExpression EmptyLines()
        {
            return Alternations.Any(
                Anchors.StartOfLineInvariant().NewLine(),
                Expressions.NewLine().OneMany().EndOfInput());
        }

        public static Expression FirstLine()
        {
            return Anchors
                .StartOfInput()
                .NotNewLineChar().MaybeMany();
        }

        internal static Expression ValidGroupName()
        {
            return Alternations.Any(
                Chars.CharRange('1', '9').ArabicDigit().MaybeMany().AsCapturing(),
                Chars.WordChar().Except(Chars.ArabicDigit()).WordChar().MaybeMany()
            ).AsEntireInput();
        }

        internal static Expression TrimInlineComment()
        {
            return Anchors.StartOfInput().WhileNot(')');
        }
    }
}
