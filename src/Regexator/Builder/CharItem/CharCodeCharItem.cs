// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class CharCodeCharItem
        : CharItem
    {
        private readonly int[] _charCodes;

        public CharCodeCharItem(params int[] charCodes)
        {
            if (charCodes == null) { throw new ArgumentNullException("charCodes"); }
            _charCodes = charCodes;
        }

        internal override string Content
        {
            get { return Syntax.Chars(_charCodes, true); }
        }
    }
}
