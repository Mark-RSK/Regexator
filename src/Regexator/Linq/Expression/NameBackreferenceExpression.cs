// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class NameBackreferenceExpression
        : QuantifiableExpression
    {
        private readonly string _groupName;

        internal NameBackreferenceExpression(string groupName)
            : base()
        {
            RegexUtilities.CheckGroupName(groupName);

            _groupName = groupName;
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.Backreference(GroupName, context.Settings.IdentifierBoundary);
        }

        public string GroupName
        {
            get { return _groupName; }
        }
    }
}
