// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Provides static methods and constants for obtaining regular expression language elements.
    /// </summary>
    public static partial class Syntax
    {
        /// <summary>
        /// Specifies start token of the inline comment.
        /// </summary>
        public const string InlineCommentStart = "(?#";

        /// <summary>
        /// Specifies alternation token (vertical bar).
        /// </summary>
        public const string Or = "|";

        /// <summary>
        /// Specifies a pattern that is matched at the beginning of the string.
        /// </summary>
        public const string StartOfInput = @"\A";

        /// <summary>
        /// Specifies a pattern that is matched at the beginning of the string (or line if the multiline option is applied).
        /// </summary>
        public const string StartOfLine = "^";
        
        /// <summary>
        /// Specifies a pattern that is matched at the end of the string.
        /// </summary>
        public const string EndOfInput = @"\z";

        /// <summary>
        /// Specifies a pattern that is matched at the end of the string (or line if the multiline option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        public const string EndOfLine = "$";

        /// <summary>
        /// Specifies a pattern that is matched at the end of the string or before linefeed at the end of the string.
        /// </summary>
        public const string EndOrBeforeEndingNewLine = @"\Z";

        /// <summary>
        /// Specifies a pattern that is matched on a boundary between a word character (\w) and a non-word character (\W). The pattern may be also matched on a word boundary at the beginning or end of the string.
        /// </summary>
        public const string WordBoundary = @"\b";

        /// <summary>
        /// Specifies a pattern that is not matched on a boundary between a word character (\w) and a non-word character (\W).
        /// </summary>
        public const string NegativeWordBoundary = @"\B";

        /// <summary>
        /// Specifies a pattern that is matched at the position where the previous match ended.
        /// </summary>
        public const string PreviousMatchEnd = @"\G";

        /// <summary>
        /// Specifies a start token of the zero-width positive lookahead assertion.
        /// </summary>
        public const string AssertionStart = "(?=";

        /// <summary>
        /// Specifies a start token of the zero-width negative lookahead assertion.
        /// </summary>
        public const string NegativeAssertionStart = "(?!";

        /// <summary>
        /// Specifies start token of the zero-width positive lookbehind assertion.
        /// </summary>
        public const string BackAssertionStart = "(?<=";

        /// <summary>
        /// Specifies start token of the zero-width negative lookbehind assertion.
        /// </summary>
        public const string NegativeBackAssertionStart = "(?<!";

        /// <summary>
        /// Specifies start token of the noncapturing group.
        /// </summary>
        public const string NoncapturingGroupStart = "(?:";

        /// <summary>
        /// Specifies start token of the nonbackstracking group.
        /// </summary>
        public const string NonbacktrackingGroupStart = "(?>";

        /// <summary>
        /// Specifies end token of a group (end parenthesis).
        /// </summary>
        public const string GroupEnd = ")";

        /// <summary>
        /// Specifies a pattern that matches any character except linefeed (or any character if the Singleline option is applied).
        /// </summary>
        public const string AnyChar = ".";

        /// <summary>
        /// Specifies a pattern that matches a digit character.
        /// </summary>
        public const string Digit = @"\d";

        /// <summary>
        /// Specifies a pattern that matches a character that is not a digit character.
        /// </summary>
        public const string NotDigit = @"\D";

        /// <summary>
        /// Specifies a pattern that matches a white-space character.
        /// </summary>
        public const string WhiteSpace = @"\s";

        /// <summary>
        /// Specifies a pattern that matches a character that is not a white-space character.
        /// </summary>
        public const string NotWhiteSpace = @"\S";

        /// <summary>
        /// Specifies a pattern that matches a word character.
        /// </summary>
        public const string WordChar = @"\w";

        /// <summary>
        /// Specifies a pattern that matches a character that is not a word character.
        /// </summary>
        public const string NotWordChar = @"\W";

        /// <summary>
        /// Specifies a pattern that matches a bell.
        /// </summary>
        public const string Bell = @"\a";

        /// <summary>
        /// Specifies a pattern that matches a tab.
        /// </summary>
        public const string Tab = @"\t";

        /// <summary>
        /// Specifies a pattern that matches a linefeed.
        /// </summary>
        public const string Linefeed = @"\n";

        /// <summary>
        /// Specifies a pattern that matches a vertical tab.
        /// </summary>
        public const string VerticalTab = @"\v";

        /// <summary>
        /// Specifies a pattern that matches a form feed.
        /// </summary>
        public const string FormFeed = @"\f";

        /// <summary>
        /// Specifies a pattern that matches a carriage return.
        /// </summary>
        public const string CarriageReturn = @"\r";

        /// <summary>
        /// Specifies a pattern that matches an escape character.
        /// </summary>
        public const string Escape = @"\e";

        /// <summary>
        /// Specifies a negation token of the character group.
        /// </summary>
        public const string CharGroupNegation = "^";

        /// <summary>
        /// Specifies start token of the character group.
        /// </summary>
        public const string CharGroupStart = "[";

        /// <summary>
        /// Specifies end token of the character group.
        /// </summary>
        public const string CharGroupEnd = "]";

        /// <summary>
        /// Specifies a start token of the hexadecimal ASCII character.
        /// </summary>
        public const string AsciiHexadecimalStart = @"\x";

        /// <summary>
        /// Specifies a start token of the ASCII control character.
        /// </summary>
        public const string AsciiControlStart = @"\c";

        /// Specifies a start token of the hexadecimal Unicode character.
        public const string UnicodeHexadecimalStart = @"\u";

        /// <summary>
        /// Specifies start token of the Unicode block or category.
        /// </summary>
        public const string UnicodeStart = @"\p{";

        /// <summary>
        /// Specifies start token of the negative Unicode block or category.
        /// </summary>
        public const string NotUnicodeStart = @"\P{";

        /// <summary>
        /// Specifies end token of the Unicode block or category.
        /// </summary>
        public const string UnicodeEnd = "}";

        /// <summary>
        /// Specifies a quantifier that matches previous element zero or one times.
        /// </summary>
        public const string Maybe = "?";

        /// <summary>
        /// Specifies a quantifier that matches previous element zero or more times.
        /// </summary>
        public const string MaybeMany = "*";

        /// <summary>
        /// Specifies a quantifier that matches previous element one or more times.
        /// </summary>
        public const string OneMany = "+";

        /// <summary>
        /// Specifies a token that turns greedy quantifier into a lazy quantifier.
        /// </summary>
        public const string Lazy = "?";

        /// <summary>
        /// Specifies an inline character of the <see cref="RegexOptions.IgnoreCase"/> options.
        /// </summary>
        public const char IgnoreCaseChar = 'i';

        /// <summary>
        /// Specifies an inline character of the <see cref="RegexOptions.Multiline"/> options.
        /// </summary>
        public const char MultilineChar = 'm';
        
        /// <summary>
        /// Specifies an inline character of the <see cref="RegexOptions.ExplicitCapture"/> options.
        /// </summary>
        public const char ExplicitCaptureChar = 'n';

        /// <summary>
        /// Specifies an inline character of the <see cref="RegexOptions.Singleline"/> options.
        /// </summary>
        public const char SinglelineChar = 's';

        /// <summary>
        /// Specifies an inline character of the <see cref="RegexOptions.IgnorePatternWhitespace"/> options.
        /// </summary>
        public const char IgnorePatternWhiteSpaceChar = 'x';

        /// <summary>
        /// Specifies start token of the substitution patter.
        /// </summary>
        public const string SubstitutionChar = "$";

        /// <summary>
        /// Specifies a substitution pattern that substitutes last captured group.
        /// </summary>
        public const string SubstituteLastCapturedGroup = SubstitutionChar + "+";

        /// <summary>
        /// Specifies a substitution pattern that substitutes entire input string.
        /// </summary>
        public const string SubstituteEntireInput = SubstitutionChar + "_";

        /// <summary>
        /// Specifies a substitution pattern that substitutes entire match.
        /// </summary>
        public const string SubstituteEntireMatch = SubstitutionChar + "&";
        
        /// <summary>
        /// Specifies a substitution pattern that substitutes all the text of the input string after the match.
        /// </summary>
        public const string SubstituteAfterMatch = SubstitutionChar + "'";

        /// <summary>
        /// Specifies a substitution pattern that substitutes all the text of the input string before the match.
        /// </summary>
        public const string SubstituteBeforeMatch = SubstitutionChar + "`";

        /// <summary>
        /// Specifies start token of the substitution pattern that substitutes a named group.
        /// </summary>
        public const string SubstituteNamedGroupStart = "${";

        /// <summary>
        /// Specifies start token of the substitution pattern that substitutes a named group.
        /// </summary>
        public const string SubstituteNamedGroupEnd = "}";

        /// <summary>
        /// Gets a content of the Unicode category pattern for a specified category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        /// <returns></returns>
        public static string GetGeneralCategoryValue(GeneralCategory category)
        {
            return _categories[(int)category];
        }

        /// <summary>
        /// Gets a content of the Unicode block pattern for a specified block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        /// <returns></returns>
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
