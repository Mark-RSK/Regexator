// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal class UnicodeBlockGroup
        : CharGroupExpression
    {
        private readonly UnicodeBlock[] _values;

        public UnicodeBlockGroup(params UnicodeBlock[] values)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            _values = values;
        }

        public override string Content
        {
            get { return Syntax.UnicodeBlocks(_values); }
        }
    }
}
