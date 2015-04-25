// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NumberNamedGroup
        : GroupingConstruct
    {
        private readonly int _name;

        internal NumberNamedGroup(int name, string value)
            : base(value)
        {
            _name = name;
        }

        internal NumberNamedGroup(int name, Expression expression)
            : base(expression)
        {
            _name = name;
        }

        public int Name
        {
            get { return _name; }
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.GroupStart(Name, context.Settings.IdentifierSeparator);
        }
    }
}
