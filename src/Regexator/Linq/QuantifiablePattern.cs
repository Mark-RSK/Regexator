// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a pattern that can be quantified, i.e. quantifier can be applied on it. This class is abstract.
    /// </summary>
    public abstract class QuantifiablePattern
        : Pattern
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QuantifiablePattern"/> class.
        /// </summary>
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

        /// <summary>
        /// Specifies that a pattern must be matched zero or many times.
        /// </summary>
        /// <returns></returns>
        public QuantifiedPattern MaybeMany()
        {
            return ConcatInternal(new QuantifiedPattern.MaybeManyQuantifiedPattern());
        }

        /// <summary>
        /// Specifies that a pattern must be matched one or many times.
        /// </summary>
        /// <returns></returns>
        public QuantifiedPattern OneMany()
        {
            return ConcatInternal(new QuantifiedPattern.OneManyQuantifiedPattern());
        }

        /// <summary>
        /// Specifies that a pattern must be matched exactly n times.
        /// </summary>
        /// <param name="exactCount">A number of times the pattern must be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedPattern Count(int minCount, int maxCount)
        {
            return ConcatInternal(new QuantifiedPattern.CountQuantifiedPattern(minCount, maxCount));
        }

        /// <summary>
        /// Specifies that a pattern must be matched at least n times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedPattern CountFrom(int minCount)
        {
            return ConcatInternal(new QuantifiedPattern.CountFromQuantifiedPattern(minCount));
        }

        /// <summary>
        /// Specifies that a pattern must be matched at most n times.
        /// </summary>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedPattern CountTo(int maxCount)
        {
            return ConcatInternal(new QuantifiedPattern.CountQuantifiedPattern(0, maxCount));
        }

#if DEBUG
        /// <summary>
        /// Specifies that a pattern must be matched zero or one time with greedy or lazy modifiers.
        /// </summary>
        /// <returns></returns>
        /// <param name="lazy">Indicates whether the quantifier will be greedy or lazy.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Specifies that a pattern must be matched zero or many times.
        /// </summary>
        /// <param name="lazy">Indicates whether the quantifier will be greedy or lazy.</param>
        /// <returns></returns>
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

        /// <summary>
        /// Specifies that a pattern must be matched one or many times.
        /// </summary>
        /// <param name="lazy">Indicates whether the quantifier will be greedy or lazy.</param>
        /// <returns></returns>
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
    }
}
