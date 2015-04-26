// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Chars(string value)
        {
            return AppendInternal(Expressions.Chars(value));
        }

        public QuantifiableExpression Chars(CharItem item)
        {
            return AppendInternal(Expressions.Chars(item));
        }

        public QuantifiableExpression Chars(params char[] values)
        {
            return AppendInternal(Expressions.Chars(values));
        }

        public QuantifiableExpression Chars(params int[] charCodes)
        {
            return AppendInternal(Expressions.Chars(charCodes));
        }

        public QuantifiableExpression Chars(params AsciiChar[] values)
        {
            return AppendInternal(Expressions.Chars(values));
        }

        public QuantifiableExpression Chars(params CharClass[] values)
        {
            return AppendInternal(Expressions.Chars(values));
        }

        public QuantifiableExpression UnicodeBlock(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Expressions.UnicodeBlock(blocks));
        }

        public QuantifiableExpression UnicodeCategory(params UnicodeCategory[] categories)
        {
            return AppendInternal(Expressions.UnicodeCategory(categories));
        }

        public QuantifiableExpression NotChars(string value)
        {
            return AppendInternal(Expressions.NotChars(value));
        }

        public QuantifiableExpression NotChars(CharItem item)
        {
            return AppendInternal(Expressions.NotChars(item));
        }

        public QuantifiableExpression NotChars(params char[] values)
        {
            return AppendInternal(Expressions.NotChars(values));
        }

        public QuantifiableExpression NotChars(params int[] charCodes)
        {
            return AppendInternal(Expressions.NotChars(charCodes));
        }

        public QuantifiableExpression NotChars(params AsciiChar[] values)
        {
            return AppendInternal(Expressions.NotChars(values));
        }

        public QuantifiableExpression NotUnicodeBlock(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Expressions.NotUnicodeBlock(blocks));
        }

        public QuantifiableExpression NotUnicodeCategory(params UnicodeCategory[] categories)
        {
            return AppendInternal(Expressions.NotUnicodeCategory(categories));
        }

        public QuantifiableExpression Range(char first, char last)
        {
            return AppendInternal(Expressions.Range(first, last));
        }

        public QuantifiableExpression Range(int first, int last)
        {
            return AppendInternal(Expressions.Range(first, last));
        }

        public QuantifiableExpression NotRange(char first, char last)
        {
            return AppendInternal(Expressions.NotRange(first, last));
        }

        public QuantifiableExpression NotRange(int first, int last)
        {
            return AppendInternal(Expressions.NotRange(first, last));
        }

        public QuantifiableExpression Subtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return AppendInternal(Expressions.Subtraction(baseGroup, excludedGroup));
        }

        public QuantifiableExpression NotSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return AppendInternal(Expressions.NotSubtraction(baseGroup, excludedGroup));
        }

        public QuantifiableExpression Any()
        {
            return AppendInternal(Expressions.Any());
        }

        public QuantifiableExpression WhiteSpaceExceptNewLine()
        {
            return AppendInternal(Expressions.WhiteSpaceExceptNewLine());
        }
    }
}