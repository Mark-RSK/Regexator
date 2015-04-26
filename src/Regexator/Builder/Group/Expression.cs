// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Group(string name, Expression value)
        {
            return AppendInternal(Groups.Group(name, value));
        }

        public QuantifiableExpression Group(int name, Expression value)
        {
            return AppendInternal(Groups.Group(name, value));
        }

        public QuantifiableExpression Group(string name, string value)
        {
            return AppendInternal(Groups.Group(name, value));
        }

        public QuantifiableExpression Group(int name, string value)
        {
            return AppendInternal(Groups.Group(name, value));
        }

        public QuantifiableExpression AsGroup(string name)
        {
            return Groups.Group(name, this);
        }

        public QuantifiableExpression AsGroup(int name)
        {
            return Groups.Group(name, this);
        }

        public QuantifiableExpression Subexpression(Expression value)
        {
            return AppendInternal(Groups.Subexpression(value));
        }

        public QuantifiableExpression Subexpression(string value)
        {
            return AppendInternal(Groups.Subexpression(value));
        }

        public QuantifiableExpression AsSubexpression()
        {
            return Groups.Subexpression(this);
        }

        public QuantifiableExpression Noncapturing(Expression value)
        {
            return AppendInternal(Groups.Noncapturing(value));
        }

        public QuantifiableExpression Noncapturing(string value)
        {
            return AppendInternal(Groups.Noncapturing(value));
        }

        public QuantifiableExpression AsNoncapturing()
        {
            return Groups.Noncapturing(this);
        }

        public QuantifiableExpression Nonbacktracking(Expression value)
        {
            return AppendInternal(Groups.Nonbacktracking(value));
        }

        public QuantifiableExpression Nonbacktracking(string value)
        {
            return AppendInternal(Groups.Nonbacktracking(value));
        }

        public QuantifiableExpression AsNonbacktracking()
        {
            return Groups.Nonbacktracking(this);
        }

        public QuantifiableExpression Balancing(string name1, string name2, Expression value)
        {
            return AppendInternal(Groups.Balancing(name1, name2, value));
        }

        public QuantifiableExpression Balancing(string name1, string name2, string value)
        {
            return AppendInternal(Groups.Balancing(name1, name2, value));
        }

        public QuantifiableExpression AsBalancing(string name1, string name2)
        {
            return Groups.Balancing(name1, name2, this);
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, Expression value)
        {
            return AppendInternal(Groups.GroupOptions(applyOptions, value));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, string value)
        {
            return AppendInternal(Groups.GroupOptions(applyOptions, value));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, Expression value)
        {
            return AppendInternal(Groups.GroupOptions(applyOptions, disableOptions, value));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string value)
        {
            return AppendInternal(Groups.GroupOptions(applyOptions, disableOptions, value));
        }

        public QuantifiableExpression AsGroupOptions(InlineOptions applyOptions)
        {
            return Groups.GroupOptions(applyOptions, this);
        }

        public QuantifiableExpression AsGroupOptions(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return Groups.GroupOptions(applyOptions, disableOptions, this);
        }
    }
}
