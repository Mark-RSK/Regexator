// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NonbacktrackingGroup
        : GroupingConstruct
    {
        internal NonbacktrackingGroup(string value)
            : base(value)
        {
        }

        internal NonbacktrackingGroup(Expression expression)
            : base(expression)
        {
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.NonbacktrackingGroupStart;
        }
    }
}
