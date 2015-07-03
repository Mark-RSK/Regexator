// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

//TODO add xml comments

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Patterns
    {
        public static TPattern Not<TPattern>(IInvertible<TPattern> value) where TPattern : Pattern
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }

        internal static QuantifiablePattern Or(object left, object right)
        {
            if (left == null)
            {
                throw new ArgumentNullException("left");
            }

            if (right == null)
            {
                throw new ArgumentNullException("right");
            }

            return new OrContainer(left, right);
        }

        /// <summary>
        /// Returns an if construct with the specified pattern to test and a pattern to match if the test pattern is matched.
        /// </summary>
        /// <param name="testContent">The test pattern to match.</param>
        /// <param name="trueContent">The pattern to match if the test pattern is matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern IfAssert(object testContent, object trueContent)
        {
            return IfAssert(testContent, trueContent, null);
        }

        public static QuantifiablePattern IfAssert(object testContent, object trueContent, object falseContent)
        {
            return new IfAssert(testContent, trueContent, falseContent);
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

        /// <summary>
        /// Returns a zero-width positive lookahead assertion with a specified content.
        /// </summary>
        /// <param name="content">The object to be added as assertion content.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Assertion Assert(object content)
        {
            return new Assertion(content);
        }

        /// <summary>
        /// Returns a zero-width positive lookahead assertion with a specified content.
        /// </summary>
        /// <param name="content">An object array that contains zero or more objects to be added as assertion content.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Assertion Assert(params object[] content)
        {
            return Assert((object)content);
        }

        /// <summary>
        /// Returns a zero-width negative lookahead assertion with a specified content.
        /// </summary>
        /// <param name="content">The object to be added as assertion content.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern NotAssert(object content)
        {
            return new NegativeAssertion(content);
        }

        /// <summary>
        /// Returns a zero-width negative lookahead assertion with a specified content.
        /// </summary>
        /// <param name="content">An object array that contains zero or more objects to be added as assertion content.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern NotAssert(params object[] content)
        {
            return NotAssert((object)content);
        }

        /// <summary>
        /// Returns a zero-width positive lookbehind assertion with a specified content.
        /// </summary>
        /// <param name="content">The object to be added as assertion content.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static BackAssertion AssertBack(object content)
        {
            return new BackAssertion(content);
        }

        /// <summary>
        /// Returns a zero-width positive lookbehind assertion with a specified content.
        /// </summary>
        /// <param name="content">An object array that contains zero or more objects to be added as assertion content.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static BackAssertion AssertBack(params object[] content)
        {
            return AssertBack((object)content);
        }

        /// <summary>
        /// Returns a zero-width negative lookbehind assertion with a specified content.
        /// </summary>
        /// <param name="content">The object to be added as assertion content.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern NotAssertBack(object content)
        {
            return new NegativeBackAssertion(content);
        }

        /// <summary>
        /// Returns a zero-width negative lookbehind assertion with a specified content.
        /// </summary>
        /// <param name="content">An object array that contains zero or more objects to be added as assertion content.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern NotAssertBack(params object[] content)
        {
            return NotAssertBack((object)content);
        }

        public static SurroundAssertion AssertSurround(object surroundContent, object content)
        {
            return AssertSurround(surroundContent, content, surroundContent);
        }

        public static SurroundAssertion AssertSurround(object contentBefore, object content, object contentAfter)
        {
            return new SurroundAssertion(contentBefore, content, contentAfter);
        }

        public static NegativeSurroundAssertion NotAssertSurround(object surroundContent, object content)
        {
            return NotAssertSurround(surroundContent, content, surroundContent);
        }

        public static NegativeSurroundAssertion NotAssertSurround(object contentBefore, object content, object contentAfter)
        {
            return new NegativeSurroundAssertion(contentBefore, content, contentAfter);
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
            return Options(RegexOptions.Multiline, StartOfLine());
        }

        public static QuantifiablePattern EndOfLine()
        {
            return new EndOfLine();
        }

        public static QuantifiablePattern EndOfLineInvariant()
        {
            return Options(RegexOptions.Multiline, EndOfLine());
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

        public static WordBoundary WordBoundary()
        {
            return new WordBoundary();
        }

        public static NegativeWordBoundary NotWordBoundary()
        {
            return new NegativeWordBoundary();
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

        public static QuantifiablePattern Line(object content)
        {
            return Pattern.Surround(StartOfLine(), content, EndOfLine()).AsNoncapturingGroup();
        }

        public static QuantifiablePattern Line(params object[] content)
        {
            return Line((object)content);
        }

        public static Pattern LineInvariant(object content)
        {
            return Pattern.Surround(StartOfLineInvariant(), content, EndOfLineInvariant());
        }

        public static QuantifiablePattern EntireInput(object content)
        {
            return Pattern.Surround(StartOfInput(), content, EndOfInput()).AsNoncapturingGroup();
        }

        public static QuantifiablePattern EntireInput(params object[] content)
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

        public static QuantifiablePattern Group()
        {
            return new NumberedGroup(string.Empty);
        }

        public static QuantifiablePattern Group(object content)
        {
            return new NumberedGroup(content);
        }

        public static QuantifiablePattern Group(params object[] content)
        {
            return Group((object)content);
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

        public static QuantifiablePattern DisallowGroup(string groupName)
        {
            RegexUtilities.CheckGroupName(groupName);

            return IfGroup(groupName, Never());
        }

        public static Pattern DisallowGroups(params string[] groupNames)
        {
            if (groupNames == null || groupNames.Length == 0)
            {
                return Pattern.Empty;
            }

            Pattern exp = DisallowGroup(groupNames[0]);

            for (int i = 1; i < groupNames.Length; i++)
            {
                exp = exp.DisallowGroup(groupNames[i]);
            }

            return exp;
        }

        public static QuantifiablePattern DisallowGroup(int groupNumber)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            return IfGroup(groupNumber, Never());
        }

        public static Pattern DisallowGroups(params int[] groupNumbers)
        {
            if (groupNumbers == null || groupNumbers.Length == 0)
            {
                return Pattern.Empty;
            }

            Pattern exp = DisallowGroup(groupNumbers[0]);

            for (int i = 1; i < groupNumbers.Length; i++)
            {
                exp = exp.DisallowGroup(groupNumbers[i]);
            }

            return exp;
        }

        public static QuantifiablePattern RequireGroup(string groupName)
        {
            RegexUtilities.CheckGroupName(groupName);

            return IfGroup(groupName, Pattern.Empty, Never());
        }

        public static Pattern RequireGroups(params string[] groupNames)
        {
            if (groupNames == null || groupNames.Length == 0)
            {
                return Pattern.Empty;
            }

            Pattern exp = RequireGroup(groupNames[0]);

            for (int i = 1; i < groupNames.Length; i++)
            {
                exp = exp.RequireGroup(groupNames[i]);
            }

            return exp;
        }

        public static QuantifiablePattern RequireGroup(int groupNumber)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            return IfGroup(groupNumber, Pattern.Empty, Never());
        }

        public static Pattern RequireGroups(params int[] groupNumbers)
        {
            if (groupNumbers == null || groupNumbers.Length == 0)
            {
                return Pattern.Empty;
            }

            Pattern exp = RequireGroup(groupNumbers[0]);

            for (int i = 1; i < groupNumbers.Length; i++)
            {
                exp = exp.RequireGroup(groupNumbers[i]);
            }

            return exp;
        }

        public static QuantifiedGroup Maybe(object content)
        {
            return new QuantifiedGroup.MaybeQuantifiedGroup(content);
        }

        public static QuantifiedGroup Maybe(params object[] content)
        {
            return Maybe((object)content);
        }

        public static QuantifiedGroup MaybeMany(object content)
        {
            return new QuantifiedGroup.MaybeManyQuantifiedGroup(content);
        }

        public static QuantifiedGroup MaybeMany(params object[] content)
        {
            return MaybeMany((object)content);
        }

        public static QuantifiedGroup OneMany(object content)
        {
            return new QuantifiedGroup.OneManyQuantifiedGroup(content);
        }

        public static QuantifiedGroup OneMany(params object[] content)
        {
            return OneMany((object)content);
        }

        public static QuantifiedGroup Count(int exactCount, object content)
        {
            return new QuantifiedGroup.CountQuantifiedGroup(exactCount, content);
        }

        public static QuantifiedGroup Count(int exactCount, params object[] content)
        {
            return Count(exactCount, (object)content);
        }

        public static QuantifiedGroup Count(int minCount, int maxCount, object content)
        {
            return new QuantifiedGroup.CountQuantifiedGroup(minCount, maxCount, content);
        }

        public static QuantifiedGroup Count(int minCount, int maxCount, params object[] content)
        {
            return Count(minCount, maxCount, (object)content);
        }

        public static QuantifiedGroup CountFrom(int minCount, object content)
        {
            return new QuantifiedGroup.CountFromQuantifiedGroup(minCount, content);
        }

        public static QuantifiedGroup CountFrom(int minCount, params object[] content)
        {
            return CountFrom(minCount, (object)content);
        }

        public static QuantifiedGroup CountTo(int maxCount, object content)
        {
            return new QuantifiedGroup.CountQuantifiedGroup(0, maxCount, content);
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

        public static Pattern Options(RegexOptions applyOptions)
        {
            return new Options(applyOptions);
        }

        public static QuantifiablePattern Options(RegexOptions applyOptions, object content)
        {
            return new GroupOptions(applyOptions, content);
        }

        public static QuantifiablePattern Options(RegexOptions applyOptions, params object[] content)
        {
            return Options(applyOptions, (object)content);
        }

        public static Pattern Options(RegexOptions applyOptions, RegexOptions disableOptions)
        {
            return new Options(applyOptions, disableOptions);
        }

        public static QuantifiablePattern Options(RegexOptions applyOptions, RegexOptions disableOptions, object content)
        {
            return new GroupOptions(applyOptions, disableOptions, content);
        }

        public static QuantifiablePattern Options(RegexOptions applyOptions, RegexOptions disableOptions, params object[] content)
        {
            return Options(applyOptions, disableOptions, (object)content);
        }

        public static Pattern DisableOptions(RegexOptions options)
        {
            return new Options(RegexOptions.None, options);
        }

        public static QuantifiablePattern DisableOptions(RegexOptions options, object content)
        {
            return new GroupOptions(RegexOptions.None, options, content);
        }

        public static QuantifiablePattern DisableOptions(RegexOptions options, params object[] content)
        {
            return Options(RegexOptions.None, options, (object)content);
        }

        public static Pattern Comment(string value)
        {
            return new InlineComment(value);
        }

        public static CharPattern Character(char value)
        {
            return CharPattern.Create(value);
        }

        public static CharPattern Character(int charCode)
        {
            return CharPattern.Create(charCode);
        }

        public static CharPattern Character(AsciiChar value)
        {
            return CharPattern.Create(value);
        }

        public static CharPattern Character(NamedBlock block)
        {
            return CharPattern.Create(block, false);
        }

        public static CharPattern Character(GeneralCategory category)
        {
            return CharPattern.Create(category, false);
        }

        public static CharGroup Character(string characters)
        {
            return CharGroup.Create(characters, false);
        }

        public static CharGroup Character(CharGrouping value)
        {
            return CharGroup.Create(value, false);
        }

        public static CharGroup NotCharacter(char value)
        {
            return CharGroup.Create(value, true);
        }

        public static CharGroup NotCharacter(int charCode)
        {
            return CharGroup.Create(charCode, true);
        }

        public static CharGroup NotCharacter(AsciiChar value)
        {
            return CharGroup.Create(value, true);
        }

        public static CharPattern NotCharacter(NamedBlock block)
        {
            return CharPattern.Create(block, true);
        }

        public static CharPattern NotCharacter(GeneralCategory category)
        {
            return CharPattern.Create(category, true);
        }

        public static CharGroup NotCharacter(string characters)
        {
            return CharGroup.Create(characters, true);
        }

        public static CharGroup NotCharacter(CharGrouping value)
        {
            return CharGroup.Create(value, true);
        }

        public static CharGroup Range(char first, char last)
        {
            return CharGroup.Create(first, last, false);
        }

        public static CharGroup Range(int firstCharCode, int lastCharCode)
        {
            return CharGroup.Create(firstCharCode, lastCharCode, false);
        }

        public static CharGroup NotRange(char first, char last)
        {
            return CharGroup.Create(first, last, true);
        }

        public static CharGroup NotRange(int firstCharCode, int lastCharCode)
        {
            return CharGroup.Create(firstCharCode, lastCharCode, true);
        }

        public static CharSubtraction Subtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup);
        }

        public static NegativeCharSubtraction NotSubtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new NegativeCharSubtraction(baseGroup, excludedGroup);
        }

        public static CharPattern Tab()
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

        public static CharPattern Linefeed()
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

        public static CharPattern CarriageReturn()
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

        public static CharPattern Space()
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

        public static CharPattern ExclamationMark()
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

        public static CharPattern QuoteMark()
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

        public static CharPattern NumberSign()
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

        public static CharPattern Dollar()
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

        public static CharPattern Percent()
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

        public static CharPattern Ampersand()
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

        public static CharPattern Apostrophe()
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

        public static CharPattern StartParenthesis()
        {
            return Character(AsciiChar.StartParenthesis);
        }

        public static QuantifiedGroup StartParenthesis(int exactCount)
        {
            return Count(exactCount, StartParenthesis());
        }

        public static QuantifiedGroup StartParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, StartParenthesis());
        }

        public static QuantifiablePattern NotStartParenthesis()
        {
            return NotCharacter(AsciiChar.StartParenthesis);
        }

        public static QuantifiedGroup NotStartParenthesis(int exactCount)
        {
            return Count(exactCount, NotStartParenthesis());
        }

        public static QuantifiedGroup NotStartParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotStartParenthesis());
        }

        public static CharPattern EndParenthesis()
        {
            return Character(AsciiChar.EndParenthesis);
        }

        public static QuantifiedGroup EndParenthesis(int exactCount)
        {
            return Count(exactCount, EndParenthesis());
        }

        public static QuantifiedGroup EndParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EndParenthesis());
        }

        public static QuantifiablePattern NotEndParenthesis()
        {
            return NotCharacter(AsciiChar.EndParenthesis);
        }

        public static QuantifiedGroup NotEndParenthesis(int exactCount)
        {
            return Count(exactCount, NotEndParenthesis());
        }

        public static QuantifiedGroup NotEndParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEndParenthesis());
        }

        public static CharPattern Asterisk()
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

        public static CharPattern Plus()
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

        public static CharPattern Comma()
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

        public static CharPattern Hyphen()
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

        public static CharPattern Dot()
        {
            return Character(AsciiChar.Dot);
        }

        public static QuantifiedGroup Dot(int exactCount)
        {
            return Count(exactCount, Dot());
        }

        public static QuantifiedGroup Dot(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Dot());
        }

        public static QuantifiablePattern NotDot()
        {
            return NotCharacter(AsciiChar.Dot);
        }

        public static QuantifiedGroup NotDot(int exactCount)
        {
            return Count(exactCount, NotDot());
        }

        public static QuantifiedGroup NotDot(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotDot());
        }

        public static CharPattern Slash()
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

        public static CharPattern Colon()
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

        public static CharPattern Semicolon()
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

        public static CharPattern LessThan()
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

        public static CharPattern EqualsSign()
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

        public static CharPattern GreaterThan()
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

        public static CharPattern QuestionMark()
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

        public static CharPattern AtSign()
        {
            return Character(AsciiChar.AtSign);
        }

        public static QuantifiedGroup AtSign(int exactCount)
        {
            return Count(exactCount, AtSign());
        }

        public static QuantifiedGroup AtSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AtSign());
        }

        public static QuantifiablePattern NotAtSign()
        {
            return NotCharacter(AsciiChar.AtSign);
        }

        public static QuantifiedGroup NotAtSign(int exactCount)
        {
            return Count(exactCount, NotAtSign());
        }

        public static QuantifiedGroup NotAtSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAtSign());
        }

        public static CharPattern StartSquareBracket()
        {
            return Character(AsciiChar.StartSquareBracket);
        }

        public static QuantifiedGroup StartSquareBracket(int exactCount)
        {
            return Count(exactCount, StartSquareBracket());
        }

        public static QuantifiedGroup StartSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, StartSquareBracket());
        }

        public static QuantifiablePattern NotStartSquareBracket()
        {
            return NotCharacter(AsciiChar.StartSquareBracket);
        }

        public static QuantifiedGroup NotStartSquareBracket(int exactCount)
        {
            return Count(exactCount, NotStartSquareBracket());
        }

        public static QuantifiedGroup NotStartSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotStartSquareBracket());
        }

        public static CharPattern Backslash()
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

        public static CharPattern EndSquareBracket()
        {
            return Character(AsciiChar.EndSquareBracket);
        }

        public static QuantifiedGroup EndSquareBracket(int exactCount)
        {
            return Count(exactCount, EndSquareBracket());
        }

        public static QuantifiedGroup EndSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EndSquareBracket());
        }

        public static QuantifiablePattern NotEndSquareBracket()
        {
            return NotCharacter(AsciiChar.EndSquareBracket);
        }

        public static QuantifiedGroup NotEndSquareBracket(int exactCount)
        {
            return Count(exactCount, NotEndSquareBracket());
        }

        public static QuantifiedGroup NotEndSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEndSquareBracket());
        }

        public static CharPattern CircumflexAccent()
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

        public static CharPattern Underscore()
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

        public static CharPattern GraveAccent()
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

        public static CharPattern StartCurlyBracket()
        {
            return Character(AsciiChar.StartCurlyBracket);
        }

        public static QuantifiedGroup StartCurlyBracket(int exactCount)
        {
            return Count(exactCount, StartCurlyBracket());
        }

        public static QuantifiedGroup StartCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, StartCurlyBracket());
        }

        public static QuantifiablePattern NotStartCurlyBracket()
        {
            return NotCharacter(AsciiChar.StartCurlyBracket);
        }

        public static QuantifiedGroup NotStartCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotStartCurlyBracket());
        }

        public static QuantifiedGroup NotStartCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotStartCurlyBracket());
        }

        public static CharPattern VerticalLine()
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

        public static CharPattern EndCurlyBracket()
        {
            return Character(AsciiChar.EndCurlyBracket);
        }

        public static QuantifiedGroup EndCurlyBracket(int exactCount)
        {
            return Count(exactCount, EndCurlyBracket());
        }

        public static QuantifiedGroup EndCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EndCurlyBracket());
        }

        public static QuantifiablePattern NotEndCurlyBracket()
        {
            return NotCharacter(AsciiChar.EndCurlyBracket);
        }

        public static QuantifiedGroup NotEndCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotEndCurlyBracket());
        }

        public static QuantifiedGroup NotEndCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEndCurlyBracket());
        }

        public static CharPattern Tilde()
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
            return Character(CharGroupings.WhiteSpace().NotWhiteSpace());
        }

        public static QuantifiedGroup AnyInvariant(int count)
        {
            return Count(count, AnyInvariant());
        }

        public static QuantifiedGroup AnyInvariant(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AnyInvariant());
        }

        public static CharPattern Digit()
        {
            return CharPattern.Create(CharClass.Digit);
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

        public static CharPattern NotDigit()
        {
            return CharPattern.Create(CharClass.NotDigit);
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

        public static CharPattern WhiteSpace()
        {
            return CharPattern.Create(CharClass.WhiteSpace);
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

        public static CharPattern NotWhiteSpace()
        {
            return CharPattern.Create(CharClass.NotWhiteSpace);
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

        public static CharPattern WordChar()
        {
            return CharPattern.Create(CharClass.WordChar);
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

        public static CharPattern NotWordChar()
        {
            return CharPattern.Create(CharClass.NotWordChar);
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
            return Character(CharGroupings.CarriageReturn().Linefeed());
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
            return NotCharacter(CharGroupings.CarriageReturn().Linefeed());
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
            return Character(CharGroupings.Alphanumeric());
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
            return NotCharacter(CharGroupings.Alphanumeric());
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
            return Character(CharGroupings.AlphanumericLower());
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
            return NotCharacter(CharGroupings.AlphanumericLower());
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
            return Character(CharGroupings.AlphanumericUpper());
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
            return NotCharacter(CharGroupings.AlphanumericUpper());
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
            return Character(CharGroupings.AlphanumericUnderscore());
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
            return NotCharacter(CharGroupings.AlphanumericUnderscore());
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
            return Character(CharGroupings.LatinLetter());
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
            return NotCharacter(CharGroupings.LatinLetter());
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
            return Character(CharGroupings.LatinLetterLower());
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
            return NotCharacter(CharGroupings.LatinLetterLower());
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
            return Character(CharGroupings.LatinLetterUpper());
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
            return NotCharacter(CharGroupings.LatinLetterUpper());
        }

        public static QuantifiedGroup NotLatinLetterUpper(int count)
        {
            return Count(count, NotLatinLetterUpper());
        }

        public static QuantifiedGroup NotLatinLetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLatinLetterUpper());
        }

        public static CharPattern LetterLower()
        {
            return Character(GeneralCategory.LetterLowercase);
        }

        public static QuantifiedGroup LetterLower(int count)
        {
            return Count(count, LetterLower());
        }

        public static QuantifiedGroup LetterLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LetterLower());
        }

        public static CharPattern NotLetterLower()
        {
            return NotCharacter(GeneralCategory.LetterLowercase);
        }

        public static QuantifiedGroup NotLetterLower(int count)
        {
            return Count(count, NotLetterLower());
        }

        public static QuantifiedGroup NotLetterLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLetterLower());
        }

        public static CharPattern LetterUpper()
        {
            return Character(GeneralCategory.LetterUppercase);
        }

        public static QuantifiedGroup LetterUpper(int count)
        {
            return Count(count, LetterUpper());
        }

        public static QuantifiedGroup LetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LetterUpper());
        }

        public static CharPattern NotLetterUpper()
        {
            return NotCharacter(GeneralCategory.LetterUppercase);
        }

        public static QuantifiedGroup NotLetterUpper(int count)
        {
            return Count(count, NotLetterUpper());
        }

        public static QuantifiedGroup NotLetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLetterUpper());
        }

        public static CharGroup ArabicDigit()
        {
            return Character(CharGroupings.ArabicDigit());
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
            return NotCharacter(CharGroupings.ArabicDigit());
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
            return Character(CharGroupings.HexadecimalDigit());
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
            return NotCharacter(CharGroupings.HexadecimalDigit());
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
            return Character(CharGroupings.Parenthesis());
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
            return NotCharacter(CharGroupings.Parenthesis());
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
            return Character(CharGroupings.CurlyBracket());
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
            return NotCharacter(CharGroupings.CurlyBracket());
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
            return Character(CharGroupings.SquareBracket());
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
            return NotCharacter(CharGroupings.SquareBracket());
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
            return StartParenthesis().EndParenthesis();
        }

        public static Pattern Parentheses(object content)
        {
            return Pattern.Surround(AsciiChar.StartParenthesis, content, AsciiChar.EndParenthesis);
        }

        public static Pattern CurlyBrackets()
        {
            return StartCurlyBracket().EndCurlyBracket();
        }

        public static Pattern CurlyBrackets(object content)
        {
            return Pattern.Surround(AsciiChar.StartCurlyBracket, content, AsciiChar.EndCurlyBracket);
        }

        public static Pattern SquareBrackets()
        {
            return StartSquareBracket().EndSquareBracket();
        }

        public static Pattern SquareBrackets(object content)
        {
            return Pattern.Surround(AsciiChar.StartSquareBracket, content, AsciiChar.EndSquareBracket);
        }

        public static Pattern AngleBrackets()
        {
            return LessThan().GreaterThan();
        }

        public static Pattern AngleBrackets(object content)
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

        public static QuantifiedPattern WhileChar(CharGrouping value)
        {
            return Character(value).MaybeMany();
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

        public static QuantifiedPattern WhileNotChar(CharGrouping value)
        {
            return NotCharacter(value).MaybeMany();
        }

        public static QuantifiedPattern WhileNotNewLine()
        {
            return WhileNotChar(CharGroupings.NewLineChar());
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

        public static QuantifiablePattern LeadingWhiteSpace()
        {
            return StartOfLine().WhiteSpaceExceptNewLine().OneMany().AsNonbacktrackingGroup();
        }

        public static QuantifiablePattern TrailingWhiteSpace()
        {
            return WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn().AsNonbacktrackingGroup();
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

        public static QuantifiablePattern FirstLine()
        {
            return StartOfInput().NotNewLineChar().MaybeMany().AsNonbacktrackingGroup();
        }

        internal static Pattern ValidGroupName()
        {
            return EntireInput(
                Group(Range('1', '9').ArabicDigit().MaybeMany()) |
                WordChar().Except(ArabicDigit()).WordChar().MaybeMany());
        }
    }
}
