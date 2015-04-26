// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    public static class Groups
    {
        public static QuantifiableExpression Group(string name, Expression expression)
        {
            return new NamedGroup(name, expression);
        }

        public static QuantifiableExpression Group(int name, Expression expression)
        {
            return new NumberNamedGroup(name, expression);
        }

        public static QuantifiableExpression Group(string name, string value)
        {
            return new NamedGroup(name, value);
        }

        public static QuantifiableExpression Group(int name, string value)
        {
            return new NumberNamedGroup(name, value);
        }

        public static QuantifiableExpression Subexpression(Expression expression)
        {
            return new Subexpression(expression);
        }

        public static QuantifiableExpression Subexpression(string value)
        {
            return new Subexpression(value);
        }

        public static QuantifiableExpression Noncapturing(Expression expression)
        {
            return new NoncapturingGroup(expression);
        }

        public static QuantifiableExpression Noncapturing(string value)
        {
            return new NoncapturingGroup(value);
        }

        public static QuantifiableExpression Balancing(string name1, string name2, Expression expression)
        {
            return new BalancingGroup(name1, name2, expression);
        }

        public static QuantifiableExpression Balancing(string name1, string name2, string value)
        {
            return new BalancingGroup(name1, name2, value);
        }

        public static QuantifiableExpression Nonbacktracking(Expression expression)
        {
            return new NonbacktrackingGroup(expression);
        }

        public static QuantifiableExpression Nonbacktracking(string value)
        {
            return new NonbacktrackingGroup(value);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, Expression expression)
        {
            return new GroupOptions(applyOptions, expression);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, string value)
        {
            return new GroupOptions(applyOptions, value);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, Expression expression)
        {
            return new GroupOptions(applyOptions, disableOptions, expression);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string value)
        {
            return new GroupOptions(applyOptions, disableOptions, value);
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

        public static CharGroup Chars(params UnicodeBlock[] blocks)
        {
            return new UnicodeBlockGroup(blocks);
        }

        public static CharGroup Chars(params UnicodeCategory[] categories)
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

        public static CharGroup NotChars(params UnicodeBlock[] blocks)
        {
            return new NotUnicodeBlockGroup(blocks);
        }

        public static CharGroup NotChars(params UnicodeCategory[] categories)
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

        public static CharGroup Alphanumeric()
        {
            return Chars(CharItems.Alphanumeric());
        }

        internal static QuantifiableExpression QuantifierGroup(string value)
        {
            return new QuantifierSubexpression(value);
        }

        internal static QuantifiableExpression QuantifierGroup(Expression expression)
        {
            return new QuantifierSubexpression(expression);
        }

        public static Quantifier Maybe(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).Maybe();
        }

        public static Quantifier Maybe(Expression value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).Maybe();
        }

        public static Quantifier MaybeMany(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).MaybeMany();
        }

        public static Quantifier MaybeMany(Expression value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).MaybeMany();
        }

        public static Quantifier OneMany(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).OneMany();
        }

        public static Quantifier OneMany(Expression value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).OneMany();
        }

        public static Quantifier Count(string value, int exactCount)
        {
            return QuantifierGroup(value).Count(exactCount);
        }

        public static Quantifier Count(Expression expression, int exactCount)
        {
            return QuantifierGroup(expression).Count(exactCount);
        }

        public static Quantifier AtLeast(string value, int minCount)
        {
            return QuantifierGroup(value).AtLeast(minCount);
        }

        public static Quantifier AtLeast(Expression expression, int minCount)
        {
            return QuantifierGroup(expression).AtLeast(minCount);
        }

        public static Quantifier Count(string value, int minCount, int maxCount)
        {
            return Groups.QuantifierGroup(value).Count(minCount, maxCount);
        }

        public static Quantifier Count(Expression expression, int minCount, int maxCount)
        {
            return Groups.QuantifierGroup(expression).Count(minCount, maxCount);
        }
    }
}
