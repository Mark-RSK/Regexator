﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class WordBoundary
        : QuantifiablePattern, IInvertible<NotWordBoundary>
    {
        public NotWordBoundary Invert()
        {
            return new NotWordBoundary();
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteWordBoundary();
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static NotWordBoundary operator !(WordBoundary value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }
    }
}
