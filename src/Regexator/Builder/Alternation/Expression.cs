// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Any(params Expression[] expressions)
        {
            return AppendInternal(Alternations.Any(expressions));
        }

        public QuantifiableExpression Any(params string[] values)
        {
            return AppendInternal(Alternations.Any(values));
        }

        public QuantifiableExpression IfGroup(string groupName, Expression yes)
        {
            return AppendInternal(Alternations.IfGroup(groupName, yes));
        }

        public QuantifiableExpression IfGroup(string groupName, Expression yes, Expression no)
        {
            return AppendInternal(Alternations.IfGroup(groupName, yes, no));
        }

        public QuantifiableExpression IfGroup(string groupName, string yes)
        {
            return AppendInternal(Alternations.IfGroup(groupName, yes));
        }

        public QuantifiableExpression IfGroup(string groupName, string yes, string no)
        {
            return AppendInternal(Alternations.IfGroup(groupName, yes, no));
        }

        public QuantifiableExpression IfGroup(int groupNumber, Expression yes)
        {
            return AppendInternal(Alternations.IfGroup(groupNumber, yes));
        }

        public QuantifiableExpression IfGroup(int groupNumber, Expression yes, Expression no)
        {
            return AppendInternal(Alternations.IfGroup(groupNumber, yes, no));
        }

        public QuantifiableExpression IfGroup(int groupNumber, string yes)
        {
            return AppendInternal(Alternations.IfGroup(groupNumber, yes));
        }

        public QuantifiableExpression IfGroup(int groupNumber, string yes, string no)
        {
            return AppendInternal(Alternations.IfGroup(groupNumber, yes, no));
        }

        public QuantifiableExpression If(Expression condition, Expression yes)
        {
            return AppendInternal(Alternations.If(condition, yes));
        }

        public QuantifiableExpression If(Expression condition, Expression yes, Expression no)
        {
            return AppendInternal(Alternations.If(condition, yes, no));
        }

        public QuantifiableExpression If(Expression condition, string yes)
        {
            return AppendInternal(Alternations.If(condition, yes));
        }

        public QuantifiableExpression If(Expression condition, string yes, string no)
        {
            return AppendInternal(Alternations.If(condition, yes, no));
        }

        public Expression Or()
        {
            return AppendInternal(Alternations.Or);
        }
    }
}