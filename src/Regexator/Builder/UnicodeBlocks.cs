// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class UnicodeBlocks
    {
        public static QuantifiableExpression AlphabeticPresentationForms()
        {
            return Character.UnicodeBlock(UnicodeBlock.AlphabeticPresentationForms);
        }

        public static QuantifierExpression AlphabeticPresentationForms(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.AlphabeticPresentationForms).Count(exactCount);
        }

        public static QuantifierExpression AlphabeticPresentationForms(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.AlphabeticPresentationForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAlphabeticPresentationForms()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.AlphabeticPresentationForms);
        }

        public static QuantifierExpression NotAlphabeticPresentationForms(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.AlphabeticPresentationForms).Count(exactCount);
        }

        public static QuantifierExpression NotAlphabeticPresentationForms(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.AlphabeticPresentationForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Arabic()
        {
            return Character.UnicodeBlock(UnicodeBlock.Arabic);
        }

        public static QuantifierExpression Arabic(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Arabic).Count(exactCount);
        }

        public static QuantifierExpression Arabic(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Arabic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArabic()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Arabic);
        }

        public static QuantifierExpression NotArabic(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Arabic).Count(exactCount);
        }

        public static QuantifierExpression NotArabic(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Arabic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression ArabicPresentationFormsA()
        {
            return Character.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsA);
        }

        public static QuantifierExpression ArabicPresentationFormsA(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsA).Count(exactCount);
        }

        public static QuantifierExpression ArabicPresentationFormsA(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArabicPresentationFormsA()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsA);
        }

        public static QuantifierExpression NotArabicPresentationFormsA(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsA).Count(exactCount);
        }

        public static QuantifierExpression NotArabicPresentationFormsA(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression ArabicPresentationFormsB()
        {
            return Character.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsB);
        }

        public static QuantifierExpression ArabicPresentationFormsB(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsB).Count(exactCount);
        }

        public static QuantifierExpression ArabicPresentationFormsB(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArabicPresentationFormsB()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsB);
        }

        public static QuantifierExpression NotArabicPresentationFormsB(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsB).Count(exactCount);
        }

        public static QuantifierExpression NotArabicPresentationFormsB(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Armenian()
        {
            return Character.UnicodeBlock(UnicodeBlock.Armenian);
        }

        public static QuantifierExpression Armenian(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Armenian).Count(exactCount);
        }

        public static QuantifierExpression Armenian(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Armenian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArmenian()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Armenian);
        }

        public static QuantifierExpression NotArmenian(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Armenian).Count(exactCount);
        }

        public static QuantifierExpression NotArmenian(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Armenian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Arrows()
        {
            return Character.UnicodeBlock(UnicodeBlock.Arrows);
        }

        public static QuantifierExpression Arrows(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Arrows).Count(exactCount);
        }

        public static QuantifierExpression Arrows(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Arrows).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArrows()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Arrows);
        }

        public static QuantifierExpression NotArrows(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Arrows).Count(exactCount);
        }

        public static QuantifierExpression NotArrows(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Arrows).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BasicLatin()
        {
            return Character.UnicodeBlock(UnicodeBlock.BasicLatin);
        }

        public static QuantifierExpression BasicLatin(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.BasicLatin).Count(exactCount);
        }

        public static QuantifierExpression BasicLatin(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.BasicLatin).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBasicLatin()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BasicLatin);
        }

        public static QuantifierExpression NotBasicLatin(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BasicLatin).Count(exactCount);
        }

        public static QuantifierExpression NotBasicLatin(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BasicLatin).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Bengali()
        {
            return Character.UnicodeBlock(UnicodeBlock.Bengali);
        }

        public static QuantifierExpression Bengali(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Bengali).Count(exactCount);
        }

        public static QuantifierExpression Bengali(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Bengali).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBengali()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Bengali);
        }

        public static QuantifierExpression NotBengali(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Bengali).Count(exactCount);
        }

        public static QuantifierExpression NotBengali(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Bengali).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BlockElements()
        {
            return Character.UnicodeBlock(UnicodeBlock.BlockElements);
        }

        public static QuantifierExpression BlockElements(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.BlockElements).Count(exactCount);
        }

        public static QuantifierExpression BlockElements(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.BlockElements).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBlockElements()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BlockElements);
        }

        public static QuantifierExpression NotBlockElements(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BlockElements).Count(exactCount);
        }

        public static QuantifierExpression NotBlockElements(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BlockElements).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Bopomofo()
        {
            return Character.UnicodeBlock(UnicodeBlock.Bopomofo);
        }

        public static QuantifierExpression Bopomofo(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Bopomofo).Count(exactCount);
        }

        public static QuantifierExpression Bopomofo(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Bopomofo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBopomofo()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Bopomofo);
        }

        public static QuantifierExpression NotBopomofo(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Bopomofo).Count(exactCount);
        }

        public static QuantifierExpression NotBopomofo(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Bopomofo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BopomofoExtended()
        {
            return Character.UnicodeBlock(UnicodeBlock.BopomofoExtended);
        }

        public static QuantifierExpression BopomofoExtended(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.BopomofoExtended).Count(exactCount);
        }

        public static QuantifierExpression BopomofoExtended(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.BopomofoExtended).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBopomofoExtended()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BopomofoExtended);
        }

        public static QuantifierExpression NotBopomofoExtended(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BopomofoExtended).Count(exactCount);
        }

        public static QuantifierExpression NotBopomofoExtended(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BopomofoExtended).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BoxDrawing()
        {
            return Character.UnicodeBlock(UnicodeBlock.BoxDrawing);
        }

        public static QuantifierExpression BoxDrawing(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.BoxDrawing).Count(exactCount);
        }

        public static QuantifierExpression BoxDrawing(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.BoxDrawing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBoxDrawing()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BoxDrawing);
        }

        public static QuantifierExpression NotBoxDrawing(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BoxDrawing).Count(exactCount);
        }

        public static QuantifierExpression NotBoxDrawing(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BoxDrawing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BraillePatterns()
        {
            return Character.UnicodeBlock(UnicodeBlock.BraillePatterns);
        }

        public static QuantifierExpression BraillePatterns(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.BraillePatterns).Count(exactCount);
        }

        public static QuantifierExpression BraillePatterns(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.BraillePatterns).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBraillePatterns()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BraillePatterns);
        }

        public static QuantifierExpression NotBraillePatterns(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BraillePatterns).Count(exactCount);
        }

        public static QuantifierExpression NotBraillePatterns(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.BraillePatterns).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Buhid()
        {
            return Character.UnicodeBlock(UnicodeBlock.Buhid);
        }

        public static QuantifierExpression Buhid(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Buhid).Count(exactCount);
        }

        public static QuantifierExpression Buhid(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Buhid).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBuhid()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Buhid);
        }

        public static QuantifierExpression NotBuhid(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Buhid).Count(exactCount);
        }

        public static QuantifierExpression NotBuhid(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Buhid).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKCompatibility()
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKCompatibility);
        }

        public static QuantifierExpression CJKCompatibility(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKCompatibility).Count(exactCount);
        }

        public static QuantifierExpression CJKCompatibility(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKCompatibility).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKCompatibility()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKCompatibility);
        }

        public static QuantifierExpression NotCJKCompatibility(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKCompatibility).Count(exactCount);
        }

        public static QuantifierExpression NotCJKCompatibility(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKCompatibility).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKCompatibilityForms()
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKCompatibilityForms);
        }

        public static QuantifierExpression CJKCompatibilityForms(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKCompatibilityForms).Count(exactCount);
        }

        public static QuantifierExpression CJKCompatibilityForms(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKCompatibilityForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKCompatibilityForms()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityForms);
        }

        public static QuantifierExpression NotCJKCompatibilityForms(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityForms).Count(exactCount);
        }

        public static QuantifierExpression NotCJKCompatibilityForms(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKCompatibilityIdeographs()
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs);
        }

        public static QuantifierExpression CJKCompatibilityIdeographs(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs).Count(exactCount);
        }

        public static QuantifierExpression CJKCompatibilityIdeographs(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKCompatibilityIdeographs()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs);
        }

        public static QuantifierExpression NotCJKCompatibilityIdeographs(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs).Count(exactCount);
        }

        public static QuantifierExpression NotCJKCompatibilityIdeographs(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKRadicalsSupplement()
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKRadicalsSupplement);
        }

        public static QuantifierExpression CJKRadicalsSupplement(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKRadicalsSupplement).Count(exactCount);
        }

        public static QuantifierExpression CJKRadicalsSupplement(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKRadicalsSupplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKRadicalsSupplement()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKRadicalsSupplement);
        }

        public static QuantifierExpression NotCJKRadicalsSupplement(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKRadicalsSupplement).Count(exactCount);
        }

        public static QuantifierExpression NotCJKRadicalsSupplement(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKRadicalsSupplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKSymbolsAndPunctuation()
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation);
        }

        public static QuantifierExpression CJKSymbolsAndPunctuation(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation).Count(exactCount);
        }

        public static QuantifierExpression CJKSymbolsAndPunctuation(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKSymbolsAndPunctuation()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation);
        }

        public static QuantifierExpression NotCJKSymbolsAndPunctuation(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation).Count(exactCount);
        }

        public static QuantifierExpression NotCJKSymbolsAndPunctuation(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKUnifiedIdeographs()
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs);
        }

        public static QuantifierExpression CJKUnifiedIdeographs(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs).Count(exactCount);
        }

        public static QuantifierExpression CJKUnifiedIdeographs(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKUnifiedIdeographs()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs);
        }

        public static QuantifierExpression NotCJKUnifiedIdeographs(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs).Count(exactCount);
        }

        public static QuantifierExpression NotCJKUnifiedIdeographs(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKUnifiedIdeographsExtensionA()
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA);
        }

        public static QuantifierExpression CJKUnifiedIdeographsExtensionA(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA).Count(exactCount);
        }

        public static QuantifierExpression CJKUnifiedIdeographsExtensionA(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKUnifiedIdeographsExtensionA()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA);
        }

        public static QuantifierExpression NotCJKUnifiedIdeographsExtensionA(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA).Count(exactCount);
        }

        public static QuantifierExpression NotCJKUnifiedIdeographsExtensionA(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CombiningDiacriticalMarks()
        {
            return Character.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks);
        }

        public static QuantifierExpression CombiningDiacriticalMarks(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks).Count(exactCount);
        }

        public static QuantifierExpression CombiningDiacriticalMarks(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCombiningDiacriticalMarks()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks);
        }

        public static QuantifierExpression NotCombiningDiacriticalMarks(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks).Count(exactCount);
        }

        public static QuantifierExpression NotCombiningDiacriticalMarks(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CombiningDiacriticalMarksForSymbols()
        {
            return Character.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols);
        }

        public static QuantifierExpression CombiningDiacriticalMarksForSymbols(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols).Count(exactCount);
        }

        public static QuantifierExpression CombiningDiacriticalMarksForSymbols(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCombiningDiacriticalMarksForSymbols()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols);
        }

        public static QuantifierExpression NotCombiningDiacriticalMarksForSymbols(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols).Count(exactCount);
        }

        public static QuantifierExpression NotCombiningDiacriticalMarksForSymbols(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CombiningHalfMarks()
        {
            return Character.UnicodeBlock(UnicodeBlock.CombiningHalfMarks);
        }

        public static QuantifierExpression CombiningHalfMarks(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CombiningHalfMarks).Count(exactCount);
        }

        public static QuantifierExpression CombiningHalfMarks(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CombiningHalfMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCombiningHalfMarks()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CombiningHalfMarks);
        }

        public static QuantifierExpression NotCombiningHalfMarks(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CombiningHalfMarks).Count(exactCount);
        }

        public static QuantifierExpression NotCombiningHalfMarks(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CombiningHalfMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CombiningMarksForSymbols()
        {
            return Character.UnicodeBlock(UnicodeBlock.CombiningMarksForSymbols);
        }

        public static QuantifierExpression CombiningMarksForSymbols(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CombiningMarksForSymbols).Count(exactCount);
        }

        public static QuantifierExpression CombiningMarksForSymbols(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CombiningMarksForSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCombiningMarksForSymbols()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CombiningMarksForSymbols);
        }

        public static QuantifierExpression NotCombiningMarksForSymbols(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CombiningMarksForSymbols).Count(exactCount);
        }

        public static QuantifierExpression NotCombiningMarksForSymbols(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CombiningMarksForSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression ControlPictures()
        {
            return Character.UnicodeBlock(UnicodeBlock.ControlPictures);
        }

        public static QuantifierExpression ControlPictures(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.ControlPictures).Count(exactCount);
        }

        public static QuantifierExpression ControlPictures(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.ControlPictures).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotControlPictures()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.ControlPictures);
        }

        public static QuantifierExpression NotControlPictures(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.ControlPictures).Count(exactCount);
        }

        public static QuantifierExpression NotControlPictures(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.ControlPictures).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CurrencySymbols()
        {
            return Character.UnicodeBlock(UnicodeBlock.CurrencySymbols);
        }

        public static QuantifierExpression CurrencySymbols(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CurrencySymbols).Count(exactCount);
        }

        public static QuantifierExpression CurrencySymbols(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CurrencySymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCurrencySymbols()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CurrencySymbols);
        }

        public static QuantifierExpression NotCurrencySymbols(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CurrencySymbols).Count(exactCount);
        }

        public static QuantifierExpression NotCurrencySymbols(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CurrencySymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Cyrillic()
        {
            return Character.UnicodeBlock(UnicodeBlock.Cyrillic);
        }

        public static QuantifierExpression Cyrillic(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Cyrillic).Count(exactCount);
        }

        public static QuantifierExpression Cyrillic(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Cyrillic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCyrillic()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Cyrillic);
        }

        public static QuantifierExpression NotCyrillic(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Cyrillic).Count(exactCount);
        }

        public static QuantifierExpression NotCyrillic(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Cyrillic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CyrillicSupplement()
        {
            return Character.UnicodeBlock(UnicodeBlock.CyrillicSupplement);
        }

        public static QuantifierExpression CyrillicSupplement(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CyrillicSupplement).Count(exactCount);
        }

        public static QuantifierExpression CyrillicSupplement(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.CyrillicSupplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCyrillicSupplement()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CyrillicSupplement);
        }

        public static QuantifierExpression NotCyrillicSupplement(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CyrillicSupplement).Count(exactCount);
        }

        public static QuantifierExpression NotCyrillicSupplement(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.CyrillicSupplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Devanagari()
        {
            return Character.UnicodeBlock(UnicodeBlock.Devanagari);
        }

        public static QuantifierExpression Devanagari(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Devanagari).Count(exactCount);
        }

        public static QuantifierExpression Devanagari(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Devanagari).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotDevanagari()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Devanagari);
        }

        public static QuantifierExpression NotDevanagari(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Devanagari).Count(exactCount);
        }

        public static QuantifierExpression NotDevanagari(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Devanagari).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Dingbats()
        {
            return Character.UnicodeBlock(UnicodeBlock.Dingbats);
        }

        public static QuantifierExpression Dingbats(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Dingbats).Count(exactCount);
        }

        public static QuantifierExpression Dingbats(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Dingbats).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotDingbats()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Dingbats);
        }

        public static QuantifierExpression NotDingbats(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Dingbats).Count(exactCount);
        }

        public static QuantifierExpression NotDingbats(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Dingbats).Count(minCount, maxCount);
        }

        public static QuantifiableExpression EnclosedAlphanumerics()
        {
            return Character.UnicodeBlock(UnicodeBlock.EnclosedAlphanumerics);
        }

        public static QuantifierExpression EnclosedAlphanumerics(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.EnclosedAlphanumerics).Count(exactCount);
        }

        public static QuantifierExpression EnclosedAlphanumerics(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.EnclosedAlphanumerics).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotEnclosedAlphanumerics()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.EnclosedAlphanumerics);
        }

        public static QuantifierExpression NotEnclosedAlphanumerics(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.EnclosedAlphanumerics).Count(exactCount);
        }

        public static QuantifierExpression NotEnclosedAlphanumerics(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.EnclosedAlphanumerics).Count(minCount, maxCount);
        }

        public static QuantifiableExpression EnclosedCJKLettersAndMonths()
        {
            return Character.UnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths);
        }

        public static QuantifierExpression EnclosedCJKLettersAndMonths(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths).Count(exactCount);
        }

        public static QuantifierExpression EnclosedCJKLettersAndMonths(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotEnclosedCJKLettersAndMonths()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths);
        }

        public static QuantifierExpression NotEnclosedCJKLettersAndMonths(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths).Count(exactCount);
        }

        public static QuantifierExpression NotEnclosedCJKLettersAndMonths(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Ethiopic()
        {
            return Character.UnicodeBlock(UnicodeBlock.Ethiopic);
        }

        public static QuantifierExpression Ethiopic(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Ethiopic).Count(exactCount);
        }

        public static QuantifierExpression Ethiopic(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Ethiopic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotEthiopic()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Ethiopic);
        }

        public static QuantifierExpression NotEthiopic(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Ethiopic).Count(exactCount);
        }

        public static QuantifierExpression NotEthiopic(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Ethiopic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GeneralPunctuation()
        {
            return Character.UnicodeBlock(UnicodeBlock.GeneralPunctuation);
        }

        public static QuantifierExpression GeneralPunctuation(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.GeneralPunctuation).Count(exactCount);
        }

        public static QuantifierExpression GeneralPunctuation(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.GeneralPunctuation).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGeneralPunctuation()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.GeneralPunctuation);
        }

        public static QuantifierExpression NotGeneralPunctuation(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.GeneralPunctuation).Count(exactCount);
        }

        public static QuantifierExpression NotGeneralPunctuation(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.GeneralPunctuation).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GeometricShapes()
        {
            return Character.UnicodeBlock(UnicodeBlock.GeometricShapes);
        }

        public static QuantifierExpression GeometricShapes(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.GeometricShapes).Count(exactCount);
        }

        public static QuantifierExpression GeometricShapes(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.GeometricShapes).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGeometricShapes()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.GeometricShapes);
        }

        public static QuantifierExpression NotGeometricShapes(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.GeometricShapes).Count(exactCount);
        }

        public static QuantifierExpression NotGeometricShapes(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.GeometricShapes).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Georgian()
        {
            return Character.UnicodeBlock(UnicodeBlock.Georgian);
        }

        public static QuantifierExpression Georgian(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Georgian).Count(exactCount);
        }

        public static QuantifierExpression Georgian(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Georgian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGeorgian()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Georgian);
        }

        public static QuantifierExpression NotGeorgian(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Georgian).Count(exactCount);
        }

        public static QuantifierExpression NotGeorgian(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Georgian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Greek()
        {
            return Character.UnicodeBlock(UnicodeBlock.Greek);
        }

        public static QuantifierExpression Greek(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Greek).Count(exactCount);
        }

        public static QuantifierExpression Greek(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Greek).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGreek()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Greek);
        }

        public static QuantifierExpression NotGreek(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Greek).Count(exactCount);
        }

        public static QuantifierExpression NotGreek(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Greek).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GreekAndCoptic()
        {
            return Character.UnicodeBlock(UnicodeBlock.GreekAndCoptic);
        }

        public static QuantifierExpression GreekAndCoptic(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.GreekAndCoptic).Count(exactCount);
        }

        public static QuantifierExpression GreekAndCoptic(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.GreekAndCoptic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGreekAndCoptic()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.GreekAndCoptic);
        }

        public static QuantifierExpression NotGreekAndCoptic(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.GreekAndCoptic).Count(exactCount);
        }

        public static QuantifierExpression NotGreekAndCoptic(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.GreekAndCoptic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GreekExtended()
        {
            return Character.UnicodeBlock(UnicodeBlock.GreekExtended);
        }

        public static QuantifierExpression GreekExtended(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.GreekExtended).Count(exactCount);
        }

        public static QuantifierExpression GreekExtended(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.GreekExtended).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGreekExtended()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.GreekExtended);
        }

        public static QuantifierExpression NotGreekExtended(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.GreekExtended).Count(exactCount);
        }

        public static QuantifierExpression NotGreekExtended(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.GreekExtended).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Gujarati()
        {
            return Character.UnicodeBlock(UnicodeBlock.Gujarati);
        }

        public static QuantifierExpression Gujarati(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Gujarati).Count(exactCount);
        }

        public static QuantifierExpression Gujarati(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Gujarati).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGujarati()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Gujarati);
        }

        public static QuantifierExpression NotGujarati(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Gujarati).Count(exactCount);
        }

        public static QuantifierExpression NotGujarati(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Gujarati).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Gurmukhi()
        {
            return Character.UnicodeBlock(UnicodeBlock.Gurmukhi);
        }

        public static QuantifierExpression Gurmukhi(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Gurmukhi).Count(exactCount);
        }

        public static QuantifierExpression Gurmukhi(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Gurmukhi).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGurmukhi()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Gurmukhi);
        }

        public static QuantifierExpression NotGurmukhi(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Gurmukhi).Count(exactCount);
        }

        public static QuantifierExpression NotGurmukhi(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Gurmukhi).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HalfWidthAndFullWidthForms()
        {
            return Character.UnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms);
        }

        public static QuantifierExpression HalfWidthAndFullWidthForms(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms).Count(exactCount);
        }

        public static QuantifierExpression HalfWidthAndFullWidthForms(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHalfWidthAndFullWidthForms()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms);
        }

        public static QuantifierExpression NotHalfWidthAndFullWidthForms(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms).Count(exactCount);
        }

        public static QuantifierExpression NotHalfWidthAndFullWidthForms(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HangulCompatibilityJamo()
        {
            return Character.UnicodeBlock(UnicodeBlock.HangulCompatibilityJamo);
        }

        public static QuantifierExpression HangulCompatibilityJamo(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.HangulCompatibilityJamo).Count(exactCount);
        }

        public static QuantifierExpression HangulCompatibilityJamo(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.HangulCompatibilityJamo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHangulCompatibilityJamo()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HangulCompatibilityJamo);
        }

        public static QuantifierExpression NotHangulCompatibilityJamo(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HangulCompatibilityJamo).Count(exactCount);
        }

        public static QuantifierExpression NotHangulCompatibilityJamo(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HangulCompatibilityJamo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HangulJamo()
        {
            return Character.UnicodeBlock(UnicodeBlock.HangulJamo);
        }

        public static QuantifierExpression HangulJamo(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.HangulJamo).Count(exactCount);
        }

        public static QuantifierExpression HangulJamo(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.HangulJamo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHangulJamo()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HangulJamo);
        }

        public static QuantifierExpression NotHangulJamo(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HangulJamo).Count(exactCount);
        }

        public static QuantifierExpression NotHangulJamo(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HangulJamo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HangulSyllables()
        {
            return Character.UnicodeBlock(UnicodeBlock.HangulSyllables);
        }

        public static QuantifierExpression HangulSyllables(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.HangulSyllables).Count(exactCount);
        }

        public static QuantifierExpression HangulSyllables(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.HangulSyllables).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHangulSyllables()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HangulSyllables);
        }

        public static QuantifierExpression NotHangulSyllables(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HangulSyllables).Count(exactCount);
        }

        public static QuantifierExpression NotHangulSyllables(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HangulSyllables).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Hanunoo()
        {
            return Character.UnicodeBlock(UnicodeBlock.Hanunoo);
        }

        public static QuantifierExpression Hanunoo(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Hanunoo).Count(exactCount);
        }

        public static QuantifierExpression Hanunoo(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Hanunoo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHanunoo()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Hanunoo);
        }

        public static QuantifierExpression NotHanunoo(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Hanunoo).Count(exactCount);
        }

        public static QuantifierExpression NotHanunoo(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Hanunoo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Hebrew()
        {
            return Character.UnicodeBlock(UnicodeBlock.Hebrew);
        }

        public static QuantifierExpression Hebrew(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Hebrew).Count(exactCount);
        }

        public static QuantifierExpression Hebrew(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Hebrew).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHebrew()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Hebrew);
        }

        public static QuantifierExpression NotHebrew(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Hebrew).Count(exactCount);
        }

        public static QuantifierExpression NotHebrew(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Hebrew).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HighPrivateUseSurrogates()
        {
            return Character.UnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates);
        }

        public static QuantifierExpression HighPrivateUseSurrogates(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates).Count(exactCount);
        }

        public static QuantifierExpression HighPrivateUseSurrogates(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHighPrivateUseSurrogates()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates);
        }

        public static QuantifierExpression NotHighPrivateUseSurrogates(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates).Count(exactCount);
        }

        public static QuantifierExpression NotHighPrivateUseSurrogates(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HighSurrogates()
        {
            return Character.UnicodeBlock(UnicodeBlock.HighSurrogates);
        }

        public static QuantifierExpression HighSurrogates(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.HighSurrogates).Count(exactCount);
        }

        public static QuantifierExpression HighSurrogates(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.HighSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHighSurrogates()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HighSurrogates);
        }

        public static QuantifierExpression NotHighSurrogates(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HighSurrogates).Count(exactCount);
        }

        public static QuantifierExpression NotHighSurrogates(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.HighSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Hiragana()
        {
            return Character.UnicodeBlock(UnicodeBlock.Hiragana);
        }

        public static QuantifierExpression Hiragana(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Hiragana).Count(exactCount);
        }

        public static QuantifierExpression Hiragana(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Hiragana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHiragana()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Hiragana);
        }

        public static QuantifierExpression NotHiragana(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Hiragana).Count(exactCount);
        }

        public static QuantifierExpression NotHiragana(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Hiragana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Cherokee()
        {
            return Character.UnicodeBlock(UnicodeBlock.Cherokee);
        }

        public static QuantifierExpression Cherokee(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Cherokee).Count(exactCount);
        }

        public static QuantifierExpression Cherokee(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Cherokee).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCherokee()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Cherokee);
        }

        public static QuantifierExpression NotCherokee(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Cherokee).Count(exactCount);
        }

        public static QuantifierExpression NotCherokee(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Cherokee).Count(minCount, maxCount);
        }

        public static QuantifiableExpression IdeographicDescriptionCharacters()
        {
            return Character.UnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters);
        }

        public static QuantifierExpression IdeographicDescriptionCharacters(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters).Count(exactCount);
        }

        public static QuantifierExpression IdeographicDescriptionCharacters(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotIdeographicDescriptionCharacters()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters);
        }

        public static QuantifierExpression NotIdeographicDescriptionCharacters(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters).Count(exactCount);
        }

        public static QuantifierExpression NotIdeographicDescriptionCharacters(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression IPAExtensions()
        {
            return Character.UnicodeBlock(UnicodeBlock.IPAExtensions);
        }

        public static QuantifierExpression IPAExtensions(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.IPAExtensions).Count(exactCount);
        }

        public static QuantifierExpression IPAExtensions(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.IPAExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotIPAExtensions()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.IPAExtensions);
        }

        public static QuantifierExpression NotIPAExtensions(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.IPAExtensions).Count(exactCount);
        }

        public static QuantifierExpression NotIPAExtensions(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.IPAExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Kanbun()
        {
            return Character.UnicodeBlock(UnicodeBlock.Kanbun);
        }

        public static QuantifierExpression Kanbun(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Kanbun).Count(exactCount);
        }

        public static QuantifierExpression Kanbun(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Kanbun).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKanbun()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Kanbun);
        }

        public static QuantifierExpression NotKanbun(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Kanbun).Count(exactCount);
        }

        public static QuantifierExpression NotKanbun(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Kanbun).Count(minCount, maxCount);
        }

        public static QuantifiableExpression KangxiRadicals()
        {
            return Character.UnicodeBlock(UnicodeBlock.KangxiRadicals);
        }

        public static QuantifierExpression KangxiRadicals(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.KangxiRadicals).Count(exactCount);
        }

        public static QuantifierExpression KangxiRadicals(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.KangxiRadicals).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKangxiRadicals()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.KangxiRadicals);
        }

        public static QuantifierExpression NotKangxiRadicals(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.KangxiRadicals).Count(exactCount);
        }

        public static QuantifierExpression NotKangxiRadicals(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.KangxiRadicals).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Kannada()
        {
            return Character.UnicodeBlock(UnicodeBlock.Kannada);
        }

        public static QuantifierExpression Kannada(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Kannada).Count(exactCount);
        }

        public static QuantifierExpression Kannada(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Kannada).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKannada()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Kannada);
        }

        public static QuantifierExpression NotKannada(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Kannada).Count(exactCount);
        }

        public static QuantifierExpression NotKannada(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Kannada).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Katakana()
        {
            return Character.UnicodeBlock(UnicodeBlock.Katakana);
        }

        public static QuantifierExpression Katakana(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Katakana).Count(exactCount);
        }

        public static QuantifierExpression Katakana(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Katakana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKatakana()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Katakana);
        }

        public static QuantifierExpression NotKatakana(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Katakana).Count(exactCount);
        }

        public static QuantifierExpression NotKatakana(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Katakana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression KatakanaPhoneticExtensions()
        {
            return Character.UnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions);
        }

        public static QuantifierExpression KatakanaPhoneticExtensions(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions).Count(exactCount);
        }

        public static QuantifierExpression KatakanaPhoneticExtensions(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKatakanaPhoneticExtensions()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions);
        }

        public static QuantifierExpression NotKatakanaPhoneticExtensions(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions).Count(exactCount);
        }

        public static QuantifierExpression NotKatakanaPhoneticExtensions(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Khmer()
        {
            return Character.UnicodeBlock(UnicodeBlock.Khmer);
        }

        public static QuantifierExpression Khmer(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Khmer).Count(exactCount);
        }

        public static QuantifierExpression Khmer(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Khmer).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKhmer()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Khmer);
        }

        public static QuantifierExpression NotKhmer(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Khmer).Count(exactCount);
        }

        public static QuantifierExpression NotKhmer(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Khmer).Count(minCount, maxCount);
        }

        public static QuantifiableExpression KhmerSymbols()
        {
            return Character.UnicodeBlock(UnicodeBlock.KhmerSymbols);
        }

        public static QuantifierExpression KhmerSymbols(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.KhmerSymbols).Count(exactCount);
        }

        public static QuantifierExpression KhmerSymbols(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.KhmerSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKhmerSymbols()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.KhmerSymbols);
        }

        public static QuantifierExpression NotKhmerSymbols(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.KhmerSymbols).Count(exactCount);
        }

        public static QuantifierExpression NotKhmerSymbols(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.KhmerSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Lao()
        {
            return Character.UnicodeBlock(UnicodeBlock.Lao);
        }

        public static QuantifierExpression Lao(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Lao).Count(exactCount);
        }

        public static QuantifierExpression Lao(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Lao).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLao()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Lao);
        }

        public static QuantifierExpression NotLao(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Lao).Count(exactCount);
        }

        public static QuantifierExpression NotLao(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Lao).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Latin1Supplement()
        {
            return Character.UnicodeBlock(UnicodeBlock.Latin1Supplement);
        }

        public static QuantifierExpression Latin1Supplement(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Latin1Supplement).Count(exactCount);
        }

        public static QuantifierExpression Latin1Supplement(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Latin1Supplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLatin1Supplement()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Latin1Supplement);
        }

        public static QuantifierExpression NotLatin1Supplement(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Latin1Supplement).Count(exactCount);
        }

        public static QuantifierExpression NotLatin1Supplement(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Latin1Supplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LatinExtendedA()
        {
            return Character.UnicodeBlock(UnicodeBlock.LatinExtendedA);
        }

        public static QuantifierExpression LatinExtendedA(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.LatinExtendedA).Count(exactCount);
        }

        public static QuantifierExpression LatinExtendedA(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.LatinExtendedA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLatinExtendedA()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LatinExtendedA);
        }

        public static QuantifierExpression NotLatinExtendedA(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LatinExtendedA).Count(exactCount);
        }

        public static QuantifierExpression NotLatinExtendedA(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LatinExtendedA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LatinExtendedAdditional()
        {
            return Character.UnicodeBlock(UnicodeBlock.LatinExtendedAdditional);
        }

        public static QuantifierExpression LatinExtendedAdditional(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.LatinExtendedAdditional).Count(exactCount);
        }

        public static QuantifierExpression LatinExtendedAdditional(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.LatinExtendedAdditional).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLatinExtendedAdditional()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LatinExtendedAdditional);
        }

        public static QuantifierExpression NotLatinExtendedAdditional(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LatinExtendedAdditional).Count(exactCount);
        }

        public static QuantifierExpression NotLatinExtendedAdditional(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LatinExtendedAdditional).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LatinExtendedB()
        {
            return Character.UnicodeBlock(UnicodeBlock.LatinExtendedB);
        }

        public static QuantifierExpression LatinExtendedB(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.LatinExtendedB).Count(exactCount);
        }

        public static QuantifierExpression LatinExtendedB(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.LatinExtendedB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLatinExtendedB()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LatinExtendedB);
        }

        public static QuantifierExpression NotLatinExtendedB(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LatinExtendedB).Count(exactCount);
        }

        public static QuantifierExpression NotLatinExtendedB(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LatinExtendedB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterLikeSymbols()
        {
            return Character.UnicodeBlock(UnicodeBlock.LetterLikeSymbols);
        }

        public static QuantifierExpression LetterLikeSymbols(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.LetterLikeSymbols).Count(exactCount);
        }

        public static QuantifierExpression LetterLikeSymbols(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.LetterLikeSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterLikeSymbols()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LetterLikeSymbols);
        }

        public static QuantifierExpression NotLetterLikeSymbols(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LetterLikeSymbols).Count(exactCount);
        }

        public static QuantifierExpression NotLetterLikeSymbols(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LetterLikeSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Limbu()
        {
            return Character.UnicodeBlock(UnicodeBlock.Limbu);
        }

        public static QuantifierExpression Limbu(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Limbu).Count(exactCount);
        }

        public static QuantifierExpression Limbu(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Limbu).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLimbu()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Limbu);
        }

        public static QuantifierExpression NotLimbu(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Limbu).Count(exactCount);
        }

        public static QuantifierExpression NotLimbu(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Limbu).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LowSurrogates()
        {
            return Character.UnicodeBlock(UnicodeBlock.LowSurrogates);
        }

        public static QuantifierExpression LowSurrogates(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.LowSurrogates).Count(exactCount);
        }

        public static QuantifierExpression LowSurrogates(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.LowSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLowSurrogates()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LowSurrogates);
        }

        public static QuantifierExpression NotLowSurrogates(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LowSurrogates).Count(exactCount);
        }

        public static QuantifierExpression NotLowSurrogates(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.LowSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Malayalam()
        {
            return Character.UnicodeBlock(UnicodeBlock.Malayalam);
        }

        public static QuantifierExpression Malayalam(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Malayalam).Count(exactCount);
        }

        public static QuantifierExpression Malayalam(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Malayalam).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMalayalam()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Malayalam);
        }

        public static QuantifierExpression NotMalayalam(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Malayalam).Count(exactCount);
        }

        public static QuantifierExpression NotMalayalam(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Malayalam).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MathematicalOperators()
        {
            return Character.UnicodeBlock(UnicodeBlock.MathematicalOperators);
        }

        public static QuantifierExpression MathematicalOperators(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.MathematicalOperators).Count(exactCount);
        }

        public static QuantifierExpression MathematicalOperators(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.MathematicalOperators).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMathematicalOperators()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MathematicalOperators);
        }

        public static QuantifierExpression NotMathematicalOperators(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MathematicalOperators).Count(exactCount);
        }

        public static QuantifierExpression NotMathematicalOperators(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MathematicalOperators).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousMathematicalSymbolsA()
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA);
        }

        public static QuantifierExpression MiscellaneousMathematicalSymbolsA(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA).Count(exactCount);
        }

        public static QuantifierExpression MiscellaneousMathematicalSymbolsA(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousMathematicalSymbolsA()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA);
        }

        public static QuantifierExpression NotMiscellaneousMathematicalSymbolsA(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA).Count(exactCount);
        }

        public static QuantifierExpression NotMiscellaneousMathematicalSymbolsA(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousMathematicalSymbolsB()
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB);
        }

        public static QuantifierExpression MiscellaneousMathematicalSymbolsB(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB).Count(exactCount);
        }

        public static QuantifierExpression MiscellaneousMathematicalSymbolsB(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousMathematicalSymbolsB()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB);
        }

        public static QuantifierExpression NotMiscellaneousMathematicalSymbolsB(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB).Count(exactCount);
        }

        public static QuantifierExpression NotMiscellaneousMathematicalSymbolsB(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousSymbols()
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousSymbols);
        }

        public static QuantifierExpression MiscellaneousSymbols(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousSymbols).Count(exactCount);
        }

        public static QuantifierExpression MiscellaneousSymbols(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousSymbols()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbols);
        }

        public static QuantifierExpression NotMiscellaneousSymbols(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbols).Count(exactCount);
        }

        public static QuantifierExpression NotMiscellaneousSymbols(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousSymbolsAndArrows()
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows);
        }

        public static QuantifierExpression MiscellaneousSymbolsAndArrows(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows).Count(exactCount);
        }

        public static QuantifierExpression MiscellaneousSymbolsAndArrows(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousSymbolsAndArrows()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows);
        }

        public static QuantifierExpression NotMiscellaneousSymbolsAndArrows(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows).Count(exactCount);
        }

        public static QuantifierExpression NotMiscellaneousSymbolsAndArrows(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousTechnical()
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousTechnical);
        }

        public static QuantifierExpression MiscellaneousTechnical(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousTechnical).Count(exactCount);
        }

        public static QuantifierExpression MiscellaneousTechnical(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.MiscellaneousTechnical).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousTechnical()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousTechnical);
        }

        public static QuantifierExpression NotMiscellaneousTechnical(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousTechnical).Count(exactCount);
        }

        public static QuantifierExpression NotMiscellaneousTechnical(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.MiscellaneousTechnical).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Mongolian()
        {
            return Character.UnicodeBlock(UnicodeBlock.Mongolian);
        }

        public static QuantifierExpression Mongolian(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Mongolian).Count(exactCount);
        }

        public static QuantifierExpression Mongolian(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Mongolian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMongolian()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Mongolian);
        }

        public static QuantifierExpression NotMongolian(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Mongolian).Count(exactCount);
        }

        public static QuantifierExpression NotMongolian(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Mongolian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Myanmar()
        {
            return Character.UnicodeBlock(UnicodeBlock.Myanmar);
        }

        public static QuantifierExpression Myanmar(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Myanmar).Count(exactCount);
        }

        public static QuantifierExpression Myanmar(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Myanmar).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMyanmar()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Myanmar);
        }

        public static QuantifierExpression NotMyanmar(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Myanmar).Count(exactCount);
        }

        public static QuantifierExpression NotMyanmar(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Myanmar).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberForms()
        {
            return Character.UnicodeBlock(UnicodeBlock.NumberForms);
        }

        public static QuantifierExpression NumberForms(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.NumberForms).Count(exactCount);
        }

        public static QuantifierExpression NumberForms(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.NumberForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberForms()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.NumberForms);
        }

        public static QuantifierExpression NotNumberForms(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.NumberForms).Count(exactCount);
        }

        public static QuantifierExpression NotNumberForms(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.NumberForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Ogham()
        {
            return Character.UnicodeBlock(UnicodeBlock.Ogham);
        }

        public static QuantifierExpression Ogham(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Ogham).Count(exactCount);
        }

        public static QuantifierExpression Ogham(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Ogham).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOgham()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Ogham);
        }

        public static QuantifierExpression NotOgham(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Ogham).Count(exactCount);
        }

        public static QuantifierExpression NotOgham(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Ogham).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OpticalCharacterRecognition()
        {
            return Character.UnicodeBlock(UnicodeBlock.OpticalCharacterRecognition);
        }

        public static QuantifierExpression OpticalCharacterRecognition(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.OpticalCharacterRecognition).Count(exactCount);
        }

        public static QuantifierExpression OpticalCharacterRecognition(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.OpticalCharacterRecognition).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOpticalCharacterRecognition()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.OpticalCharacterRecognition);
        }

        public static QuantifierExpression NotOpticalCharacterRecognition(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.OpticalCharacterRecognition).Count(exactCount);
        }

        public static QuantifierExpression NotOpticalCharacterRecognition(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.OpticalCharacterRecognition).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Oriya()
        {
            return Character.UnicodeBlock(UnicodeBlock.Oriya);
        }

        public static QuantifierExpression Oriya(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Oriya).Count(exactCount);
        }

        public static QuantifierExpression Oriya(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Oriya).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOriya()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Oriya);
        }

        public static QuantifierExpression NotOriya(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Oriya).Count(exactCount);
        }

        public static QuantifierExpression NotOriya(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Oriya).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PhoneticExtensions()
        {
            return Character.UnicodeBlock(UnicodeBlock.PhoneticExtensions);
        }

        public static QuantifierExpression PhoneticExtensions(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.PhoneticExtensions).Count(exactCount);
        }

        public static QuantifierExpression PhoneticExtensions(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.PhoneticExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPhoneticExtensions()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.PhoneticExtensions);
        }

        public static QuantifierExpression NotPhoneticExtensions(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.PhoneticExtensions).Count(exactCount);
        }

        public static QuantifierExpression NotPhoneticExtensions(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.PhoneticExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PrivateUse()
        {
            return Character.UnicodeBlock(UnicodeBlock.PrivateUse);
        }

        public static QuantifierExpression PrivateUse(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.PrivateUse).Count(exactCount);
        }

        public static QuantifierExpression PrivateUse(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.PrivateUse).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPrivateUse()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.PrivateUse);
        }

        public static QuantifierExpression NotPrivateUse(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.PrivateUse).Count(exactCount);
        }

        public static QuantifierExpression NotPrivateUse(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.PrivateUse).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PrivateUseArea()
        {
            return Character.UnicodeBlock(UnicodeBlock.PrivateUseArea);
        }

        public static QuantifierExpression PrivateUseArea(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.PrivateUseArea).Count(exactCount);
        }

        public static QuantifierExpression PrivateUseArea(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.PrivateUseArea).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPrivateUseArea()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.PrivateUseArea);
        }

        public static QuantifierExpression NotPrivateUseArea(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.PrivateUseArea).Count(exactCount);
        }

        public static QuantifierExpression NotPrivateUseArea(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.PrivateUseArea).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Runic()
        {
            return Character.UnicodeBlock(UnicodeBlock.Runic);
        }

        public static QuantifierExpression Runic(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Runic).Count(exactCount);
        }

        public static QuantifierExpression Runic(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Runic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotRunic()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Runic);
        }

        public static QuantifierExpression NotRunic(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Runic).Count(exactCount);
        }

        public static QuantifierExpression NotRunic(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Runic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Sinhala()
        {
            return Character.UnicodeBlock(UnicodeBlock.Sinhala);
        }

        public static QuantifierExpression Sinhala(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Sinhala).Count(exactCount);
        }

        public static QuantifierExpression Sinhala(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Sinhala).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSinhala()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Sinhala);
        }

        public static QuantifierExpression NotSinhala(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Sinhala).Count(exactCount);
        }

        public static QuantifierExpression NotSinhala(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Sinhala).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SmallFormVariants()
        {
            return Character.UnicodeBlock(UnicodeBlock.SmallFormVariants);
        }

        public static QuantifierExpression SmallFormVariants(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.SmallFormVariants).Count(exactCount);
        }

        public static QuantifierExpression SmallFormVariants(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.SmallFormVariants).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSmallFormVariants()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SmallFormVariants);
        }

        public static QuantifierExpression NotSmallFormVariants(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SmallFormVariants).Count(exactCount);
        }

        public static QuantifierExpression NotSmallFormVariants(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SmallFormVariants).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SpacingModifierLetters()
        {
            return Character.UnicodeBlock(UnicodeBlock.SpacingModifierLetters);
        }

        public static QuantifierExpression SpacingModifierLetters(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.SpacingModifierLetters).Count(exactCount);
        }

        public static QuantifierExpression SpacingModifierLetters(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.SpacingModifierLetters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSpacingModifierLetters()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SpacingModifierLetters);
        }

        public static QuantifierExpression NotSpacingModifierLetters(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SpacingModifierLetters).Count(exactCount);
        }

        public static QuantifierExpression NotSpacingModifierLetters(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SpacingModifierLetters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Specials()
        {
            return Character.UnicodeBlock(UnicodeBlock.Specials);
        }

        public static QuantifierExpression Specials(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Specials).Count(exactCount);
        }

        public static QuantifierExpression Specials(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Specials).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSpecials()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Specials);
        }

        public static QuantifierExpression NotSpecials(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Specials).Count(exactCount);
        }

        public static QuantifierExpression NotSpecials(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Specials).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SuperscriptsAndSubscripts()
        {
            return Character.UnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts);
        }

        public static QuantifierExpression SuperscriptsAndSubscripts(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts).Count(exactCount);
        }

        public static QuantifierExpression SuperscriptsAndSubscripts(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSuperscriptsAndSubscripts()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts);
        }

        public static QuantifierExpression NotSuperscriptsAndSubscripts(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts).Count(exactCount);
        }

        public static QuantifierExpression NotSuperscriptsAndSubscripts(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SupplementalArrowsA()
        {
            return Character.UnicodeBlock(UnicodeBlock.SupplementalArrowsA);
        }

        public static QuantifierExpression SupplementalArrowsA(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.SupplementalArrowsA).Count(exactCount);
        }

        public static QuantifierExpression SupplementalArrowsA(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.SupplementalArrowsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSupplementalArrowsA()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsA);
        }

        public static QuantifierExpression NotSupplementalArrowsA(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsA).Count(exactCount);
        }

        public static QuantifierExpression NotSupplementalArrowsA(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SupplementalArrowsB()
        {
            return Character.UnicodeBlock(UnicodeBlock.SupplementalArrowsB);
        }

        public static QuantifierExpression SupplementalArrowsB(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.SupplementalArrowsB).Count(exactCount);
        }

        public static QuantifierExpression SupplementalArrowsB(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.SupplementalArrowsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSupplementalArrowsB()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsB);
        }

        public static QuantifierExpression NotSupplementalArrowsB(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsB).Count(exactCount);
        }

        public static QuantifierExpression NotSupplementalArrowsB(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SupplementalMathematicalOperators()
        {
            return Character.UnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators);
        }

        public static QuantifierExpression SupplementalMathematicalOperators(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators).Count(exactCount);
        }

        public static QuantifierExpression SupplementalMathematicalOperators(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSupplementalMathematicalOperators()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators);
        }

        public static QuantifierExpression NotSupplementalMathematicalOperators(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators).Count(exactCount);
        }

        public static QuantifierExpression NotSupplementalMathematicalOperators(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Syriac()
        {
            return Character.UnicodeBlock(UnicodeBlock.Syriac);
        }

        public static QuantifierExpression Syriac(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Syriac).Count(exactCount);
        }

        public static QuantifierExpression Syriac(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Syriac).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSyriac()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Syriac);
        }

        public static QuantifierExpression NotSyriac(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Syriac).Count(exactCount);
        }

        public static QuantifierExpression NotSyriac(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Syriac).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tagalog()
        {
            return Character.UnicodeBlock(UnicodeBlock.Tagalog);
        }

        public static QuantifierExpression Tagalog(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Tagalog).Count(exactCount);
        }

        public static QuantifierExpression Tagalog(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Tagalog).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTagalog()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Tagalog);
        }

        public static QuantifierExpression NotTagalog(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Tagalog).Count(exactCount);
        }

        public static QuantifierExpression NotTagalog(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Tagalog).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tagbanwa()
        {
            return Character.UnicodeBlock(UnicodeBlock.Tagbanwa);
        }

        public static QuantifierExpression Tagbanwa(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Tagbanwa).Count(exactCount);
        }

        public static QuantifierExpression Tagbanwa(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Tagbanwa).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTagbanwa()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Tagbanwa);
        }

        public static QuantifierExpression NotTagbanwa(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Tagbanwa).Count(exactCount);
        }

        public static QuantifierExpression NotTagbanwa(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Tagbanwa).Count(minCount, maxCount);
        }

        public static QuantifiableExpression TaiLe()
        {
            return Character.UnicodeBlock(UnicodeBlock.TaiLe);
        }

        public static QuantifierExpression TaiLe(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.TaiLe).Count(exactCount);
        }

        public static QuantifierExpression TaiLe(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.TaiLe).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTaiLe()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.TaiLe);
        }

        public static QuantifierExpression NotTaiLe(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.TaiLe).Count(exactCount);
        }

        public static QuantifierExpression NotTaiLe(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.TaiLe).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tamil()
        {
            return Character.UnicodeBlock(UnicodeBlock.Tamil);
        }

        public static QuantifierExpression Tamil(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Tamil).Count(exactCount);
        }

        public static QuantifierExpression Tamil(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Tamil).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTamil()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Tamil);
        }

        public static QuantifierExpression NotTamil(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Tamil).Count(exactCount);
        }

        public static QuantifierExpression NotTamil(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Tamil).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Telugu()
        {
            return Character.UnicodeBlock(UnicodeBlock.Telugu);
        }

        public static QuantifierExpression Telugu(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Telugu).Count(exactCount);
        }

        public static QuantifierExpression Telugu(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Telugu).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTelugu()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Telugu);
        }

        public static QuantifierExpression NotTelugu(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Telugu).Count(exactCount);
        }

        public static QuantifierExpression NotTelugu(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Telugu).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Thaana()
        {
            return Character.UnicodeBlock(UnicodeBlock.Thaana);
        }

        public static QuantifierExpression Thaana(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Thaana).Count(exactCount);
        }

        public static QuantifierExpression Thaana(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Thaana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotThaana()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Thaana);
        }

        public static QuantifierExpression NotThaana(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Thaana).Count(exactCount);
        }

        public static QuantifierExpression NotThaana(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Thaana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Thai()
        {
            return Character.UnicodeBlock(UnicodeBlock.Thai);
        }

        public static QuantifierExpression Thai(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Thai).Count(exactCount);
        }

        public static QuantifierExpression Thai(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Thai).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotThai()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Thai);
        }

        public static QuantifierExpression NotThai(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Thai).Count(exactCount);
        }

        public static QuantifierExpression NotThai(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Thai).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tibetan()
        {
            return Character.UnicodeBlock(UnicodeBlock.Tibetan);
        }

        public static QuantifierExpression Tibetan(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Tibetan).Count(exactCount);
        }

        public static QuantifierExpression Tibetan(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.Tibetan).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTibetan()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Tibetan);
        }

        public static QuantifierExpression NotTibetan(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Tibetan).Count(exactCount);
        }

        public static QuantifierExpression NotTibetan(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.Tibetan).Count(minCount, maxCount);
        }

        public static QuantifiableExpression UnifiedCanadianAboriginalSyllabics()
        {
            return Character.UnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics);
        }

        public static QuantifierExpression UnifiedCanadianAboriginalSyllabics(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics).Count(exactCount);
        }

        public static QuantifierExpression UnifiedCanadianAboriginalSyllabics(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotUnifiedCanadianAboriginalSyllabics()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics);
        }

        public static QuantifierExpression NotUnifiedCanadianAboriginalSyllabics(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics).Count(exactCount);
        }

        public static QuantifierExpression NotUnifiedCanadianAboriginalSyllabics(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics).Count(minCount, maxCount);
        }

        public static QuantifiableExpression VariationSelectors()
        {
            return Character.UnicodeBlock(UnicodeBlock.VariationSelectors);
        }

        public static QuantifierExpression VariationSelectors(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.VariationSelectors).Count(exactCount);
        }

        public static QuantifierExpression VariationSelectors(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.VariationSelectors).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotVariationSelectors()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.VariationSelectors);
        }

        public static QuantifierExpression NotVariationSelectors(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.VariationSelectors).Count(exactCount);
        }

        public static QuantifierExpression NotVariationSelectors(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.VariationSelectors).Count(minCount, maxCount);
        }

        public static QuantifiableExpression YijingHexagramSymbols()
        {
            return Character.UnicodeBlock(UnicodeBlock.YijingHexagramSymbols);
        }

        public static QuantifierExpression YijingHexagramSymbols(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.YijingHexagramSymbols).Count(exactCount);
        }

        public static QuantifierExpression YijingHexagramSymbols(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.YijingHexagramSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotYijingHexagramSymbols()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.YijingHexagramSymbols);
        }

        public static QuantifierExpression NotYijingHexagramSymbols(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.YijingHexagramSymbols).Count(exactCount);
        }

        public static QuantifierExpression NotYijingHexagramSymbols(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.YijingHexagramSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression YiRadicals()
        {
            return Character.UnicodeBlock(UnicodeBlock.YiRadicals);
        }

        public static QuantifierExpression YiRadicals(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.YiRadicals).Count(exactCount);
        }

        public static QuantifierExpression YiRadicals(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.YiRadicals).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotYiRadicals()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.YiRadicals);
        }

        public static QuantifierExpression NotYiRadicals(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.YiRadicals).Count(exactCount);
        }

        public static QuantifierExpression NotYiRadicals(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.YiRadicals).Count(minCount, maxCount);
        }

        public static QuantifiableExpression YiSyllables()
        {
            return Character.UnicodeBlock(UnicodeBlock.YiSyllables);
        }

        public static QuantifierExpression YiSyllables(int exactCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.YiSyllables).Count(exactCount);
        }

        public static QuantifierExpression YiSyllables(int minCount, int maxCount)
        {
            return Character.UnicodeBlock(UnicodeBlock.YiSyllables).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotYiSyllables()
        {
            return Character.NotUnicodeBlock(UnicodeBlock.YiSyllables);
        }

        public static QuantifierExpression NotYiSyllables(int exactCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.YiSyllables).Count(exactCount);
        }

        public static QuantifierExpression NotYiSyllables(int minCount, int maxCount)
        {
            return Character.NotUnicodeBlock(UnicodeBlock.YiSyllables).Count(minCount, maxCount);
        }
    }
}
