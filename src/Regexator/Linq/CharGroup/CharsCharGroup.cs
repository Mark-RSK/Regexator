// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharsCharGroup
        : CharGroupExpression
    {
        private readonly string _chars;
        private readonly bool _negative;

        public CharsCharGroup(string chars)
            : this(chars, false)
        {
        }

        public CharsCharGroup(string chars, bool negative)
        {
            if (chars == null)
            {
                throw new ArgumentNullException("chars");
            }

            _chars = chars;
            _negative = negative;
        }

        public override bool Negative
        {
            get { return _negative; }
        }

        public override string Content
        {
            get { return RegexUtilities.Escape(_chars, true); }
        }
    }
}
