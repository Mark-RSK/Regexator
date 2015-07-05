// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Exposes static methods that returns instance of the pattern class.
    /// </summary>
    public static class Patterns
    {
        /// <summary>
        /// Returns a pattern that has opposite meaning than the current instance. For example a word boundary will be inverted into a non-word boundary.
        /// </summary>
        /// <typeparam name="TPattern"></typeparam>
        /// <param name="value">A pattern to be inverted.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Returns an if construct with the specified pattern to test and a pattern to match if the test pattern is matched and a pattern to match if the test pattern is not matched.
        /// </summary>
        /// <param name="testContent">The test pattern to match.</param>
        /// <param name="trueContent">The pattern to match if the test pattern is matched.</param>
        /// <param name="falseContent">The pattern to match if the test pattern is not matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern IfAssert(object testContent, object trueContent, object falseContent)
        {
            return new IfAssert(testContent, trueContent, falseContent);
        }

        /// <summary>
        /// Returns an if construct with a pattern to match if the named group is matched.
        /// </summary>
        /// <param name="groupName">A Valid name of a regex group.</param>
        /// <param name="trueContent">The pattern to match if the named group is matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static QuantifiablePattern IfGroup(string groupName, object trueContent)
        {
            return IfGroup(groupName, trueContent, null);
        }

        /// <summary>
        /// Returns an if construct with a pattern to match if the named group is matched and a pattern to match if the named group is not matched.
        /// </summary>
        /// <param name="groupName">A Valid name of a regex group.</param>
        /// <param name="trueContent">The pattern to match if the named group is matched.</param>
        /// <param name="falseContent">The pattern to match if the named group is not matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static QuantifiablePattern IfGroup(string groupName, object trueContent, object falseContent)
        {
            return new IfGroup(groupName, trueContent, falseContent);
        }

        /// <summary>
        /// Returns an if construct with a pattern to match if the numbered group is matched.
        /// </summary>
        /// <param name="groupNumber">A Valid number of a regex group.</param>
        /// <param name="trueContent">The pattern to match if the numbered group is matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiablePattern IfGroup(int groupNumber, object trueContent)
        {
            return IfGroup(groupNumber, trueContent, null);
        }

        /// <summary>
        /// Returns an if construct with a pattern to match if the numbered group is matched and a pattern to match if the numbered group is not matched.
        /// </summary>
        /// <param name="groupNumber">A Valid number of a regex group.</param>
        /// <param name="trueContent">The pattern to match if the numbered group is matched.</param>
        /// <param name="falseContent">The pattern to match if the numbered group is not matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiablePattern IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            return new IfGroup(groupNumber, trueContent, falseContent);
        }

        /// <summary>
        /// Returns a zero-width positive lookahead assertion with a specified content to be matched.
        /// </summary>
        /// <param name="content">A content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Assertion Assert(object content)
        {
            return new Assertion(content);
        }

        /// <summary>
        /// Returns a zero-width positive lookahead assertion that matches any one pattern specified in the object array.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Assertion Assert(params object[] content)
        {
            return Assert((object)content);
        }

        /// <summary>
        /// Returns a zero-width negative lookahead assertion with a specified content not to be matched.
        /// </summary>
        /// <param name="content">A content not to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern NotAssert(object content)
        {
            return new NegativeAssertion(content);
        }

        /// <summary>
        /// Returns a zero-width negative lookahead assertion that has to match none of patterns specified in the object array.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns none of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern NotAssert(params object[] content)
        {
            return NotAssert((object)content);
        }

        /// <summary>
        /// Returns a zero-width positive lookbehind assertion with a specified content to be matched.
        /// </summary>
        /// <param name="content">A content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static BackAssertion AssertBack(object content)
        {
            return new BackAssertion(content);
        }

        /// <summary>
        /// Returns a zero-width positive lookbehind assertion that matches any one pattern specified in the object array.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static BackAssertion AssertBack(params object[] content)
        {
            return AssertBack((object)content);
        }

        /// <summary>
        /// Returns a zero-width negative lookbehind assertion with a specified content not to be matched.
        /// </summary>
        /// <param name="content">A content not to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern NotAssertBack(object content)
        {
            return new NegativeBackAssertion(content);
        }

        /// <summary>
        /// Returns a zero-width negative lookbehind assertion that has to match none of patterns specified in the object array.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns none of which has to be matched.</param>
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


        /// <summary>
        /// Returns a pattern that is matched at end of the string.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EndOfInput()
        {
            return new EndOfInput();
        }

        /// <summary>
        /// Returns a pattern that is matched at the end of the string or before \n at the end of the string.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EndOrBeforeEndingNewLine()
        {
            return new EndOrBeforeEndingNewLine();
        }

        /// <summary>
        /// Returns a pattern that is matched at the position where the previous match ended.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern PreviousMatchEnd()
        {
            return new PreviousMatchEnd();
        }

        /// <summary>
        /// Returns a pattern that is matched on a boundary between a word character (\w) and a non-word character (\W).
        /// The match may also occur on a word boundary at the beginning or end of the string.
        /// </summary>
        /// <returns></returns>
        public static WordBoundary WordBoundary()
        {
            return new WordBoundary();
        }

        /// <summary>
        /// Returns a pattern that is not matched on a boundary between a word character (\w) and a non-word character (\W).
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Returns a pattern that matches any one of the patterns specified in the collection.
        /// </summary>
        /// <param name="values">A collection that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        public static QuantifiablePattern Any(IEnumerable<object> values)
        {
            return new AnyGroup(values);
        }

        /// <summary>
        /// Returns a pattern that matches any one of the patterns specified in the object array.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern Any(params object[] content)
        {
            return new AnyGroup(content);
        }

        /// <summary>
        /// Returns an empty numbered group.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern Group()
        {
            return new NumberedGroup(string.Empty);
        }

        /// <summary>
        /// Returns a numbered group with a specified content.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern Group(object content)
        {
            return new NumberedGroup(content);
        }

        /// <summary>
        /// Returns a numbered group with a specified content.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern Group(params object[] content)
        {
            return Group((object)content);
        }

        /// <summary>
        /// Returns a named group with a specified name and content.
        /// </summary>
        /// <param name="name">A name of the group.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static QuantifiablePattern NamedGroup(string name, object content)
        {
            return new NamedGroup(name, content);
        }

        /// <summary>
        /// Returns a named group with a specified name and content.
        /// </summary>
        /// <param name="name">A name of the group.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static QuantifiablePattern NamedGroup(string name, params object[] content)
        {
            return NamedGroup(name, (object)content);
        }

        /// <summary>
        /// Returns a noncapturing group with a specified content.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern NoncapturingGroup(object content)
        {
            return new NoncapturingGroup(content);
        }

        /// <summary>
        /// Returns a noncapturing group with a specified content.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern NoncapturingGroup(params object[] content)
        {
            return NoncapturingGroup((object)content);
        }

        /// <summary>
        /// Returns a balancing group with specified group names and a content.
        /// </summary>
        /// <param name="name1">Current group name.</param>
        /// <param name="name2">Previously defined group name.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static QuantifiablePattern BalancingGroup(string name1, string name2, object content)
        {
            return new BalancingGroup(name1, name2, content);
        }

        /// <summary>
        /// Returns a balancing group with specified group names and a content.
        /// </summary>
        /// <param name="name1">Current group name.</param>
        /// <param name="name2">Previously defined group name.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static QuantifiablePattern BalancingGroup(string name1, string name2, params object[] content)
        {
            return BalancingGroup(name1, name2, (object)content);
        }

        /// <summary>
        /// Returns a nonbacktracking group with a specified content.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern NonbacktrackingGroup(object content)
        {
            return new NonbacktrackingGroup(content);
        }

        /// <summary>
        /// Returns a nonbacktracking group with a specified content.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Appends a pattern that matches a tab.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Tab()
        {
            return Character(AsciiChar.Tab);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of tab characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Tab(int exactCount)
        {
            return Count(exactCount, Tab());
        }

        /// <summary>
        /// Appends a pattern that matches a tab character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Tab(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Tab());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a tab character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotTab()
        {
            return NotCharacter(AsciiChar.Tab);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a tab character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotTab(int exactCount)
        {
            return Count(exactCount, NotTab());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a tab character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotTab(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotTab());
        }

        /// <summary>
        /// Appends a pattern that matches a linefeed.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Linefeed()
        {
            return Character(AsciiChar.Linefeed);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of linefeed characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Linefeed(int exactCount)
        {
            return Count(exactCount, Linefeed());
        }

        /// <summary>
        /// Appends a pattern that matches a linefeed character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Linefeed(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Linefeed());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a linefeed character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotLinefeed()
        {
            return NotCharacter(AsciiChar.Linefeed);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a linefeed character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLinefeed(int exactCount)
        {
            return Count(exactCount, NotLinefeed());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a linefeed character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLinefeed(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLinefeed());
        }

        /// <summary>
        /// Appends a pattern that matches a carriage return.
        /// </summary>
        /// <returns></returns>
        public static CharPattern CarriageReturn()
        {
            return Character(AsciiChar.CarriageReturn);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of carriage return characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CarriageReturn(int exactCount)
        {
            return Count(exactCount, CarriageReturn());
        }

        /// <summary>
        /// Appends a pattern that matches a carriage return character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CarriageReturn(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, CarriageReturn());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a carriage return character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotCarriageReturn()
        {
            return NotCharacter(AsciiChar.CarriageReturn);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a carriage return character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCarriageReturn(int exactCount)
        {
            return Count(exactCount, NotCarriageReturn());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a carriage return character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCarriageReturn(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotCarriageReturn());
        }

        /// <summary>
        /// Appends a pattern that matches a space.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Space()
        {
            return Character(AsciiChar.Space);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of space characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Space(int exactCount)
        {
            return Count(exactCount, Space());
        }

        /// <summary>
        /// Appends a pattern that matches a space character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Space(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Space());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a space character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotSpace()
        {
            return NotCharacter(AsciiChar.Space);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a space character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSpace(int exactCount)
        {
            return Count(exactCount, NotSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a space character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSpace(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a exclamation mark.
        /// </summary>
        /// <returns></returns>
        public static CharPattern ExclamationMark()
        {
            return Character(AsciiChar.ExclamationMark);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of exclamation mark characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup ExclamationMark(int exactCount)
        {
            return Count(exactCount, ExclamationMark());
        }

        /// <summary>
        /// Appends a pattern that matches a exclamation mark character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup ExclamationMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, ExclamationMark());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a exclamation mark character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotExclamationMark()
        {
            return NotCharacter(AsciiChar.ExclamationMark);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a exclamation mark character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotExclamationMark(int exactCount)
        {
            return Count(exactCount, NotExclamationMark());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a exclamation mark character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotExclamationMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotExclamationMark());
        }

        /// <summary>
        /// Appends a pattern that matches a quote mark.
        /// </summary>
        /// <returns></returns>
        public static CharPattern QuoteMark()
        {
            return Character(AsciiChar.QuoteMark);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of quote mark characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup QuoteMark(int exactCount)
        {
            return Count(exactCount, QuoteMark());
        }

        /// <summary>
        /// Appends a pattern that matches a quote mark character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup QuoteMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, QuoteMark());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a quote mark character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotQuoteMark()
        {
            return NotCharacter(AsciiChar.QuoteMark);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a quote mark character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotQuoteMark(int exactCount)
        {
            return Count(exactCount, NotQuoteMark());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a quote mark character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotQuoteMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotQuoteMark());
        }

        /// <summary>
        /// Appends a pattern that matches a number sign.
        /// </summary>
        /// <returns></returns>
        public static CharPattern NumberSign()
        {
            return Character(AsciiChar.NumberSign);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of number sign characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NumberSign(int exactCount)
        {
            return Count(exactCount, NumberSign());
        }

        /// <summary>
        /// Appends a pattern that matches a number sign character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NumberSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NumberSign());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a number sign character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotNumberSign()
        {
            return NotCharacter(AsciiChar.NumberSign);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a number sign character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotNumberSign(int exactCount)
        {
            return Count(exactCount, NotNumberSign());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a number sign character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotNumberSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotNumberSign());
        }

        /// <summary>
        /// Appends a pattern that matches a dollar.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Dollar()
        {
            return Character(AsciiChar.Dollar);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of dollar characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Dollar(int exactCount)
        {
            return Count(exactCount, Dollar());
        }

        /// <summary>
        /// Appends a pattern that matches a dollar character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Dollar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Dollar());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a dollar character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotDollar()
        {
            return NotCharacter(AsciiChar.Dollar);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a dollar character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDollar(int exactCount)
        {
            return Count(exactCount, NotDollar());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a dollar character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDollar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotDollar());
        }

        /// <summary>
        /// Appends a pattern that matches a percent.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Percent()
        {
            return Character(AsciiChar.Percent);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of percent characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Percent(int exactCount)
        {
            return Count(exactCount, Percent());
        }

        /// <summary>
        /// Appends a pattern that matches a percent character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Percent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Percent());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a percent character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotPercent()
        {
            return NotCharacter(AsciiChar.Percent);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a percent character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotPercent(int exactCount)
        {
            return Count(exactCount, NotPercent());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a percent character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotPercent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotPercent());
        }

        /// <summary>
        /// Appends a pattern that matches a ampersand.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Ampersand()
        {
            return Character(AsciiChar.Ampersand);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of ampersand characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Ampersand(int exactCount)
        {
            return Count(exactCount, Ampersand());
        }

        /// <summary>
        /// Appends a pattern that matches a ampersand character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Ampersand(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Ampersand());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a ampersand character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotAmpersand()
        {
            return NotCharacter(AsciiChar.Ampersand);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a ampersand character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAmpersand(int exactCount)
        {
            return Count(exactCount, NotAmpersand());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a ampersand character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAmpersand(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAmpersand());
        }

        /// <summary>
        /// Appends a pattern that matches a apostrophe.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Apostrophe()
        {
            return Character(AsciiChar.Apostrophe);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of apostrophe characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Apostrophe(int exactCount)
        {
            return Count(exactCount, Apostrophe());
        }

        /// <summary>
        /// Appends a pattern that matches a apostrophe character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Apostrophe(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Apostrophe());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a apostrophe character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotApostrophe()
        {
            return NotCharacter(AsciiChar.Apostrophe);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a apostrophe character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotApostrophe(int exactCount)
        {
            return Count(exactCount, NotApostrophe());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a apostrophe character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotApostrophe(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotApostrophe());
        }

        /// <summary>
        /// Appends a pattern that matches a start parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharPattern StartParenthesis()
        {
            return Character(AsciiChar.StartParenthesis);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of start parenthesis characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartParenthesis(int exactCount)
        {
            return Count(exactCount, StartParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a start parenthesis character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, StartParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a start parenthesis character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotStartParenthesis()
        {
            return NotCharacter(AsciiChar.StartParenthesis);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a start parenthesis character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartParenthesis(int exactCount)
        {
            return Count(exactCount, NotStartParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a start parenthesis character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotStartParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a end parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharPattern EndParenthesis()
        {
            return Character(AsciiChar.EndParenthesis);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of end parenthesis characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndParenthesis(int exactCount)
        {
            return Count(exactCount, EndParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a end parenthesis character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EndParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a end parenthesis character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotEndParenthesis()
        {
            return NotCharacter(AsciiChar.EndParenthesis);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a end parenthesis character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndParenthesis(int exactCount)
        {
            return Count(exactCount, NotEndParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a end parenthesis character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEndParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a asterisk.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Asterisk()
        {
            return Character(AsciiChar.Asterisk);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of asterisk characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Asterisk(int exactCount)
        {
            return Count(exactCount, Asterisk());
        }

        /// <summary>
        /// Appends a pattern that matches a asterisk character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Asterisk(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Asterisk());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a asterisk character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotAsterisk()
        {
            return NotCharacter(AsciiChar.Asterisk);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a asterisk character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAsterisk(int exactCount)
        {
            return Count(exactCount, NotAsterisk());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a asterisk character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAsterisk(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAsterisk());
        }

        /// <summary>
        /// Appends a pattern that matches a plus.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Plus()
        {
            return Character(AsciiChar.Plus);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of plus characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Plus(int exactCount)
        {
            return Count(exactCount, Plus());
        }

        /// <summary>
        /// Appends a pattern that matches a plus character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Plus(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Plus());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a plus character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotPlus()
        {
            return NotCharacter(AsciiChar.Plus);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a plus character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotPlus(int exactCount)
        {
            return Count(exactCount, NotPlus());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a plus character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotPlus(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotPlus());
        }

        /// <summary>
        /// Appends a pattern that matches a comma.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Comma()
        {
            return Character(AsciiChar.Comma);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of comma characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Comma(int exactCount)
        {
            return Count(exactCount, Comma());
        }

        /// <summary>
        /// Appends a pattern that matches a comma character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Comma(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Comma());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a comma character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotComma()
        {
            return NotCharacter(AsciiChar.Comma);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a comma character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotComma(int exactCount)
        {
            return Count(exactCount, NotComma());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a comma character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotComma(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotComma());
        }

        /// <summary>
        /// Appends a pattern that matches a hyphen.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Hyphen()
        {
            return Character(AsciiChar.Hyphen);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of hyphen characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Hyphen(int exactCount)
        {
            return Count(exactCount, Hyphen());
        }

        /// <summary>
        /// Appends a pattern that matches a hyphen character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Hyphen(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Hyphen());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a hyphen character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotHyphen()
        {
            return NotCharacter(AsciiChar.Hyphen);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a hyphen character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotHyphen(int exactCount)
        {
            return Count(exactCount, NotHyphen());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a hyphen character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotHyphen(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotHyphen());
        }

        /// <summary>
        /// Appends a pattern that matches a dot.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Dot()
        {
            return Character(AsciiChar.Dot);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of dot characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Dot(int exactCount)
        {
            return Count(exactCount, Dot());
        }

        /// <summary>
        /// Appends a pattern that matches a dot character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Dot(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Dot());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a dot character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotDot()
        {
            return NotCharacter(AsciiChar.Dot);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a dot character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDot(int exactCount)
        {
            return Count(exactCount, NotDot());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a dot character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDot(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotDot());
        }

        /// <summary>
        /// Appends a pattern that matches a slash.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Slash()
        {
            return Character(AsciiChar.Slash);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of slash characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Slash(int exactCount)
        {
            return Count(exactCount, Slash());
        }

        /// <summary>
        /// Appends a pattern that matches a slash character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Slash(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Slash());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a slash character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotSlash()
        {
            return NotCharacter(AsciiChar.Slash);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a slash character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSlash(int exactCount)
        {
            return Count(exactCount, NotSlash());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a slash character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSlash(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotSlash());
        }

        /// <summary>
        /// Appends a pattern that matches a colon.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Colon()
        {
            return Character(AsciiChar.Colon);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of colon characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Colon(int exactCount)
        {
            return Count(exactCount, Colon());
        }

        /// <summary>
        /// Appends a pattern that matches a colon character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Colon(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Colon());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a colon character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotColon()
        {
            return NotCharacter(AsciiChar.Colon);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a colon character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotColon(int exactCount)
        {
            return Count(exactCount, NotColon());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a colon character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotColon(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotColon());
        }

        /// <summary>
        /// Appends a pattern that matches a semicolon.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Semicolon()
        {
            return Character(AsciiChar.Semicolon);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of semicolon characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Semicolon(int exactCount)
        {
            return Count(exactCount, Semicolon());
        }

        /// <summary>
        /// Appends a pattern that matches a semicolon character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Semicolon(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Semicolon());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a semicolon character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotSemicolon()
        {
            return NotCharacter(AsciiChar.Semicolon);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a semicolon character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSemicolon(int exactCount)
        {
            return Count(exactCount, NotSemicolon());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a semicolon character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSemicolon(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotSemicolon());
        }

        /// <summary>
        /// Appends a pattern that matches a less than.
        /// </summary>
        /// <returns></returns>
        public static CharPattern LessThan()
        {
            return Character(AsciiChar.LessThan);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of less than characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LessThan(int exactCount)
        {
            return Count(exactCount, LessThan());
        }

        /// <summary>
        /// Appends a pattern that matches a less than character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LessThan(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LessThan());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a less than character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotLessThan()
        {
            return NotCharacter(AsciiChar.LessThan);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a less than character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLessThan(int exactCount)
        {
            return Count(exactCount, NotLessThan());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a less than character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLessThan(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLessThan());
        }

        /// <summary>
        /// Appends a pattern that matches a equals sign.
        /// </summary>
        /// <returns></returns>
        public static CharPattern EqualsSign()
        {
            return Character(AsciiChar.EqualsSign);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of equals sign characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EqualsSign(int exactCount)
        {
            return Count(exactCount, EqualsSign());
        }

        /// <summary>
        /// Appends a pattern that matches a equals sign character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EqualsSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EqualsSign());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a equals sign character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotEqualsSign()
        {
            return NotCharacter(AsciiChar.EqualsSign);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a equals sign character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEqualsSign(int exactCount)
        {
            return Count(exactCount, NotEqualsSign());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a equals sign character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEqualsSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEqualsSign());
        }

        /// <summary>
        /// Appends a pattern that matches a greater than.
        /// </summary>
        /// <returns></returns>
        public static CharPattern GreaterThan()
        {
            return Character(AsciiChar.GreaterThan);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of greater than characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup GreaterThan(int exactCount)
        {
            return Count(exactCount, GreaterThan());
        }

        /// <summary>
        /// Appends a pattern that matches a greater than character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup GreaterThan(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, GreaterThan());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a greater than character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotGreaterThan()
        {
            return NotCharacter(AsciiChar.GreaterThan);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a greater than character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotGreaterThan(int exactCount)
        {
            return Count(exactCount, NotGreaterThan());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a greater than character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotGreaterThan(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotGreaterThan());
        }

        /// <summary>
        /// Appends a pattern that matches a question mark.
        /// </summary>
        /// <returns></returns>
        public static CharPattern QuestionMark()
        {
            return Character(AsciiChar.QuestionMark);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of question mark characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup QuestionMark(int exactCount)
        {
            return Count(exactCount, QuestionMark());
        }

        /// <summary>
        /// Appends a pattern that matches a question mark character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup QuestionMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, QuestionMark());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a question mark character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotQuestionMark()
        {
            return NotCharacter(AsciiChar.QuestionMark);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a question mark character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotQuestionMark(int exactCount)
        {
            return Count(exactCount, NotQuestionMark());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a question mark character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotQuestionMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotQuestionMark());
        }

        /// <summary>
        /// Appends a pattern that matches a at sign.
        /// </summary>
        /// <returns></returns>
        public static CharPattern AtSign()
        {
            return Character(AsciiChar.AtSign);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of at sign characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AtSign(int exactCount)
        {
            return Count(exactCount, AtSign());
        }

        /// <summary>
        /// Appends a pattern that matches a at sign character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AtSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AtSign());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a at sign character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotAtSign()
        {
            return NotCharacter(AsciiChar.AtSign);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a at sign character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAtSign(int exactCount)
        {
            return Count(exactCount, NotAtSign());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a at sign character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAtSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAtSign());
        }

        /// <summary>
        /// Appends a pattern that matches a start square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern StartSquareBracket()
        {
            return Character(AsciiChar.StartSquareBracket);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of start square bracket characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartSquareBracket(int exactCount)
        {
            return Count(exactCount, StartSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a start square bracket character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, StartSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a start square bracket character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotStartSquareBracket()
        {
            return NotCharacter(AsciiChar.StartSquareBracket);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a start square bracket character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartSquareBracket(int exactCount)
        {
            return Count(exactCount, NotStartSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a start square bracket character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotStartSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a backslash.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Backslash()
        {
            return Character(AsciiChar.Backslash);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of backslash characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Backslash(int exactCount)
        {
            return Count(exactCount, Backslash());
        }

        /// <summary>
        /// Appends a pattern that matches a backslash character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Backslash(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Backslash());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a backslash character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotBackslash()
        {
            return NotCharacter(AsciiChar.Backslash);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a backslash character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotBackslash(int exactCount)
        {
            return Count(exactCount, NotBackslash());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a backslash character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotBackslash(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotBackslash());
        }

        /// <summary>
        /// Appends a pattern that matches a end square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern EndSquareBracket()
        {
            return Character(AsciiChar.EndSquareBracket);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of end square bracket characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndSquareBracket(int exactCount)
        {
            return Count(exactCount, EndSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a end square bracket character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EndSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a end square bracket character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotEndSquareBracket()
        {
            return NotCharacter(AsciiChar.EndSquareBracket);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a end square bracket character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndSquareBracket(int exactCount)
        {
            return Count(exactCount, NotEndSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a end square bracket character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEndSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a circumflex accent.
        /// </summary>
        /// <returns></returns>
        public static CharPattern CircumflexAccent()
        {
            return Character(AsciiChar.CircumflexAccent);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of circumflex accent characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CircumflexAccent(int exactCount)
        {
            return Count(exactCount, CircumflexAccent());
        }

        /// <summary>
        /// Appends a pattern that matches a circumflex accent character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CircumflexAccent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, CircumflexAccent());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a circumflex accent character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotCircumflexAccent()
        {
            return NotCharacter(AsciiChar.CircumflexAccent);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a circumflex accent character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCircumflexAccent(int exactCount)
        {
            return Count(exactCount, NotCircumflexAccent());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a circumflex accent character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCircumflexAccent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotCircumflexAccent());
        }

        /// <summary>
        /// Appends a pattern that matches a underscore.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Underscore()
        {
            return Character(AsciiChar.Underscore);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of underscore characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Underscore(int exactCount)
        {
            return Count(exactCount, Underscore());
        }

        /// <summary>
        /// Appends a pattern that matches a underscore character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Underscore(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Underscore());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a underscore character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotUnderscore()
        {
            return NotCharacter(AsciiChar.Underscore);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a underscore character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotUnderscore(int exactCount)
        {
            return Count(exactCount, NotUnderscore());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a underscore character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotUnderscore(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotUnderscore());
        }

        /// <summary>
        /// Appends a pattern that matches a grave accent.
        /// </summary>
        /// <returns></returns>
        public static CharPattern GraveAccent()
        {
            return Character(AsciiChar.GraveAccent);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of grave accent characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup GraveAccent(int exactCount)
        {
            return Count(exactCount, GraveAccent());
        }

        /// <summary>
        /// Appends a pattern that matches a grave accent character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup GraveAccent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, GraveAccent());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a grave accent character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotGraveAccent()
        {
            return NotCharacter(AsciiChar.GraveAccent);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a grave accent character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotGraveAccent(int exactCount)
        {
            return Count(exactCount, NotGraveAccent());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a grave accent character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotGraveAccent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotGraveAccent());
        }

        /// <summary>
        /// Appends a pattern that matches a start curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern StartCurlyBracket()
        {
            return Character(AsciiChar.StartCurlyBracket);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of start curly bracket characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartCurlyBracket(int exactCount)
        {
            return Count(exactCount, StartCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a start curly bracket character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, StartCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a start curly bracket character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotStartCurlyBracket()
        {
            return NotCharacter(AsciiChar.StartCurlyBracket);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a start curly bracket character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotStartCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a start curly bracket character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotStartCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a vertical line.
        /// </summary>
        /// <returns></returns>
        public static CharPattern VerticalLine()
        {
            return Character(AsciiChar.VerticalLine);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of vertical line characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup VerticalLine(int exactCount)
        {
            return Count(exactCount, VerticalLine());
        }

        /// <summary>
        /// Appends a pattern that matches a vertical line character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup VerticalLine(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, VerticalLine());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a vertical line character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotVerticalLine()
        {
            return NotCharacter(AsciiChar.VerticalLine);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a vertical line character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotVerticalLine(int exactCount)
        {
            return Count(exactCount, NotVerticalLine());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a vertical line character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotVerticalLine(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotVerticalLine());
        }

        /// <summary>
        /// Appends a pattern that matches a end curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern EndCurlyBracket()
        {
            return Character(AsciiChar.EndCurlyBracket);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of end curly bracket characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndCurlyBracket(int exactCount)
        {
            return Count(exactCount, EndCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a end curly bracket character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EndCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a end curly bracket character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotEndCurlyBracket()
        {
            return NotCharacter(AsciiChar.EndCurlyBracket);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a end curly bracket character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotEndCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a end curly bracket character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEndCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a tilde.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Tilde()
        {
            return Character(AsciiChar.Tilde);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of tilde characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Tilde(int exactCount)
        {
            return Count(exactCount, Tilde());
        }

        /// <summary>
        /// Appends a pattern that matches a tilde character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Tilde(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Tilde());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a tilde character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotTilde()
        {
            return NotCharacter(AsciiChar.Tilde);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a tilde character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotTilde(int exactCount)
        {
            return Count(exactCount, NotTilde());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a tilde character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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

        /// <summary>
        /// Returns a pattern that matches a digit character.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Digit()
        {
            return CharPattern.Create(CharClass.Digit);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of digit characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Digit(int exactCount)
        {
            return Count(exactCount, Digit());
        }

        /// <summary>
        /// Appends a pattern that matches a digit character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Digit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Digit());
        }

        /// <summary>
        /// Appends a pattern that matches a digit character one or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedGroup Digits()
        {
            return OneMany(Digit());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a digit character.
        /// </summary>
        /// <returns></returns>
        public static CharPattern NotDigit()
        {
            return CharPattern.Create(CharClass.NotDigit);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a digit character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDigit(int exactCount)
        {
            return Count(exactCount, NotDigit());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a digit character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotDigit());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a digit character one or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedGroup NotDigits()
        {
            return OneMany(NotDigit());
        }

        /// <summary>
        /// Appends a pattern that matches a white-space character.
        /// </summary>
        /// <returns></returns>
        public static CharPattern WhiteSpace()
        {
            return CharPattern.Create(CharClass.WhiteSpace);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of white-space characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup WhiteSpace(int exactCount)
        {
            return Count(exactCount, WhiteSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a white-space character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup WhiteSpace(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, WhiteSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a white-space character one or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedGroup WhiteSpaces()
        {
            return OneMany(WhiteSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a white-space character.
        /// </summary>
        /// <returns></returns>
        public static CharPattern NotWhiteSpace()
        {
            return CharPattern.Create(CharClass.NotWhiteSpace);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a white-space character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotWhiteSpace(int exactCount)
        {
            return Count(exactCount, NotWhiteSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a white-space character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotWhiteSpace(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotWhiteSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a white-space character one or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedGroup NotWhiteSpaces()
        {
            return OneMany(NotWhiteSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a word character.
        /// </summary>
        /// <returns></returns>
        public static CharPattern WordChar()
        {
            return CharPattern.Create(CharClass.WordChar);
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of word characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup WordChar(int exactCount)
        {
            return Count(exactCount, WordChar());
        }

        /// <summary>
        /// Appends a pattern that matches a word character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup WordChar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, WordChar());
        }

        /// <summary>
        /// Appends a pattern that matches a word character one or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedGroup WordChars()
        {
            return OneMany(WordChar());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a word character.
        /// </summary>
        /// <returns></returns>
        public static CharPattern NotWordChar()
        {
            return CharPattern.Create(CharClass.NotWordChar);
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a word character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotWordChar(int exactCount)
        {
            return Count(exactCount, NotWordChar());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a word character from minimum times to maximum times.
        /// </summary>
        /// <param name="minCount">A minimum number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotWordChar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotWordChar());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a word character one or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedGroup NotWordChars()
        {
            return OneMany(NotWordChar());
        }

        public static CharGroup NewLineChar()
        {
            return Character(CharGroupings.CarriageReturn().Linefeed());
        }

        public static QuantifiedGroup NewLineChar(int exactCount)
        {
            return Count(exactCount, NewLineChar());
        }

        public static QuantifiedGroup NewLineChar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NewLineChar());
        }

        public static CharGroup NotNewLineChar()
        {
            return NotCharacter(CharGroupings.CarriageReturn().Linefeed());
        }

        public static QuantifiedGroup NotNewLineChar(int exactCount)
        {
            return Count(exactCount, NotNewLineChar());
        }

        public static QuantifiedGroup NotNewLineChar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotNewLineChar());
        }

        public static CharGroup Alphanumeric()
        {
            return Character(CharGroupings.Alphanumeric());
        }

        public static QuantifiedGroup Alphanumeric(int exactCount)
        {
            return Count(exactCount, Alphanumeric());
        }

        public static QuantifiedGroup Alphanumeric(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Alphanumeric());
        }

        public static CharGroup NotAlphanumeric()
        {
            return NotCharacter(CharGroupings.Alphanumeric());
        }

        public static QuantifiedGroup NotAlphanumeric(int exactCount)
        {
            return Count(exactCount, NotAlphanumeric());
        }

        public static QuantifiedGroup NotAlphanumeric(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAlphanumeric());
        }

        public static CharGroup AlphanumericLower()
        {
            return Character(CharGroupings.AlphanumericLower());
        }

        public static QuantifiedGroup AlphanumericLower(int exactCount)
        {
            return Count(exactCount, AlphanumericLower());
        }

        public static QuantifiedGroup AlphanumericLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AlphanumericLower());
        }

        public static CharGroup NotAlphanumericLower()
        {
            return NotCharacter(CharGroupings.AlphanumericLower());
        }

        public static QuantifiedGroup NotAlphanumericLower(int exactCount)
        {
            return Count(exactCount, NotAlphanumericLower());
        }

        public static QuantifiedGroup NotAlphanumericLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAlphanumericLower());
        }

        public static CharGroup AlphanumericUpper()
        {
            return Character(CharGroupings.AlphanumericUpper());
        }

        public static QuantifiedGroup AlphanumericUpper(int exactCount)
        {
            return Count(exactCount, AlphanumericUpper());
        }

        public static QuantifiedGroup AlphanumericUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AlphanumericUpper());
        }

        public static CharGroup NotAlphanumericUpper()
        {
            return NotCharacter(CharGroupings.AlphanumericUpper());
        }

        public static QuantifiedGroup NotAlphanumericUpper(int exactCount)
        {
            return Count(exactCount, NotAlphanumericUpper());
        }

        public static QuantifiedGroup NotAlphanumericUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAlphanumericUpper());
        }

        public static CharGroup AlphanumericUnderscore()
        {
            return Character(CharGroupings.AlphanumericUnderscore());
        }

        public static QuantifiedGroup AlphanumericUnderscore(int exactCount)
        {
            return Count(exactCount, AlphanumericUnderscore());
        }

        public static QuantifiedGroup AlphanumericUnderscore(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AlphanumericUnderscore());
        }

        public static CharGroup NotAlphanumericUnderscore()
        {
            return NotCharacter(CharGroupings.AlphanumericUnderscore());
        }

        public static QuantifiedGroup NotAlphanumericUnderscore(int exactCount)
        {
            return Count(exactCount, NotAlphanumericUnderscore());
        }

        public static QuantifiedGroup NotAlphanumericUnderscore(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAlphanumericUnderscore());
        }

        public static CharGroup LatinLetter()
        {
            return Character(CharGroupings.LatinLetter());
        }

        public static QuantifiedGroup LatinLetter(int exactCount)
        {
            return Count(exactCount, LatinLetter());
        }

        public static QuantifiedGroup LatinLetter(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LatinLetter());
        }

        public static CharGroup NotLatinLetter()
        {
            return NotCharacter(CharGroupings.LatinLetter());
        }

        public static QuantifiedGroup NotLatinLetter(int exactCount)
        {
            return Count(exactCount, NotLatinLetter());
        }

        public static QuantifiedGroup NotLatinLetter(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLatinLetter());
        }

        public static CharGroup LatinLetterLower()
        {
            return Character(CharGroupings.LatinLetterLower());
        }

        public static QuantifiedGroup LatinLetterLower(int exactCount)
        {
            return Count(exactCount, LatinLetterLower());
        }

        public static QuantifiedGroup LatinLetterLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LatinLetterLower());
        }

        public static CharGroup NotLatinLetterLower()
        {
            return NotCharacter(CharGroupings.LatinLetterLower());
        }

        public static QuantifiedGroup NotLatinLetterLower(int exactCount)
        {
            return Count(exactCount, NotLatinLetterLower());
        }

        public static QuantifiedGroup NotLatinLetterLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLatinLetterLower());
        }

        public static CharGroup LatinLetterUpper()
        {
            return Character(CharGroupings.LatinLetterUpper());
        }

        public static QuantifiedGroup LatinLetterUpper(int exactCount)
        {
            return Count(exactCount, LatinLetterUpper());
        }

        public static QuantifiedGroup LatinLetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LatinLetterUpper());
        }

        public static CharGroup NotLatinLetterUpper()
        {
            return NotCharacter(CharGroupings.LatinLetterUpper());
        }

        public static QuantifiedGroup NotLatinLetterUpper(int exactCount)
        {
            return Count(exactCount, NotLatinLetterUpper());
        }

        public static QuantifiedGroup NotLatinLetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLatinLetterUpper());
        }

        public static CharPattern LetterLower()
        {
            return Character(GeneralCategory.LetterLowercase);
        }

        public static QuantifiedGroup LetterLower(int exactCount)
        {
            return Count(exactCount, LetterLower());
        }

        public static QuantifiedGroup LetterLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LetterLower());
        }

        public static CharPattern NotLetterLower()
        {
            return NotCharacter(GeneralCategory.LetterLowercase);
        }

        public static QuantifiedGroup NotLetterLower(int exactCount)
        {
            return Count(exactCount, NotLetterLower());
        }

        public static QuantifiedGroup NotLetterLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLetterLower());
        }

        public static CharPattern LetterUpper()
        {
            return Character(GeneralCategory.LetterUppercase);
        }

        public static QuantifiedGroup LetterUpper(int exactCount)
        {
            return Count(exactCount, LetterUpper());
        }

        public static QuantifiedGroup LetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LetterUpper());
        }

        public static CharPattern NotLetterUpper()
        {
            return NotCharacter(GeneralCategory.LetterUppercase);
        }

        public static QuantifiedGroup NotLetterUpper(int exactCount)
        {
            return Count(exactCount, NotLetterUpper());
        }

        public static QuantifiedGroup NotLetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLetterUpper());
        }

        public static CharGroup ArabicDigit()
        {
            return Character(CharGroupings.ArabicDigit());
        }

        public static QuantifiedGroup ArabicDigit(int exactCount)
        {
            return Count(exactCount, ArabicDigit());
        }

        public static QuantifiedGroup ArabicDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, ArabicDigit());
        }

        public static CharGroup NotArabicDigit()
        {
            return NotCharacter(CharGroupings.ArabicDigit());
        }

        public static QuantifiedGroup NotArabicDigit(int exactCount)
        {
            return Count(exactCount, NotArabicDigit());
        }

        public static QuantifiedGroup NotArabicDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotArabicDigit());
        }

        public static CharGroup HexadecimalDigit()
        {
            return Character(CharGroupings.HexadecimalDigit());
        }

        public static QuantifiedGroup HexadecimalDigit(int exactCount)
        {
            return Count(exactCount, HexadecimalDigit());
        }

        public static QuantifiedGroup HexadecimalDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, HexadecimalDigit());
        }

        public static CharGroup NotHexadecimalDigit()
        {
            return NotCharacter(CharGroupings.HexadecimalDigit());
        }

        public static QuantifiedGroup NotHexadecimalDigit(int exactCount)
        {
            return Count(exactCount, NotHexadecimalDigit());
        }

        public static QuantifiedGroup NotHexadecimalDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotHexadecimalDigit());
        }

        public static CharGroup Parenthesis()
        {
            return Character(CharGroupings.Parenthesis());
        }

        public static QuantifiedGroup Parenthesis(int exactCount)
        {
            return Count(exactCount, Parenthesis());
        }

        public static QuantifiedGroup Parenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Parenthesis());
        }

        public static CharGroup NotParenthesis()
        {
            return NotCharacter(CharGroupings.Parenthesis());
        }

        public static QuantifiedGroup NotParenthesis(int exactCount)
        {
            return Count(exactCount, NotParenthesis());
        }

        public static QuantifiedGroup NotParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotParenthesis());
        }

        public static CharGroup CurlyBracket()
        {
            return Character(CharGroupings.CurlyBracket());
        }

        public static QuantifiedGroup CurlyBracket(int exactCount)
        {
            return Count(exactCount, CurlyBracket());
        }

        public static QuantifiedGroup CurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, CurlyBracket());
        }

        public static CharGroup NotCurlyBracket()
        {
            return NotCharacter(CharGroupings.CurlyBracket());
        }

        public static QuantifiedGroup NotCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotCurlyBracket());
        }

        public static QuantifiedGroup NotCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotCurlyBracket());
        }

        public static CharGroup SquareBracket()
        {
            return Character(CharGroupings.SquareBracket());
        }

        public static QuantifiedGroup SquareBracket(int exactCount)
        {
            return Count(exactCount, SquareBracket());
        }

        public static QuantifiedGroup SquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, SquareBracket());
        }

        public static CharGroup NotSquareBracket()
        {
            return NotCharacter(CharGroupings.SquareBracket());
        }

        public static QuantifiedGroup NotSquareBracket(int exactCount)
        {
            return Count(exactCount, NotSquareBracket());
        }

        public static QuantifiedGroup NotSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotSquareBracket());
        }

        public static CharSubtraction WhiteSpaceExceptNewLine()
        {
            return WhiteSpace().Except(NewLineChar());
        }

        public static QuantifiedGroup WhiteSpaceExceptNewLine(int exactCount)
        {
            return Count(exactCount, WhiteSpaceExceptNewLine());
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
