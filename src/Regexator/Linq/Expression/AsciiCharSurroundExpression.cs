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
            : this(content, surroundChar, surroundChar)
        {
        }

        public AsciiCharSurroundExpression(object content, AsciiChar charBefore, AsciiChar charAfter)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content;
            _charBefore = charBefore;
            _charAfter = charAfter;
        }

        internal override void BuildContent(BuildContext context)
        {
            context.Write(Syntax.Char(_charBefore));

            Expression.BuildContent(_content, context);

            context.Write(Syntax.Char(_charAfter));
        }
    }
}
