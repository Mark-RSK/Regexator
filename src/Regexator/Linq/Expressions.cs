// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Expressions
    {
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
            return Surround(expression, Chars.LeftParenthesis(), Chars.RightParenthesis()).AsNoncapturing();
        }

        public static QuantifiableExpression Parentheses(string text)
        {
            return Surround(text, Chars.LeftParenthesis(), Chars.RightParenthesis()).AsNoncapturing();
        }

        public static QuantifiableExpression CurlyBrackets(Expression expression)
        {
            return Surround(expression, Chars.LeftCurlyBracket(), Chars.RightCurlyBracket()).AsNoncapturing();
        }

        public static QuantifiableExpression CurlyBrackets(string text)
        {
            return Surround(text, Chars.LeftCurlyBracket(), Chars.RightCurlyBracket()).AsNoncapturing();
        }

        public static QuantifiableExpression SquareBrackets(Expression expression)
        {
            return Surround(expression, Chars.LeftSquareBracket(), Chars.RightSquareBracket()).AsNoncapturing();
        }

        public static QuantifiableExpression SquareBrackets(string text)
        {
            return Surround(text, Chars.LeftSquareBracket(), Chars.RightSquareBracket()).AsNoncapturing();
        }

        public static QuantifiableExpression LessThanGreaterThan(Expression expression)
        {
            return Surround(expression, Chars.LessThan(), Chars.GreaterThan()).AsNoncapturing();
        }

        public static QuantifiableExpression LessThanGreaterThan(string text)
        {
            return Surround(text, Chars.LessThan(), Chars.GreaterThan()).AsNoncapturing();
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

        internal static Expression Surround(string text, Expression surroundExpression)
        {
            return new SurroundExpression(text, surroundExpression, surroundExpression);
        }

        internal static Expression Surround(string text, AsciiChar surroundChar)
        {
            return new AsciiCharSurroundExpression(text, surroundChar);
        }

        internal static Expression Surround(Expression expression, Expression surroundExpression)
        {
            return new SurroundExpression(expression, surroundExpression, surroundExpression);
        }

        internal static Expression Surround(Expression expression, AsciiChar surroundChar)
        {
            return new AsciiCharSurroundExpression(expression, surroundChar);
        }

        internal static Expression Surround(Expression expression, Expression beforeExpression, Expression afterExpression)
        {
            return new SurroundExpression(expression, beforeExpression, afterExpression);
        }

        internal static Expression Surround(string text, Expression beforeExpression, Expression afterExpression)
        {
            return new SurroundExpression(text, beforeExpression, afterExpression);
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
