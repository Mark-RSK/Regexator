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
            return Append(Quantifiers.Maybe());
        }

        public Quantifier MaybeMany()
        {
            return Append(Quantifiers.MaybeMany());
        }

        public Quantifier OneMany()
        {
            return Append(Quantifiers.OneMany());
        }

        public Quantifier Count(int exactCount)
        {
            return Append(Quantifiers.Count(exactCount));
        }

        public Quantifier AtLeast(int minCount)
        {
            return Append(Quantifiers.AtLeast(minCount));
        }

        public Quantifier Count(int minCount, int maxCount)
        {
            return Append(Quantifiers.Count(minCount, maxCount));
        }
    }
}
