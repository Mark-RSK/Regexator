// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Regexator.Builder
{
    public static class Miscellaneous
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

        public static CharSubtraction WhiteSpaceExceptNewLine()
        {
            return new CharSubtraction(CharItems.WhiteSpace(), CharItems.CarriageReturn().Linefeed());
        }

        public static QuantifiableExpression NewLine()
        {
            return Character.CarriageReturn().Maybe().Linefeed().AsNoncapturing();
        }

        public static Expression Text(string value)
        {
            return Expression.Create(value);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal static QuantifiableExpression InsignificantSeparator()
        {
            return Grouping.GroupOptions(InlineOptions.IgnorePatternWhitespace, new TextExpression(" ", false));
        }
    }
}
