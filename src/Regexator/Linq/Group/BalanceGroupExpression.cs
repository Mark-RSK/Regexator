// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class BalanceGroupExpression
        : GroupExpression
    {
        private readonly string _name1;
        private readonly string _name2;

        public BalanceGroupExpression(string name1, string name2, object content)
            : base(content)
        {
            RegexUtilities.CheckGroupName(name1, "name1");
            RegexUtilities.CheckGroupName(name2, "name2");

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

        internal override void BuildOpening(PatternWriter writer)
        {
            writer.Write(Syntax.BalanceGroupStart(Name1, Name2, writer.Settings.IdentifierBoundary));
        }
    }
}