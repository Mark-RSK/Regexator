// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Quantifiers
    {
        public static QuantifierExpression Maybe(object content)
        {
            return QuantifierGroup(content).Maybe();
        }

        public static QuantifierExpression Maybe(params object[] content)
        {
            return Maybe((object)content);
        }

        public static QuantifierExpression MaybeMany(object content)
        {
            return QuantifierGroup(content).MaybeMany();
        }

        public static QuantifierExpression MaybeMany(params object[] content)
        {
            return MaybeMany((object)content);
        }

        public static QuantifierExpression OneMany(object content)
        {
            return QuantifierGroup(content).OneMany();
        }

        public static QuantifierExpression OneMany(params object[] content)
        {
            return OneMany((object)content);
        }

        public static QuantifierExpression Count(int exactCount, object content)
        {
            return QuantifierGroup(content).Count(exactCount);
        }

        public static QuantifierExpression Count(int exactCount, params object[] content)
        {
            return Count(exactCount, (object)content);
        }

        public static QuantifierExpression CountFrom(int minCount, object content)
        {
            return QuantifierGroup(content).CountFrom(minCount);
        }

        public static QuantifierExpression CountFrom(int minCount, params object[] content)
        {
            return CountFrom(minCount, (object)content);
        }

        public static QuantifierExpression CountRange(int minCount, int maxCount, object content)
        {
            return QuantifierGroup(content).CountRange(minCount, maxCount);
        }

        public static QuantifierExpression CountRange(int minCount, int maxCount, params object[] content)
        {
            return CountRange(minCount, maxCount, (object)content);
        }

        public static QuantifierExpression CountTo(int maxCount, object content)
        {
            return QuantifierGroup(content).CountTo(maxCount);
        }

        public static QuantifierExpression CountTo(int maxCount, params object[] content)
        {
            return CountTo(maxCount, (object)content);
        }

        internal static QuantifiableExpression QuantifierGroup(object content)
        {
            return new QuantifierGroupExpression(content);
        }
    }
}
