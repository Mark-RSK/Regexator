// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Specifies that a match must occur at the end of the string, or before \n at the end of the string. This class cannot be inherited.
    /// </summary>
    internal sealed class EndOrBeforeEndingNewLine
        : QuantifiablePattern
    {
        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteEndOrBeforeEndingNewLine();
        }
    }
}
