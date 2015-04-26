// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Groups
    {
        public static QuantifiableExpression Group(string name, Expression expression)
        {
            return new NamedGroup(name, expression);
        }

        public static QuantifiableExpression Group(int name, Expression expression)
        {
            return new NumberNamedGroup(name, expression);
        }

        public static QuantifiableExpression Group(string name, string value)
        {
            return new NamedGroup(name, value);
        }

        public static QuantifiableExpression Group(int name, string value)
        {
            return new NumberNamedGroup(name, value);
        }

        public static QuantifiableExpression Subexpression(Expression expression)
        {
            return new Subexpression(expression);
        }

        public static QuantifiableExpression Subexpression(string value)
        {
            return new Subexpression(value);
        }

        public static QuantifiableExpression Noncapturing(Expression expression)
        {
            return new NoncapturingGroup(expression);
        }

        public static QuantifiableExpression Noncapturing(string value)
        {
            return new NoncapturingGroup(value);
        }

        public static QuantifiableExpression Balancing(string name1, string name2, Expression expression)
        {
            return new BalancingGroup(name1, name2, expression);
        }

        public static QuantifiableExpression Balancing(string name1, string name2, string value)
        {
            return new BalancingGroup(name1, name2, value);
        }

        public static QuantifiableExpression Nonbacktracking(Expression expression)
        {
            return new NonbacktrackingGroup(expression);
        }

        public static QuantifiableExpression Nonbacktracking(string value)
        {
            return new NonbacktrackingGroup(value);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, Expression expression)
        {
            return new GroupOptions(applyOptions, expression);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, string value)
        {
            return new GroupOptions(applyOptions, value);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, Expression expression)
        {
            return new GroupOptions(applyOptions, disableOptions, expression);
        }

        public static QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string value)
        {
            return new GroupOptions(applyOptions, disableOptions, value);
        }

        internal static QuantifiableExpression QuantifierGroup(string value)
        {
            return new QuantifierSubexpression(value);
        }

        internal static QuantifiableExpression QuantifierGroup(Expression expression)
        {
            return new QuantifierSubexpression(expression);
        }

        public static Quantifier Maybe(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).Maybe();
        }

        public static Quantifier Maybe(Expression value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).Maybe();
        }

        public static Quantifier MaybeMany(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).MaybeMany();
        }

        public static Quantifier MaybeMany(Expression value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).MaybeMany();
        }

        public static Quantifier OneMany(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).OneMany();
        }

        public static Quantifier OneMany(Expression value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return QuantifierGroup(value).OneMany();
        }

        public static Quantifier Count(int exactCount, string value)
        {
            return QuantifierGroup(value).Count(exactCount);
        }

        public static Quantifier Count(int exactCount, Expression expression)
        {
            return QuantifierGroup(expression).Count(exactCount);
        }

        public static Quantifier AtLeast(int minCount, string value)
        {
            return QuantifierGroup(value).AtLeast(minCount);
        }

        public static Quantifier AtLeast(int minCount, Expression expression)
        {
            return QuantifierGroup(expression).AtLeast(minCount);
        }

        public static Quantifier Count(int minCount, int maxCount, string value)
        {
            return Groups.QuantifierGroup(value).Count(minCount, maxCount);
        }

        public static Quantifier Count(int minCount, int maxCount, Expression expression)
        {
            return Groups.QuantifierGroup(expression).Count(minCount, maxCount);
        }
    }
}
