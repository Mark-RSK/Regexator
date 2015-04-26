// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Digit()
        {
            return AppendInternal(Characters.Digit());
        }

        public Quantifier Digit(int count)
        {
            return AppendInternal(Characters.Digit(count));
        }

        public Quantifier Digit(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Digit(minCount, maxCount));
        }

        public QuantifiableExpression NotDigit()
        {
            return AppendInternal(Characters.NotDigit());
        }

        public Quantifier NotDigit(int count)
        {
            return AppendInternal(Characters.NotDigit(count));
        }

        public Quantifier NotDigit(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotDigit(minCount, maxCount));
        }

        public QuantifiableExpression WhiteSpace()
        {
            return AppendInternal(Characters.WhiteSpace());
        }

        public Quantifier WhiteSpace(int count)
        {
            return AppendInternal(Characters.WhiteSpace(count));
        }

        public Quantifier WhiteSpace(int minCount, int maxCount)
        {
            return AppendInternal(Characters.WhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression NotWhiteSpace()
        {
            return AppendInternal(Characters.NotWhiteSpace());
        }

        public Quantifier NotWhiteSpace(int count)
        {
            return AppendInternal(Characters.NotWhiteSpace(count));
        }

        public Quantifier NotWhiteSpace(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotWhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression Word()
        {
            return AppendInternal(Characters.Word());
        }

        public Quantifier Word(int count)
        {
            return AppendInternal(Characters.Word(count));
        }

        public Quantifier Word(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Word(minCount, maxCount));
        }

        public QuantifiableExpression NotWord()
        {
            return AppendInternal(Characters.NotWord());
        }

        public Quantifier NotWord(int count)
        {
            return AppendInternal(Characters.NotWord(count));
        }

        public Quantifier NotWord(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotWord(minCount, maxCount));
        }
    }
}