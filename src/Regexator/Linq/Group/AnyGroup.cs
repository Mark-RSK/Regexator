// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AnyGroup
        : GroupingPattern
    {
        private readonly GroupMode _groupMode;

        public AnyGroup(IEnumerable<object> content)
            : this(GroupMode.Noncapturing, content)
        {
        }

        internal AnyGroup(GroupMode groupMode, IEnumerable<object> content)
            : base((object)content)
        {
            _groupMode = groupMode;
        }

        public AnyGroup(params object[] content)
            : this(GroupMode.Noncapturing, content)
        {
        }

        internal AnyGroup(GroupMode groupMode, params object[] content)
            : base((object)content)
        {
            _groupMode = groupMode;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteAny(Content, GroupMode);
        }

        internal GroupMode GroupMode
        {
            get { return _groupMode; }
        }
    }
}
