// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static class Quantifiers
    {
        internal static Quantifier Maybe()
        {
            return new MaybeQuantifier();
        }

        internal static Quantifier MaybeMany()
        {
            return new MaybeManyQuantifier();
        }

        internal static Quantifier OneMany()
        {
            return new OneManyQuantifier();
        }

        internal static Quantifier Count(int exactCount)
        {
            return new ExactQuantifier(exactCount);
        }

        internal static Quantifier AtLeast(int minCount)
        {
            return new AtLeastQuantifier(minCount);
        }

        internal static Quantifier Count(int minCount, int maxCount)
        {
            return new FromToQuantifier(minCount, maxCount);
        }
    }
}
