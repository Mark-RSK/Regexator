// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a zero-width positive lookahead assertion. This class cannot be inherited.
    /// </summary>
    public sealed class Assertion
        : GroupingPattern, IInvertible<NegativeAssertion>
    {
        internal Assertion(object content)
            : base(content)
        {
        }

        /// <summary>
        /// Returns an instance of the <see cref="NegativeAssertion" class./>
        /// </summary>
        /// <returns></returns>
        public NegativeAssertion Invert()
        {
            return new NegativeAssertion(this);
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendAssertion(Content);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static NegativeAssertion operator !(Assertion value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }
    }
}