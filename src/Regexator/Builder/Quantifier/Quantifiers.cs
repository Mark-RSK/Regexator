// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal static class Quantifiers
    {
        public static Quantifier Maybe()
        {
            return new MaybeQuantifier();
        }

        public static Quantifier MaybeMany()
        {
            return new MaybeManyQuantifier();
        }

        public static Quantifier OneMany()
        {
            return new OneManyQuantifier();
        }

        public static Quantifier Count(int exactCount)
        {
            return new ExactQuantifier(exactCount);
        }

        public static Quantifier AtLeast(int minCount)
        {
            return new AtLeastQuantifier(minCount);
        }

        public static Quantifier Count(int minCount, int maxCount)
        {
            return new FromToQuantifier(minCount, maxCount);
        }
    }
}
