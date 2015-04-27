// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NumberNamedGroup
        : GroupExpression
    {
        private readonly int _groupName;

        internal NumberNamedGroup(int groupName, string value)
            : base(value)
        {
            if (groupName < 1) { throw new ArgumentOutOfRangeException("groupName"); }
            _groupName = groupName;
        }

        internal NumberNamedGroup(int groupName, Expression expression)
            : base(expression)
        {
            if (groupName < 1) { throw new ArgumentOutOfRangeException("groupName"); }
            _groupName = groupName;
        }

        public int GroupName
        {
            get { return _groupName; }
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.GroupStart(GroupName, context.Settings.IdentifierSeparator);
        }
    }
}
