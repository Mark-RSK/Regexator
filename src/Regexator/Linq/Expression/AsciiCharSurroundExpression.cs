// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AsciiCharSurroundExpression
        : Expression
    {
        private readonly object _value;
        private readonly AsciiChar _beforeChar;
        private readonly AsciiChar _afterChar;

        public AsciiCharSurroundExpression(object value, AsciiChar surroundChar)
            : this(value, surroundChar, surroundChar)
        {
        }

        public AsciiCharSurroundExpression(object value, AsciiChar charBefore, AsciiChar charAfter)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            _value = value;
            _beforeChar = charBefore;
            _afterChar = charAfter;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            yield return Syntax.Char(_beforeChar);

            foreach (var value in Expression.EnumerateValues(_value, context))
            {
                yield return value;
            }

            yield return Syntax.Char(_afterChar);
        }
    }
}
