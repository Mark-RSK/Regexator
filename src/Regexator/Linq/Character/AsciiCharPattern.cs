﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AsciiCharPattern
        : CharacterPattern
    {
        private readonly AsciiChar _value;

        internal AsciiCharPattern(AsciiChar value)
        {
            _value = value;
        }

        public override CharGroup ToGroup()
        {
            return new AsciiCharGroup(_value);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.Write(_value);
        }
    }
}