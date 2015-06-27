// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Specifies that the match must occur at the end of the string.
    /// </summary>
    internal sealed class EndOfInput
        : QuantifiablePattern
    {
        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteEndOfInput();
        }
    }
}
