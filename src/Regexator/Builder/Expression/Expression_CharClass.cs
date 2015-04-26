// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Digit()
        {
            return Append(Characters.Digit());
        }

        public Quantifier Digit(int count)
        {
            return Append(Characters.Digit(count));
        }

        public Quantifier Digit(int minCount, int maxCount)
        {
            return Append(Characters.Digit(minCount, maxCount));
        }

        public QuantifiableExpression NotDigit()
        {
            return Append(Characters.NotDigit());
        }

        public Quantifier NotDigit(int count)
        {
            return Append(Characters.NotDigit(count));
        }

        public Quantifier NotDigit(int minCount, int maxCount)
        {
            return Append(Characters.NotDigit(minCount, maxCount));
        }

        public QuantifiableExpression WhiteSpace()
        {
            return Append(Characters.WhiteSpace());
        }

        public Quantifier WhiteSpace(int count)
        {
            return Append(Characters.WhiteSpace(count));
        }

        public Quantifier WhiteSpace(int minCount, int maxCount)
        {
            return Append(Characters.WhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression NotWhiteSpace()
        {
            return Append(Characters.NotWhiteSpace());
        }

        public Quantifier NotWhiteSpace(int count)
        {
            return Append(Characters.NotWhiteSpace(count));
        }

        public Quantifier NotWhiteSpace(int minCount, int maxCount)
        {
            return Append(Characters.NotWhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression Word()
        {
            return Append(Characters.Word());
        }

        public Quantifier Word(int count)
        {
            return Append(Characters.Word(count));
        }

        public Quantifier Word(int minCount, int maxCount)
        {
            return Append(Characters.Word(minCount, maxCount));
        }

        public QuantifiableExpression NotWord()
        {
            return Append(Characters.NotWord());
        }

        public Quantifier NotWord(int count)
        {
            return Append(Characters.NotWord(count));
        }

        public Quantifier NotWord(int minCount, int maxCount)
        {
            return Append(Characters.NotWord(minCount, maxCount));
        }
    }
}