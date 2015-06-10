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

#if DEBUG
        public Expression Maybe(bool lazy)
        {
            if (lazy)
            {
                return Maybe().Lazy();
            }
            else
            {
                return Maybe();
            }
        }
#endif

        public QuantifiedExpression MaybeMany()
        {
            return ConcatInternal(new MaybeManyQuantifier());
        }

#if DEBUG
        public Expression MaybeMany(bool lazy)
        {
            if (lazy)
            {
                return MaybeMany().Lazy();
            }
            else
            {
                return MaybeMany();
            }
        }
#endif

        public QuantifiedExpression MaybeCount(int maxCount)
        {
            return ConcatInternal(new CountRangeQuantifier(0, maxCount));
        }

        public QuantifiedExpression OneMany()
        {
            return ConcatInternal(new OneManyQuantifier());
        }

#if DEBUG
        public Expression OneMany(bool lazy)
        {
            if (lazy)
            {
                return OneMany().Lazy();
            }
            else
            {
                return OneMany();
            }
        }
#endif

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
