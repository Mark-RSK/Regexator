// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class GroupNameIfExpression
        : AlternationExpression
    {
        private readonly string _groupName;

        internal GroupNameIfExpression(string groupName, object yes)
            : this(groupName, yes, null)
        {
        }

        internal GroupNameIfExpression(string groupName, object yes, object no)
            : base(yes, no)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }

            _groupName = groupName;
        }

        public string GroupName
        {
            get { return _groupName; }
        }

        protected override IEnumerable<string> EnumerateCondition(BuildContext context)
        {
            yield return Syntax.IfGroupCondition(GroupName);
        }
    }
}