// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Expressions
    {
        public static QuantifiableExpression Apostrophes(object content)
        {
            return Surround(content, AsciiChar.Apostrophe).AsNoncapturing();
        }

        public static QuantifiableExpression QuoteMarks(object content)
        {
            return Surround(content, AsciiChar.QuoteMark).AsNoncapturing();
        }

        public static QuantifiableExpression Parentheses(object content)
        {
            return Surround(content, AsciiChar.LeftParenthesis, AsciiChar.RightParenthesis).AsNoncapturing();
        }

        public static QuantifiableExpression CurlyBrackets(object content)
        {
            return Surround(content, AsciiChar.LeftCurlyBracket, AsciiChar.RightCurlyBracket).AsNoncapturing();
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

        public static Expression Options(InlineOptions applyOptions)
        {
            return new InlineOptionsExpression(applyOptions);
        }

        public static Expression Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return new InlineOptionsExpression(applyOptions, disableOptions);
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
