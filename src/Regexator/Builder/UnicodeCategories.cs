// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class UnicodeCategories
    {
        public static QuantifiableExpression AllControlCharacters()
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllControlCharacters);
        }

        public static Quantifier AllControlCharacters(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllControlCharacters).Count(exactCount);
        }

        public static Quantifier AllControlCharacters(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllControlCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllControlCharacters()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllControlCharacters);
        }

        public static Quantifier NotAllControlCharacters(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllControlCharacters).Count(exactCount);
        }

        public static Quantifier NotAllControlCharacters(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllControlCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllDiacriticMarks()
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllDiacriticMarks);
        }

        public static Quantifier AllDiacriticMarks(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllDiacriticMarks).Count(exactCount);
        }

        public static Quantifier AllDiacriticMarks(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllDiacriticMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllDiacriticMarks()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllDiacriticMarks);
        }

        public static Quantifier NotAllDiacriticMarks(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllDiacriticMarks).Count(exactCount);
        }

        public static Quantifier NotAllDiacriticMarks(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllDiacriticMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllLetterCharacters()
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllLetterCharacters);
        }

        public static Quantifier AllLetterCharacters(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllLetterCharacters).Count(exactCount);
        }

        public static Quantifier AllLetterCharacters(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllLetterCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllLetterCharacters()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllLetterCharacters);
        }

        public static Quantifier NotAllLetterCharacters(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllLetterCharacters).Count(exactCount);
        }

        public static Quantifier NotAllLetterCharacters(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllLetterCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllNumbers()
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllNumbers);
        }

        public static Quantifier AllNumbers(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllNumbers).Count(exactCount);
        }

        public static Quantifier AllNumbers(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllNumbers).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllNumbers()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllNumbers);
        }

        public static Quantifier NotAllNumbers(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllNumbers).Count(exactCount);
        }

        public static Quantifier NotAllNumbers(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllNumbers).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllPunctuationCharacters()
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllPunctuationCharacters);
        }

        public static Quantifier AllPunctuationCharacters(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllPunctuationCharacters).Count(exactCount);
        }

        public static Quantifier AllPunctuationCharacters(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllPunctuationCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllPunctuationCharacters()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllPunctuationCharacters);
        }

        public static Quantifier NotAllPunctuationCharacters(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllPunctuationCharacters).Count(exactCount);
        }

        public static Quantifier NotAllPunctuationCharacters(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllPunctuationCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllSeparatorCharacters()
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllSeparatorCharacters);
        }

        public static Quantifier AllSeparatorCharacters(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllSeparatorCharacters).Count(exactCount);
        }

        public static Quantifier AllSeparatorCharacters(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllSeparatorCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllSeparatorCharacters()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllSeparatorCharacters);
        }

        public static Quantifier NotAllSeparatorCharacters(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllSeparatorCharacters).Count(exactCount);
        }

        public static Quantifier NotAllSeparatorCharacters(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllSeparatorCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllSymbols()
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllSymbols);
        }

        public static Quantifier AllSymbols(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllSymbols).Count(exactCount);
        }

        public static Quantifier AllSymbols(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.AllSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllSymbols()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllSymbols);
        }

        public static Quantifier NotAllSymbols(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllSymbols).Count(exactCount);
        }

        public static Quantifier NotAllSymbols(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.AllSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterLowercase()
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterLowercase);
        }

        public static Quantifier LetterLowercase(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterLowercase).Count(exactCount);
        }

        public static Quantifier LetterLowercase(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterLowercase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterLowercase()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterLowercase);
        }

        public static Quantifier NotLetterLowercase(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterLowercase).Count(exactCount);
        }

        public static Quantifier NotLetterLowercase(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterLowercase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterModifier()
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterModifier);
        }

        public static Quantifier LetterModifier(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterModifier).Count(exactCount);
        }

        public static Quantifier LetterModifier(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterModifier).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterModifier()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterModifier);
        }

        public static Quantifier NotLetterModifier(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterModifier).Count(exactCount);
        }

        public static Quantifier NotLetterModifier(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterModifier).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterOther()
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterOther);
        }

        public static Quantifier LetterOther(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterOther).Count(exactCount);
        }

        public static Quantifier LetterOther(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterOther()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterOther);
        }

        public static Quantifier NotLetterOther(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterOther).Count(exactCount);
        }

        public static Quantifier NotLetterOther(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterTitlecase()
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterTitlecase);
        }

        public static Quantifier LetterTitlecase(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterTitlecase).Count(exactCount);
        }

        public static Quantifier LetterTitlecase(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterTitlecase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterTitlecase()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterTitlecase);
        }

        public static Quantifier NotLetterTitlecase(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterTitlecase).Count(exactCount);
        }

        public static Quantifier NotLetterTitlecase(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterTitlecase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterUppercase()
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterUppercase);
        }

        public static Quantifier LetterUppercase(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterUppercase).Count(exactCount);
        }

        public static Quantifier LetterUppercase(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.LetterUppercase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterUppercase()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterUppercase);
        }

        public static Quantifier NotLetterUppercase(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterUppercase).Count(exactCount);
        }

        public static Quantifier NotLetterUppercase(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.LetterUppercase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MarkEnclosing()
        {
            return Characters.UnicodeCategory(UnicodeCategory.MarkEnclosing);
        }

        public static Quantifier MarkEnclosing(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.MarkEnclosing).Count(exactCount);
        }

        public static Quantifier MarkEnclosing(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.MarkEnclosing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMarkEnclosing()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.MarkEnclosing);
        }

        public static Quantifier NotMarkEnclosing(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.MarkEnclosing).Count(exactCount);
        }

        public static Quantifier NotMarkEnclosing(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.MarkEnclosing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MarkNonspacing()
        {
            return Characters.UnicodeCategory(UnicodeCategory.MarkNonspacing);
        }

        public static Quantifier MarkNonspacing(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.MarkNonspacing).Count(exactCount);
        }

        public static Quantifier MarkNonspacing(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.MarkNonspacing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMarkNonspacing()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.MarkNonspacing);
        }

        public static Quantifier NotMarkNonspacing(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.MarkNonspacing).Count(exactCount);
        }

        public static Quantifier NotMarkNonspacing(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.MarkNonspacing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MarkSpacingCombining()
        {
            return Characters.UnicodeCategory(UnicodeCategory.MarkSpacingCombining);
        }

        public static Quantifier MarkSpacingCombining(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.MarkSpacingCombining).Count(exactCount);
        }

        public static Quantifier MarkSpacingCombining(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.MarkSpacingCombining).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMarkSpacingCombining()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.MarkSpacingCombining);
        }

        public static Quantifier NotMarkSpacingCombining(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.MarkSpacingCombining).Count(exactCount);
        }

        public static Quantifier NotMarkSpacingCombining(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.MarkSpacingCombining).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberDecimalDigit()
        {
            return Characters.UnicodeCategory(UnicodeCategory.NumberDecimalDigit);
        }

        public static Quantifier NumberDecimalDigit(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.NumberDecimalDigit).Count(exactCount);
        }

        public static Quantifier NumberDecimalDigit(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.NumberDecimalDigit).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberDecimalDigit()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.NumberDecimalDigit);
        }

        public static Quantifier NotNumberDecimalDigit(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.NumberDecimalDigit).Count(exactCount);
        }

        public static Quantifier NotNumberDecimalDigit(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.NumberDecimalDigit).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberLetter()
        {
            return Characters.UnicodeCategory(UnicodeCategory.NumberLetter);
        }

        public static Quantifier NumberLetter(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.NumberLetter).Count(exactCount);
        }

        public static Quantifier NumberLetter(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.NumberLetter).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberLetter()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.NumberLetter);
        }

        public static Quantifier NotNumberLetter(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.NumberLetter).Count(exactCount);
        }

        public static Quantifier NotNumberLetter(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.NumberLetter).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberOther()
        {
            return Characters.UnicodeCategory(UnicodeCategory.NumberOther);
        }

        public static Quantifier NumberOther(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.NumberOther).Count(exactCount);
        }

        public static Quantifier NumberOther(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.NumberOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberOther()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.NumberOther);
        }

        public static Quantifier NotNumberOther(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.NumberOther).Count(exactCount);
        }

        public static Quantifier NotNumberOther(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.NumberOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherControl()
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherControl);
        }

        public static Quantifier OtherControl(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherControl).Count(exactCount);
        }

        public static Quantifier OtherControl(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherControl).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherControl()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherControl);
        }

        public static Quantifier NotOtherControl(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherControl).Count(exactCount);
        }

        public static Quantifier NotOtherControl(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherControl).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherFormat()
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherFormat);
        }

        public static Quantifier OtherFormat(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherFormat).Count(exactCount);
        }

        public static Quantifier OtherFormat(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherFormat).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherFormat()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherFormat);
        }

        public static Quantifier NotOtherFormat(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherFormat).Count(exactCount);
        }

        public static Quantifier NotOtherFormat(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherFormat).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherNotAssigned()
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherNotAssigned);
        }

        public static Quantifier OtherNotAssigned(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherNotAssigned).Count(exactCount);
        }

        public static Quantifier OtherNotAssigned(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherNotAssigned).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherNotAssigned()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherNotAssigned);
        }

        public static Quantifier NotOtherNotAssigned(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherNotAssigned).Count(exactCount);
        }

        public static Quantifier NotOtherNotAssigned(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherNotAssigned).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherPrivateUse()
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherPrivateUse);
        }

        public static Quantifier OtherPrivateUse(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherPrivateUse).Count(exactCount);
        }

        public static Quantifier OtherPrivateUse(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherPrivateUse).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherPrivateUse()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherPrivateUse);
        }

        public static Quantifier NotOtherPrivateUse(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherPrivateUse).Count(exactCount);
        }

        public static Quantifier NotOtherPrivateUse(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherPrivateUse).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherSurrogate()
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherSurrogate);
        }

        public static Quantifier OtherSurrogate(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherSurrogate).Count(exactCount);
        }

        public static Quantifier OtherSurrogate(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.OtherSurrogate).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherSurrogate()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherSurrogate);
        }

        public static Quantifier NotOtherSurrogate(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherSurrogate).Count(exactCount);
        }

        public static Quantifier NotOtherSurrogate(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.OtherSurrogate).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationClose()
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationClose);
        }

        public static Quantifier PunctuationClose(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationClose).Count(exactCount);
        }

        public static Quantifier PunctuationClose(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationClose).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationClose()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationClose);
        }

        public static Quantifier NotPunctuationClose(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationClose).Count(exactCount);
        }

        public static Quantifier NotPunctuationClose(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationClose).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationConnector()
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationConnector);
        }

        public static Quantifier PunctuationConnector(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationConnector).Count(exactCount);
        }

        public static Quantifier PunctuationConnector(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationConnector).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationConnector()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationConnector);
        }

        public static Quantifier NotPunctuationConnector(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationConnector).Count(exactCount);
        }

        public static Quantifier NotPunctuationConnector(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationConnector).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationDash()
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationDash);
        }

        public static Quantifier PunctuationDash(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationDash).Count(exactCount);
        }

        public static Quantifier PunctuationDash(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationDash).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationDash()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationDash);
        }

        public static Quantifier NotPunctuationDash(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationDash).Count(exactCount);
        }

        public static Quantifier NotPunctuationDash(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationDash).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationFinalQuote()
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationFinalQuote);
        }

        public static Quantifier PunctuationFinalQuote(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationFinalQuote).Count(exactCount);
        }

        public static Quantifier PunctuationFinalQuote(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationFinalQuote).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationFinalQuote()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationFinalQuote);
        }

        public static Quantifier NotPunctuationFinalQuote(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationFinalQuote).Count(exactCount);
        }

        public static Quantifier NotPunctuationFinalQuote(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationFinalQuote).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationInitialQuote()
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationInitialQuote);
        }

        public static Quantifier PunctuationInitialQuote(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationInitialQuote).Count(exactCount);
        }

        public static Quantifier PunctuationInitialQuote(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationInitialQuote).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationInitialQuote()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationInitialQuote);
        }

        public static Quantifier NotPunctuationInitialQuote(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationInitialQuote).Count(exactCount);
        }

        public static Quantifier NotPunctuationInitialQuote(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationInitialQuote).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationOpen()
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationOpen);
        }

        public static Quantifier PunctuationOpen(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationOpen).Count(exactCount);
        }

        public static Quantifier PunctuationOpen(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationOpen).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationOpen()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationOpen);
        }

        public static Quantifier NotPunctuationOpen(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationOpen).Count(exactCount);
        }

        public static Quantifier NotPunctuationOpen(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationOpen).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationOther()
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationOther);
        }

        public static Quantifier PunctuationOther(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationOther).Count(exactCount);
        }

        public static Quantifier PunctuationOther(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.PunctuationOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationOther()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationOther);
        }

        public static Quantifier NotPunctuationOther(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationOther).Count(exactCount);
        }

        public static Quantifier NotPunctuationOther(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.PunctuationOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SeparatorLine()
        {
            return Characters.UnicodeCategory(UnicodeCategory.SeparatorLine);
        }

        public static Quantifier SeparatorLine(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SeparatorLine).Count(exactCount);
        }

        public static Quantifier SeparatorLine(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SeparatorLine).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSeparatorLine()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SeparatorLine);
        }

        public static Quantifier NotSeparatorLine(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SeparatorLine).Count(exactCount);
        }

        public static Quantifier NotSeparatorLine(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SeparatorLine).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SeparatorParagraph()
        {
            return Characters.UnicodeCategory(UnicodeCategory.SeparatorParagraph);
        }

        public static Quantifier SeparatorParagraph(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SeparatorParagraph).Count(exactCount);
        }

        public static Quantifier SeparatorParagraph(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SeparatorParagraph).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSeparatorParagraph()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SeparatorParagraph);
        }

        public static Quantifier NotSeparatorParagraph(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SeparatorParagraph).Count(exactCount);
        }

        public static Quantifier NotSeparatorParagraph(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SeparatorParagraph).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SeparatorSpace()
        {
            return Characters.UnicodeCategory(UnicodeCategory.SeparatorSpace);
        }

        public static Quantifier SeparatorSpace(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SeparatorSpace).Count(exactCount);
        }

        public static Quantifier SeparatorSpace(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SeparatorSpace).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSeparatorSpace()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SeparatorSpace);
        }

        public static Quantifier NotSeparatorSpace(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SeparatorSpace).Count(exactCount);
        }

        public static Quantifier NotSeparatorSpace(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SeparatorSpace).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SymbolCurrency()
        {
            return Characters.UnicodeCategory(UnicodeCategory.SymbolCurrency);
        }

        public static Quantifier SymbolCurrency(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SymbolCurrency).Count(exactCount);
        }

        public static Quantifier SymbolCurrency(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SymbolCurrency).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSymbolCurrency()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SymbolCurrency);
        }

        public static Quantifier NotSymbolCurrency(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SymbolCurrency).Count(exactCount);
        }

        public static Quantifier NotSymbolCurrency(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SymbolCurrency).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SymbolMath()
        {
            return Characters.UnicodeCategory(UnicodeCategory.SymbolMath);
        }

        public static Quantifier SymbolMath(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SymbolMath).Count(exactCount);
        }

        public static Quantifier SymbolMath(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SymbolMath).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSymbolMath()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SymbolMath);
        }

        public static Quantifier NotSymbolMath(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SymbolMath).Count(exactCount);
        }

        public static Quantifier NotSymbolMath(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SymbolMath).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SymbolModifier()
        {
            return Characters.UnicodeCategory(UnicodeCategory.SymbolModifier);
        }

        public static Quantifier SymbolModifier(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SymbolModifier).Count(exactCount);
        }

        public static Quantifier SymbolModifier(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SymbolModifier).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSymbolModifier()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SymbolModifier);
        }

        public static Quantifier NotSymbolModifier(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SymbolModifier).Count(exactCount);
        }

        public static Quantifier NotSymbolModifier(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SymbolModifier).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SymbolOther()
        {
            return Characters.UnicodeCategory(UnicodeCategory.SymbolOther);
        }

        public static Quantifier SymbolOther(int exactCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SymbolOther).Count(exactCount);
        }

        public static Quantifier SymbolOther(int minCount, int maxCount)
        {
            return Characters.UnicodeCategory(UnicodeCategory.SymbolOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSymbolOther()
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SymbolOther);
        }

        public static Quantifier NotSymbolOther(int exactCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SymbolOther).Count(exactCount);
        }

        public static Quantifier NotSymbolOther(int minCount, int maxCount)
        {
            return Characters.NotUnicodeCategory(UnicodeCategory.SymbolOther).Count(minCount, maxCount);
        }
    }
}
