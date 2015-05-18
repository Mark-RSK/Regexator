// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal static class Quantifiers
    {
        public static QuantifierExpression Maybe()
        {
            return new MaybeQuantifier();
        }

        public static QuantifierExpression MaybeMany()
        {
            return new MaybeManyQuantifier();
        }

        public static QuantifierExpression OneMany()
        {
            return new OneManyQuantifier();
        }

        public static QuantifierExpression MaybeCount(int maxCount)
        {
            return new CountRangeQuantifier(0, maxCount);
        }

        public static QuantifierExpression Count(int exactCount)
        {
            return new CountQuantifier(exactCount);
        }

        public static QuantifierExpression CountFrom(int minCount)
        {
            return new CountFromQuantifier(minCount);
        }

        public static QuantifierExpression CountRange(int minCount, int maxCount)
        {
            return new CountRangeQuantifier(minCount, maxCount);
        }
    }
}
