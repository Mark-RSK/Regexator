// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Digit()
        {
            return Append(Expressions.Digit());
        }

        public Quantifier Digit(int count)
        {
            return Append(Expressions.Digit(count));
        }

        public Quantifier Digit(int minCount, int maxCount)
        {
            return Append(Expressions.Digit(minCount, maxCount));
        }

        public QuantifiableExpression NotDigit()
        {
            return Append(Expressions.NotDigit());
        }

        public Quantifier NotDigit(int count)
        {
            return Append(Expressions.NotDigit(count));
        }

        public Quantifier NotDigit(int minCount, int maxCount)
        {
            return Append(Expressions.NotDigit(minCount, maxCount));
        }

        public QuantifiableExpression WhiteSpace()
        {
            return Append(Expressions.WhiteSpace());
        }

        public Quantifier WhiteSpace(int count)
        {
            return Append(Expressions.WhiteSpace(count));
        }

        public Quantifier WhiteSpace(int minCount, int maxCount)
        {
            return Append(Expressions.WhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression NotWhiteSpace()
        {
            return Append(Expressions.NotWhiteSpace());
        }

        public Quantifier NotWhiteSpace(int count)
        {
            return Append(Expressions.NotWhiteSpace(count));
        }

        public Quantifier NotWhiteSpace(int minCount, int maxCount)
        {
            return Append(Expressions.NotWhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression Word()
        {
            return Append(Expressions.Word());
        }

        public Quantifier Word(int count)
        {
            return Append(Expressions.Word(count));
        }

        public Quantifier Word(int minCount, int maxCount)
        {
            return Append(Expressions.Word(minCount, maxCount));
        }

        public QuantifiableExpression NotWord()
        {
            return Append(Expressions.NotWord());
        }

        public Quantifier NotWord(int count)
        {
            return Append(Expressions.NotWord(count));
        }

        public Quantifier NotWord(int minCount, int maxCount)
        {
            return Append(Expressions.NotWord(minCount, maxCount));
        }
    }
}