// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class TextCharItem
        : CharGroupItem
    {
        private readonly string _chars;

        public TextCharItem(string chars)
        {
            if (chars == null) { throw new ArgumentNullException("chars"); }
            _chars = chars;
        }

        internal override string Content
        {
            get { return Utilities.Escape(_chars, true); }
        }
    }
}
