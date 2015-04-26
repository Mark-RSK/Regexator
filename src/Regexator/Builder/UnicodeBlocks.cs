// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class UnicodeBlocks
    {
        public static QuantifiableExpression AlphabeticPresentationForms()
        {
            return Characters.UnicodeBlock(UnicodeBlock.AlphabeticPresentationForms);
        }

        public static Quantifier AlphabeticPresentationForms(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.AlphabeticPresentationForms).Count(exactCount);
        }

        public static Quantifier AlphabeticPresentationForms(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.AlphabeticPresentationForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotAlphabeticPresentationForms()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.AlphabeticPresentationForms);
        }

        public static Quantifier NotAlphabeticPresentationForms(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.AlphabeticPresentationForms).Count(exactCount);
        }

        public static Quantifier NotAlphabeticPresentationForms(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.AlphabeticPresentationForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Arabic()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Arabic);
        }

        public static Quantifier Arabic(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Arabic).Count(exactCount);
        }

        public static Quantifier Arabic(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Arabic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArabic()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Arabic);
        }

        public static Quantifier NotArabic(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Arabic).Count(exactCount);
        }

        public static Quantifier NotArabic(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Arabic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression ArabicPresentationFormsA()
        {
            return Characters.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsA);
        }

        public static Quantifier ArabicPresentationFormsA(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsA).Count(exactCount);
        }

        public static Quantifier ArabicPresentationFormsA(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArabicPresentationFormsA()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsA);
        }

        public static Quantifier NotArabicPresentationFormsA(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsA).Count(exactCount);
        }

        public static Quantifier NotArabicPresentationFormsA(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression ArabicPresentationFormsB()
        {
            return Characters.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsB);
        }

        public static Quantifier ArabicPresentationFormsB(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsB).Count(exactCount);
        }

        public static Quantifier ArabicPresentationFormsB(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.ArabicPresentationFormsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArabicPresentationFormsB()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsB);
        }

        public static Quantifier NotArabicPresentationFormsB(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsB).Count(exactCount);
        }

        public static Quantifier NotArabicPresentationFormsB(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.ArabicPresentationFormsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Armenian()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Armenian);
        }

        public static Quantifier Armenian(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Armenian).Count(exactCount);
        }

        public static Quantifier Armenian(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Armenian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArmenian()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Armenian);
        }

        public static Quantifier NotArmenian(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Armenian).Count(exactCount);
        }

        public static Quantifier NotArmenian(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Armenian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Arrows()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Arrows);
        }

        public static Quantifier Arrows(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Arrows).Count(exactCount);
        }

        public static Quantifier Arrows(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Arrows).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotArrows()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Arrows);
        }

        public static Quantifier NotArrows(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Arrows).Count(exactCount);
        }

        public static Quantifier NotArrows(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Arrows).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BasicLatin()
        {
            return Characters.UnicodeBlock(UnicodeBlock.BasicLatin);
        }

        public static Quantifier BasicLatin(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.BasicLatin).Count(exactCount);
        }

        public static Quantifier BasicLatin(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.BasicLatin).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBasicLatin()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BasicLatin);
        }

        public static Quantifier NotBasicLatin(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BasicLatin).Count(exactCount);
        }

        public static Quantifier NotBasicLatin(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BasicLatin).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Bengali()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Bengali);
        }

        public static Quantifier Bengali(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Bengali).Count(exactCount);
        }

        public static Quantifier Bengali(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Bengali).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBengali()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Bengali);
        }

        public static Quantifier NotBengali(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Bengali).Count(exactCount);
        }

        public static Quantifier NotBengali(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Bengali).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BlockElements()
        {
            return Characters.UnicodeBlock(UnicodeBlock.BlockElements);
        }

        public static Quantifier BlockElements(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.BlockElements).Count(exactCount);
        }

        public static Quantifier BlockElements(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.BlockElements).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBlockElements()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BlockElements);
        }

        public static Quantifier NotBlockElements(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BlockElements).Count(exactCount);
        }

        public static Quantifier NotBlockElements(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BlockElements).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Bopomofo()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Bopomofo);
        }

        public static Quantifier Bopomofo(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Bopomofo).Count(exactCount);
        }

        public static Quantifier Bopomofo(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Bopomofo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBopomofo()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Bopomofo);
        }

        public static Quantifier NotBopomofo(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Bopomofo).Count(exactCount);
        }

        public static Quantifier NotBopomofo(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Bopomofo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BopomofoExtended()
        {
            return Characters.UnicodeBlock(UnicodeBlock.BopomofoExtended);
        }

        public static Quantifier BopomofoExtended(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.BopomofoExtended).Count(exactCount);
        }

        public static Quantifier BopomofoExtended(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.BopomofoExtended).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBopomofoExtended()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BopomofoExtended);
        }

        public static Quantifier NotBopomofoExtended(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BopomofoExtended).Count(exactCount);
        }

        public static Quantifier NotBopomofoExtended(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BopomofoExtended).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BoxDrawing()
        {
            return Characters.UnicodeBlock(UnicodeBlock.BoxDrawing);
        }

        public static Quantifier BoxDrawing(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.BoxDrawing).Count(exactCount);
        }

        public static Quantifier BoxDrawing(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.BoxDrawing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBoxDrawing()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BoxDrawing);
        }

        public static Quantifier NotBoxDrawing(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BoxDrawing).Count(exactCount);
        }

        public static Quantifier NotBoxDrawing(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BoxDrawing).Count(minCount, maxCount);
        }

        public static QuantifiableExpression BraillePatterns()
        {
            return Characters.UnicodeBlock(UnicodeBlock.BraillePatterns);
        }

        public static Quantifier BraillePatterns(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.BraillePatterns).Count(exactCount);
        }

        public static Quantifier BraillePatterns(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.BraillePatterns).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBraillePatterns()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BraillePatterns);
        }

        public static Quantifier NotBraillePatterns(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BraillePatterns).Count(exactCount);
        }

        public static Quantifier NotBraillePatterns(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.BraillePatterns).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Buhid()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Buhid);
        }

        public static Quantifier Buhid(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Buhid).Count(exactCount);
        }

        public static Quantifier Buhid(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Buhid).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotBuhid()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Buhid);
        }

        public static Quantifier NotBuhid(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Buhid).Count(exactCount);
        }

        public static Quantifier NotBuhid(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Buhid).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKCompatibility()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKCompatibility);
        }

        public static Quantifier CJKCompatibility(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKCompatibility).Count(exactCount);
        }

        public static Quantifier CJKCompatibility(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKCompatibility).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKCompatibility()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKCompatibility);
        }

        public static Quantifier NotCJKCompatibility(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKCompatibility).Count(exactCount);
        }

        public static Quantifier NotCJKCompatibility(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKCompatibility).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKCompatibilityForms()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKCompatibilityForms);
        }

        public static Quantifier CJKCompatibilityForms(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKCompatibilityForms).Count(exactCount);
        }

        public static Quantifier CJKCompatibilityForms(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKCompatibilityForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKCompatibilityForms()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityForms);
        }

        public static Quantifier NotCJKCompatibilityForms(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityForms).Count(exactCount);
        }

        public static Quantifier NotCJKCompatibilityForms(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKCompatibilityIdeographs()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs);
        }

        public static Quantifier CJKCompatibilityIdeographs(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs).Count(exactCount);
        }

        public static Quantifier CJKCompatibilityIdeographs(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKCompatibilityIdeographs()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs);
        }

        public static Quantifier NotCJKCompatibilityIdeographs(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs).Count(exactCount);
        }

        public static Quantifier NotCJKCompatibilityIdeographs(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKCompatibilityIdeographs).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKRadicalsSupplement()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKRadicalsSupplement);
        }

        public static Quantifier CJKRadicalsSupplement(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKRadicalsSupplement).Count(exactCount);
        }

        public static Quantifier CJKRadicalsSupplement(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKRadicalsSupplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKRadicalsSupplement()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKRadicalsSupplement);
        }

        public static Quantifier NotCJKRadicalsSupplement(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKRadicalsSupplement).Count(exactCount);
        }

        public static Quantifier NotCJKRadicalsSupplement(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKRadicalsSupplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKSymbolsAndPunctuation()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation);
        }

        public static Quantifier CJKSymbolsAndPunctuation(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation).Count(exactCount);
        }

        public static Quantifier CJKSymbolsAndPunctuation(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKSymbolsAndPunctuation()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation);
        }

        public static Quantifier NotCJKSymbolsAndPunctuation(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation).Count(exactCount);
        }

        public static Quantifier NotCJKSymbolsAndPunctuation(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKSymbolsAndPunctuation).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKUnifiedIdeographs()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs);
        }

        public static Quantifier CJKUnifiedIdeographs(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs).Count(exactCount);
        }

        public static Quantifier CJKUnifiedIdeographs(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKUnifiedIdeographs()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs);
        }

        public static Quantifier NotCJKUnifiedIdeographs(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs).Count(exactCount);
        }

        public static Quantifier NotCJKUnifiedIdeographs(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographs).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CJKUnifiedIdeographsExtensionA()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA);
        }

        public static Quantifier CJKUnifiedIdeographsExtensionA(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA).Count(exactCount);
        }

        public static Quantifier CJKUnifiedIdeographsExtensionA(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCJKUnifiedIdeographsExtensionA()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA);
        }

        public static Quantifier NotCJKUnifiedIdeographsExtensionA(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA).Count(exactCount);
        }

        public static Quantifier NotCJKUnifiedIdeographsExtensionA(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CJKUnifiedIdeographsExtensionA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CombiningDiacriticalMarks()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks);
        }

        public static Quantifier CombiningDiacriticalMarks(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks).Count(exactCount);
        }

        public static Quantifier CombiningDiacriticalMarks(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCombiningDiacriticalMarks()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks);
        }

        public static Quantifier NotCombiningDiacriticalMarks(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks).Count(exactCount);
        }

        public static Quantifier NotCombiningDiacriticalMarks(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CombiningDiacriticalMarksForSymbols()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols);
        }

        public static Quantifier CombiningDiacriticalMarksForSymbols(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols).Count(exactCount);
        }

        public static Quantifier CombiningDiacriticalMarksForSymbols(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCombiningDiacriticalMarksForSymbols()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols);
        }

        public static Quantifier NotCombiningDiacriticalMarksForSymbols(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols).Count(exactCount);
        }

        public static Quantifier NotCombiningDiacriticalMarksForSymbols(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CombiningDiacriticalMarksForSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CombiningHalfMarks()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CombiningHalfMarks);
        }

        public static Quantifier CombiningHalfMarks(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CombiningHalfMarks).Count(exactCount);
        }

        public static Quantifier CombiningHalfMarks(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CombiningHalfMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCombiningHalfMarks()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CombiningHalfMarks);
        }

        public static Quantifier NotCombiningHalfMarks(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CombiningHalfMarks).Count(exactCount);
        }

        public static Quantifier NotCombiningHalfMarks(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CombiningHalfMarks).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CombiningMarksForSymbols()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CombiningMarksForSymbols);
        }

        public static Quantifier CombiningMarksForSymbols(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CombiningMarksForSymbols).Count(exactCount);
        }

        public static Quantifier CombiningMarksForSymbols(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CombiningMarksForSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCombiningMarksForSymbols()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CombiningMarksForSymbols);
        }

        public static Quantifier NotCombiningMarksForSymbols(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CombiningMarksForSymbols).Count(exactCount);
        }

        public static Quantifier NotCombiningMarksForSymbols(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CombiningMarksForSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression ControlPictures()
        {
            return Characters.UnicodeBlock(UnicodeBlock.ControlPictures);
        }

        public static Quantifier ControlPictures(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.ControlPictures).Count(exactCount);
        }

        public static Quantifier ControlPictures(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.ControlPictures).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotControlPictures()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.ControlPictures);
        }

        public static Quantifier NotControlPictures(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.ControlPictures).Count(exactCount);
        }

        public static Quantifier NotControlPictures(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.ControlPictures).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CurrencySymbols()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CurrencySymbols);
        }

        public static Quantifier CurrencySymbols(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CurrencySymbols).Count(exactCount);
        }

        public static Quantifier CurrencySymbols(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CurrencySymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCurrencySymbols()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CurrencySymbols);
        }

        public static Quantifier NotCurrencySymbols(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CurrencySymbols).Count(exactCount);
        }

        public static Quantifier NotCurrencySymbols(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CurrencySymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Cyrillic()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Cyrillic);
        }

        public static Quantifier Cyrillic(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Cyrillic).Count(exactCount);
        }

        public static Quantifier Cyrillic(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Cyrillic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCyrillic()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Cyrillic);
        }

        public static Quantifier NotCyrillic(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Cyrillic).Count(exactCount);
        }

        public static Quantifier NotCyrillic(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Cyrillic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression CyrillicSupplement()
        {
            return Characters.UnicodeBlock(UnicodeBlock.CyrillicSupplement);
        }

        public static Quantifier CyrillicSupplement(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CyrillicSupplement).Count(exactCount);
        }

        public static Quantifier CyrillicSupplement(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.CyrillicSupplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCyrillicSupplement()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CyrillicSupplement);
        }

        public static Quantifier NotCyrillicSupplement(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CyrillicSupplement).Count(exactCount);
        }

        public static Quantifier NotCyrillicSupplement(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.CyrillicSupplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Devanagari()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Devanagari);
        }

        public static Quantifier Devanagari(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Devanagari).Count(exactCount);
        }

        public static Quantifier Devanagari(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Devanagari).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotDevanagari()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Devanagari);
        }

        public static Quantifier NotDevanagari(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Devanagari).Count(exactCount);
        }

        public static Quantifier NotDevanagari(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Devanagari).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Dingbats()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Dingbats);
        }

        public static Quantifier Dingbats(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Dingbats).Count(exactCount);
        }

        public static Quantifier Dingbats(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Dingbats).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotDingbats()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Dingbats);
        }

        public static Quantifier NotDingbats(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Dingbats).Count(exactCount);
        }

        public static Quantifier NotDingbats(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Dingbats).Count(minCount, maxCount);
        }

        public static QuantifiableExpression EnclosedAlphanumerics()
        {
            return Characters.UnicodeBlock(UnicodeBlock.EnclosedAlphanumerics);
        }

        public static Quantifier EnclosedAlphanumerics(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.EnclosedAlphanumerics).Count(exactCount);
        }

        public static Quantifier EnclosedAlphanumerics(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.EnclosedAlphanumerics).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotEnclosedAlphanumerics()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.EnclosedAlphanumerics);
        }

        public static Quantifier NotEnclosedAlphanumerics(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.EnclosedAlphanumerics).Count(exactCount);
        }

        public static Quantifier NotEnclosedAlphanumerics(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.EnclosedAlphanumerics).Count(minCount, maxCount);
        }

        public static QuantifiableExpression EnclosedCJKLettersAndMonths()
        {
            return Characters.UnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths);
        }

        public static Quantifier EnclosedCJKLettersAndMonths(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths).Count(exactCount);
        }

        public static Quantifier EnclosedCJKLettersAndMonths(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotEnclosedCJKLettersAndMonths()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths);
        }

        public static Quantifier NotEnclosedCJKLettersAndMonths(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths).Count(exactCount);
        }

        public static Quantifier NotEnclosedCJKLettersAndMonths(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.EnclosedCJKLettersAndMonths).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Ethiopic()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Ethiopic);
        }

        public static Quantifier Ethiopic(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Ethiopic).Count(exactCount);
        }

        public static Quantifier Ethiopic(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Ethiopic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotEthiopic()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Ethiopic);
        }

        public static Quantifier NotEthiopic(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Ethiopic).Count(exactCount);
        }

        public static Quantifier NotEthiopic(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Ethiopic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GeneralPunctuation()
        {
            return Characters.UnicodeBlock(UnicodeBlock.GeneralPunctuation);
        }

        public static Quantifier GeneralPunctuation(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.GeneralPunctuation).Count(exactCount);
        }

        public static Quantifier GeneralPunctuation(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.GeneralPunctuation).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGeneralPunctuation()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.GeneralPunctuation);
        }

        public static Quantifier NotGeneralPunctuation(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.GeneralPunctuation).Count(exactCount);
        }

        public static Quantifier NotGeneralPunctuation(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.GeneralPunctuation).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GeometricShapes()
        {
            return Characters.UnicodeBlock(UnicodeBlock.GeometricShapes);
        }

        public static Quantifier GeometricShapes(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.GeometricShapes).Count(exactCount);
        }

        public static Quantifier GeometricShapes(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.GeometricShapes).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGeometricShapes()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.GeometricShapes);
        }

        public static Quantifier NotGeometricShapes(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.GeometricShapes).Count(exactCount);
        }

        public static Quantifier NotGeometricShapes(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.GeometricShapes).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Georgian()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Georgian);
        }

        public static Quantifier Georgian(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Georgian).Count(exactCount);
        }

        public static Quantifier Georgian(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Georgian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGeorgian()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Georgian);
        }

        public static Quantifier NotGeorgian(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Georgian).Count(exactCount);
        }

        public static Quantifier NotGeorgian(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Georgian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Greek()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Greek);
        }

        public static Quantifier Greek(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Greek).Count(exactCount);
        }

        public static Quantifier Greek(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Greek).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGreek()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Greek);
        }

        public static Quantifier NotGreek(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Greek).Count(exactCount);
        }

        public static Quantifier NotGreek(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Greek).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GreekAndCoptic()
        {
            return Characters.UnicodeBlock(UnicodeBlock.GreekAndCoptic);
        }

        public static Quantifier GreekAndCoptic(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.GreekAndCoptic).Count(exactCount);
        }

        public static Quantifier GreekAndCoptic(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.GreekAndCoptic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGreekAndCoptic()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.GreekAndCoptic);
        }

        public static Quantifier NotGreekAndCoptic(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.GreekAndCoptic).Count(exactCount);
        }

        public static Quantifier NotGreekAndCoptic(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.GreekAndCoptic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression GreekExtended()
        {
            return Characters.UnicodeBlock(UnicodeBlock.GreekExtended);
        }

        public static Quantifier GreekExtended(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.GreekExtended).Count(exactCount);
        }

        public static Quantifier GreekExtended(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.GreekExtended).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGreekExtended()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.GreekExtended);
        }

        public static Quantifier NotGreekExtended(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.GreekExtended).Count(exactCount);
        }

        public static Quantifier NotGreekExtended(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.GreekExtended).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Gujarati()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Gujarati);
        }

        public static Quantifier Gujarati(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Gujarati).Count(exactCount);
        }

        public static Quantifier Gujarati(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Gujarati).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGujarati()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Gujarati);
        }

        public static Quantifier NotGujarati(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Gujarati).Count(exactCount);
        }

        public static Quantifier NotGujarati(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Gujarati).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Gurmukhi()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Gurmukhi);
        }

        public static Quantifier Gurmukhi(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Gurmukhi).Count(exactCount);
        }

        public static Quantifier Gurmukhi(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Gurmukhi).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotGurmukhi()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Gurmukhi);
        }

        public static Quantifier NotGurmukhi(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Gurmukhi).Count(exactCount);
        }

        public static Quantifier NotGurmukhi(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Gurmukhi).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HalfWidthAndFullWidthForms()
        {
            return Characters.UnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms);
        }

        public static Quantifier HalfWidthAndFullWidthForms(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms).Count(exactCount);
        }

        public static Quantifier HalfWidthAndFullWidthForms(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHalfWidthAndFullWidthForms()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms);
        }

        public static Quantifier NotHalfWidthAndFullWidthForms(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms).Count(exactCount);
        }

        public static Quantifier NotHalfWidthAndFullWidthForms(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HalfWidthAndFullWidthForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HangulCompatibilityJamo()
        {
            return Characters.UnicodeBlock(UnicodeBlock.HangulCompatibilityJamo);
        }

        public static Quantifier HangulCompatibilityJamo(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.HangulCompatibilityJamo).Count(exactCount);
        }

        public static Quantifier HangulCompatibilityJamo(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.HangulCompatibilityJamo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHangulCompatibilityJamo()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HangulCompatibilityJamo);
        }

        public static Quantifier NotHangulCompatibilityJamo(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HangulCompatibilityJamo).Count(exactCount);
        }

        public static Quantifier NotHangulCompatibilityJamo(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HangulCompatibilityJamo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HangulJamo()
        {
            return Characters.UnicodeBlock(UnicodeBlock.HangulJamo);
        }

        public static Quantifier HangulJamo(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.HangulJamo).Count(exactCount);
        }

        public static Quantifier HangulJamo(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.HangulJamo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHangulJamo()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HangulJamo);
        }

        public static Quantifier NotHangulJamo(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HangulJamo).Count(exactCount);
        }

        public static Quantifier NotHangulJamo(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HangulJamo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HangulSyllables()
        {
            return Characters.UnicodeBlock(UnicodeBlock.HangulSyllables);
        }

        public static Quantifier HangulSyllables(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.HangulSyllables).Count(exactCount);
        }

        public static Quantifier HangulSyllables(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.HangulSyllables).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHangulSyllables()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HangulSyllables);
        }

        public static Quantifier NotHangulSyllables(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HangulSyllables).Count(exactCount);
        }

        public static Quantifier NotHangulSyllables(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HangulSyllables).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Hanunoo()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Hanunoo);
        }

        public static Quantifier Hanunoo(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Hanunoo).Count(exactCount);
        }

        public static Quantifier Hanunoo(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Hanunoo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHanunoo()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Hanunoo);
        }

        public static Quantifier NotHanunoo(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Hanunoo).Count(exactCount);
        }

        public static Quantifier NotHanunoo(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Hanunoo).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Hebrew()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Hebrew);
        }

        public static Quantifier Hebrew(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Hebrew).Count(exactCount);
        }

        public static Quantifier Hebrew(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Hebrew).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHebrew()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Hebrew);
        }

        public static Quantifier NotHebrew(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Hebrew).Count(exactCount);
        }

        public static Quantifier NotHebrew(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Hebrew).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HighPrivateUseSurrogates()
        {
            return Characters.UnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates);
        }

        public static Quantifier HighPrivateUseSurrogates(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates).Count(exactCount);
        }

        public static Quantifier HighPrivateUseSurrogates(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHighPrivateUseSurrogates()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates);
        }

        public static Quantifier NotHighPrivateUseSurrogates(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates).Count(exactCount);
        }

        public static Quantifier NotHighPrivateUseSurrogates(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HighPrivateUseSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression HighSurrogates()
        {
            return Characters.UnicodeBlock(UnicodeBlock.HighSurrogates);
        }

        public static Quantifier HighSurrogates(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.HighSurrogates).Count(exactCount);
        }

        public static Quantifier HighSurrogates(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.HighSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHighSurrogates()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HighSurrogates);
        }

        public static Quantifier NotHighSurrogates(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HighSurrogates).Count(exactCount);
        }

        public static Quantifier NotHighSurrogates(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.HighSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Hiragana()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Hiragana);
        }

        public static Quantifier Hiragana(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Hiragana).Count(exactCount);
        }

        public static Quantifier Hiragana(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Hiragana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotHiragana()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Hiragana);
        }

        public static Quantifier NotHiragana(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Hiragana).Count(exactCount);
        }

        public static Quantifier NotHiragana(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Hiragana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Cherokee()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Cherokee);
        }

        public static Quantifier Cherokee(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Cherokee).Count(exactCount);
        }

        public static Quantifier Cherokee(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Cherokee).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotCherokee()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Cherokee);
        }

        public static Quantifier NotCherokee(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Cherokee).Count(exactCount);
        }

        public static Quantifier NotCherokee(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Cherokee).Count(minCount, maxCount);
        }

        public static QuantifiableExpression IdeographicDescriptionCharacters()
        {
            return Characters.UnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters);
        }

        public static Quantifier IdeographicDescriptionCharacters(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters).Count(exactCount);
        }

        public static Quantifier IdeographicDescriptionCharacters(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotIdeographicDescriptionCharacters()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters);
        }

        public static Quantifier NotIdeographicDescriptionCharacters(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters).Count(exactCount);
        }

        public static Quantifier NotIdeographicDescriptionCharacters(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.IdeographicDescriptionCharacters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression IPAExtensions()
        {
            return Characters.UnicodeBlock(UnicodeBlock.IPAExtensions);
        }

        public static Quantifier IPAExtensions(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.IPAExtensions).Count(exactCount);
        }

        public static Quantifier IPAExtensions(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.IPAExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotIPAExtensions()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.IPAExtensions);
        }

        public static Quantifier NotIPAExtensions(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.IPAExtensions).Count(exactCount);
        }

        public static Quantifier NotIPAExtensions(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.IPAExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Kanbun()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Kanbun);
        }

        public static Quantifier Kanbun(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Kanbun).Count(exactCount);
        }

        public static Quantifier Kanbun(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Kanbun).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKanbun()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Kanbun);
        }

        public static Quantifier NotKanbun(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Kanbun).Count(exactCount);
        }

        public static Quantifier NotKanbun(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Kanbun).Count(minCount, maxCount);
        }

        public static QuantifiableExpression KangxiRadicals()
        {
            return Characters.UnicodeBlock(UnicodeBlock.KangxiRadicals);
        }

        public static Quantifier KangxiRadicals(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.KangxiRadicals).Count(exactCount);
        }

        public static Quantifier KangxiRadicals(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.KangxiRadicals).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKangxiRadicals()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.KangxiRadicals);
        }

        public static Quantifier NotKangxiRadicals(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.KangxiRadicals).Count(exactCount);
        }

        public static Quantifier NotKangxiRadicals(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.KangxiRadicals).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Kannada()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Kannada);
        }

        public static Quantifier Kannada(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Kannada).Count(exactCount);
        }

        public static Quantifier Kannada(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Kannada).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKannada()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Kannada);
        }

        public static Quantifier NotKannada(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Kannada).Count(exactCount);
        }

        public static Quantifier NotKannada(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Kannada).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Katakana()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Katakana);
        }

        public static Quantifier Katakana(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Katakana).Count(exactCount);
        }

        public static Quantifier Katakana(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Katakana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKatakana()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Katakana);
        }

        public static Quantifier NotKatakana(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Katakana).Count(exactCount);
        }

        public static Quantifier NotKatakana(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Katakana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression KatakanaPhoneticExtensions()
        {
            return Characters.UnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions);
        }

        public static Quantifier KatakanaPhoneticExtensions(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions).Count(exactCount);
        }

        public static Quantifier KatakanaPhoneticExtensions(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKatakanaPhoneticExtensions()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions);
        }

        public static Quantifier NotKatakanaPhoneticExtensions(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions).Count(exactCount);
        }

        public static Quantifier NotKatakanaPhoneticExtensions(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.KatakanaPhoneticExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Khmer()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Khmer);
        }

        public static Quantifier Khmer(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Khmer).Count(exactCount);
        }

        public static Quantifier Khmer(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Khmer).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKhmer()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Khmer);
        }

        public static Quantifier NotKhmer(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Khmer).Count(exactCount);
        }

        public static Quantifier NotKhmer(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Khmer).Count(minCount, maxCount);
        }

        public static QuantifiableExpression KhmerSymbols()
        {
            return Characters.UnicodeBlock(UnicodeBlock.KhmerSymbols);
        }

        public static Quantifier KhmerSymbols(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.KhmerSymbols).Count(exactCount);
        }

        public static Quantifier KhmerSymbols(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.KhmerSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotKhmerSymbols()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.KhmerSymbols);
        }

        public static Quantifier NotKhmerSymbols(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.KhmerSymbols).Count(exactCount);
        }

        public static Quantifier NotKhmerSymbols(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.KhmerSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Lao()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Lao);
        }

        public static Quantifier Lao(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Lao).Count(exactCount);
        }

        public static Quantifier Lao(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Lao).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLao()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Lao);
        }

        public static Quantifier NotLao(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Lao).Count(exactCount);
        }

        public static Quantifier NotLao(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Lao).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Latin1Supplement()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Latin1Supplement);
        }

        public static Quantifier Latin1Supplement(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Latin1Supplement).Count(exactCount);
        }

        public static Quantifier Latin1Supplement(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Latin1Supplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLatin1Supplement()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Latin1Supplement);
        }

        public static Quantifier NotLatin1Supplement(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Latin1Supplement).Count(exactCount);
        }

        public static Quantifier NotLatin1Supplement(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Latin1Supplement).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LatinExtendedA()
        {
            return Characters.UnicodeBlock(UnicodeBlock.LatinExtendedA);
        }

        public static Quantifier LatinExtendedA(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.LatinExtendedA).Count(exactCount);
        }

        public static Quantifier LatinExtendedA(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.LatinExtendedA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLatinExtendedA()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LatinExtendedA);
        }

        public static Quantifier NotLatinExtendedA(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LatinExtendedA).Count(exactCount);
        }

        public static Quantifier NotLatinExtendedA(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LatinExtendedA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LatinExtendedAdditional()
        {
            return Characters.UnicodeBlock(UnicodeBlock.LatinExtendedAdditional);
        }

        public static Quantifier LatinExtendedAdditional(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.LatinExtendedAdditional).Count(exactCount);
        }

        public static Quantifier LatinExtendedAdditional(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.LatinExtendedAdditional).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLatinExtendedAdditional()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LatinExtendedAdditional);
        }

        public static Quantifier NotLatinExtendedAdditional(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LatinExtendedAdditional).Count(exactCount);
        }

        public static Quantifier NotLatinExtendedAdditional(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LatinExtendedAdditional).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LatinExtendedB()
        {
            return Characters.UnicodeBlock(UnicodeBlock.LatinExtendedB);
        }

        public static Quantifier LatinExtendedB(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.LatinExtendedB).Count(exactCount);
        }

        public static Quantifier LatinExtendedB(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.LatinExtendedB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLatinExtendedB()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LatinExtendedB);
        }

        public static Quantifier NotLatinExtendedB(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LatinExtendedB).Count(exactCount);
        }

        public static Quantifier NotLatinExtendedB(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LatinExtendedB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LetterLikeSymbols()
        {
            return Characters.UnicodeBlock(UnicodeBlock.LetterLikeSymbols);
        }

        public static Quantifier LetterLikeSymbols(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.LetterLikeSymbols).Count(exactCount);
        }

        public static Quantifier LetterLikeSymbols(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.LetterLikeSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLetterLikeSymbols()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LetterLikeSymbols);
        }

        public static Quantifier NotLetterLikeSymbols(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LetterLikeSymbols).Count(exactCount);
        }

        public static Quantifier NotLetterLikeSymbols(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LetterLikeSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Limbu()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Limbu);
        }

        public static Quantifier Limbu(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Limbu).Count(exactCount);
        }

        public static Quantifier Limbu(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Limbu).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLimbu()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Limbu);
        }

        public static Quantifier NotLimbu(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Limbu).Count(exactCount);
        }

        public static Quantifier NotLimbu(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Limbu).Count(minCount, maxCount);
        }

        public static QuantifiableExpression LowSurrogates()
        {
            return Characters.UnicodeBlock(UnicodeBlock.LowSurrogates);
        }

        public static Quantifier LowSurrogates(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.LowSurrogates).Count(exactCount);
        }

        public static Quantifier LowSurrogates(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.LowSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotLowSurrogates()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LowSurrogates);
        }

        public static Quantifier NotLowSurrogates(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LowSurrogates).Count(exactCount);
        }

        public static Quantifier NotLowSurrogates(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.LowSurrogates).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Malayalam()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Malayalam);
        }

        public static Quantifier Malayalam(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Malayalam).Count(exactCount);
        }

        public static Quantifier Malayalam(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Malayalam).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMalayalam()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Malayalam);
        }

        public static Quantifier NotMalayalam(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Malayalam).Count(exactCount);
        }

        public static Quantifier NotMalayalam(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Malayalam).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MathematicalOperators()
        {
            return Characters.UnicodeBlock(UnicodeBlock.MathematicalOperators);
        }

        public static Quantifier MathematicalOperators(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.MathematicalOperators).Count(exactCount);
        }

        public static Quantifier MathematicalOperators(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.MathematicalOperators).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMathematicalOperators()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MathematicalOperators);
        }

        public static Quantifier NotMathematicalOperators(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MathematicalOperators).Count(exactCount);
        }

        public static Quantifier NotMathematicalOperators(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MathematicalOperators).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousMathematicalSymbolsA()
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA);
        }

        public static Quantifier MiscellaneousMathematicalSymbolsA(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA).Count(exactCount);
        }

        public static Quantifier MiscellaneousMathematicalSymbolsA(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousMathematicalSymbolsA()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA);
        }

        public static Quantifier NotMiscellaneousMathematicalSymbolsA(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA).Count(exactCount);
        }

        public static Quantifier NotMiscellaneousMathematicalSymbolsA(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousMathematicalSymbolsB()
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB);
        }

        public static Quantifier MiscellaneousMathematicalSymbolsB(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB).Count(exactCount);
        }

        public static Quantifier MiscellaneousMathematicalSymbolsB(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousMathematicalSymbolsB()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB);
        }

        public static Quantifier NotMiscellaneousMathematicalSymbolsB(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB).Count(exactCount);
        }

        public static Quantifier NotMiscellaneousMathematicalSymbolsB(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousMathematicalSymbolsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousSymbols()
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousSymbols);
        }

        public static Quantifier MiscellaneousSymbols(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousSymbols).Count(exactCount);
        }

        public static Quantifier MiscellaneousSymbols(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousSymbols()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbols);
        }

        public static Quantifier NotMiscellaneousSymbols(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbols).Count(exactCount);
        }

        public static Quantifier NotMiscellaneousSymbols(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousSymbolsAndArrows()
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows);
        }

        public static Quantifier MiscellaneousSymbolsAndArrows(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows).Count(exactCount);
        }

        public static Quantifier MiscellaneousSymbolsAndArrows(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousSymbolsAndArrows()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows);
        }

        public static Quantifier NotMiscellaneousSymbolsAndArrows(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows).Count(exactCount);
        }

        public static Quantifier NotMiscellaneousSymbolsAndArrows(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousSymbolsAndArrows).Count(minCount, maxCount);
        }

        public static QuantifiableExpression MiscellaneousTechnical()
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousTechnical);
        }

        public static Quantifier MiscellaneousTechnical(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousTechnical).Count(exactCount);
        }

        public static Quantifier MiscellaneousTechnical(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.MiscellaneousTechnical).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMiscellaneousTechnical()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousTechnical);
        }

        public static Quantifier NotMiscellaneousTechnical(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousTechnical).Count(exactCount);
        }

        public static Quantifier NotMiscellaneousTechnical(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.MiscellaneousTechnical).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Mongolian()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Mongolian);
        }

        public static Quantifier Mongolian(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Mongolian).Count(exactCount);
        }

        public static Quantifier Mongolian(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Mongolian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMongolian()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Mongolian);
        }

        public static Quantifier NotMongolian(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Mongolian).Count(exactCount);
        }

        public static Quantifier NotMongolian(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Mongolian).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Myanmar()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Myanmar);
        }

        public static Quantifier Myanmar(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Myanmar).Count(exactCount);
        }

        public static Quantifier Myanmar(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Myanmar).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotMyanmar()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Myanmar);
        }

        public static Quantifier NotMyanmar(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Myanmar).Count(exactCount);
        }

        public static Quantifier NotMyanmar(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Myanmar).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NumberForms()
        {
            return Characters.UnicodeBlock(UnicodeBlock.NumberForms);
        }

        public static Quantifier NumberForms(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.NumberForms).Count(exactCount);
        }

        public static Quantifier NumberForms(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.NumberForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotNumberForms()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.NumberForms);
        }

        public static Quantifier NotNumberForms(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.NumberForms).Count(exactCount);
        }

        public static Quantifier NotNumberForms(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.NumberForms).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Ogham()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Ogham);
        }

        public static Quantifier Ogham(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Ogham).Count(exactCount);
        }

        public static Quantifier Ogham(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Ogham).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOgham()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Ogham);
        }

        public static Quantifier NotOgham(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Ogham).Count(exactCount);
        }

        public static Quantifier NotOgham(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Ogham).Count(minCount, maxCount);
        }

        public static QuantifiableExpression OpticalCharacterRecognition()
        {
            return Characters.UnicodeBlock(UnicodeBlock.OpticalCharacterRecognition);
        }

        public static Quantifier OpticalCharacterRecognition(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.OpticalCharacterRecognition).Count(exactCount);
        }

        public static Quantifier OpticalCharacterRecognition(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.OpticalCharacterRecognition).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOpticalCharacterRecognition()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.OpticalCharacterRecognition);
        }

        public static Quantifier NotOpticalCharacterRecognition(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.OpticalCharacterRecognition).Count(exactCount);
        }

        public static Quantifier NotOpticalCharacterRecognition(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.OpticalCharacterRecognition).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Oriya()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Oriya);
        }

        public static Quantifier Oriya(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Oriya).Count(exactCount);
        }

        public static Quantifier Oriya(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Oriya).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotOriya()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Oriya);
        }

        public static Quantifier NotOriya(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Oriya).Count(exactCount);
        }

        public static Quantifier NotOriya(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Oriya).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PhoneticExtensions()
        {
            return Characters.UnicodeBlock(UnicodeBlock.PhoneticExtensions);
        }

        public static Quantifier PhoneticExtensions(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.PhoneticExtensions).Count(exactCount);
        }

        public static Quantifier PhoneticExtensions(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.PhoneticExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPhoneticExtensions()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.PhoneticExtensions);
        }

        public static Quantifier NotPhoneticExtensions(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.PhoneticExtensions).Count(exactCount);
        }

        public static Quantifier NotPhoneticExtensions(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.PhoneticExtensions).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PrivateUse()
        {
            return Characters.UnicodeBlock(UnicodeBlock.PrivateUse);
        }

        public static Quantifier PrivateUse(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.PrivateUse).Count(exactCount);
        }

        public static Quantifier PrivateUse(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.PrivateUse).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPrivateUse()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.PrivateUse);
        }

        public static Quantifier NotPrivateUse(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.PrivateUse).Count(exactCount);
        }

        public static Quantifier NotPrivateUse(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.PrivateUse).Count(minCount, maxCount);
        }

        public static QuantifiableExpression PrivateUseArea()
        {
            return Characters.UnicodeBlock(UnicodeBlock.PrivateUseArea);
        }

        public static Quantifier PrivateUseArea(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.PrivateUseArea).Count(exactCount);
        }

        public static Quantifier PrivateUseArea(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.PrivateUseArea).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotPrivateUseArea()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.PrivateUseArea);
        }

        public static Quantifier NotPrivateUseArea(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.PrivateUseArea).Count(exactCount);
        }

        public static Quantifier NotPrivateUseArea(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.PrivateUseArea).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Runic()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Runic);
        }

        public static Quantifier Runic(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Runic).Count(exactCount);
        }

        public static Quantifier Runic(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Runic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotRunic()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Runic);
        }

        public static Quantifier NotRunic(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Runic).Count(exactCount);
        }

        public static Quantifier NotRunic(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Runic).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Sinhala()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Sinhala);
        }

        public static Quantifier Sinhala(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Sinhala).Count(exactCount);
        }

        public static Quantifier Sinhala(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Sinhala).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSinhala()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Sinhala);
        }

        public static Quantifier NotSinhala(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Sinhala).Count(exactCount);
        }

        public static Quantifier NotSinhala(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Sinhala).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SmallFormVariants()
        {
            return Characters.UnicodeBlock(UnicodeBlock.SmallFormVariants);
        }

        public static Quantifier SmallFormVariants(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.SmallFormVariants).Count(exactCount);
        }

        public static Quantifier SmallFormVariants(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.SmallFormVariants).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSmallFormVariants()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SmallFormVariants);
        }

        public static Quantifier NotSmallFormVariants(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SmallFormVariants).Count(exactCount);
        }

        public static Quantifier NotSmallFormVariants(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SmallFormVariants).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SpacingModifierLetters()
        {
            return Characters.UnicodeBlock(UnicodeBlock.SpacingModifierLetters);
        }

        public static Quantifier SpacingModifierLetters(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.SpacingModifierLetters).Count(exactCount);
        }

        public static Quantifier SpacingModifierLetters(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.SpacingModifierLetters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSpacingModifierLetters()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SpacingModifierLetters);
        }

        public static Quantifier NotSpacingModifierLetters(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SpacingModifierLetters).Count(exactCount);
        }

        public static Quantifier NotSpacingModifierLetters(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SpacingModifierLetters).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Specials()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Specials);
        }

        public static Quantifier Specials(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Specials).Count(exactCount);
        }

        public static Quantifier Specials(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Specials).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSpecials()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Specials);
        }

        public static Quantifier NotSpecials(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Specials).Count(exactCount);
        }

        public static Quantifier NotSpecials(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Specials).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SuperscriptsAndSubscripts()
        {
            return Characters.UnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts);
        }

        public static Quantifier SuperscriptsAndSubscripts(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts).Count(exactCount);
        }

        public static Quantifier SuperscriptsAndSubscripts(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSuperscriptsAndSubscripts()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts);
        }

        public static Quantifier NotSuperscriptsAndSubscripts(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts).Count(exactCount);
        }

        public static Quantifier NotSuperscriptsAndSubscripts(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SuperscriptsAndSubscripts).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SupplementalArrowsA()
        {
            return Characters.UnicodeBlock(UnicodeBlock.SupplementalArrowsA);
        }

        public static Quantifier SupplementalArrowsA(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.SupplementalArrowsA).Count(exactCount);
        }

        public static Quantifier SupplementalArrowsA(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.SupplementalArrowsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSupplementalArrowsA()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsA);
        }

        public static Quantifier NotSupplementalArrowsA(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsA).Count(exactCount);
        }

        public static Quantifier NotSupplementalArrowsA(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsA).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SupplementalArrowsB()
        {
            return Characters.UnicodeBlock(UnicodeBlock.SupplementalArrowsB);
        }

        public static Quantifier SupplementalArrowsB(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.SupplementalArrowsB).Count(exactCount);
        }

        public static Quantifier SupplementalArrowsB(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.SupplementalArrowsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSupplementalArrowsB()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsB);
        }

        public static Quantifier NotSupplementalArrowsB(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsB).Count(exactCount);
        }

        public static Quantifier NotSupplementalArrowsB(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SupplementalArrowsB).Count(minCount, maxCount);
        }

        public static QuantifiableExpression SupplementalMathematicalOperators()
        {
            return Characters.UnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators);
        }

        public static Quantifier SupplementalMathematicalOperators(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators).Count(exactCount);
        }

        public static Quantifier SupplementalMathematicalOperators(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSupplementalMathematicalOperators()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators);
        }

        public static Quantifier NotSupplementalMathematicalOperators(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators).Count(exactCount);
        }

        public static Quantifier NotSupplementalMathematicalOperators(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.SupplementalMathematicalOperators).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Syriac()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Syriac);
        }

        public static Quantifier Syriac(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Syriac).Count(exactCount);
        }

        public static Quantifier Syriac(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Syriac).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotSyriac()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Syriac);
        }

        public static Quantifier NotSyriac(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Syriac).Count(exactCount);
        }

        public static Quantifier NotSyriac(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Syriac).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tagalog()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Tagalog);
        }

        public static Quantifier Tagalog(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Tagalog).Count(exactCount);
        }

        public static Quantifier Tagalog(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Tagalog).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTagalog()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Tagalog);
        }

        public static Quantifier NotTagalog(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Tagalog).Count(exactCount);
        }

        public static Quantifier NotTagalog(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Tagalog).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tagbanwa()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Tagbanwa);
        }

        public static Quantifier Tagbanwa(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Tagbanwa).Count(exactCount);
        }

        public static Quantifier Tagbanwa(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Tagbanwa).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTagbanwa()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Tagbanwa);
        }

        public static Quantifier NotTagbanwa(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Tagbanwa).Count(exactCount);
        }

        public static Quantifier NotTagbanwa(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Tagbanwa).Count(minCount, maxCount);
        }

        public static QuantifiableExpression TaiLe()
        {
            return Characters.UnicodeBlock(UnicodeBlock.TaiLe);
        }

        public static Quantifier TaiLe(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.TaiLe).Count(exactCount);
        }

        public static Quantifier TaiLe(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.TaiLe).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTaiLe()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.TaiLe);
        }

        public static Quantifier NotTaiLe(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.TaiLe).Count(exactCount);
        }

        public static Quantifier NotTaiLe(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.TaiLe).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tamil()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Tamil);
        }

        public static Quantifier Tamil(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Tamil).Count(exactCount);
        }

        public static Quantifier Tamil(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Tamil).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTamil()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Tamil);
        }

        public static Quantifier NotTamil(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Tamil).Count(exactCount);
        }

        public static Quantifier NotTamil(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Tamil).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Telugu()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Telugu);
        }

        public static Quantifier Telugu(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Telugu).Count(exactCount);
        }

        public static Quantifier Telugu(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Telugu).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTelugu()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Telugu);
        }

        public static Quantifier NotTelugu(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Telugu).Count(exactCount);
        }

        public static Quantifier NotTelugu(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Telugu).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Thaana()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Thaana);
        }

        public static Quantifier Thaana(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Thaana).Count(exactCount);
        }

        public static Quantifier Thaana(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Thaana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotThaana()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Thaana);
        }

        public static Quantifier NotThaana(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Thaana).Count(exactCount);
        }

        public static Quantifier NotThaana(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Thaana).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Thai()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Thai);
        }

        public static Quantifier Thai(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Thai).Count(exactCount);
        }

        public static Quantifier Thai(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Thai).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotThai()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Thai);
        }

        public static Quantifier NotThai(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Thai).Count(exactCount);
        }

        public static Quantifier NotThai(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Thai).Count(minCount, maxCount);
        }

        public static QuantifiableExpression Tibetan()
        {
            return Characters.UnicodeBlock(UnicodeBlock.Tibetan);
        }

        public static Quantifier Tibetan(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Tibetan).Count(exactCount);
        }

        public static Quantifier Tibetan(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.Tibetan).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotTibetan()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Tibetan);
        }

        public static Quantifier NotTibetan(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Tibetan).Count(exactCount);
        }

        public static Quantifier NotTibetan(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.Tibetan).Count(minCount, maxCount);
        }

        public static QuantifiableExpression UnifiedCanadianAboriginalSyllabics()
        {
            return Characters.UnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics);
        }

        public static Quantifier UnifiedCanadianAboriginalSyllabics(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics).Count(exactCount);
        }

        public static Quantifier UnifiedCanadianAboriginalSyllabics(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotUnifiedCanadianAboriginalSyllabics()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics);
        }

        public static Quantifier NotUnifiedCanadianAboriginalSyllabics(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics).Count(exactCount);
        }

        public static Quantifier NotUnifiedCanadianAboriginalSyllabics(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.UnifiedCanadianAboriginalSyllabics).Count(minCount, maxCount);
        }

        public static QuantifiableExpression VariationSelectors()
        {
            return Characters.UnicodeBlock(UnicodeBlock.VariationSelectors);
        }

        public static Quantifier VariationSelectors(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.VariationSelectors).Count(exactCount);
        }

        public static Quantifier VariationSelectors(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.VariationSelectors).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotVariationSelectors()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.VariationSelectors);
        }

        public static Quantifier NotVariationSelectors(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.VariationSelectors).Count(exactCount);
        }

        public static Quantifier NotVariationSelectors(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.VariationSelectors).Count(minCount, maxCount);
        }

        public static QuantifiableExpression YijingHexagramSymbols()
        {
            return Characters.UnicodeBlock(UnicodeBlock.YijingHexagramSymbols);
        }

        public static Quantifier YijingHexagramSymbols(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.YijingHexagramSymbols).Count(exactCount);
        }

        public static Quantifier YijingHexagramSymbols(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.YijingHexagramSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotYijingHexagramSymbols()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.YijingHexagramSymbols);
        }

        public static Quantifier NotYijingHexagramSymbols(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.YijingHexagramSymbols).Count(exactCount);
        }

        public static Quantifier NotYijingHexagramSymbols(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.YijingHexagramSymbols).Count(minCount, maxCount);
        }

        public static QuantifiableExpression YiRadicals()
        {
            return Characters.UnicodeBlock(UnicodeBlock.YiRadicals);
        }

        public static Quantifier YiRadicals(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.YiRadicals).Count(exactCount);
        }

        public static Quantifier YiRadicals(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.YiRadicals).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotYiRadicals()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.YiRadicals);
        }

        public static Quantifier NotYiRadicals(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.YiRadicals).Count(exactCount);
        }

        public static Quantifier NotYiRadicals(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.YiRadicals).Count(minCount, maxCount);
        }

        public static QuantifiableExpression YiSyllables()
        {
            return Characters.UnicodeBlock(UnicodeBlock.YiSyllables);
        }

        public static Quantifier YiSyllables(int exactCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.YiSyllables).Count(exactCount);
        }

        public static Quantifier YiSyllables(int minCount, int maxCount)
        {
            return Characters.UnicodeBlock(UnicodeBlock.YiSyllables).Count(minCount, maxCount);
        }

        public static QuantifiableExpression NotYiSyllables()
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.YiSyllables);
        }

        public static Quantifier NotYiSyllables(int exactCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.YiSyllables).Count(exactCount);
        }

        public static Quantifier NotYiSyllables(int minCount, int maxCount)
        {
            return Characters.NotUnicodeBlock(UnicodeBlock.YiSyllables).Count(minCount, maxCount);
        }
    }
}
