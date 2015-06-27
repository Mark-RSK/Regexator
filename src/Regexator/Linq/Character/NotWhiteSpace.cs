// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NotWhiteSpace
        : CharacterPattern
    {
        public override CharacterGroup Invert()
        {
            return new CharClassCharGroup(CharClass.WhiteSpace);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteNotWhiteSpace();
        }
    }
}
