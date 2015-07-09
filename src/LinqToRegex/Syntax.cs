// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static partial class Syntax
    {
        public const string InlineCommentStart = "(?#";

        public const string Or = "|";

        public const string StartOfInput = @"\A";
        public const string StartOfLine = "^";
        public const string EndOfInput = @"\z";
        public const string EndOfLine = "$";
        public const string EndOrBeforeEndingNewLine = @"\Z";
        public const string WordBoundary = @"\b";
        public const string NegativeWordBoundary = @"\B";
        public const string PreviousMatchEnd = @"\G";

        public const string AssertionStart = "(?=";
        public const string NegativeAssertionStart = "(?!";
        public const string BackAssertionStart = "(?<=";
        public const string NegativeBackAssertionStart = "(?<!";

        public const string NoncapturingGroupStart = "(?:";
        public const string NonbacktrackingGroupStart = "(?>";
        public const string GroupEnd = ")";

        public const string AnyChar = ".";
        public const string Digit = @"\d";
        public const string NotDigit = @"\D";
        public const string WhiteSpace = @"\s";
        public const string NotWhiteSpace = @"\S";
        public const string WordChar = @"\w";
        public const string NotWordChar = @"\W";
        public const string Bell = @"\a";
        public const string Backspace = @"\b";
        public const string Tab = @"\t";
        public const string Linefeed = @"\n";
        public const string VerticalTab = @"\v";
        public const string FormFeed = @"\f";
        public const string CarriageReturn = @"\r";
        public const string Escape = @"\e";

        public const string CharGroupNegation = "^";
        public const string CharGroupStart = "[";
        public const string CharGroupEnd = "]";

        public const string AsciiHexadecimalStart = @"\x";
        public const string AsciiControlStart = @"\c";
        public const string UnicodeHexadecimalStart = @"\u";

        public const string UnicodeStart = @"\p{";
        public const string NotUnicodeStart = @"\P{";
        public const string UnicodeEnd = "}";

        public const string Maybe = "?";
        public const string MaybeMany = "*";
        public const string OneMany = "+";
        public const string Lazy = "?";

        public const char IgnoreCaseChar = 'i';
        public const char MultilineChar = 'm';
        public const char ExplicitCaptureChar = 'n';
        public const char SinglelineChar = 's';
        public const char IgnorePatternWhiteSpaceChar = 'x';

        public const string SubstitutionChar = "$";
        public const string SubstituteLastCapturedGroup = SubstitutionChar + "+";
        public const string SubstituteEntireInput = SubstitutionChar + "_";
        public const string SubstituteEntireMatch = SubstitutionChar + "&";
        public const string SubstituteAfterMatch = SubstitutionChar + "'";
        public const string SubstituteBeforeMatch = SubstitutionChar + "`";
        public const string SubstituteNamedGroupStart = "${";
        public const string SubstituteNamedGroupEnd = "}";

        public static string GetGeneralCategoryValue(GeneralCategory category)
        {
            return _categories[(int)category];
        }

        public static string GetNamedBlockValue(NamedBlock block)
        {
            return _blocks[(int)block];
        }

        private static readonly string[] _categories = new string[] 
        {
            "C",
            "M",
            "L",
            "N",
            "P",
            "Z",
            "S",
            "Ll",
            "Lm",
            "Lo",
            "Lt",
            "Lu",
            "Me",
            "Mn",
            "Mc",
            "Nd",
            "Nl",
            "No",
            "Cc",
            "Cf",
            "Cn",
            "Co",
            "Cs",
            "Pe",
            "Pc",
            "Pd",
            "Pf",
            "Pi",
            "Ps",
            "Po",
            "Zl",
            "Zp",
            "Zs",
            "Sc",
            "Sm",
            "Sk",
            "So"
        };

        private static readonly string[] _blocks = new string[] 
        {
            "IsAlphabeticPresentationForms",
            "IsArabic",
            "IsArabicPresentationForms-A",
            "IsArabicPresentationForms-B",
            "IsArmenian",
            "IsArrows",
            "IsBasicLatin",
            "IsBengali",
            "IsBlockElements",
            "IsBopomofo",
            "IsBopomofoExtended",
            "IsBoxDrawing",
            "IsBraillePatterns",
            "IsBuhid",
            "IsCJKCompatibility",
            "IsCJKCompatibilityForms",
            "IsCJKCompatibilityIdeographs",
            "IsCJKRadicalsSupplement",
            "IsCJKSymbolsandPunctuation",
            "IsCJKUnifiedIdeographs",
            "IsCJKUnifiedIdeographsExtensionA",
            "IsCombiningDiacriticalMarks",
            "IsCombiningDiacriticalMarksforSymbols",
            "IsCombiningHalfMarks",
            "IsCombiningMarksforSymbols",
            "IsControlPictures",
            "IsCurrencySymbols",
            "IsCyrillic",
            "IsCyrillicSupplement",
            "IsDevanagari",
            "IsDingbats",
            "IsEnclosedAlphanumerics",
            "IsEnclosedCJKLettersandMonths",
            "IsEthiopic",
            "IsGeneralPunctuation",
            "IsGeometricShapes",
            "IsGeorgian",
            "IsGreek",
            "IsGreekandCoptic",
            "IsGreekExtended",
            "IsGujarati",
            "IsGurmukhi",
            "IsHalfwidthandFullwidthForms",
            "IsHangulCompatibilityJamo",
            "IsHangulJamo",
            "IsHangulSyllables",
            "IsHanunoo",
            "IsHebrew",
            "IsHighPrivateUseSurrogates",
            "IsHighSurrogates",
            "IsHiragana",
            "IsCherokee",
            "IsIdeographicDescriptionCharacters",
            "IsIPAExtensions",
            "IsKanbun",
            "IsKangxiRadicals",
            "IsKannada",
            "IsKatakana",
            "IsKatakanaPhoneticExtensions",
            "IsKhmer",
            "IsKhmerSymbols",
            "IsLao",
            "IsLatin-1Supplement",
            "IsLatinExtended-A",
            "IsLatinExtendedAdditional",
            "IsLatinExtended-B",
            "IsLetterlikeSymbols",
            "IsLimbu",
            "IsLowSurrogates",
            "IsMalayalam",
            "IsMathematicalOperators",
            "IsMiscellaneousMathematicalSymbols-A",
            "IsMiscellaneousMathematicalSymbols-B",
            "IsMiscellaneousSymbols",
            "IsMiscellaneousSymbolsandArrows",
            "IsMiscellaneousTechnical",
            "IsMongolian",
            "IsMyanmar",
            "IsNumberForms",
            "IsOgham",
            "IsOpticalCharacterRecognition",
            "IsOriya",
            "IsPhoneticExtensions",
            "IsPrivateUse",
            "IsPrivateUseArea",
            "IsRunic",
            "IsSinhala",
            "IsSmallFormVariants",
            "IsSpacingModifierLetters",
            "IsSpecials",
            "IsSuperscriptsandSubscripts",
            "IsSupplementalArrows-A",
            "IsSupplementalArrows-B",
            "IsSupplementalMathematicalOperators",
            "IsSyriac",
            "IsTagalog",
            "IsTagbanwa",
            "IsTaiLe",
            "IsTamil",
            "IsTelugu",
            "IsThaana",
            "IsThai",
            "IsTibetan",
            "IsUnifiedCanadianAboriginalSyllabics",
            "IsVariationSelectors",
            "IsYijingHexagramSymbols",
            "IsYiRadicals",
            "IsYiSyllables"
        };
    }
}
