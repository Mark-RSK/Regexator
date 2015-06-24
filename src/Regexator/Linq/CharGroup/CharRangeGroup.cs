// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharRangeGroup
        : CharGroup
    {
        private readonly char _firstChar;
        private readonly char _lastChar;
        private readonly bool _negative;

        public CharRangeGroup(char firstChar, char lastChar)
            : this(firstChar, lastChar, false)
        {
        }

        public CharRangeGroup(char firstChar, char lastChar, bool negative)
        {
            if (lastChar < firstChar)
            {
                throw new ArgumentOutOfRangeException("lastChar");
            }

            _firstChar = firstChar;
            _lastChar = lastChar;
            _negative = negative;
        }

        public override bool Negative
        {
            get { return _negative; }
        }

        internal override void WriteContentTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteCharRange(_firstChar, _lastChar);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteCharGroup(_firstChar, _lastChar, Negative);
        }
    }
}
