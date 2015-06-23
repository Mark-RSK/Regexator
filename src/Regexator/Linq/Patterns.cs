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
            return IfGroup(groupName, trueContent, null);
        }

        public static QuantifiablePattern IfGroup(string groupName, object trueContent, object falseContent)
        {
            return new IfGroup(groupName, trueContent, falseContent);
        }

        public static QuantifiablePattern IfGroup(int groupNumber, object trueContent)
        {
            return IfGroup(groupNumber, trueContent, null);
        }

        public static QuantifiablePattern IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            return new IfGroup(groupNumber, trueContent, falseContent);
        }

        public static QuantifiablePattern IfAssert(Pattern testContent, object trueContent)
        {
            return IfAssert(testContent, trueContent, null);
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
            return NoncapturingGroup(
                NotAssertBack(CarriageReturn()) +
                Assert(CarriageReturn().Maybe().EndOfLine()));
        }

        public static Pattern EndOfLineOrBeforeCarriageReturnInvariant()
        {
            return NoncapturingGroup(
                NotAssertBack(CarriageReturn()) +
                Assert(CarriageReturn().Maybe().EndOfLineInvariant()));
        }

        public static QuantifiablePattern EndOfInput()
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
            return Pattern.Surround(WordBoundary(), WordChars()).AsNoncapturingGroup();
        }

        public static QuantifiablePattern Word(string text)
        {
            return Pattern.Surround(WordBoundary(), text).AsNoncapturingGroup();
        }

        public static QuantifiablePattern Word(params string[] values)
        {
            return Pattern.Surround(WordBoundary(), Any(values)).AsNoncapturingGroup();
        }

        public static Pattern Line(object content)
        {
            return Pattern.Surround(StartOfLine(), content, EndOfLine());
        }

        public static Pattern Line(params object[] content)
        {
            return Line((object)content);
        }

        public static Pattern LineInvariant(object content)
        {
            return Pattern.Surround(StartOfLineInvariant(), content, EndOfLineInvariant());
        }

        public static Pattern EntireInput(object content)
        {
            return Pattern.Surround(StartOfInput(), content, EndOfInput());
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
            return Maybe((object)content);
        }

        public static QuantifiedGroup MaybeMany(object content)
        {
            return new MaybeMany(content);
        }

        public static QuantifiedGroup MaybeMany(params object[] content)
        {
            return MaybeMany((object)content);
        }

        public static QuantifiedGroup OneMany(object content)
        {
            return new OneMany(content);
        }

        public static QuantifiedGroup OneMany(params object[] content)
        {
            return OneMany((object)content);
        }

        public static QuantifiedGroup Count(int exactCount, object content)
        {
            return new Count(exactCount, content);
        }

        public static QuantifiedGroup Count(int exactCount, params object[] content)
        {
            return Count(exactCount, (object)content);
        }

        public static QuantifiedGroup Count(int minCount, int maxCount, object content)
        {
            return new Count(minCount, maxCount, content);
        }

        public static QuantifiedGroup Count(int minCount, int maxCount, params object[] content)
        {
            return Count(minCount, maxCount, (object)content);
        }

        public static QuantifiedGroup CountFrom(int minCount, object content)
        {
            return new CountFrom(minCount, content);
        }

        public static QuantifiedGroup CountFrom(int minCount, params object[] content)
        {
            return CountFrom(minCount, (object)content);
        }

        public static QuantifiedGroup CountTo(int maxCount, object content)
        {
            return new CountTo(maxCount, content);
        }

        public static QuantifiedGroup CountTo(int maxCount, params object[] content)
        {
            return CountTo(maxCount, (object)content);
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
            return Options(applyOptions, (object)content);
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
            return Options(applyOptions, disableOptions, (object)content);
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
            return Options(InlineOptions.None, options, (object)content);
        }

        public static Pattern Comment(string value)
        {
            return new InlineComment(value);
        }

        public static CharacterPattern Character(char value)
        {
            return new CharPattern(value);
        }

        public static CharacterPattern Character(int charCode)
        {
            return new CharCodePattern(charCode);
        }

        public static CharacterPattern Character(AsciiChar value)
        {
            return new AsciiCharPattern(value);
        }

        public static CharacterPattern Character(NamedBlock block)
        {
            return new NamedBlockPattern(block);
        }

        public static CharacterPattern Character(GeneralCategory category)
        {
            return new GeneralCategoryPattern(category);
        }

        public static CharGroup Character(string characters)
        {
            return new CharactersGroup(characters);
        }

        public static CharGroup Character(CharGroupItem item)
        {
            return new CharGroupItemGroup(item);
        }

        public static CharGroup NotCharacter(char value)
        {
            return new CharacterGroup(value, true);
        }

        public static CharGroup NotCharacter(int charCode)
        {
            return new CharCodeGroup(charCode, true);
        }

        public static CharGroup NotCharacter(AsciiChar value)
        {
            return new AsciiCharGroup(value, true);
        }

        public static CharacterPattern NotCharacter(NamedBlock block)
        {
            return new NotNamedBlockPattern(block);
        }

        public static CharacterPattern NotCharacter(GeneralCategory category)
        {
            return new NotGeneralCategoryPattern(category);
        }

        public static CharGroup NotCharacter(string characters)
        {
            return new CharactersGroup(characters, true);
        }

        public static CharGroup NotCharacter(CharGroupItem item)
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

        public static CharacterPattern Tab()
        {
            return Character(AsciiChar.Tab);
        }

        public static QuantifiedGroup Tab(int exactCount)
        {
            return Count(exactCount, Tab());
        }

        public static QuantifiedGroup Tab(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Tab());
        }

        public static QuantifiablePattern NotTab()
        {
            return NotCharacter(AsciiChar.Tab);
        }

        public static QuantifiedGroup NotTab(int exactCount)
        {
            return Count(exactCount, NotTab());
        }

        public static QuantifiedGroup NotTab(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotTab());
        }

        public static CharacterPattern Linefeed()
        {
            return Character(AsciiChar.Linefeed);
        }

        public static QuantifiedGroup Linefeed(int exactCount)
        {
            return Count(exactCount, Linefeed());
        }

        public static QuantifiedGroup Linefeed(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Linefeed());
        }

        public static QuantifiablePattern NotLinefeed()
        {
            return NotCharacter(AsciiChar.Linefeed);
        }

        public static QuantifiedGroup NotLinefeed(int exactCount)
        {
            return Count(exactCount, NotLinefeed());
        }

        public static QuantifiedGroup NotLinefeed(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLinefeed());
        }

        public static CharacterPattern CarriageReturn()
        {
            return Character(AsciiChar.CarriageReturn);
        }

        public static QuantifiedGroup CarriageReturn(int exactCount)
        {
            return Count(exactCount, CarriageReturn());
        }

        public static QuantifiedGroup CarriageReturn(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, CarriageReturn());
        }

        public static QuantifiablePattern NotCarriageReturn()
        {
            return NotCharacter(AsciiChar.CarriageReturn);
        }

        public static QuantifiedGroup NotCarriageReturn(int exactCount)
        {
            return Count(exactCount, NotCarriageReturn());
        }

        public static QuantifiedGroup NotCarriageReturn(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotCarriageReturn());
        }

        public static CharacterPattern Space()
        {
            return Character(AsciiChar.Space);
        }

        public static QuantifiedGroup Space(int exactCount)
        {
            return Count(exactCount, Space());
        }

        public static QuantifiedGroup Space(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Space());
        }

        public static QuantifiablePattern NotSpace()
        {
            return NotCharacter(AsciiChar.Space);
        }

        public static QuantifiedGroup NotSpace(int exactCount)
        {
            return Count(exactCount, NotSpace());
        }

        public static QuantifiedGroup NotSpace(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotSpace());
        }

        public static CharacterPattern ExclamationMark()
        {
            return Character(AsciiChar.ExclamationMark);
        }

        public static QuantifiedGroup ExclamationMark(int exactCount)
        {
            return Count(exactCount, ExclamationMark());
        }

        public static QuantifiedGroup ExclamationMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, ExclamationMark());
        }

        public static QuantifiablePattern NotExclamationMark()
        {
            return NotCharacter(AsciiChar.ExclamationMark);
        }

        public static QuantifiedGroup NotExclamationMark(int exactCount)
        {
            return Count(exactCount, NotExclamationMark());
        }

        public static QuantifiedGroup NotExclamationMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotExclamationMark());
        }

        public static CharacterPattern QuoteMark()
        {
            return Character(AsciiChar.QuoteMark);
        }

        public static QuantifiedGroup QuoteMark(int exactCount)
        {
            return Count(exactCount, QuoteMark());
        }

        public static QuantifiedGroup QuoteMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, QuoteMark());
        }

        public static QuantifiablePattern NotQuoteMark()
        {
            return NotCharacter(AsciiChar.QuoteMark);
        }

        public static QuantifiedGroup NotQuoteMark(int exactCount)
        {
            return Count(exactCount, NotQuoteMark());
        }

        public static QuantifiedGroup NotQuoteMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotQuoteMark());
        }

        public static CharacterPattern NumberSign()
        {
            return Character(AsciiChar.NumberSign);
        }

        public static QuantifiedGroup NumberSign(int exactCount)
        {
            return Count(exactCount, NumberSign());
        }

        public static QuantifiedGroup NumberSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NumberSign());
        }

        public static QuantifiablePattern NotNumberSign()
        {
            return NotCharacter(AsciiChar.NumberSign);
        }

        public static QuantifiedGroup NotNumberSign(int exactCount)
        {
            return Count(exactCount, NotNumberSign());
        }

        public static QuantifiedGroup NotNumberSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotNumberSign());
        }

        public static CharacterPattern Dollar()
        {
            return Character(AsciiChar.Dollar);
        }

        public static QuantifiedGroup Dollar(int exactCount)
        {
            return Count(exactCount, Dollar());
        }

        public static QuantifiedGroup Dollar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Dollar());
        }

        public static QuantifiablePattern NotDollar()
        {
            return NotCharacter(AsciiChar.Dollar);
        }

        public static QuantifiedGroup NotDollar(int exactCount)
        {
            return Count(exactCount, NotDollar());
        }

        public static QuantifiedGroup NotDollar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotDollar());
        }

        public static CharacterPattern Percent()
        {
            return Character(AsciiChar.Percent);
        }

        public static QuantifiedGroup Percent(int exactCount)
        {
            return Count(exactCount, Percent());
        }

        public static QuantifiedGroup Percent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Percent());
        }

        public static QuantifiablePattern NotPercent()
        {
            return NotCharacter(AsciiChar.Percent);
        }

        public static QuantifiedGroup NotPercent(int exactCount)
        {
            return Count(exactCount, NotPercent());
        }

        public static QuantifiedGroup NotPercent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotPercent());
        }

        public static CharacterPattern Ampersand()
        {
            return Character(AsciiChar.Ampersand);
        }

        public static QuantifiedGroup Ampersand(int exactCount)
        {
            return Count(exactCount, Ampersand());
        }

        public static QuantifiedGroup Ampersand(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Ampersand());
        }

        public static QuantifiablePattern NotAmpersand()
        {
            return NotCharacter(AsciiChar.Ampersand);
        }

        public static QuantifiedGroup NotAmpersand(int exactCount)
        {
            return Count(exactCount, NotAmpersand());
        }

        public static QuantifiedGroup NotAmpersand(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAmpersand());
        }

        public static CharacterPattern Apostrophe()
        {
            return Character(AsciiChar.Apostrophe);
        }

        public static QuantifiedGroup Apostrophe(int exactCount)
        {
            return Count(exactCount, Apostrophe());
        }

        public static QuantifiedGroup Apostrophe(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Apostrophe());
        }

        public static QuantifiablePattern NotApostrophe()
        {
            return NotCharacter(AsciiChar.Apostrophe);
        }

        public static QuantifiedGroup NotApostrophe(int exactCount)
        {
            return Count(exactCount, NotApostrophe());
        }

        public static QuantifiedGroup NotApostrophe(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotApostrophe());
        }

        public static CharacterPattern LeftParenthesis()
        {
            return Character(AsciiChar.LeftParenthesis);
        }

        public static QuantifiedGroup LeftParenthesis(int exactCount)
        {
            return Count(exactCount, LeftParenthesis());
        }

        public static QuantifiedGroup LeftParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LeftParenthesis());
        }

        public static QuantifiablePattern NotLeftParenthesis()
        {
            return NotCharacter(AsciiChar.LeftParenthesis);
        }

        public static QuantifiedGroup NotLeftParenthesis(int exactCount)
        {
            return Count(exactCount, NotLeftParenthesis());
        }

        public static QuantifiedGroup NotLeftParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLeftParenthesis());
        }

        public static CharacterPattern RightParenthesis()
        {
            return Character(AsciiChar.RightParenthesis);
        }

        public static QuantifiedGroup RightParenthesis(int exactCount)
        {
            return Count(exactCount, RightParenthesis());
        }

        public static QuantifiedGroup RightParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, RightParenthesis());
        }

        public static QuantifiablePattern NotRightParenthesis()
        {
            return NotCharacter(AsciiChar.RightParenthesis);
        }

        public static QuantifiedGroup NotRightParenthesis(int exactCount)
        {
            return Count(exactCount, NotRightParenthesis());
        }

        public static QuantifiedGroup NotRightParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotRightParenthesis());
        }

        public static CharacterPattern Asterisk()
        {
            return Character(AsciiChar.Asterisk);
        }

        public static QuantifiedGroup Asterisk(int exactCount)
        {
            return Count(exactCount, Asterisk());
        }

        public static QuantifiedGroup Asterisk(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Asterisk());
        }

        public static QuantifiablePattern NotAsterisk()
        {
            return NotCharacter(AsciiChar.Asterisk);
        }

        public static QuantifiedGroup NotAsterisk(int exactCount)
        {
            return Count(exactCount, NotAsterisk());
        }

        public static QuantifiedGroup NotAsterisk(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAsterisk());
        }

        public static CharacterPattern Plus()
        {
            return Character(AsciiChar.Plus);
        }

        public static QuantifiedGroup Plus(int exactCount)
        {
            return Count(exactCount, Plus());
        }

        public static QuantifiedGroup Plus(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Plus());
        }

        public static QuantifiablePattern NotPlus()
        {
            return NotCharacter(AsciiChar.Plus);
        }

        public static QuantifiedGroup NotPlus(int exactCount)
        {
            return Count(exactCount, NotPlus());
        }

        public static QuantifiedGroup NotPlus(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotPlus());
        }

        public static CharacterPattern Comma()
        {
            return Character(AsciiChar.Comma);
        }

        public static QuantifiedGroup Comma(int exactCount)
        {
            return Count(exactCount, Comma());
        }

        public static QuantifiedGroup Comma(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Comma());
        }

        public static QuantifiablePattern NotComma()
        {
            return NotCharacter(AsciiChar.Comma);
        }

        public static QuantifiedGroup NotComma(int exactCount)
        {
            return Count(exactCount, NotComma());
        }

        public static QuantifiedGroup NotComma(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotComma());
        }

        public static CharacterPattern Hyphen()
        {
            return Character(AsciiChar.Hyphen);
        }

        public static QuantifiedGroup Hyphen(int exactCount)
        {
            return Count(exactCount, Hyphen());
        }

        public static QuantifiedGroup Hyphen(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Hyphen());
        }

        public static QuantifiablePattern NotHyphen()
        {
            return NotCharacter(AsciiChar.Hyphen);
        }

        public static QuantifiedGroup NotHyphen(int exactCount)
        {
            return Count(exactCount, NotHyphen());
        }

        public static QuantifiedGroup NotHyphen(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotHyphen());
        }

        public static CharacterPattern Period()
        {
            return Character(AsciiChar.Period);
        }

        public static QuantifiedGroup Period(int exactCount)
        {
            return Count(exactCount, Period());
        }

        public static QuantifiedGroup Period(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Period());
        }

        public static QuantifiablePattern NotPeriod()
        {
            return NotCharacter(AsciiChar.Period);
        }

        public static QuantifiedGroup NotPeriod(int exactCount)
        {
            return Count(exactCount, NotPeriod());
        }

        public static QuantifiedGroup NotPeriod(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotPeriod());
        }

        public static CharacterPattern Slash()
        {
            return Character(AsciiChar.Slash);
        }

        public static QuantifiedGroup Slash(int exactCount)
        {
            return Count(exactCount, Slash());
        }

        public static QuantifiedGroup Slash(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Slash());
        }

        public static QuantifiablePattern NotSlash()
        {
            return NotCharacter(AsciiChar.Slash);
        }

        public static QuantifiedGroup NotSlash(int exactCount)
        {
            return Count(exactCount, NotSlash());
        }

        public static QuantifiedGroup NotSlash(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotSlash());
        }

        public static CharacterPattern Colon()
        {
            return Character(AsciiChar.Colon);
        }

        public static QuantifiedGroup Colon(int exactCount)
        {
            return Count(exactCount, Colon());
        }

        public static QuantifiedGroup Colon(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Colon());
        }

        public static QuantifiablePattern NotColon()
        {
            return NotCharacter(AsciiChar.Colon);
        }

        public static QuantifiedGroup NotColon(int exactCount)
        {
            return Count(exactCount, NotColon());
        }

        public static QuantifiedGroup NotColon(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotColon());
        }

        public static CharacterPattern Semicolon()
        {
            return Character(AsciiChar.Semicolon);
        }

        public static QuantifiedGroup Semicolon(int exactCount)
        {
            return Count(exactCount, Semicolon());
        }

        public static QuantifiedGroup Semicolon(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Semicolon());
        }

        public static QuantifiablePattern NotSemicolon()
        {
            return NotCharacter(AsciiChar.Semicolon);
        }

        public static QuantifiedGroup NotSemicolon(int exactCount)
        {
            return Count(exactCount, NotSemicolon());
        }

        public static QuantifiedGroup NotSemicolon(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotSemicolon());
        }

        public static CharacterPattern LessThan()
        {
            return Character(AsciiChar.LessThan);
        }

        public static QuantifiedGroup LessThan(int exactCount)
        {
            return Count(exactCount, LessThan());
        }

        public static QuantifiedGroup LessThan(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LessThan());
        }

        public static QuantifiablePattern NotLessThan()
        {
            return NotCharacter(AsciiChar.LessThan);
        }

        public static QuantifiedGroup NotLessThan(int exactCount)
        {
            return Count(exactCount, NotLessThan());
        }

        public static QuantifiedGroup NotLessThan(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLessThan());
        }

        public static CharacterPattern EqualsSign()
        {
            return Character(AsciiChar.EqualsSign);
        }

        public static QuantifiedGroup EqualsSign(int exactCount)
        {
            return Count(exactCount, EqualsSign());
        }

        public static QuantifiedGroup EqualsSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EqualsSign());
        }

        public static QuantifiablePattern NotEqualsSign()
        {
            return NotCharacter(AsciiChar.EqualsSign);
        }

        public static QuantifiedGroup NotEqualsSign(int exactCount)
        {
            return Count(exactCount, NotEqualsSign());
        }

        public static QuantifiedGroup NotEqualsSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEqualsSign());
        }

        public static CharacterPattern GreaterThan()
        {
            return Character(AsciiChar.GreaterThan);
        }

        public static QuantifiedGroup GreaterThan(int exactCount)
        {
            return Count(exactCount, GreaterThan());
        }

        public static QuantifiedGroup GreaterThan(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, GreaterThan());
        }

        public static QuantifiablePattern NotGreaterThan()
        {
            return NotCharacter(AsciiChar.GreaterThan);
        }

        public static QuantifiedGroup NotGreaterThan(int exactCount)
        {
            return Count(exactCount, NotGreaterThan());
        }

        public static QuantifiedGroup NotGreaterThan(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotGreaterThan());
        }

        public static CharacterPattern QuestionMark()
        {
            return Character(AsciiChar.QuestionMark);
        }

        public static QuantifiedGroup QuestionMark(int exactCount)
        {
            return Count(exactCount, QuestionMark());
        }

        public static QuantifiedGroup QuestionMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, QuestionMark());
        }

        public static QuantifiablePattern NotQuestionMark()
        {
            return NotCharacter(AsciiChar.QuestionMark);
        }

        public static QuantifiedGroup NotQuestionMark(int exactCount)
        {
            return Count(exactCount, NotQuestionMark());
        }

        public static QuantifiedGroup NotQuestionMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotQuestionMark());
        }

        public static CharacterPattern At()
        {
            return Character(AsciiChar.At);
        }

        public static QuantifiedGroup At(int exactCount)
        {
            return Count(exactCount, At());
        }

        public static QuantifiedGroup At(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, At());
        }

        public static QuantifiablePattern NotAt()
        {
            return NotCharacter(AsciiChar.At);
        }

        public static QuantifiedGroup NotAt(int exactCount)
        {
            return Count(exactCount, NotAt());
        }

        public static QuantifiedGroup NotAt(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAt());
        }

        public static CharacterPattern LeftSquareBracket()
        {
            return Character(AsciiChar.LeftSquareBracket);
        }

        public static QuantifiedGroup LeftSquareBracket(int exactCount)
        {
            return Count(exactCount, LeftSquareBracket());
        }

        public static QuantifiedGroup LeftSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LeftSquareBracket());
        }

        public static QuantifiablePattern NotLeftSquareBracket()
        {
            return NotCharacter(AsciiChar.LeftSquareBracket);
        }

        public static QuantifiedGroup NotLeftSquareBracket(int exactCount)
        {
            return Count(exactCount, NotLeftSquareBracket());
        }

        public static QuantifiedGroup NotLeftSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLeftSquareBracket());
        }

        public static CharacterPattern Backslash()
        {
            return Character(AsciiChar.Backslash);
        }

        public static QuantifiedGroup Backslash(int exactCount)
        {
            return Count(exactCount, Backslash());
        }

        public static QuantifiedGroup Backslash(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Backslash());
        }

        public static QuantifiablePattern NotBackslash()
        {
            return NotCharacter(AsciiChar.Backslash);
        }

        public static QuantifiedGroup NotBackslash(int exactCount)
        {
            return Count(exactCount, NotBackslash());
        }

        public static QuantifiedGroup NotBackslash(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotBackslash());
        }

        public static CharacterPattern RightSquareBracket()
        {
            return Character(AsciiChar.RightSquareBracket);
        }

        public static QuantifiedGroup RightSquareBracket(int exactCount)
        {
            return Count(exactCount, RightSquareBracket());
        }

        public static QuantifiedGroup RightSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, RightSquareBracket());
        }

        public static QuantifiablePattern NotRightSquareBracket()
        {
            return NotCharacter(AsciiChar.RightSquareBracket);
        }

        public static QuantifiedGroup NotRightSquareBracket(int exactCount)
        {
            return Count(exactCount, NotRightSquareBracket());
        }

        public static QuantifiedGroup NotRightSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotRightSquareBracket());
        }

        public static CharacterPattern CircumflexAccent()
        {
            return Character(AsciiChar.CircumflexAccent);
        }

        public static QuantifiedGroup CircumflexAccent(int exactCount)
        {
            return Count(exactCount, CircumflexAccent());
        }

        public static QuantifiedGroup CircumflexAccent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, CircumflexAccent());
        }

        public static QuantifiablePattern NotCircumflexAccent()
        {
            return NotCharacter(AsciiChar.CircumflexAccent);
        }

        public static QuantifiedGroup NotCircumflexAccent(int exactCount)
        {
            return Count(exactCount, NotCircumflexAccent());
        }

        public static QuantifiedGroup NotCircumflexAccent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotCircumflexAccent());
        }

        public static CharacterPattern Underscore()
        {
            return Character(AsciiChar.Underscore);
        }

        public static QuantifiedGroup Underscore(int exactCount)
        {
            return Count(exactCount, Underscore());
        }

        public static QuantifiedGroup Underscore(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Underscore());
        }

        public static QuantifiablePattern NotUnderscore()
        {
            return NotCharacter(AsciiChar.Underscore);
        }

        public static QuantifiedGroup NotUnderscore(int exactCount)
        {
            return Count(exactCount, NotUnderscore());
        }

        public static QuantifiedGroup NotUnderscore(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotUnderscore());
        }

        public static CharacterPattern GraveAccent()
        {
            return Character(AsciiChar.GraveAccent);
        }

        public static QuantifiedGroup GraveAccent(int exactCount)
        {
            return Count(exactCount, GraveAccent());
        }

        public static QuantifiedGroup GraveAccent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, GraveAccent());
        }

        public static QuantifiablePattern NotGraveAccent()
        {
            return NotCharacter(AsciiChar.GraveAccent);
        }

        public static QuantifiedGroup NotGraveAccent(int exactCount)
        {
            return Count(exactCount, NotGraveAccent());
        }

        public static QuantifiedGroup NotGraveAccent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotGraveAccent());
        }

        public static CharacterPattern LeftCurlyBracket()
        {
            return Character(AsciiChar.LeftCurlyBracket);
        }

        public static QuantifiedGroup LeftCurlyBracket(int exactCount)
        {
            return Count(exactCount, LeftCurlyBracket());
        }

        public static QuantifiedGroup LeftCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LeftCurlyBracket());
        }

        public static QuantifiablePattern NotLeftCurlyBracket()
        {
            return NotCharacter(AsciiChar.LeftCurlyBracket);
        }

        public static QuantifiedGroup NotLeftCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotLeftCurlyBracket());
        }

        public static QuantifiedGroup NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLeftCurlyBracket());
        }

        public static CharacterPattern VerticalLine()
        {
            return Character(AsciiChar.VerticalLine);
        }

        public static QuantifiedGroup VerticalLine(int exactCount)
        {
            return Count(exactCount, VerticalLine());
        }

        public static QuantifiedGroup VerticalLine(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, VerticalLine());
        }

        public static QuantifiablePattern NotVerticalLine()
        {
            return NotCharacter(AsciiChar.VerticalLine);
        }

        public static QuantifiedGroup NotVerticalLine(int exactCount)
        {
            return Count(exactCount, NotVerticalLine());
        }

        public static QuantifiedGroup NotVerticalLine(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotVerticalLine());
        }

        public static CharacterPattern RightCurlyBracket()
        {
            return Character(AsciiChar.RightCurlyBracket);
        }

        public static QuantifiedGroup RightCurlyBracket(int exactCount)
        {
            return Count(exactCount, RightCurlyBracket());
        }

        public static QuantifiedGroup RightCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, RightCurlyBracket());
        }

        public static QuantifiablePattern NotRightCurlyBracket()
        {
            return NotCharacter(AsciiChar.RightCurlyBracket);
        }

        public static QuantifiedGroup NotRightCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotRightCurlyBracket());
        }

        public static QuantifiedGroup NotRightCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotRightCurlyBracket());
        }

        public static CharacterPattern Tilde()
        {
            return Character(AsciiChar.Tilde);
        }

        public static QuantifiedGroup Tilde(int exactCount)
        {
            return Count(exactCount, Tilde());
        }

        public static QuantifiedGroup Tilde(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Tilde());
        }

        public static QuantifiablePattern NotTilde()
        {
            return NotCharacter(AsciiChar.Tilde);
        }

        public static QuantifiedGroup NotTilde(int exactCount)
        {
            return Count(exactCount, NotTilde());
        }

        public static QuantifiedGroup NotTilde(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotTilde());
        }

        public static QuantifiablePattern Any()
        {
            return new AnyChar();
        }

        public static QuantifiedGroup Any(int count)
        {
            return Count(count, Any());
        }

        public static QuantifiedGroup Any(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Any());
        }

        public static CharGroup AnyInvariant()
        {
            return Character(CharGroupItems.WhiteSpace().NotWhiteSpace());
        }

        public static QuantifiedGroup AnyInvariant(int count)
        {
            return Count(count, AnyInvariant());
        }

        public static QuantifiedGroup AnyInvariant(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AnyInvariant());
        }

        public static CharacterPattern Digit()
        {
            return new Digit();
        }

        public static QuantifiedGroup Digit(int count)
        {
            return Count(count, Digit());
        }

        public static QuantifiedGroup Digit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Digit());
        }

        public static QuantifiedGroup Digits()
        {
            return OneMany(Digit());
        }

        public static CharacterPattern NotDigit()
        {
            return new NotDigit();
        }

        public static QuantifiedGroup NotDigit(int count)
        {
            return Count(count, NotDigit());
        }

        public static QuantifiedGroup NotDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotDigit());
        }

        public static QuantifiedGroup NotDigits()
        {
            return OneMany(NotDigit());
        }

        public static CharacterPattern WhiteSpace()
        {
            return new WhiteSpace();
        }

        public static QuantifiedGroup WhiteSpace(int count)
        {
            return Count(count, WhiteSpace());
        }

        public static QuantifiedGroup WhiteSpace(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, WhiteSpace());
        }

        public static QuantifiedGroup WhiteSpaces()
        {
            return OneMany(WhiteSpace());
        }

        public static CharacterPattern NotWhiteSpace()
        {
            return new NotWhiteSpace();
        }

        public static QuantifiedGroup NotWhiteSpace(int count)
        {
            return Count(count, NotWhiteSpace());
        }

        public static QuantifiedGroup NotWhiteSpace(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotWhiteSpace());
        }

        public static QuantifiedGroup NotWhiteSpaces()
        {
            return OneMany(NotWhiteSpace());
        }

        public static CharacterPattern WordChar()
        {
            return new WordChar();
        }

        public static QuantifiedGroup WordChar(int count)
        {
            return Count(count, WordChar());
        }

        public static QuantifiedGroup WordChar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, WordChar());
        }

        public static QuantifiedGroup WordChars()
        {
            return OneMany(WordChar());
        }

        public static CharacterPattern NotWordChar()
        {
            return new NotWordChar();
        }

        public static QuantifiedGroup NotWordChar(int count)
        {
            return Count(count, NotWordChar());
        }

        public static QuantifiedGroup NotWordChar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotWordChar());
        }

        public static QuantifiedGroup NotWordChars()
        {
            return OneMany(NotWordChar());
        }

        public static CharGroup NewLineChar()
        {
            return Character(CharGroupItems.CarriageReturn().Linefeed());
        }

        public static QuantifiedGroup NewLineChar(int count)
        {
            return Count(count, NewLineChar());
        }

        public static QuantifiedGroup NewLineChar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NewLineChar());
        }

        public static CharGroup NotNewLineChar()
        {
            return NotCharacter(CharGroupItems.CarriageReturn().Linefeed());
        }

        public static QuantifiedGroup NotNewLineChar(int count)
        {
            return Count(count, NotNewLineChar());
        }

        public static QuantifiedGroup NotNewLineChar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotNewLineChar());
        }

        public static CharGroup Alphanumeric()
        {
            return Character(CharGroupItems.Alphanumeric());
        }

        public static QuantifiedGroup Alphanumeric(int count)
        {
            return Count(count, Alphanumeric());
        }

        public static QuantifiedGroup Alphanumeric(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Alphanumeric());
        }

        public static CharGroup NotAlphanumeric()
        {
            return NotCharacter(CharGroupItems.Alphanumeric());
        }

        public static QuantifiedGroup NotAlphanumeric(int count)
        {
            return Count(count, NotAlphanumeric());
        }

        public static QuantifiedGroup NotAlphanumeric(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAlphanumeric());
        }

        public static CharGroup AlphanumericLower()
        {
            return Character(CharGroupItems.AlphanumericLower());
        }

        public static QuantifiedGroup AlphanumericLower(int count)
        {
            return Count(count, AlphanumericLower());
        }

        public static QuantifiedGroup AlphanumericLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AlphanumericLower());
        }

        public static CharGroup NotAlphanumericLower()
        {
            return NotCharacter(CharGroupItems.AlphanumericLower());
        }

        public static QuantifiedGroup NotAlphanumericLower(int count)
        {
            return Count(count, NotAlphanumericLower());
        }

        public static QuantifiedGroup NotAlphanumericLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAlphanumericLower());
        }

        public static CharGroup AlphanumericUpper()
        {
            return Character(CharGroupItems.AlphanumericUpper());
        }

        public static QuantifiedGroup AlphanumericUpper(int count)
        {
            return Count(count, AlphanumericUpper());
        }

        public static QuantifiedGroup AlphanumericUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AlphanumericUpper());
        }

        public static CharGroup NotAlphanumericUpper()
        {
            return NotCharacter(CharGroupItems.AlphanumericUpper());
        }

        public static QuantifiedGroup NotAlphanumericUpper(int count)
        {
            return Count(count, NotAlphanumericUpper());
        }

        public static QuantifiedGroup NotAlphanumericUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAlphanumericUpper());
        }

        public static CharGroup AlphanumericUnderscore()
        {
            return Character(CharGroupItems.AlphanumericUnderscore());
        }

        public static QuantifiedGroup AlphanumericUnderscore(int count)
        {
            return Count(count, AlphanumericUnderscore());
        }

        public static QuantifiedGroup AlphanumericUnderscore(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AlphanumericUnderscore());
        }

        public static CharGroup NotAlphanumericUnderscore()
        {
            return NotCharacter(CharGroupItems.AlphanumericUnderscore());
        }

        public static QuantifiedGroup NotAlphanumericUnderscore(int count)
        {
            return Count(count, NotAlphanumericUnderscore());
        }

        public static QuantifiedGroup NotAlphanumericUnderscore(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAlphanumericUnderscore());
        }

        public static CharGroup LatinLetter()
        {
            return Character(CharGroupItems.LatinLetter());
        }

        public static QuantifiedGroup LatinLetter(int count)
        {
            return Count(count, LatinLetter());
        }

        public static QuantifiedGroup LatinLetter(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LatinLetter());
        }

        public static CharGroup NotLatinLetter()
        {
            return NotCharacter(CharGroupItems.LatinLetter());
        }

        public static QuantifiedGroup NotLatinLetter(int count)
        {
            return Count(count, NotLatinLetter());
        }

        public static QuantifiedGroup NotLatinLetter(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLatinLetter());
        }

        public static CharGroup LatinLetterLower()
        {
            return Character(CharGroupItems.LatinLetterLower());
        }

        public static QuantifiedGroup LatinLetterLower(int count)
        {
            return Count(count, LatinLetterLower());
        }

        public static QuantifiedGroup LatinLetterLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LatinLetterLower());
        }

        public static CharGroup NotLatinLetterLower()
        {
            return NotCharacter(CharGroupItems.LatinLetterLower());
        }

        public static QuantifiedGroup NotLatinLetterLower(int count)
        {
            return Count(count, NotLatinLetterLower());
        }

        public static QuantifiedGroup NotLatinLetterLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLatinLetterLower());
        }

        public static CharGroup LatinLetterUpper()
        {
            return Character(CharGroupItems.LatinLetterUpper());
        }

        public static QuantifiedGroup LatinLetterUpper(int count)
        {
            return Count(count, LatinLetterUpper());
        }

        public static QuantifiedGroup LatinLetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LatinLetterUpper());
        }

        public static CharGroup NotLatinLetterUpper()
        {
            return NotCharacter(CharGroupItems.LatinLetterUpper());
        }

        public static QuantifiedGroup NotLatinLetterUpper(int count)
        {
            return Count(count, NotLatinLetterUpper());
        }

        public static QuantifiedGroup NotLatinLetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLatinLetterUpper());
        }

        public static CharGroup ArabicDigit()
        {
            return Character(CharGroupItems.ArabicDigit());
        }

        public static QuantifiedGroup ArabicDigit(int count)
        {
            return Count(count, ArabicDigit());
        }

        public static QuantifiedGroup ArabicDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, ArabicDigit());
        }

        public static CharGroup NotArabicDigit()
        {
            return NotCharacter(CharGroupItems.ArabicDigit());
        }

        public static QuantifiedGroup NotArabicDigit(int count)
        {
            return Count(count, NotArabicDigit());
        }

        public static QuantifiedGroup NotArabicDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotArabicDigit());
        }

        public static CharGroup HexadecimalDigit()
        {
            return Character(CharGroupItems.HexadecimalDigit());
        }

        public static QuantifiedGroup HexadecimalDigit(int count)
        {
            return Count(count, HexadecimalDigit());
        }

        public static QuantifiedGroup HexadecimalDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, HexadecimalDigit());
        }

        public static CharGroup NotHexadecimalDigit()
        {
            return NotCharacter(CharGroupItems.HexadecimalDigit());
        }

        public static QuantifiedGroup NotHexadecimalDigit(int count)
        {
            return Count(count, NotHexadecimalDigit());
        }

        public static QuantifiedGroup NotHexadecimalDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotHexadecimalDigit());
        }

        public static CharGroup Parenthesis()
        {
            return Character(CharGroupItems.Parenthesis());
        }

        public static QuantifiedGroup Parenthesis(int count)
        {
            return Count(count, Parenthesis());
        }

        public static QuantifiedGroup Parenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Parenthesis());
        }

        public static CharGroup NotParenthesis()
        {
            return NotCharacter(CharGroupItems.Parenthesis());
        }

        public static QuantifiedGroup NotParenthesis(int count)
        {
            return Count(count, NotParenthesis());
        }

        public static QuantifiedGroup NotParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotParenthesis());
        }

        public static CharGroup CurlyBracket()
        {
            return Character(CharGroupItems.CurlyBracket());
        }

        public static QuantifiedGroup CurlyBracket(int count)
        {
            return Count(count, CurlyBracket());
        }

        public static QuantifiedGroup CurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, CurlyBracket());
        }

        public static CharGroup NotCurlyBracket()
        {
            return NotCharacter(CharGroupItems.CurlyBracket());
        }

        public static QuantifiedGroup NotCurlyBracket(int count)
        {
            return Count(count, NotCurlyBracket());
        }

        public static QuantifiedGroup NotCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotCurlyBracket());
        }

        public static CharGroup SquareBracket()
        {
            return Character(CharGroupItems.SquareBracket());
        }

        public static QuantifiedGroup SquareBracket(int count)
        {
            return Count(count, SquareBracket());
        }

        public static QuantifiedGroup SquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, SquareBracket());
        }

        public static CharGroup NotSquareBracket()
        {
            return NotCharacter(CharGroupItems.SquareBracket());
        }

        public static QuantifiedGroup NotSquareBracket(int count)
        {
            return Count(count, NotSquareBracket());
        }

        public static QuantifiedGroup NotSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotSquareBracket());
        }

        public static CharSubtraction WhiteSpaceExceptNewLine()
        {
            return WhiteSpace().Except(NewLineChar());
        }

        public static QuantifiedGroup WhiteSpaceExceptNewLine(int count)
        {
            return Count(count, WhiteSpaceExceptNewLine());
        }

        public static QuantifiedGroup WhiteSpaceExceptNewLine(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, WhiteSpaceExceptNewLine());
        }

        public static Pattern Apostrophes()
        {
            return Apostrophe().Apostrophe();
        }

        public static Pattern Apostrophes(object content)
        {
            return Pattern.Surround(AsciiChar.Apostrophe, content);
        }

        public static Pattern QuoteMarks()
        {
            return QuoteMark().QuoteMark();
        }

        public static Pattern QuoteMarks(object content)
        {
            return Pattern.Surround(AsciiChar.QuoteMark, content);
        }

        public static Pattern Parentheses()
        {
            return LeftParenthesis().RightParenthesis();
        }

        public static Pattern Parentheses(object content)
        {
            return Pattern.Surround(AsciiChar.LeftParenthesis, content, AsciiChar.RightParenthesis);
        }

        public static Pattern CurlyBrackets()
        {
            return LeftCurlyBracket().RightCurlyBracket();
        }

        public static Pattern CurlyBrackets(object content)
        {
            return Pattern.Surround(AsciiChar.LeftCurlyBracket, content, AsciiChar.RightCurlyBracket);
        }

        public static Pattern SquareBrackets()
        {
            return LeftSquareBracket().RightSquareBracket();
        }

        public static Pattern SquareBrackets(object content)
        {
            return Pattern.Surround(AsciiChar.LeftSquareBracket, content, AsciiChar.RightSquareBracket);
        }

        public static Pattern LessThanGreaterThan(object content)
        {
            return Pattern.Surround(AsciiChar.LessThan, content, AsciiChar.GreaterThan);
        }

        public static QuantifiedPattern WhileChar(char value)
        {
            return Character(value).MaybeMany();
        }

        public static QuantifiedPattern WhileChar(AsciiChar value)
        {
            return Character(value).MaybeMany();
        }

        public static QuantifiedPattern WhileChar(CharGroupItem item)
        {
            return Character(item).MaybeMany();
        }

        public static QuantifiedPattern WhileWhiteSpace()
        {
            return WhiteSpace().MaybeMany();
        }

        public static QuantifiedPattern WhileNotChar(char value)
        {
            return NotCharacter(value).MaybeMany();
        }

        public static QuantifiedPattern WhileNotChar(AsciiChar value)
        {
            return NotCharacter(value).MaybeMany();
        }

        public static QuantifiedPattern WhileNotChar(CharGroupItem item)
        {
            return NotCharacter(item).MaybeMany();
        }

        public static QuantifiedPattern WhileNotNewLine()
        {
            return WhileNotChar(CharGroupItems.NewLineChar());
        }

#if DEBUG
        public static QuantifiablePattern GoToChar(char value)
        {
            return NotCharacter(value).MaybeMany().Character(value).AsNoncapturingGroup();
        }

        public static QuantifiablePattern GoToChar(AsciiChar value)
        {
            return NotCharacter(value).MaybeMany().Character(value).AsNoncapturingGroup();
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
            return CarriageReturn().Maybe().Linefeed().AsNoncapturingGroup();
        }

        public static QuantifiablePattern Never()
        {
            return NotAssert(string.Empty);
        }

        public static QuantifiablePattern LinefeedWithoutCarriageReturn()
        {
            return NotAssertBack(CarriageReturn()).Linefeed().AsNonbacktrackingGroup();
        }

        public static Pattern LeadingWhiteSpace()
        {
            return StartOfLine().WhiteSpaceExceptNewLine().OneMany();
        }

        public static Pattern TrailingWhiteSpace()
        {
            return WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn();
        }

        public static QuantifiablePattern LeadingTrailingWhiteSpace()
        {
            return Any(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        public static QuantifiablePattern WhiteSpaceLine()
        {
            return StartOfLineInvariant().WhiteSpaceExceptNewLine().MaybeMany().NewLine() |
                NewLine().Assert(WhiteSpace().MaybeMany().EndOfInput());
        }

        public static QuantifiablePattern EmptyLine()
        {
            return StartOfLineInvariant().NewLine() |
                NewLine().Assert(NewLine().MaybeMany().EndOfInput());
        }

        public static Pattern FirstLine()
        {
            return StartOfInput().NotNewLineChar().MaybeMany();
        }

        internal static Pattern ValidGroupName()
        {
            return EntireInput(
                CapturingGroup(Range('1', '9').ArabicDigit().MaybeMany()) |
                WordChar().Except(ArabicDigit()).WordChar().MaybeMany());
        }

        internal static Pattern TrimInlineComment()
        {
            return StartOfInput().WhileNotChar(')');
        }
    }
}
