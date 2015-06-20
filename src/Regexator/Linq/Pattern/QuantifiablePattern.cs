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

        public QuantifierGroup Maybe()
        {
            return new Maybe(this);
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

        public QuantifierGroup MaybeMany()
        {
            return new MaybeMany(this);
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

        public QuantifierGroup OneMany()
        {
            return new OneMany(this);
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

        public QuantifierGroup Count(int exactCount)
        {
            return new Count(exactCount, this);
        }

        public QuantifierGroup CountFrom(int minCount)
        {
            return new CountFrom(minCount, this);
        }

        public QuantifierGroup CountTo(int maxCount)
        {
            return new CountTo(maxCount, this);
        }

        public QuantifierGroup CountRange(int minCount, int maxCount)
        {
            return new CountRange(minCount, maxCount, this);
        }
    }
}
