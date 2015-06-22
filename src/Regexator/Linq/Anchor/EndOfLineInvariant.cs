// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class EndOfLineInvariant
        : QuantifiablePattern
    {
        private static readonly QuantifiablePattern _pattern = new GroupOptions(InlineOptions.Multiline, new EndOfLine());

        internal override void WriteTo(PatternWriter writer)
        {
            writer.Write(_pattern);
        }
    }
}
