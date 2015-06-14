// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharClassCharItem
        : CharGroupItem
    {
        private readonly CharClass _value;

        public CharClassCharItem(CharClass value)
        {
            _value = value;
        }

        protected override void WriteItemContentTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteCharClass(_value);
        }
    }
}
