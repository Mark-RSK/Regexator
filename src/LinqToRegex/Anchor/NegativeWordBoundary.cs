// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a pattern that is matched not on a boundary between a word character (\w) and a non-word character (\W). This class cannot be inherited.
    /// </summary>
    public sealed class NegativeWordBoundary
        : QuantifiablePattern
    {
        internal NegativeWordBoundary()
        {
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendNegativeWordBoundary();
        }
    }
}
