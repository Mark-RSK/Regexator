// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Expressions
    {
        public static QuantifiableExpression Any(params Expression[] expressions)
        {
            return new OrConstruct(expressions);
        }

        public static QuantifiableExpression Any(params string[] values)
        {
            return new OrConstruct(values);
        }

        public static QuantifiableExpression IfGroup(string groupName, Expression yes)
        {
            return new IfConstruct(Syntax.IfGroupStart(groupName), yes);
        }

        public static QuantifiableExpression IfGroup(string groupName, Expression yes, Expression no)
        {
            return new IfConstruct(Syntax.IfGroupStart(groupName), yes, no);
        }

        public static QuantifiableExpression IfGroup(string groupName, string yes)
        {
            return new IfConstruct(Syntax.IfGroupStart(groupName), yes);
        }

        public static QuantifiableExpression IfGroup(string groupName, string yes, string no)
        {
            return new IfConstruct(Syntax.IfGroupStart(groupName), yes, no);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, Expression yes)
        {
            return new IfConstruct(Syntax.IfGroupStart(groupNumber), yes);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, Expression yes, Expression no)
        {
            return new IfConstruct(Syntax.IfGroupStart(groupNumber), yes, no);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, string yes)
        {
            return new IfConstruct(Syntax.IfGroupStart(groupNumber), yes);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, string yes, string no)
        {
            return new IfConstruct(Syntax.IfGroupStart(groupNumber), yes, no);
        }

        public static QuantifiableExpression If(Expression condition, Expression yes)
        {
            return new IfConstruct(condition, yes);
        }

        public static QuantifiableExpression If(Expression condition, Expression yes, Expression no)
        {
            return new IfConstruct(condition, yes, no);
        }

        public static QuantifiableExpression If(Expression condition, string yes)
        {
            return new IfConstruct(condition, yes);
        }

        public static QuantifiableExpression If(Expression condition, string yes, string no)
        {
            return new IfConstruct(condition, yes, no);
        }

        public static Expression Or
        {
            get { return new Expression(Syntax.Or); }
        }
    }
}
