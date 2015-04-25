// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Expressions
    {
        public static QuantifiableExpression Char(char value)
        {
            return new CharExpression(value);
        }

        public static QuantifiableExpression Char(int charCode)
        {
            return new CharCodeExpression(charCode);
        }

        public static QuantifiableExpression Char(AsciiChar value)
        {
            return new AsciiCharExpression(value);
        }

        public static QuantifiableExpression Char(CharClass value)
        {
            return new CharClassExpression(value);
        }

        public static QuantifiableExpression UnicodeBlock(UnicodeBlock block)
        {
            return new UnicodeBlockExpression(block);
        }

        public static QuantifiableExpression UnicodeCategory(UnicodeCategory category)
        {
            return new UnicodeCategoryExpression(category);
        }

        public static CharGroup NotChar(char value)
        {
            return new NotCharsGroup(value);
        }

        public static CharGroup NotChar(int charCode)
        {
            return new NotCharCodeGroup(charCode);
        }

        public static CharGroup NotChar(AsciiChar value)
        {
            return new NotAsciiCharGroup(value);
        }

        public static QuantifiableExpression NotUnicodeBlock(UnicodeBlock block)
        {
            return new NotUnicodeBlockExpression(block);
        }

        public static QuantifiableExpression NotUnicodeCategory(UnicodeCategory category)
        {
            return new NotUnicodeCategoryExpression(category);
        }

        public static CharGroup Chars(string value)
        {
            return new TextCharGroup(value);
        }

        public static CharGroup Chars(CharItem item)
        {
            return new CharItemGroup(item);
        }

        public static CharGroup Chars(params char[] values)
        {
            return new CharsGroup(values);
        }

        public static CharGroup Chars(params int[] charCodes)
        {
            return new CharCodeGroup(charCodes);
        }

        public static CharGroup Chars(params AsciiChar[] values)
        {
            return new AsciiCharGroup(values);
        }

        public static CharGroup Chars(params CharClass[] values)
        {
            return new CharClassGroup(values);
        }

        public static CharGroup UnicodeBlock(params UnicodeBlock[] blocks)
        {
            return new UnicodeBlockGroup(blocks);
        }

        public static CharGroup UnicodeCategory(params UnicodeCategory[] categories)
        {
            return new UnicodeCategoryGroup(categories);
        }

        public static CharGroup NotChars(string value)
        {
            return new NotTextCharGroup(value);
        }

        public static CharGroup NotChars(CharItem item)
        {
            return new NotCharItemGroup(item);
        }

        public static CharGroup NotChars(params char[] values)
        {
            return new NotCharsGroup(values);
        }

        public static CharGroup NotChars(params int[] charCodes)
        {
            return new NotCharCodeGroup(charCodes);
        }

        public static CharGroup NotChars(params AsciiChar[] values)
        {
            return new NotAsciiCharGroup(values);
        }

        public static CharGroup NotUnicodeBlock(params UnicodeBlock[] blocks)
        {
            return new NotUnicodeBlockGroup(blocks);
        }

        public static CharGroup NotUnicodeCategory(params UnicodeCategory[] categories)
        {
            return new NotUnicodeCategoryGroup(categories);
        }

        public static CharGroup Range(char first, char last)
        {
            return new CharRangeGroup(first, last);
        }

        public static CharGroup Range(int first, int last)
        {
            return new CodeRangeGroup(first, last);
        }

        public static CharGroup NotRange(char first, char last)
        {
            return new NotCharRangeGroup(first, last);
        }

        public static CharGroup NotRange(int first, int last)
        {
            return new NotCodeRangeGroup(first, last);
        }

        public static CharSubtraction Subtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup);
        }

        public static CharSubtraction NotSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup, true);
        }

        public static QuantifiableExpression Any()
        {
            return new AnyCharExpression();
        }

        public static CharSubtraction WhiteSpaceExceptNewLine()
        {
            return new CharSubtraction(CharItems.WhiteSpace(), CharItems.CarriageReturn().Linefeed());
        }
    }
}
