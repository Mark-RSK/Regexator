// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Groups
    {
        public static QuantifiableExpression NamedGroup(string name, Expression expression)
        {
            return new NamedGroupExpression(name, expression);
        }

        public static QuantifiableExpression NamedGroup(string name, string text)
        {
            return new NamedGroupExpression(name, text);
        }

        public static QuantifiableExpression NamedGroup(string name, params Expression[] expressions)
        {
            return new NamedGroupExpression(name, new AnyExpression(AnyGroupMode.None, expressions));
        }

        public static QuantifiableExpression NamedGroup(string name, params string[] values)
        {
            return new NamedGroupExpression(name, new AnyTextExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression Subexpression()
        {
            return new Subexpression(string.Empty);
        }

        public static QuantifiableExpression Subexpression(Expression expression)
        {
            return new Subexpression(expression);
        }

        public static QuantifiableExpression Subexpression(string text)
        {
            return new Subexpression(text);
        }

        public static QuantifiableExpression Subexpression(params Expression[] expressions)
        {
            return new Subexpression(new AnyExpression(AnyGroupMode.None, expressions));
        }

        public static QuantifiableExpression Subexpression(params string[] values)
        {
            return new Subexpression(new AnyTextExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression Noncapturing(Expression expression)
        {
            return new NoncapturingExpression(expression);
        }

        public static QuantifiableExpression Noncapturing(string text)
        {
            return new NoncapturingExpression(text);
        }

        public static QuantifiableExpression Noncapturing(params Expression[] expressions)
        {
            return new NoncapturingExpression(new AnyExpression(AnyGroupMode.None, expressions));
        }

        public static QuantifiableExpression Noncapturing(params string[] values)
        {
            return new NoncapturingExpression(new AnyTextExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression BalanceGroup(string name1, string name2, Expression expression)
        {
            return new BalanceGroupExpression(name1, name2, expression);
        }

        public static QuantifiableExpression BalanceGroup(string name1, string name2, string text)
        {
            return new BalanceGroupExpression(name1, name2, text);
        }

        public static QuantifiableExpression BalanceGroup(string name1, string name2, params Expression[] expressions)
        {
            return new BalanceGroupExpression(name1, name2, new AnyExpression(AnyGroupMode.None, expressions));
        }

        public static QuantifiableExpression BalanceGroup(string name1, string name2, params string[] values)
        {
            return new BalanceGroupExpression(name1, name2, new AnyTextExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression Nonbacktracking(Expression expression)
        {
            return new NonbacktrackingExpression(expression);
        }

        public static QuantifiableExpression Nonbacktracking(string text)
        {
            return new NonbacktrackingExpression(text);
        }

        public static QuantifiableExpression Nonbacktracking(params Expression[] expressions)
        {
            return new NonbacktrackingExpression(new AnyExpression(AnyGroupMode.None, expressions));
        }

        public static QuantifiableExpression Nonbacktracking(params string[] values)
        {
            return new NonbacktrackingExpression(new AnyTextExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, Expression expression)
        {
            return new GroupOptionsExpression(applyOptions, expression);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, string text)
        {
            return new GroupOptionsExpression(applyOptions, text);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, params Expression[] expressions)
        {
            return new GroupOptionsExpression(applyOptions, new AnyExpression(AnyGroupMode.None, expressions));
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, params string[] values)
        {
            return new GroupOptionsExpression(applyOptions, new AnyTextExpression(AnyGroupMode.None, values));
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, Expression expression)
        {
            return new GroupOptionsExpression(applyOptions, disableOptions, expression);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string text)
        {
            return new GroupOptionsExpression(applyOptions, disableOptions, text);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, params Expression[] expressions)
        {
            return new GroupOptionsExpression(applyOptions, disableOptions, new AnyExpression(AnyGroupMode.None, expressions));
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, params string[] values)
        {
            return new GroupOptionsExpression(applyOptions, disableOptions, new AnyTextExpression(AnyGroupMode.None, values));
        }

        public static QuantifierExpression Maybe(string text)
        {
            return QuantifierGroup(text).Maybe();
        }

        public static QuantifierExpression Maybe(Expression expression)
        {
            return QuantifierGroup(expression).Maybe();
        }

        public static QuantifierExpression Maybe(params string[] values)
        {
            return QuantifierGroup(new AnyTextExpression(AnyGroupMode.Subexpression, values)).Maybe();
        }

        public static QuantifierExpression Maybe(params Expression[] expressions)
        {
            return QuantifierGroup(new AnyExpression(AnyGroupMode.Subexpression, expressions)).Maybe();
        }

        public static QuantifierExpression MaybeMany(string text)
        {
            return QuantifierGroup(text).MaybeMany();
        }

        public static QuantifierExpression MaybeMany(Expression expression)
        {
            return QuantifierGroup(expression).MaybeMany();
        }

        public static QuantifierExpression MaybeMany(params string[] values)
        {
            return QuantifierGroup(new AnyTextExpression(AnyGroupMode.Subexpression, values)).MaybeMany();
        }

        public static QuantifierExpression MaybeMany(params Expression[] expressions)
        {
            return QuantifierGroup(new AnyExpression(AnyGroupMode.Subexpression, expressions)).MaybeMany();
        }

        public static QuantifierExpression OneMany(string text)
        {
            return QuantifierGroup(text).OneMany();
        }

        public static QuantifierExpression OneMany(Expression expression)
        {
            return QuantifierGroup(expression).OneMany();
        }

        public static QuantifierExpression OneMany(params string[] values)
        {
            return QuantifierGroup(new AnyTextExpression(AnyGroupMode.Subexpression, values)).OneMany();
        }

        public static QuantifierExpression OneMany(params Expression[] expressions)
        {
            return QuantifierGroup(new AnyExpression(AnyGroupMode.Subexpression, expressions)).OneMany();
        }

        internal static QuantifiableExpression QuantifierGroup(string text)
        {
            return new QuantifierSubexpression(text);
        }

        internal static QuantifiableExpression QuantifierGroup(Expression expression)
        {
            return new QuantifierSubexpression(expression);
        }
    }
}
