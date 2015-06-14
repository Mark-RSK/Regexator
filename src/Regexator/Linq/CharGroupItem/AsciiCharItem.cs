// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AsciiCharItem
        : CharGroupItem
    {
        private readonly AsciiChar _value;

        public AsciiCharItem(AsciiChar value)
        {
            _value = value;
        }

        internal override void BuildItemContent(PatternContext context)
        {
            context.Write(Syntax.Char(_value, true));
        }
    }
}
