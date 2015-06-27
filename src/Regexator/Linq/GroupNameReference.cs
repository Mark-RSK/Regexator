// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class GroupNameReference
        : QuantifiablePattern
    {
        private readonly string _groupName;

        public GroupNameReference(string groupName)
            : base()
        {
            RegexUtilities.CheckGroupName(groupName);

            _groupName = groupName;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteGroupReferenceInternal(GroupName);
        }

        public string GroupName
        {
            get { return _groupName; }
        }
    }
}
