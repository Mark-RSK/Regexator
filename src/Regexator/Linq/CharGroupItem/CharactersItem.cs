// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharactersItem
        : CharGroupItem
    {
        private readonly string _characters;

        public CharactersItem(string characters)
        {
            if (characters == null)
            {
                throw new ArgumentNullException("characters");
            }

            _characters = characters;
        }

        internal override void BuildItemContent(PatternWriter writer)
        {
            writer.Write(_characters, true);
        }
    }
}
