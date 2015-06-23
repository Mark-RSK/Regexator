// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NewLine
        : QuantifiablePattern
    {
        private static readonly Pattern _pattern = Patterns.CarriageReturn().Maybe().Linefeed().AsNoncapturingGroup();

        public NewLine()
        {
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.Write(_pattern);
        }
    }
}
