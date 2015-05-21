// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Pihrtsoft.Regexator.Linq
{
    public static class Alternations
    {
        public static QuantifiableExpression Any(IEnumerable<Expression> expressions)
        {
            return new AnyExpression(expressions);
        }

        public static QuantifiableExpression Any(params Expression[] expressions)
        {
            return new AnyExpression(expressions);
        }

        public static QuantifiableExpression Any(Func<Expression, Expression> selector, params Expression[] expressions)
        {
            if (expressions == null)
            {
                throw new ArgumentNullException("expressions");
            }
            return new AnyExpression(expressions.Select(selector));
        }

        public static QuantifiableExpression Any(IEnumerable<string> values)
        {
            return new AnyTextExpression(values);
        }

        public static QuantifiableExpression Any(params string[] values)
        {
            return new AnyTextExpression(values);
        }

        public static QuantifiableExpression Any(Func<string, Expression> selector, params string[] values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            return new AnyExpression(values.Select(selector));
        }

        public static QuantifiableExpression IfGroup(string groupName, Expression yes)
        {
            return new GroupNameIfExpression(groupName, yes);
        }

        public static QuantifiableExpression IfGroup(string groupName, Expression yes, Expression no)
        {
            return new GroupNameIfExpression(groupName, yes, no);
        }

        public static QuantifiableExpression IfGroup(string groupName, string yes)
        {
            return new GroupNameIfExpression(groupName, yes);
        }

        public static QuantifiableExpression IfGroup(string groupName, string yes, string no)
        {
            return new GroupNameIfExpression(groupName, yes, no);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, Expression yes)
        {
            return new GroupNumberIfExpression(groupNumber, yes);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, Expression yes, Expression no)
        {
            return new GroupNumberIfExpression(groupNumber, yes, no);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, string yes)
        {
            return new GroupNumberIfExpression(groupNumber, yes);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, string yes, string no)
        {
            return new GroupNumberIfExpression(groupNumber, yes, no);
        }

        public static QuantifiableExpression If(Expression condition, Expression yes)
        {
            return new IfExpression(condition, yes);
        }

        public static QuantifiableExpression If(Expression condition, Expression yes, Expression no)
        {
            return new IfExpression(condition, yes, no);
        }

        public static QuantifiableExpression If(Expression condition, string yes)
        {
            return new IfExpression(condition, yes);
        }

        public static QuantifiableExpression If(Expression condition, string yes, string no)
        {
            return new IfExpression(condition, yes, no);
        }

        public static Expression Or()
        {
            return new OrExpression();
        }
    }
}
