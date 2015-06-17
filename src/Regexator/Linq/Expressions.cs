// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Expressions
    {
        public static QuantifiableExpression Any(IEnumerable<object> values)
        {
            return new AnyExpression(values);
        }

        public static QuantifiableExpression Any(params object[] content)
        {
            return new AnyExpression(content);
        }

        public static QuantifiableExpression IfGroup(string groupName, object trueContent)
        {
            return new GroupNameIfExpression(groupName, trueContent);
        }

        public static QuantifiableExpression IfGroup(string groupName, object trueContent, object falseContent)
        {
            return new GroupNameIfExpression(groupName, trueContent, falseContent);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, object trueContent)
        {
            return new GroupNumberIfExpression(groupNumber, trueContent);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            return new GroupNumberIfExpression(groupNumber, trueContent, falseContent);
        }

        public static QuantifiableExpression If(Expression testContent, object trueContent)
        {
            return new IfExpression(testContent, trueContent);
        }

        public static QuantifiableExpression If(Expression testContent, object trueContent, object falseContent)
        {
            return new IfExpression(testContent, trueContent, falseContent);
        }

        internal static QuantifiableExpression Or(object left, object right)
        {
            return new OrContainerExpression(left, right);
        }

        public static Expression Crawl()
        {
            return Chars.Any().MaybeMany().Lazy();
        }

        public static Expression CrawlInvariant()
        {
            return Chars.AnyInvariant().MaybeMany().Lazy();
        }

        public static QuantifiableExpression GroupReference(int groupNumber)
        {
            return new NumberedGroupReferenceExpression(groupNumber);
        }

        public static QuantifiableExpression GroupReference(string groupName)
        {
            return new NamedGroupReferenceExpression(groupName);
        }

        public static Expression ApplyOptions(InlineOptions options)
        {
            return Options(options, InlineOptions.None);
        }

        public static QuantifiableExpression ApplyOptions(InlineOptions options, object content)
        {
            return Options(options, InlineOptions.None, content);
        }

        public static QuantifiableExpression ApplyOptions(InlineOptions options, params object[] content)
        {
            return Options(options, InlineOptions.None, content);
        }

        public static Expression DisableOptions(InlineOptions options)
        {
            return Options(InlineOptions.None, options);
        }

        public static QuantifiableExpression DisableOptions(InlineOptions options, object content)
        {
            return Options(InlineOptions.None, options, content);
        }

        public static QuantifiableExpression DisableOptions(InlineOptions options, params object[] content)
        {
            return Options(InlineOptions.None, options, content);
        }

        public static Expression Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return new InlineOptionsExpression(applyOptions, disableOptions);
        }

        public static QuantifiableExpression Options(InlineOptions applyOptions, InlineOptions disableOptions, params object[] content)
        {
            return Options(applyOptions, disableOptions, (object)content);
        }

        public static QuantifiableExpression Options(InlineOptions applyOptions, InlineOptions disableOptions, object content)
        {
            return new GroupOptionsExpression(applyOptions, disableOptions, content);
        }

        public static Expression Comment(string value)
        {
            return new InlineCommentExpression(value);
        }

        public static QuantifiableExpression Never()
        {
            return Anchors.NotAssert(string.Empty);
        }

        public static QuantifiableExpression NewLine()
        {
            return Chars.CarriageReturn().Maybe().Linefeed().AsNoncapturing();
        }

        public static QuantifiableExpression LinefeedWithoutCarriageReturn()
        {
            return Anchors.NotAssertBack(Chars.CarriageReturn()).Linefeed().AsNonbacktracking();
        }
    }
}
