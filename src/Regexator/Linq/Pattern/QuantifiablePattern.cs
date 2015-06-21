// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class QuantifiablePattern
        : Pattern
    {
        protected QuantifiablePattern()
            : base()
        {
        }

        public Quantifier Maybe()
        {
            return ConcatInternal(new MaybeQuantifier());
        }

#if DEBUG
        public Pattern Maybe(bool lazy)
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

        public Quantifier MaybeMany()
        {
            return ConcatInternal(new MaybeManyQuantifier());
        }

#if DEBUG
        public Pattern MaybeMany(bool lazy)
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

        public Quantifier OneMany()
        {
            return ConcatInternal(new OneManyQuantifier());
        }

#if DEBUG
        public Pattern OneMany(bool lazy)
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

        public Quantifier Count(int exactCount)
        {
            return ConcatInternal(new CountQuantifier(exactCount));
        }

        public Quantifier Count(int minCount, int maxCount)
        {
            return ConcatInternal(new CountQuantifier(minCount, maxCount));
        }

        public Quantifier CountFrom(int minCount)
        {
            return ConcatInternal(new CountFromQuantifier(minCount));
        }

        public Quantifier CountTo(int maxCount)
        {
            return ConcatInternal(new CountQuantifier(0, maxCount));
        }
    }
}
