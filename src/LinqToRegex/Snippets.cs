// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal static class Snippets
    {
        public static QuantifiablePattern LinefeedWithoutCarriageReturn()
        {
            return Patterns.NotAssertBack(Patterns.CarriageReturn()).Linefeed().AsNoncapturingGroup();
        }

        public static QuantifiablePattern LeadingWhiteSpace()
        {
            return Patterns.BeginLine().WhiteSpaceExceptNewLine().OneMany().AsNoncapturingGroup();
        }

        public static QuantifiablePattern TrailingWhiteSpace()
        {
            return Patterns.WhiteSpaceExceptNewLine().OneMany().EndLine(true).AsNoncapturingGroup();
        }

        public static QuantifiablePattern LeadingTrailingWhiteSpace()
        {
            return Patterns.Any(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        public static QuantifiablePattern WhiteSpaceLine()
        {
            return Patterns.BeginLineInvariant().WhiteSpaceExceptNewLine().MaybeMany().NewLine() |
                Patterns.NewLine().Assert(Patterns.WhiteSpace().MaybeMany().EndInput());
        }

        public static QuantifiablePattern EmptyLine()
        {
            return Patterns.BeginLineInvariant().NewLine() |
                Patterns.NewLine().Assert(Patterns.NewLine().MaybeMany().EndInput());
        }

        public static QuantifiablePattern FirstLine()
        {
            return Patterns.BeginInput().NotNewLineChar().MaybeMany().AsNoncapturingGroup();
        }

        public static Pattern QuotedContentWithEscapes(string contentGroupName)
        {
            var quotedChars = Patterns.MaybeMany(!CharGroupings.QuoteMark().Backslash());

            return Patterns.QuoteMarks(
                Patterns.NamedGroup(contentGroupName,
                    quotedChars + Patterns.MaybeMany(Patterns.Backslash().AnyInvariant() + quotedChars))).AsNoncapturingGroup();
        }
    }
}
