// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Expressions
    {
        public static Expression Concat(params object[] values)
        {
            return Concat(values.AsEnumerable());
        }

        public static Expression Concat(IEnumerable<object> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            return Expression.Empty.Concat(values);
        }

        public static Expression Join(object joinValue, params object[] values)
        {
            return Join(joinValue, values.AsEnumerable());
        }

        public static Expression Join(object joinValue, IEnumerable<object> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            if (joinValue == null)
            {
                joinValue = Expression.Empty;
            }

            using (IEnumerator<object> en = values.GetEnumerator())
            {
                if (!en.MoveNext())
                {
                    return Expression.Empty;
                }

                Expression exp = Expression.Empty;

                if (en.Current != null)
                {
                    exp = exp.Concat(en.Current);
                }

                while (en.MoveNext())
                {
                    exp = exp.Concat(joinValue);

                    if (en.Current != null)
                    {
                        exp = exp.Concat(en.Current);
                    }
                }

                return exp;
            }
        }

        public static QuantifiableExpression Apostrophes(Expression expression)
        {
            return Surround(expression, AsciiChar.Apostrophe).AsNoncapturing();
        }

        public static QuantifiableExpression Apostrophes(string text)
        {
            return Surround(text, AsciiChar.Apostrophe).AsNoncapturing();
        }

        public static QuantifiableExpression QuoteMarks(Expression expression)
        {
            return Surround(expression, AsciiChar.QuoteMark).AsNoncapturing();
        }

        public static QuantifiableExpression QuoteMarks(string text)
        {
            return Surround(text, AsciiChar.QuoteMark).AsNoncapturing();
        }

        public static QuantifiableExpression Parentheses(Expression expression)
        {
            return Surround(expression, AsciiChar.LeftParenthesis, AsciiChar.RightParenthesis).AsNoncapturing();
        }

        public static QuantifiableExpression Parentheses(string text)
        {
            return Surround(text, AsciiChar.LeftParenthesis, AsciiChar.RightParenthesis).AsNoncapturing();
        }

        public static QuantifiableExpression CurlyBrackets(Expression expression)
        {
            return Surround(expression, AsciiChar.LeftCurlyBracket, AsciiChar.RightCurlyBracket).AsNoncapturing();
        }

        public static QuantifiableExpression CurlyBrackets(string text)
        {
            return Surround(text, AsciiChar.LeftCurlyBracket, AsciiChar.RightCurlyBracket).AsNoncapturing();
        }

        public static QuantifiableExpression SquareBrackets(Expression expression)
        {
            return Surround(expression, AsciiChar.LeftSquareBracket, AsciiChar.RightSquareBracket).AsNoncapturing();
        }

        public static QuantifiableExpression SquareBrackets(string text)
        {
            return Surround(text, AsciiChar.LeftSquareBracket, AsciiChar.RightSquareBracket).AsNoncapturing();
        }

        public static QuantifiableExpression LessThanGreaterThan(Expression expression)
        {
            return Surround(expression, AsciiChar.LessThan, AsciiChar.GreaterThan).AsNoncapturing();
        }

        public static QuantifiableExpression LessThanGreaterThan(string text)
        {
            return Surround(text, AsciiChar.LessThan, AsciiChar.GreaterThan).AsNoncapturing();
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

        public static Expression Text(string value)
        {
            return new TextExpression(value);
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

        public static Expression LeadingWhiteSpace()
        {
            return Anchors.StartOfLine().WhiteSpaceExceptNewLine().OneMany();
        }

        public static QuantifiableExpression TrailingWhiteSpace()
        {
            return Chars.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn();
        }

        public static QuantifiableExpression LeadingTrailingWhiteSpace()
        {
            return Alternations.Any(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        public static QuantifiableExpression WhiteSpaceLines()
        {
            return Alternations.Any(Anchors
                    .StartOfLine().WhiteSpace().MaybeMany().NewLine(),
                    NewLine().WhiteSpace().MaybeMany().End())
                .WithOptions(InlineOptions.Multiline);
        }

        public static QuantifiableExpression EmptyLines()
        {
            return Alternations.Any(Anchors
                    .StartOfLine().NewLine(),
                    NewLine().OneMany().End())
                .WithOptions(InlineOptions.Multiline);
        }

        public static QuantifiableExpression FirstLine()
        {
            return Anchors
                .Start()
                .NotNewLineChar().MaybeMany()
                .EndOfLineOrBeforeCarriageReturnInvariant();
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
