// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Provides static methods that returns various kinds of patterns.
    /// </summary>
    public static class Snippets
    {
        /// <summary>
        /// Returns a pattern that matches a linefeed that is not preceded with a carriage return.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern LinefeedWithoutCarriageReturn()
        {
            return Patterns.NotAssertBack(Patterns.CarriageReturn()).Linefeed().AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches leading whitespace of the string (or line if the multiline option is applied).
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern LeadingWhiteSpace()
        {
            return Patterns.BeginLine().WhiteSpaceExceptNewLine().OneMany().AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches trailing whitespace of the string (or line if the multiline option is applied). A carriage return is not included in the match.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern TrailingWhiteSpace()
        {
            return Patterns.WhiteSpaceExceptNewLine().OneMany().EndLine(true).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches leading and trailing whitespace of the string (or line if the multiline option is applied). A carriage return is not included in the match.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern LeadingTrailingWhiteSpace()
        {
            return Patterns.Any(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        /// <summary>
        /// Returns a pattern that matches a line that is empty or contains only whitespace(s).
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern WhiteSpaceLine()
        {
            return Patterns.BeginLineInvariant().WhiteSpaceExceptNewLine().MaybeMany().NewLine() |
                Patterns.NewLine().Assert(Patterns.WhiteSpace().MaybeMany().EndInput());
        }

        /// <summary>
        /// Returns a pattern that matches an empty line. Empty line is a line that has zero width.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EmptyLine()
        {
            return Patterns.BeginLineInvariant().NewLine() |
                Patterns.NewLine().Assert(Patterns.NewLine().MaybeMany().EndInput());
        }

        /// <summary>
        /// Returns a pattern that matches first line of the string. Neither carriage return nor linefeed is included in the match.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern FirstLine()
        {
            return Patterns.BeginInput().NotNewLineChar().MaybeMany().AsNoncapturingGroup();
        }

#if DEBUG
        /// <summary>
        /// Returns a pattern that matches a content that is enclosed in quotation marks. The content can contains escaped characters.
        /// </summary>
        /// <param name="contentGroupName">A name of the group that contain quoted content.</param>
        /// <returns></returns>
        public static Pattern QuotedContentWithEscapes(string contentGroupName)
        {
            var quotedChars = Patterns.MaybeMany(!CharGroupings.QuoteMark().Backslash());

            return Patterns.QuoteMarks(
                Patterns.NamedGroup(contentGroupName,
                    quotedChars + Patterns.MaybeMany(Patterns.Backslash().AnyInvariant() + quotedChars))).AsNoncapturingGroup();
        }
#endif

        internal static Pattern ValidGroupName()
        {
            return Patterns.EntireInput(
                Patterns.Group(Patterns.Range('1', '9').ArabicDigit().MaybeMany()) |
                Patterns.WordChar().Except(Patterns.ArabicDigit()).WordChar().MaybeMany());
        }
    }
}
