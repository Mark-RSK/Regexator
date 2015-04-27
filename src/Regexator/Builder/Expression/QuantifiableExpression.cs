// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public abstract class QuantifiableExpression
        : Expression
    {
        protected QuantifiableExpression()
            : base()
        {
        }

        public QuantifierExpression Maybe()
        {
            return AppendInternal(Quantifier.Maybe());
        }

        public QuantifierExpression MaybeMany()
        {
            return AppendInternal(Quantifier.MaybeMany());
        }

        public QuantifierExpression OneMany()
        {
            return AppendInternal(Quantifier.OneMany());
        }

        public QuantifierExpression Count(int exactCount)
        {
            return AppendInternal(Quantifier.Count(exactCount));
        }

        public QuantifierExpression AtLeast(int minCount)
        {
            return AppendInternal(Quantifier.AtLeast(minCount));
        }

        public QuantifierExpression Count(int minCount, int maxCount)
        {
            return AppendInternal(Quantifier.Count(minCount, maxCount));
        }
    }
}
