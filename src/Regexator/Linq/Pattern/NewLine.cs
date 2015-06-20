﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class NewLine
        : QuantifiablePattern
    {
        private static readonly Pattern _pattern = Chars.CarriageReturn().Maybe().Linefeed().AsNoncapturing();

        public NewLine()
        {
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.Write(_pattern);
        }
    }
}
