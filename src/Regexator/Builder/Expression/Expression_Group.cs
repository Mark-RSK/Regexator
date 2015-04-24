// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Group(string name, Expression value)
        {
            return Append(Expressions.Group(name, value));
        }

        public QuantifiableExpression Group(int name, Expression value)
        {
            return Append(Expressions.Group(name, value));
        }

        public QuantifiableExpression Group(string name, string value)
        {
            return Append(Expressions.Group(name, value));
        }

        public QuantifiableExpression Group(int name, string value)
        {
            return Append(Expressions.Group(name, value));
        }

        public QuantifiableExpression AsGroup(string name)
        {
            return Expressions.Group(name, First);
        }

        public QuantifiableExpression AsGroup(int name)
        {
            return Expressions.Group(name, First);
        }

        public QuantifiableExpression Subexpression(Expression value)
        {
            return Append(Expressions.Subexpression(value));
        }

        public QuantifiableExpression Subexpression(string value)
        {
            return Append(Expressions.Subexpression(value));
        }

        public QuantifiableExpression AsSubexpression()
        {
            return Expressions.Subexpression(First);
        }

        public QuantifiableExpression Noncapturing(Expression value)
        {
            return Append(Expressions.Noncapturing(value));
        }

        public QuantifiableExpression Noncapturing(string value)
        {
            return Append(Expressions.Noncapturing(value));
        }

        public QuantifiableExpression AsNoncapturing()
        {
            return Expressions.Noncapturing(First);
        }

        public QuantifiableExpression Nonbacktracking(Expression value)
        {
            return Append(Expressions.Nonbacktracking(value));
        }

        public QuantifiableExpression Nonbacktracking(string value)
        {
            return Append(Expressions.Nonbacktracking(value));
        }

        public QuantifiableExpression AsNonbacktracking()
        {
            return Expressions.Nonbacktracking(First);
        }

        public QuantifiableExpression Balancing(string name1, string name2, Expression value)
        {
            return Append(Expressions.Balancing(name1, name2, value));
        }

        public QuantifiableExpression Balancing(string name1, string name2, string value)
        {
            return Append(Expressions.Balancing(name1, name2, value));
        }

        public QuantifiableExpression AsBalancing(string name1, string name2)
        {
            return Expressions.Balancing(name1, name2, First);
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, Expression value)
        {
            return Append(Expressions.GroupOptions(applyOptions, value));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, string value)
        {
            return Append(Expressions.GroupOptions(applyOptions, value));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, Expression value)
        {
            return Append(Expressions.GroupOptions(applyOptions, disableOptions, value));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string value)
        {
            return Append(Expressions.GroupOptions(applyOptions, disableOptions, value));
        }

        public QuantifiableExpression AsGroupOptions(InlineOptions applyOptions)
        {
            return Expressions.GroupOptions(applyOptions, First);
        }

        public QuantifiableExpression AsGroupOptions(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return Expressions.GroupOptions(applyOptions, disableOptions, First);
        }
    }
}
