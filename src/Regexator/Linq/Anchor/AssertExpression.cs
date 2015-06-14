// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AssertExpression
        : GroupExpression
    {
        internal AssertExpression(object content)
            : base(content)
        {
        }

        internal override void BuildOpening(PatternContext context)
        {
            context.Write(Syntax.AssertStart);
        }
    }
}