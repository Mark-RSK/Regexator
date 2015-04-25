// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NameBackreference
        : QuantifiableExpression
    {
        private readonly string _groupName;

        internal NameBackreference(string groupName)
            : base()
        {
            if (groupName == null) { throw new ArgumentNullException("groupName"); }
            _groupName = groupName;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            yield return Syntax.Backreference(GroupName, context.Settings.IdentifierSeparator);
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