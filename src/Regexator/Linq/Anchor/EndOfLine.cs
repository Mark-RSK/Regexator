﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class EndOfLine
        : AnchorExpression
    {
        internal override string Value(PatternWriter writer)
        {
            return Syntax.EndOfLine;
        }
    }
}
