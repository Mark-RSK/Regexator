// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharCodePattern
        : CharacterPattern
    {
        private readonly int _charCode;

        internal CharCodePattern(int charCode)
        {
            if (charCode < 0 || charCode > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("charCode");
            }

            _charCode = charCode;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteInternal(_charCode);
        }
    }
}
