// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharPattern
        : CharacterPattern
    {
        private readonly char _value;

        internal CharPattern(char value)
        {
            _value = value;
        }

        public override CharGroup ToGroup()
        {
            return new CharacterGroup(_value);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.Write(_value);
        }
    }
}
