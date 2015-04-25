// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Expressions
    {
        public static QuantifiableExpression Backreference(int groupNumber)
        {
            return new NumberBackreference(groupNumber);
        }

        public static QuantifiableExpression Backreference(string groupName)
        {
            return new NameBackreference(groupName);
        }

        public static Expression Options(InlineOptions applyOptions)
        {
            return new InlineOptionsExpression(applyOptions);
        }

        public static Expression Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return new InlineOptionsExpression(applyOptions, disableOptions);
        }

        public static Expression InlineComment(string value)
        {
            return new InlineCommentExpression(value);
        }

        public static QuantifiableExpression NewLine()
        {
            return CarriageReturn().Maybe().Linefeed().AsNoncapturing();
        }

        public static Expression Text(string value)
        {
            return Expression.Create(value);
        }

        internal static QuantifiableExpression InsignificantSeparator()
        {
            return Expressions.GroupOptions(InlineOptions.IgnorePatternWhitespace, new Expression(" ", false));
        }
    }
}
