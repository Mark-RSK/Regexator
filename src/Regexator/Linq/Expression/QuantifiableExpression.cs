// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class QuantifiableExpression
        : Expression
    {
        protected QuantifiableExpression()
            : base()
        {
        }

        public QuantifiedExpression Maybe()
        {
            return ConcatInternal(new MaybeQuantifier());
        }

        public QuantifiedExpression MaybeMany()
        {
            return ConcatInternal(new MaybeManyQuantifier());
        }

        public QuantifiedExpression MaybeCount(int maxCount)
        {
            return ConcatInternal(new CountRangeQuantifier(0, maxCount));
        }

        public QuantifiedExpression OneMany()
        {
            return ConcatInternal(new OneManyQuantifier());
        }

        public QuantifiedExpression Count(int exactCount)
        {
            return ConcatInternal(new CountQuantifier(exactCount));
        }

        public QuantifiedExpression CountFrom(int minCount)
        {
            return ConcatInternal(new CountFromQuantifier(minCount));
        }

        public QuantifiedExpression CountRange(int minCount, int maxCount)
        {
            return ConcatInternal(new CountRangeQuantifier(minCount, maxCount));
        }
    }
}
