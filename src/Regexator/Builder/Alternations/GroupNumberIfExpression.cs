// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class GroupNumberIfExpression
        : AlternationConstruct
    {
        private readonly int _groupNumber;

        internal GroupNumberIfExpression(int groupNumber, string yes)
            : this(groupNumber, yes, null)
        {
        }

        internal GroupNumberIfExpression(int groupNumber, string yes, string no)
            : base(yes, no)
        {
            _groupNumber = groupNumber;
        }

        internal GroupNumberIfExpression(int groupNumber, Expression yes)
            : this(groupNumber, yes, null)
        {
        }

        internal GroupNumberIfExpression(int groupNumber, Expression yes, Expression no)
            : base(yes, no)
        {
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
