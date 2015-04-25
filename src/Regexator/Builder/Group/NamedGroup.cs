// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NamedGroup
        : GroupingConstruct
    {
        private readonly string _name;

        internal NamedGroup(string name, string value)
            : base(value)
        {
            if (name == null) { throw new ArgumentNullException("name"); }
            _name = name;
        }

        internal NamedGroup(string name, Expression expression)
            : base(expression)
        {
            if (name == null) { throw new ArgumentNullException("name"); }
            _name = name;
        }

        public string Name
        {
            get { return _name; }
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.GroupStart(Name, context.Settings.IdentifierSeparator);
        }
    }
}
