﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Specifies that the match must occur at the beginning of the string (or line if the multiline option is applied). This class cannot be inherited.
    /// </summary>
    internal sealed class StartOfLine
        : QuantifiablePattern
    {
        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendStartOfLine();
        }
    }
}
