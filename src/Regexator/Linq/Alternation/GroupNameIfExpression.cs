// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class GroupNameIfExpression
        : AlternationExpression
    {
        private readonly string _groupName;

        internal GroupNameIfExpression(string groupName, object trueContent)
            : this(groupName, trueContent, null)
        {
        }

        internal GroupNameIfExpression(string groupName, object trueContent, object falseContent)
            : base(trueContent, falseContent)
        {
            RegexUtilities.CheckGroupName(groupName);

            _groupName = groupName;
        }

        public string GroupName
        {
            get { return _groupName; }
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteIfGroupInternal(GroupName, TrueContent, FalseContent);
        }
    }
}
