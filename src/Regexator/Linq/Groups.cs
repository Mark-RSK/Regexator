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

        public static QuantifiableExpression Enclose(object content)
        {
            return new NoncapturingExpression(content);
        }

        public static QuantifiableExpression Enclose(params object[] content)
        {
            return Enclose((object)content);
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

        public static QuantifierExpression Maybe(object content)
        {
            return QuantifierGroup(content).Maybe();
        }

        public static QuantifierExpression Maybe(params object[] content)
        {
            return Maybe((object)content);
        }

        public static QuantifierExpression MaybeMany(object content)
        {
            return QuantifierGroup(content).MaybeMany();
        }

        public static QuantifierExpression MaybeMany(params object[] content)
        {
            return MaybeMany((object)content);
        }

        public static QuantifierExpression OneMany(object content)
        {
            return QuantifierGroup(content).OneMany();
        }

        public static QuantifierExpression OneMany(params object[] content)
        {
            return OneMany((object)content);
        }

        public static QuantifierExpression Count(int exactCount, object content)
        {
            return QuantifierGroup(content).Count(exactCount);
        }

        public static QuantifierExpression Count(int exactCount, params object[] content)
        {
            return Count(exactCount, (object)content);
        }

        public static QuantifierExpression CountFrom(int minCount, object content)
        {
            return QuantifierGroup(content).CountFrom(minCount);
        }

        public static QuantifierExpression CountFrom(int minCount, params object[] content)
        {
            return CountFrom(minCount, (object)content);
        }

        public static QuantifierExpression CountRange(int minCount, int maxCount, object content)
        {
            return QuantifierGroup(content).CountRange(minCount, maxCount);
        }

        public static QuantifierExpression CountRange(int minCount, int maxCount, params object[] content)
        {
            return CountRange(minCount, maxCount, (object)content);
        }

        public static QuantifierExpression CountTo(int maxCount, object content)
        {
            return QuantifierGroup(content).CountTo(maxCount);
        }

        public static QuantifierExpression CountTo(int maxCount, params object[] content)
        {
            return CountTo(maxCount, (object)content);
        }

        internal static QuantifiableExpression QuantifierGroup(object content)
        {
            return new QuantifierGroupExpression(content);
        }

        public static QuantifiableExpression GroupReference(int groupNumber)
        {
            return new NumberedGroupReferenceExpression(groupNumber);
        }

        public static QuantifiableExpression GroupReference(string groupName)
        {
            return new NamedGroupReferenceExpression(groupName);
        }
    }
}
