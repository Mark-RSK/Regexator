// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AnyGroup
        : GroupingPattern
    {
        private readonly GroupMode _groupMode;

        public AnyGroup(object content)
            : this(content, GroupMode.NoncapturingGroup)
        {
        }

        public AnyGroup(object content, GroupMode groupMode)
            : base(content)
        {
            _groupMode = groupMode;
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendAny(Content, GroupMode);
        }

        public GroupMode GroupMode
        {
            get { return _groupMode; }
        }
    }
}
