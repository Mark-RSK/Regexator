// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AnyGroup
        : GroupPattern
    {
        private readonly AnyGroupMode _groupMode;

        public AnyGroup(IEnumerable<object> content)
            : this(AnyGroupMode.Noncapturing, content)
        {
        }

        internal AnyGroup(AnyGroupMode groupMode, IEnumerable<object> content)
            : base((object)content)
        {
            _groupMode = groupMode;
        }

        public AnyGroup(params object[] content)
            : this(AnyGroupMode.Noncapturing, content)
        {
        }

        internal AnyGroup(AnyGroupMode groupMode, params object[] content)
            : base((object)content)
        {
            _groupMode = groupMode;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteAny(Content, GroupMode);
        }

        internal AnyGroupMode GroupMode
        {
            get { return _groupMode; }
        }
    }
}
