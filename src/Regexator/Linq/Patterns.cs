// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Patterns
    {
        internal static QuantifiablePattern Or(object left, object right)
        {
            return new OrContainer(left, right);
        }

        public static Pattern Crawl()
        {
            return Chars.Any().MaybeMany().Lazy();
        }

        public static Pattern CrawlInvariant()
        {
            return Chars.AnyInvariant().MaybeMany().Lazy();
        }

        public static QuantifiablePattern Never()
        {
            return Anchors.NotAssert(string.Empty);
        }

        public static QuantifiablePattern NewLine()
        {
            return Chars.CarriageReturn().Maybe().Linefeed().AsNoncapturing();
        }

        public static QuantifiablePattern LinefeedWithoutCarriageReturn()
        {
            return Anchors.NotAssertBack(Chars.CarriageReturn()).Linefeed().AsNonbacktracking();
        }

        public static Pattern LeadingWhiteSpace()
        {
            return Anchors.StartOfLine().WhiteSpaceExceptNewLine().OneMany();
        }

        public static QuantifiablePattern TrailingWhiteSpace()
        {
            return Chars.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn();
        }

        public static QuantifiablePattern LeadingTrailingWhiteSpace()
        {
            return new AnyGroup(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        public static QuantifiablePattern WhiteSpaceLines()
        {
            return new AnyGroup(
                Anchors.StartOfLineInvariant().WhiteSpace().MaybeMany().NewLine(),
                Patterns.NewLine().WhiteSpace().MaybeMany().EndOfInput());
        }

        public static QuantifiablePattern EmptyLines()
        {
            return new AnyGroup(
                Anchors.StartOfLineInvariant().NewLine(),
                Patterns.NewLine().OneMany().EndOfInput());
        }

        public static Pattern FirstLine()
        {
            return Anchors
                .StartOfInput()
                .NotNewLineChar().MaybeMany();
        }

        internal static Pattern ValidGroupName()
        {
            return new AnyGroup(
                Chars.Range('1', '9').ArabicDigit().MaybeMany().AsGroup(),
                Chars.WordChar().Except(Chars.ArabicDigit()).WordChar().MaybeMany()
            ).AsEntireInput();
        }

        internal static Pattern TrimInlineComment()
        {
            return Anchors.StartOfInput().WhileNot(')');
        }
    }
}
