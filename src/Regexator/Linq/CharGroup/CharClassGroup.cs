// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharClassGroup
        : CharGroupExpression
    {
        private readonly CharClass _value;

        public CharClassGroup(CharClass value)
        {
            _value = value;
        }

        internal override void WriteContentTo(PatternWriter writer)
        {
            writer.WriteCharClass(_value);
        }
    }
}
