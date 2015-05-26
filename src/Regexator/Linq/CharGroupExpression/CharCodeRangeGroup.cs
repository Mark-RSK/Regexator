﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class CharCodeRangeGroup
        : CharGroupExpression
    {
        private readonly int _first;
        private readonly int _last;

        public CharCodeRangeGroup(int firstCharCode, int lastCharCode)
        {
            _first = firstCharCode;
            _last = lastCharCode;
        }

        public override string Content
        {
            get { return Syntax.Range(_first, _last); }
        }
    }
}