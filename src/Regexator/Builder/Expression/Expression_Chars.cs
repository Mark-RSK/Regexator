// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Chars(string value)
        {
            return Append(Expressions.Chars(value));
        }

        public QuantifiableExpression Chars(CharItem item)
        {
            return Append(Expressions.Chars(item));
        }

        public QuantifiableExpression Chars(params char[] values)
        {
            return Append(Expressions.Chars(values));
        }

        public QuantifiableExpression Chars(params int[] charCodes)
        {
            return Append(Expressions.Chars(charCodes));
        }

        public QuantifiableExpression Chars(params AsciiChar[] values)
        {
            return Append(Expressions.Chars(values));
        }

        public QuantifiableExpression Chars(params CharClass[] values)
        {
            return Append(Expressions.Chars(values));
        }

        public QuantifiableExpression UnicodeBlock(params UnicodeBlock[] blocks)
        {
            return Append(Expressions.UnicodeBlock(blocks));
        }

        public QuantifiableExpression UnicodeCategory(params UnicodeCategory[] categories)
        {
            return Append(Expressions.UnicodeCategory(categories));
        }

        public QuantifiableExpression NotChars(string value)
        {
            return Append(Expressions.NotChars(value));
        }

        public QuantifiableExpression NotChars(CharItem item)
        {
            return Append(Expressions.NotChars(item));
        }

        public QuantifiableExpression NotChars(params char[] values)
        {
            return Append(Expressions.NotChars(values));
        }

        public QuantifiableExpression NotChars(params int[] charCodes)
        {
            return Append(Expressions.NotChars(charCodes));
        }

        public QuantifiableExpression NotChars(params AsciiChar[] values)
        {
            return Append(Expressions.NotChars(values));
        }

        public QuantifiableExpression NotUnicodeBlock(params UnicodeBlock[] blocks)
        {
            return Append(Expressions.NotUnicodeBlock(blocks));
        }

        public QuantifiableExpression NotUnicodeCategory(params UnicodeCategory[] categories)
        {
            return Append(Expressions.NotUnicodeCategory(categories));
        }

        public QuantifiableExpression Range(char first, char last)
        {
            return Append(Expressions.Range(first, last));
        }

        public QuantifiableExpression Range(int first, int last)
        {
            return Append(Expressions.Range(first, last));
        }

        public QuantifiableExpression NotRange(char first, char last)
        {
            return Append(Expressions.NotRange(first, last));
        }

        public QuantifiableExpression NotRange(int first, int last)
        {
            return Append(Expressions.NotRange(first, last));
        }

        public QuantifiableExpression Subtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return Append(Expressions.Subtraction(baseGroup, excludedGroup));
        }

        public QuantifiableExpression NotSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return Append(Expressions.NotSubtraction(baseGroup, excludedGroup));
        }

        public QuantifiableExpression Any()
        {
            return Append(Expressions.Any());
        }

        public QuantifiableExpression WhiteSpaceExceptNewLine()
        {
            return Append(Expressions.WhiteSpaceExceptNewLine());
        }
    }
}