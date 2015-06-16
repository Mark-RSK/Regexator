// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Groups
    {
        public static QuantifiableExpression NamedGroup(string name, object content)
        {
            return new NamedGroupExpression(name, content);
        }

        public static QuantifiableExpression NamedGroup(string name, params object[] content)
        {
            return NamedGroup(name, (object)content);
        }

        public static QuantifiableExpression Group()
        {
            return new CapturingExpression(string.Empty);
        }

        public static QuantifiableExpression Group(object content)
        {
            return new CapturingExpression(content);
        }

        public static QuantifiableExpression Group(params object[] content)
        {
            return Group((object)content);
        }

        public static QuantifiableExpression Noncapturing(object content)
        {
            return new NoncapturingExpression(content);
        }

        public static QuantifiableExpression Noncapturing(params object[] content)
        {
            return Noncapturing((object)content);
        }

        public static QuantifiableExpression BalanceGroup(string name1, string name2, object content)
        {
            return new BalanceGroupExpression(name1, name2, content);
        }

        public static QuantifiableExpression BalanceGroup(string name1, string name2, params object[] content)
        {
            return BalanceGroup(name1, name2, (object)content);
        }

        public static QuantifiableExpression Nonbacktracking(object content)
        {
            return new NonbacktrackingExpression(content);
        }

        public static QuantifiableExpression Nonbacktracking(params object[] content)
        {
            return Nonbacktracking((object)content);
        }
    }
}
