// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharsCharItem
        : CharGroupItem
    {
        private readonly string _chars;

        public CharsCharItem(string chars)
        {
            if (chars == null)
            {
                throw new ArgumentNullException("chars");
            }

            _chars = chars;
        }

        internal override string Content
        {
            get { return RegexUtilities.Escape(_chars, true); }
        }
    }
}
