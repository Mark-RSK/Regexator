// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Syntax
    {
        internal const string IfStart = "(?";
        internal const string InlineCommentStart = "(?#";

        public const string Or = "|";

        public const string Start = @"\A";
        public const string StartOfLine = "^";
        public const string End = @"\z";
        public const string EndOfLine = "$";
        public const string EndOrBeforeEndingNewLine = @"\Z";
        public const string WordBoundary = @"\b";
        public const string NotWordBoundary = @"\B";
        public const string PreviousMatchEnd = @"\G";

        internal const string LookaheadStart = "(?=";
        internal const string NotLookaheadStart = "(?!";
        internal const string LookbehindStart = "(?<=";
        internal const string NotLookbehindStart = "(?<!";

        internal const string SubexpressionStart = "(";
        internal const string NoncapturingGroupStart = "(?:";
        internal const string NonbacktrackingGroupStart = "(?>";
        internal const string GroupEnd = ")";

        public const string AnyChar = ".";
        public const string Digit = @"\d";
        public const string NotDigit = @"\D";
        public const string WhiteSpace = @"\s";
        public const string NotWhiteSpace = @"\S";
        public const string Word = @"\w";
        public const string NotWord = @"\W";
        public const string Bell = @"\a";
        public const string Backspace = @"\b";
        public const string Escape = @"\e";
        public const string FormFeed = @"\f";
        public const string Linefeed = @"\n";
        public const string CarriageReturn = @"\r";
        public const string Tab = @"\t";
        public const string VerticalTab = @"\v";

        internal const string CharGroupStart = "[";
        internal const string NotCharGroupStart = "[^";
        internal const string CharGroupEnd = "]";
        internal const string AsciiStart = @"\x";
        internal const string AsciiOctalStart = @"\";
        internal const string AsciiControlStart = @"\c";

        internal const string UnicodeStart = @"\p{";
        internal const string NotUnicodeStart = @"\P{";
        internal const string HexUnicodeStart = @"\u";
        internal const string UnicodeEnd = "}";

        public const string Maybe = "?";
        public const string MaybeLazy = "??";
        public const string MaybeMany = "*";
        public const string MaybeManyLazy = "*?";
        public const string OneMany = "+";
        public const string OneManyLazy = "+?";
        public const string Lazy = "?";

        public const char IgnoreCaseChar = 'i';
        public const char MultilineChar = 'm';
        public const char ExplicitCaptureChar = 'n';
        public const char SinglelineChar = 's';
        public const char IgnorePatternWhiteSpaceChar = 'x';

        internal static readonly InlineOptions InlineOptions = InlineOptions.IgnoreCase | InlineOptions.Multiline | InlineOptions.ExplicitCapture | InlineOptions.Singleline | InlineOptions.IgnorePatternWhitespace;

        internal static string IfGroupCondition(int groupNumber)
        {
            if (groupNumber < 0) { throw new ArgumentOutOfRangeException("groupNumber"); }
            return IfGroupCondition(groupNumber.ToString(CultureInfo.InvariantCulture));
        }

        internal static string IfGroupCondition(string groupName)
        {
            if (groupName == null) { throw new ArgumentNullException("groupName"); }
            return SubexpressionStart + groupName + GroupEnd;
        }

        public static string Lookahead(string value)
        {
            return LookaheadStart + value + GroupEnd;
        }

        public static string NotLookahead(string value)
        {
            return NotLookaheadStart + value + GroupEnd;
        }

        public static string Lookbehind(string value)
        {
            return LookbehindStart + value + GroupEnd;
        }

        public static string NotLookbehind(string value)
        {
            return NotLookbehindStart + value + GroupEnd;
        }

        public static string Backreference(int groupNumber)
        {
            if (groupNumber < 0) { throw new ArgumentOutOfRangeException("groupNumber"); }
            return @"\" + groupNumber;
        }

        public static string Backreference(string groupName, IdentifierBoundary separator)
        {
            if (groupName == null) { throw new ArgumentNullException("groupName"); }
            switch (separator)
            {
                case IdentifierBoundary.LessThan:
                    return @"\k<" + groupName + ">";
                case IdentifierBoundary.Apostrophe:
                    return @"\k'" + groupName + "'";
            }
            return null;
        }

        public static string Group(string name, string value, IdentifierBoundary separator)
        {
            return GroupStart(name, separator) + value + GroupEnd;
        }

        internal static string GroupStart(string groupName, IdentifierBoundary separator)
        {
            if (groupName == null) { throw new ArgumentNullException("groupName"); }
            switch (separator)
            {
                case IdentifierBoundary.LessThan:
                    return @"(?<" + groupName + @">";
                case IdentifierBoundary.Apostrophe:
                    return @"(?'" + groupName + @"'";
            }
            return null;
        }

        public static string BalancingGroup(string name1, string name2, string value, IdentifierBoundary separator)
        {
            return BalancingGroupStart(name1, name2, separator) + value + GroupEnd;
        }

        internal static string BalancingGroupStart(string name1, string name2, IdentifierBoundary separator)
        {
            if (name1 == null) { throw new ArgumentNullException("name1"); }
            if (name2 == null) { throw new ArgumentNullException("name2"); }
            switch (separator)
            {
                case IdentifierBoundary.LessThan:
                    return @"(?<" + name1 + "-" + name2 + @">";
                case IdentifierBoundary.Apostrophe:
                    return @"(?'" + name1 + "-" + name2 + @"'";
            }
            return null;
        }

        public static string Subexpression(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return SubexpressionStart + value + GroupEnd;
        }

        public static string NoncapturingGroup(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return NoncapturingGroupStart + value + GroupEnd;
        }

        public static string NonbacktrackingGroup(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return NonbacktrackingGroupStart + value + GroupEnd;
        }

        public static string GroupOptions(InlineOptions applyOptions, string value)
        {
            return GroupOptions(applyOptions, InlineOptions.None, value);
        }

        public static string GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string value)
        {
            return GroupOptionsStart(applyOptions, disableOptions) + value + GroupEnd;
        }

        internal static string GroupOptionsStart(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            if ((applyOptions & InlineOptions) != InlineOptions.None)
            {
                if ((disableOptions & InlineOptions) != InlineOptions.None)
                {
                    return "(?" + GetInlineChars(applyOptions) + "-" + GetInlineChars(disableOptions) + ":";
                }
                else
                {
                    return "(?" + GetInlineChars(applyOptions) + ":";
                }
            }
            return string.Empty;
        }

        internal static string CharGroup(string value)
        {
            return CharGroup(value, false);
        }

        internal static string CharGroup(string value, bool negative)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            if (value.Length == 0) { throw new ArgumentException("Character group cannot be empty.", "value"); }
            return (negative ? NotCharGroupStart : CharGroupStart) + value + CharGroupEnd;
        }

        public static string CharClass(CharClass value)
        {
            switch (value)
            {
                case Builder.CharClass.Digit:
                    return Digit;
                case Builder.CharClass.Word:
                    return Word;
                case Builder.CharClass.WhiteSpace:
                    return WhiteSpace;
                case Builder.CharClass.NotDigit:
                    return NotDigit;
                case Builder.CharClass.NotWord:
                    return NotWord;
                case Builder.CharClass.NotWhiteSpace:
                    return NotWhiteSpace;
            }
            return string.Empty;
        }

        public static string CharClasses(IEnumerable<CharClass> values)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            return string.Concat(values.Select(f => CharClass(f)));
        }

        public static string Range(char first, char last)
        {
            return Syntax.Char(first, true) + "-" + Syntax.Char(last, true);
        }

        public static string Range(int firstCharCode, int lastCharCode)
        {
            return Syntax.Char(firstCharCode, true) + "-" + Syntax.Char(lastCharCode, true);
        }

        internal static string RangeInternal(int firstCharCode, int lastCharCode)
        {
            return Syntax.CharInternal(firstCharCode, true) + "-" + Syntax.CharInternal(lastCharCode, true);
        }

        public static string Char(char value, bool inCharGroup)
        {
            return Utilities.EscapeInternal((int)value, inCharGroup);
        }

        public static string Char(int charCode)
        {
            return Char(charCode, false);
        }

        public static string Char(int charCode, bool inCharGroup)
        {
            return Utilities.Escape(charCode, inCharGroup);
        }

        internal static string CharInternal(int charCode)
        {
            return CharInternal(charCode, false);
        }

        internal static string CharInternal(int charCode, bool inCharGroup)
        {
            return Utilities.EscapeInternal(charCode, inCharGroup);
        }

        public static string Char(AsciiChar value)
        {
            return Char(value, false);
        }

        public static string Char(AsciiChar value, bool inCharGroup)
        {
            return Utilities.EscapeInternal((int)value, inCharGroup);
        }

        public static string Char(char value)
        {
            return Char(value, false);
        }

        public static string Chars(IEnumerable<char> values)
        {
            return Chars(values, false);
        }

        public static string Chars(IEnumerable<char> values, bool inCharGroup)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            return string.Concat(values.Select(f => Char(f, inCharGroup)));
        }

        public static string Chars(IEnumerable<int> charCodes)
        {
            return Chars(charCodes, false);
        }

        public static string Chars(IEnumerable<int> charCodes, bool inCharGroup)
        {
            if (charCodes == null) { throw new ArgumentNullException("charCodes"); }
            return string.Concat(charCodes.Select(f => Char(f, inCharGroup)));
        }

        public static string Chars(IEnumerable<AsciiChar> values)
        {
            return Chars(values, false);
        }

        public static string Chars(IEnumerable<AsciiChar> values, bool inCharGroup)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            return string.Concat(values.Select(f => Char(f, inCharGroup)));
        }

        public static string Unicode(char value)
        {
            return UnicodeInternal((int)value);
        }

        public static string Unicode(int charCode)
        {
            if (charCode < 0 || charCode > 0xFFFF) { throw new ArgumentOutOfRangeException("charCode"); }
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

        public static string UnicodeBlocks(IEnumerable<UnicodeBlock> blocks)
        {
            return UnicodeBlocks(blocks, false);
        }

        public static string UnicodeBlocks(IEnumerable<UnicodeBlock> blocks, bool negative)
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

        public static string UnicodeCategories(IEnumerable<UnicodeCategory> categories)
        {
            return UnicodeCategories(categories, false);
        }

        public static string UnicodeCategories(IEnumerable<UnicodeCategory> categories, bool negative)
        {
            if (categories == null) { throw new ArgumentNullException("categories"); }
            return string.Concat(categories.Select(f => UnicodeCategory(f, negative)));
        }

        public static string Count(int exactCount)
        {
            if (exactCount < 0) { throw new ArgumentOutOfRangeException("exactCount"); }
            return "{" + exactCount + "}";
        }

        public static string CountFrom(int minCount)
        {
            if (minCount < 0) { throw new ArgumentOutOfRangeException("minCount"); }
            return "{" + minCount + ",}";
        }

        public static string CountRange(int minCount, int maxCount)
        {
            if (minCount < 0) { throw new ArgumentOutOfRangeException("minCount"); }
            if (maxCount < minCount) { throw new ArgumentOutOfRangeException("maxCount"); }
            return "{" + minCount + "," + maxCount + "}";
        }

        public static string Options(InlineOptions enableOptions)
        {
            return Options(enableOptions, InlineOptions.None);
        }

        public static string Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            if ((applyOptions & InlineOptions) != InlineOptions.None)
            {
                if ((disableOptions & InlineOptions) != InlineOptions.None)
                {
                    return "(?" + GetInlineChars(applyOptions) + "-" + GetInlineChars(disableOptions) + GroupEnd;
                }
                else
                {
                    return "(?" + GetInlineChars(applyOptions) + GroupEnd;
                }
            }
            return string.Empty;
        }

        public static string GetInlineChars(InlineOptions options)
        {
            return new string(EnumerateInlineChars(options).ToArray());
        }

        internal static IEnumerable<char> EnumerateInlineChars(InlineOptions options)
        {
            if ((options & InlineOptions.IgnoreCase) == InlineOptions.IgnoreCase)
            {
                yield return IgnoreCaseChar;
            }
            if ((options & InlineOptions.Multiline) == InlineOptions.Multiline)
            {
                yield return MultilineChar;
            }
            if ((options & InlineOptions.ExplicitCapture) == InlineOptions.ExplicitCapture)
            {
                yield return ExplicitCaptureChar;
            }
            if ((options & InlineOptions.Singleline) == InlineOptions.Singleline)
            {
                yield return SinglelineChar;
            }
            if ((options & InlineOptions.IgnorePatternWhitespace) == InlineOptions.IgnorePatternWhitespace)
            {
                yield return IgnorePatternWhiteSpaceChar;
            }
        }

        public static string InlineComment(string value)
        {
            return InlineCommentStart + value + GroupEnd;
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
