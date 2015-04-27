// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    public static class Grouping
    {
        public static QuantifiableExpression NamedGroup(string name, Expression expression)
        {
            return new NamedGroup(name, expression);
        }

        public static QuantifiableExpression NamedGroup(string name, string value)
        {
            return new NamedGroup(name, value);
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
            return new NoncapturingExpression(expression);
        }

        public static QuantifiableExpression Noncapturing(string value)
        {
            return new NoncapturingExpression(value);
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
            return new NonbacktrackingExpression(expression);
        }

        public static QuantifiableExpression Nonbacktracking(string value)
        {
            return new NonbacktrackingExpression(value);
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

        public static CharacterGroupExpression Chars(string value)
        {
            return new TextCharGroup(value);
        }

        public static CharacterGroupExpression Chars(CharacterGroupItem item)
        {
            return new CharItemGroup(item);
        }

        public static CharacterGroupExpression Chars(params char[] values)
        {
            return new CharGroup(values);
        }

        public static CharacterGroupExpression Chars(params int[] charCodes)
        {
            return new CharCodeGroup(charCodes);
        }

        public static CharacterGroupExpression Chars(params AsciiChar[] values)
        {
            return new AsciiCharGroup(values);
        }

        public static CharacterGroupExpression Chars(params CharClass[] values)
        {
            return new CharClassGroup(values);
        }

        public static CharacterGroupExpression Chars(params UnicodeBlock[] blocks)
        {
            return new UnicodeBlockGroup(blocks);
        }

        public static CharacterGroupExpression Chars(params UnicodeCategory[] categories)
        {
            return new UnicodeCategoryGroup(categories);
        }

        public static CharacterGroupExpression NotChars(string value)
        {
            return new NotTextCharGroup(value);
        }

        public static CharacterGroupExpression NotChars(CharacterGroupItem item)
        {
            return new NotCharItemGroup(item);
        }

        public static CharacterGroupExpression NotChars(params char[] values)
        {
            return new NotCharGroup(values);
        }

        public static CharacterGroupExpression NotChars(params int[] charCodes)
        {
            return new NotCharCodeGroup(charCodes);
        }

        public static CharacterGroupExpression NotChars(params AsciiChar[] values)
        {
            return new NotAsciiCharGroup(values);
        }

        public static CharacterGroupExpression NotChars(params UnicodeBlock[] blocks)
        {
            return new NotUnicodeBlockGroup(blocks);
        }

        public static CharacterGroupExpression NotChars(params UnicodeCategory[] categories)
        {
            return new NotUnicodeCategoryGroup(categories);
        }

        public static CharacterGroupExpression Range(char first, char last)
        {
            return new CharRangeGroup(first, last);
        }

        public static CharacterGroupExpression Range(int first, int last)
        {
            return new CharCodeRangeGroup(first, last);
        }

        public static CharacterGroupExpression NotRange(char first, char last)
        {
            return new NotCharRangeGroup(first, last);
        }

        public static CharacterGroupExpression NotRange(int first, int last)
        {
            return new NotCharCodeRangeGroup(first, last);
        }

        public static CharSubtraction Subtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup);
        }

        public static CharSubtraction NotSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup, true);
        }

        public static CharacterGroupExpression Alphanumeric()
        {
            return Chars(CharacterItem.Alphanumeric());
        }

        internal static QuantifiableExpression QuantifierGroup(string value)
        {
            return new QuantifierSubexpression(value);
        }

        internal static QuantifiableExpression QuantifierGroup(Expression expression)
        {
            return new QuantifierSubexpression(expression);
        }

        public static QuantifierExpression Maybe(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).Maybe();
        }

        public static QuantifierExpression Maybe(Expression value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).Maybe();
        }

        public static QuantifierExpression MaybeMany(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).MaybeMany();
        }

        public static QuantifierExpression MaybeMany(Expression value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).MaybeMany();
        }

        public static QuantifierExpression OneMany(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).OneMany();
        }

        public static QuantifierExpression OneMany(Expression value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).OneMany();
        }

        public static QuantifierExpression Count(string value, int exactCount)
        {
            return QuantifierGroup(value).Count(exactCount);
        }

        public static QuantifierExpression Count(Expression expression, int exactCount)
        {
            return QuantifierGroup(expression).Count(exactCount);
        }

        public static QuantifierExpression AtLeast(string value, int minCount)
        {
            return QuantifierGroup(value).AtLeast(minCount);
        }

        public static QuantifierExpression AtLeast(Expression expression, int minCount)
        {
            return QuantifierGroup(expression).AtLeast(minCount);
        }

        public static QuantifierExpression Count(string value, int minCount, int maxCount)
        {
            return Grouping.QuantifierGroup(value).Count(minCount, maxCount);
        }

        public static QuantifierExpression Count(Expression expression, int minCount, int maxCount)
        {
            return Grouping.QuantifierGroup(expression).Count(minCount, maxCount);
        }
    }
}
