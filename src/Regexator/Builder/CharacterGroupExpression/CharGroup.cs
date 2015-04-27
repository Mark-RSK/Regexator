// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal class CharGroup
        : CharacterGroupExpression
    {
        private readonly char[] _values;

        public CharGroup(params char[] values)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            _values = values;
        }

        public override string Content
        {
            get { return Syntax.Chars(_values, true); }
        }
    }
}
