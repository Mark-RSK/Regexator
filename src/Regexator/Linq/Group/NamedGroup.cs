// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NamedGroup
        : GroupingPattern
    {
        private readonly string _name;

        public NamedGroup(string name, object content)
            : this(name, content, true)
        {
        }

        public NamedGroup(string name, object content, bool checkGroupName)
            : base(content)
        {
            if (checkGroupName)
            {
                RegexUtility.CheckGroupName(name);
            }

            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendNamedGroupInternal(Name, Content);
        }
    }
}
