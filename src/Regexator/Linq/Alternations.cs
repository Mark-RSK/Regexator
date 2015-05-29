// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Alternations
    {
        public static QuantifiableExpression Any(IEnumerable<object> values)
        {
            return new AnyExpression(values);
        }

        public static QuantifiableExpression Any(params object[] values)
        {
            return new AnyExpression(values);
        }

        public static QuantifiableExpression IfGroup(string groupName, object yes)
        {
            return new GroupNameIfExpression(groupName, yes);
        }

        public static QuantifiableExpression IfGroup(string groupName, object yes, object no)
        {
            return new GroupNameIfExpression(groupName, yes, no);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, object yes)
        {
            return new GroupNumberIfExpression(groupNumber, yes);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, object yes, object no)
        {
            return new GroupNumberIfExpression(groupNumber, yes, no);
        }

        public static QuantifiableExpression If(Expression condition, object yes)
        {
            return new IfExpression(condition, yes);
        }

        public static QuantifiableExpression If(Expression condition, object yes, object no)
        {
            return new IfExpression(condition, yes, no);
        }

        public static Expression Or()
        {
            return new OrExpression();
        }
    }
}
