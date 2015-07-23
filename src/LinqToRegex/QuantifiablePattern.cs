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
        /// Specifies that previous element must be matched zero or one time.
        /// </summary>
        /// <returns></returns>
        public QuantifiedPattern Maybe()
        {
            return ConcatInternal(new QuantifiedPattern.MaybeQuantifiedPattern());
        }

        /// <summary>
        /// Specifies that previous element must be matched zero or more times.
        /// </summary>
        /// <returns></returns>
        public QuantifiedPattern MaybeMany()
        {
            return ConcatInternal(new QuantifiedPattern.MaybeManyQuantifiedPattern());
        }

        /// <summary>
        /// Specifies that previous element must be matched one or more times.
        /// </summary>
        /// <returns></returns>
        public QuantifiedPattern OneMany()
        {
            return ConcatInternal(new QuantifiedPattern.OneManyQuantifiedPattern());
        }

        /// <summary>
        /// Specifies that previous element must be matched a specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times the pattern must be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedPattern Count(int exactCount)
        {
            return ConcatInternal(new QuantifiedPattern.CountQuantifiedPattern(exactCount));
        }

        /// <summary>
        /// Specifies that previous element must be matched from minimal to maximum times.
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
        /// Specifies that previous element must be matched at least specified number of times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedPattern CountFrom(int minCount)
        {
            return ConcatInternal(new QuantifiedPattern.CountFromQuantifiedPattern(minCount));
        }

        /// <summary>
        /// Specifies that previous element must be matched at most specified number of times.
        /// </summary>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedPattern MaybeCount(int maxCount)
        {
            return ConcatInternal(new QuantifiedPattern.CountQuantifiedPattern(0, maxCount));
        }
    }
}
