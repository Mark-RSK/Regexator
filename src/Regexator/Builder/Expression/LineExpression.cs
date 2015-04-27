// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class LineExpression
        : EnclosingExpression
    {
        internal LineExpression(Expression expression)
            : base(expression)
        {
        }

        protected override IEnumerable<string> EnumerateStart(BuildContext context)
        {
            yield return Syntax.StartOfLine;
        }

        protected override IEnumerable<string> EnumerateEnd(BuildContext context)
        {
            yield return Syntax.EndOfLine;
        }
    }
}
