﻿// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal class CharRangeGroup
        : CharGroupExpression
    {
        private readonly char _first;
        private readonly char _last;

        public CharRangeGroup(char first, char last)
        {
            _first = first;
            _last = last;
        }

        public override string Content
        {
            get { return Syntax.Range(_first, _last); }
        }
    }
}