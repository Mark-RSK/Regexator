// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static partial class Syntax
    {
        internal const string IfStart = "(?";
        internal const string InlineCommentStart = "(?#";

        public const string Or = "|";

        public const string StartOfInput = @"\A";
        public const string StartOfLine = "^";
        public const string EndOfInput = @"\z";
        public const string EndOfLine = "$";
        public const string EndOrBeforeEndingNewLine = @"\Z";
        public const string WordBoundary = @"\b";
        public const string NotWordBoundary = @"\B";
        public const string PreviousMatchEnd = @"\G";

        internal const string AssertStart = "(?=";
        internal const string NotAssertStart = "(?!";
        internal const string AssertBackStart = "(?<=";
        internal const string NotAssertBackStart = "(?<!";

        internal const string CapturingGroupStart = "(";
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

        internal static string IfGroupCondition(int groupNumber)
        {
            return IfGroupCondition(groupNumber.ToString(CultureInfo.InvariantCulture));
        }

        internal static string IfGroupCondition(string groupName)
        {
            return CapturingGroupStart + groupName + GroupEnd;
        }

        public static string Assert(string content)
        {
            return AssertStart + RegexUtilities.Escape(content) + GroupEnd;
        }

        public static string NotAssert(string content)
        {
            return NotAssertStart + RegexUtilities.Escape(content) + GroupEnd;
        }

        public static string AssertBack(string content)
        {
            return AssertBackStart + RegexUtilities.Escape(content) + GroupEnd;
        }

        public static string NotAssertBack(string content)
        {
            return NotAssertBackStart + RegexUtilities.Escape(content) + GroupEnd;
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

            RegexUtilities.CheckGroupName(groupName);

            return BackreferenceInternal(groupName, separator);
        }

        internal static string BackreferenceInternal(string groupName, IdentifierBoundary separator)
        {
            switch (separator)
            {
                case IdentifierBoundary.LessThan:
                    return @"\k<" + groupName + ">";
                case IdentifierBoundary.Apostrophe:
                    return @"\k'" + groupName + "'";
            }

            return null;
        }

        public static string Group(string groupName, string content, IdentifierBoundary boundary)
        {
            RegexUtilities.CheckGroupName(groupName);
            
            return GroupStart(groupName, boundary) + RegexUtilities.Escape(content) + GroupEnd;
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

        public static string BalanceGroup(string name1, string name2, string content, IdentifierBoundary separator)
        {
            RegexUtilities.CheckGroupName(name1);
            RegexUtilities.CheckGroupName(name2);

            return BalanceGroupStart(name1, name2, separator) + RegexUtilities.Escape(content) + GroupEnd;
        }

        internal static string BalanceGroupStart(string name1, string name2, IdentifierBoundary separator)
        {
            switch (separator)
            {
                case IdentifierBoundary.LessThan:
                    return @"(?<" + name1 + "-" + name2 + @">";
                case IdentifierBoundary.Apostrophe:
                    return @"(?'" + name1 + "-" + name2 + @"'";
            }
            return null;
        }

        public static string CapturingGroup(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            return CapturingGroupStart + RegexUtilities.Escape(content) + GroupEnd;
        }

        public static string NoncapturingGroup(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            return NoncapturingGroupStart + RegexUtilities.Escape(content) + GroupEnd;
        }

        public static string NonbacktrackingGroup(string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            return NonbacktrackingGroupStart + RegexUtilities.Escape(content) + GroupEnd;
        }

        public static string GroupOptions(InlineOptions applyOptions, string content)
        {
            return GroupOptions(applyOptions, InlineOptions.None, content);
        }

        public static string GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            string options = GetInlineChars(applyOptions, disableOptions);

            string text = RegexUtilities.Escape(content);

            return (!string.IsNullOrEmpty(options))
                ? "(?" + options + ":" + text + GroupEnd
                : text;
        }

        internal static string CharGroup(string value)
        {
            return CharGroup(value, false);
        }

        internal static string CharGroup(string content, bool negative)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (content.Length == 0)
            {
                throw new ArgumentException("Character group cannot be empty.", "content");
            }

            return (negative ? NotCharGroupStart : CharGroupStart) + RegexUtilities.Escape(content, true) + CharGroupEnd;
        }

        public static string CharClass(CharClass value)
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

        public static string CharClasses(IEnumerable<CharClass> values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            return string.Concat(values.Select(f => CharClass(f)));
        }

        public static string CharRange(char first, char last)
        {
            return Syntax.Char(first, true) + "-" + Syntax.Char(last, true);
        }

        public static string CharRange(int firstCharCode, int lastCharCode)
        {
            return Syntax.Char(firstCharCode, true) + "-" + Syntax.Char(lastCharCode, true);
        }

        internal static string RangeInternal(int firstCharCode, int lastCharCode)
        {
            return Syntax.CharInternal(firstCharCode, true) + "-" + Syntax.CharInternal(lastCharCode, true);
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

        public static string AsciiHexadecimal(int charCode)
        {
            if (charCode < 0 || charCode > 0xFF)
            {
                throw new ArgumentOutOfRangeException("charCode");
            }

            return AsciiStart + charCode.ToString("X2", CultureInfo.InvariantCulture);
        }

        public static string AsciiOctal(int charCode)
        {
            if (charCode < 0 || charCode > 0xFF)
            {
                throw new ArgumentOutOfRangeException("charCode");
            }

            return @"\" + Convert.ToString(charCode, 8).PadLeft(2, '0');
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
            string options = GetInlineChars(applyOptions, disableOptions);

            return (!string.IsNullOrEmpty(options))
                ? "(?" + options + GroupEnd
                : string.Empty;
        }

        internal static string GetInlineChars(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            if (applyOptions != InlineOptions.None)
            {
                if (disableOptions != InlineOptions.None)
                {
                    return GetInlineChars(applyOptions) + "-" + GetInlineChars(disableOptions);
                }
                else
                {
                    return GetInlineChars(applyOptions);
                }
            }
            else if (disableOptions != InlineOptions.None)
            {
                return GetInlineChars(disableOptions);
            }

            return string.Empty;
        }

        public static string GetInlineChars(InlineOptions options)
        {
            return options != InlineOptions.None
                ? new string(EnumerateInlineChars(options).ToArray())
                : string.Empty;
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

        public static string InlineComment(string comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }

            return InlineCommentStart + RegexUtilities.TrimInlineComment.Match(comment).Value + GroupEnd;
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
                    Debug.Assert(false);
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
                    Debug.Assert(false);
                    return string.Empty;
            }
        }

        public static string SubstituteNamedGroup(string groupName)
        {
            RegexUtilities.CheckGroupName(groupName);

            return SubstituteNamedGroupInternal(groupName);
        }

        internal static string SubstituteNamedGroupInternal(string groupName)
        {
            return "${" + groupName + "}";
        }
    }
}
