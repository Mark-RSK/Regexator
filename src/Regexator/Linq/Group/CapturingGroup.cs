// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class CapturingGroup
        : GroupPattern
    {
        public CapturingGroup()
            : this(string.Empty)
        {
        }

        public CapturingGroup(object content)
            : base(content)
        {
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteCapturingGroup(Content);
        }
    }
}
