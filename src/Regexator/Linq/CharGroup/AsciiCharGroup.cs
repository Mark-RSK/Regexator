// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AsciiCharGroup
        : CharGroupExpression
    {
        private readonly AsciiChar _value;
        private readonly bool _negative;

        public AsciiCharGroup(AsciiChar value)
            : this(value, false)
        {
        }

        public AsciiCharGroup(AsciiChar value, bool negative)
        {
            _value = value;
            _negative = negative;
        }

        public override bool Negative
        {
            get { return _negative; }
        }

        internal override void BuildContent(PatternWriter writer)
        {
            writer.Write(Syntax.Char(_value, true));
        }
    }
}
