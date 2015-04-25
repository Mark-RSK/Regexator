// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    public static class Expressions
    {
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

        public static QuantifiableExpression Backreference(int groupNumber)
        {
            return new NumberBackreference(groupNumber);
        }

        public static QuantifiableExpression Backreference(string groupName)
        {
            return new NameBackreference(groupName);
        }

        public static Expression Options(InlineOptions applyOptions)
        {
            return new InlineOptionsExpression(applyOptions);
        }

        public static Expression Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return new InlineOptionsExpression(applyOptions, disableOptions);
        }

        public static Expression InlineComment(string value)
        {
            return new InlineCommentExpression(value);
        }

        public static CharSubtraction WhiteSpaceExceptNewLine()
        {
            return new CharSubtraction(CharItems.WhiteSpace(), CharItems.CarriageReturn().Linefeed());
        }

        public static QuantifiableExpression NewLine()
        {
            return Characters.CarriageReturn().Maybe().Linefeed().AsNoncapturing();
        }

        public static Expression Text(string value)
        {
            return Expression.Create(value);
        }

        internal static QuantifiableExpression InsignificantSeparator()
        {
            return Groups.GroupOptions(InlineOptions.IgnorePatternWhitespace, new TextExpression(" ", false));
        }
    }
}
