// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NameBackreferenceExpression
        : QuantifiableExpression
    {
        private readonly string _groupName;

        internal NameBackreferenceExpression(string groupName)
            : base()
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
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

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.Backreference; }
        }
    }
}
