// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class NamedGroup
        : GroupingExpression
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
                RegexUtilities.CheckGroupName(name);
            }

            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteNamedGroupInternal(Name, Content);
        }
    }
}
