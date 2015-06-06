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

        public static QuantifiableExpression Options(InlineOptions applyOptions, object content)
        {
            return new GroupOptionsExpression(applyOptions, content);
        }

        public static QuantifiableExpression Options(InlineOptions applyOptions, params object[] content)
        {
            return Options(applyOptions, (object)content);
        }

        public static QuantifiableExpression Options(InlineOptions applyOptions, InlineOptions disableOptions, object content)
        {
            return new GroupOptionsExpression(applyOptions, disableOptions, content);
        }

        public static QuantifiableExpression Options(InlineOptions applyOptions, InlineOptions disableOptions, params object[] content)
        {
            return Options(applyOptions, disableOptions, (object)content);
        }

        public static QuantifiableExpression DisableOptions(InlineOptions options, object content)
        {
            return Options(InlineOptions.None, options, content);
        }

        public static QuantifiableExpression DisableOptions(InlineOptions options, params object[] content)
        {
            return Options(InlineOptions.None, options, content);
        }

        public static QuantifierExpression Maybe(object content)
        {
            return QuantifierGroup(content).Maybe();
        }

        public static QuantifierExpression Maybe(params object[] content)
        {
            return QuantifierGroup(content).Maybe();
        }

        public static QuantifierExpression MaybeMany(object content)
        {
            return QuantifierGroup(content).MaybeMany();
        }

        public static QuantifierExpression MaybeMany(params object[] content)
        {
            return QuantifierGroup(content).MaybeMany();
        }

        public static QuantifierExpression OneMany(object content)
        {
            return QuantifierGroup(content).OneMany();
        }

        public static QuantifierExpression OneMany(params object[] content)
        {
            return QuantifierGroup(content).OneMany();
        }

        public static QuantifierExpression Count(int exactCount, object content)
        {
            return QuantifierGroup(content).Count(exactCount);
        }

        public static QuantifierExpression Count(int exactCount, params object[] content)
        {
            return QuantifierGroup(content).Count(exactCount);
        }

        public static QuantifierExpression CountFrom(int minCount, object content)
        {
            return QuantifierGroup(content).CountFrom(minCount);
        }

        public static QuantifierExpression CountFrom(int minCount, params object[] content)
        {
            return QuantifierGroup(content).CountFrom(minCount);
        }

        public static QuantifierExpression CountRange(int minCount, int maxCount, object content)
        {
            return QuantifierGroup(content).CountRange(minCount, maxCount);
        }

        public static QuantifierExpression CountRange(int minCount, int maxCount, params object[] content)
        {
            return QuantifierGroup(content).CountRange(minCount, maxCount);
        }

        public static QuantifierExpression MaybeCount(int maxCount, object content)
        {
            return QuantifierGroup(content).MaybeCount(maxCount);
        }

        public static QuantifierExpression MaybeCount(int maxCount, params object[] content)
        {
            return QuantifierGroup(content).MaybeCount(maxCount);
        }

        internal static QuantifiableExpression QuantifierGroup(object content)
        {
            return new QuantifierCapturingExpression(content);
        }

        internal static QuantifiableExpression QuantifierGroup(params object[] content)
        {
            return new QuantifierCapturingExpression(new AnyExpression(AnyGroupMode.Capturing, content));
        }
    }
}
