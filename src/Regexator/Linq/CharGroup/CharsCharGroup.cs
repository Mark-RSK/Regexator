// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharsCharGroup
        : CharGroupExpression
    {
        private readonly string _characters;
        private readonly bool _negative;

        public CharsCharGroup(string characters)
            : this(characters, false)
        {
        }

        public CharsCharGroup(string characters, bool negative)
        {
            if (characters == null)
            {
                throw new ArgumentNullException("characters");
            }

            _characters = characters;
            _negative = negative;
        }

        public override bool Negative
        {
            get { return _negative; }
        }

        public override string Content
        {
            get { return RegexUtilities.Escape(_characters, true); }
        }
    }
}
