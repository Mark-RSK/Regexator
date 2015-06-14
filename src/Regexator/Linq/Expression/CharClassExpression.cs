﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharClassExpression
        : CharacterExpression
    {
        private readonly CharClass _value;

        internal CharClassExpression(CharClass value)
        {
            _value = value;
        }

        public override CharGroupExpression ToGroup()
        {
            return new CharClassGroup(_value);
        }

        internal override void WriteContentTo(PatternWriter writer)
        {
            writer.WriteCharClass(_value);
        }
    }
}
