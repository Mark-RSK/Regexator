// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NamedGroupSubstitution
        : Substitution
    {
        private readonly string _groupName;

        internal NamedGroupSubstitution(string groupName)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            RegexUtilities.CheckGroupName(groupName);
            _groupName = groupName;
        }

        public string GroupName
        {
            get { return _groupName; }
        }

        internal override string Value
        {
            get { return Syntax.SubstituteNamedGroupInternal(GroupName); }
        }
    }
}