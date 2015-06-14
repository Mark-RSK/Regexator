// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharCodeExpression
        : CharacterExpression
    {
        private readonly int _charCode;

        internal CharCodeExpression(int charCode)
        {
            if (charCode < 0 || charCode > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("charCode");
            }

            _charCode = charCode;
        }

        public override CharGroupExpression ToGroup()
        {
            return new CharCodeGroup(_charCode);
        }

        internal override void BuildContent(PatternWriter writer)
        {
            writer.WriteInternal(_charCode);
        }
    }
}
