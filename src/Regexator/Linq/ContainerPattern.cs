// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class ContainerPattern
        : Pattern
    {
        private readonly object _content;

        public ContainerPattern(object content)
        {
            _content = content;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.Write(_content);
        }
    }
}
