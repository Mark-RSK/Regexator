// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
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
            return ConcatInternal(Quantifiers.Maybe());
        }

        public QuantifierExpression MaybeMany()
        {
            return ConcatInternal(Quantifiers.MaybeMany());
        }

        public QuantifierExpression MaybeCount(int maxCount)
        {
            return ConcatInternal(Quantifiers.MaybeCount(maxCount));
        }

        public QuantifierExpression OneMany()
        {
            return ConcatInternal(Quantifiers.OneMany());
        }

        public QuantifierExpression Count(int exactCount)
        {
            return ConcatInternal(Quantifiers.Count(exactCount));
        }

        public QuantifierExpression CountFrom(int minCount)
        {
            return ConcatInternal(Quantifiers.CountFrom(minCount));
        }

        public QuantifierExpression CountRange(int minCount, int maxCount)
        {
            return ConcatInternal(Quantifiers.CountRange(minCount, maxCount));
        }
    }
}
