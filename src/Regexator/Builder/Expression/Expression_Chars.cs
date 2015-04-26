// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Chars(string value)
        {
            return AppendInternal(Groups.Chars(value));
        }

        public QuantifiableExpression Chars(CharItem item)
        {
            return AppendInternal(Groups.Chars(item));
        }

        public QuantifiableExpression Chars(params char[] values)
        {
            return AppendInternal(Groups.Chars(values));
        }

        public QuantifiableExpression Chars(params int[] charCodes)
        {
            return AppendInternal(Groups.Chars(charCodes));
        }

        public QuantifiableExpression Chars(params AsciiChar[] values)
        {
            return AppendInternal(Groups.Chars(values));
        }

        public QuantifiableExpression Chars(params CharClass[] values)
        {
            return AppendInternal(Groups.Chars(values));
        }

        public QuantifiableExpression UnicodeBlock(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Groups.Chars(blocks));
        }

        public QuantifiableExpression UnicodeCategory(params UnicodeCategory[] categories)
        {
            return AppendInternal(Groups.Chars(categories));
        }

        public QuantifiableExpression NotChars(string value)
        {
            return AppendInternal(Groups.NotChars(value));
        }

        public QuantifiableExpression NotChars(CharItem item)
        {
            return AppendInternal(Groups.NotChars(item));
        }

        public QuantifiableExpression NotChars(params char[] values)
        {
            return AppendInternal(Groups.NotChars(values));
        }

        public QuantifiableExpression NotChars(params int[] charCodes)
        {
            return AppendInternal(Groups.NotChars(charCodes));
        }

        public QuantifiableExpression NotChars(params AsciiChar[] values)
        {
            return AppendInternal(Groups.NotChars(values));
        }

        public QuantifiableExpression NotUnicodeBlock(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Groups.NotChars(blocks));
        }

        public QuantifiableExpression NotUnicodeCategory(params UnicodeCategory[] categories)
        {
            return AppendInternal(Groups.NotChars(categories));
        }

        public QuantifiableExpression Range(char first, char last)
        {
            return AppendInternal(Groups.Range(first, last));
        }

        public QuantifiableExpression Range(int first, int last)
        {
            return AppendInternal(Groups.Range(first, last));
        }

        public QuantifiableExpression NotRange(char first, char last)
        {
            return AppendInternal(Groups.NotRange(first, last));
        }

        public QuantifiableExpression NotRange(int first, int last)
        {
            return AppendInternal(Groups.NotRange(first, last));
        }

        public QuantifiableExpression Subtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return AppendInternal(Groups.Subtraction(baseGroup, excludedGroup));
        }

        public QuantifiableExpression NotSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return AppendInternal(Groups.NotSubtraction(baseGroup, excludedGroup));
        }

        public QuantifiableExpression Any()
        {
            return AppendInternal(Characters.Any());
        }

        public QuantifiableExpression WhiteSpaceExceptNewLine()
        {
            return AppendInternal(Expressions.WhiteSpaceExceptNewLine());
        }

        public CharGroup Alphanumeric()
        {
            return AppendInternal(Groups.Alphanumeric());
        }
    }
}