// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class BackAssertion
        : GroupPattern, IInvertible<NotBackAssertion>
    {
        internal BackAssertion(object content)
            : base(content)
        {
        }

        public NotBackAssertion Invert()
        {
            return new NotBackAssertion(this);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteAssertBack(Content);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static NotBackAssertion operator !(BackAssertion value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }
    }
}