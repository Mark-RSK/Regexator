// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NonbacktrackingExpression
        : GroupExpression
    {
        internal NonbacktrackingExpression(string text)
            : base(text)
        {
        }

        internal NonbacktrackingExpression(Expression expression)
            : base(expression)
        {
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.NonbacktrackingGroupStart;
        }
    }
}
