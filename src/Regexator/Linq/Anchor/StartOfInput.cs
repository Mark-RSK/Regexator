// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Specifies that the match must occur at the beginning of the string. This class cannot be inherited.
    /// </summary>
    internal sealed class StartOfInput
        : QuantifiablePattern
    {
        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteStartOfInput();
        }
    }
}
