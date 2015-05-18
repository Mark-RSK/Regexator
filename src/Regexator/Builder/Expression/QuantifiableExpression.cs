// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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
            return AppendInternal(Quantifiers.Maybe());
        }

        public QuantifierExpression MaybeMany()
        {
            return AppendInternal(Quantifiers.MaybeMany());
        }

        public QuantifierExpression MaybeCount(int maxCount)
        {
            return AppendInternal(Quantifiers.MaybeCount(maxCount));
        }

        public QuantifierExpression OneMany()
        {
            return AppendInternal(Quantifiers.OneMany());
        }

        public QuantifierExpression Count(int exactCount)
        {
            return AppendInternal(Quantifiers.Count(exactCount));
        }

        public QuantifierExpression CountFrom(int minCount)
        {
            return AppendInternal(Quantifiers.CountFrom(minCount));
        }

        public QuantifierExpression CountRange(int minCount, int maxCount)
        {
            return AppendInternal(Quantifiers.CountRange(minCount, maxCount));
        }
    }
}
