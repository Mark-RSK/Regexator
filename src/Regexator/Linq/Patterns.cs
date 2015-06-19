// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Patterns
    {
        public static QuantifiablePattern Any(IEnumerable<object> values)
        {
            return new AnyGroup(values);
        }

        public static QuantifiablePattern Any(params object[] content)
        {
            return new AnyGroup(content);
        }

        public static QuantifiablePattern IfGroup(string groupName, object trueContent)
        {
            return new IfGroup(groupName, trueContent);
        }

        public static QuantifiablePattern IfGroup(string groupName, object trueContent, object falseContent)
        {
            return new IfGroup(groupName, trueContent, falseContent);
        }

        public static QuantifiablePattern IfGroup(int groupNumber, object trueContent)
        {
            return new IfGroup(groupNumber, trueContent);
        }

        public static QuantifiablePattern IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            return new IfGroup(groupNumber, trueContent, falseContent);
        }

        public static QuantifiablePattern If(Pattern testContent, object trueContent)
        {
            return new IfPattern(testContent, trueContent);
        }

        public static QuantifiablePattern If(Pattern testContent, object trueContent, object falseContent)
        {
            return new IfPattern(testContent, trueContent, falseContent);
        }

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

        public static Pattern ApplyOptions(InlineOptions options)
        {
            return Options(options, InlineOptions.None);
        }

        public static QuantifiablePattern ApplyOptions(InlineOptions options, object content)
        {
            return Options(options, InlineOptions.None, content);
        }

        public static QuantifiablePattern ApplyOptions(InlineOptions options, params object[] content)
        {
            return Options(options, InlineOptions.None, content);
        }

        public static Pattern DisableOptions(InlineOptions options)
        {
            return Options(InlineOptions.None, options);
        }

        public static QuantifiablePattern DisableOptions(InlineOptions options, object content)
        {
            return Options(InlineOptions.None, options, content);
        }

        public static QuantifiablePattern DisableOptions(InlineOptions options, params object[] content)
        {
            return Options(InlineOptions.None, options, content);
        }

        public static Pattern Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return new InlineOptionsPattern(applyOptions, disableOptions);
        }

        public static QuantifiablePattern Options(InlineOptions applyOptions, InlineOptions disableOptions, params object[] content)
        {
            return Options(applyOptions, disableOptions, (object)content);
        }

        public static QuantifiablePattern Options(InlineOptions applyOptions, InlineOptions disableOptions, object content)
        {
            return new GroupOptions(applyOptions, disableOptions, content);
        }

        public static Pattern Comment(string value)
        {
            return new InlineComment(value);
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
            return Patterns.Any(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        public static QuantifiablePattern WhiteSpaceLines()
        {
            return Patterns.Any(
                Anchors.StartOfLineInvariant().WhiteSpace().MaybeMany().NewLine(),
                Patterns.NewLine().WhiteSpace().MaybeMany().End());
        }

        public static QuantifiablePattern EmptyLines()
        {
            return Patterns.Any(
                Anchors.StartOfLineInvariant().NewLine(),
                Patterns.NewLine().OneMany().End());
        }

        public static Pattern FirstLine()
        {
            return Anchors
                .Start()
                .NotNewLineChar().MaybeMany();
        }

        internal static Pattern ValidGroupName()
        {
            return Patterns.Any(
                Chars.Range('1', '9').ArabicDigit().MaybeMany().AsGroup(),
                Chars.WordChar().Except(Chars.ArabicDigit()).WordChar().MaybeMany()
            ).AsEntireInput();
        }

        internal static Pattern TrimInlineComment()
        {
            return Anchors.Start().WhileNot(')');
        }
    }
}
