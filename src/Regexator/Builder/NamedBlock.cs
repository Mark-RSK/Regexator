// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public enum NamedBlock
    {
        ///<summary>Code point range FB00 - FB4F</summary>
        AlphabeticPresentationForms,
        ///<summary>Code point range 0600 - 06FF</summary>
        Arabic,
        ///<summary>Code point range FB50 - FDFF</summary>
        ArabicPresentationFormsA,
        ///<summary>Code point range FE70 - FEFF</summary>
        ArabicPresentationFormsB,
        ///<summary>Code point range 0530 - 058F</summary>
        Armenian,
        ///<summary>Code point range 2190 - 21FF</summary>
        Arrows,
        ///<summary>Code point range 0000 - 007F</summary>
        BasicLatin,
        ///<summary>Code point range 0980 - 09FF</summary>
        Bengali,
        ///<summary>Code point range 2580 - 259F</summary>
        BlockElements,
        ///<summary>Code point range 3100 - 312F</summary>
        Bopomofo,
        ///<summary>Code point range 31A0 - 31BF</summary>
        BopomofoExtended,
        ///<summary>Code point range 2500 - 257F</summary>
        BoxDrawing,
        ///<summary>Code point range 2800 - 28FF</summary>
        BraillePatterns,
        ///<summary>Code point range 1740 - 175F</summary>
        Buhid,
        ///<summary>Code point range 3300 - 33FF</summary>
        CJKCompatibility,
        ///<summary>Code point range FE30 - FE4F</summary>
        CJKCompatibilityForms,
        ///<summary>Code point range F900 - FAFF</summary>
        CJKCompatibilityIdeographs,
        ///<summary>Code point range 2E80 - 2EFF</summary>
        CJKRadicalsSupplement,
        ///<summary>Code point range 3000 - 303F</summary>
        CJKSymbolsAndPunctuation,
        ///<summary>Code point range 4E00 - 9FFF</summary>
        CJKUnifiedIdeographs,
        ///<summary>Code point range 3400 - 4DBF</summary>
        CJKUnifiedIdeographsExtensionA,
        ///<summary>Code point range 0300 - 036F</summary>
        CombiningDiacriticalMarks,
        ///<summary>Code point range 20D0 - 20FF</summary>
        CombiningDiacriticalMarksForSymbols,
        ///<summary>Code point range FE20 - FE2F</summary>
        CombiningHalfMarks,
        ///<summary>Code point range 20D0 - 20FF</summary>
        CombiningMarksForSymbols,
        ///<summary>Code point range 2400 - 243F</summary>
        ControlPictures,
        ///<summary>Code point range 20A0 - 20CF</summary>
        CurrencySymbols,
        ///<summary>Code point range 0400 - 04FF</summary>
        Cyrillic,
        ///<summary>Code point range 0500 - 052F</summary>
        CyrillicSupplement,
        ///<summary>Code point range 0900 - 097F</summary>
        Devanagari,
        ///<summary>Code point range 2700 - 27BF</summary>
        Dingbats,
        ///<summary>Code point range 2460 - 24FF</summary>
        EnclosedAlphanumerics,
        ///<summary>Code point range 3200 - 32FF</summary>
        EnclosedCJKLettersAndMonths,
        ///<summary>Code point range 1200 - 137F</summary>
        Ethiopic,
        ///<summary>Code point range 2000 - 206F</summary>
        GeneralPunctuation,
        ///<summary>Code point range 25A0 - 25FF</summary>
        GeometricShapes,
        ///<summary>Code point range 10A0 - 10FF</summary>
        Georgian,
        ///<summary>Code point range 0370 - 03FF</summary>
        Greek,
        ///<summary>Code point range 0370 - 03FF</summary>
        GreekAndCoptic,
        ///<summary>Code point range 1F00 - 1FFF</summary>
        GreekExtended,
        ///<summary>Code point range 0A80 - 0AFF</summary>
        Gujarati,
        ///<summary>Code point range 0A00 - 0A7F</summary>
        Gurmukhi,
        ///<summary>Code point range FF00 - FFEF</summary>
        HalfWidthAndFullWidthForms,
        ///<summary>Code point range 3130 - 318F</summary>
        HangulCompatibilityJamo,
        ///<summary>Code point range 1100 - 11FF</summary>
        HangulJamo,
        ///<summary>Code point range AC00 - D7AF</summary>
        HangulSyllables,
        ///<summary>Code point range 1720 - 173F</summary>
        Hanunoo,
        ///<summary>Code point range 0590 - 05FF</summary>
        Hebrew,
        ///<summary>Code point range DB80 - DBFF</summary>
        HighPrivateUseSurrogates,
        ///<summary>Code point range D800 - DB7F</summary>
        HighSurrogates,
        ///<summary>Code point range 3040 - 309F</summary>
        Hiragana,
        ///<summary>Code point range 13A0 - 13FF</summary>
        Cherokee,
        ///<summary>Code point range 2FF0 - 2FFF</summary>
        IdeographicDescriptionCharacters,
        ///<summary>Code point range 0250 - 02AF</summary>
        IPAExtensions,
        ///<summary>Code point range 3190 - 319F</summary>
        Kanbun,
        ///<summary>Code point range 2F00 - 2FDF</summary>
        KangxiRadicals,
        ///<summary>Code point range 0C80 - 0CFF</summary>
        Kannada,
        ///<summary>Code point range 30A0 - 30FF</summary>
        Katakana,
        ///<summary>Code point range 31F0 - 31FF</summary>
        KatakanaPhoneticExtensions,
        ///<summary>Code point range 1780 - 17FF</summary>
        Khmer,
        ///<summary>Code point range 19E0 - 19FF</summary>
        KhmerSymbols,
        ///<summary>Code point range 0E80 - 0EFF</summary>
        Lao,
        ///<summary>Code point range 0080 - 00FF</summary>
        Latin1Supplement,
        ///<summary>Code point range 0100 - 017F</summary>
        LatinExtendedA,
        ///<summary>Code point range 1E00 - 1EFF</summary>
        LatinExtendedAdditional,
        ///<summary>Code point range 0180 - 024F</summary>
        LatinExtendedB,
        ///<summary>Code point range 2100 - 214F</summary>
        LetterLikeSymbols,
        ///<summary>Code point range 1900 - 194F</summary>
        Limbu,
        ///<summary>Code point range DC00 - DFFF</summary>
        LowSurrogates,
        ///<summary>Code point range 0D00 - 0D7F</summary>
        Malayalam,
        ///<summary>Code point range 2200 - 22FF</summary>
        MathematicalOperators,
        ///<summary>Code point range 27C0 - 27EF</summary>
        MiscellaneousMathematicalSymbolsA,
        ///<summary>Code point range 2980 - 29FF</summary>
        MiscellaneousMathematicalSymbolsB,
        ///<summary>Code point range 2600 - 26FF</summary>
        MiscellaneousSymbols,
        ///<summary>Code point range 2B00 - 2BFF</summary>
        MiscellaneousSymbolsAndArrows,
        ///<summary>Code point range 2300 - 23FF</summary>
        MiscellaneousTechnical,
        ///<summary>Code point range 1800 - 18AF</summary>
        Mongolian,
        ///<summary>Code point range 1000 - 109F</summary>
        Myanmar,
        ///<summary>Code point range 2150 - 218F</summary>
        NumberForms,
        ///<summary>Code point range 1680 - 169F</summary>
        Ogham,
        ///<summary>Code point range 2440 - 245F</summary>
        OpticalCharacterRecognition,
        ///<summary>Code point range 0B00 - 0B7F</summary>
        Oriya,
        ///<summary>Code point range 1D00 - 1D7F</summary>
        PhoneticExtensions,
        ///<summary>Code point range E000 - F8FF</summary>
        PrivateUse,
        ///<summary>Code point range E000 - F8FF</summary>
        PrivateUseArea,
        ///<summary>Code point range 16A0 - 16FF</summary>
        Runic,
        ///<summary>Code point range 0D80 - 0DFF</summary>
        Sinhala,
        ///<summary>Code point range FE50 - FE6F</summary>
        SmallFormVariants,
        ///<summary>Code point range 02B0 - 02FF</summary>
        SpacingModifierLetters,
        ///<summary>Code point range FFF0 - FFFF</summary>
        Specials,
        ///<summary>Code point range 2070 - 209F</summary>
        SuperscriptsAndSubscripts,
        ///<summary>Code point range 27F0 - 27FF</summary>
        SupplementalArrowsA,
        ///<summary>Code point range 2900 - 297F</summary>
        SupplementalArrowsB,
        ///<summary>Code point range 2A00 - 2AFF</summary>
        SupplementalMathematicalOperators,
        ///<summary>Code point range 0700 - 074F</summary>
        Syriac,
        ///<summary>Code point range 1700 - 171F</summary>
        Tagalog,
        ///<summary>Code point range 1760 - 177F</summary>
        Tagbanwa,
        ///<summary>Code point range 1950 - 197F</summary>
        TaiLe,
        ///<summary>Code point range 0B80 - 0BFF</summary>
        Tamil,
        ///<summary>Code point range 0C00 - 0C7F</summary>
        Telugu,
        ///<summary>Code point range 0780 - 07BF</summary>
        Thaana,
        ///<summary>Code point range 0E00 - 0E7F</summary>
        Thai,
        ///<summary>Code point range 0F00 - 0FFF</summary>
        Tibetan,
        ///<summary>Code point range 1400 - 167F</summary>
        UnifiedCanadianAboriginalSyllabics,
        ///<summary>Code point range FE00 - FE0F</summary>
        VariationSelectors,
        ///<summary>Code point range 4DC0 - 4DFF</summary>
        YijingHexagramSymbols,
        ///<summary>Code point range A490 - A4CF</summary>
        YiRadicals,
        ///<summary>Code point range A000 - A48F</summary>
        YiSyllables,
    }
}
