// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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

        internal static Expression Surround(string value, Expression beforeExpression, Expression afterExpression)
        {
            return new SurroundExpression(value, beforeExpression, afterExpression);
        }

        internal static Expression Surround(Expression expression, Expression beforeExpression, Expression afterExpression)
        {
            return new SurroundExpression(expression, beforeExpression, afterExpression);
        }

        public static QuantifiableExpression Never()
        {
            return Assertions.NotLookahead(string.Empty);
        }

        public static Expression LeadingWhiteSpace()
        {
            return Anchors.StartOfLine().WhiteSpaceExceptNewLine().OneMany();
        }

        public static QuantifiableExpression TrailingWhiteSpace()
        {
            return Characters.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn();
        }

        public static QuantifiableExpression LeadingTrailingWhiteSpace()
        {
            return Alternations.Any(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        public static QuantifiableExpression WhiteSpaceLines()
        {
            return Miscellaneous.Options(InlineOptions.Multiline).Any(
                Anchors.StartOfLine().WhiteSpace().MaybeMany().NewLine(),
                NewLine().WhiteSpace().MaybeMany().End());
        }

        public static QuantifiableExpression EmptyLines()
        {
            return Miscellaneous.Options(InlineOptions.Multiline).Any(
                Anchors.StartOfLine().NewLine(),
                NewLine().OneMany().End());
        }

        public static QuantifiableExpression FirstLine()
        {
            return Miscellaneous.Options(InlineOptions.Multiline).Start().Any().MaybeMany().Lazy().EndOfLineOrBeforeCarriageReturn();
        }

        public static QuantifiableExpression NewLine()
        {
            return Characters.CarriageReturn().Maybe().Linefeed().AsNoncapturing();
        }

        public static QuantifiableExpression LinefeedWithoutCarriageReturn()
        {
            return Characters.CarriageReturn().AsNotLookbehind().Linefeed().AsNonbacktracking();
        }

        internal static QuantifiableExpression InsignificantSeparator()
        {
            return Groups.GroupOptions(InlineOptions.IgnorePatternWhitespace, new TextExpression(" ", false));
        }
    }
}
