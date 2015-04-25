// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Digit()
        {
            return Append(CharClasses.Digit());
        }

        public Quantifier Digit(int count)
        {
            return Append(CharClasses.Digit(count));
        }

        public Quantifier Digit(int minCount, int maxCount)
        {
            return Append(CharClasses.Digit(minCount, maxCount));
        }

        public QuantifiableExpression NotDigit()
        {
            return Append(CharClasses.NotDigit());
        }

        public Quantifier NotDigit(int count)
        {
            return Append(CharClasses.NotDigit(count));
        }

        public Quantifier NotDigit(int minCount, int maxCount)
        {
            return Append(CharClasses.NotDigit(minCount, maxCount));
        }

        public QuantifiableExpression WhiteSpace()
        {
            return Append(CharClasses.WhiteSpace());
        }

        public Quantifier WhiteSpace(int count)
        {
            return Append(CharClasses.WhiteSpace(count));
        }

        public Quantifier WhiteSpace(int minCount, int maxCount)
        {
            return Append(CharClasses.WhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression NotWhiteSpace()
        {
            return Append(CharClasses.NotWhiteSpace());
        }

        public Quantifier NotWhiteSpace(int count)
        {
            return Append(CharClasses.NotWhiteSpace(count));
        }

        public Quantifier NotWhiteSpace(int minCount, int maxCount)
        {
            return Append(CharClasses.NotWhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression Word()
        {
            return Append(CharClasses.Word());
        }

        public Quantifier Word(int count)
        {
            return Append(CharClasses.Word(count));
        }

        public Quantifier Word(int minCount, int maxCount)
        {
            return Append(CharClasses.Word(minCount, maxCount));
        }

        public QuantifiableExpression NotWord()
        {
            return Append(CharClasses.NotWord());
        }

        public Quantifier NotWord(int count)
        {
            return Append(CharClasses.NotWord(count));
        }

        public Quantifier NotWord(int minCount, int maxCount)
        {
            return Append(CharClasses.NotWord(minCount, maxCount));
        }
    }
}