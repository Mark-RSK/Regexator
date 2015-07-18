// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a pattern that is matched on a boundary between a word character (\w) and a non-word character (\W).
    /// The pattern may be also matched on a word boundary at the beginning or end of the string. This class cannot be inherited.
    /// </summary>
    public sealed class WordBoundary
        : QuantifiablePattern, INegateable<NegativeWordBoundary>
    {
        /// <summary>
        /// Returns an instance of the <see cref="NegativeWordBoundary"/> class.
        /// </summary>
        /// <returns></returns>
        public NegativeWordBoundary Negate()
        {
            return new NegativeWordBoundary();
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendWordBoundary();
        }

        /// <summary>
        /// Returns an instance of the <see cref="NegativeWordBoundary"/> class.
        /// </summary>
        /// <param name="value">A value to negate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static NegativeWordBoundary operator !(WordBoundary value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Negate();
        }
    }
}
