﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using static Pihrtsoft.Text.RegularExpressions.Linq.Patterns;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Snippets
    {
        /// <summary>
        /// Returns a pattern that matches a linefeed that is not preceded with a carriage return.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern LinefeedWithoutCarriageReturn()
        {
            return NoncapturingGroup(
                NotAssertBack(CarriageReturn()).Linefeed());
        }

        /// <summary>
        /// Returns a pattern that matches leading whitespace of the string (or line if the <see cref="RegexOptions.Multiline"/> option is applied).
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern LeadingWhiteSpace()
        {
            return NoncapturingGroup(
                BeginInputOrLine().WhiteSpaceExceptNewLine().OneMany());
        }

        /// <summary>
        /// Returns a pattern that matches trailing whitespace of the string (or line if the <see cref="RegexOptions.Multiline"/> option is applied). A carriage return is not included in the match.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern TrailingWhiteSpace()
        {
            return NoncapturingGroup(
                WhiteSpaceExceptNewLine().OneMany()
                .EndInputOrLine(true));
        }

        /// <summary>
        /// Returns a pattern that matches leading and trailing whitespace of the string (or line if the <see cref="RegexOptions.Multiline"/> option is applied). A carriage return is not included in the match.
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
                return BeginLine()
                    .WhileWhiteSpaceExceptNewLine()
                    .Any(NewLine() | EndInput());
            }
            else
            {
                return BeginLine()
                    .WhileWhiteSpaceExceptNewLine()
                    .Assert(NewLine() | EndInput());
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
        /// Returns a pattern that matches an empty line, optionally including new line characters.
        /// Empty line is defined as a start of line
        /// </summary>
        /// <param name="includeNewLine">Indicates whether new line characters should be included in the match.</param>
        /// <returns></returns>
        public static QuantifiablePattern EmptyLine(bool includeNewLine)
        {
            if (includeNewLine)
            {
                return BeginLine().NewLine();
            }
            else
            {
                return BeginLine().Assert(NewLine());
            }
        }

        /// <summary>
        /// Returns a pattern that matches a line that contains at least one non-whitespace character. New line characters are not included in the match.
        /// </summary>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NonWhite")]
        public static QuantifiablePattern NonEmptyOrWhiteSpaceLine()
        {
            return NonEmptyOrWhiteSpaceLine(false);
        }

        /// <summary>
        /// Returns a pattern that matches a line that contains at least one non-whitespace character, optionally including new line characters.
        /// </summary>
        /// <param name="includeNewLine">Indicates whether new line characters should be included in the match.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "NonWhite")]
        public static QuantifiablePattern NonEmptyOrWhiteSpaceLine(bool includeNewLine)
        {
            return NoncapturingGroup(
                BeginLine()
                    .WhileNotNewLineChar().Lazy()
                    .NotWhiteSpace()
                    .WhileNotNewLineChar()
                    .AppendIf(includeNewLine, NewLine().Maybe()));
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
            return NoncapturingGroup(
                BeginLine()
                .NotNewLineChar().OneMany()
                .AppendIf(includeNewLine, NewLine().Maybe()));
        }

        /// <summary>
        /// Returns a pattern that matches first line of the string. Neither carriage return nor linefeed is included in the match.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern FirstLineWithoutNewLine()
        {
            return NoncapturingGroup(
                BeginInput().WhileNotNewLineChar());
        }

        /// <summary>
        /// Returns a pattern that matches a content that is enclosed in quotation marks. The content can contains escaped characters.
        /// </summary>
        /// <returns></returns>
        public static Pattern SurroundQuoteMarksWithEscapes()
        {
            return SurroundQuoteMarksWithEscapes(null);
        }

        /// <summary>
        /// Returns a pattern that matches a content that is enclosed in quotation marks. The content can contains escaped characters.
        /// </summary>
        /// <param name="contentGroupName">A name of the group that contain quoted content. Specify <c>null</c> to omit group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Pattern SurroundQuoteMarksWithEscapes(string contentGroupName)
        {
            var chars = MaybeMany(!Chars.QuoteMark().Backslash());

            var content = chars + MaybeMany(Backslash().Any() + chars);

            var pattern = (contentGroupName != null)
                ? NamedGroup(contentGroupName, content)
                : content;

            return NoncapturingGroup(SurroundQuoteMarks(pattern));
        }

        public static Pattern CSharpQuotation()
        {
            return IfAssert("@",
                CSharpVerbatimQuotation(),
                CSharpQuotationMarksWithEscapes());
        }

        public static Pattern CSharpQuotationMarksWithEscapes()
        {
            var chars = MaybeMany(!Chars.QuoteMark().Backslash().NewLineChar());

            return SurroundQuoteMarks(chars + MaybeMany(Backslash().NotNewLineChar() + chars));
        }

        public static Pattern CSharpVerbatimQuotation()
        {
            var q = QuoteMark();
            var nq = NotQuoteMark();

            return "@" + q
                + MaybeMany(nq)
                + MaybeMany(q + q + nq)
                + q;
        }
    }
}
