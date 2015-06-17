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

#if DEBUG
        public static Expression GoTo(char value)
        {
            return Chars.NotChar(value).MaybeMany().Char(value);
        }

        public static Expression GoTo(AsciiChar value)
        {
            return Chars.NotChar(value).MaybeMany().Char(value);
        }
#endif

        public static Expression Crawl()
        {
            return Chars.Any().MaybeMany().Lazy();
        }

        public static Expression CrawlInvariant()
        {
            return Chars.AnyInvariant().MaybeMany().Lazy();
        }

        public static Expression Apostrophes(object content)
        {
            return Surround(content, AsciiChar.Apostrophe);
        }

        public static Expression QuoteMarks(object content)
        {
            return Surround(content, AsciiChar.QuoteMark);
        }

        public static Expression Parentheses()
        {
            return Chars.LeftParenthesis().RightParenthesis();
        }

        public static Expression Parentheses(object content)
        {
            return Surround(AsciiChar.LeftParenthesis, content, AsciiChar.RightParenthesis);
        }

        public static Expression CurlyBrackets()
        {
            return Chars.LeftCurlyBracket().RightCurlyBracket();
        }

        public static Expression CurlyBrackets(object content)
        {
            return Surround(AsciiChar.LeftCurlyBracket, content, AsciiChar.RightCurlyBracket);
        }

        public static Expression SquareBrackets()
        {
            return Chars.LeftSquareBracket().RightSquareBracket();
        }

        public static Expression SquareBrackets(object content)
        {
            return Surround(AsciiChar.LeftSquareBracket, content, AsciiChar.RightSquareBracket);
        }

        public static Expression LessThanGreaterThan(object content)
        {
            return Surround(AsciiChar.LessThan, content, AsciiChar.GreaterThan);
        }

        public static QuantifiableExpression Backreference(int groupNumber)
        {
            return new NumberBackreferenceExpression(groupNumber);
        }

        public static QuantifiableExpression Backreference(string groupName)
        {
            return new NameBackreferenceExpression(groupName);
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

        internal static Expression Surround(object value, AsciiChar surroundChar)
        {
            return new AsciiCharSurroundExpression(value, surroundChar);
        }

        internal static Expression Surround(AsciiChar charBefore, object value, AsciiChar charAfter)
        {
            return new AsciiCharSurroundExpression(charBefore, value, charAfter);
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
