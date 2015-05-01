// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

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
            return new ExactQuantifier(exactCount);
        }

        internal static QuantifierExpression AtLeast(int minCount)
        {
            return new AtLeastQuantifier(minCount);
        }

        internal static QuantifierExpression Count(int minCount, int maxCount)
        {
            return new FromToQuantifier(minCount, maxCount);
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
            return QuantifierGroup(value).Count(minCount, maxCount);
        }

        public static QuantifierExpression Count(Expression expression, int minCount, int maxCount)
        {
            return QuantifierGroup(expression).Count(minCount, maxCount);
        }
    }
}
