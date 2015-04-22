// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class UnicodeBlocks
    {
        public static QuantifiableExpression AlphabeticPresentationForms()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.AlphabeticPresentationForms);
        }

        public static Quantifier AlphabeticPresentationForms(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.AlphabeticPresentationForms).Count(exactCount);
        }

        public static Quantifier AlphabeticPresentationForms(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.AlphabeticPresentationForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAlphabeticPresentationForms()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.AlphabeticPresentationForms);
        }

        public static Quantifier NotAlphabeticPresentationForms(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.AlphabeticPresentationForms).Count(exactCount);
        }

        public static Quantifier NotAlphabeticPresentationForms(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.AlphabeticPresentationForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Arabic()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Arabic);
        }

        public static Quantifier Arabic(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Arabic).Count(exactCount);
        }

        public static Quantifier Arabic(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Arabic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArabic()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Arabic);
        }

        public static Quantifier NotArabic(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Arabic).Count(exactCount);
        }

        public static Quantifier NotArabic(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Arabic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression ArabicPresentationFormsA()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsA);
        }

        public static Quantifier ArabicPresentationFormsA(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsA).Count(exactCount);
        }

        public static Quantifier ArabicPresentationFormsA(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArabicPresentationFormsA()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsA);
        }

        public static Quantifier NotArabicPresentationFormsA(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsA).Count(exactCount);
        }

        public static Quantifier NotArabicPresentationFormsA(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression ArabicPresentationFormsB()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsB);
        }

        public static Quantifier ArabicPresentationFormsB(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsB).Count(exactCount);
        }

        public static Quantifier ArabicPresentationFormsB(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArabicPresentationFormsB()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsB);
        }

        public static Quantifier NotArabicPresentationFormsB(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsB).Count(exactCount);
        }

        public static Quantifier NotArabicPresentationFormsB(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Armenian()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Armenian);
        }

        public static Quantifier Armenian(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Armenian).Count(exactCount);
        }

        public static Quantifier Armenian(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Armenian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArmenian()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Armenian);
        }

        public static Quantifier NotArmenian(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Armenian).Count(exactCount);
        }

        public static Quantifier NotArmenian(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Armenian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Arrows()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Arrows);
        }

        public static Quantifier Arrows(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Arrows).Count(exactCount);
        }

        public static Quantifier Arrows(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Arrows).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArrows()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Arrows);
        }

        public static Quantifier NotArrows(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Arrows).Count(exactCount);
        }

        public static Quantifier NotArrows(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Arrows).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BasicLatin()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BasicLatin);
        }

        public static Quantifier BasicLatin(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BasicLatin).Count(exactCount);
        }

        public static Quantifier BasicLatin(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BasicLatin).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBasicLatin()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BasicLatin);
        }

        public static Quantifier NotBasicLatin(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BasicLatin).Count(exactCount);
        }

        public static Quantifier NotBasicLatin(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BasicLatin).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Bengali()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Bengali);
        }

        public static Quantifier Bengali(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Bengali).Count(exactCount);
        }

        public static Quantifier Bengali(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Bengali).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBengali()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Bengali);
        }

        public static Quantifier NotBengali(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Bengali).Count(exactCount);
        }

        public static Quantifier NotBengali(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Bengali).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BlockElements()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BlockElements);
        }

        public static Quantifier BlockElements(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BlockElements).Count(exactCount);
        }

        public static Quantifier BlockElements(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BlockElements).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBlockElements()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BlockElements);
        }

        public static Quantifier NotBlockElements(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BlockElements).Count(exactCount);
        }

        public static Quantifier NotBlockElements(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BlockElements).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Bopomofo()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Bopomofo);
        }

        public static Quantifier Bopomofo(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Bopomofo).Count(exactCount);
        }

        public static Quantifier Bopomofo(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Bopomofo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBopomofo()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Bopomofo);
        }

        public static Quantifier NotBopomofo(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Bopomofo).Count(exactCount);
        }

        public static Quantifier NotBopomofo(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Bopomofo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BopomofoExtended()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BopomofoExtended);
        }

        public static Quantifier BopomofoExtended(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BopomofoExtended).Count(exactCount);
        }

        public static Quantifier BopomofoExtended(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BopomofoExtended).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBopomofoExtended()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BopomofoExtended);
        }

        public static Quantifier NotBopomofoExtended(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BopomofoExtended).Count(exactCount);
        }

        public static Quantifier NotBopomofoExtended(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BopomofoExtended).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BoxDrawing()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BoxDrawing);
        }

        public static Quantifier BoxDrawing(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BoxDrawing).Count(exactCount);
        }

        public static Quantifier BoxDrawing(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BoxDrawing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBoxDrawing()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BoxDrawing);
        }

        public static Quantifier NotBoxDrawing(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BoxDrawing).Count(exactCount);
        }

        public static Quantifier NotBoxDrawing(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BoxDrawing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BraillePatterns()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BraillePatterns);
        }

        public static Quantifier BraillePatterns(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BraillePatterns).Count(exactCount);
        }

        public static Quantifier BraillePatterns(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.BraillePatterns).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBraillePatterns()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BraillePatterns);
        }

        public static Quantifier NotBraillePatterns(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BraillePatterns).Count(exactCount);
        }

        public static Quantifier NotBraillePatterns(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.BraillePatterns).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Buhid()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Buhid);
        }

        public static Quantifier Buhid(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Buhid).Count(exactCount);
        }

        public static Quantifier Buhid(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Buhid).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBuhid()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Buhid);
        }

        public static Quantifier NotBuhid(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Buhid).Count(exactCount);
        }

        public static Quantifier NotBuhid(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Buhid).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKCompatibility()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKCompatibility);
        }

        public static Quantifier CJKCompatibility(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKCompatibility).Count(exactCount);
        }

        public static Quantifier CJKCompatibility(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKCompatibility).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKCompatibility()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKCompatibility);
        }

        public static Quantifier NotCJKCompatibility(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKCompatibility).Count(exactCount);
        }

        public static Quantifier NotCJKCompatibility(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKCompatibility).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKCompatibilityForms()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKCompatibilityForms);
        }

        public static Quantifier CJKCompatibilityForms(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKCompatibilityForms).Count(exactCount);
        }

        public static Quantifier CJKCompatibilityForms(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKCompatibilityForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKCompatibilityForms()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityForms);
        }

        public static Quantifier NotCJKCompatibilityForms(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityForms).Count(exactCount);
        }

        public static Quantifier NotCJKCompatibilityForms(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKCompatibilityIdeographs()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs);
        }

        public static Quantifier CJKCompatibilityIdeographs(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs).Count(exactCount);
        }

        public static Quantifier CJKCompatibilityIdeographs(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKCompatibilityIdeographs()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs);
        }

        public static Quantifier NotCJKCompatibilityIdeographs(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs).Count(exactCount);
        }

        public static Quantifier NotCJKCompatibilityIdeographs(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKRadicalsSupplement()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKRadicalsSupplement);
        }

        public static Quantifier CJKRadicalsSupplement(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKRadicalsSupplement).Count(exactCount);
        }

        public static Quantifier CJKRadicalsSupplement(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKRadicalsSupplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKRadicalsSupplement()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKRadicalsSupplement);
        }

        public static Quantifier NotCJKRadicalsSupplement(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKRadicalsSupplement).Count(exactCount);
        }

        public static Quantifier NotCJKRadicalsSupplement(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKRadicalsSupplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKSymbolsAndPunctuation()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation);
        }

        public static Quantifier CJKSymbolsAndPunctuation(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation).Count(exactCount);
        }

        public static Quantifier CJKSymbolsAndPunctuation(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKSymbolsAndPunctuation()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation);
        }

        public static Quantifier NotCJKSymbolsAndPunctuation(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation).Count(exactCount);
        }

        public static Quantifier NotCJKSymbolsAndPunctuation(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKUnifiedIdeographs()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs);
        }

        public static Quantifier CJKUnifiedIdeographs(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs).Count(exactCount);
        }

        public static Quantifier CJKUnifiedIdeographs(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKUnifiedIdeographs()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs);
        }

        public static Quantifier NotCJKUnifiedIdeographs(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs).Count(exactCount);
        }

        public static Quantifier NotCJKUnifiedIdeographs(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKUnifiedIdeographsExtensionA()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA);
        }

        public static Quantifier CJKUnifiedIdeographsExtensionA(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA).Count(exactCount);
        }

        public static Quantifier CJKUnifiedIdeographsExtensionA(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKUnifiedIdeographsExtensionA()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA);
        }

        public static Quantifier NotCJKUnifiedIdeographsExtensionA(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA).Count(exactCount);
        }

        public static Quantifier NotCJKUnifiedIdeographsExtensionA(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CombiningDiacriticalMarks()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks);
        }

        public static Quantifier CombiningDiacriticalMarks(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks).Count(exactCount);
        }

        public static Quantifier CombiningDiacriticalMarks(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCombiningDiacriticalMarks()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks);
        }

        public static Quantifier NotCombiningDiacriticalMarks(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks).Count(exactCount);
        }

        public static Quantifier NotCombiningDiacriticalMarks(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CombiningDiacriticalMarksForSymbols()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols);
        }

        public static Quantifier CombiningDiacriticalMarksForSymbols(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols).Count(exactCount);
        }

        public static Quantifier CombiningDiacriticalMarksForSymbols(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCombiningDiacriticalMarksForSymbols()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols);
        }

        public static Quantifier NotCombiningDiacriticalMarksForSymbols(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols).Count(exactCount);
        }

        public static Quantifier NotCombiningDiacriticalMarksForSymbols(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CombiningHalfMarks()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CombiningHalfMarks);
        }

        public static Quantifier CombiningHalfMarks(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CombiningHalfMarks).Count(exactCount);
        }

        public static Quantifier CombiningHalfMarks(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CombiningHalfMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCombiningHalfMarks()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CombiningHalfMarks);
        }

        public static Quantifier NotCombiningHalfMarks(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CombiningHalfMarks).Count(exactCount);
        }

        public static Quantifier NotCombiningHalfMarks(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CombiningHalfMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CombiningMarksForSymbols()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CombiningMarksForSymbols);
        }

        public static Quantifier CombiningMarksForSymbols(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CombiningMarksForSymbols).Count(exactCount);
        }

        public static Quantifier CombiningMarksForSymbols(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CombiningMarksForSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCombiningMarksForSymbols()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CombiningMarksForSymbols);
        }

        public static Quantifier NotCombiningMarksForSymbols(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CombiningMarksForSymbols).Count(exactCount);
        }

        public static Quantifier NotCombiningMarksForSymbols(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CombiningMarksForSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression ControlPictures()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.ControlPictures);
        }

        public static Quantifier ControlPictures(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.ControlPictures).Count(exactCount);
        }

        public static Quantifier ControlPictures(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.ControlPictures).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotControlPictures()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.ControlPictures);
        }

        public static Quantifier NotControlPictures(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.ControlPictures).Count(exactCount);
        }

        public static Quantifier NotControlPictures(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.ControlPictures).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CurrencySymbols()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CurrencySymbols);
        }

        public static Quantifier CurrencySymbols(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CurrencySymbols).Count(exactCount);
        }

        public static Quantifier CurrencySymbols(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CurrencySymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCurrencySymbols()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CurrencySymbols);
        }

        public static Quantifier NotCurrencySymbols(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CurrencySymbols).Count(exactCount);
        }

        public static Quantifier NotCurrencySymbols(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CurrencySymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Cyrillic()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Cyrillic);
        }

        public static Quantifier Cyrillic(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Cyrillic).Count(exactCount);
        }

        public static Quantifier Cyrillic(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Cyrillic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCyrillic()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Cyrillic);
        }

        public static Quantifier NotCyrillic(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Cyrillic).Count(exactCount);
        }

        public static Quantifier NotCyrillic(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Cyrillic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CyrillicSupplement()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CyrillicSupplement);
        }

        public static Quantifier CyrillicSupplement(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CyrillicSupplement).Count(exactCount);
        }

        public static Quantifier CyrillicSupplement(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.CyrillicSupplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCyrillicSupplement()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CyrillicSupplement);
        }

        public static Quantifier NotCyrillicSupplement(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CyrillicSupplement).Count(exactCount);
        }

        public static Quantifier NotCyrillicSupplement(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.CyrillicSupplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Devanagari()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Devanagari);
        }

        public static Quantifier Devanagari(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Devanagari).Count(exactCount);
        }

        public static Quantifier Devanagari(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Devanagari).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotDevanagari()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Devanagari);
        }

        public static Quantifier NotDevanagari(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Devanagari).Count(exactCount);
        }

        public static Quantifier NotDevanagari(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Devanagari).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Dingbats()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Dingbats);
        }

        public static Quantifier Dingbats(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Dingbats).Count(exactCount);
        }

        public static Quantifier Dingbats(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Dingbats).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotDingbats()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Dingbats);
        }

        public static Quantifier NotDingbats(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Dingbats).Count(exactCount);
        }

        public static Quantifier NotDingbats(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Dingbats).Count(minCount, maxCount);
        }

        public static QuantifiableExpression EnclosedAlphanumerics()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.EnclosedAlphanumerics);
        }

        public static Quantifier EnclosedAlphanumerics(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.EnclosedAlphanumerics).Count(exactCount);
        }

        public static Quantifier EnclosedAlphanumerics(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.EnclosedAlphanumerics).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotEnclosedAlphanumerics()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.EnclosedAlphanumerics);
        }

        public static Quantifier NotEnclosedAlphanumerics(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.EnclosedAlphanumerics).Count(exactCount);
        }

        public static Quantifier NotEnclosedAlphanumerics(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.EnclosedAlphanumerics).Count(minCount, maxCount);
        }

        public static QuantifiableExpression EnclosedCJKLettersAndMonths()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths);
        }

        public static Quantifier EnclosedCJKLettersAndMonths(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths).Count(exactCount);
        }

        public static Quantifier EnclosedCJKLettersAndMonths(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotEnclosedCJKLettersAndMonths()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths);
        }

        public static Quantifier NotEnclosedCJKLettersAndMonths(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths).Count(exactCount);
        }

        public static Quantifier NotEnclosedCJKLettersAndMonths(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Ethiopic()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Ethiopic);
        }

        public static Quantifier Ethiopic(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Ethiopic).Count(exactCount);
        }

        public static Quantifier Ethiopic(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Ethiopic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotEthiopic()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Ethiopic);
        }

        public static Quantifier NotEthiopic(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Ethiopic).Count(exactCount);
        }

        public static Quantifier NotEthiopic(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Ethiopic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GeneralPunctuation()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.GeneralPunctuation);
        }

        public static Quantifier GeneralPunctuation(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.GeneralPunctuation).Count(exactCount);
        }

        public static Quantifier GeneralPunctuation(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.GeneralPunctuation).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGeneralPunctuation()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.GeneralPunctuation);
        }

        public static Quantifier NotGeneralPunctuation(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.GeneralPunctuation).Count(exactCount);
        }

        public static Quantifier NotGeneralPunctuation(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.GeneralPunctuation).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GeometricShapes()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.GeometricShapes);
        }

        public static Quantifier GeometricShapes(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.GeometricShapes).Count(exactCount);
        }

        public static Quantifier GeometricShapes(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.GeometricShapes).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGeometricShapes()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.GeometricShapes);
        }

        public static Quantifier NotGeometricShapes(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.GeometricShapes).Count(exactCount);
        }

        public static Quantifier NotGeometricShapes(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.GeometricShapes).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Georgian()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Georgian);
        }

        public static Quantifier Georgian(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Georgian).Count(exactCount);
        }

        public static Quantifier Georgian(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Georgian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGeorgian()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Georgian);
        }

        public static Quantifier NotGeorgian(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Georgian).Count(exactCount);
        }

        public static Quantifier NotGeorgian(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Georgian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Greek()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Greek);
        }

        public static Quantifier Greek(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Greek).Count(exactCount);
        }

        public static Quantifier Greek(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Greek).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGreek()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Greek);
        }

        public static Quantifier NotGreek(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Greek).Count(exactCount);
        }

        public static Quantifier NotGreek(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Greek).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GreekAndCoptic()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.GreekAndCoptic);
        }

        public static Quantifier GreekAndCoptic(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.GreekAndCoptic).Count(exactCount);
        }

        public static Quantifier GreekAndCoptic(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.GreekAndCoptic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGreekAndCoptic()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.GreekAndCoptic);
        }

        public static Quantifier NotGreekAndCoptic(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.GreekAndCoptic).Count(exactCount);
        }

        public static Quantifier NotGreekAndCoptic(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.GreekAndCoptic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GreekExtended()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.GreekExtended);
        }

        public static Quantifier GreekExtended(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.GreekExtended).Count(exactCount);
        }

        public static Quantifier GreekExtended(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.GreekExtended).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGreekExtended()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.GreekExtended);
        }

        public static Quantifier NotGreekExtended(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.GreekExtended).Count(exactCount);
        }

        public static Quantifier NotGreekExtended(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.GreekExtended).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Gujarati()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Gujarati);
        }

        public static Quantifier Gujarati(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Gujarati).Count(exactCount);
        }

        public static Quantifier Gujarati(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Gujarati).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGujarati()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Gujarati);
        }

        public static Quantifier NotGujarati(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Gujarati).Count(exactCount);
        }

        public static Quantifier NotGujarati(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Gujarati).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Gurmukhi()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Gurmukhi);
        }

        public static Quantifier Gurmukhi(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Gurmukhi).Count(exactCount);
        }

        public static Quantifier Gurmukhi(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Gurmukhi).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGurmukhi()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Gurmukhi);
        }

        public static Quantifier NotGurmukhi(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Gurmukhi).Count(exactCount);
        }

        public static Quantifier NotGurmukhi(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Gurmukhi).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HalfWidthAndFullWidthForms()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms);
        }

        public static Quantifier HalfWidthAndFullWidthForms(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms).Count(exactCount);
        }

        public static Quantifier HalfWidthAndFullWidthForms(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHalfWidthAndFullWidthForms()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms);
        }

        public static Quantifier NotHalfWidthAndFullWidthForms(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms).Count(exactCount);
        }

        public static Quantifier NotHalfWidthAndFullWidthForms(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HangulCompatibilityJamo()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HangulCompatibilityJamo);
        }

        public static Quantifier HangulCompatibilityJamo(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HangulCompatibilityJamo).Count(exactCount);
        }

        public static Quantifier HangulCompatibilityJamo(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HangulCompatibilityJamo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHangulCompatibilityJamo()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HangulCompatibilityJamo);
        }

        public static Quantifier NotHangulCompatibilityJamo(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HangulCompatibilityJamo).Count(exactCount);
        }

        public static Quantifier NotHangulCompatibilityJamo(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HangulCompatibilityJamo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HangulJamo()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HangulJamo);
        }

        public static Quantifier HangulJamo(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HangulJamo).Count(exactCount);
        }

        public static Quantifier HangulJamo(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HangulJamo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHangulJamo()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HangulJamo);
        }

        public static Quantifier NotHangulJamo(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HangulJamo).Count(exactCount);
        }

        public static Quantifier NotHangulJamo(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HangulJamo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HangulSyllables()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HangulSyllables);
        }

        public static Quantifier HangulSyllables(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HangulSyllables).Count(exactCount);
        }

        public static Quantifier HangulSyllables(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HangulSyllables).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHangulSyllables()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HangulSyllables);
        }

        public static Quantifier NotHangulSyllables(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HangulSyllables).Count(exactCount);
        }

        public static Quantifier NotHangulSyllables(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HangulSyllables).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Hanunoo()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Hanunoo);
        }

        public static Quantifier Hanunoo(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Hanunoo).Count(exactCount);
        }

        public static Quantifier Hanunoo(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Hanunoo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHanunoo()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Hanunoo);
        }

        public static Quantifier NotHanunoo(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Hanunoo).Count(exactCount);
        }

        public static Quantifier NotHanunoo(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Hanunoo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Hebrew()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Hebrew);
        }

        public static Quantifier Hebrew(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Hebrew).Count(exactCount);
        }

        public static Quantifier Hebrew(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Hebrew).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHebrew()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Hebrew);
        }

        public static Quantifier NotHebrew(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Hebrew).Count(exactCount);
        }

        public static Quantifier NotHebrew(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Hebrew).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HighPrivateUseSurrogates()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates);
        }

        public static Quantifier HighPrivateUseSurrogates(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates).Count(exactCount);
        }

        public static Quantifier HighPrivateUseSurrogates(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHighPrivateUseSurrogates()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates);
        }

        public static Quantifier NotHighPrivateUseSurrogates(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates).Count(exactCount);
        }

        public static Quantifier NotHighPrivateUseSurrogates(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HighSurrogates()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HighSurrogates);
        }

        public static Quantifier HighSurrogates(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HighSurrogates).Count(exactCount);
        }

        public static Quantifier HighSurrogates(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.HighSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHighSurrogates()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HighSurrogates);
        }

        public static Quantifier NotHighSurrogates(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HighSurrogates).Count(exactCount);
        }

        public static Quantifier NotHighSurrogates(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.HighSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Hiragana()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Hiragana);
        }

        public static Quantifier Hiragana(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Hiragana).Count(exactCount);
        }

        public static Quantifier Hiragana(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Hiragana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHiragana()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Hiragana);
        }

        public static Quantifier NotHiragana(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Hiragana).Count(exactCount);
        }

        public static Quantifier NotHiragana(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Hiragana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Cherokee()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Cherokee);
        }

        public static Quantifier Cherokee(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Cherokee).Count(exactCount);
        }

        public static Quantifier Cherokee(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Cherokee).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCherokee()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Cherokee);
        }

        public static Quantifier NotCherokee(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Cherokee).Count(exactCount);
        }

        public static Quantifier NotCherokee(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Cherokee).Count(minCount, maxCount);
        }

        public static QuantifiableExpression IdeographicDescriptionCharacters()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters);
        }

        public static Quantifier IdeographicDescriptionCharacters(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters).Count(exactCount);
        }

        public static Quantifier IdeographicDescriptionCharacters(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotIdeographicDescriptionCharacters()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters);
        }

        public static Quantifier NotIdeographicDescriptionCharacters(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters).Count(exactCount);
        }

        public static Quantifier NotIdeographicDescriptionCharacters(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression IPAExtensions()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.IPAExtensions);
        }

        public static Quantifier IPAExtensions(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.IPAExtensions).Count(exactCount);
        }

        public static Quantifier IPAExtensions(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.IPAExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotIPAExtensions()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.IPAExtensions);
        }

        public static Quantifier NotIPAExtensions(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.IPAExtensions).Count(exactCount);
        }

        public static Quantifier NotIPAExtensions(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.IPAExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Kanbun()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Kanbun);
        }

        public static Quantifier Kanbun(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Kanbun).Count(exactCount);
        }

        public static Quantifier Kanbun(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Kanbun).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKanbun()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Kanbun);
        }

        public static Quantifier NotKanbun(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Kanbun).Count(exactCount);
        }

        public static Quantifier NotKanbun(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Kanbun).Count(minCount, maxCount);
        }

        public static QuantifiableExpression KangxiRadicals()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.KangxiRadicals);
        }

        public static Quantifier KangxiRadicals(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.KangxiRadicals).Count(exactCount);
        }

        public static Quantifier KangxiRadicals(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.KangxiRadicals).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKangxiRadicals()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.KangxiRadicals);
        }

        public static Quantifier NotKangxiRadicals(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.KangxiRadicals).Count(exactCount);
        }

        public static Quantifier NotKangxiRadicals(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.KangxiRadicals).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Kannada()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Kannada);
        }

        public static Quantifier Kannada(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Kannada).Count(exactCount);
        }

        public static Quantifier Kannada(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Kannada).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKannada()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Kannada);
        }

        public static Quantifier NotKannada(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Kannada).Count(exactCount);
        }

        public static Quantifier NotKannada(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Kannada).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Katakana()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Katakana);
        }

        public static Quantifier Katakana(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Katakana).Count(exactCount);
        }

        public static Quantifier Katakana(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Katakana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKatakana()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Katakana);
        }

        public static Quantifier NotKatakana(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Katakana).Count(exactCount);
        }

        public static Quantifier NotKatakana(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Katakana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression KatakanaPhoneticExtensions()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions);
        }

        public static Quantifier KatakanaPhoneticExtensions(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions).Count(exactCount);
        }

        public static Quantifier KatakanaPhoneticExtensions(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKatakanaPhoneticExtensions()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions);
        }

        public static Quantifier NotKatakanaPhoneticExtensions(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions).Count(exactCount);
        }

        public static Quantifier NotKatakanaPhoneticExtensions(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Khmer()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Khmer);
        }

        public static Quantifier Khmer(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Khmer).Count(exactCount);
        }

        public static Quantifier Khmer(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Khmer).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKhmer()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Khmer);
        }

        public static Quantifier NotKhmer(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Khmer).Count(exactCount);
        }

        public static Quantifier NotKhmer(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Khmer).Count(minCount, maxCount);
        }

        public static QuantifiableExpression KhmerSymbols()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.KhmerSymbols);
        }

        public static Quantifier KhmerSymbols(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.KhmerSymbols).Count(exactCount);
        }

        public static Quantifier KhmerSymbols(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.KhmerSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKhmerSymbols()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.KhmerSymbols);
        }

        public static Quantifier NotKhmerSymbols(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.KhmerSymbols).Count(exactCount);
        }

        public static Quantifier NotKhmerSymbols(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.KhmerSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Lao()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Lao);
        }

        public static Quantifier Lao(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Lao).Count(exactCount);
        }

        public static Quantifier Lao(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Lao).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLao()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Lao);
        }

        public static Quantifier NotLao(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Lao).Count(exactCount);
        }

        public static Quantifier NotLao(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Lao).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Latin1Supplement()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Latin1Supplement);
        }

        public static Quantifier Latin1Supplement(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Latin1Supplement).Count(exactCount);
        }

        public static Quantifier Latin1Supplement(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Latin1Supplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLatin1Supplement()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Latin1Supplement);
        }

        public static Quantifier NotLatin1Supplement(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Latin1Supplement).Count(exactCount);
        }

        public static Quantifier NotLatin1Supplement(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Latin1Supplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LatinExtendedA()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LatinExtendedA);
        }

        public static Quantifier LatinExtendedA(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LatinExtendedA).Count(exactCount);
        }

        public static Quantifier LatinExtendedA(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LatinExtendedA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLatinExtendedA()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LatinExtendedA);
        }

        public static Quantifier NotLatinExtendedA(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LatinExtendedA).Count(exactCount);
        }

        public static Quantifier NotLatinExtendedA(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LatinExtendedA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LatinExtendedAdditional()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LatinExtendedAdditional);
        }

        public static Quantifier LatinExtendedAdditional(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LatinExtendedAdditional).Count(exactCount);
        }

        public static Quantifier LatinExtendedAdditional(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LatinExtendedAdditional).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLatinExtendedAdditional()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LatinExtendedAdditional);
        }

        public static Quantifier NotLatinExtendedAdditional(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LatinExtendedAdditional).Count(exactCount);
        }

        public static Quantifier NotLatinExtendedAdditional(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LatinExtendedAdditional).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LatinExtendedB()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LatinExtendedB);
        }

        public static Quantifier LatinExtendedB(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LatinExtendedB).Count(exactCount);
        }

        public static Quantifier LatinExtendedB(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LatinExtendedB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLatinExtendedB()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LatinExtendedB);
        }

        public static Quantifier NotLatinExtendedB(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LatinExtendedB).Count(exactCount);
        }

        public static Quantifier NotLatinExtendedB(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LatinExtendedB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterLikeSymbols()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LetterLikeSymbols);
        }

        public static Quantifier LetterLikeSymbols(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LetterLikeSymbols).Count(exactCount);
        }

        public static Quantifier LetterLikeSymbols(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LetterLikeSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterLikeSymbols()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LetterLikeSymbols);
        }

        public static Quantifier NotLetterLikeSymbols(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LetterLikeSymbols).Count(exactCount);
        }

        public static Quantifier NotLetterLikeSymbols(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LetterLikeSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Limbu()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Limbu);
        }

        public static Quantifier Limbu(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Limbu).Count(exactCount);
        }

        public static Quantifier Limbu(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Limbu).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLimbu()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Limbu);
        }

        public static Quantifier NotLimbu(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Limbu).Count(exactCount);
        }

        public static Quantifier NotLimbu(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Limbu).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LowSurrogates()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LowSurrogates);
        }

        public static Quantifier LowSurrogates(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LowSurrogates).Count(exactCount);
        }

        public static Quantifier LowSurrogates(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.LowSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLowSurrogates()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LowSurrogates);
        }

        public static Quantifier NotLowSurrogates(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LowSurrogates).Count(exactCount);
        }

        public static Quantifier NotLowSurrogates(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.LowSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Malayalam()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Malayalam);
        }

        public static Quantifier Malayalam(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Malayalam).Count(exactCount);
        }

        public static Quantifier Malayalam(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Malayalam).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMalayalam()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Malayalam);
        }

        public static Quantifier NotMalayalam(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Malayalam).Count(exactCount);
        }

        public static Quantifier NotMalayalam(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Malayalam).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MathematicalOperators()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MathematicalOperators);
        }

        public static Quantifier MathematicalOperators(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MathematicalOperators).Count(exactCount);
        }

        public static Quantifier MathematicalOperators(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MathematicalOperators).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMathematicalOperators()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MathematicalOperators);
        }

        public static Quantifier NotMathematicalOperators(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MathematicalOperators).Count(exactCount);
        }

        public static Quantifier NotMathematicalOperators(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MathematicalOperators).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousMathematicalSymbolsA()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA);
        }

        public static Quantifier MiscellaneousMathematicalSymbolsA(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA).Count(exactCount);
        }

        public static Quantifier MiscellaneousMathematicalSymbolsA(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousMathematicalSymbolsA()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA);
        }

        public static Quantifier NotMiscellaneousMathematicalSymbolsA(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA).Count(exactCount);
        }

        public static Quantifier NotMiscellaneousMathematicalSymbolsA(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousMathematicalSymbolsB()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB);
        }

        public static Quantifier MiscellaneousMathematicalSymbolsB(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB).Count(exactCount);
        }

        public static Quantifier MiscellaneousMathematicalSymbolsB(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousMathematicalSymbolsB()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB);
        }

        public static Quantifier NotMiscellaneousMathematicalSymbolsB(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB).Count(exactCount);
        }

        public static Quantifier NotMiscellaneousMathematicalSymbolsB(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousSymbols()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousSymbols);
        }

        public static Quantifier MiscellaneousSymbols(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousSymbols).Count(exactCount);
        }

        public static Quantifier MiscellaneousSymbols(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousSymbols()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbols);
        }

        public static Quantifier NotMiscellaneousSymbols(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbols).Count(exactCount);
        }

        public static Quantifier NotMiscellaneousSymbols(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousSymbolsAndArrows()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows);
        }

        public static Quantifier MiscellaneousSymbolsAndArrows(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows).Count(exactCount);
        }

        public static Quantifier MiscellaneousSymbolsAndArrows(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousSymbolsAndArrows()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows);
        }

        public static Quantifier NotMiscellaneousSymbolsAndArrows(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows).Count(exactCount);
        }

        public static Quantifier NotMiscellaneousSymbolsAndArrows(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousTechnical()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousTechnical);
        }

        public static Quantifier MiscellaneousTechnical(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousTechnical).Count(exactCount);
        }

        public static Quantifier MiscellaneousTechnical(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.MiscellaneousTechnical).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousTechnical()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousTechnical);
        }

        public static Quantifier NotMiscellaneousTechnical(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousTechnical).Count(exactCount);
        }

        public static Quantifier NotMiscellaneousTechnical(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.MiscellaneousTechnical).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Mongolian()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Mongolian);
        }

        public static Quantifier Mongolian(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Mongolian).Count(exactCount);
        }

        public static Quantifier Mongolian(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Mongolian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMongolian()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Mongolian);
        }

        public static Quantifier NotMongolian(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Mongolian).Count(exactCount);
        }

        public static Quantifier NotMongolian(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Mongolian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Myanmar()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Myanmar);
        }

        public static Quantifier Myanmar(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Myanmar).Count(exactCount);
        }

        public static Quantifier Myanmar(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Myanmar).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMyanmar()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Myanmar);
        }

        public static Quantifier NotMyanmar(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Myanmar).Count(exactCount);
        }

        public static Quantifier NotMyanmar(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Myanmar).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberForms()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.NumberForms);
        }

        public static Quantifier NumberForms(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.NumberForms).Count(exactCount);
        }

        public static Quantifier NumberForms(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.NumberForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberForms()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.NumberForms);
        }

        public static Quantifier NotNumberForms(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.NumberForms).Count(exactCount);
        }

        public static Quantifier NotNumberForms(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.NumberForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Ogham()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Ogham);
        }

        public static Quantifier Ogham(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Ogham).Count(exactCount);
        }

        public static Quantifier Ogham(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Ogham).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOgham()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Ogham);
        }

        public static Quantifier NotOgham(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Ogham).Count(exactCount);
        }

        public static Quantifier NotOgham(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Ogham).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OpticalCharacterRecognition()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.OpticalCharacterRecognition);
        }

        public static Quantifier OpticalCharacterRecognition(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.OpticalCharacterRecognition).Count(exactCount);
        }

        public static Quantifier OpticalCharacterRecognition(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.OpticalCharacterRecognition).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOpticalCharacterRecognition()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.OpticalCharacterRecognition);
        }

        public static Quantifier NotOpticalCharacterRecognition(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.OpticalCharacterRecognition).Count(exactCount);
        }

        public static Quantifier NotOpticalCharacterRecognition(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.OpticalCharacterRecognition).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Oriya()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Oriya);
        }

        public static Quantifier Oriya(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Oriya).Count(exactCount);
        }

        public static Quantifier Oriya(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Oriya).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOriya()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Oriya);
        }

        public static Quantifier NotOriya(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Oriya).Count(exactCount);
        }

        public static Quantifier NotOriya(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Oriya).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PhoneticExtensions()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.PhoneticExtensions);
        }

        public static Quantifier PhoneticExtensions(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.PhoneticExtensions).Count(exactCount);
        }

        public static Quantifier PhoneticExtensions(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.PhoneticExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPhoneticExtensions()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.PhoneticExtensions);
        }

        public static Quantifier NotPhoneticExtensions(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.PhoneticExtensions).Count(exactCount);
        }

        public static Quantifier NotPhoneticExtensions(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.PhoneticExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PrivateUse()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.PrivateUse);
        }

        public static Quantifier PrivateUse(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.PrivateUse).Count(exactCount);
        }

        public static Quantifier PrivateUse(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.PrivateUse).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPrivateUse()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.PrivateUse);
        }

        public static Quantifier NotPrivateUse(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.PrivateUse).Count(exactCount);
        }

        public static Quantifier NotPrivateUse(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.PrivateUse).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PrivateUseArea()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.PrivateUseArea);
        }

        public static Quantifier PrivateUseArea(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.PrivateUseArea).Count(exactCount);
        }

        public static Quantifier PrivateUseArea(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.PrivateUseArea).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPrivateUseArea()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.PrivateUseArea);
        }

        public static Quantifier NotPrivateUseArea(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.PrivateUseArea).Count(exactCount);
        }

        public static Quantifier NotPrivateUseArea(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.PrivateUseArea).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Runic()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Runic);
        }

        public static Quantifier Runic(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Runic).Count(exactCount);
        }

        public static Quantifier Runic(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Runic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotRunic()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Runic);
        }

        public static Quantifier NotRunic(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Runic).Count(exactCount);
        }

        public static Quantifier NotRunic(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Runic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Sinhala()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Sinhala);
        }

        public static Quantifier Sinhala(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Sinhala).Count(exactCount);
        }

        public static Quantifier Sinhala(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Sinhala).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSinhala()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Sinhala);
        }

        public static Quantifier NotSinhala(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Sinhala).Count(exactCount);
        }

        public static Quantifier NotSinhala(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Sinhala).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SmallFormVariants()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SmallFormVariants);
        }

        public static Quantifier SmallFormVariants(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SmallFormVariants).Count(exactCount);
        }

        public static Quantifier SmallFormVariants(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SmallFormVariants).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSmallFormVariants()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SmallFormVariants);
        }

        public static Quantifier NotSmallFormVariants(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SmallFormVariants).Count(exactCount);
        }

        public static Quantifier NotSmallFormVariants(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SmallFormVariants).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SpacingModifierLetters()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SpacingModifierLetters);
        }

        public static Quantifier SpacingModifierLetters(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SpacingModifierLetters).Count(exactCount);
        }

        public static Quantifier SpacingModifierLetters(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SpacingModifierLetters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSpacingModifierLetters()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SpacingModifierLetters);
        }

        public static Quantifier NotSpacingModifierLetters(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SpacingModifierLetters).Count(exactCount);
        }

        public static Quantifier NotSpacingModifierLetters(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SpacingModifierLetters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Specials()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Specials);
        }

        public static Quantifier Specials(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Specials).Count(exactCount);
        }

        public static Quantifier Specials(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Specials).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSpecials()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Specials);
        }

        public static Quantifier NotSpecials(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Specials).Count(exactCount);
        }

        public static Quantifier NotSpecials(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Specials).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SuperscriptsAndSubscripts()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts);
        }

        public static Quantifier SuperscriptsAndSubscripts(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts).Count(exactCount);
        }

        public static Quantifier SuperscriptsAndSubscripts(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSuperscriptsAndSubscripts()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts);
        }

        public static Quantifier NotSuperscriptsAndSubscripts(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts).Count(exactCount);
        }

        public static Quantifier NotSuperscriptsAndSubscripts(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SupplementalArrowsA()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SupplementalArrowsA);
        }

        public static Quantifier SupplementalArrowsA(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SupplementalArrowsA).Count(exactCount);
        }

        public static Quantifier SupplementalArrowsA(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SupplementalArrowsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSupplementalArrowsA()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsA);
        }

        public static Quantifier NotSupplementalArrowsA(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsA).Count(exactCount);
        }

        public static Quantifier NotSupplementalArrowsA(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SupplementalArrowsB()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SupplementalArrowsB);
        }

        public static Quantifier SupplementalArrowsB(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SupplementalArrowsB).Count(exactCount);
        }

        public static Quantifier SupplementalArrowsB(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SupplementalArrowsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSupplementalArrowsB()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsB);
        }

        public static Quantifier NotSupplementalArrowsB(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsB).Count(exactCount);
        }

        public static Quantifier NotSupplementalArrowsB(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SupplementalMathematicalOperators()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators);
        }

        public static Quantifier SupplementalMathematicalOperators(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators).Count(exactCount);
        }

        public static Quantifier SupplementalMathematicalOperators(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSupplementalMathematicalOperators()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators);
        }

        public static Quantifier NotSupplementalMathematicalOperators(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators).Count(exactCount);
        }

        public static Quantifier NotSupplementalMathematicalOperators(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Syriac()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Syriac);
        }

        public static Quantifier Syriac(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Syriac).Count(exactCount);
        }

        public static Quantifier Syriac(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Syriac).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSyriac()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Syriac);
        }

        public static Quantifier NotSyriac(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Syriac).Count(exactCount);
        }

        public static Quantifier NotSyriac(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Syriac).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tagalog()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Tagalog);
        }

        public static Quantifier Tagalog(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Tagalog).Count(exactCount);
        }

        public static Quantifier Tagalog(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Tagalog).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTagalog()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Tagalog);
        }

        public static Quantifier NotTagalog(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Tagalog).Count(exactCount);
        }

        public static Quantifier NotTagalog(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Tagalog).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tagbanwa()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Tagbanwa);
        }

        public static Quantifier Tagbanwa(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Tagbanwa).Count(exactCount);
        }

        public static Quantifier Tagbanwa(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Tagbanwa).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTagbanwa()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Tagbanwa);
        }

        public static Quantifier NotTagbanwa(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Tagbanwa).Count(exactCount);
        }

        public static Quantifier NotTagbanwa(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Tagbanwa).Count(minCount, maxCount);
        }

        public static QuantifiableExpression TaiLe()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.TaiLe);
        }

        public static Quantifier TaiLe(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.TaiLe).Count(exactCount);
        }

        public static Quantifier TaiLe(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.TaiLe).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTaiLe()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.TaiLe);
        }

        public static Quantifier NotTaiLe(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.TaiLe).Count(exactCount);
        }

        public static Quantifier NotTaiLe(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.TaiLe).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tamil()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Tamil);
        }

        public static Quantifier Tamil(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Tamil).Count(exactCount);
        }

        public static Quantifier Tamil(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Tamil).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTamil()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Tamil);
        }

        public static Quantifier NotTamil(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Tamil).Count(exactCount);
        }

        public static Quantifier NotTamil(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Tamil).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Telugu()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Telugu);
        }

        public static Quantifier Telugu(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Telugu).Count(exactCount);
        }

        public static Quantifier Telugu(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Telugu).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTelugu()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Telugu);
        }

        public static Quantifier NotTelugu(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Telugu).Count(exactCount);
        }

        public static Quantifier NotTelugu(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Telugu).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Thaana()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Thaana);
        }

        public static Quantifier Thaana(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Thaana).Count(exactCount);
        }

        public static Quantifier Thaana(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Thaana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotThaana()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Thaana);
        }

        public static Quantifier NotThaana(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Thaana).Count(exactCount);
        }

        public static Quantifier NotThaana(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Thaana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Thai()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Thai);
        }

        public static Quantifier Thai(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Thai).Count(exactCount);
        }

        public static Quantifier Thai(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Thai).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotThai()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Thai);
        }

        public static Quantifier NotThai(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Thai).Count(exactCount);
        }

        public static Quantifier NotThai(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Thai).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tibetan()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Tibetan);
        }

        public static Quantifier Tibetan(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Tibetan).Count(exactCount);
        }

        public static Quantifier Tibetan(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.Tibetan).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTibetan()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Tibetan);
        }

        public static Quantifier NotTibetan(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Tibetan).Count(exactCount);
        }

        public static Quantifier NotTibetan(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.Tibetan).Count(minCount, maxCount);
        }

        public static QuantifiableExpression UnifiedCanadianAboriginalSyllabics()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics);
        }

        public static Quantifier UnifiedCanadianAboriginalSyllabics(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics).Count(exactCount);
        }

        public static Quantifier UnifiedCanadianAboriginalSyllabics(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotUnifiedCanadianAboriginalSyllabics()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics);
        }

        public static Quantifier NotUnifiedCanadianAboriginalSyllabics(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics).Count(exactCount);
        }

        public static Quantifier NotUnifiedCanadianAboriginalSyllabics(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics).Count(minCount, maxCount);
        }

        public static QuantifiableExpression VariationSelectors()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.VariationSelectors);
        }

        public static Quantifier VariationSelectors(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.VariationSelectors).Count(exactCount);
        }

        public static Quantifier VariationSelectors(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.VariationSelectors).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotVariationSelectors()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.VariationSelectors);
        }

        public static Quantifier NotVariationSelectors(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.VariationSelectors).Count(exactCount);
        }

        public static Quantifier NotVariationSelectors(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.VariationSelectors).Count(minCount, maxCount);
        }

        public static QuantifiableExpression YijingHexagramSymbols()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.YijingHexagramSymbols);
        }

        public static Quantifier YijingHexagramSymbols(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.YijingHexagramSymbols).Count(exactCount);
        }

        public static Quantifier YijingHexagramSymbols(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.YijingHexagramSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotYijingHexagramSymbols()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.YijingHexagramSymbols);
        }

        public static Quantifier NotYijingHexagramSymbols(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.YijingHexagramSymbols).Count(exactCount);
        }

        public static Quantifier NotYijingHexagramSymbols(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.YijingHexagramSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression YiRadicals()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.YiRadicals);
        }

        public static Quantifier YiRadicals(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.YiRadicals).Count(exactCount);
        }

        public static Quantifier YiRadicals(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.YiRadicals).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotYiRadicals()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.YiRadicals);
        }

        public static Quantifier NotYiRadicals(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.YiRadicals).Count(exactCount);
        }

        public static Quantifier NotYiRadicals(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.YiRadicals).Count(minCount, maxCount);
        }

        public static QuantifiableExpression YiSyllables()
        {
            return Expressions.UnicodeBlock(UnicodeBlock.YiSyllables);
        }

        public static Quantifier YiSyllables(int exactCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.YiSyllables).Count(exactCount);
        }

        public static Quantifier YiSyllables(int minCount, int maxCount)
        {
            return Expressions.UnicodeBlock(UnicodeBlock.YiSyllables).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotYiSyllables()
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.YiSyllables);
        }

        public static Quantifier NotYiSyllables(int exactCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.YiSyllables).Count(exactCount);
        }

        public static Quantifier NotYiSyllables(int minCount, int maxCount)
        {
            return Expressions.NotUnicodeBlock(UnicodeBlock.YiSyllables).Count(minCount, maxCount);
        }
    }
}
