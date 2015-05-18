// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static class Quantifiers
    {
        internal static QuantifierExpression Maybe()
        {
            return new MaybeQuantifier();
        }

        internal static QuantifierExpression MaybeMany()
        {
            return new MaybeManyQuantifier();
        }

        internal static QuantifierExpression MaybeCount(int maxCount)
        {
            return new CountRangeQuantifier(0, maxCount);
        }

        internal static QuantifierExpression OneMany()
        {
            return new OneManyQuantifier();
        }

        internal static QuantifierExpression Count(int exactCount)
        {
            return new CountQuantifier(exactCount);
        }

        internal static QuantifierExpression CountFrom(int minCount)
        {
            return new CountFromQuantifier(minCount);
        }

        internal static QuantifierExpression CountRange(int minCount, int maxCount)
        {
            return new CountRangeQuantifier(minCount, maxCount);
        }

        internal static QuantifiableExpression QuantifierGroup(string text)
        {
            return new QuantifierSubexpression(text);
        }

        internal static QuantifiableExpression QuantifierGroup(Expression expression)
        {
            return new QuantifierSubexpression(expression);
        }

        public static QuantifierExpression Maybe(string text)
        {
            return QuantifierGroup(text).Maybe();
        }

        public static QuantifierExpression Maybe(Expression expression)
        {
            return QuantifierGroup(expression).Maybe();
        }

        public static QuantifierExpression MaybeMany(string text)
        {
            return QuantifierGroup(text).MaybeMany();
        }

        public static QuantifierExpression MaybeMany(Expression expression)
        {
            return QuantifierGroup(expression).MaybeMany();
        }

        public static QuantifierExpression OneMany(string text)
        {
            return QuantifierGroup(text).OneMany();
        }

        public static QuantifierExpression OneMany(Expression expression)
        {
            return QuantifierGroup(expression).OneMany();
        }
    }
}
