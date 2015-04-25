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
            return Append(Expressions.Maybe());
        }

        public Quantifier MaybeMany()
        {
            return Append(Expressions.MaybeMany());
        }

        public Quantifier OneMany()
        {
            return Append(Expressions.OneMany());
        }

        public Quantifier Count(int exactCount)
        {
            return Append(Expressions.Count(exactCount));
        }

        public Quantifier AtLeast(int minCount)
        {
            return Append(Expressions.AtLeast(minCount));
        }

        public Quantifier Count(int minCount, int maxCount)
        {
            return Append(Expressions.Count(minCount, maxCount));
        }
    }
}
