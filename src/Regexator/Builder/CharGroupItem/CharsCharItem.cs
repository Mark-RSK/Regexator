// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class CharsCharItem
        : CharGroupItem
    {
        private readonly string _chars;

        public CharsCharItem(string characters)
        {
            if (characters == null) { throw new ArgumentNullException("characters"); }
            _chars = characters;
        }

        internal override string Content
        {
            get { return Utilities.Escape(_chars, true); }
        }
    }
}
