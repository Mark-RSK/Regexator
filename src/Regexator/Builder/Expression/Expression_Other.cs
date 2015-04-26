// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Backreference(int groupNumber)
        {
            return AppendInternal(Expressions.Backreference(groupNumber));
        }

        public QuantifiableExpression Backreference(string groupName)
        {
            return AppendInternal(Expressions.Backreference(groupName));
        }

        public Expression Options(InlineOptions applyOptions)
        {
            return AppendInternal(Expressions.Options(applyOptions));
        }

        public Expression Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return AppendInternal(Expressions.Options(applyOptions, disableOptions));
        }

        public Expression InlineComment(string value)
        {
            return AppendInternal(Expressions.InlineComment(value));
        }

        public QuantifiableExpression NewLine()
        {
            return AppendInternal(Expressions.NewLine());
        }

        public Expression Text(string value)
        {
            return AppendInternal(Expressions.Text(value));
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal QuantifiableExpression InsignificantSeparator()
        {
            return AppendInternal(Expressions.InsignificantSeparator());
        }
    }
}
