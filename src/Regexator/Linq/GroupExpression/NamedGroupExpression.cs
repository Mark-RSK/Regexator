// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NamedGroupExpression
        : GroupExpression
    {
        private readonly string _groupName;

        internal NamedGroupExpression(string groupName, string text)
            : this(groupName, text, true)
        {
        }

        internal NamedGroupExpression(string groupName, string text, bool checkGroupName)
            : base(text)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (checkGroupName)
            {
                RegexUtilities.CheckGroupName(groupName);
            }
            _groupName = groupName;
        }

        internal NamedGroupExpression(string groupName, Expression expression)
            : this(groupName, expression, true)
        {
        }

        internal NamedGroupExpression(string groupName, Expression expression, bool checkGroupName)
            : base(expression)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
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
