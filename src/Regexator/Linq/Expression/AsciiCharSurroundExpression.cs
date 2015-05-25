// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AsciiCharSurroundExpression
        : Expression
    {
        private readonly Expression _expression;
        private readonly AsciiChar _surroundChar;

        public AsciiCharSurroundExpression(string text, AsciiChar surroundChar)
            : this(new TextExpression(text), surroundChar)
        {
        }

        public AsciiCharSurroundExpression(Expression expression, AsciiChar surroundChar)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            _expression = expression;
            _surroundChar = surroundChar;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            yield return Syntax.Char(_surroundChar);

            foreach (var value in _expression.EnumerateValues(context))
            {
                yield return value;
            }

            yield return Syntax.Char(_surroundChar);
        }
    }
}
