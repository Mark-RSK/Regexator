// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

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

        public override CharacterGroup Invert()
        {
            return new AsciiCharGroup(_value, true);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.Write(_value);
        }

        protected override void WriteGroupContentTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.Write(_value, true);
        }
    }
}
