// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class CharsCharItem
        : CharItem
    {
        private readonly char[] _chars;

        public CharsCharItem(params char[] chars)
        {
            if (chars == null) { throw new ArgumentNullException("chars"); }
            _chars = chars;
        }

        internal override string Content
        {
            get { return Syntax.Chars(_chars, true); }
        }
    }
}
