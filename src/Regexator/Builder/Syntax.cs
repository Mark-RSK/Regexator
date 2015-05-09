// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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
        public const string WordChar = @"\w";
        public const string NotWordChar = @"\W";
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

        public const string SubstitutionChar = "$";
        public const string SubstituteLastCapturedGroup = SubstitutionChar + "+";
        public const string SubstituteEntireInput = SubstitutionChar + "_";
        public const string SubstituteEntireMatch = SubstitutionChar + "&";
        public const string SubstituteAfterMatch = SubstitutionChar + "'";
        public const string SubstituteBeforeMatch = SubstitutionChar + "`";

        internal static readonly InlineOptions InlineOptions = InlineOptions.IgnoreCase | InlineOptions.Multiline | InlineOptions.ExplicitCapture | InlineOptions.Singleline | InlineOptions.IgnorePatternWhitespace;

        internal static string IfGroupCondition(int groupNumber)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }
            return IfGroupCondition(groupNumber.ToString(CultureInfo.InvariantCulture));
        }

        internal static string IfGroupCondition(string groupName)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
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
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }
            return @"\" + groupNumber;
        }

        public static string Backreference(string groupName, IdentifierBoundary separator)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            switch (separator)
            {
                case IdentifierBoundary.LessThan:
                    return @"\k<" + groupName + ">";
                case IdentifierBoundary.Apostrophe:
                    return @"\k'" + groupName + "'";
            }
            return null;
        }

        public static string Group(string groupName, string value, IdentifierBoundary boundary)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            RegexUtilities.CheckGroupName(groupName);
            return GroupStart(groupName, boundary) + value + GroupEnd;
        }

        internal static string GroupStart(string groupName, IdentifierBoundary boundary)
        {
            switch (boundary)
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
            if (name1 == null)
            {
                throw new ArgumentNullException("name1");
            }
            if (name2 == null)
            {
                throw new ArgumentNullException("name2");
            }
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
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            return SubexpressionStart + value + GroupEnd;
        }

        public static string NoncapturingGroup(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            return NoncapturingGroupStart + value + GroupEnd;
        }

        public static string NonbacktrackingGroup(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
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
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (value.Length == 0)
            {
                throw new ArgumentException("Character group cannot be empty.", "value");
            }
            return (negative ? NotCharGroupStart : CharGroupStart) + value + CharGroupEnd;
        }

        public static string CharClass(CharClass value)
        {
            switch (value)
            {
                case Builder.CharClass.Digit:
                    return Digit;
                case Builder.CharClass.WordChar:
                    return WordChar;
                case Builder.CharClass.WhiteSpace:
                    return WhiteSpace;
                case Builder.CharClass.NotDigit:
                    return NotDigit;
                case Builder.CharClass.NotWordChar:
                    return NotWordChar;
                case Builder.CharClass.NotWhiteSpace:
                    return NotWhiteSpace;
            }
            return string.Empty;
        }

        public static string CharClasses(IEnumerable<CharClass> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
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

        public static string ArabicDigitRange(int first, int last)
        {
            if (first < 0 || first > 9)
            {
                throw new ArgumentOutOfRangeException("first");
            }
            if (last < first || last > 9)
            {
                throw new ArgumentOutOfRangeException("last");
            }
            return ArabicDigitRangeInternal(first, last);
        }

        internal static string ArabicDigitRangeInternal(int first, int last)
        {
            return RangeInternal((char)('0' + first), (char)('0' + last));
        }

        public static string Char(char value, bool inCharGroup)
        {
            return RegexUtilities.EscapeInternal((int)value, inCharGroup);
        }

        public static string Char(int charCode)
        {
            return Char(charCode, false);
        }

        public static string Char(int charCode, bool inCharGroup)
        {
            return RegexUtilities.Escape(charCode, inCharGroup);
        }

        internal static string CharInternal(int charCode)
        {
            return CharInternal(charCode, false);
        }

        internal static string CharInternal(int charCode, bool inCharGroup)
        {
            return RegexUtilities.EscapeInternal(charCode, inCharGroup);
        }

        public static string Char(AsciiChar value)
        {
            return Char(value, false);
        }

        public static string Char(AsciiChar value, bool inCharGroup)
        {
            return RegexUtilities.EscapeInternal((int)value, inCharGroup);
        }

        public static string Char(char value)
        {
            return Char(value, false);
        }

        public static string Char(IEnumerable<char> values)
        {
            return Char(values, false);
        }

        public static string Char(IEnumerable<char> values, bool inCharGroup)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            return string.Concat(values.Select(f => Char(f, inCharGroup)));
        }

        public static string Char(IEnumerable<int> charCodes)
        {
            return Char(charCodes, false);
        }

        public static string Char(IEnumerable<int> charCodes, bool inCharGroup)
        {
            if (charCodes == null)
            {
                throw new ArgumentNullException("charCodes");
            }
            return string.Concat(charCodes.Select(f => Char(f, inCharGroup)));
        }

        public static string Char(IEnumerable<AsciiChar> values)
        {
            return Char(values, false);
        }

        public static string Char(IEnumerable<AsciiChar> values, bool inCharGroup)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }
            return string.Concat(values.Select(f => Char(f, inCharGroup)));
        }

        public static string Unicode(char value)
        {
            return UnicodeInternal((int)value);
        }

        public static string Unicode(int charCode)
        {
            if (charCode < 0 || charCode > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("charCode");
            }
            return UnicodeInternal(charCode);
        }

        internal static string UnicodeInternal(int charCode)
        {
            return HexUnicodeStart + charCode.ToString("X4", CultureInfo.InvariantCulture);
        }

        public static string NamedBlock(NamedBlock block)
        {
            return NamedBlock(block, false);
        }

        public static string NotNamedBlock(NamedBlock block)
        {
            return NamedBlock(block, true);
        }

        public static string NamedBlock(NamedBlock block, bool negative)
        {
            return (negative ? NotUnicodeStart : UnicodeStart) + GetNamedBlockValue(block) + UnicodeEnd;
        }

        public static string NamedBlocks(IEnumerable<NamedBlock> blocks)
        {
            return NamedBlocks(blocks, false);
        }

        public static string NamedBlocks(IEnumerable<NamedBlock> blocks, bool negative)
        {
            if (blocks == null)
            {
                throw new ArgumentNullException("blocks");
            }
            return string.Concat(blocks.Select(f => NamedBlock(f, negative)));
        }

        public static string GeneralCategory(GeneralCategory category)
        {
            return GeneralCategory(category, false);
        }

        public static string NotGeneralCategory(GeneralCategory category)
        {
            return GeneralCategory(category, true);
        }

        public static string GeneralCategory(GeneralCategory category, bool negative)
        {
            return (negative ? NotUnicodeStart : UnicodeStart) + GetGeneralCategoryValue(category) + UnicodeEnd;
        }

        public static string GeneralCategories(IEnumerable<GeneralCategory> categories)
        {
            return GeneralCategories(categories, false);
        }

        public static string GeneralCategories(IEnumerable<GeneralCategory> categories, bool negative)
        {
            if (categories == null)
            {
                throw new ArgumentNullException("categories");
            }
            return string.Concat(categories.Select(f => GeneralCategory(f, negative)));
        }

        public static string Count(int exactCount)
        {
            if (exactCount < 0)
            {
                throw new ArgumentOutOfRangeException("exactCount");
            }
            return "{" + exactCount + "}";
        }

        public static string CountFrom(int minCount)
        {
            if (minCount < 0)
            {
                throw new ArgumentOutOfRangeException("minCount");
            }
            return "{" + minCount + ",}";
        }

        public static string CountRange(int minCount, int maxCount)
        {
            if (minCount < 0)
            {
                throw new ArgumentOutOfRangeException("minCount");
            }
            if (maxCount < minCount)
            {
                throw new ArgumentOutOfRangeException("maxCount");
            }
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
        public static string GetGeneralCategoryValue(GeneralCategory category)
        {
            switch (category)
            {
                case Builder.GeneralCategory.AllControlCharacters:
                    return "C";
                case Builder.GeneralCategory.AllDiacriticMarks:
                    return "M";
                case Builder.GeneralCategory.AllLetterCharacters:
                    return "L";
                case Builder.GeneralCategory.AllNumbers:
                    return "N";
                case Builder.GeneralCategory.AllPunctuationCharacters:
                    return "P";
                case Builder.GeneralCategory.AllSeparatorCharacters:
                    return "Z";
                case Builder.GeneralCategory.AllSymbols:
                    return "S";
                case Builder.GeneralCategory.LetterLowercase:
                    return "Ll";
                case Builder.GeneralCategory.LetterModifier:
                    return "Lm";
                case Builder.GeneralCategory.LetterOther:
                    return "Lo";
                case Builder.GeneralCategory.LetterTitlecase:
                    return "Lt";
                case Builder.GeneralCategory.LetterUppercase:
                    return "Lu";
                case Builder.GeneralCategory.MarkEnclosing:
                    return "Me";
                case Builder.GeneralCategory.MarkNonspacing:
                    return "Mn";
                case Builder.GeneralCategory.MarkSpacingCombining:
                    return "Mc";
                case Builder.GeneralCategory.NumberDecimalDigit:
                    return "Nd";
                case Builder.GeneralCategory.NumberLetter:
                    return "Nl";
                case Builder.GeneralCategory.NumberOther:
                    return "No";
                case Builder.GeneralCategory.OtherControl:
                    return "Cc";
                case Builder.GeneralCategory.OtherFormat:
                    return "Cf";
                case Builder.GeneralCategory.OtherNotAssigned:
                    return "Cn";
                case Builder.GeneralCategory.OtherPrivateUse:
                    return "Co";
                case Builder.GeneralCategory.OtherSurrogate:
                    return "Cs";
                case Builder.GeneralCategory.PunctuationClose:
                    return "Pe";
                case Builder.GeneralCategory.PunctuationConnector:
                    return "Pc";
                case Builder.GeneralCategory.PunctuationDash:
                    return "Pd";
                case Builder.GeneralCategory.PunctuationFinalQuote:
                    return "Pf";
                case Builder.GeneralCategory.PunctuationInitialQuote:
                    return "Pi";
                case Builder.GeneralCategory.PunctuationOpen:
                    return "Ps";
                case Builder.GeneralCategory.PunctuationOther:
                    return "Po";
                case Builder.GeneralCategory.SeparatorLine:
                    return "Zl";
                case Builder.GeneralCategory.SeparatorParagraph:
                    return "Zp";
                case Builder.GeneralCategory.SeparatorSpace:
                    return "Zs";
                case Builder.GeneralCategory.SymbolCurrency:
                    return "Sc";
                case Builder.GeneralCategory.SymbolMath:
                    return "Sm";
                case Builder.GeneralCategory.SymbolModifier:
                    return "Sk";
                case Builder.GeneralCategory.SymbolOther:
                    return "So";
                default:
                    Debug.Assert(false);
                    return string.Empty;
            }
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        public static string GetNamedBlockValue(NamedBlock block)
        {
            switch (block)
            {
                case Builder.NamedBlock.AlphabeticPresentationForms:
                    return "IsAlphabeticPresentationForms";
                case Builder.NamedBlock.Arabic:
                    return "IsArabic";
                case Builder.NamedBlock.ArabicPresentationFormsA:
                    return "IsArabicPresentationForms-A";
                case Builder.NamedBlock.ArabicPresentationFormsB:
                    return "IsArabicPresentationForms-B";
                case Builder.NamedBlock.Armenian:
                    return "IsArmenian";
                case Builder.NamedBlock.Arrows:
                    return "IsArrows";
                case Builder.NamedBlock.BasicLatin:
                    return "IsBasicLatin";
                case Builder.NamedBlock.Bengali:
                    return "IsBengali";
                case Builder.NamedBlock.BlockElements:
                    return "IsBlockElements";
                case Builder.NamedBlock.Bopomofo:
                    return "IsBopomofo";
                case Builder.NamedBlock.BopomofoExtended:
                    return "IsBopomofoExtended";
                case Builder.NamedBlock.BoxDrawing:
                    return "IsBoxDrawing";
                case Builder.NamedBlock.BraillePatterns:
                    return "IsBraillePatterns";
                case Builder.NamedBlock.Buhid:
                    return "IsBuhid";
                case Builder.NamedBlock.CJKCompatibility:
                    return "IsCJKCompatibility";
                case Builder.NamedBlock.CJKCompatibilityForms:
                    return "IsCJKCompatibilityForms";
                case Builder.NamedBlock.CJKCompatibilityIdeographs:
                    return "IsCJKCompatibilityIdeographs";
                case Builder.NamedBlock.CJKRadicalsSupplement:
                    return "IsCJKRadicalsSupplement";
                case Builder.NamedBlock.CJKSymbolsAndPunctuation:
                    return "IsCJKSymbolsandPunctuation";
                case Builder.NamedBlock.CJKUnifiedIdeographs:
                    return "IsCJKUnifiedIdeographs";
                case Builder.NamedBlock.CJKUnifiedIdeographsExtensionA:
                    return "IsCJKUnifiedIdeographsExtensionA";
                case Builder.NamedBlock.CombiningDiacriticalMarks:
                    return "IsCombiningDiacriticalMarks";
                case Builder.NamedBlock.CombiningDiacriticalMarksForSymbols:
                    return "IsCombiningDiacriticalMarksforSymbols";
                case Builder.NamedBlock.CombiningHalfMarks:
                    return "IsCombiningHalfMarks";
                case Builder.NamedBlock.CombiningMarksForSymbols:
                    return "IsCombiningMarksforSymbols";
                case Builder.NamedBlock.ControlPictures:
                    return "IsControlPictures";
                case Builder.NamedBlock.CurrencySymbols:
                    return "IsCurrencySymbols";
                case Builder.NamedBlock.Cyrillic:
                    return "IsCyrillic";
                case Builder.NamedBlock.CyrillicSupplement:
                    return "IsCyrillicSupplement";
                case Builder.NamedBlock.Devanagari:
                    return "IsDevanagari";
                case Builder.NamedBlock.Dingbats:
                    return "IsDingbats";
                case Builder.NamedBlock.EnclosedAlphanumerics:
                    return "IsEnclosedAlphanumerics";
                case Builder.NamedBlock.EnclosedCJKLettersAndMonths:
                    return "IsEnclosedCJKLettersandMonths";
                case Builder.NamedBlock.Ethiopic:
                    return "IsEthiopic";
                case Builder.NamedBlock.GeneralPunctuation:
                    return "IsGeneralPunctuation";
                case Builder.NamedBlock.GeometricShapes:
                    return "IsGeometricShapes";
                case Builder.NamedBlock.Georgian:
                    return "IsGeorgian";
                case Builder.NamedBlock.Greek:
                    return "IsGreek";
                case Builder.NamedBlock.GreekAndCoptic:
                    return "IsGreekandCoptic";
                case Builder.NamedBlock.GreekExtended:
                    return "IsGreekExtended";
                case Builder.NamedBlock.Gujarati:
                    return "IsGujarati";
                case Builder.NamedBlock.Gurmukhi:
                    return "IsGurmukhi";
                case Builder.NamedBlock.HalfWidthAndFullWidthForms:
                    return "IsHalfwidthandFullwidthForms";
                case Builder.NamedBlock.HangulCompatibilityJamo:
                    return "IsHangulCompatibilityJamo";
                case Builder.NamedBlock.HangulJamo:
                    return "IsHangulJamo";
                case Builder.NamedBlock.HangulSyllables:
                    return "IsHangulSyllables";
                case Builder.NamedBlock.Hanunoo:
                    return "IsHanunoo";
                case Builder.NamedBlock.Hebrew:
                    return "IsHebrew";
                case Builder.NamedBlock.HighPrivateUseSurrogates:
                    return "IsHighPrivateUseSurrogates";
                case Builder.NamedBlock.HighSurrogates:
                    return "IsHighSurrogates";
                case Builder.NamedBlock.Hiragana:
                    return "IsHiragana";
                case Builder.NamedBlock.Cherokee:
                    return "IsCherokee";
                case Builder.NamedBlock.IdeographicDescriptionCharacters:
                    return "IsIdeographicDescriptionCharacters";
                case Builder.NamedBlock.IPAExtensions:
                    return "IsIPAExtensions";
                case Builder.NamedBlock.Kanbun:
                    return "IsKanbun";
                case Builder.NamedBlock.KangxiRadicals:
                    return "IsKangxiRadicals";
                case Builder.NamedBlock.Kannada:
                    return "IsKannada";
                case Builder.NamedBlock.Katakana:
                    return "IsKatakana";
                case Builder.NamedBlock.KatakanaPhoneticExtensions:
                    return "IsKatakanaPhoneticExtensions";
                case Builder.NamedBlock.Khmer:
                    return "IsKhmer";
                case Builder.NamedBlock.KhmerSymbols:
                    return "IsKhmerSymbols";
                case Builder.NamedBlock.Lao:
                    return "IsLao";
                case Builder.NamedBlock.Latin1Supplement:
                    return "IsLatin-1Supplement";
                case Builder.NamedBlock.LatinExtendedA:
                    return "IsLatinExtended-A";
                case Builder.NamedBlock.LatinExtendedAdditional:
                    return "IsLatinExtendedAdditional";
                case Builder.NamedBlock.LatinExtendedB:
                    return "IsLatinExtended-B";
                case Builder.NamedBlock.LetterLikeSymbols:
                    return "IsLetterlikeSymbols";
                case Builder.NamedBlock.Limbu:
                    return "IsLimbu";
                case Builder.NamedBlock.LowSurrogates:
                    return "IsLowSurrogates";
                case Builder.NamedBlock.Malayalam:
                    return "IsMalayalam";
                case Builder.NamedBlock.MathematicalOperators:
                    return "IsMathematicalOperators";
                case Builder.NamedBlock.MiscellaneousMathematicalSymbolsA:
                    return "IsMiscellaneousMathematicalSymbols-A";
                case Builder.NamedBlock.MiscellaneousMathematicalSymbolsB:
                    return "IsMiscellaneousMathematicalSymbols-B";
                case Builder.NamedBlock.MiscellaneousSymbols:
                    return "IsMiscellaneousSymbols";
                case Builder.NamedBlock.MiscellaneousSymbolsAndArrows:
                    return "IsMiscellaneousSymbolsandArrows";
                case Builder.NamedBlock.MiscellaneousTechnical:
                    return "IsMiscellaneousTechnical";
                case Builder.NamedBlock.Mongolian:
                    return "IsMongolian";
                case Builder.NamedBlock.Myanmar:
                    return "IsMyanmar";
                case Builder.NamedBlock.NumberForms:
                    return "IsNumberForms";
                case Builder.NamedBlock.Ogham:
                    return "IsOgham";
                case Builder.NamedBlock.OpticalCharacterRecognition:
                    return "IsOpticalCharacterRecognition";
                case Builder.NamedBlock.Oriya:
                    return "IsOriya";
                case Builder.NamedBlock.PhoneticExtensions:
                    return "IsPhoneticExtensions";
                case Builder.NamedBlock.PrivateUse:
                    return "IsPrivateUse";
                case Builder.NamedBlock.PrivateUseArea:
                    return "IsPrivateUseArea";
                case Builder.NamedBlock.Runic:
                    return "IsRunic";
                case Builder.NamedBlock.Sinhala:
                    return "IsSinhala";
                case Builder.NamedBlock.SmallFormVariants:
                    return "IsSmallFormVariants";
                case Builder.NamedBlock.SpacingModifierLetters:
                    return "IsSpacingModifierLetters";
                case Builder.NamedBlock.Specials:
                    return "IsSpecials";
                case Builder.NamedBlock.SuperscriptsAndSubscripts:
                    return "IsSuperscriptsandSubscripts";
                case Builder.NamedBlock.SupplementalArrowsA:
                    return "IsSupplementalArrows-A";
                case Builder.NamedBlock.SupplementalArrowsB:
                    return "IsSupplementalArrows-B";
                case Builder.NamedBlock.SupplementalMathematicalOperators:
                    return "IsSupplementalMathematicalOperators";
                case Builder.NamedBlock.Syriac:
                    return "IsSyriac";
                case Builder.NamedBlock.Tagalog:
                    return "IsTagalog";
                case Builder.NamedBlock.Tagbanwa:
                    return "IsTagbanwa";
                case Builder.NamedBlock.TaiLe:
                    return "IsTaiLe";
                case Builder.NamedBlock.Tamil:
                    return "IsTamil";
                case Builder.NamedBlock.Telugu:
                    return "IsTelugu";
                case Builder.NamedBlock.Thaana:
                    return "IsThaana";
                case Builder.NamedBlock.Thai:
                    return "IsThai";
                case Builder.NamedBlock.Tibetan:
                    return "IsTibetan";
                case Builder.NamedBlock.UnifiedCanadianAboriginalSyllabics:
                    return "IsUnifiedCanadianAboriginalSyllabics";
                case Builder.NamedBlock.VariationSelectors:
                    return "IsVariationSelectors";
                case Builder.NamedBlock.YijingHexagramSymbols:
                    return "IsYijingHexagramSymbols";
                case Builder.NamedBlock.YiRadicals:
                    return "IsYiRadicals";
                case Builder.NamedBlock.YiSyllables:
                    return "IsYiSyllables";
                default:
                    Debug.Assert(false);
                    return string.Empty;
            }
        }

        public static string SubstituteNamedGroup(string groupName)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            RegexUtilities.CheckGroupName(groupName);
            return SubstituteNamedGroupInternal(groupName);
        }

        internal static string SubstituteNamedGroupInternal(string groupName)
        {
            return "${" + groupName + "}";
        }
    }
}
