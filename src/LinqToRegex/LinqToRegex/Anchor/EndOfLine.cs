﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Specifies that the match must occur at the end of the string (or line if the multiline option is applied). End of line is defined as the position before a linefeed. This class cannot be inherited.
    /// </summary>
    internal sealed class EndOfLine
        : QuantifiablePattern
    {
        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendEndOfLine();
        }
    }
}