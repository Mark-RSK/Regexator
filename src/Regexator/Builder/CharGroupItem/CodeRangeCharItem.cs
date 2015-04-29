﻿// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class CodeRangeCharItem
        : CharGroupItem
    {
        private readonly int _first;
        private readonly int _last;

        public CodeRangeCharItem(int first, int last)
        {
            _first = first;
            _last = last;
        }

        internal override string Content
        {
            get { return Syntax.Range(_first, _last); }
        }
    }
}