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

        public Quantifier Maybe()
        {
            return AppendInternal(Quantifiers.Maybe());
        }

        public Quantifier MaybeMany()
        {
            return AppendInternal(Quantifiers.MaybeMany());
        }

        public Quantifier OneMany()
        {
            return AppendInternal(Quantifiers.OneMany());
        }

        public Quantifier Count(int exactCount)
        {
            return AppendInternal(Quantifiers.Count(exactCount));
        }

        public Quantifier AtLeast(int minCount)
        {
            return AppendInternal(Quantifiers.AtLeast(minCount));
        }

        public Quantifier Count(int minCount, int maxCount)
        {
            return AppendInternal(Quantifiers.Count(minCount, maxCount));
        }
    }
}
