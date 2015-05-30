// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class GroupNumberIfExpression
        : AlternationExpression
    {
        private readonly int _groupNumber;

        internal GroupNumberIfExpression(int groupNumber, object yes)
            : this(groupNumber, yes, null)
        {
        }

        internal GroupNumberIfExpression(int groupNumber, object yes, object no)
            : base(yes, no)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            _groupNumber = groupNumber;
        }

        public int GroupNumber
        {
            get { return _groupNumber; }
        }

        protected override IEnumerable<string> EnumerateCondition(BuildContext context)
        {
            yield return Syntax.IfGroupCondition(GroupNumber);
        }
    }
}