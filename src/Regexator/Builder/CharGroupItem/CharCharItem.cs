// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class CharCharItem
        : CharGroupItem
    {
        private readonly char _value;

        public CharCharItem(char value)
        {
            _value = value;
        }

        internal override string Content
        {
            get { return Syntax.Char(_value, true); }
        }
    }
}
