// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static class CharClasses
    {
        public static QuantifiableExpression Digit()
        {
            return new CharClassExpression(CharClass.Digit);
        }

        public static Quantifier Digit(int count)
        {
            return new CharClassExpression(CharClass.Digit).Count(count);
        }

        public static Quantifier Digit(int minCount, int maxCount)
        {
            return new CharClassExpression(CharClass.Digit).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotDigit()
        {
            return new CharClassExpression(CharClass.NotDigit);
        }

        public static Quantifier NotDigit(int count)
        {
            return new CharClassExpression(CharClass.NotDigit).Count(count);
        }

        public static Quantifier NotDigit(int minCount, int maxCount)
        {
            return new CharClassExpression(CharClass.NotDigit).Count(minCount, maxCount);
        }

        public static QuantifiableExpression WhiteSpace()
        {
            return new CharClassExpression(CharClass.WhiteSpace);
        }

        public static Quantifier WhiteSpace(int count)
        {
            return new CharClassExpression(CharClass.WhiteSpace).Count(count);
        }

        public static Quantifier WhiteSpace(int minCount, int maxCount)
        {
            return new CharClassExpression(CharClass.WhiteSpace).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotWhiteSpace()
        {
            return new CharClassExpression(CharClass.NotWhiteSpace);
        }

        public static Quantifier NotWhiteSpace(int count)
        {
            return new CharClassExpression(CharClass.NotWhiteSpace).Count(count);
        }

        public static Quantifier NotWhiteSpace(int minCount, int maxCount)
        {
            return new CharClassExpression(CharClass.NotWhiteSpace).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Word()
        {
            return new CharClassExpression(CharClass.Word);
        }

        public static Quantifier Word(int count)
        {
            return new CharClassExpression(CharClass.Word).Count(count);
        }

        public static Quantifier Word(int minCount, int maxCount)
        {
            return new CharClassExpression(CharClass.Word).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotWord()
        {
            return new CharClassExpression(CharClass.NotWord);
        }

        public static Quantifier NotWord(int count)
        {
            return new CharClassExpression(CharClass.NotWord).Count(count);
        }

        public static Quantifier NotWord(int minCount, int maxCount)
        {
            return new CharClassExpression(CharClass.NotWord).Count(minCount, maxCount);
        }
    }
}
