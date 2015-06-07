// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NamedGroupExpression
        : GroupExpression
    {
        private readonly string _groupName;

        public NamedGroupExpression(string groupName, object content)
            : this(groupName, content, true)
        {
        }

        public NamedGroupExpression(string groupName, object content, bool checkGroupName)
            : base(content)
        {
            if (checkGroupName)
            {
                RegexUtilities.CheckGroupName(groupName);
            }

            _groupName = groupName;
        }

        public string GroupName
        {
            get { return _groupName; }
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.GroupStart(GroupName, context.Settings.IdentifierBoundary);
        }
    }
}
