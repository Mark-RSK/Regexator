// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    [Flags]
    public enum InlineOptions
    {
        None = 0,
        IgnoreCase = 1,
        Multiline = 2,
        ExplicitCapture = 4,
        Singleline = 16,
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "Whitespace")]
        IgnorePatternWhitespace = 32
    }
}
