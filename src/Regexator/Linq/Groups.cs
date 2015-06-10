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

        public static QuantifiableExpression Capturing()
        {
            return new CapturingExpression(string.Empty);
        }

        public static QuantifiableExpression Capturing(object content)
        {
            return new CapturingExpression(content);
        }

        public static QuantifiableExpression Capturing(params object[] content)
        {
            return Capturing((object)content);
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

        public static QuantifiedExpression Maybe(object content)
        {
            return QuantifierGroup(content).Maybe();
        }

        public static QuantifiedExpression Maybe(params object[] content)
        {
            return Maybe((object)content);
        }

        public static QuantifiedExpression MaybeMany(object content)
        {
            return QuantifierGroup(content).MaybeMany();
        }

        public static QuantifiedExpression MaybeMany(params object[] content)
        {
            return MaybeMany((object)content);
        }

        public static QuantifiedExpression OneMany(object content)
        {
            return QuantifierGroup(content).OneMany();
        }

        public static QuantifiedExpression OneMany(params object[] content)
        {
            return OneMany((object)content);
        }

        public static QuantifiedExpression Count(int exactCount, object content)
        {
            return QuantifierGroup(content).Count(exactCount);
        }

        public static QuantifiedExpression Count(int exactCount, params object[] content)
        {
            return Count(exactCount, (object)content);
        }

        public static QuantifiedExpression CountFrom(int minCount, object content)
        {
            return QuantifierGroup(content).CountFrom(minCount);
        }

        public static QuantifiedExpression CountFrom(int minCount, params object[] content)
        {
            return CountFrom(minCount, (object)content);
        }

        public static QuantifiedExpression CountRange(int minCount, int maxCount, object content)
        {
            return QuantifierGroup(content).CountRange(minCount, maxCount);
        }

        public static QuantifiedExpression CountRange(int minCount, int maxCount, params object[] content)
        {
            return CountRange(minCount, maxCount, (object)content);
        }

        public static QuantifiedExpression MaybeCount(int maxCount, object content)
        {
            return QuantifierGroup(content).MaybeCount(maxCount);
        }

        public static QuantifiedExpression MaybeCount(int maxCount, params object[] content)
        {
            return MaybeCount(maxCount, (object)content);
        }

        internal static QuantifiableExpression QuantifierGroup(object content)
        {
            return new QuantifierGroupExpression(content);
        }
    }
}
