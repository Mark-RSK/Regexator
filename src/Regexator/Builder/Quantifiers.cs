// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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

        public static QuantifierExpression Count(int exactCount)
        {
            return new ExactQuantifier(exactCount);
        }

        public static QuantifierExpression AtLeast(int minCount)
        {
            return new AtLeastQuantifier(minCount);
        }

        public static QuantifierExpression Count(int minCount, int maxCount)
        {
            return new FromToQuantifier(minCount, maxCount);
        }
    }
}
