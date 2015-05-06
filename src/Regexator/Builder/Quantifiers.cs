// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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
            return QuantifierGroup(value).Maybe();
        }

        public static QuantifierExpression Maybe(Expression value)
        {
            return QuantifierGroup(value).Maybe();
        }

        public static QuantifierExpression MaybeMany(string value)
        {
            return QuantifierGroup(value).MaybeMany();
        }

        public static QuantifierExpression MaybeMany(Expression value)
        {
            return QuantifierGroup(value).MaybeMany();
        }

        public static QuantifierExpression OneMany(string value)
        {
            return QuantifierGroup(value).OneMany();
        }

        public static QuantifierExpression OneMany(Expression value)
        {
            return QuantifierGroup(value).OneMany();
        }
    }
}
