// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    public static class Expressions
    {
        public static Expression Empty()
        {
            return new TextExpression();
        }

        public static Expression Text(string value)
        {
            return new TextExpression(value);
        }

        public static Expression LeadingWhiteSpace()
        {
            return Anchor.StartOfLine().WhiteSpaceExceptNewLine().OneMany();
        }

        public static QuantifiableExpression TrailingWhiteSpace()
        {
            return Miscellaneous.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn();
        }

        public static QuantifiableExpression LeadingTrailingWhiteSpace()
        {
            return Alternation.Any(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        public static QuantifiableExpression WhiteSpaceLines()
        {
            return Miscellaneous.Options(InlineOptions.Multiline).Any(
                Anchor.StartOfLine().WhiteSpace().MaybeMany().NewLine(),
                NewLine().WhiteSpace().MaybeMany().End());
        }

        public static QuantifiableExpression EmptyLines()
        {
            return Miscellaneous.Options(InlineOptions.Multiline).Any(
                Anchor.StartOfLine().NewLine(),
                NewLine().OneMany().End());
        }

        public static QuantifiableExpression FirstLastEmptyLine()
        {
            return Alternation.Any(Anchor.Start().NewLine(), NewLine().End()).AsNonbacktracking();
        }

        public static QuantifiableExpression FirstLine()
        {
            return Miscellaneous.Options(InlineOptions.Multiline).Start().Any().MaybeMany().Lazy().EndOfLineOrBeforeCarriageReturn();
        }

        public static QuantifiableExpression NewLine()
        {
            return Character.CarriageReturn().Maybe().Linefeed().AsNoncapturing();
        }

        public static QuantifiableExpression LinefeedWithoutCarriageReturn()
        {
            return Character.CarriageReturn().AsNotLookbehind().Linefeed().AsNonbacktracking();
        }

        internal static QuantifiableExpression InsignificantSeparator()
        {
            return Grouping.GroupOptions(InlineOptions.IgnorePatternWhitespace, new TextExpression(" ", false));
        }
    }
}
