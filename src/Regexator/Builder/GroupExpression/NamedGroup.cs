// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NamedGroup
        : GroupExpression
    {
        private readonly string _groupName;

        internal NamedGroup(string groupName, string value)
            : base(value)
        {
            if (groupName == null) { throw new ArgumentNullException("groupName"); }
            _groupName = groupName;
        }

        internal NamedGroup(string groupName, Expression expression)
            : base(expression)
        {
            if (groupName == null) { throw new ArgumentNullException("groupName"); }
            _groupName = groupName;
        }

        public string GroupName
        {
            get { return _groupName; }
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.GroupStart(GroupName, context.Settings.IdentifierSeparator);
        }
    }
}
