// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class IfGroup
        : QuantifiablePattern
    {
        private readonly string _groupName;
        private readonly object _trueContent;
        private readonly object _falseContent;

        public IfGroup(string groupName, object trueContent)
            : this(groupName, trueContent, null)
        {
        }

        public IfGroup(string groupName, object trueContent, object falseContent)
        {
            RegexUtilities.CheckGroupName(groupName);

            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            _groupName = groupName;
            _trueContent = trueContent;
            _falseContent = falseContent;
        }

        public IfGroup(int groupNumber, object trueContent)
            : this(groupNumber, trueContent, null)
        {
        }

        public IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            _groupName = groupNumber.ToString(CultureInfo.InvariantCulture);
            _trueContent = trueContent;
            _falseContent = falseContent;
        }

        public string GroupName
        {
            get { return _groupName; }
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteIfGroupInternal(GroupName, _trueContent, _falseContent);
        }
    }
}
