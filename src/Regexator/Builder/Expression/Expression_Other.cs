// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Backreference(int groupNumber)
        {
            return Append(Expressions.Backreference(groupNumber));
        }

        public QuantifiableExpression Backreference(string groupName)
        {
            return Append(Expressions.Backreference(groupName));
        }

        public Expression Options(InlineOptions applyOptions)
        {
            return Append(Expressions.Options(applyOptions));
        }

        public Expression Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return Append(Expressions.Options(applyOptions, disableOptions));
        }

        public Expression InlineComment(string value)
        {
            return Append(Expressions.InlineComment(value));
        }

        public QuantifiableExpression NewLine()
        {
            return Append(Expressions.NewLine());
        }

        public Expression Text(string value)
        {
            return Append(Expressions.Text(value));
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal QuantifiableExpression InsignificantSeparator()
        {
            return Append(Expressions.InsignificantSeparator());
        }
    }
}
