// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.ComponentModel;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public enum NamedBlock
    {
        ///<summary>Code point range FB00 - FB4F</summary>
        [Description("FB00 - FB4F")]
        AlphabeticPresentationForms,

        ///<summary>Code point range 0600 - 06FF</summary>
        [Description("0600 - 06FF")]
        Arabic,

        ///<summary>Code point range FB50 - FDFF</summary>
        [Description("FB50 - FDFF")]
        ArabicPresentationFormsA,

        ///<summary>Code point range FE70 - FEFF</summary>
        [Description("FE70 - FEFF")]
        ArabicPresentationFormsB,

        ///<summary>Code point range 0530 - 058F</summary>
        [Description("0530 - 058F")]
        Armenian,

        ///<summary>Code point range 2190 - 21FF</summary>
        [Description("2190 - 21FF")]
        Arrows,

        ///<summary>Code point range 0000 - 007F</summary>
        [Description("0000 - 007F")]
        BasicLatin,

        ///<summary>Code point range 0980 - 09FF</summary>
        [Description("0980 - 09FF")]
        Bengali,

        ///<summary>Code point range 2580 - 259F</summary>
        [Description("2580 - 259F")]
        BlockElements,

        ///<summary>Code point range 3100 - 312F</summary>
        [Description("3100 - 312F")]
        Bopomofo,

        ///<summary>Code point range 31A0 - 31BF</summary>
        [Description("31A0 - 31BF")]
        BopomofoExtended,

        ///<summary>Code point range 2500 - 257F</summary>
        [Description("2500 - 257F")]
        BoxDrawing,

        ///<summary>Code point range 2800 - 28FF</summary>
        [Description("2800 - 28FF")]
        BraillePatterns,

        ///<summary>Code point range 1740 - 175F</summary>
        [Description("1740 - 175F")]
        Buhid,

        ///<summary>Code point range 3300 - 33FF</summary>
        [Description("3300 - 33FF")]
        CJKCompatibility,

        ///<summary>Code point range FE30 - FE4F</summary>
        [Description("FE30 - FE4F")]
        CJKCompatibilityForms,

        ///<summary>Code point range F900 - FAFF</summary>
        [Description("F900 - FAFF")]
        CJKCompatibilityIdeographs,

        ///<summary>Code point range 2E80 - 2EFF</summary>
        [Description("2E80 - 2EFF")]
        CJKRadicalsSupplement,

        ///<summary>Code point range 3000 - 303F</summary>
        [Description("3000 - 303F")]
        CJKSymbolsAndPunctuation,

        ///<summary>Code point range 4E00 - 9FFF</summary>
        [Description("4E00 - 9FFF")]
        CJKUnifiedIdeographs,

        ///<summary>Code point range 3400 - 4DBF</summary>
        [Description("3400 - 4DBF")]
        CJKUnifiedIdeographsExtensionA,

        ///<summary>Code point range 0300 - 036F</summary>
        [Description("0300 - 036F")]
        CombiningDiacriticalMarks,

        ///<summary>Code point range 20D0 - 20FF</summary>
        [Description("20D0 - 20FF")]
        CombiningDiacriticalMarksForSymbols,

        ///<summary>Code point range FE20 - FE2F</summary>
        [Description("FE20 - FE2F")]
        CombiningHalfMarks,

        ///<summary>Code point range 20D0 - 20FF</summary>
        [Description("20D0 - 20FF")]
        CombiningMarksForSymbols,

        ///<summary>Code point range 2400 - 243F</summary>
        [Description("2400 - 243F")]
        ControlPictures,

        ///<summary>Code point range 20A0 - 20CF</summary>
        [Description("20A0 - 20CF")]
        CurrencySymbols,

        ///<summary>Code point range 0400 - 04FF</summary>
        [Description("0400 - 04FF")]
        Cyrillic,

        ///<summary>Code point range 0500 - 052F</summary>
        [Description("0500 - 052F")]
        CyrillicSupplement,

        ///<summary>Code point range 0900 - 097F</summary>
        [Description("0900 - 097F")]
        Devanagari,

        ///<summary>Code point range 2700 - 27BF</summary>
        [Description("2700 - 27BF")]
        Dingbats,

        ///<summary>Code point range 2460 - 24FF</summary>
        [Description("2460 - 24FF")]
        EnclosedAlphanumerics,

        ///<summary>Code point range 3200 - 32FF</summary>
        [Description("3200 - 32FF")]
        EnclosedCJKLettersAndMonths,

        ///<summary>Code point range 1200 - 137F</summary>
        [Description("1200 - 137F")]
        Ethiopic,

        ///<summary>Code point range 2000 - 206F</summary>
        [Description("2000 - 206F")]
        GeneralPunctuation,

        ///<summary>Code point range 25A0 - 25FF</summary>
        [Description("25A0 - 25FF")]
        GeometricShapes,

        ///<summary>Code point range 10A0 - 10FF</summary>
        [Description("10A0 - 10FF")]
        Georgian,

        ///<summary>Code point range 0370 - 03FF</summary>
        [Description("0370 - 03FF")]
        Greek,

        ///<summary>Code point range 0370 - 03FF</summary>
        [Description("0370 - 03FF")]
        GreekAndCoptic,

        ///<summary>Code point range 1F00 - 1FFF</summary>
        [Description("1F00 - 1FFF")]
        GreekExtended,

        ///<summary>Code point range 0A80 - 0AFF</summary>
        [Description("0A80 - 0AFF")]
        Gujarati,

        ///<summary>Code point range 0A00 - 0A7F</summary>
        [Description("0A00 - 0A7F")]
        Gurmukhi,

        ///<summary>Code point range FF00 - FFEF</summary>
        [Description("FF00 - FFEF")]
        HalfWidthAndFullWidthForms,

        ///<summary>Code point range 3130 - 318F</summary>
        [Description("3130 - 318F")]
        HangulCompatibilityJamo,

        ///<summary>Code point range 1100 - 11FF</summary>
        [Description("1100 - 11FF")]
        HangulJamo,

        ///<summary>Code point range AC00 - D7AF</summary>
        [Description("AC00 - D7AF")]
        HangulSyllables,

        ///<summary>Code point range 1720 - 173F</summary>
        [Description("1720 - 173F")]
        Hanunoo,

        ///<summary>Code point range 0590 - 05FF</summary>
        [Description("0590 - 05FF")]
        Hebrew,

        ///<summary>Code point range DB80 - DBFF</summary>
        [Description("DB80 - DBFF")]
        HighPrivateUseSurrogates,

        ///<summary>Code point range D800 - DB7F</summary>
        [Description("D800 - DB7F")]
        HighSurrogates,

        ///<summary>Code point range 3040 - 309F</summary>
        [Description("3040 - 309F")]
        Hiragana,

        ///<summary>Code point range 13A0 - 13FF</summary>
        [Description("13A0 - 13FF")]
        Cherokee,

        ///<summary>Code point range 2FF0 - 2FFF</summary>
        [Description("2FF0 - 2FFF")]
        IdeographicDescriptionCharacters,

        ///<summary>Code point range 0250 - 02AF</summary>
        [Description("0250 - 02AF")]
        IPAExtensions,

        ///<summary>Code point range 3190 - 319F</summary>
        [Description("3190 - 319F")]
        Kanbun,

        ///<summary>Code point range 2F00 - 2FDF</summary>
        [Description("2F00 - 2FDF")]
        KangxiRadicals,

        ///<summary>Code point range 0C80 - 0CFF</summary>
        [Description("0C80 - 0CFF")]
        Kannada,

        ///<summary>Code point range 30A0 - 30FF</summary>
        [Description("30A0 - 30FF")]
        Katakana,

        ///<summary>Code point range 31F0 - 31FF</summary>
        [Description("31F0 - 31FF")]
        KatakanaPhoneticExtensions,

        ///<summary>Code point range 1780 - 17FF</summary>
        [Description("1780 - 17FF")]
        Khmer,

        ///<summary>Code point range 19E0 - 19FF</summary>
        [Description("19E0 - 19FF")]
        KhmerSymbols,

        ///<summary>Code point range 0E80 - 0EFF</summary>
        [Description("0E80 - 0EFF")]
        Lao,

        ///<summary>Code point range 0080 - 00FF</summary>
        [Description("0080 - 00FF")]
        Latin1Supplement,

        ///<summary>Code point range 0100 - 017F</summary>
        [Description("0100 - 017F")]
        LatinExtendedA,

        ///<summary>Code point range 1E00 - 1EFF</summary>
        [Description("1E00 - 1EFF")]
        LatinExtendedAdditional,

        ///<summary>Code point range 0180 - 024F</summary>
        [Description("0180 - 024F")]
        LatinExtendedB,

        ///<summary>Code point range 2100 - 214F</summary>
        [Description("2100 - 214F")]
        LetterLikeSymbols,

        ///<summary>Code point range 1900 - 194F</summary>
        [Description("1900 - 194F")]
        Limbu,

        ///<summary>Code point range DC00 - DFFF</summary>
        [Description("DC00 - DFFF")]
        LowSurrogates,

        ///<summary>Code point range 0D00 - 0D7F</summary>
        [Description("0D00 - 0D7F")]
        Malayalam,

        ///<summary>Code point range 2200 - 22FF</summary>
        [Description("2200 - 22FF")]
        MathematicalOperators,

        ///<summary>Code point range 27C0 - 27EF</summary>
        [Description("27C0 - 27EF")]
        MiscellaneousMathematicalSymbolsA,

        ///<summary>Code point range 2980 - 29FF</summary>
        [Description("2980 - 29FF")]
        MiscellaneousMathematicalSymbolsB,

        ///<summary>Code point range 2600 - 26FF</summary>
        [Description("2600 - 26FF")]
        MiscellaneousSymbols,

        ///<summary>Code point range 2B00 - 2BFF</summary>
        [Description("2B00 - 2BFF")]
        MiscellaneousSymbolsAndArrows,

        ///<summary>Code point range 2300 - 23FF</summary>
        [Description("2300 - 23FF")]
        MiscellaneousTechnical,

        ///<summary>Code point range 1800 - 18AF</summary>
        [Description("1800 - 18AF")]
        Mongolian,

        ///<summary>Code point range 1000 - 109F</summary>
        [Description("1000 - 109F")]
        Myanmar,

        ///<summary>Code point range 2150 - 218F</summary>
        [Description("2150 - 218F")]
        NumberForms,

        ///<summary>Code point range 1680 - 169F</summary>
        [Description("1680 - 169F")]
        Ogham,

        ///<summary>Code point range 2440 - 245F</summary>
        [Description("2440 - 245F")]
        OpticalCharacterRecognition,

        ///<summary>Code point range 0B00 - 0B7F</summary>
        [Description("0B00 - 0B7F")]
        Oriya,

        ///<summary>Code point range 1D00 - 1D7F</summary>
        [Description("1D00 - 1D7F")]
        PhoneticExtensions,

        ///<summary>Code point range E000 - F8FF</summary>
        [Description("E000 - F8FF")]
        PrivateUse,

        ///<summary>Code point range E000 - F8FF</summary>
        [Description("E000 - F8FF")]
        PrivateUseArea,

        ///<summary>Code point range 16A0 - 16FF</summary>
        [Description("16A0 - 16FF")]
        Runic,

        ///<summary>Code point range 0D80 - 0DFF</summary>
        [Description("0D80 - 0DFF")]
        Sinhala,

        ///<summary>Code point range FE50 - FE6F</summary>
        [Description("FE50 - FE6F")]
        SmallFormVariants,

        ///<summary>Code point range 02B0 - 02FF</summary>
        [Description("02B0 - 02FF")]
        SpacingModifierLetters,

        ///<summary>Code point range FFF0 - FFFF</summary>
        [Description("FFF0 - FFFF")]
        Specials,

        ///<summary>Code point range 2070 - 209F</summary>
        [Description("2070 - 209F")]
        SuperscriptsAndSubscripts,

        ///<summary>Code point range 27F0 - 27FF</summary>
        [Description("27F0 - 27FF")]
        SupplementalArrowsA,

        ///<summary>Code point range 2900 - 297F</summary>
        [Description("2900 - 297F")]
        SupplementalArrowsB,

        ///<summary>Code point range 2A00 - 2AFF</summary>
        [Description("2A00 - 2AFF")]
        SupplementalMathematicalOperators,

        ///<summary>Code point range 0700 - 074F</summary>
        [Description("0700 - 074F")]
        Syriac,

        ///<summary>Code point range 1700 - 171F</summary>
        [Description("1700 - 171F")]
        Tagalog,

        ///<summary>Code point range 1760 - 177F</summary>
        [Description("1760 - 177F")]
        Tagbanwa,

        ///<summary>Code point range 1950 - 197F</summary>
        [Description("1950 - 197F")]
        TaiLe,

        ///<summary>Code point range 0B80 - 0BFF</summary>
        [Description("0B80 - 0BFF")]
        Tamil,

        ///<summary>Code point range 0C00 - 0C7F</summary>
        [Description("0C00 - 0C7F")]
        Telugu,

        ///<summary>Code point range 0780 - 07BF</summary>
        [Description("0780 - 07BF")]
        Thaana,

        ///<summary>Code point range 0E00 - 0E7F</summary>
        [Description("0E00 - 0E7F")]
        Thai,

        ///<summary>Code point range 0F00 - 0FFF</summary>
        [Description("0F00 - 0FFF")]
        Tibetan,

        ///<summary>Code point range 1400 - 167F</summary>
        [Description("1400 - 167F")]
        UnifiedCanadianAboriginalSyllabics,

        ///<summary>Code point range FE00 - FE0F</summary>
        [Description("FE00 - FE0F")]
        VariationSelectors,

        ///<summary>Code point range 4DC0 - 4DFF</summary>
        [Description("4DC0 - 4DFF")]
        YijingHexagramSymbols,

        ///<summary>Code point range A490 - A4CF</summary>
        [Description("A490 - A4CF")]
        YiRadicals,

        ///<summary>Code point range A000 - A48F</summary>
        [Description("A000 - A48F")]
        YiSyllables,
    }
}
