// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class LazyQuantifiedExpression
        : Expression
    {
        private QuantifiedExpression _expression;

        public LazyQuantifiedExpression(QuantifiedExpression expression)
        {
            _expression = expression;
        }

        internal override void BuildContent(BuildContext context)
        {
            _expression.BuildContent(context);

            context.Write(Syntax.Lazy);
        }
    }
}
