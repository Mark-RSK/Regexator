﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class EndOfLineOrBeforeCarriageReturnInvariant
        : Pattern
    {
        private static readonly Pattern _pattern = new NoncapturingGroup(
            new NotAssertBack(Chars.CarriageReturn()) + 
            new Assert(Chars.CarriageReturn().Maybe().EndOfLineInvariant()));

        internal override void WriteTo(PatternWriter writer)
        {
            writer.Write(_pattern);
        }
    }
}
