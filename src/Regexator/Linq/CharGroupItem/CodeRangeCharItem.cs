// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CodeRangeCharItem
        : CharGroupItem
    {
        private readonly int _first;
        private readonly int _last;

        public CodeRangeCharItem(int firstCharCode, int lastCharCode)
        {
            if (firstCharCode < 0 || firstCharCode > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("firstCharCode");
            }

            if (lastCharCode < 0 || lastCharCode > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("lastCharCode");
            }

            _first = firstCharCode;
            _last = lastCharCode;
        }

        internal override string Content
        {
            get { return Syntax.RangeInternal(_first, _last); }
        }
    }
}
