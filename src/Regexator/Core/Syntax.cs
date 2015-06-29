// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using Pihrtsoft.Text.RegularExpressions.Linq;

//TODO add xml comments

namespace Pihrtsoft.Text.RegularExpressions
{
    public static partial class Syntax
    {
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

        internal const string GroupStart = "(?";
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
        public const string Tab = @"\t";
        public const string Linefeed = @"\n";
        public const string VerticalTab = @"\v";
        public const string FormFeed = @"\f";
        public const string CarriageReturn = @"\r";
        public const string Escape = @"\e";

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

        public static string Assert(object content)
        {
            return AssertStart + Pattern.GetPattern(content) + GroupEnd;
        }

        public static string Assert(params object[] content)
        {
            return Assert((object)content);
        }

        public static string NotAssert(object content)
        {
            return NotAssertStart + Pattern.GetPattern(content) + GroupEnd;
        }

        public static string NotAssert(params object[] content)
        {
            return NotAssert((object)content);
        }

        public static string AssertBack(object content)
        {
            return AssertBackStart + Pattern.GetPattern(content) + GroupEnd;
        }

        public static string AssertBack(params object[] content)
        {
            return AssertBack((object)content);
        }

        public static string NotAssertBack(object content)
        {
            return NotAssertBackStart + Pattern.GetPattern(content) + GroupEnd;
        }

        public static string NotAssertBack(params object[] content)
        {
            return NotAssertBack((object)content);
        }

        public static string GroupReference(int groupNumber)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            return @"\" + groupNumber;
        }

        public static string GroupReference(string groupName, IdentifierBoundary separator)
        {
            RegexUtilities.CheckGroupName(groupName);

            return GroupReferenceInternal(groupName, separator);
        }

        internal static string GroupReferenceInternal(string groupName, IdentifierBoundary separator)
        {
            switch (separator)
            {
                case IdentifierBoundary.LessThanGreaterThan:
                    return @"\k<" + groupName + ">";
                case IdentifierBoundary.Apostrophe:
                    return @"\k'" + groupName + "'";
            }

            return null;
        }

        public static string NamedGroup(string groupName, IdentifierBoundary boundary, object content)
        {
            RegexUtilities.CheckGroupName(groupName);

            return NamedGroupStart(groupName, boundary) + Pattern.GetPattern(content) + GroupEnd;
        }

        public static string NamedGroup(string groupName, IdentifierBoundary boundary, params object[] content)
        {
            return NamedGroup(groupName, boundary, (object)content);
        }

        internal static string NamedGroupStart(string groupName, IdentifierBoundary boundary)
        {
            switch (boundary)
            {
                case IdentifierBoundary.LessThanGreaterThan:
                    return @"(?<" + groupName + @">";
                case IdentifierBoundary.Apostrophe:
                    return @"(?'" + groupName + @"'";
            }
            return null;
        }

        public static string BalancingGroup(string name1, string name2, IdentifierBoundary separator, object content)
        {
            RegexUtilities.CheckGroupName(name1, "name1");
            RegexUtilities.CheckGroupName(name2, "name2");

            return BalancingGroupStart(name1, name2, separator) + Pattern.GetPattern(content) + GroupEnd;
        }

        public static string BalancingGroup(string name1, string name2, IdentifierBoundary separator, params object[] content)
        {
            return BalancingGroup(name1, name2, separator, (object)content);
        }

        internal static string BalancingGroupStart(string name1, string name2, IdentifierBoundary separator)
        {
            switch (separator)
            {
                case IdentifierBoundary.LessThanGreaterThan:
                    return @"(?<" + name1 + "-" + name2 + @">";
                case IdentifierBoundary.Apostrophe:
                    return @"(?'" + name1 + "-" + name2 + @"'";
            }
            return null;
        }

        public static string Group(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            return "(" + Pattern.GetPattern(content) + GroupEnd;
        }

        public static string Group(params object[] content)
        {
            return Group((object)content);
        }

        public static string NoncapturingGroup()
        {
            return NoncapturingGroupStart + GroupEnd;
        }

        public static string NoncapturingGroup(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            return NoncapturingGroupStart + Pattern.GetPattern(content) + GroupEnd;
        }

        public static string NoncapturingGroup(params object[] content)
        {
            return NoncapturingGroup((object)content);
        }

        public static string NonbacktrackingGroup(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            return NonbacktrackingGroupStart + Pattern.GetPattern(content) + GroupEnd;
        }

        public static string NonbacktrackingGroup(params object[] content)
        {
            return NonbacktrackingGroup((object)content);
        }

        public static string GroupOptions(RegexOptions applyOptions, params object[] content)
        {
            return GroupOptions(applyOptions, (object)content);
        }

        public static string GroupOptions(RegexOptions applyOptions, object content)
        {
            return GroupOptions(applyOptions, RegexOptions.None, content);
        }

        public static string GroupOptions(RegexOptions applyOptions, RegexOptions disableOptions, params object[] content)
        {
            return GroupOptions(applyOptions, disableOptions, (object)content);
        }
        
        public static string GroupOptions(RegexOptions applyOptions, RegexOptions disableOptions, object content)
        {
            if (!RegexUtilities.IsValidInlineOptions(applyOptions))
            {
                throw new ArgumentNullException("applyOptions");
            }

            if (!RegexUtilities.IsValidInlineOptions(disableOptions))
            {
                throw new ArgumentNullException("disableOptions");
            }

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            string options = GetInlineChars(applyOptions, disableOptions);

            string text = Pattern.GetPattern(content);

            return (!string.IsNullOrEmpty(options))
                ? GroupStart + options + ":" + text + GroupEnd
                : text;
        }

        public static string CharGroup(string characters)
        {
            return CharGroup(characters, false);
        }

        public static string CharGroup(string characters, bool negative)
        {
            if (characters == null)
            {
                throw new ArgumentNullException("characters");
            }

            return CharGroupInternal(RegexUtilities.Escape(characters, true), negative);
        }

        internal static string CharGroupInternal(string characters, bool negative)
        {
            if (characters.Length == 0)
            {
                throw new ArgumentException("Character group cannot be empty.", "characters");
            }

            return (negative ? NotCharGroupStart : CharGroupStart) + characters + CharGroupEnd;
        }

        public static string CharClass(CharClass value)
        {
            switch (value)
            {
                case RegularExpressions.CharClass.Digit:
                    return Digit;
                case RegularExpressions.CharClass.WordChar:
                    return WordChar;
                case RegularExpressions.CharClass.WhiteSpace:
                    return WhiteSpace;
                case RegularExpressions.CharClass.NotDigit:
                    return NotDigit;
                case RegularExpressions.CharClass.NotWordChar:
                    return NotWordChar;
                case RegularExpressions.CharClass.NotWhiteSpace:
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
            return Character(first, true) + "-" + Character(last, true);
        }

        public static string Range(int firstCharCode, int lastCharCode)
        {
            return Character(firstCharCode, true) + "-" + Character(lastCharCode, true);
        }

        public static string Character(char value, bool inCharGroup)
        {
            return RegexUtilities.EscapeInternal((int)value, inCharGroup);
        }

        public static string Character(int charCode)
        {
            return Character(charCode, false);
        }

        public static string Character(int charCode, bool inCharGroup)
        {
            return RegexUtilities.Escape(charCode, inCharGroup);
        }

        public static string Character(AsciiChar value)
        {
            return Character(value, false);
        }

        public static string Character(AsciiChar value, bool inCharGroup)
        {
            return RegexUtilities.EscapeInternal((int)value, inCharGroup);
        }

        public static string Character(char value)
        {
            return Character(value, false);
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

        public static string Count(int minCount, int maxCount)
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

        public static string CountFrom(int minCount)
        {
            if (minCount < 0)
            {
                throw new ArgumentOutOfRangeException("minCount");
            }

            return "{" + minCount + ",}";
        }

        public static string CountTo(int maxCount)
        {
            if (maxCount < 0)
            {
                throw new ArgumentOutOfRangeException("maxCount");
            }

            return "{0," + maxCount + "}";
        }

        public static string Options(RegexOptions enableOptions)
        {
            return Options(enableOptions, RegexOptions.None);
        }

        public static string Options(RegexOptions applyOptions, RegexOptions disableOptions)
        {
            if (!RegexUtilities.IsValidInlineOptions(applyOptions))
            {
                throw new ArgumentNullException("applyOptions");
            }

            if (!RegexUtilities.IsValidInlineOptions(disableOptions))
            {
                throw new ArgumentNullException("disableOptions");
            }

            string options = GetInlineChars(applyOptions, disableOptions);

            return (!string.IsNullOrEmpty(options))
                ? GroupStart + options + GroupEnd
                : string.Empty;
        }

        internal static string GetInlineChars(RegexOptions applyOptions, RegexOptions disableOptions)
        {
            if (applyOptions != RegexOptions.None)
            {
                if (disableOptions != RegexOptions.None)
                {
                    return GetInlineChars(applyOptions) + "-" + GetInlineChars(disableOptions);
                }
                else
                {
                    return GetInlineChars(applyOptions);
                }
            }
            else if (disableOptions != RegexOptions.None)
            {
                return GetInlineChars(disableOptions);
            }

            return string.Empty;
        }

        internal static string GetInlineChars(RegexOptions options)
        {
            return options != RegexOptions.None
                ? new string(EnumerateInlineChars(options).ToArray())
                : string.Empty;
        }

        internal static IEnumerable<char> EnumerateInlineChars(RegexOptions options)
        {
            if ((options & RegexOptions.IgnoreCase) == RegexOptions.IgnoreCase)
            {
                yield return IgnoreCaseChar;
            }

            if ((options & RegexOptions.Multiline) == RegexOptions.Multiline)
            {
                yield return MultilineChar;
            }

            if ((options & RegexOptions.ExplicitCapture) == RegexOptions.ExplicitCapture)
            {
                yield return ExplicitCaptureChar;
            }

            if ((options & RegexOptions.Singleline) == RegexOptions.Singleline)
            {
                yield return SinglelineChar;
            }

            if ((options & RegexOptions.IgnorePatternWhitespace) == RegexOptions.IgnorePatternWhitespace)
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
                case RegularExpressions.GeneralCategory.AllControlCharacters:
                    return "C";
                case RegularExpressions.GeneralCategory.AllDiacriticMarks:
                    return "M";
                case RegularExpressions.GeneralCategory.AllLetterCharacters:
                    return "L";
                case RegularExpressions.GeneralCategory.AllNumbers:
                    return "N";
                case RegularExpressions.GeneralCategory.AllPunctuationCharacters:
                    return "P";
                case RegularExpressions.GeneralCategory.AllSeparatorCharacters:
                    return "Z";
                case RegularExpressions.GeneralCategory.AllSymbols:
                    return "S";
                case RegularExpressions.GeneralCategory.LetterLowercase:
                    return "Ll";
                case RegularExpressions.GeneralCategory.LetterModifier:
                    return "Lm";
                case RegularExpressions.GeneralCategory.LetterOther:
                    return "Lo";
                case RegularExpressions.GeneralCategory.LetterTitlecase:
                    return "Lt";
                case RegularExpressions.GeneralCategory.LetterUppercase:
                    return "Lu";
                case RegularExpressions.GeneralCategory.MarkEnclosing:
                    return "Me";
                case RegularExpressions.GeneralCategory.MarkNonspacing:
                    return "Mn";
                case RegularExpressions.GeneralCategory.MarkSpacingCombining:
                    return "Mc";
                case RegularExpressions.GeneralCategory.NumberDecimalDigit:
                    return "Nd";
                case RegularExpressions.GeneralCategory.NumberLetter:
                    return "Nl";
                case RegularExpressions.GeneralCategory.NumberOther:
                    return "No";
                case RegularExpressions.GeneralCategory.OtherControl:
                    return "Cc";
                case RegularExpressions.GeneralCategory.OtherFormat:
                    return "Cf";
                case RegularExpressions.GeneralCategory.OtherNotAssigned:
                    return "Cn";
                case RegularExpressions.GeneralCategory.OtherPrivateUse:
                    return "Co";
                case RegularExpressions.GeneralCategory.OtherSurrogate:
                    return "Cs";
                case RegularExpressions.GeneralCategory.PunctuationClose:
                    return "Pe";
                case RegularExpressions.GeneralCategory.PunctuationConnector:
                    return "Pc";
                case RegularExpressions.GeneralCategory.PunctuationDash:
                    return "Pd";
                case RegularExpressions.GeneralCategory.PunctuationFinalQuote:
                    return "Pf";
                case RegularExpressions.GeneralCategory.PunctuationInitialQuote:
                    return "Pi";
                case RegularExpressions.GeneralCategory.PunctuationOpen:
                    return "Ps";
                case RegularExpressions.GeneralCategory.PunctuationOther:
                    return "Po";
                case RegularExpressions.GeneralCategory.SeparatorLine:
                    return "Zl";
                case RegularExpressions.GeneralCategory.SeparatorParagraph:
                    return "Zp";
                case RegularExpressions.GeneralCategory.SeparatorSpace:
                    return "Zs";
                case RegularExpressions.GeneralCategory.SymbolCurrency:
                    return "Sc";
                case RegularExpressions.GeneralCategory.SymbolMath:
                    return "Sm";
                case RegularExpressions.GeneralCategory.SymbolModifier:
                    return "Sk";
                case RegularExpressions.GeneralCategory.SymbolOther:
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
                case RegularExpressions.NamedBlock.AlphabeticPresentationForms:
                    return "IsAlphabeticPresentationForms";
                case RegularExpressions.NamedBlock.Arabic:
                    return "IsArabic";
                case RegularExpressions.NamedBlock.ArabicPresentationFormsA:
                    return "IsArabicPresentationForms-A";
                case RegularExpressions.NamedBlock.ArabicPresentationFormsB:
                    return "IsArabicPresentationForms-B";
                case RegularExpressions.NamedBlock.Armenian:
                    return "IsArmenian";
                case RegularExpressions.NamedBlock.Arrows:
                    return "IsArrows";
                case RegularExpressions.NamedBlock.BasicLatin:
                    return "IsBasicLatin";
                case RegularExpressions.NamedBlock.Bengali:
                    return "IsBengali";
                case RegularExpressions.NamedBlock.BlockElements:
                    return "IsBlockElements";
                case RegularExpressions.NamedBlock.Bopomofo:
                    return "IsBopomofo";
                case RegularExpressions.NamedBlock.BopomofoExtended:
                    return "IsBopomofoExtended";
                case RegularExpressions.NamedBlock.BoxDrawing:
                    return "IsBoxDrawing";
                case RegularExpressions.NamedBlock.BraillePatterns:
                    return "IsBraillePatterns";
                case RegularExpressions.NamedBlock.Buhid:
                    return "IsBuhid";
                case RegularExpressions.NamedBlock.CJKCompatibility:
                    return "IsCJKCompatibility";
                case RegularExpressions.NamedBlock.CJKCompatibilityForms:
                    return "IsCJKCompatibilityForms";
                case RegularExpressions.NamedBlock.CJKCompatibilityIdeographs:
                    return "IsCJKCompatibilityIdeographs";
                case RegularExpressions.NamedBlock.CJKRadicalsSupplement:
                    return "IsCJKRadicalsSupplement";
                case RegularExpressions.NamedBlock.CJKSymbolsAndPunctuation:
                    return "IsCJKSymbolsandPunctuation";
                case RegularExpressions.NamedBlock.CJKUnifiedIdeographs:
                    return "IsCJKUnifiedIdeographs";
                case RegularExpressions.NamedBlock.CJKUnifiedIdeographsExtensionA:
                    return "IsCJKUnifiedIdeographsExtensionA";
                case RegularExpressions.NamedBlock.CombiningDiacriticalMarks:
                    return "IsCombiningDiacriticalMarks";
                case RegularExpressions.NamedBlock.CombiningDiacriticalMarksForSymbols:
                    return "IsCombiningDiacriticalMarksforSymbols";
                case RegularExpressions.NamedBlock.CombiningHalfMarks:
                    return "IsCombiningHalfMarks";
                case RegularExpressions.NamedBlock.CombiningMarksForSymbols:
                    return "IsCombiningMarksforSymbols";
                case RegularExpressions.NamedBlock.ControlPictures:
                    return "IsControlPictures";
                case RegularExpressions.NamedBlock.CurrencySymbols:
                    return "IsCurrencySymbols";
                case RegularExpressions.NamedBlock.Cyrillic:
                    return "IsCyrillic";
                case RegularExpressions.NamedBlock.CyrillicSupplement:
                    return "IsCyrillicSupplement";
                case RegularExpressions.NamedBlock.Devanagari:
                    return "IsDevanagari";
                case RegularExpressions.NamedBlock.Dingbats:
                    return "IsDingbats";
                case RegularExpressions.NamedBlock.EnclosedAlphanumerics:
                    return "IsEnclosedAlphanumerics";
                case RegularExpressions.NamedBlock.EnclosedCJKLettersAndMonths:
                    return "IsEnclosedCJKLettersandMonths";
                case RegularExpressions.NamedBlock.Ethiopic:
                    return "IsEthiopic";
                case RegularExpressions.NamedBlock.GeneralPunctuation:
                    return "IsGeneralPunctuation";
                case RegularExpressions.NamedBlock.GeometricShapes:
                    return "IsGeometricShapes";
                case RegularExpressions.NamedBlock.Georgian:
                    return "IsGeorgian";
                case RegularExpressions.NamedBlock.Greek:
                    return "IsGreek";
                case RegularExpressions.NamedBlock.GreekAndCoptic:
                    return "IsGreekandCoptic";
                case RegularExpressions.NamedBlock.GreekExtended:
                    return "IsGreekExtended";
                case RegularExpressions.NamedBlock.Gujarati:
                    return "IsGujarati";
                case RegularExpressions.NamedBlock.Gurmukhi:
                    return "IsGurmukhi";
                case RegularExpressions.NamedBlock.HalfWidthAndFullWidthForms:
                    return "IsHalfwidthandFullwidthForms";
                case RegularExpressions.NamedBlock.HangulCompatibilityJamo:
                    return "IsHangulCompatibilityJamo";
                case RegularExpressions.NamedBlock.HangulJamo:
                    return "IsHangulJamo";
                case RegularExpressions.NamedBlock.HangulSyllables:
                    return "IsHangulSyllables";
                case RegularExpressions.NamedBlock.Hanunoo:
                    return "IsHanunoo";
                case RegularExpressions.NamedBlock.Hebrew:
                    return "IsHebrew";
                case RegularExpressions.NamedBlock.HighPrivateUseSurrogates:
                    return "IsHighPrivateUseSurrogates";
                case RegularExpressions.NamedBlock.HighSurrogates:
                    return "IsHighSurrogates";
                case RegularExpressions.NamedBlock.Hiragana:
                    return "IsHiragana";
                case RegularExpressions.NamedBlock.Cherokee:
                    return "IsCherokee";
                case RegularExpressions.NamedBlock.IdeographicDescriptionCharacters:
                    return "IsIdeographicDescriptionCharacters";
                case RegularExpressions.NamedBlock.IPAExtensions:
                    return "IsIPAExtensions";
                case RegularExpressions.NamedBlock.Kanbun:
                    return "IsKanbun";
                case RegularExpressions.NamedBlock.KangxiRadicals:
                    return "IsKangxiRadicals";
                case RegularExpressions.NamedBlock.Kannada:
                    return "IsKannada";
                case RegularExpressions.NamedBlock.Katakana:
                    return "IsKatakana";
                case RegularExpressions.NamedBlock.KatakanaPhoneticExtensions:
                    return "IsKatakanaPhoneticExtensions";
                case RegularExpressions.NamedBlock.Khmer:
                    return "IsKhmer";
                case RegularExpressions.NamedBlock.KhmerSymbols:
                    return "IsKhmerSymbols";
                case RegularExpressions.NamedBlock.Lao:
                    return "IsLao";
                case RegularExpressions.NamedBlock.Latin1Supplement:
                    return "IsLatin-1Supplement";
                case RegularExpressions.NamedBlock.LatinExtendedA:
                    return "IsLatinExtended-A";
                case RegularExpressions.NamedBlock.LatinExtendedAdditional:
                    return "IsLatinExtendedAdditional";
                case RegularExpressions.NamedBlock.LatinExtendedB:
                    return "IsLatinExtended-B";
                case RegularExpressions.NamedBlock.LetterLikeSymbols:
                    return "IsLetterlikeSymbols";
                case RegularExpressions.NamedBlock.Limbu:
                    return "IsLimbu";
                case RegularExpressions.NamedBlock.LowSurrogates:
                    return "IsLowSurrogates";
                case RegularExpressions.NamedBlock.Malayalam:
                    return "IsMalayalam";
                case RegularExpressions.NamedBlock.MathematicalOperators:
                    return "IsMathematicalOperators";
                case RegularExpressions.NamedBlock.MiscellaneousMathematicalSymbolsA:
                    return "IsMiscellaneousMathematicalSymbols-A";
                case RegularExpressions.NamedBlock.MiscellaneousMathematicalSymbolsB:
                    return "IsMiscellaneousMathematicalSymbols-B";
                case RegularExpressions.NamedBlock.MiscellaneousSymbols:
                    return "IsMiscellaneousSymbols";
                case RegularExpressions.NamedBlock.MiscellaneousSymbolsAndArrows:
                    return "IsMiscellaneousSymbolsandArrows";
                case RegularExpressions.NamedBlock.MiscellaneousTechnical:
                    return "IsMiscellaneousTechnical";
                case RegularExpressions.NamedBlock.Mongolian:
                    return "IsMongolian";
                case RegularExpressions.NamedBlock.Myanmar:
                    return "IsMyanmar";
                case RegularExpressions.NamedBlock.NumberForms:
                    return "IsNumberForms";
                case RegularExpressions.NamedBlock.Ogham:
                    return "IsOgham";
                case RegularExpressions.NamedBlock.OpticalCharacterRecognition:
                    return "IsOpticalCharacterRecognition";
                case RegularExpressions.NamedBlock.Oriya:
                    return "IsOriya";
                case RegularExpressions.NamedBlock.PhoneticExtensions:
                    return "IsPhoneticExtensions";
                case RegularExpressions.NamedBlock.PrivateUse:
                    return "IsPrivateUse";
                case RegularExpressions.NamedBlock.PrivateUseArea:
                    return "IsPrivateUseArea";
                case RegularExpressions.NamedBlock.Runic:
                    return "IsRunic";
                case RegularExpressions.NamedBlock.Sinhala:
                    return "IsSinhala";
                case RegularExpressions.NamedBlock.SmallFormVariants:
                    return "IsSmallFormVariants";
                case RegularExpressions.NamedBlock.SpacingModifierLetters:
                    return "IsSpacingModifierLetters";
                case RegularExpressions.NamedBlock.Specials:
                    return "IsSpecials";
                case RegularExpressions.NamedBlock.SuperscriptsAndSubscripts:
                    return "IsSuperscriptsandSubscripts";
                case RegularExpressions.NamedBlock.SupplementalArrowsA:
                    return "IsSupplementalArrows-A";
                case RegularExpressions.NamedBlock.SupplementalArrowsB:
                    return "IsSupplementalArrows-B";
                case RegularExpressions.NamedBlock.SupplementalMathematicalOperators:
                    return "IsSupplementalMathematicalOperators";
                case RegularExpressions.NamedBlock.Syriac:
                    return "IsSyriac";
                case RegularExpressions.NamedBlock.Tagalog:
                    return "IsTagalog";
                case RegularExpressions.NamedBlock.Tagbanwa:
                    return "IsTagbanwa";
                case RegularExpressions.NamedBlock.TaiLe:
                    return "IsTaiLe";
                case RegularExpressions.NamedBlock.Tamil:
                    return "IsTamil";
                case RegularExpressions.NamedBlock.Telugu:
                    return "IsTelugu";
                case RegularExpressions.NamedBlock.Thaana:
                    return "IsThaana";
                case RegularExpressions.NamedBlock.Thai:
                    return "IsThai";
                case RegularExpressions.NamedBlock.Tibetan:
                    return "IsTibetan";
                case RegularExpressions.NamedBlock.UnifiedCanadianAboriginalSyllabics:
                    return "IsUnifiedCanadianAboriginalSyllabics";
                case RegularExpressions.NamedBlock.VariationSelectors:
                    return "IsVariationSelectors";
                case RegularExpressions.NamedBlock.YijingHexagramSymbols:
                    return "IsYijingHexagramSymbols";
                case RegularExpressions.NamedBlock.YiRadicals:
                    return "IsYiRadicals";
                case RegularExpressions.NamedBlock.YiSyllables:
                    return "IsYiSyllables";
                default:
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
