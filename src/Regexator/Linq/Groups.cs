// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Groups
    {
        public static QuantifiableExpression NamedGroup(string name, object content)
        {
            return new NamedGroupExpression(name, content);
        }

        public static QuantifiableExpression NamedGroup(string name, params object[] values)
        {
            return new NamedGroupExpression(name, new AnyExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression Capturing()
        {
            return new CapturingExpression(string.Empty);
        }

        public static QuantifiableExpression Capturing(object content)
        {
            return new CapturingExpression(content);
        }

        public static QuantifiableExpression Capturing(params object[] values)
        {
            return new CapturingExpression(new AnyExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression Noncapturing(object content)
        {
            return new NoncapturingExpression(content);
        }

        public static QuantifiableExpression Noncapturing(params object[] values)
        {
            return new NoncapturingExpression(new AnyExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression BalanceGroup(string name1, string name2, object content)
        {
            return new BalanceGroupExpression(name1, name2, content);
        }

        public static QuantifiableExpression BalanceGroup(string name1, string name2, params object[] values)
        {
            return new BalanceGroupExpression(name1, name2, new AnyExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression Nonbacktracking(object content)
        {
            return new NonbacktrackingExpression(content);
        }

        public static QuantifiableExpression Nonbacktracking(params object[] values)
        {
            return new NonbacktrackingExpression(new AnyExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, object content)
        {
            return new GroupOptionsExpression(applyOptions, content);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, params object[] values)
        {
            return new GroupOptionsExpression(applyOptions, new AnyExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, object content)
        {
            return new GroupOptionsExpression(applyOptions, disableOptions, content);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, params object[] values)
        {
            return new GroupOptionsExpression(applyOptions, disableOptions, new AnyExpression(AnyGroupMode.None, values));
        }

        public static QuantifierExpression Maybe(object content)
        {
            return QuantifierGroup(content).Maybe();
        }

        public static QuantifierExpression Maybe(params object[] values)
        {
            return QuantifierGroup(new AnyExpression(AnyGroupMode.Capturing, values)).Maybe();
        }

        public static QuantifierExpression MaybeMany(object content)
        {
            return QuantifierGroup(content).MaybeMany();
        }

        public static QuantifierExpression MaybeMany(params object[] values)
        {
            return QuantifierGroup(new AnyExpression(AnyGroupMode.Capturing, values)).MaybeMany();
        }

        public static QuantifierExpression OneMany(object content)
        {
            return QuantifierGroup(content).OneMany();
        }

        public static QuantifierExpression OneMany(params object[] values)
        {
            return QuantifierGroup(new AnyExpression(AnyGroupMode.Capturing, values)).OneMany();
        }

        internal static QuantifiableExpression QuantifierGroup(object content)
        {
            return new QuantifierCapturingExpression(content);
        }
    }
}
