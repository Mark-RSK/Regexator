// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

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
            return Patterns
                .NotAssertBack(Patterns.CarriageReturn())
                .Linefeed()
                .AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches leading whitespace of the string (or line if the multiline option is applied).
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern LeadingWhiteSpace()
        {
            return Patterns
                .BeginLine()
                .WhiteSpaceExceptNewLine().OneMany()
                .AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches trailing whitespace of the string (or line if the multiline option is applied). A carriage return is not included in the match.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern TrailingWhiteSpace()
        {
            return Patterns
                .WhiteSpaceExceptNewLine().OneMany()
                .EndLine(true)
                .AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches leading and trailing whitespace of the string (or line if the multiline option is applied). A carriage return is not included in the match.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern LeadingTrailingWhiteSpace()
        {
            return LeadingWhiteSpace() | TrailingWhiteSpace();
        }

        /// <summary>
        /// Returns a pattern that matches a line that is empty or contains only whitespace(s). Neither carriage return nor linefeed is included in the match.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EmptyOrWhiteSpaceLine()
        {
            return EmptyOrWhiteSpaceLine(false);
        }

        /// <summary>
        /// Returns a pattern that matches a line that is empty or contains only whitespace(s), optionally including new line characters.
        /// </summary>
        /// <param name="includeNewLine">Indicates whether new line characters should be included in the match.</param>
        /// <returns></returns>
        public static QuantifiablePattern EmptyOrWhiteSpaceLine(bool includeNewLine)
        {
            if (includeNewLine)
            {
                return Patterns
                    .BeginLineInvariant()
                    .WhiteSpaceExceptNewLine().MaybeMany()
                    .NewLine();
            }
            else
            {
                return Patterns
                    .BeginLineInvariant()
                    .WhiteSpaceExceptNewLine().MaybeMany()
                    .Assert(Patterns.NewLine());
            }
        }

        /// <summary>
        /// Returns a pattern that matches an empty line. Neither carriage return nor linefeed is included in the match.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EmptyLine()
        {
            return EmptyLine(false);
        }

        /// <summary>
        /// Returns a pattern that matches an empty line. Neither carriage return nor linefeed is included in the match, optionally including new line characters.
        /// </summary>
        /// <param name="includeNewLine">Indicates whether new line characters should be included in the match.</param>
        /// <returns></returns>
        public static QuantifiablePattern EmptyLine(bool includeNewLine)
        {
            if (includeNewLine)
            {
                return Patterns
                    .BeginLineInvariant()
                    .NewLine();
            }
            else
            {
                return Patterns
                    .BeginLineInvariant()
                    .Assert(Patterns.NewLine());
            }
        }

        /// <summary>
        /// Returns a pattern that matches a line that contains at least one non-whitespace character. New line characters are not included in the match.
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NonWhite")]
        public static QuantifiablePattern NonWhiteSpaceLine()
        {
            return NonWhiteSpaceLine(false);
        }

        /// <summary>
        /// Returns a pattern that matches a line that contains at least one non-whitespace character, optionally including new line characters.
        /// </summary>
        /// <param name="includeNewLine">Indicates whether new line characters should be included in the match.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NonWhite")]
        public static QuantifiablePattern NonWhiteSpaceLine(bool includeNewLine)
        {
            return Patterns
                .BeginLineInvariant()
                .NotNewLineChar().MaybeMany().Lazy()
                .NotWhiteSpace()
                .NotNewLineChar().MaybeMany()
                .ConcatIf(includeNewLine, Patterns.NewLine().Maybe())
                .AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches a line that contains at least one character.  New line characters are not included in the match.
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NonEmpty")]
        public static QuantifiablePattern NonEmptyLine()
        {
            return NonEmptyLine(false);
        }

        /// <summary>
        /// Returns a pattern that matches a line that contains at least one character, optionally including new line characters.
        /// </summary>
        /// <param name="includeNewLine">Indicates whether new line characters should be included in the match.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NonEmpty")]
        public static QuantifiablePattern NonEmptyLine(bool includeNewLine)
        {
            return Patterns
                .BeginLineInvariant()
                .NotNewLineChar().OneMany()
                .ConcatIf(includeNewLine, Patterns.NewLine().Maybe())
                .AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches first line of the string. Neither carriage return nor linefeed is included in the match.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern FirstLine()
        {
            return Patterns
                .BeginInput()
                .NotNewLineChar().MaybeMany()
                .AsNoncapturingGroup();
        }

#if DEBUG
        /// <summary>
        /// Returns a pattern that matches a content that is enclosed in quotation marks. The content can contains escaped characters.
        /// </summary>
        /// <returns></returns>
        public static Pattern SurroundQuotesWithEscapes()
        {
            return SurroundQuotesWithEscapes(null);
        }

        /// <summary>
        /// Returns a pattern that matches a content that is enclosed in quotation marks. The content can contains escaped characters.
        /// </summary>
        /// <param name="contentGroupName">A name of the group that contain quoted content. Specify <c>null</c> to omit group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Pattern SurroundQuotesWithEscapes(string contentGroupName)
        {
            var chars = Patterns.MaybeMany(!CharGroupings.QuoteMark().Backslash());

            var content = chars + Patterns.MaybeMany(Patterns.Backslash().AnyInvariant() + chars);

            var pattern = (contentGroupName != null)
                ? Patterns.NamedGroup(contentGroupName, content)
                : content;

            return Patterns.SurroundQuoteMarks(pattern).AsNoncapturingGroup();
        }

        internal static Pattern Balance(char openChar, char closeChar, string openGroupName, string closeGroupName)
        {
            return Patterns
                .OneMany(Patterns
                    .NamedGroup(openGroupName, openChar)
                    .WhileNotChar(openChar, closeChar))
                .OneMany(Patterns
                    .BalancingGroup(closeGroupName, openGroupName, closeChar)
                    .WhileNotChar(openChar, closeChar));
        }

#endif

        internal static Pattern ValidGroupName()
        {
            return Patterns.EntireInput(
                Patterns.Group(Patterns.Range('1', '9').ArabicDigit().MaybeMany()),
                Patterns.WordChar().Except(Patterns.ArabicDigit()).WordChar().MaybeMany());
        }
    }
}
