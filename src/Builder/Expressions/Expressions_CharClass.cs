// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Expressions
    {
        public static QuantifiableExpression Digit()
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.Digit));
        }

        public static Quantifier Digit(int count)
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.Digit)).Count(count);
        }

        public static Quantifier Digit(int minCount, int maxCount)
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.Digit)).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotDigit()
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.NotDigit));
        }

        public static Quantifier NotDigit(int count)
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.NotDigit)).Count(count);
        }

        public static Quantifier NotDigit(int minCount, int maxCount)
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.NotDigit)).Count(minCount, maxCount);
        }

        public static QuantifiableExpression WhiteSpace()
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.WhiteSpace));
        }

        public static Quantifier WhiteSpace(int count)
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.WhiteSpace)).Count(count);
        }

        public static Quantifier WhiteSpace(int minCount, int maxCount)
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.WhiteSpace)).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotWhiteSpace()
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.NotWhiteSpace));
        }

        public static Quantifier NotWhiteSpace(int count)
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.NotWhiteSpace)).Count(count);
        }

        public static Quantifier NotWhiteSpace(int minCount, int maxCount)
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.NotWhiteSpace)).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Word()
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.Word));
        }

        public static Quantifier Word(int count)
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.Word)).Count(count);
        }

        public static Quantifier Word(int minCount, int maxCount)
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.Word)).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotWord()
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.NotWord));
        }

        public static Quantifier NotWord(int count)
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.NotWord)).Count(count);
        }

        public static Quantifier NotWord(int minCount, int maxCount)
        {
            return new QuantifiableExpression(Syntax.CharClass(CharClass.NotWord)).Count(minCount, maxCount);
        }
    }
}
