// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a zero-width positive lookbehind assertion. This class cannot be inherited.
    /// </summary>
    public sealed class BackAssertion
        : GroupingPattern, INegateable<NegativeBackAssertion>
    {
        internal BackAssertion(object content)
            : base(content)
        {
        }

        /// <summary>
        /// Returns a new instance of the <see cref="NegativeBackAssertion"/> class.
        /// </summary>
        /// <returns></returns>
        public NegativeBackAssertion Negate()
        {
            return new NegativeBackAssertion(this);
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendBackAssertion(Content);
        }

        /// <summary>
        /// Returns a new instance of the <see cref="NegativeBackAssertion"/> class.
        /// </summary>
        /// <param name="value">A value to negate.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static NegativeBackAssertion operator !(BackAssertion value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Negate();
        }
    }
}