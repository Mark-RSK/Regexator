// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Patterns
    {
        internal static QuantifiablePattern Or(object left, object right)
        {
            return new OrContainer(left, right);
        }

        public static QuantifiablePattern IfGroup(string groupName, object trueContent)
        {
            return new IfGroup(groupName, trueContent);
        }

        public static QuantifiablePattern IfGroup(string groupName, object trueContent, object falseContent)
        {
            return new IfGroup(groupName, trueContent, falseContent);
        }

        public static QuantifiablePattern IfGroup(int groupNumber, object trueContent)
        {
            return new IfGroup(groupNumber, trueContent);
        }

        public static QuantifiablePattern IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            return new IfGroup(groupNumber, trueContent, falseContent);
        }

        public static QuantifiablePattern IfAssert(Pattern testContent, object trueContent)
        {
            return new IfAssert(testContent, trueContent);
        }

        public static QuantifiablePattern IfAssert(Pattern testContent, object trueContent, object falseContent)
        {
            return new IfAssert(testContent, trueContent, falseContent);
        }

        public static QuantifiablePattern Assert(object content)
        {
            return new Assert(content);
        }

        public static QuantifiablePattern Assert(params object[] content)
        {
            return Assert((object)content);
        }

        public static QuantifiablePattern NotAssert(object content)
        {
            return new NotAssert(content);
        }

        public static QuantifiablePattern NotAssert(params object[] content)
        {
            return NotAssert((object)content);
        }

        public static QuantifiablePattern AssertBack(object content)
        {
            return new AssertBack(content);
        }

        public static QuantifiablePattern AssertBack(params object[] content)
        {
            return AssertBack((object)content);
        }

        public static QuantifiablePattern NotAssertBack(object content)
        {
            return new NotAssertBack(content);
        }

        public static QuantifiablePattern NotAssertBack(params object[] content)
        {
            return NotAssertBack((object)content);
        }

        public static Pattern AssertSurround(object surroundContent, object content)
        {
            return AssertSurround(surroundContent, content, surroundContent);
        }

        public static Pattern AssertSurround(object contentBefore, object content, object contentAfter)
        {
            return new AssertSurround(contentBefore, content, contentAfter);
        }

        public static Pattern NotAssertSurround(object surroundContent, object content)
        {
            return NotAssertSurround(surroundContent, content, surroundContent);
        }

        public static Pattern NotAssertSurround(object contentBefore, object content, object contentAfter)
        {
            return new NotAssertSurround(contentBefore, content, contentAfter);
        }

        public static QuantifiablePattern StartOfInput()
        {
            return new StartOfInput();
        }

        public static QuantifiablePattern StartOfLine()
        {
            return new StartOfLine();
        }

        public static QuantifiablePattern StartOfLineInvariant()
        {
            return Options(InlineOptions.Multiline, StartOfLine());
        }

        public static QuantifiablePattern EndOfLine()
        {
            return new EndOfLine();
        }

        public static QuantifiablePattern EndOfLineInvariant()
        {
            return Options(InlineOptions.Multiline, EndOfLine());
        }

        public static Pattern EndOfLineOrBeforeCarriageReturn()
        {
            return new EndOfLineOrBeforeCarriageReturn();
        }

        public static Pattern EndOfLineOrBeforeCarriageReturnInvariant()
        {
            return new EndOfLineOrBeforeCarriageReturnInvariant();
        }

        public static Pattern EndOfInput()
        {
            return new EndOfInput();
        }

        public static QuantifiablePattern EndOrBeforeEndingNewLine()
        {
            return new EndOrBeforeEndingNewLine();
        }

        public static QuantifiablePattern PreviousMatchEnd()
        {
            return new PreviousMatchEnd();
        }

        public static QuantifiablePattern WordBoundary()
        {
            return new WordBoundary();
        }

        public static QuantifiablePattern NotWordBoundary()
        {
            return new NotWordBoundary();
        }

        public static QuantifiablePattern Word()
        {
            return Pattern.Surround(new WordBoundary(), WordChars()).AsNoncapturingGroup();
        }

        public static QuantifiablePattern Word(string text)
        {
            return Pattern.Surround(new WordBoundary(), text).AsNoncapturingGroup();
        }

        public static QuantifiablePattern Word(params string[] values)
        {
            return Pattern.Surround(new WordBoundary(), new AnyGroup(values)).AsNoncapturingGroup();
        }

        public static Pattern Line(object content)
        {
            return Pattern.Surround(new StartOfLine(), content, new EndOfLine());
        }

        public static Pattern Line(params object[] content)
        {
            return Line((object)content);
        }

        public static Pattern LineInvariant(object content)
        {
            return Pattern.Surround(new StartOfLineInvariant(), content, new EndOfLineInvariant());
        }

        public static Pattern EntireInput(object content)
        {
            return Pattern.Surround(new StartOfInput(), content, new EndOfInput());
        }

        public static Pattern EntireInput(params object[] content)
        {
            return EntireInput((object)content);
        }

        public static QuantifiablePattern Any(IEnumerable<object> values)
        {
            return new AnyGroup(values);
        }

        public static QuantifiablePattern Any(params object[] content)
        {
            return new AnyGroup(content);
        }

        public static QuantifiablePattern NamedGroup(string name, object content)
        {
            return new NamedGroup(name, content);
        }

        public static QuantifiablePattern NamedGroup(string name, params object[] content)
        {
            return NamedGroup(name, (object)content);
        }

        public static QuantifiablePattern CapturingGroup()
        {
            return new CapturingGroup(string.Empty);
        }

        public static QuantifiablePattern CapturingGroup(object content)
        {
            return new CapturingGroup(content);
        }

        public static QuantifiablePattern CapturingGroup(params object[] content)
        {
            return CapturingGroup((object)content);
        }

        public static QuantifiablePattern NoncapturingGroup(object content)
        {
            return new NoncapturingGroup(content);
        }

        public static QuantifiablePattern NoncapturingGroup(params object[] content)
        {
            return NoncapturingGroup((object)content);
        }

        public static QuantifiablePattern BalancingGroup(string name1, string name2, object content)
        {
            return new BalancingGroup(name1, name2, content);
        }

        public static QuantifiablePattern BalancingGroup(string name1, string name2, params object[] content)
        {
            return BalancingGroup(name1, name2, (object)content);
        }

        public static QuantifiablePattern NonbacktrackingGroup(object content)
        {
            return new NonbacktrackingGroup(content);
        }

        public static QuantifiablePattern NonbacktrackingGroup(params object[] content)
        {
            return NonbacktrackingGroup((object)content);
        }

        public static QuantifiedGroup Maybe(object content)
        {
            return new Maybe(content);
        }

        public static QuantifiedGroup Maybe(params object[] content)
        {
            return new Maybe((object)content);
        }

        public static QuantifiedGroup MaybeMany(object content)
        {
            return new MaybeMany(content);
        }

        public static QuantifiedGroup MaybeMany(params object[] content)
        {
            return new MaybeMany((object)content);
        }

        public static QuantifiedGroup OneMany(object content)
        {
            return new OneMany(content);
        }

        public static QuantifiedGroup OneMany(params object[] content)
        {
            return new OneMany((object)content);
        }

        public static QuantifiedGroup Count(int exactCount, object content)
        {
            return new Count(exactCount, content);
        }

        public static QuantifiedGroup Count(int minCount, int maxCount, object content)
        {
            return new Count(minCount, maxCount, content);
        }

        public static QuantifiedGroup Count(int exactCount, params object[] content)
        {
            return new Count(exactCount, (object)content);
        }

        public static QuantifiedGroup Count(int minCount, int maxCount, params object[] content)
        {
            return new Count(minCount, maxCount, (object)content);
        }

        public static QuantifiedGroup CountFrom(int minCount, object content)
        {
            return new CountFrom(minCount, content);
        }

        public static QuantifiedGroup CountFrom(int minCount, params object[] content)
        {
            return new CountFrom(minCount, (object)content);
        }

        public static QuantifiedGroup CountTo(int maxCount, object content)
        {
            return new CountTo(maxCount, content);
        }

        public static QuantifiedGroup CountTo(int maxCount, params object[] content)
        {
            return new CountTo(maxCount, (object)content);
        }

        public static QuantifiablePattern GroupReference(int groupNumber)
        {
            return new GroupNumberReference(groupNumber);
        }

        public static QuantifiablePattern GroupReference(string groupName)
        {
            return new GroupNameReference(groupName);
        }

        public static Pattern Options(InlineOptions applyOptions)
        {
            return new Options(applyOptions);
        }

        public static QuantifiablePattern Options(InlineOptions applyOptions, object content)
        {
            return new GroupOptions(applyOptions, content);
        }

        public static QuantifiablePattern Options(InlineOptions applyOptions, params object[] content)
        {
            return new GroupOptions(applyOptions, content);
        }

        public static Pattern Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return new Options(applyOptions, disableOptions);
        }

        public static QuantifiablePattern Options(InlineOptions applyOptions, InlineOptions disableOptions, object content)
        {
            return new GroupOptions(applyOptions, disableOptions, content);
        }

        public static QuantifiablePattern Options(InlineOptions applyOptions, InlineOptions disableOptions, params object[] content)
        {
            return new GroupOptions(applyOptions, disableOptions, content);
        }

        public static Pattern DisableOptions(InlineOptions options)
        {
            return new Options(InlineOptions.None, options);
        }

        public static QuantifiablePattern DisableOptions(InlineOptions options, object content)
        {
            return new GroupOptions(InlineOptions.None, options, content);
        }

        public static QuantifiablePattern DisableOptions(InlineOptions options, params object[] content)
        {
            return new GroupOptions(InlineOptions.None, options, content);
        }

        public static Pattern Comment(string value)
        {
            return new InlineComment(value);
        }

        public static CharacterPattern Char(char value)
        {
            return new CharPattern(value);
        }

        public static CharacterPattern Char(int charCode)
        {
            return new CharCodePattern(charCode);
        }

        public static CharacterPattern Char(AsciiChar value)
        {
            return new AsciiCharPattern(value);
        }

        public static CharacterPattern Char(NamedBlock block)
        {
            return new NamedBlockPattern(block);
        }

        public static CharacterPattern Char(GeneralCategory category)
        {
            return new GeneralCategoryPattern(category);
        }

        public static CharGroup Char(string characters)
        {
            return new CharactersGroup(characters);
        }

        public static CharGroup Char(CharGroupItem item)
        {
            return new CharGroupItemGroup(item);
        }

        public static CharGroup NotChar(char value)
        {
            return new CharacterGroup(value, true);
        }

        public static CharGroup NotChar(int charCode)
        {
            return new CharCodeGroup(charCode, true);
        }

        public static CharGroup NotChar(AsciiChar value)
        {
            return new AsciiCharGroup(value, true);
        }

        public static CharacterPattern NotChar(NamedBlock block)
        {
            return new NotNamedBlockPattern(block);
        }

        public static CharacterPattern NotChar(GeneralCategory category)
        {
            return new NotGeneralCategoryPattern(category);
        }

        public static CharGroup NotChar(string characters)
        {
            return new CharactersGroup(characters, true);
        }

        public static CharGroup NotChar(CharGroupItem item)
        {
            return new CharGroupItemGroup(item, true);
        }

        public static CharGroup Range(char first, char last)
        {
            return new CharRangeGroup(first, last);
        }

        public static CharGroup Range(int firstCharCode, int lastCharCode)
        {
            return new CharCodeRangeGroup(firstCharCode, lastCharCode);
        }

        public static CharGroup NotRange(char first, char last)
        {
            return new CharRangeGroup(first, last, true);
        }

        public static CharGroup NotRange(int firstCharCode, int lastCharCode)
        {
            return new CharCodeRangeGroup(firstCharCode, lastCharCode, true);
        }

        public static CharSubtraction Subtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup);
        }

        public static CharSubtraction NotSubtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new NotCharSubtraction(baseGroup, excludedGroup);
        }

        public static QuantifiablePattern Any()
        {
            return new AnyChar();
        }

        public static QuantifiedGroup Any(int count)
        {
            return new Count(count, Any());
        }

        public static QuantifiedGroup Any(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Any());
        }

        public static CharGroup AnyInvariant()
        {
            return Char(CharGroupItems.WhiteSpace().NotWhiteSpace());
        }

        public static QuantifiedGroup AnyInvariant(int count)
        {
            return new Count(count, AnyInvariant());
        }

        public static QuantifiedGroup AnyInvariant(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, AnyInvariant());
        }

        public static CharacterPattern Digit()
        {
            return new Digit();
        }

        public static QuantifiedGroup Digit(int count)
        {
            return new Count(count, Digit());
        }

        public static QuantifiedGroup Digit(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Digit());
        }

        public static CharacterPattern NotDigit()
        {
            return new NotDigit();
        }

        public static QuantifiedGroup NotDigit(int count)
        {
            return new Count(count, NotDigit());
        }

        public static QuantifiedGroup NotDigit(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotDigit());
        }

        public static CharacterPattern WhiteSpace()
        {
            return new WhiteSpace();
        }

        public static QuantifiedGroup WhiteSpace(int count)
        {
            return new Count(count, WhiteSpace());
        }

        public static QuantifiedGroup WhiteSpace(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, WhiteSpace());
        }

        public static CharacterPattern NotWhiteSpace()
        {
            return new NotWhiteSpace();
        }

        public static QuantifiedGroup NotWhiteSpace(int count)
        {
            return new Count(count, NotWhiteSpace());
        }

        public static QuantifiedGroup NotWhiteSpace(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotWhiteSpace());
        }

        public static CharacterPattern WordChar()
        {
            return new WordChar();
        }

        public static QuantifiedGroup WordChar(int count)
        {
            return new Count(count, WordChar());
        }

        public static QuantifiedGroup WordChar(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, WordChar());
        }

        public static CharacterPattern NotWordChar()
        {
            return new NotWordChar();
        }

        public static QuantifiedGroup NotWordChar(int count)
        {
            return new Count(count, NotWordChar());
        }

        public static QuantifiedGroup NotWordChar(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotWordChar());
        }

        public static QuantifiedGroup Digits()
        {
            return new OneMany(Digit());
        }

        public static QuantifiedGroup NotDigits()
        {
            return new OneMany(NotDigit());
        }

        public static QuantifiedGroup WhiteSpaces()
        {
            return new OneMany(WhiteSpace());
        }

        public static QuantifiedGroup NotWhiteSpaces()
        {
            return new OneMany(NotWhiteSpace());
        }

        public static QuantifiedGroup WordChars()
        {
            return new OneMany(WordChar());
        }

        public static QuantifiedGroup NotWordChars()
        {
            return new OneMany(NotWordChar());
        }

        public static CharGroup NewLineChar()
        {
            return Char(CharGroupItems.CarriageReturn().Linefeed());
        }

        public static QuantifiedGroup NewLineChar(int count)
        {
            return new Count(count, NewLineChar());
        }

        public static QuantifiedGroup NewLineChar(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NewLineChar());
        }

        public static CharGroup NotNewLineChar()
        {
            return NotChar(CharGroupItems.CarriageReturn().Linefeed());
        }

        public static QuantifiedGroup NotNewLineChar(int count)
        {
            return new Count(count, NotNewLineChar());
        }

        public static QuantifiedGroup NotNewLineChar(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotNewLineChar());
        }

        public static CharGroup Alphanumeric()
        {
            return Char(CharGroupItems.Alphanumeric());
        }

        public static QuantifiedGroup Alphanumeric(int count)
        {
            return new Count(count, Alphanumeric());
        }

        public static QuantifiedGroup Alphanumeric(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Alphanumeric());
        }

        public static CharGroup NotAlphanumeric()
        {
            return NotChar(CharGroupItems.Alphanumeric());
        }

        public static QuantifiedGroup NotAlphanumeric(int count)
        {
            return new Count(count, NotAlphanumeric());
        }

        public static QuantifiedGroup NotAlphanumeric(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotAlphanumeric());
        }

        public static CharGroup AlphanumericLower()
        {
            return Char(CharGroupItems.AlphanumericLower());
        }

        public static QuantifiedGroup AlphanumericLower(int count)
        {
            return new Count(count, AlphanumericLower());
        }

        public static QuantifiedGroup AlphanumericLower(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, AlphanumericLower());
        }

        public static CharGroup NotAlphanumericLower()
        {
            return NotChar(CharGroupItems.AlphanumericLower());
        }

        public static QuantifiedGroup NotAlphanumericLower(int count)
        {
            return new Count(count, NotAlphanumericLower());
        }

        public static QuantifiedGroup NotAlphanumericLower(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotAlphanumericLower());
        }

        public static CharGroup AlphanumericUpper()
        {
            return Char(CharGroupItems.AlphanumericUpper());
        }

        public static QuantifiedGroup AlphanumericUpper(int count)
        {
            return new Count(count, AlphanumericUpper());
        }

        public static QuantifiedGroup AlphanumericUpper(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, AlphanumericUpper());
        }

        public static CharGroup NotAlphanumericUpper()
        {
            return NotChar(CharGroupItems.AlphanumericUpper());
        }

        public static QuantifiedGroup NotAlphanumericUpper(int count)
        {
            return new Count(count, NotAlphanumericUpper());
        }

        public static QuantifiedGroup NotAlphanumericUpper(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotAlphanumericUpper());
        }

        public static CharGroup AlphanumericUnderscore()
        {
            return Char(CharGroupItems.AlphanumericUnderscore());
        }

        public static QuantifiedGroup AlphanumericUnderscore(int count)
        {
            return new Count(count, AlphanumericUnderscore());
        }

        public static QuantifiedGroup AlphanumericUnderscore(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, AlphanumericUnderscore());
        }

        public static CharGroup NotAlphanumericUnderscore()
        {
            return NotChar(CharGroupItems.AlphanumericUnderscore());
        }

        public static QuantifiedGroup NotAlphanumericUnderscore(int count)
        {
            return new Count(count, NotAlphanumericUnderscore());
        }

        public static QuantifiedGroup NotAlphanumericUnderscore(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotAlphanumericUnderscore());
        }

        public static CharGroup LatinLetter()
        {
            return Char(CharGroupItems.LatinLetter());
        }

        public static QuantifiedGroup LatinLetter(int count)
        {
            return new Count(count, LatinLetter());
        }

        public static QuantifiedGroup LatinLetter(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, LatinLetter());
        }

        public static CharGroup LatinLetterLower()
        {
            return Char(CharGroupItems.LatinLetterLower());
        }

        public static QuantifiedGroup LatinLetterLower(int count)
        {
            return new Count(count, LatinLetterLower());
        }

        public static QuantifiedGroup LatinLetterLower(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, LatinLetterLower());
        }

        public static CharGroup LatinLetterUpper()
        {
            return Char(CharGroupItems.LatinLetterUpper());
        }

        public static QuantifiedGroup LatinLetterUpper(int count)
        {
            return new Count(count, LatinLetterUpper());
        }

        public static QuantifiedGroup LatinLetterUpper(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, LatinLetterUpper());
        }

        public static CharGroup NotLatinLetter()
        {
            return NotChar(CharGroupItems.LatinLetter());
        }

        public static QuantifiedGroup NotLatinLetter(int count)
        {
            return new Count(count, NotLatinLetter());
        }

        public static QuantifiedGroup NotLatinLetter(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotLatinLetter());
        }

        public static CharGroup NotLatinLetterLower()
        {
            return NotChar(CharGroupItems.LatinLetterLower());
        }

        public static QuantifiedGroup NotLatinLetterLower(int count)
        {
            return new Count(count, NotLatinLetterLower());
        }

        public static QuantifiedGroup NotLatinLetterLower(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotLatinLetterLower());
        }

        public static CharGroup NotLatinLetterUpper()
        {
            return NotChar(CharGroupItems.LatinLetterUpper());
        }

        public static QuantifiedGroup NotLatinLetterUpper(int count)
        {
            return new Count(count, NotLatinLetterUpper());
        }

        public static QuantifiedGroup NotLatinLetterUpper(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotLatinLetterUpper());
        }

        public static CharGroup ArabicDigit()
        {
            return Char(CharGroupItems.ArabicDigit());
        }

        public static QuantifiedGroup ArabicDigit(int count)
        {
            return new Count(count, ArabicDigit());
        }

        public static QuantifiedGroup ArabicDigit(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, ArabicDigit());
        }

        public static CharGroup NotArabicDigit()
        {
            return NotChar(CharGroupItems.ArabicDigit());
        }

        public static QuantifiedGroup NotArabicDigit(int count)
        {
            return new Count(count, NotArabicDigit());
        }

        public static QuantifiedGroup NotArabicDigit(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotArabicDigit());
        }

        public static CharGroup HexadecimalDigit()
        {
            return Char(CharGroupItems.HexadecimalDigit());
        }

        public static QuantifiedGroup HexadecimalDigit(int count)
        {
            return new Count(count, HexadecimalDigit());
        }

        public static QuantifiedGroup HexadecimalDigit(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, HexadecimalDigit());
        }

        public static CharGroup NotHexadecimalDigit()
        {
            return NotChar(CharGroupItems.HexadecimalDigit());
        }

        public static QuantifiedGroup NotHexadecimalDigit(int count)
        {
            return new Count(count, NotHexadecimalDigit());
        }

        public static QuantifiedGroup NotHexadecimalDigit(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotHexadecimalDigit());
        }

        public static CharGroup Parenthesis()
        {
            return Char(CharGroupItems.Parenthesis());
        }

        public static QuantifiedGroup Parenthesis(int count)
        {
            return new Count(count, Parenthesis());
        }

        public static QuantifiedGroup Parenthesis(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, Parenthesis());
        }

        public static CharGroup NotParenthesis()
        {
            return NotChar(CharGroupItems.Parenthesis());
        }

        public static QuantifiedGroup NotParenthesis(int count)
        {
            return new Count(count, NotParenthesis());
        }

        public static QuantifiedGroup NotParenthesis(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotParenthesis());
        }

        public static CharGroup CurlyBracket()
        {
            return Char(CharGroupItems.CurlyBracket());
        }

        public static QuantifiedGroup CurlyBracket(int count)
        {
            return new Count(count, CurlyBracket());
        }

        public static QuantifiedGroup CurlyBracket(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, CurlyBracket());
        }

        public static CharGroup NotCurlyBracket()
        {
            return NotChar(CharGroupItems.CurlyBracket());
        }

        public static QuantifiedGroup NotCurlyBracket(int count)
        {
            return new Count(count, NotCurlyBracket());
        }

        public static QuantifiedGroup NotCurlyBracket(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotCurlyBracket());
        }

        public static CharGroup SquareBracket()
        {
            return Char(CharGroupItems.SquareBracket());
        }

        public static QuantifiedGroup SquareBracket(int count)
        {
            return new Count(count, SquareBracket());
        }

        public static QuantifiedGroup SquareBracket(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, SquareBracket());
        }

        public static CharGroup NotSquareBracket()
        {
            return NotChar(CharGroupItems.SquareBracket());
        }

        public static QuantifiedGroup NotSquareBracket(int count)
        {
            return new Count(count, NotSquareBracket());
        }

        public static QuantifiedGroup NotSquareBracket(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, NotSquareBracket());
        }

        public static CharSubtraction WhiteSpaceExceptNewLine()
        {
            return WhiteSpace().Except(NewLineChar());
        }

        public static QuantifiedGroup WhiteSpaceExceptNewLine(int count)
        {
            return new Count(count, WhiteSpaceExceptNewLine());
        }

        public static QuantifiedGroup WhiteSpaceExceptNewLine(int minCount, int maxCount)
        {
            return new Count(minCount, maxCount, WhiteSpaceExceptNewLine());
        }

        public static Pattern Apostrophes()
        {
            return Chars.Apostrophe().Apostrophe();
        }

        public static Pattern Apostrophes(object content)
        {
            return Pattern.Surround(AsciiChar.Apostrophe, content);
        }

        public static Pattern QuoteMarks()
        {
            return Chars.QuoteMark().QuoteMark();
        }

        public static Pattern QuoteMarks(object content)
        {
            return Pattern.Surround(AsciiChar.QuoteMark, content);
        }

        public static Pattern Parentheses()
        {
            return Chars.LeftParenthesis().RightParenthesis();
        }

        public static Pattern Parentheses(object content)
        {
            return Pattern.Surround(AsciiChar.LeftParenthesis, content, AsciiChar.RightParenthesis);
        }

        public static Pattern CurlyBrackets()
        {
            return Chars.LeftCurlyBracket().RightCurlyBracket();
        }

        public static Pattern CurlyBrackets(object content)
        {
            return Pattern.Surround(AsciiChar.LeftCurlyBracket, content, AsciiChar.RightCurlyBracket);
        }

        public static Pattern SquareBrackets()
        {
            return Chars.LeftSquareBracket().RightSquareBracket();
        }

        public static Pattern SquareBrackets(object content)
        {
            return Pattern.Surround(AsciiChar.LeftSquareBracket, content, AsciiChar.RightSquareBracket);
        }

        public static Pattern LessThanGreaterThan(object content)
        {
            return Pattern.Surround(AsciiChar.LessThan, content, AsciiChar.GreaterThan);
        }

        public static QuantifiedPattern While(char value)
        {
            return Char(value).MaybeMany();
        }

        public static QuantifiedPattern While(AsciiChar value)
        {
            return Char(value).MaybeMany();
        }

        public static QuantifiedPattern While(CharGroupItem item)
        {
            return Char(item).MaybeMany();
        }

        public static QuantifiedPattern WhileWhiteSpace()
        {
            return new WhiteSpace().MaybeMany();
        }

        public static QuantifiedPattern WhileNot(char value)
        {
            return NotChar(value).MaybeMany();
        }

        public static QuantifiedPattern WhileNot(AsciiChar value)
        {
            return NotChar(value).MaybeMany();
        }

        public static QuantifiedPattern WhileNot(CharGroupItem item)
        {
            return NotChar(item).MaybeMany();
        }

        public static QuantifiedPattern WhileNotNewLine()
        {
            return WhileNot(CharGroupItems.NewLineChar());
        }

#if DEBUG
        public static QuantifiablePattern GoTo(char value)
        {
            return NotChar(value).MaybeMany().Char(value).AsNoncapturingGroup();
        }

        public static QuantifiablePattern GoTo(AsciiChar value)
        {
            return NotChar(value).MaybeMany().Char(value).AsNoncapturingGroup();
        }
#endif

        public static Pattern Crawl()
        {
            return Any().MaybeMany().Lazy();
        }

        public static Pattern CrawlInvariant()
        {
            return AnyInvariant().MaybeMany().Lazy();
        }

        public static QuantifiablePattern NewLine()
        {
            return new NewLine();
        }

        public static QuantifiablePattern Never()
        {
            return new NotAssert(string.Empty);
        }

        public static QuantifiablePattern LinefeedWithoutCarriageReturn()
        {
            return new NotAssertBack(Chars.CarriageReturn()).Linefeed().AsNonbacktrackingGroup();
        }

        public static Pattern LeadingWhiteSpace()
        {
            return new StartOfLine().WhiteSpaceExceptNewLine().OneMany();
        }

        public static Pattern TrailingWhiteSpace()
        {
            return WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn();
        }

        public static QuantifiablePattern LeadingTrailingWhiteSpace()
        {
            return new AnyGroup(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        public static QuantifiablePattern WhiteSpaceLine()
        {
            return new StartOfLineInvariant().WhiteSpaceExceptNewLine().MaybeMany().NewLine() |
                new NewLine().Assert(new WhiteSpace().MaybeMany().EndOfInput());
        }

        public static QuantifiablePattern EmptyLine()
        {
            return new StartOfLineInvariant().NewLine() |
                new NewLine().Assert(new NewLine().MaybeMany().EndOfInput());
        }

        public static Pattern FirstLine()
        {
            return new StartOfInput().NotNewLineChar().MaybeMany();
        }

        internal static Pattern ValidGroupName()
        {
            return EntireInput(
                new CapturingGroup(Range('1', '9').ArabicDigit().MaybeMany()) |
                WordChar().Except(ArabicDigit()).WordChar().MaybeMany());
        }

        internal static Pattern TrimInlineComment()
        {
            return new StartOfInput().WhileNot(')');
        }
    }
}
