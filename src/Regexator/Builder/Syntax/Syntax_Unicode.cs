// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Syntax
    {
        internal const string UnicodeStart = @"\p{";
        internal const string NotUnicodeStart = @"\P{";
        internal const string HexUnicodeStart = @"\u";
        internal const string UnicodeEnd = "}";

        public static string Unicode(char value)
        {
            return UnicodeInternal((int)value);
        }

        public static string Unicode(int charCode)
        {
            if (charCode < 0 || charCode > 0xFFFF) { throw new OverflowException(); }
            return UnicodeInternal(charCode);
        }

        internal static string UnicodeInternal(int charCode)
        {
            return HexUnicodeStart + charCode.ToString("X4", CultureInfo.InvariantCulture);
        }

        public static string UnicodeBlock(UnicodeBlock block)
        {
            return UnicodeBlock(block, false);
        }

        public static string NotUnicodeBlock(UnicodeBlock block)
        {
            return UnicodeBlock(block, true);
        }

        public static string UnicodeBlock(UnicodeBlock block, bool negative)
        {
            return (negative ? NotUnicodeStart : UnicodeStart) + GetUnicodeBlockValue(block) + UnicodeEnd;
        }

        public static string UnicodeBlocks(params UnicodeBlock[] blocks)
        {
            return UnicodeBlocks(false, blocks);
        }

        public static string UnicodeBlocks(bool negative, params UnicodeBlock[] blocks)
        {
            if (blocks == null) { throw new ArgumentNullException("blocks"); }
            return string.Concat(blocks.Select(f => UnicodeBlock(f, negative)));
        }

        public static string UnicodeCategory(UnicodeCategory category)
        {
            return UnicodeCategory(category, false);
        }

        public static string NotUnicodeCategory(UnicodeCategory category)
        {
            return UnicodeCategory(category, true);
        }

        public static string UnicodeCategory(UnicodeCategory category, bool negative)
        {
            return (negative ? NotUnicodeStart : UnicodeStart) + GetUnicodeCategoryValue(category) + UnicodeEnd;
        }

        public static string UnicodeCategories(params UnicodeCategory[] categories)
        {
            return UnicodeCategories(false, categories);
        }

        public static string UnicodeCategories(bool negative, params UnicodeCategory[] categories)
        {
            if (categories == null) { throw new ArgumentNullException("categories"); }
            return string.Concat(categories.Select(f => UnicodeCategory(f, negative)));
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public static string GetUnicodeCategoryValue(UnicodeCategory category)
        {
            switch (category)
            {
                case Builder.UnicodeCategory.AllControlCharacters:
                    return "C";
                case Builder.UnicodeCategory.AllDiacriticMarks:
                    return "M";
                case Builder.UnicodeCategory.AllLetterCharacters:
                    return "L";
                case Builder.UnicodeCategory.AllNumbers:
                    return "N";
                case Builder.UnicodeCategory.AllPunctuationCharacters:
                    return "P";
                case Builder.UnicodeCategory.AllSeparatorCharacters:
                    return "Z";
                case Builder.UnicodeCategory.AllSymbols:
                    return "S";
                case Builder.UnicodeCategory.LetterLowercase:
                    return "Ll";
                case Builder.UnicodeCategory.LetterModifier:
                    return "Lm";
                case Builder.UnicodeCategory.LetterOther:
                    return "Lo";
                case Builder.UnicodeCategory.LetterTitlecase:
                    return "Lt";
                case Builder.UnicodeCategory.LetterUppercase:
                    return "Lu";
                case Builder.UnicodeCategory.MarkEnclosing:
                    return "Me";
                case Builder.UnicodeCategory.MarkNonspacing:
                    return "Mn";
                case Builder.UnicodeCategory.MarkSpacingCombining:
                    return "Mc";
                case Builder.UnicodeCategory.NumberDecimalDigit:
                    return "Nd";
                case Builder.UnicodeCategory.NumberLetter:
                    return "Nl";
                case Builder.UnicodeCategory.NumberOther:
                    return "No";
                case Builder.UnicodeCategory.OtherControl:
                    return "Cc";
                case Builder.UnicodeCategory.OtherFormat:
                    return "Cf";
                case Builder.UnicodeCategory.OtherNotAssigned:
                    return "Cn";
                case Builder.UnicodeCategory.OtherPrivateUse:
                    return "Co";
                case Builder.UnicodeCategory.OtherSurrogate:
                    return "Cs";
                case Builder.UnicodeCategory.PunctuationClose:
                    return "Pe";
                case Builder.UnicodeCategory.PunctuationConnector:
                    return "Pc";
                case Builder.UnicodeCategory.PunctuationDash:
                    return "Pd";
                case Builder.UnicodeCategory.PunctuationFinalQuote:
                    return "Pf";
                case Builder.UnicodeCategory.PunctuationInitialQuote:
                    return "Pi";
                case Builder.UnicodeCategory.PunctuationOpen:
                    return "Ps";
                case Builder.UnicodeCategory.PunctuationOther:
                    return "Po";
                case Builder.UnicodeCategory.SeparatorLine:
                    return "Zl";
                case Builder.UnicodeCategory.SeparatorParagraph:
                    return "Zp";
                case Builder.UnicodeCategory.SeparatorSpace:
                    return "Zs";
                case Builder.UnicodeCategory.SymbolCurrency:
                    return "Sc";
                case Builder.UnicodeCategory.SymbolMath:
                    return "Sm";
                case Builder.UnicodeCategory.SymbolModifier:
                    return "Sk";
                case Builder.UnicodeCategory.SymbolOther:
                    return "So";
                default:
                    Debug.Assert(false);
                    return string.Empty;
            }
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public static string GetUnicodeBlockValue(UnicodeBlock block)
        {
            switch (block)
            {
                case Builder.UnicodeBlock.AlphabeticPresentationForms:
                    return "IsAlphabeticPresentationForms";
                case Builder.UnicodeBlock.Arabic:
                    return "IsArabic";
                case Builder.UnicodeBlock.ArabicPresentationFormsA:
                    return "IsArabicPresentationForms-A";
                case Builder.UnicodeBlock.ArabicPresentationFormsB:
                    return "IsArabicPresentationForms-B";
                case Builder.UnicodeBlock.Armenian:
                    return "IsArmenian";
                case Builder.UnicodeBlock.Arrows:
                    return "IsArrows";
                case Builder.UnicodeBlock.BasicLatin:
                    return "IsBasicLatin";
                case Builder.UnicodeBlock.Bengali:
                    return "IsBengali";
                case Builder.UnicodeBlock.BlockElements:
                    return "IsBlockElements";
                case Builder.UnicodeBlock.Bopomofo:
                    return "IsBopomofo";
                case Builder.UnicodeBlock.BopomofoExtended:
                    return "IsBopomofoExtended";
                case Builder.UnicodeBlock.BoxDrawing:
                    return "IsBoxDrawing";
                case Builder.UnicodeBlock.BraillePatterns:
                    return "IsBraillePatterns";
                case Builder.UnicodeBlock.Buhid:
                    return "IsBuhid";
                case Builder.UnicodeBlock.CJKCompatibility:
                    return "IsCJKCompatibility";
                case Builder.UnicodeBlock.CJKCompatibilityForms:
                    return "IsCJKCompatibilityForms";
                case Builder.UnicodeBlock.CJKCompatibilityIdeographs:
                    return "IsCJKCompatibilityIdeographs";
                case Builder.UnicodeBlock.CJKRadicalsSupplement:
                    return "IsCJKRadicalsSupplement";
                case Builder.UnicodeBlock.CJKSymbolsAndPunctuation:
                    return "IsCJKSymbolsandPunctuation";
                case Builder.UnicodeBlock.CJKUnifiedIdeographs:
                    return "IsCJKUnifiedIdeographs";
                case Builder.UnicodeBlock.CJKUnifiedIdeographsExtensionA:
                    return "IsCJKUnifiedIdeographsExtensionA";
                case Builder.UnicodeBlock.CombiningDiacriticalMarks:
                    return "IsCombiningDiacriticalMarks";
                case Builder.UnicodeBlock.CombiningDiacriticalMarksForSymbols:
                    return "IsCombiningDiacriticalMarksforSymbols";
                case Builder.UnicodeBlock.CombiningHalfMarks:
                    return "IsCombiningHalfMarks";
                case Builder.UnicodeBlock.CombiningMarksForSymbols:
                    return "IsCombiningMarksforSymbols";
                case Builder.UnicodeBlock.ControlPictures:
                    return "IsControlPictures";
                case Builder.UnicodeBlock.CurrencySymbols:
                    return "IsCurrencySymbols";
                case Builder.UnicodeBlock.Cyrillic:
                    return "IsCyrillic";
                case Builder.UnicodeBlock.CyrillicSupplement:
                    return "IsCyrillicSupplement";
                case Builder.UnicodeBlock.Devanagari:
                    return "IsDevanagari";
                case Builder.UnicodeBlock.Dingbats:
                    return "IsDingbats";
                case Builder.UnicodeBlock.EnclosedAlphanumerics:
                    return "IsEnclosedAlphanumerics";
                case Builder.UnicodeBlock.EnclosedCJKLettersAndMonths:
                    return "IsEnclosedCJKLettersandMonths";
                case Builder.UnicodeBlock.Ethiopic:
                    return "IsEthiopic";
                case Builder.UnicodeBlock.GeneralPunctuation:
                    return "IsGeneralPunctuation";
                case Builder.UnicodeBlock.GeometricShapes:
                    return "IsGeometricShapes";
                case Builder.UnicodeBlock.Georgian:
                    return "IsGeorgian";
                case Builder.UnicodeBlock.Greek:
                    return "IsGreek";
                case Builder.UnicodeBlock.GreekAndCoptic:
                    return "IsGreekandCoptic";
                case Builder.UnicodeBlock.GreekExtended:
                    return "IsGreekExtended";
                case Builder.UnicodeBlock.Gujarati:
                    return "IsGujarati";
                case Builder.UnicodeBlock.Gurmukhi:
                    return "IsGurmukhi";
                case Builder.UnicodeBlock.HalfWidthAndFullWidthForms:
                    return "IsHalfwidthandFullwidthForms";
                case Builder.UnicodeBlock.HangulCompatibilityJamo:
                    return "IsHangulCompatibilityJamo";
                case Builder.UnicodeBlock.HangulJamo:
                    return "IsHangulJamo";
                case Builder.UnicodeBlock.HangulSyllables:
                    return "IsHangulSyllables";
                case Builder.UnicodeBlock.Hanunoo:
                    return "IsHanunoo";
                case Builder.UnicodeBlock.Hebrew:
                    return "IsHebrew";
                case Builder.UnicodeBlock.HighPrivateUseSurrogates:
                    return "IsHighPrivateUseSurrogates";
                case Builder.UnicodeBlock.HighSurrogates:
                    return "IsHighSurrogates";
                case Builder.UnicodeBlock.Hiragana:
                    return "IsHiragana";
                case Builder.UnicodeBlock.Cherokee:
                    return "IsCherokee";
                case Builder.UnicodeBlock.IdeographicDescriptionCharacters:
                    return "IsIdeographicDescriptionCharacters";
                case Builder.UnicodeBlock.IPAExtensions:
                    return "IsIPAExtensions";
                case Builder.UnicodeBlock.Kanbun:
                    return "IsKanbun";
                case Builder.UnicodeBlock.KangxiRadicals:
                    return "IsKangxiRadicals";
                case Builder.UnicodeBlock.Kannada:
                    return "IsKannada";
                case Builder.UnicodeBlock.Katakana:
                    return "IsKatakana";
                case Builder.UnicodeBlock.KatakanaPhoneticExtensions:
                    return "IsKatakanaPhoneticExtensions";
                case Builder.UnicodeBlock.Khmer:
                    return "IsKhmer";
                case Builder.UnicodeBlock.KhmerSymbols:
                    return "IsKhmerSymbols";
                case Builder.UnicodeBlock.Lao:
                    return "IsLao";
                case Builder.UnicodeBlock.Latin1Supplement:
                    return "IsLatin-1Supplement";
                case Builder.UnicodeBlock.LatinExtendedA:
                    return "IsLatinExtended-A";
                case Builder.UnicodeBlock.LatinExtendedAdditional:
                    return "IsLatinExtendedAdditional";
                case Builder.UnicodeBlock.LatinExtendedB:
                    return "IsLatinExtended-B";
                case Builder.UnicodeBlock.LetterLikeSymbols:
                    return "IsLetterlikeSymbols";
                case Builder.UnicodeBlock.Limbu:
                    return "IsLimbu";
                case Builder.UnicodeBlock.LowSurrogates:
                    return "IsLowSurrogates";
                case Builder.UnicodeBlock.Malayalam:
                    return "IsMalayalam";
                case Builder.UnicodeBlock.MathematicalOperators:
                    return "IsMathematicalOperators";
                case Builder.UnicodeBlock.MiscellaneousMathematicalSymbolsA:
                    return "IsMiscellaneousMathematicalSymbols-A";
                case Builder.UnicodeBlock.MiscellaneousMathematicalSymbolsB:
                    return "IsMiscellaneousMathematicalSymbols-B";
                case Builder.UnicodeBlock.MiscellaneousSymbols:
                    return "IsMiscellaneousSymbols";
                case Builder.UnicodeBlock.MiscellaneousSymbolsAndArrows:
                    return "IsMiscellaneousSymbolsandArrows";
                case Builder.UnicodeBlock.MiscellaneousTechnical:
                    return "IsMiscellaneousTechnical";
                case Builder.UnicodeBlock.Mongolian:
                    return "IsMongolian";
                case Builder.UnicodeBlock.Myanmar:
                    return "IsMyanmar";
                case Builder.UnicodeBlock.NumberForms:
                    return "IsNumberForms";
                case Builder.UnicodeBlock.Ogham:
                    return "IsOgham";
                case Builder.UnicodeBlock.OpticalCharacterRecognition:
                    return "IsOpticalCharacterRecognition";
                case Builder.UnicodeBlock.Oriya:
                    return "IsOriya";
                case Builder.UnicodeBlock.PhoneticExtensions:
                    return "IsPhoneticExtensions";
                case Builder.UnicodeBlock.PrivateUse:
                    return "IsPrivateUse";
                case Builder.UnicodeBlock.PrivateUseArea:
                    return "IsPrivateUseArea";
                case Builder.UnicodeBlock.Runic:
                    return "IsRunic";
                case Builder.UnicodeBlock.Sinhala:
                    return "IsSinhala";
                case Builder.UnicodeBlock.SmallFormVariants:
                    return "IsSmallFormVariants";
                case Builder.UnicodeBlock.SpacingModifierLetters:
                    return "IsSpacingModifierLetters";
                case Builder.UnicodeBlock.Specials:
                    return "IsSpecials";
                case Builder.UnicodeBlock.SuperscriptsAndSubscripts:
                    return "IsSuperscriptsandSubscripts";
                case Builder.UnicodeBlock.SupplementalArrowsA:
                    return "IsSupplementalArrows-A";
                case Builder.UnicodeBlock.SupplementalArrowsB:
                    return "IsSupplementalArrows-B";
                case Builder.UnicodeBlock.SupplementalMathematicalOperators:
                    return "IsSupplementalMathematicalOperators";
                case Builder.UnicodeBlock.Syriac:
                    return "IsSyriac";
                case Builder.UnicodeBlock.Tagalog:
                    return "IsTagalog";
                case Builder.UnicodeBlock.Tagbanwa:
                    return "IsTagbanwa";
                case Builder.UnicodeBlock.TaiLe:
                    return "IsTaiLe";
                case Builder.UnicodeBlock.Tamil:
                    return "IsTamil";
                case Builder.UnicodeBlock.Telugu:
                    return "IsTelugu";
                case Builder.UnicodeBlock.Thaana:
                    return "IsThaana";
                case Builder.UnicodeBlock.Thai:
                    return "IsThai";
                case Builder.UnicodeBlock.Tibetan:
                    return "IsTibetan";
                case Builder.UnicodeBlock.UnifiedCanadianAboriginalSyllabics:
                    return "IsUnifiedCanadianAboriginalSyllabics";
                case Builder.UnicodeBlock.VariationSelectors:
                    return "IsVariationSelectors";
                case Builder.UnicodeBlock.YijingHexagramSymbols:
                    return "IsYijingHexagramSymbols";
                case Builder.UnicodeBlock.YiRadicals:
                    return "IsYiRadicals";
                case Builder.UnicodeBlock.YiSyllables:
                    return "IsYiSyllables";
                default:
                    Debug.Assert(false);
                    return string.Empty;
            }
        }
    }
}