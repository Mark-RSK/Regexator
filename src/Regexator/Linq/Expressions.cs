// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Expressions
    {
#if DEBUG
        public static Expression GoTo(char value)
        {
            return Chars.NotChar(value).MaybeMany().Char(value);
        }

        public static Expression GoTo(int charCode)
        {
            return Chars.NotChar(charCode).MaybeMany().Char(charCode);
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

        public static QuantifiableExpression Apostrophes(object content)
        {
            return Surround(content, AsciiChar.Apostrophe).AsNoncapturing();
        }

        public static QuantifiableExpression QuoteMarks(object content)
        {
            return Surround(content, AsciiChar.QuoteMark).AsNoncapturing();
        }

        public static Expression Parentheses()
        {
            return Chars.LeftParenthesis().RightParenthesis();
        }

        public static QuantifiableExpression Parentheses(object content)
        {
            return Surround(content, AsciiChar.LeftParenthesis, AsciiChar.RightParenthesis).AsNoncapturing();
        }

        public static Expression CurlyBrackets()
        {
            return Chars.LeftCurlyBracket().RightCurlyBracket();
        }

        public static QuantifiableExpression CurlyBrackets(object content)
        {
            return Surround(content, AsciiChar.LeftCurlyBracket, AsciiChar.RightCurlyBracket).AsNoncapturing();
        }

        public static Expression SquareBrackets()
        {
            return Chars.LeftSquareBracket().RightSquareBracket();
        }

        public static QuantifiableExpression SquareBrackets(object content)
        {
            return Surround(content, AsciiChar.LeftSquareBracket, AsciiChar.RightSquareBracket).AsNoncapturing();
        }

        public static QuantifiableExpression LessThanGreaterThan(object content)
        {
            return Surround(content, AsciiChar.LessThan, AsciiChar.GreaterThan).AsNoncapturing();
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

        internal static Expression Surround(object value, object surroundValue)
        {
            return new SurroundExpression(value, surroundValue, surroundValue);
        }

        internal static Expression Surround(object value, object valueBefore, object valueAfter)
        {
            return new SurroundExpression(value, valueBefore, valueAfter);
        }

        internal static Expression Surround(object value, AsciiChar surroundChar)
        {
            return new AsciiCharSurroundExpression(value, surroundChar);
        }

        internal static Expression Surround(object value, AsciiChar charBefore, AsciiChar charAfter)
        {
            return new AsciiCharSurroundExpression(value, charBefore, charAfter);
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
