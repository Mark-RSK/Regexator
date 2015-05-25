// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AsciiCharSurroundExpression
        : Expression
    {
        private readonly Expression _expression;
        private readonly AsciiChar _beforeChar;
        private readonly AsciiChar _afterChar;

        public AsciiCharSurroundExpression(string text, AsciiChar surroundChar)
            : this(new TextExpression(text), surroundChar, surroundChar)
        {
        }

        public AsciiCharSurroundExpression(string text, AsciiChar beforeChar, AsciiChar afterChar)
            : this(new TextExpression(text), beforeChar, afterChar)
        {
        }

        public AsciiCharSurroundExpression(Expression expression, AsciiChar surroundChar)
            : this(expression, surroundChar, surroundChar)
        {
        }

        public AsciiCharSurroundExpression(Expression expression, AsciiChar beforeChar, AsciiChar afterChar)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            _expression = expression;
            _beforeChar = beforeChar;
            _afterChar = afterChar;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            yield return Syntax.Char(_beforeChar);

            foreach (var value in _expression.EnumerateValues(context))
            {
                yield return value;
            }

            yield return Syntax.Char(_afterChar);
        }
    }
}
