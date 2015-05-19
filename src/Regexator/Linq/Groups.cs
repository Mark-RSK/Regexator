// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Linq
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

        public static QuantifiableExpression Subexpression()
        {
            return new Subexpression(string.Empty);
        }

        public static QuantifiableExpression Subexpression(string text)
        {
            return new Subexpression(text);
        }

        public static QuantifiableExpression Subexpression(Expression expression)
        {
            return new Subexpression(expression);
        }

        public static QuantifiableExpression Noncapturing(Expression expression)
        {
            return new NoncapturingExpression(expression);
        }

        public static QuantifiableExpression Noncapturing(string text)
        {
            return new NoncapturingExpression(text);
        }

        public static QuantifiableExpression Balancing(string name1, string name2, Expression expression)
        {
            return new BalancingGroupExpression(name1, name2, expression);
        }

        public static QuantifiableExpression Balancing(string name1, string name2, string text)
        {
            return new BalancingGroupExpression(name1, name2, text);
        }

        public static QuantifiableExpression Nonbacktracking(Expression expression)
        {
            return new NonbacktrackingExpression(expression);
        }

        public static QuantifiableExpression Nonbacktracking(string text)
        {
            return new NonbacktrackingExpression(text);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, Expression expression)
        {
            return new GroupOptionsExpression(applyOptions, expression);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, string text)
        {
            return new GroupOptionsExpression(applyOptions, text);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, Expression expression)
        {
            return new GroupOptionsExpression(applyOptions, disableOptions, expression);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string text)
        {
            return new GroupOptionsExpression(applyOptions, disableOptions, text);
        }

        public static QuantifierExpression Maybe(string text)
        {
            return QuantifierGroup(text).Maybe();
        }

        public static QuantifierExpression Maybe(Expression expression)
        {
            return QuantifierGroup(expression).Maybe();
        }

        public static QuantifierExpression MaybeMany(string text)
        {
            return QuantifierGroup(text).MaybeMany();
        }

        public static QuantifierExpression MaybeMany(Expression expression)
        {
            return QuantifierGroup(expression).MaybeMany();
        }

        public static QuantifierExpression OneMany(string text)
        {
            return QuantifierGroup(text).OneMany();
        }

        public static QuantifierExpression OneMany(Expression expression)
        {
            return QuantifierGroup(expression).OneMany();
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
