// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Specifies that the match must occur on a boundary between a word character (\w) and a non-word character (\W).
    /// The match may also occur on a word boundary at the beginning or end of the string. This class cannot be inherited.
    /// </summary>
    public sealed class WordBoundary
        : QuantifiablePattern, IInvertible<NegativeWordBoundary>
    {
        /// <summary>
        /// Returns an instance of the <see cref="NegativeWordBoundary" class./>
        /// </summary>
        /// <returns></returns>
        public NegativeWordBoundary Invert()
        {
            return new NegativeWordBoundary();
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendWordBoundary();
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static NegativeWordBoundary operator !(WordBoundary value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }
    }
}
