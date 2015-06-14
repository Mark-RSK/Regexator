// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class RangeCharItem
        : CharGroupItem
    {
        private readonly char _firstChar;
        private readonly char _lastChar;

        public RangeCharItem(char firstChar, char lastChar)
        {
            if (lastChar < firstChar)
            {
                throw new ArgumentOutOfRangeException("lastChar");
            }

            _firstChar = firstChar;
            _lastChar = lastChar;
        }

        protected override void WriteItemContentTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteCharRange(_firstChar, _lastChar);
        }
    }
}
