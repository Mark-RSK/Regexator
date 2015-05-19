// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Linq
{
    internal sealed class EndOrBeforeEndingNewLine
        : AnchorExpression
    {
        internal override string Value(BuildContext context)
        {
            return Syntax.EndOrBeforeEndingNewLine;
        }
    }
}
