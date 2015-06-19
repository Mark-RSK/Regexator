// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class IfGroup
        : AlternationPattern
    {
        private readonly string _groupName;

        public IfGroup(string groupName, object trueContent)
            : this(groupName, trueContent, null)
        {
        }

        public IfGroup(string groupName, object trueContent, object falseContent)
            : base(trueContent, falseContent)
        {
            RegexUtilities.CheckGroupName(groupName);

            _groupName = groupName;
        }

        public IfGroup(int groupNumber, object trueContent)
            : this(groupNumber, trueContent, null)
        {
        }

        public IfGroup(int groupNumber, object trueContent, object falseContent)
            : base(trueContent, falseContent)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            _groupName = groupNumber.ToString(CultureInfo.InvariantCulture);
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
