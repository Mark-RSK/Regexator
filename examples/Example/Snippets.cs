// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Snippets
    {
        public static QuantifiablePattern LinefeedWithoutCarriageReturn()
        {
            return Patterns.NotAssertBack(Patterns.CarriageReturn()).Linefeed().AsNoncapturingGroup();
        }

        public static QuantifiablePattern LeadingWhiteSpace()
        {
            return Patterns.StartOfLine().WhiteSpaceExceptNewLine().OneMany().AsNoncapturingGroup();
        }

        public static QuantifiablePattern TrailingWhiteSpace()
        {
            return Patterns.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn().AsNoncapturingGroup();
        }

        public static QuantifiablePattern LeadingTrailingWhiteSpace()
        {
            return Patterns.Any(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        public static QuantifiablePattern WhiteSpaceLine()
        {
            return Patterns.StartOfLineInvariant().WhiteSpaceExceptNewLine().MaybeMany().NewLine() |
                Patterns.NewLine().Assert(Patterns.WhiteSpace().MaybeMany().EndOfInput());
        }

        public static QuantifiablePattern EmptyLine()
        {
            return Patterns.StartOfLineInvariant().NewLine() |
                Patterns.NewLine().Assert(Patterns.NewLine().MaybeMany().EndOfInput());
        }

        public static QuantifiablePattern FirstLine()
        {
            return Patterns.StartOfInput().NotNewLineChar().MaybeMany().AsNoncapturingGroup();
        }
    }
}
