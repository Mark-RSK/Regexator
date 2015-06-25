// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class Assertion
        : GroupPattern, IInvertible<NegativeAssertion>
    {
        internal Assertion(object content)
            : base(content)
        {
        }

        public NegativeAssertion Invert()
        {
            return new NegativeAssertion(this);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteAssert(Content);
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