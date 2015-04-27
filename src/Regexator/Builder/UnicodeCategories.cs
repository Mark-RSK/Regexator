// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class UnicodeCategories
    {
        public static QuantifiableExpression AllControlCharacters()
        {
            return Character.UnicodeCategory(UnicodeCategory.AllControlCharacters);
        }

        public static QuantifierExpression AllControlCharacters(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllControlCharacters).Count(exactCount);
        }

        public static QuantifierExpression AllControlCharacters(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllControlCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllControlCharacters()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllControlCharacters);
        }

        public static QuantifierExpression NotAllControlCharacters(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllControlCharacters).Count(exactCount);
        }

        public static QuantifierExpression NotAllControlCharacters(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllControlCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllDiacriticMarks()
        {
            return Character.UnicodeCategory(UnicodeCategory.AllDiacriticMarks);
        }

        public static QuantifierExpression AllDiacriticMarks(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllDiacriticMarks).Count(exactCount);
        }

        public static QuantifierExpression AllDiacriticMarks(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllDiacriticMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllDiacriticMarks()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllDiacriticMarks);
        }

        public static QuantifierExpression NotAllDiacriticMarks(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllDiacriticMarks).Count(exactCount);
        }

        public static QuantifierExpression NotAllDiacriticMarks(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllDiacriticMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllLetterCharacters()
        {
            return Character.UnicodeCategory(UnicodeCategory.AllLetterCharacters);
        }

        public static QuantifierExpression AllLetterCharacters(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllLetterCharacters).Count(exactCount);
        }

        public static QuantifierExpression AllLetterCharacters(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllLetterCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllLetterCharacters()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllLetterCharacters);
        }

        public static QuantifierExpression NotAllLetterCharacters(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllLetterCharacters).Count(exactCount);
        }

        public static QuantifierExpression NotAllLetterCharacters(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllLetterCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllNumbers()
        {
            return Character.UnicodeCategory(UnicodeCategory.AllNumbers);
        }

        public static QuantifierExpression AllNumbers(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllNumbers).Count(exactCount);
        }

        public static QuantifierExpression AllNumbers(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllNumbers).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllNumbers()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllNumbers);
        }

        public static QuantifierExpression NotAllNumbers(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllNumbers).Count(exactCount);
        }

        public static QuantifierExpression NotAllNumbers(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllNumbers).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllPunctuationCharacters()
        {
            return Character.UnicodeCategory(UnicodeCategory.AllPunctuationCharacters);
        }

        public static QuantifierExpression AllPunctuationCharacters(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllPunctuationCharacters).Count(exactCount);
        }

        public static QuantifierExpression AllPunctuationCharacters(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllPunctuationCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllPunctuationCharacters()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllPunctuationCharacters);
        }

        public static QuantifierExpression NotAllPunctuationCharacters(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllPunctuationCharacters).Count(exactCount);
        }

        public static QuantifierExpression NotAllPunctuationCharacters(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllPunctuationCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllSeparatorCharacters()
        {
            return Character.UnicodeCategory(UnicodeCategory.AllSeparatorCharacters);
        }

        public static QuantifierExpression AllSeparatorCharacters(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllSeparatorCharacters).Count(exactCount);
        }

        public static QuantifierExpression AllSeparatorCharacters(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllSeparatorCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllSeparatorCharacters()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllSeparatorCharacters);
        }

        public static QuantifierExpression NotAllSeparatorCharacters(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllSeparatorCharacters).Count(exactCount);
        }

        public static QuantifierExpression NotAllSeparatorCharacters(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllSeparatorCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression AllSymbols()
        {
            return Character.UnicodeCategory(UnicodeCategory.AllSymbols);
        }

        public static QuantifierExpression AllSymbols(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllSymbols).Count(exactCount);
        }

        public static QuantifierExpression AllSymbols(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.AllSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAllSymbols()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllSymbols);
        }

        public static QuantifierExpression NotAllSymbols(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllSymbols).Count(exactCount);
        }

        public static QuantifierExpression NotAllSymbols(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.AllSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterLowercase()
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterLowercase);
        }

        public static QuantifierExpression LetterLowercase(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterLowercase).Count(exactCount);
        }

        public static QuantifierExpression LetterLowercase(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterLowercase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterLowercase()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterLowercase);
        }

        public static QuantifierExpression NotLetterLowercase(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterLowercase).Count(exactCount);
        }

        public static QuantifierExpression NotLetterLowercase(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterLowercase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterModifier()
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterModifier);
        }

        public static QuantifierExpression LetterModifier(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterModifier).Count(exactCount);
        }

        public static QuantifierExpression LetterModifier(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterModifier).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterModifier()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterModifier);
        }

        public static QuantifierExpression NotLetterModifier(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterModifier).Count(exactCount);
        }

        public static QuantifierExpression NotLetterModifier(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterModifier).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterOther()
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterOther);
        }

        public static QuantifierExpression LetterOther(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterOther).Count(exactCount);
        }

        public static QuantifierExpression LetterOther(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterOther()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterOther);
        }

        public static QuantifierExpression NotLetterOther(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterOther).Count(exactCount);
        }

        public static QuantifierExpression NotLetterOther(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterTitlecase()
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterTitlecase);
        }

        public static QuantifierExpression LetterTitlecase(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterTitlecase).Count(exactCount);
        }

        public static QuantifierExpression LetterTitlecase(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterTitlecase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterTitlecase()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterTitlecase);
        }

        public static QuantifierExpression NotLetterTitlecase(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterTitlecase).Count(exactCount);
        }

        public static QuantifierExpression NotLetterTitlecase(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterTitlecase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterUppercase()
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterUppercase);
        }

        public static QuantifierExpression LetterUppercase(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterUppercase).Count(exactCount);
        }

        public static QuantifierExpression LetterUppercase(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.LetterUppercase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterUppercase()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterUppercase);
        }

        public static QuantifierExpression NotLetterUppercase(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterUppercase).Count(exactCount);
        }

        public static QuantifierExpression NotLetterUppercase(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.LetterUppercase).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MarkEnclosing()
        {
            return Character.UnicodeCategory(UnicodeCategory.MarkEnclosing);
        }

        public static QuantifierExpression MarkEnclosing(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.MarkEnclosing).Count(exactCount);
        }

        public static QuantifierExpression MarkEnclosing(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.MarkEnclosing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMarkEnclosing()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.MarkEnclosing);
        }

        public static QuantifierExpression NotMarkEnclosing(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.MarkEnclosing).Count(exactCount);
        }

        public static QuantifierExpression NotMarkEnclosing(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.MarkEnclosing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MarkNonspacing()
        {
            return Character.UnicodeCategory(UnicodeCategory.MarkNonspacing);
        }

        public static QuantifierExpression MarkNonspacing(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.MarkNonspacing).Count(exactCount);
        }

        public static QuantifierExpression MarkNonspacing(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.MarkNonspacing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMarkNonspacing()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.MarkNonspacing);
        }

        public static QuantifierExpression NotMarkNonspacing(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.MarkNonspacing).Count(exactCount);
        }

        public static QuantifierExpression NotMarkNonspacing(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.MarkNonspacing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MarkSpacingCombining()
        {
            return Character.UnicodeCategory(UnicodeCategory.MarkSpacingCombining);
        }

        public static QuantifierExpression MarkSpacingCombining(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.MarkSpacingCombining).Count(exactCount);
        }

        public static QuantifierExpression MarkSpacingCombining(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.MarkSpacingCombining).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMarkSpacingCombining()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.MarkSpacingCombining);
        }

        public static QuantifierExpression NotMarkSpacingCombining(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.MarkSpacingCombining).Count(exactCount);
        }

        public static QuantifierExpression NotMarkSpacingCombining(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.MarkSpacingCombining).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberDecimalDigit()
        {
            return Character.UnicodeCategory(UnicodeCategory.NumberDecimalDigit);
        }

        public static QuantifierExpression NumberDecimalDigit(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.NumberDecimalDigit).Count(exactCount);
        }

        public static QuantifierExpression NumberDecimalDigit(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.NumberDecimalDigit).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberDecimalDigit()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.NumberDecimalDigit);
        }

        public static QuantifierExpression NotNumberDecimalDigit(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.NumberDecimalDigit).Count(exactCount);
        }

        public static QuantifierExpression NotNumberDecimalDigit(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.NumberDecimalDigit).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberLetter()
        {
            return Character.UnicodeCategory(UnicodeCategory.NumberLetter);
        }

        public static QuantifierExpression NumberLetter(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.NumberLetter).Count(exactCount);
        }

        public static QuantifierExpression NumberLetter(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.NumberLetter).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberLetter()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.NumberLetter);
        }

        public static QuantifierExpression NotNumberLetter(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.NumberLetter).Count(exactCount);
        }

        public static QuantifierExpression NotNumberLetter(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.NumberLetter).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberOther()
        {
            return Character.UnicodeCategory(UnicodeCategory.NumberOther);
        }

        public static QuantifierExpression NumberOther(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.NumberOther).Count(exactCount);
        }

        public static QuantifierExpression NumberOther(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.NumberOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberOther()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.NumberOther);
        }

        public static QuantifierExpression NotNumberOther(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.NumberOther).Count(exactCount);
        }

        public static QuantifierExpression NotNumberOther(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.NumberOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherControl()
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherControl);
        }

        public static QuantifierExpression OtherControl(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherControl).Count(exactCount);
        }

        public static QuantifierExpression OtherControl(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherControl).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherControl()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherControl);
        }

        public static QuantifierExpression NotOtherControl(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherControl).Count(exactCount);
        }

        public static QuantifierExpression NotOtherControl(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherControl).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherFormat()
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherFormat);
        }

        public static QuantifierExpression OtherFormat(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherFormat).Count(exactCount);
        }

        public static QuantifierExpression OtherFormat(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherFormat).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherFormat()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherFormat);
        }

        public static QuantifierExpression NotOtherFormat(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherFormat).Count(exactCount);
        }

        public static QuantifierExpression NotOtherFormat(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherFormat).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherNotAssigned()
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherNotAssigned);
        }

        public static QuantifierExpression OtherNotAssigned(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherNotAssigned).Count(exactCount);
        }

        public static QuantifierExpression OtherNotAssigned(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherNotAssigned).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherNotAssigned()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherNotAssigned);
        }

        public static QuantifierExpression NotOtherNotAssigned(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherNotAssigned).Count(exactCount);
        }

        public static QuantifierExpression NotOtherNotAssigned(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherNotAssigned).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherPrivateUse()
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherPrivateUse);
        }

        public static QuantifierExpression OtherPrivateUse(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherPrivateUse).Count(exactCount);
        }

        public static QuantifierExpression OtherPrivateUse(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherPrivateUse).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherPrivateUse()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherPrivateUse);
        }

        public static QuantifierExpression NotOtherPrivateUse(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherPrivateUse).Count(exactCount);
        }

        public static QuantifierExpression NotOtherPrivateUse(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherPrivateUse).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OtherSurrogate()
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherSurrogate);
        }

        public static QuantifierExpression OtherSurrogate(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherSurrogate).Count(exactCount);
        }

        public static QuantifierExpression OtherSurrogate(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.OtherSurrogate).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOtherSurrogate()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherSurrogate);
        }

        public static QuantifierExpression NotOtherSurrogate(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherSurrogate).Count(exactCount);
        }

        public static QuantifierExpression NotOtherSurrogate(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.OtherSurrogate).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationClose()
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationClose);
        }

        public static QuantifierExpression PunctuationClose(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationClose).Count(exactCount);
        }

        public static QuantifierExpression PunctuationClose(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationClose).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationClose()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationClose);
        }

        public static QuantifierExpression NotPunctuationClose(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationClose).Count(exactCount);
        }

        public static QuantifierExpression NotPunctuationClose(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationClose).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationConnector()
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationConnector);
        }

        public static QuantifierExpression PunctuationConnector(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationConnector).Count(exactCount);
        }

        public static QuantifierExpression PunctuationConnector(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationConnector).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationConnector()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationConnector);
        }

        public static QuantifierExpression NotPunctuationConnector(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationConnector).Count(exactCount);
        }

        public static QuantifierExpression NotPunctuationConnector(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationConnector).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationDash()
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationDash);
        }

        public static QuantifierExpression PunctuationDash(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationDash).Count(exactCount);
        }

        public static QuantifierExpression PunctuationDash(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationDash).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationDash()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationDash);
        }

        public static QuantifierExpression NotPunctuationDash(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationDash).Count(exactCount);
        }

        public static QuantifierExpression NotPunctuationDash(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationDash).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationFinalQuote()
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationFinalQuote);
        }

        public static QuantifierExpression PunctuationFinalQuote(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationFinalQuote).Count(exactCount);
        }

        public static QuantifierExpression PunctuationFinalQuote(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationFinalQuote).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationFinalQuote()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationFinalQuote);
        }

        public static QuantifierExpression NotPunctuationFinalQuote(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationFinalQuote).Count(exactCount);
        }

        public static QuantifierExpression NotPunctuationFinalQuote(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationFinalQuote).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationInitialQuote()
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationInitialQuote);
        }

        public static QuantifierExpression PunctuationInitialQuote(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationInitialQuote).Count(exactCount);
        }

        public static QuantifierExpression PunctuationInitialQuote(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationInitialQuote).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationInitialQuote()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationInitialQuote);
        }

        public static QuantifierExpression NotPunctuationInitialQuote(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationInitialQuote).Count(exactCount);
        }

        public static QuantifierExpression NotPunctuationInitialQuote(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationInitialQuote).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationOpen()
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationOpen);
        }

        public static QuantifierExpression PunctuationOpen(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationOpen).Count(exactCount);
        }

        public static QuantifierExpression PunctuationOpen(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationOpen).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationOpen()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationOpen);
        }

        public static QuantifierExpression NotPunctuationOpen(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationOpen).Count(exactCount);
        }

        public static QuantifierExpression NotPunctuationOpen(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationOpen).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PunctuationOther()
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationOther);
        }

        public static QuantifierExpression PunctuationOther(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationOther).Count(exactCount);
        }

        public static QuantifierExpression PunctuationOther(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.PunctuationOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPunctuationOther()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationOther);
        }

        public static QuantifierExpression NotPunctuationOther(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationOther).Count(exactCount);
        }

        public static QuantifierExpression NotPunctuationOther(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.PunctuationOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SeparatorLine()
        {
            return Character.UnicodeCategory(UnicodeCategory.SeparatorLine);
        }

        public static QuantifierExpression SeparatorLine(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SeparatorLine).Count(exactCount);
        }

        public static QuantifierExpression SeparatorLine(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SeparatorLine).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSeparatorLine()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SeparatorLine);
        }

        public static QuantifierExpression NotSeparatorLine(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SeparatorLine).Count(exactCount);
        }

        public static QuantifierExpression NotSeparatorLine(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SeparatorLine).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SeparatorParagraph()
        {
            return Character.UnicodeCategory(UnicodeCategory.SeparatorParagraph);
        }

        public static QuantifierExpression SeparatorParagraph(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SeparatorParagraph).Count(exactCount);
        }

        public static QuantifierExpression SeparatorParagraph(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SeparatorParagraph).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSeparatorParagraph()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SeparatorParagraph);
        }

        public static QuantifierExpression NotSeparatorParagraph(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SeparatorParagraph).Count(exactCount);
        }

        public static QuantifierExpression NotSeparatorParagraph(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SeparatorParagraph).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SeparatorSpace()
        {
            return Character.UnicodeCategory(UnicodeCategory.SeparatorSpace);
        }

        public static QuantifierExpression SeparatorSpace(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SeparatorSpace).Count(exactCount);
        }

        public static QuantifierExpression SeparatorSpace(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SeparatorSpace).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSeparatorSpace()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SeparatorSpace);
        }

        public static QuantifierExpression NotSeparatorSpace(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SeparatorSpace).Count(exactCount);
        }

        public static QuantifierExpression NotSeparatorSpace(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SeparatorSpace).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SymbolCurrency()
        {
            return Character.UnicodeCategory(UnicodeCategory.SymbolCurrency);
        }

        public static QuantifierExpression SymbolCurrency(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SymbolCurrency).Count(exactCount);
        }

        public static QuantifierExpression SymbolCurrency(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SymbolCurrency).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSymbolCurrency()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SymbolCurrency);
        }

        public static QuantifierExpression NotSymbolCurrency(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SymbolCurrency).Count(exactCount);
        }

        public static QuantifierExpression NotSymbolCurrency(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SymbolCurrency).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SymbolMath()
        {
            return Character.UnicodeCategory(UnicodeCategory.SymbolMath);
        }

        public static QuantifierExpression SymbolMath(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SymbolMath).Count(exactCount);
        }

        public static QuantifierExpression SymbolMath(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SymbolMath).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSymbolMath()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SymbolMath);
        }

        public static QuantifierExpression NotSymbolMath(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SymbolMath).Count(exactCount);
        }

        public static QuantifierExpression NotSymbolMath(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SymbolMath).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SymbolModifier()
        {
            return Character.UnicodeCategory(UnicodeCategory.SymbolModifier);
        }

        public static QuantifierExpression SymbolModifier(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SymbolModifier).Count(exactCount);
        }

        public static QuantifierExpression SymbolModifier(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SymbolModifier).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSymbolModifier()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SymbolModifier);
        }

        public static QuantifierExpression NotSymbolModifier(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SymbolModifier).Count(exactCount);
        }

        public static QuantifierExpression NotSymbolModifier(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SymbolModifier).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SymbolOther()
        {
            return Character.UnicodeCategory(UnicodeCategory.SymbolOther);
        }

        public static QuantifierExpression SymbolOther(int exactCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SymbolOther).Count(exactCount);
        }

        public static QuantifierExpression SymbolOther(int minCount, int maxCount)
        {
            return Character.UnicodeCategory(UnicodeCategory.SymbolOther).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSymbolOther()
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SymbolOther);
        }

        public static QuantifierExpression NotSymbolOther(int exactCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SymbolOther).Count(exactCount);
        }

        public static QuantifierExpression NotSymbolOther(int minCount, int maxCount)
        {
            return Character.NotUnicodeCategory(UnicodeCategory.SymbolOther).Count(minCount, maxCount);
        }
    }
}
