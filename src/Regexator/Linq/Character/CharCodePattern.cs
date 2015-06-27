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

        public override CharacterGroup Invert()
        {
            return CharacterGroup.Create(_charCode, true);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteInternal(_charCode);
        }

        protected override void WriteGroupContentTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteInternal(_charCode, true);
        }
    }
}
