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

        public static QuantifiableExpression Any(params object[] content)
        {
            return new AnyExpression(content);
        }

        public static QuantifiableExpression IfGroup(string groupName, object trueContent)
        {
            return new GroupNameIfExpression(groupName, trueContent);
        }

        public static QuantifiableExpression IfGroup(string groupName, object trueContent, object falseContent)
        {
            return new GroupNameIfExpression(groupName, trueContent, falseContent);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, object trueContent)
        {
            return new GroupNumberIfExpression(groupNumber, trueContent);
        }

        public static QuantifiableExpression IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            return new GroupNumberIfExpression(groupNumber, trueContent, falseContent);
        }

        public static QuantifiableExpression If(Expression testContent, object trueContent)
        {
            return new IfExpression(testContent, trueContent);
        }

        public static QuantifiableExpression If(Expression testContent, object trueContent, object falseContent)
        {
            return new IfExpression(testContent, trueContent, falseContent);
        }

        internal static QuantifiableExpression Or(object left, object right)
        {
            return new OrContainerExpression(left, right);
        }
    }
}
