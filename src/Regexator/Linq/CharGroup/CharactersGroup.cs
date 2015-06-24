// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharactersGroup
        : CharGroup
    {
        private readonly string _characters;
        private readonly bool _negative;

        public CharactersGroup(string characters)
            : this(characters, false)
        {
        }

        public CharactersGroup(string characters, bool negative)
        {
            if (characters == null)
            {
                throw new ArgumentNullException("characters");
            }

            if (characters.Length == 0)
            {
                throw new ArgumentException("Character group cannot be empty.", "characters");
            }

            _characters = characters;
            _negative = negative;
        }

        internal override void WriteContentTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.Write(_characters, true);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteCharGroup(_characters, Negative);
        }

        public override bool Negative
        {
            get { return _negative; }
        }
    }
}
