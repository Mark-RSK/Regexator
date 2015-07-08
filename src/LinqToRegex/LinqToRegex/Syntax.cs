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

        internal static string CharClass(CharClass value)
        {
            switch (value)
            {
                case Linq.CharClass.Digit:
                    return Digit;
                case Linq.CharClass.WordChar:
                    return WordChar;
                case Linq.CharClass.WhiteSpace:
                    return WhiteSpace;
                case Linq.CharClass.NotDigit:
                    return NotDigit;
                case Linq.CharClass.NotWordChar:
                    return NotWordChar;
                case Linq.CharClass.NotWhiteSpace:
                    return NotWhiteSpace;
            }

            return string.Empty;
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public static string GetGeneralCategoryValue(GeneralCategory category)
        {
            switch (category)
            {
                case Linq.GeneralCategory.AllControlCharacters:
                    return "C";
                case Linq.GeneralCategory.AllDiacriticMarks:
                    return "M";
                case Linq.GeneralCategory.AllLetterCharacters:
                    return "L";
                case Linq.GeneralCategory.AllNumbers:
                    return "N";
                case Linq.GeneralCategory.AllPunctuationCharacters:
                    return "P";
                case Linq.GeneralCategory.AllSeparatorCharacters:
                    return "Z";
                case Linq.GeneralCategory.AllSymbols:
                    return "S";
                case Linq.GeneralCategory.LetterLowercase:
                    return "Ll";
                case Linq.GeneralCategory.LetterModifier:
                    return "Lm";
                case Linq.GeneralCategory.LetterOther:
                    return "Lo";
                case Linq.GeneralCategory.LetterTitlecase:
                    return "Lt";
                case Linq.GeneralCategory.LetterUppercase:
                    return "Lu";
                case Linq.GeneralCategory.MarkEnclosing:
                    return "Me";
                case Linq.GeneralCategory.MarkNonspacing:
                    return "Mn";
                case Linq.GeneralCategory.MarkSpacingCombining:
                    return "Mc";
                case Linq.GeneralCategory.NumberDecimalDigit:
                    return "Nd";
                case Linq.GeneralCategory.NumberLetter:
                    return "Nl";
                case Linq.GeneralCategory.NumberOther:
                    return "No";
                case Linq.GeneralCategory.OtherControl:
                    return "Cc";
                case Linq.GeneralCategory.OtherFormat:
                    return "Cf";
                case Linq.GeneralCategory.OtherNotAssigned:
                    return "Cn";
                case Linq.GeneralCategory.OtherPrivateUse:
                    return "Co";
                case Linq.GeneralCategory.OtherSurrogate:
                    return "Cs";
                case Linq.GeneralCategory.PunctuationClose:
                    return "Pe";
                case Linq.GeneralCategory.PunctuationConnector:
                    return "Pc";
                case Linq.GeneralCategory.PunctuationDash:
                    return "Pd";
                case Linq.GeneralCategory.PunctuationFinalQuote:
                    return "Pf";
                case Linq.GeneralCategory.PunctuationInitialQuote:
                    return "Pi";
                case Linq.GeneralCategory.PunctuationOpen:
                    return "Ps";
                case Linq.GeneralCategory.PunctuationOther:
                    return "Po";
                case Linq.GeneralCategory.SeparatorLine:
                    return "Zl";
                case Linq.GeneralCategory.SeparatorParagraph:
                    return "Zp";
                case Linq.GeneralCategory.SeparatorSpace:
                    return "Zs";
                case Linq.GeneralCategory.SymbolCurrency:
                    return "Sc";
                case Linq.GeneralCategory.SymbolMath:
                    return "Sm";
                case Linq.GeneralCategory.SymbolModifier:
                    return "Sk";
                case Linq.GeneralCategory.SymbolOther:
                    return "So";
                default:
                    return string.Empty;
            }
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public static string GetNamedBlockValue(NamedBlock block)
        {
            switch (block)
            {
                case Linq.NamedBlock.AlphabeticPresentationForms:
                    return "IsAlphabeticPresentationForms";
                case Linq.NamedBlock.Arabic:
                    return "IsArabic";
                case Linq.NamedBlock.ArabicPresentationFormsA:
                    return "IsArabicPresentationForms-A";
                case Linq.NamedBlock.ArabicPresentationFormsB:
                    return "IsArabicPresentationForms-B";
                case Linq.NamedBlock.Armenian:
                    return "IsArmenian";
                case Linq.NamedBlock.Arrows:
                    return "IsArrows";
                case Linq.NamedBlock.BasicLatin:
                    return "IsBasicLatin";
                case Linq.NamedBlock.Bengali:
                    return "IsBengali";
                case Linq.NamedBlock.BlockElements:
                    return "IsBlockElements";
                case Linq.NamedBlock.Bopomofo:
                    return "IsBopomofo";
                case Linq.NamedBlock.BopomofoExtended:
                    return "IsBopomofoExtended";
                case Linq.NamedBlock.BoxDrawing:
                    return "IsBoxDrawing";
                case Linq.NamedBlock.BraillePatterns:
                    return "IsBraillePatterns";
                case Linq.NamedBlock.Buhid:
                    return "IsBuhid";
                case Linq.NamedBlock.CJKCompatibility:
                    return "IsCJKCompatibility";
                case Linq.NamedBlock.CJKCompatibilityForms:
                    return "IsCJKCompatibilityForms";
                case Linq.NamedBlock.CJKCompatibilityIdeographs:
                    return "IsCJKCompatibilityIdeographs";
                case Linq.NamedBlock.CJKRadicalsSupplement:
                    return "IsCJKRadicalsSupplement";
                case Linq.NamedBlock.CJKSymbolsAndPunctuation:
                    return "IsCJKSymbolsandPunctuation";
                case Linq.NamedBlock.CJKUnifiedIdeographs:
                    return "IsCJKUnifiedIdeographs";
                case Linq.NamedBlock.CJKUnifiedIdeographsExtensionA:
                    return "IsCJKUnifiedIdeographsExtensionA";
                case Linq.NamedBlock.CombiningDiacriticalMarks:
                    return "IsCombiningDiacriticalMarks";
                case Linq.NamedBlock.CombiningDiacriticalMarksForSymbols:
                    return "IsCombiningDiacriticalMarksforSymbols";
                case Linq.NamedBlock.CombiningHalfMarks:
                    return "IsCombiningHalfMarks";
                case Linq.NamedBlock.CombiningMarksForSymbols:
                    return "IsCombiningMarksforSymbols";
                case Linq.NamedBlock.ControlPictures:
                    return "IsControlPictures";
                case Linq.NamedBlock.CurrencySymbols:
                    return "IsCurrencySymbols";
                case Linq.NamedBlock.Cyrillic:
                    return "IsCyrillic";
                case Linq.NamedBlock.CyrillicSupplement:
                    return "IsCyrillicSupplement";
                case Linq.NamedBlock.Devanagari:
                    return "IsDevanagari";
                case Linq.NamedBlock.Dingbats:
                    return "IsDingbats";
                case Linq.NamedBlock.EnclosedAlphanumerics:
                    return "IsEnclosedAlphanumerics";
                case Linq.NamedBlock.EnclosedCJKLettersAndMonths:
                    return "IsEnclosedCJKLettersandMonths";
                case Linq.NamedBlock.Ethiopic:
                    return "IsEthiopic";
                case Linq.NamedBlock.GeneralPunctuation:
                    return "IsGeneralPunctuation";
                case Linq.NamedBlock.GeometricShapes:
                    return "IsGeometricShapes";
                case Linq.NamedBlock.Georgian:
                    return "IsGeorgian";
                case Linq.NamedBlock.Greek:
                    return "IsGreek";
                case Linq.NamedBlock.GreekAndCoptic:
                    return "IsGreekandCoptic";
                case Linq.NamedBlock.GreekExtended:
                    return "IsGreekExtended";
                case Linq.NamedBlock.Gujarati:
                    return "IsGujarati";
                case Linq.NamedBlock.Gurmukhi:
                    return "IsGurmukhi";
                case Linq.NamedBlock.HalfWidthAndFullWidthForms:
                    return "IsHalfwidthandFullwidthForms";
                case Linq.NamedBlock.HangulCompatibilityJamo:
                    return "IsHangulCompatibilityJamo";
                case Linq.NamedBlock.HangulJamo:
                    return "IsHangulJamo";
                case Linq.NamedBlock.HangulSyllables:
                    return "IsHangulSyllables";
                case Linq.NamedBlock.Hanunoo:
                    return "IsHanunoo";
                case Linq.NamedBlock.Hebrew:
                    return "IsHebrew";
                case Linq.NamedBlock.HighPrivateUseSurrogates:
                    return "IsHighPrivateUseSurrogates";
                case Linq.NamedBlock.HighSurrogates:
                    return "IsHighSurrogates";
                case Linq.NamedBlock.Hiragana:
                    return "IsHiragana";
                case Linq.NamedBlock.Cherokee:
                    return "IsCherokee";
                case Linq.NamedBlock.IdeographicDescriptionCharacters:
                    return "IsIdeographicDescriptionCharacters";
                case Linq.NamedBlock.IPAExtensions:
                    return "IsIPAExtensions";
                case Linq.NamedBlock.Kanbun:
                    return "IsKanbun";
                case Linq.NamedBlock.KangxiRadicals:
                    return "IsKangxiRadicals";
                case Linq.NamedBlock.Kannada:
                    return "IsKannada";
                case Linq.NamedBlock.Katakana:
                    return "IsKatakana";
                case Linq.NamedBlock.KatakanaPhoneticExtensions:
                    return "IsKatakanaPhoneticExtensions";
                case Linq.NamedBlock.Khmer:
                    return "IsKhmer";
                case Linq.NamedBlock.KhmerSymbols:
                    return "IsKhmerSymbols";
                case Linq.NamedBlock.Lao:
                    return "IsLao";
                case Linq.NamedBlock.Latin1Supplement:
                    return "IsLatin-1Supplement";
                case Linq.NamedBlock.LatinExtendedA:
                    return "IsLatinExtended-A";
                case Linq.NamedBlock.LatinExtendedAdditional:
                    return "IsLatinExtendedAdditional";
                case Linq.NamedBlock.LatinExtendedB:
                    return "IsLatinExtended-B";
                case Linq.NamedBlock.LetterLikeSymbols:
                    return "IsLetterlikeSymbols";
                case Linq.NamedBlock.Limbu:
                    return "IsLimbu";
                case Linq.NamedBlock.LowSurrogates:
                    return "IsLowSurrogates";
                case Linq.NamedBlock.Malayalam:
                    return "IsMalayalam";
                case Linq.NamedBlock.MathematicalOperators:
                    return "IsMathematicalOperators";
                case Linq.NamedBlock.MiscellaneousMathematicalSymbolsA:
                    return "IsMiscellaneousMathematicalSymbols-A";
                case Linq.NamedBlock.MiscellaneousMathematicalSymbolsB:
                    return "IsMiscellaneousMathematicalSymbols-B";
                case Linq.NamedBlock.MiscellaneousSymbols:
                    return "IsMiscellaneousSymbols";
                case Linq.NamedBlock.MiscellaneousSymbolsAndArrows:
                    return "IsMiscellaneousSymbolsandArrows";
                case Linq.NamedBlock.MiscellaneousTechnical:
                    return "IsMiscellaneousTechnical";
                case Linq.NamedBlock.Mongolian:
                    return "IsMongolian";
                case Linq.NamedBlock.Myanmar:
                    return "IsMyanmar";
                case Linq.NamedBlock.NumberForms:
                    return "IsNumberForms";
                case Linq.NamedBlock.Ogham:
                    return "IsOgham";
                case Linq.NamedBlock.OpticalCharacterRecognition:
                    return "IsOpticalCharacterRecognition";
                case Linq.NamedBlock.Oriya:
                    return "IsOriya";
                case Linq.NamedBlock.PhoneticExtensions:
                    return "IsPhoneticExtensions";
                case Linq.NamedBlock.PrivateUse:
                    return "IsPrivateUse";
                case Linq.NamedBlock.PrivateUseArea:
                    return "IsPrivateUseArea";
                case Linq.NamedBlock.Runic:
                    return "IsRunic";
                case Linq.NamedBlock.Sinhala:
                    return "IsSinhala";
                case Linq.NamedBlock.SmallFormVariants:
                    return "IsSmallFormVariants";
                case Linq.NamedBlock.SpacingModifierLetters:
                    return "IsSpacingModifierLetters";
                case Linq.NamedBlock.Specials:
                    return "IsSpecials";
                case Linq.NamedBlock.SuperscriptsAndSubscripts:
                    return "IsSuperscriptsandSubscripts";
                case Linq.NamedBlock.SupplementalArrowsA:
                    return "IsSupplementalArrows-A";
                case Linq.NamedBlock.SupplementalArrowsB:
                    return "IsSupplementalArrows-B";
                case Linq.NamedBlock.SupplementalMathematicalOperators:
                    return "IsSupplementalMathematicalOperators";
                case Linq.NamedBlock.Syriac:
                    return "IsSyriac";
                case Linq.NamedBlock.Tagalog:
                    return "IsTagalog";
                case Linq.NamedBlock.Tagbanwa:
                    return "IsTagbanwa";
                case Linq.NamedBlock.TaiLe:
                    return "IsTaiLe";
                case Linq.NamedBlock.Tamil:
                    return "IsTamil";
                case Linq.NamedBlock.Telugu:
                    return "IsTelugu";
                case Linq.NamedBlock.Thaana:
                    return "IsThaana";
                case Linq.NamedBlock.Thai:
                    return "IsThai";
                case Linq.NamedBlock.Tibetan:
                    return "IsTibetan";
                case Linq.NamedBlock.UnifiedCanadianAboriginalSyllabics:
                    return "IsUnifiedCanadianAboriginalSyllabics";
                case Linq.NamedBlock.VariationSelectors:
                    return "IsVariationSelectors";
                case Linq.NamedBlock.YijingHexagramSymbols:
                    return "IsYijingHexagramSymbols";
                case Linq.NamedBlock.YiRadicals:
                    return "IsYiRadicals";
                case Linq.NamedBlock.YiSyllables:
                    return "IsYiSyllables";
                default:
                    return string.Empty;
            }
        }
    }
}
