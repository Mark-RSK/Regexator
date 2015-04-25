// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Expressions
    {
        internal static Quantifier Maybe()
        {
            return new MaybeQuantifier();
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

        internal static Quantifier MaybeMany()
        {
            return new MaybeManyQuantifier();
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

        internal static Quantifier OneMany()
        {
            return new OneManyQuantifier();
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

        internal static Quantifier Count(int exactCount)
        {
            return new ExactQuantifier(exactCount);
        }

        public static Quantifier Count(int exactCount, Expression expression)
        {
            return QuantifierGroup(expression).Count(exactCount);
        }

        internal static Quantifier AtLeast(int minCount)
        {
            return new AtLeastQuantifier(minCount);
        }

        public static Quantifier AtLeast(int minCount, Expression expression)
        {
            return QuantifierGroup(expression).AtLeast(minCount);
        }

        internal static Quantifier Count(int minCount, int maxCount)
        {
            return new FromToQuantifier(minCount, maxCount);
        }

        public static Quantifier Count(int minCount, int maxCount, Expression expression)
        {
            return QuantifierGroup(expression).Count(minCount, maxCount);
        }
    }
}
