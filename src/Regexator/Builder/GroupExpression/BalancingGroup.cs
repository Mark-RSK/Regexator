// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class BalancingGroup
        : GroupExpression
    {
        private readonly string _name1;
        private readonly string _name2;

        internal BalancingGroup(string name1, string name2, string value)
            : base(value)
        {
            if (name1 == null) { throw new ArgumentNullException("name1"); }
            if (name2 == null) { throw new ArgumentNullException("name2"); }
            _name1 = name1;
            _name2 = name2;
        }

        internal BalancingGroup(string name1, string name2, Expression expression)
            : base(expression)
        {
            if (name1 == null) { throw new ArgumentNullException("name1"); }
            if (name2 == null) { throw new ArgumentNullException("name2"); }
            _name1 = name1;
            _name2 = name2;
        }

        public string Name1
        {
            get { return _name1; }
        }

        public string Name2
        {
            get { return _name2; }
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.BalancingGroupStart(Name1, Name2, context.Settings.IdentifierBoundary);
        }
    }
}