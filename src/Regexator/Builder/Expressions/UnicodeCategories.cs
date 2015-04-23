// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class UnicodeCategories
    {
        public static QuantifiableExpression AllControlCharacters()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllControlCharacters);
        }

        public static Quantifier AllControlCharacters(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllControlCharacters).Count(exactCount);
        }

        public static Quantifier AllControlCharacters(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllControlCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllControlCharacters()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllControlCharacters);
        }

        public static Quantifier NotAllControlCharacters(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllControlCharacters).Count(exactCount);
        }

        public static Quantifier NotAllControlCharacters(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllControlCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllDiacriticMarks()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllDiacriticMarks);
        }

        public static Quantifier AllDiacriticMarks(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllDiacriticMarks).Count(exactCount);
        }

        public static Quantifier AllDiacriticMarks(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllDiacriticMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllDiacriticMarks()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllDiacriticMarks);
        }

        public static Quantifier NotAllDiacriticMarks(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllDiacriticMarks).Count(exactCount);
        }

        public static Quantifier NotAllDiacriticMarks(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllDiacriticMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllLetterCharacters()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllLetterCharacters);
        }

        public static Quantifier AllLetterCharacters(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllLetterCharacters).Count(exactCount);
        }

        public static Quantifier AllLetterCharacters(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllLetterCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllLetterCharacters()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllLetterCharacters);
        }

        public static Quantifier NotAllLetterCharacters(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllLetterCharacters).Count(exactCount);
        }

        public static Quantifier NotAllLetterCharacters(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllLetterCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllNumbers()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllNumbers);
        }

        public static Quantifier AllNumbers(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllNumbers).Count(exactCount);
        }

        public static Quantifier AllNumbers(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllNumbers).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllNumbers()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllNumbers);
        }

        public static Quantifier NotAllNumbers(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllNumbers).Count(exactCount);
        }

        public static Quantifier NotAllNumbers(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllNumbers).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllPunctuationCharacters()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllPunctuationCharacters);
        }

        public static Quantifier AllPunctuationCharacters(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllPunctuationCharacters).Count(exactCount);
        }

        public static Quantifier AllPunctuationCharacters(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllPunctuationCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllPunctuationCharacters()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllPunctuationCharacters);
        }

        public static Quantifier NotAllPunctuationCharacters(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllPunctuationCharacters).Count(exactCount);
        }

        public static Quantifier NotAllPunctuationCharacters(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllPunctuationCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllSeparatorCharacters()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllSeparatorCharacters);
        }

        public static Quantifier AllSeparatorCharacters(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllSeparatorCharacters).Count(exactCount);
        }

        public static Quantifier AllSeparatorCharacters(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllSeparatorCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllSeparatorCharacters()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllSeparatorCharacters);
        }

        public static Quantifier NotAllSeparatorCharacters(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllSeparatorCharacters).Count(exactCount);
        }

        public static Quantifier NotAllSeparatorCharacters(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllSeparatorCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllSymbols()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllSymbols);
        }

        public static Quantifier AllSymbols(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllSymbols).Count(exactCount);
        }

        public static Quantifier AllSymbols(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.AllSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllSymbols()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllSymbols);
        }

        public static Quantifier NotAllSymbols(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllSymbols).Count(exactCount);
        }

        public static Quantifier NotAllSymbols(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.AllSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterLowercase()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterLowercase);
        }

        public static Quantifier LetterLowercase(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterLowercase).Count(exactCount);
        }

        public static Quantifier LetterLowercase(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterLowercase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterLowercase()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterLowercase);
        }

        public static Quantifier NotLetterLowercase(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterLowercase).Count(exactCount);
        }

        public static Quantifier NotLetterLowercase(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterLowercase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterModifier()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterModifier);
        }

        public static Quantifier LetterModifier(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterModifier).Count(exactCount);
        }

        public static Quantifier LetterModifier(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterModifier).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterModifier()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterModifier);
        }

        public static Quantifier NotLetterModifier(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterModifier).Count(exactCount);
        }

        public static Quantifier NotLetterModifier(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterModifier).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterOther()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterOther);
        }

        public static Quantifier LetterOther(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterOther).Count(exactCount);
        }

        public static Quantifier LetterOther(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterOther()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterOther);
        }

        public static Quantifier NotLetterOther(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterOther).Count(exactCount);
        }

        public static Quantifier NotLetterOther(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterTitlecase()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterTitlecase);
        }

        public static Quantifier LetterTitlecase(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterTitlecase).Count(exactCount);
        }

        public static Quantifier LetterTitlecase(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterTitlecase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterTitlecase()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterTitlecase);
        }

        public static Quantifier NotLetterTitlecase(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterTitlecase).Count(exactCount);
        }

        public static Quantifier NotLetterTitlecase(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterTitlecase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterUppercase()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterUppercase);
        }

        public static Quantifier LetterUppercase(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterUppercase).Count(exactCount);
        }

        public static Quantifier LetterUppercase(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.LetterUppercase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterUppercase()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterUppercase);
        }

        public static Quantifier NotLetterUppercase(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterUppercase).Count(exactCount);
        }

        public static Quantifier NotLetterUppercase(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.LetterUppercase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MarkEnclosing()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.MarkEnclosing);
        }

        public static Quantifier MarkEnclosing(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.MarkEnclosing).Count(exactCount);
        }

        public static Quantifier MarkEnclosing(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.MarkEnclosing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMarkEnclosing()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.MarkEnclosing);
        }

        public static Quantifier NotMarkEnclosing(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.MarkEnclosing).Count(exactCount);
        }

        public static Quantifier NotMarkEnclosing(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.MarkEnclosing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MarkNonspacing()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.MarkNonspacing);
        }

        public static Quantifier MarkNonspacing(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.MarkNonspacing).Count(exactCount);
        }

        public static Quantifier MarkNonspacing(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.MarkNonspacing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMarkNonspacing()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.MarkNonspacing);
        }

        public static Quantifier NotMarkNonspacing(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.MarkNonspacing).Count(exactCount);
        }

        public static Quantifier NotMarkNonspacing(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.MarkNonspacing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MarkSpacingCombining()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.MarkSpacingCombining);
        }

        public static Quantifier MarkSpacingCombining(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.MarkSpacingCombining).Count(exactCount);
        }

        public static Quantifier MarkSpacingCombining(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.MarkSpacingCombining).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMarkSpacingCombining()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.MarkSpacingCombining);
        }

        public static Quantifier NotMarkSpacingCombining(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.MarkSpacingCombining).Count(exactCount);
        }

        public static Quantifier NotMarkSpacingCombining(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.MarkSpacingCombining).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberDecimalDigit()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.NumberDecimalDigit);
        }

        public static Quantifier NumberDecimalDigit(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.NumberDecimalDigit).Count(exactCount);
        }

        public static Quantifier NumberDecimalDigit(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.NumberDecimalDigit).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberDecimalDigit()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.NumberDecimalDigit);
        }

        public static Quantifier NotNumberDecimalDigit(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.NumberDecimalDigit).Count(exactCount);
        }

        public static Quantifier NotNumberDecimalDigit(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.NumberDecimalDigit).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberLetter()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.NumberLetter);
        }

        public static Quantifier NumberLetter(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.NumberLetter).Count(exactCount);
        }

        public static Quantifier NumberLetter(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.NumberLetter).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberLetter()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.NumberLetter);
        }

        public static Quantifier NotNumberLetter(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.NumberLetter).Count(exactCount);
        }

        public static Quantifier NotNumberLetter(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.NumberLetter).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberOther()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.NumberOther);
        }

        public static Quantifier NumberOther(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.NumberOther).Count(exactCount);
        }

        public static Quantifier NumberOther(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.NumberOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberOther()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.NumberOther);
        }

        public static Quantifier NotNumberOther(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.NumberOther).Count(exactCount);
        }

        public static Quantifier NotNumberOther(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.NumberOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherControl()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherControl);
        }

        public static Quantifier OtherControl(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherControl).Count(exactCount);
        }

        public static Quantifier OtherControl(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherControl).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherControl()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherControl);
        }

        public static Quantifier NotOtherControl(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherControl).Count(exactCount);
        }

        public static Quantifier NotOtherControl(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherControl).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherFormat()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherFormat);
        }

        public static Quantifier OtherFormat(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherFormat).Count(exactCount);
        }

        public static Quantifier OtherFormat(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherFormat).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherFormat()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherFormat);
        }

        public static Quantifier NotOtherFormat(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherFormat).Count(exactCount);
        }

        public static Quantifier NotOtherFormat(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherFormat).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherNotAssigned()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherNotAssigned);
        }

        public static Quantifier OtherNotAssigned(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherNotAssigned).Count(exactCount);
        }

        public static Quantifier OtherNotAssigned(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherNotAssigned).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherNotAssigned()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherNotAssigned);
        }

        public static Quantifier NotOtherNotAssigned(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherNotAssigned).Count(exactCount);
        }

        public static Quantifier NotOtherNotAssigned(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherNotAssigned).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherPrivateUse()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherPrivateUse);
        }

        public static Quantifier OtherPrivateUse(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherPrivateUse).Count(exactCount);
        }

        public static Quantifier OtherPrivateUse(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherPrivateUse).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherPrivateUse()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherPrivateUse);
        }

        public static Quantifier NotOtherPrivateUse(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherPrivateUse).Count(exactCount);
        }

        public static Quantifier NotOtherPrivateUse(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherPrivateUse).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherSurrogate()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherSurrogate);
        }

        public static Quantifier OtherSurrogate(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherSurrogate).Count(exactCount);
        }

        public static Quantifier OtherSurrogate(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.OtherSurrogate).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherSurrogate()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherSurrogate);
        }

        public static Quantifier NotOtherSurrogate(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherSurrogate).Count(exactCount);
        }

        public static Quantifier NotOtherSurrogate(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.OtherSurrogate).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationClose()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationClose);
        }

        public static Quantifier PunctuationClose(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationClose).Count(exactCount);
        }

        public static Quantifier PunctuationClose(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationClose).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationClose()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationClose);
        }

        public static Quantifier NotPunctuationClose(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationClose).Count(exactCount);
        }

        public static Quantifier NotPunctuationClose(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationClose).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationConnector()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationConnector);
        }

        public static Quantifier PunctuationConnector(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationConnector).Count(exactCount);
        }

        public static Quantifier PunctuationConnector(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationConnector).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationConnector()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationConnector);
        }

        public static Quantifier NotPunctuationConnector(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationConnector).Count(exactCount);
        }

        public static Quantifier NotPunctuationConnector(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationConnector).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationDash()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationDash);
        }

        public static Quantifier PunctuationDash(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationDash).Count(exactCount);
        }

        public static Quantifier PunctuationDash(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationDash).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationDash()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationDash);
        }

        public static Quantifier NotPunctuationDash(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationDash).Count(exactCount);
        }

        public static Quantifier NotPunctuationDash(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationDash).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationFinalQuote()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationFinalQuote);
        }

        public static Quantifier PunctuationFinalQuote(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationFinalQuote).Count(exactCount);
        }

        public static Quantifier PunctuationFinalQuote(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationFinalQuote).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationFinalQuote()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationFinalQuote);
        }

        public static Quantifier NotPunctuationFinalQuote(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationFinalQuote).Count(exactCount);
        }

        public static Quantifier NotPunctuationFinalQuote(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationFinalQuote).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationInitialQuote()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationInitialQuote);
        }

        public static Quantifier PunctuationInitialQuote(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationInitialQuote).Count(exactCount);
        }

        public static Quantifier PunctuationInitialQuote(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationInitialQuote).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationInitialQuote()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationInitialQuote);
        }

        public static Quantifier NotPunctuationInitialQuote(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationInitialQuote).Count(exactCount);
        }

        public static Quantifier NotPunctuationInitialQuote(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationInitialQuote).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationOpen()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationOpen);
        }

        public static Quantifier PunctuationOpen(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationOpen).Count(exactCount);
        }

        public static Quantifier PunctuationOpen(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationOpen).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationOpen()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationOpen);
        }

        public static Quantifier NotPunctuationOpen(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationOpen).Count(exactCount);
        }

        public static Quantifier NotPunctuationOpen(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationOpen).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationOther()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationOther);
        }

        public static Quantifier PunctuationOther(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationOther).Count(exactCount);
        }

        public static Quantifier PunctuationOther(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.PunctuationOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationOther()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationOther);
        }

        public static Quantifier NotPunctuationOther(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationOther).Count(exactCount);
        }

        public static Quantifier NotPunctuationOther(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.PunctuationOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SeparatorLine()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SeparatorLine);
        }

        public static Quantifier SeparatorLine(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SeparatorLine).Count(exactCount);
        }

        public static Quantifier SeparatorLine(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SeparatorLine).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSeparatorLine()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SeparatorLine);
        }

        public static Quantifier NotSeparatorLine(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SeparatorLine).Count(exactCount);
        }

        public static Quantifier NotSeparatorLine(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SeparatorLine).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SeparatorParagraph()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SeparatorParagraph);
        }

        public static Quantifier SeparatorParagraph(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SeparatorParagraph).Count(exactCount);
        }

        public static Quantifier SeparatorParagraph(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SeparatorParagraph).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSeparatorParagraph()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SeparatorParagraph);
        }

        public static Quantifier NotSeparatorParagraph(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SeparatorParagraph).Count(exactCount);
        }

        public static Quantifier NotSeparatorParagraph(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SeparatorParagraph).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SeparatorSpace()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SeparatorSpace);
        }

        public static Quantifier SeparatorSpace(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SeparatorSpace).Count(exactCount);
        }

        public static Quantifier SeparatorSpace(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SeparatorSpace).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSeparatorSpace()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SeparatorSpace);
        }

        public static Quantifier NotSeparatorSpace(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SeparatorSpace).Count(exactCount);
        }

        public static Quantifier NotSeparatorSpace(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SeparatorSpace).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SymbolCurrency()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SymbolCurrency);
        }

        public static Quantifier SymbolCurrency(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SymbolCurrency).Count(exactCount);
        }

        public static Quantifier SymbolCurrency(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SymbolCurrency).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSymbolCurrency()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SymbolCurrency);
        }

        public static Quantifier NotSymbolCurrency(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SymbolCurrency).Count(exactCount);
        }

        public static Quantifier NotSymbolCurrency(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SymbolCurrency).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SymbolMath()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SymbolMath);
        }

        public static Quantifier SymbolMath(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SymbolMath).Count(exactCount);
        }

        public static Quantifier SymbolMath(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SymbolMath).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSymbolMath()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SymbolMath);
        }

        public static Quantifier NotSymbolMath(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SymbolMath).Count(exactCount);
        }

        public static Quantifier NotSymbolMath(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SymbolMath).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SymbolModifier()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SymbolModifier);
        }

        public static Quantifier SymbolModifier(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SymbolModifier).Count(exactCount);
        }

        public static Quantifier SymbolModifier(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SymbolModifier).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSymbolModifier()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SymbolModifier);
        }

        public static Quantifier NotSymbolModifier(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SymbolModifier).Count(exactCount);
        }

        public static Quantifier NotSymbolModifier(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SymbolModifier).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SymbolOther()
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SymbolOther);
        }

        public static Quantifier SymbolOther(int exactCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SymbolOther).Count(exactCount);
        }

        public static Quantifier SymbolOther(int minCount, int maxCount)
        {
            return Expressions.UnicodeCategory(UnicodeCategory.SymbolOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSymbolOther()
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SymbolOther);
        }

        public static Quantifier NotSymbolOther(int exactCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SymbolOther).Count(exactCount);
        }

        public static Quantifier NotSymbolOther(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeCategory(UnicodeCategory.SymbolOther).Count(minCount, maxCount);
        }
    }
}
