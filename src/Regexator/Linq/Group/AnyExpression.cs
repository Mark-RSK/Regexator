// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class AnyExpression
        : GroupExpression
    {
        private readonly AnyGroupMode _groupMode;

        internal AnyExpression(IEnumerable<object> content)
            : this(AnyGroupMode.Noncapturing, content)
        {
        }

        internal AnyExpression(AnyGroupMode groupMode, IEnumerable<object> content)
            : base((object)content)
        {
            _groupMode = groupMode;
        }

        internal AnyExpression(params object[] content)
            : this(AnyGroupMode.Noncapturing, content)
        {
        }

        internal AnyExpression(AnyGroupMode groupMode, params object[] content)
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
