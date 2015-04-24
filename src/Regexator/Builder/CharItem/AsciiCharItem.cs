// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class AsciiCharItem
        : CharItem
    {
        private readonly AsciiChar[] _values;

        public AsciiCharItem(params AsciiChar[] values)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            _values = values;
        }

        internal override string Content
        {
            get { return Syntax.Chars(_values, true); }
        }
    }
}
