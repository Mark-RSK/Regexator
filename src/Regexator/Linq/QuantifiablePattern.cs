// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a pattern that can be quantified, i.e. quantifier can be applied on it. This class is abstract.
    /// </summary>
    public abstract class QuantifiablePattern
        : Pattern
    {
        protected QuantifiablePattern()
        {
        }

        /// <summary>
        /// Specifies that a pattern must be matched zero or one time.
        /// </summary>
        /// <returns></returns>
        public QuantifiedPattern Maybe()
        {
            return ConcatInternal(new QuantifiedPattern.MaybeQuantifiedPattern());
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
        /// <summary>
        /// Specifies that a pattern must be matched zero or many times.
        /// </summary>
        /// <returns></returns>
        public QuantifiedPattern MaybeMany()
        {
            return ConcatInternal(new QuantifiedPattern.MaybeManyQuantifiedPattern());
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

        /// <summary>
        /// Specifies that a pattern must be matched one or many times.
        /// </summary>
        /// <returns></returns>
        public QuantifiedPattern OneMany()
        {
            return ConcatInternal(new QuantifiedPattern.OneManyQuantifiedPattern());
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
        /// <summary>
        /// Specifies that a pattern must be matched exactly n times.
        /// </summary>
        /// <param name="exactCount">A number of times the pattern must be matched.</param>
        /// <returns></returns>
        public QuantifiedPattern Count(int exactCount)
        {
            return ConcatInternal(new QuantifiedPattern.CountQuantifiedPattern(exactCount));
        }

        /// <summary>
        /// Specifies that a pattern must be matched from n to m times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <returns></returns>
        public QuantifiedPattern Count(int minCount, int maxCount)
        {
            return ConcatInternal(new QuantifiedPattern.CountQuantifiedPattern(minCount, maxCount));
        }

        /// <summary>
        /// Specifies that a pattern must be matched at least n times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <returns></returns>
        public QuantifiedPattern CountFrom(int minCount)
        {
            return ConcatInternal(new QuantifiedPattern.CountFromQuantifiedPattern(minCount));
        }

        /// <summary>
        /// Specifies that a pattern must be matched at most n times.
        /// </summary>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <returns></returns>
        public QuantifiedPattern CountTo(int maxCount)
        {
            return ConcatInternal(new QuantifiedPattern.CountQuantifiedPattern(0, maxCount));
        }
    }
}
