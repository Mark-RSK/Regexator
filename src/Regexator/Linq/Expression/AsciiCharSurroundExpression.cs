// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AsciiCharSurroundExpression
        : Expression
    {
        private readonly object _content;
        private readonly AsciiChar _charBefore;
        private readonly AsciiChar _charAfter;

        public AsciiCharSurroundExpression(object content, AsciiChar surroundChar)
            : this(surroundChar, content, surroundChar)
        {
        }

        public AsciiCharSurroundExpression(AsciiChar charBefore, object content, AsciiChar charAfter)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _charBefore = charBefore;
            _content = content;
            _charAfter = charAfter;
        }

        internal override void BuildContent(PatternWriter writer)
        {
            writer.Write(Syntax.Char(_charBefore));

            Expression.Build(_content, writer);

            writer.Write(Syntax.Char(_charAfter));
        }
    }
}
