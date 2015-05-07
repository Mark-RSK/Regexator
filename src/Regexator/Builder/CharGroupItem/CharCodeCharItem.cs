// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class CharCodeCharItem
        : CharGroupItem
    {
        private readonly int _charCode;

        public CharCodeCharItem(int charCode)
        {
            if (charCode < 0 || charCode > 0xFFFF) { throw new ArgumentOutOfRangeException("charCode"); }
            _charCode = charCode;
        }

        internal override string Content
        {
            get { return Syntax.CharInternal(_charCode, true); }
        }
    }
}
