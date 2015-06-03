﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class RangeCharItem
        : CharGroupItem
    {
        private readonly char _first;
        private readonly char _last;

        public RangeCharItem(char first, char last)
        {
            _first = first;
            _last = last;
        }

        internal override string Content
        {
            get { return Syntax.CharRange(_first, _last); }
        }
    }
}
