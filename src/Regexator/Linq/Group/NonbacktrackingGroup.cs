// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class NonbacktrackingGroup
        : GroupingExpression
    {
        public NonbacktrackingGroup(object content)
            : base(content)
        {
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteNonbacktrackingGroup(Content);
        }
    }
}
