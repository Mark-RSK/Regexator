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

        public QuantifiedPattern Maybe()
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

        public QuantifiedPattern MaybeMany()
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

        public QuantifiedPattern OneMany()
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

        public QuantifiedPattern Count(int exactCount)
        {
            return ConcatInternal(new CountQuantifier(exactCount));
        }

        public QuantifiedPattern Count(int minCount, int maxCount)
        {
            return ConcatInternal(new CountQuantifier(minCount, maxCount));
        }

        public QuantifiedPattern CountFrom(int minCount)
        {
            return ConcatInternal(new CountFromQuantifier(minCount));
        }

        public QuantifiedPattern CountTo(int maxCount)
        {
            return ConcatInternal(new CountQuantifier(0, maxCount));
        }
    }
}
