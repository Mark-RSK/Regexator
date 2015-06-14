// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CharGroup
        : CharGroupExpression
    {
        private readonly char _value;
        private readonly bool _negative;

        public CharGroup(char value)
            : this(value, false)
        {
        }

        public CharGroup(char value, bool negative)
        {
            _value = value;
            _negative = negative;
        }

        public override bool Negative
        {
            get { return _negative; }
        }

        internal override void WriteContentTo(PatternWriter writer)
        {
            writer.Write(_value, true);
        }
    }
}
