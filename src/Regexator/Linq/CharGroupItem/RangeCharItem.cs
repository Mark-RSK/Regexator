// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class RangeCharItem
        : CharGroupItem
    {
        private readonly char _firstChar;
        private readonly char _lastChar;

        public RangeCharItem(char firstChar, char lastChar)
        {
            _firstChar = firstChar;
            _lastChar = lastChar;
        }

        internal override string Content
        {
            get { return Syntax.CharRange(_firstChar, _lastChar); }
        }
    }
}
