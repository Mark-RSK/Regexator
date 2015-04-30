// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class StartOfLine
        : AnchorExpression
    {
        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            if (context.Settings.UseInvariant)
            {
                foreach (var value in Anchors.StartOfLineInvariant().EnumerateContent(context))
                {
                    yield return value;
                }
            }
            else
            {
                yield return Syntax.StartOfLine;
            }
        }
    }
}
