// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

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
    }
}
