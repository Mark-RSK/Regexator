// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// A zero-width positive lookahead assertion.
    /// </summary>
    public sealed class Assertion
        : GroupingPattern, IInvertible<NotAssertion>
    {
        internal Assertion(object content)
            : base(content)
        {
        }

        /// <summary>
        /// Returns a new instance of the <see cref="NotAssertion" class./>
        /// </summary>
        /// <returns></returns>
        public NotAssertion Invert()
        {
            return new NotAssertion(this);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteAssert(Content);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static NotAssertion operator !(Assertion value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }
    }
}