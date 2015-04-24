// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public class CodeRangeGroup
        : CharGroup
    {
        private readonly int _first;
        private readonly int _last;

        public CodeRangeGroup(int first, int last)
        {
            _first = first;
            _last = last;
        }

        public override string Content
        {
            get { return Syntax.Char(_first, true) + "-" + Syntax.Char(_last, true); }
        }
    }
}
