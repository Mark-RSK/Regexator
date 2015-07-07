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
        /// Returns a pattern that is a negation of the specified pattern.
        /// </summary>
        /// <typeparam name="TPattern"></typeparam>
        /// <param name="value">A pattern to be negated.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static TPattern Not<TPattern>(INegateable<TPattern> value) where TPattern : Pattern
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Negate();
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
        /// Returns an if construct with the specified content to test and a content to match if the test content is matched.
        /// </summary>
        /// <param name="testContent">The content to assert.</param>
        /// <param name="trueContent">The content to be matched if the test content is matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern IfAssert(object testContent, object trueContent)
        {
            return IfAssert(testContent, trueContent, null);
        }

        /// <summary>
        /// Returns an if construct with the specified content to test and a content to match if the test content is matched and a content to match if the test content is not matched.
        /// </summary>
        /// <param name="testContent">The content to assert.</param>
        /// <param name="trueContent">The content to be matched if the test content is matched.</param>
        /// <param name="falseContent">The content to be matched if the test content is not matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern IfAssert(object testContent, object trueContent, object falseContent)
        {
            return new IfAssert(testContent, trueContent, falseContent);
        }

        /// <summary>
        /// Returns an if construct with a content to match if the named group is matched.
        /// </summary>
        /// <param name="groupName">A name of the group.</param>
        /// <param name="trueContent">The content to be matched if the named group is matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static QuantifiablePattern IfGroup(string groupName, object trueContent)
        {
            return IfGroup(groupName, trueContent, null);
        }

        /// <summary>
        /// Returns an if construct with a content to match if the named group is matched and a content to match if the named group is not matched.
        /// </summary>
        /// <param name="groupName">A name of the group.</param>
        /// <param name="trueContent">The content to be matched if the named group is matched.</param>
        /// <param name="falseContent">The content to be matched if the named group is not matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static QuantifiablePattern IfGroup(string groupName, object trueContent, object falseContent)
        {
            return new IfGroup(groupName, trueContent, falseContent);
        }

        /// <summary>
        /// Returns an if construct with a content to match if the numbered group is matched.
        /// </summary>
        /// <param name="groupNumber">A number of the group.</param>
        /// <param name="trueContent">The content to be matched if the numbered group is matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiablePattern IfGroup(int groupNumber, object trueContent)
        {
            return IfGroup(groupNumber, trueContent, null);
        }

        /// <summary>
        /// Returns an if construct with a content to match if the numbered group is matched and a content to match if the numbered group is not matched.
        /// </summary>
        /// <param name="groupNumber">A number of the group.</param>
        /// <param name="trueContent">The content to be matched if the numbered group is matched.</param>
        /// <param name="falseContent">The content to be matched if the numbered group is not matched.</param>
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
        /// Returns a zero-width negative lookahead assertion that matches none of patterns specified in the object array.
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
        /// Returns a zero-width negative lookbehind assertion that matches none of patterns specified in the object array.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns none of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern NotAssertBack(params object[] content)
        {
            return NotAssertBack((object)content);
        }

        /// <summary>
        /// Returns a pattern that matches a specified content with lookbehind assertion on the left side and lookahead assertion on the right side.
        /// </summary>
        /// <param name="assertion">A content of the assertions.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static SurroundAssertion AssertSurround(object assertion, object content)
        {
            return AssertSurround(assertion, content, assertion);
        }

        /// <summary>
        /// Returns a pattern that matches a specified content with lookbehind assertion on the left side and lookahead assertion on the right side.
        /// </summary>
        /// <param name="backAssertion">A content of the lookbehind assertion.</param>
        /// <param name="content">The content to be matched.</param>
        /// <param name="assertion">A content of the lookahead assertion.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static SurroundAssertion AssertSurround(object backAssertion, object content, object assertion)
        {
            return new SurroundAssertion(backAssertion, content, assertion);
        }

        /// <summary>
        /// Returns a pattern that matches a specified content with negative lookbehind assertion on the left side and negative lookahead assertion on the right side.
        /// </summary>
        /// <param name="assertion">A content of the negative assertions.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static NegativeSurroundAssertion NotAssertSurround(object assertion, object content)
        {
            return NotAssertSurround(assertion, content, assertion);
        }

        /// <summary>
        /// Returns a pattern that matches a specified content with negative lookbehind assertion on the left side and negative lookahead assertion on the right side.
        /// </summary>
        /// <param name="backAssertion">A content of the negative lookbehind assertion.</param>
        /// <param name="content">The content to be matched.</param>
        /// <param name="assertion">A content of the negative lookahead assertion.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static NegativeSurroundAssertion NotAssertSurround(object backAssertion, object content, object assertion)
        {
            return new NegativeSurroundAssertion(backAssertion, content, assertion);
        }

        /// <summary>
        /// Returns a pattern that is matched at the beginning of the string.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern StartOfInput()
        {
            return new StartOfInput();
        }

        /// <summary>
        /// Returns a pattern that is matched at the beginning of the string (or line if the multiline option is applied).
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern StartOfLine()
        {
            return new StartOfLine();
        }

        /// <summary>
        /// Returns a pattern that is matched at the beginning of the line.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern StartOfLineInvariant()
        {
            return Options(RegexOptions.Multiline, StartOfLine());
        }

        /// <summary>
        /// Returns a pattern that is matched at the end of the string.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EndOfInput()
        {
            return new EndOfInput();
        }

        /// <summary>
        /// Returns a pattern that is matched at the end of the string (or line if the multiline option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EndOfLine()
        {
            return new EndOfLine();
        }

        /// <summary>
        /// Returns a pattern that is matched (before carriage return) at the end of the string (or (before carriage return) at the end of line if the multiline option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="matchCarriageReturnIfPresent">Indicates whether a carriage return should be matched if present and not already consumed by regex engine.</param>
        /// <returns></returns>
        public static Pattern EndOfLine(bool matchCarriageReturnIfPresent)
        {
            if (matchCarriageReturnIfPresent)
            {
                return Assert(CarriageReturn().Maybe().EndOfLine());
            }
            else
            {
                return EndOfLine();
            }
        }

        /// <summary>
        /// Returns a pattern that is matched at the end of the string or line. End of line is defined as the position before a linefeed.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EndOfLineInvariant()
        {
            return Options(RegexOptions.Multiline, EndOfLine());
        }

        /// <summary>
        /// Returns a pattern that is matched (before carriage return) at the end of the string or line. End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="matchCarriageReturnIfPresent">Indicates whether a carriage return should be matched if present and not already consumed by regex engine.</param>
        /// <returns></returns>
        public static QuantifiablePattern EndOfLineInvariant(bool matchCarriageReturnIfPresent)
        {
            if (matchCarriageReturnIfPresent)
            {
                return Assert(CarriageReturn().Maybe().EndOfLineInvariant());
            }
            else
            {
                return EndOfLineInvariant();
            }
        }

        /// <summary>
        /// Returns a pattern that is matched at the end of the string or before linefeed at the end of the string.
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
        /// Returns a pattern that is matched on a boundary between a word character (\w) and a non-word character (\W). The match may also occur on a word boundary at the beginning or end of the string.
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

        /// <summary>
        /// Returns a pattern that matches one or more word characters surrounded with a word boundary.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern Word()
        {
            return Pattern.Surround(WordBoundary(), WordChars()).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches literal text surrounded with a word boundary.
        /// </summary>
        /// <param name="text">A literal text.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern Word(string text)
        {
            return Pattern.Surround(WordBoundary(), text).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches any one literal text surrounded with a word boundary.
        /// </summary>
        /// <param name="values">An object array that contains zero or more values any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern Word(params string[] values)
        {
            return Pattern.Surround(WordBoundary(), Any(values)).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches a specified content surrounded with the beginning and the end of the string (or line if the multiline option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern Line(object content)
        {
            return Pattern.Surround(StartOfLine(), content, EndOfLine()).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches any one pattern surrounded with the beginning and the end of the string (or line if the multiline option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="content">An object array that contains zero or more values any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern Line(params object[] content)
        {
            return Line((object)content);
        }

        /// <summary>
        /// Returns a pattern that matches a specified content surrounded with the beginning and the end of string or line. End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern LineInvariant(object content)
        {
            return Pattern.Surround(StartOfLineInvariant(), content, EndOfLineInvariant());
        }

        /// <summary>
        /// Returns a pattern that matches any one pattern surrounded with the beginning and the end of line.
        /// </summary>
        /// <param name="content">An object array that contains zero or more values any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern LineInvariant(params object[] content)
        {
            return LineInvariant((object)content);
        }

        /// <summary>
        /// Returns a pattern that matches a specified content surrounded with the beginning and the end of the string.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern EntireInput(object content)
        {
            return Pattern.Surround(StartOfInput(), content, EndOfInput()).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches any one pattern surrounded with the beginning and the end of the string.
        /// </summary>
        /// <param name="content">An object array that contains zero or more values any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
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

        /// <summary>
        /// Returns a pattern that matches specified content zero or one times.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedGroup Maybe(object content)
        {
            return new QuantifiedGroup.MaybeQuantifiedGroup(content);
        }

        /// <summary>
        /// Returns a pattern that matches any one element of the specified content zero or one times.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedGroup Maybe(params object[] content)
        {
            return Maybe((object)content);
        }

        /// <summary>
        /// Returns a pattern that matches specified content zero or many times.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedGroup MaybeMany(object content)
        {
            return new QuantifiedGroup.MaybeManyQuantifiedGroup(content);
        }

        /// <summary>
        /// Returns a pattern that matches any one element of the specified content zero or many times.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedGroup MaybeMany(params object[] content)
        {
            return MaybeMany((object)content);
        }

        /// <summary>
        /// Returns a pattern that matches specified content one or many times.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedGroup OneMany(object content)
        {
            return new QuantifiedGroup.OneManyQuantifiedGroup(content);
        }

        /// <summary>
        /// Returns a pattern that matches any one element of the specified content one or many times.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedGroup OneMany(params object[] content)
        {
            return OneMany((object)content);
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times the pattern has to be matched.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Count(int exactCount, object content)
        {
            return new QuantifiedGroup.CountQuantifiedGroup(exactCount, content);
        }

        /// <summary>
        /// Returns a pattern that matches any one pattern specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times the pattern has to be matched.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Count(int exactCount, params object[] content)
        {
            return Count(exactCount, (object)content);
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern from minimal to maximum number of times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Count(int minCount, int maxCount, object content)
        {
            return new QuantifiedGroup.CountQuantifiedGroup(minCount, maxCount, content);
        }

        /// <summary>
        /// Returns a pattern that matches any one pattern from minimal to maximum number of times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Count(int minCount, int maxCount, params object[] content)
        {
            return Count(minCount, maxCount, (object)content);
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern at least specified number of times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CountFrom(int minCount, object content)
        {
            return new QuantifiedGroup.CountFromQuantifiedGroup(minCount, content);
        }

        /// <summary>
        /// Returns a pattern that matches any one pattern at least specified number of times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CountFrom(int minCount, params object[] content)
        {
            return CountFrom(minCount, (object)content);
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern at most specified number of times.
        /// </summary>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CountTo(int maxCount, object content)
        {
            return new QuantifiedGroup.CountQuantifiedGroup(0, maxCount, content);
        }

        /// <summary>
        /// Returns a pattern that matches any one pattern at most specified number of times.
        /// </summary>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CountTo(int maxCount, params object[] content)
        {
            return CountTo(maxCount, (object)content);
        }

        /// <summary>
        /// Returns a pattern that matches previously defined numbered group.
        /// </summary>
        /// <param name="groupNumber">A number of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiablePattern GroupReference(int groupNumber)
        {
            return new GroupNumberReference(groupNumber);
        }

        /// <summary>
        /// Returns a pattern that matches previously defined named group.
        /// </summary>
        /// <param name="groupName">A name of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static QuantifiablePattern GroupReference(string groupName)
        {
            return new GroupNameReference(groupName);
        }

        /// <summary>
        /// Returns a pattern that applies specified options.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <returns></returns>
        public static Pattern Options(RegexOptions applyOptions)
        {
            return new Options(applyOptions);
        }

        /// <summary>
        /// Returns a pattern that applies specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern Options(RegexOptions applyOptions, object content)
        {
            return new GroupOptions(applyOptions, content);
        }

        /// <summary>
        /// Returns a pattern that applies specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern Options(RegexOptions applyOptions, params object[] content)
        {
            return Options(applyOptions, (object)content);
        }

        /// <summary>
        /// Returns a pattern that applies and disables specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="disableOptions">A bitwise combination of the enumeration values that are disabled.</param>
        /// <returns></returns>
        public static Pattern Options(RegexOptions applyOptions, RegexOptions disableOptions)
        {
            return new Options(applyOptions, disableOptions);
        }

        /// <summary>
        /// Returns a pattern that applies and disables specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="disableOptions">A bitwise combination of the enumeration values that are disabled.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern Options(RegexOptions applyOptions, RegexOptions disableOptions, object content)
        {
            return new GroupOptions(applyOptions, disableOptions, content);
        }

        /// <summary>
        /// Returns a pattern that applies and disables specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="disableOptions">A bitwise combination of the enumeration values that are disabled.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        public static QuantifiablePattern Options(RegexOptions applyOptions, RegexOptions disableOptions, params object[] content)
        {
            return Options(applyOptions, disableOptions, (object)content);
        }

        /// <summary>
        /// Returns a pattern that disables specified options.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values that are disabled.</param>
        /// <returns></returns>
        public static Pattern DisableOptions(RegexOptions options)
        {
            return new Options(RegexOptions.None, options);
        }

        /// <summary>
        /// Returns a pattern that disables specified options to a specified pattern.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values that are disabled.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern DisableOptions(RegexOptions options, object content)
        {
            return new GroupOptions(RegexOptions.None, options, content);
        }

        /// <summary>
        /// Returns a pattern that disables specified options to a specified pattern.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values that are disabled.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern DisableOptions(RegexOptions options, params object[] content)
        {
            return Options(RegexOptions.None, options, (object)content);
        }

        /// <summary>
        /// Returns an inline comment.
        /// </summary>
        /// <param name="value">A comment text.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static Pattern Comment(string value)
        {
            return new InlineComment(value);
        }

        /// <summary>
        /// Returns a pattern that matches a specified character.
        /// </summary>
        /// <param name="value">The Unicode character.</param>
        /// <returns></returns>
        public static CharPattern Character(char value)
        {
            return CharPattern.Create(value);
        }

        /// <summary>
        /// Returns a pattern that matches a specified character.
        /// </summary>
        /// <param name="charCode">The Unicode character interpreted as <see cref="Int32"/> object.</param>
        /// <returns></returns>
        public static CharPattern Character(int charCode)
        {
            return CharPattern.Create(charCode);
        }

        /// <summary>
        /// Returns a pattern that matches a specified character.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public static CharPattern Character(AsciiChar value)
        {
            return CharPattern.Create(value);
        }

        /// <summary>
        /// Returns a pattern that matches a character from a specified Unicode named block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode named block.</param>
        /// <returns></returns>
        public static CharPattern Character(NamedBlock block)
        {
            return CharPattern.Create(block, false);
        }

        /// <summary>
        /// Returns a pattern that matches a character from a specified Unicode general category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode general category.</param>
        /// <returns></returns>
        public static CharPattern Character(GeneralCategory category)
        {
            return CharPattern.Create(category, false);
        }

        /// <summary>
        /// Returns a character group containing specified characters.
        /// </summary>
        /// <param name="characters">A set of characters any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static CharGroup Character(string characters)
        {
            return CharGroup.Create(characters, false);
        }

        /// <summary>
        /// Returns a character group containing specified <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">A content of a character group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static CharGroup Character(CharGrouping value)
        {
            return CharGroup.Create(value, false);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a specified character..
        /// </summary>
        /// <param name="value">The Unicode character.</param>
        /// <returns></returns>
        public static CharGroup NotCharacter(char value)
        {
            return CharGroup.Create(value, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a specified character..
        /// </summary>
        /// <param name="charCode">The Unicode character interpreted as <see cref="Int32"/> object.</param>
        /// <returns></returns>
        public static CharGroup NotCharacter(int charCode)
        {
            return CharGroup.Create(charCode, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a specified character..
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public static CharGroup NotCharacter(AsciiChar value)
        {
            return CharGroup.Create(value, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from a specified Unicode named block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode named block.</param>
        /// <returns></returns>
        public static CharPattern NotCharacter(NamedBlock block)
        {
            return CharPattern.Create(block, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from a specified Unicode general category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode general category.</param>
        /// <returns></returns>
        public static CharPattern NotCharacter(GeneralCategory category)
        {
            return CharPattern.Create(category, true);
        }

        /// <summary>
        /// Returns a negative character group containing specified characters.
        /// </summary>
        /// <param name="characters">A set of Unicode characters none of which can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static CharGroup NotCharacter(string characters)
        {
            return CharGroup.Create(characters, true);
        }

        /// <summary>
        /// Returns a negative character group containing specified <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">A content of a character group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static CharGroup NotCharacter(CharGrouping value)
        {
            return CharGroup.Create(value, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character in the specified range.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CharGroup Range(char first, char last)
        {
            return CharGroup.Create(first, last, false);
        }

        /// <summary>
        /// Returns a pattern that matches a character in the specified range.
        /// </summary>
        /// <param name="firstCharCode">The first character of the range interpreted as <see cref="Int32"/> object.</param>
        /// <param name="lastCharCode">The last character of the range interpreted as <see cref="Int32"/> object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CharGroup Range(int firstCharCode, int lastCharCode)
        {
            return CharGroup.Create(firstCharCode, lastCharCode, false);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not in the specified range.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CharGroup NotRange(char first, char last)
        {
            return CharGroup.Create(first, last, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not in the specified range.
        /// </summary>
        /// <param name="firstCharCode">The first character of the range interpreted as <see cref="Int32"/> object.</param>
        /// <param name="lastCharCode">The last character of the range interpreted as <see cref="Int32"/> object.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static CharGroup NotRange(int firstCharCode, int lastCharCode)
        {
            return CharGroup.Create(firstCharCode, lastCharCode, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character from a base group except characters from an excluded group.
        /// </summary>
        /// <param name="baseGroup">A base group.</param>
        /// <param name="excludedGroup">An excluded group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static CharSubtraction Subtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup);
        }

        /// <summary>
        /// Returns a pattern that matches a tab.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Tab()
        {
            return Character(AsciiChar.Tab);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of tab characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Tab(int exactCount)
        {
            return Count(exactCount, Tab());
        }

        /// <summary>
        /// Returns a pattern that matches a tab character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Tab(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Tab());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a tab character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotTab()
        {
            return NotCharacter(AsciiChar.Tab);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a tab character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotTab(int exactCount)
        {
            return Count(exactCount, NotTab());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a tab character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotTab(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotTab());
        }

        /// <summary>
        /// Returns a pattern that matches a linefeed.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Linefeed()
        {
            return Character(AsciiChar.Linefeed);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of linefeed characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Linefeed(int exactCount)
        {
            return Count(exactCount, Linefeed());
        }

        /// <summary>
        /// Returns a pattern that matches a linefeed character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Linefeed(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Linefeed());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a linefeed character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotLinefeed()
        {
            return NotCharacter(AsciiChar.Linefeed);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a linefeed character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLinefeed(int exactCount)
        {
            return Count(exactCount, NotLinefeed());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a linefeed character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLinefeed(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLinefeed());
        }

        /// <summary>
        /// Returns a pattern that matches a carriage return.
        /// </summary>
        /// <returns></returns>
        public static CharPattern CarriageReturn()
        {
            return Character(AsciiChar.CarriageReturn);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of carriage return characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CarriageReturn(int exactCount)
        {
            return Count(exactCount, CarriageReturn());
        }

        /// <summary>
        /// Returns a pattern that matches a carriage return character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CarriageReturn(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, CarriageReturn());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a carriage return character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotCarriageReturn()
        {
            return NotCharacter(AsciiChar.CarriageReturn);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a carriage return character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCarriageReturn(int exactCount)
        {
            return Count(exactCount, NotCarriageReturn());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a carriage return character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCarriageReturn(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotCarriageReturn());
        }

        /// <summary>
        /// Returns a pattern that matches a space.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Space()
        {
            return Character(AsciiChar.Space);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of space characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Space(int exactCount)
        {
            return Count(exactCount, Space());
        }

        /// <summary>
        /// Returns a pattern that matches a space character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Space(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Space());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a space character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotSpace()
        {
            return NotCharacter(AsciiChar.Space);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a space character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSpace(int exactCount)
        {
            return Count(exactCount, NotSpace());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a space character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSpace(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotSpace());
        }

        /// <summary>
        /// Returns a pattern that matches a exclamation mark.
        /// </summary>
        /// <returns></returns>
        public static CharPattern ExclamationMark()
        {
            return Character(AsciiChar.ExclamationMark);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of exclamation mark characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup ExclamationMark(int exactCount)
        {
            return Count(exactCount, ExclamationMark());
        }

        /// <summary>
        /// Returns a pattern that matches a exclamation mark character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup ExclamationMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, ExclamationMark());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a exclamation mark character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotExclamationMark()
        {
            return NotCharacter(AsciiChar.ExclamationMark);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a exclamation mark character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotExclamationMark(int exactCount)
        {
            return Count(exactCount, NotExclamationMark());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a exclamation mark character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotExclamationMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotExclamationMark());
        }

        /// <summary>
        /// Returns a pattern that matches a quote mark.
        /// </summary>
        /// <returns></returns>
        public static CharPattern QuoteMark()
        {
            return Character(AsciiChar.QuoteMark);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of quote mark characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup QuoteMark(int exactCount)
        {
            return Count(exactCount, QuoteMark());
        }

        /// <summary>
        /// Returns a pattern that matches a quote mark character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup QuoteMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, QuoteMark());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a quote mark character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotQuoteMark()
        {
            return NotCharacter(AsciiChar.QuoteMark);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a quote mark character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotQuoteMark(int exactCount)
        {
            return Count(exactCount, NotQuoteMark());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a quote mark character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotQuoteMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotQuoteMark());
        }

        /// <summary>
        /// Returns a pattern that matches a number sign.
        /// </summary>
        /// <returns></returns>
        public static CharPattern NumberSign()
        {
            return Character(AsciiChar.NumberSign);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of number sign characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NumberSign(int exactCount)
        {
            return Count(exactCount, NumberSign());
        }

        /// <summary>
        /// Returns a pattern that matches a number sign character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NumberSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NumberSign());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a number sign character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotNumberSign()
        {
            return NotCharacter(AsciiChar.NumberSign);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a number sign character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotNumberSign(int exactCount)
        {
            return Count(exactCount, NotNumberSign());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a number sign character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotNumberSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotNumberSign());
        }

        /// <summary>
        /// Returns a pattern that matches a dollar.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Dollar()
        {
            return Character(AsciiChar.Dollar);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of dollar characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Dollar(int exactCount)
        {
            return Count(exactCount, Dollar());
        }

        /// <summary>
        /// Returns a pattern that matches a dollar character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Dollar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Dollar());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a dollar character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotDollar()
        {
            return NotCharacter(AsciiChar.Dollar);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a dollar character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDollar(int exactCount)
        {
            return Count(exactCount, NotDollar());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a dollar character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDollar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotDollar());
        }

        /// <summary>
        /// Returns a pattern that matches a percent.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Percent()
        {
            return Character(AsciiChar.Percent);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of percent characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Percent(int exactCount)
        {
            return Count(exactCount, Percent());
        }

        /// <summary>
        /// Returns a pattern that matches a percent character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Percent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Percent());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a percent character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotPercent()
        {
            return NotCharacter(AsciiChar.Percent);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a percent character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotPercent(int exactCount)
        {
            return Count(exactCount, NotPercent());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a percent character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotPercent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotPercent());
        }

        /// <summary>
        /// Returns a pattern that matches a ampersand.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Ampersand()
        {
            return Character(AsciiChar.Ampersand);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of ampersand characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Ampersand(int exactCount)
        {
            return Count(exactCount, Ampersand());
        }

        /// <summary>
        /// Returns a pattern that matches a ampersand character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Ampersand(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Ampersand());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a ampersand character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotAmpersand()
        {
            return NotCharacter(AsciiChar.Ampersand);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a ampersand character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAmpersand(int exactCount)
        {
            return Count(exactCount, NotAmpersand());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a ampersand character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAmpersand(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAmpersand());
        }

        /// <summary>
        /// Returns a pattern that matches a apostrophe.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Apostrophe()
        {
            return Character(AsciiChar.Apostrophe);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of apostrophe characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Apostrophe(int exactCount)
        {
            return Count(exactCount, Apostrophe());
        }

        /// <summary>
        /// Returns a pattern that matches a apostrophe character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Apostrophe(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Apostrophe());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a apostrophe character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotApostrophe()
        {
            return NotCharacter(AsciiChar.Apostrophe);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a apostrophe character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotApostrophe(int exactCount)
        {
            return Count(exactCount, NotApostrophe());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a apostrophe character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotApostrophe(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotApostrophe());
        }

        /// <summary>
        /// Returns a pattern that matches a start parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharPattern StartParenthesis()
        {
            return Character(AsciiChar.StartParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of start parenthesis characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartParenthesis(int exactCount)
        {
            return Count(exactCount, StartParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a start parenthesis character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, StartParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a start parenthesis character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotStartParenthesis()
        {
            return NotCharacter(AsciiChar.StartParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a start parenthesis character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartParenthesis(int exactCount)
        {
            return Count(exactCount, NotStartParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a start parenthesis character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotStartParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a end parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharPattern EndParenthesis()
        {
            return Character(AsciiChar.EndParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of end parenthesis characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndParenthesis(int exactCount)
        {
            return Count(exactCount, EndParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a end parenthesis character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EndParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a end parenthesis character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotEndParenthesis()
        {
            return NotCharacter(AsciiChar.EndParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a end parenthesis character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndParenthesis(int exactCount)
        {
            return Count(exactCount, NotEndParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a end parenthesis character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEndParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a asterisk.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Asterisk()
        {
            return Character(AsciiChar.Asterisk);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of asterisk characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Asterisk(int exactCount)
        {
            return Count(exactCount, Asterisk());
        }

        /// <summary>
        /// Returns a pattern that matches a asterisk character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Asterisk(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Asterisk());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a asterisk character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotAsterisk()
        {
            return NotCharacter(AsciiChar.Asterisk);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a asterisk character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAsterisk(int exactCount)
        {
            return Count(exactCount, NotAsterisk());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a asterisk character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAsterisk(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAsterisk());
        }

        /// <summary>
        /// Returns a pattern that matches a plus.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Plus()
        {
            return Character(AsciiChar.Plus);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of plus characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Plus(int exactCount)
        {
            return Count(exactCount, Plus());
        }

        /// <summary>
        /// Returns a pattern that matches a plus character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Plus(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Plus());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a plus character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotPlus()
        {
            return NotCharacter(AsciiChar.Plus);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a plus character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotPlus(int exactCount)
        {
            return Count(exactCount, NotPlus());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a plus character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotPlus(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotPlus());
        }

        /// <summary>
        /// Returns a pattern that matches a comma.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Comma()
        {
            return Character(AsciiChar.Comma);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of comma characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Comma(int exactCount)
        {
            return Count(exactCount, Comma());
        }

        /// <summary>
        /// Returns a pattern that matches a comma character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Comma(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Comma());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a comma character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotComma()
        {
            return NotCharacter(AsciiChar.Comma);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a comma character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotComma(int exactCount)
        {
            return Count(exactCount, NotComma());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a comma character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotComma(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotComma());
        }

        /// <summary>
        /// Returns a pattern that matches a hyphen.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Hyphen()
        {
            return Character(AsciiChar.Hyphen);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of hyphen characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Hyphen(int exactCount)
        {
            return Count(exactCount, Hyphen());
        }

        /// <summary>
        /// Returns a pattern that matches a hyphen character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Hyphen(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Hyphen());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a hyphen character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotHyphen()
        {
            return NotCharacter(AsciiChar.Hyphen);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a hyphen character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotHyphen(int exactCount)
        {
            return Count(exactCount, NotHyphen());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a hyphen character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotHyphen(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotHyphen());
        }

        /// <summary>
        /// Returns a pattern that matches a dot.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Dot()
        {
            return Character(AsciiChar.Dot);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of dot characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Dot(int exactCount)
        {
            return Count(exactCount, Dot());
        }

        /// <summary>
        /// Returns a pattern that matches a dot character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Dot(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Dot());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a dot character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotDot()
        {
            return NotCharacter(AsciiChar.Dot);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a dot character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDot(int exactCount)
        {
            return Count(exactCount, NotDot());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a dot character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDot(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotDot());
        }

        /// <summary>
        /// Returns a pattern that matches a slash.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Slash()
        {
            return Character(AsciiChar.Slash);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of slash characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Slash(int exactCount)
        {
            return Count(exactCount, Slash());
        }

        /// <summary>
        /// Returns a pattern that matches a slash character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Slash(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Slash());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a slash character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotSlash()
        {
            return NotCharacter(AsciiChar.Slash);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a slash character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSlash(int exactCount)
        {
            return Count(exactCount, NotSlash());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a slash character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSlash(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotSlash());
        }

        /// <summary>
        /// Returns a pattern that matches a colon.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Colon()
        {
            return Character(AsciiChar.Colon);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of colon characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Colon(int exactCount)
        {
            return Count(exactCount, Colon());
        }

        /// <summary>
        /// Returns a pattern that matches a colon character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Colon(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Colon());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a colon character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotColon()
        {
            return NotCharacter(AsciiChar.Colon);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a colon character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotColon(int exactCount)
        {
            return Count(exactCount, NotColon());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a colon character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotColon(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotColon());
        }

        /// <summary>
        /// Returns a pattern that matches a semicolon.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Semicolon()
        {
            return Character(AsciiChar.Semicolon);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of semicolon characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Semicolon(int exactCount)
        {
            return Count(exactCount, Semicolon());
        }

        /// <summary>
        /// Returns a pattern that matches a semicolon character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Semicolon(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Semicolon());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a semicolon character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotSemicolon()
        {
            return NotCharacter(AsciiChar.Semicolon);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a semicolon character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSemicolon(int exactCount)
        {
            return Count(exactCount, NotSemicolon());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a semicolon character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSemicolon(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotSemicolon());
        }

        /// <summary>
        /// Returns a pattern that matches a start angle bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern StartAngleBracket()
        {
            return Character(AsciiChar.StartAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of start angle bracket characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartAngleBracket(int exactCount)
        {
            return Count(exactCount, StartAngleBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a start angle bracket character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartAngleBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, StartAngleBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a start angle bracket character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotStartAngleBracket()
        {
            return NotCharacter(AsciiChar.StartAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a start angle bracket character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartAngleBracket(int exactCount)
        {
            return Count(exactCount, NotStartAngleBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a start angle bracket character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartAngleBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotStartAngleBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a equals sign.
        /// </summary>
        /// <returns></returns>
        public static CharPattern EqualsSign()
        {
            return Character(AsciiChar.EqualsSign);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of equals sign characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EqualsSign(int exactCount)
        {
            return Count(exactCount, EqualsSign());
        }

        /// <summary>
        /// Returns a pattern that matches a equals sign character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EqualsSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EqualsSign());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a equals sign character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotEqualsSign()
        {
            return NotCharacter(AsciiChar.EqualsSign);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a equals sign character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEqualsSign(int exactCount)
        {
            return Count(exactCount, NotEqualsSign());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a equals sign character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEqualsSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEqualsSign());
        }

        /// <summary>
        /// Returns a pattern that matches a end angle bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern EndAngleBracket()
        {
            return Character(AsciiChar.EndAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of end angle bracket characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndAngleBracket(int exactCount)
        {
            return Count(exactCount, EndAngleBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a end angle bracket character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndAngleBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EndAngleBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a end angle bracket character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotEndAngleBracket()
        {
            return NotCharacter(AsciiChar.EndAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a end angle bracket character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndAngleBracket(int exactCount)
        {
            return Count(exactCount, NotEndAngleBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a end angle bracket character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndAngleBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEndAngleBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a question mark.
        /// </summary>
        /// <returns></returns>
        public static CharPattern QuestionMark()
        {
            return Character(AsciiChar.QuestionMark);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of question mark characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup QuestionMark(int exactCount)
        {
            return Count(exactCount, QuestionMark());
        }

        /// <summary>
        /// Returns a pattern that matches a question mark character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup QuestionMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, QuestionMark());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a question mark character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotQuestionMark()
        {
            return NotCharacter(AsciiChar.QuestionMark);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a question mark character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotQuestionMark(int exactCount)
        {
            return Count(exactCount, NotQuestionMark());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a question mark character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotQuestionMark(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotQuestionMark());
        }

        /// <summary>
        /// Returns a pattern that matches a at sign.
        /// </summary>
        /// <returns></returns>
        public static CharPattern AtSign()
        {
            return Character(AsciiChar.AtSign);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of at sign characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AtSign(int exactCount)
        {
            return Count(exactCount, AtSign());
        }

        /// <summary>
        /// Returns a pattern that matches a at sign character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AtSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AtSign());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a at sign character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotAtSign()
        {
            return NotCharacter(AsciiChar.AtSign);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a at sign character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAtSign(int exactCount)
        {
            return Count(exactCount, NotAtSign());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a at sign character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAtSign(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAtSign());
        }

        /// <summary>
        /// Returns a pattern that matches a start square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern StartSquareBracket()
        {
            return Character(AsciiChar.StartSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of start square bracket characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartSquareBracket(int exactCount)
        {
            return Count(exactCount, StartSquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a start square bracket character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, StartSquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a start square bracket character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotStartSquareBracket()
        {
            return NotCharacter(AsciiChar.StartSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a start square bracket character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartSquareBracket(int exactCount)
        {
            return Count(exactCount, NotStartSquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a start square bracket character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotStartSquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a backslash.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Backslash()
        {
            return Character(AsciiChar.Backslash);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of backslash characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Backslash(int exactCount)
        {
            return Count(exactCount, Backslash());
        }

        /// <summary>
        /// Returns a pattern that matches a backslash character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Backslash(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Backslash());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a backslash character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotBackslash()
        {
            return NotCharacter(AsciiChar.Backslash);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a backslash character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotBackslash(int exactCount)
        {
            return Count(exactCount, NotBackslash());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a backslash character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotBackslash(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotBackslash());
        }

        /// <summary>
        /// Returns a pattern that matches a end square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern EndSquareBracket()
        {
            return Character(AsciiChar.EndSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of end square bracket characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndSquareBracket(int exactCount)
        {
            return Count(exactCount, EndSquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a end square bracket character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EndSquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a end square bracket character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotEndSquareBracket()
        {
            return NotCharacter(AsciiChar.EndSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a end square bracket character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndSquareBracket(int exactCount)
        {
            return Count(exactCount, NotEndSquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a end square bracket character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEndSquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a circumflex accent.
        /// </summary>
        /// <returns></returns>
        public static CharPattern CircumflexAccent()
        {
            return Character(AsciiChar.CircumflexAccent);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of circumflex accent characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CircumflexAccent(int exactCount)
        {
            return Count(exactCount, CircumflexAccent());
        }

        /// <summary>
        /// Returns a pattern that matches a circumflex accent character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CircumflexAccent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, CircumflexAccent());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a circumflex accent character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotCircumflexAccent()
        {
            return NotCharacter(AsciiChar.CircumflexAccent);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a circumflex accent character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCircumflexAccent(int exactCount)
        {
            return Count(exactCount, NotCircumflexAccent());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a circumflex accent character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCircumflexAccent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotCircumflexAccent());
        }

        /// <summary>
        /// Returns a pattern that matches a underscore.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Underscore()
        {
            return Character(AsciiChar.Underscore);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of underscore characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Underscore(int exactCount)
        {
            return Count(exactCount, Underscore());
        }

        /// <summary>
        /// Returns a pattern that matches a underscore character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Underscore(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Underscore());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a underscore character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotUnderscore()
        {
            return NotCharacter(AsciiChar.Underscore);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a underscore character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotUnderscore(int exactCount)
        {
            return Count(exactCount, NotUnderscore());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a underscore character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotUnderscore(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotUnderscore());
        }

        /// <summary>
        /// Returns a pattern that matches a grave accent.
        /// </summary>
        /// <returns></returns>
        public static CharPattern GraveAccent()
        {
            return Character(AsciiChar.GraveAccent);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of grave accent characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup GraveAccent(int exactCount)
        {
            return Count(exactCount, GraveAccent());
        }

        /// <summary>
        /// Returns a pattern that matches a grave accent character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup GraveAccent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, GraveAccent());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a grave accent character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotGraveAccent()
        {
            return NotCharacter(AsciiChar.GraveAccent);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a grave accent character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotGraveAccent(int exactCount)
        {
            return Count(exactCount, NotGraveAccent());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a grave accent character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotGraveAccent(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotGraveAccent());
        }

        /// <summary>
        /// Returns a pattern that matches a start curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern StartCurlyBracket()
        {
            return Character(AsciiChar.StartCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of start curly bracket characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartCurlyBracket(int exactCount)
        {
            return Count(exactCount, StartCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a start curly bracket character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup StartCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, StartCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a start curly bracket character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotStartCurlyBracket()
        {
            return NotCharacter(AsciiChar.StartCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a start curly bracket character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotStartCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a start curly bracket character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotStartCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotStartCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a vertical line.
        /// </summary>
        /// <returns></returns>
        public static CharPattern VerticalLine()
        {
            return Character(AsciiChar.VerticalLine);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of vertical line characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup VerticalLine(int exactCount)
        {
            return Count(exactCount, VerticalLine());
        }

        /// <summary>
        /// Returns a pattern that matches a vertical line character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup VerticalLine(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, VerticalLine());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a vertical line character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotVerticalLine()
        {
            return NotCharacter(AsciiChar.VerticalLine);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a vertical line character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotVerticalLine(int exactCount)
        {
            return Count(exactCount, NotVerticalLine());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a vertical line character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotVerticalLine(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotVerticalLine());
        }

        /// <summary>
        /// Returns a pattern that matches a end curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern EndCurlyBracket()
        {
            return Character(AsciiChar.EndCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of end curly bracket characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndCurlyBracket(int exactCount)
        {
            return Count(exactCount, EndCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a end curly bracket character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EndCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, EndCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a end curly bracket character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotEndCurlyBracket()
        {
            return NotCharacter(AsciiChar.EndCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a end curly bracket character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotEndCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a end curly bracket character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEndCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotEndCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a tilde.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Tilde()
        {
            return Character(AsciiChar.Tilde);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of tilde characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Tilde(int exactCount)
        {
            return Count(exactCount, Tilde());
        }

        /// <summary>
        /// Returns a pattern that matches a tilde character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Tilde(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Tilde());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a tilde character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotTilde()
        {
            return NotCharacter(AsciiChar.Tilde);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a tilde character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotTilde(int exactCount)
        {
            return Count(exactCount, NotTilde());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a tilde character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotTilde(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotTilde());
        }

        /// <summary>
        /// Returns a pattern that matches any character except linefeed (or any character if the Singleline option is applied).
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern Any()
        {
            return new AnyChar();
        }

        /// <summary>
        /// Returns a pattern that matches any character except linefeed (or any character if the Singleline option is applied) specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Any(int exactCount)
        {
            return Count(exactCount, Any());
        }

        /// <summary>
        /// Returns a pattern that matches any character except linefeed (or any character if the Singleline option is applied) from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Any(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Any());
        }

        /// <summary>
        /// Returns a pattern that matches any character.
        /// </summary>
        /// <returns></returns>
        public static CharGroup AnyInvariant()
        {
            return Character(CharGroupings.WhiteSpace().NotWhiteSpace());
        }

        /// <summary>
        /// Returns a pattern that matches any character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AnyInvariant(int exactCount)
        {
            return Count(exactCount, AnyInvariant());
        }

        /// <summary>
        /// Returns a pattern that matches any character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
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
        /// Returns a pattern that matches a digit character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Digit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Digit());
        }

        /// <summary>
        /// Returns a pattern that matches a digit character one or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedGroup Digits()
        {
            return OneMany(Digit());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a digit character.
        /// </summary>
        /// <returns></returns>
        public static CharPattern NotDigit()
        {
            return CharPattern.Create(CharClass.NotDigit);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a digit character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDigit(int exactCount)
        {
            return Count(exactCount, NotDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a digit character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a digit character one or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedGroup NotDigits()
        {
            return OneMany(NotDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a white-space character.
        /// </summary>
        /// <returns></returns>
        public static CharPattern WhiteSpace()
        {
            return CharPattern.Create(CharClass.WhiteSpace);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of white-space characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup WhiteSpace(int exactCount)
        {
            return Count(exactCount, WhiteSpace());
        }

        /// <summary>
        /// Returns a pattern that matches a white-space character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup WhiteSpace(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, WhiteSpace());
        }

        /// <summary>
        /// Returns a pattern that matches a white-space character one or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedGroup WhiteSpaces()
        {
            return OneMany(WhiteSpace());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a white-space character.
        /// </summary>
        /// <returns></returns>
        public static CharPattern NotWhiteSpace()
        {
            return CharPattern.Create(CharClass.NotWhiteSpace);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a white-space character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotWhiteSpace(int exactCount)
        {
            return Count(exactCount, NotWhiteSpace());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a white-space character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotWhiteSpace(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotWhiteSpace());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a white-space character one or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedGroup NotWhiteSpaces()
        {
            return OneMany(NotWhiteSpace());
        }

        /// <summary>
        /// Returns a pattern that matches a word character.
        /// </summary>
        /// <returns></returns>
        public static CharPattern WordChar()
        {
            return CharPattern.Create(CharClass.WordChar);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of word characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup WordChar(int exactCount)
        {
            return Count(exactCount, WordChar());
        }

        /// <summary>
        /// Returns a pattern that matches a word character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup WordChar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, WordChar());
        }

        /// <summary>
        /// Returns a pattern that matches a word character one or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedGroup WordChars()
        {
            return OneMany(WordChar());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a word character.
        /// </summary>
        /// <returns></returns>
        public static CharPattern NotWordChar()
        {
            return CharPattern.Create(CharClass.NotWordChar);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a word character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotWordChar(int exactCount)
        {
            return Count(exactCount, NotWordChar());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a word character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotWordChar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotWordChar());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a word character one or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedGroup NotWordChars()
        {
            return OneMany(NotWordChar());
        }

        /// <summary>
        /// Returns a pattern that matches a newline character. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NewLineChar()
        {
            return Character(CharGroupings.CarriageReturn().Linefeed());
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of newline characters. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NewLineChar(int exactCount)
        {
            return Count(exactCount, NewLineChar());
        }

        /// <summary>
        /// Returns a pattern that matches a newline character from minimal to maximum times. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NewLineChar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NewLineChar());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a newline character. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotNewLineChar()
        {
            return NotCharacter(CharGroupings.CarriageReturn().Linefeed());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a newline character specified number of times. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotNewLineChar(int exactCount)
        {
            return Count(exactCount, NotNewLineChar());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a newline character from minimal to maximum times. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotNewLineChar(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotNewLineChar());
        }

        /// <summary>
        /// Returns a pattern that matches an alphanumeric character. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup Alphanumeric()
        {
            return Character(CharGroupings.Alphanumeric());
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of alphanumeric characters. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Alphanumeric(int exactCount)
        {
            return Count(exactCount, Alphanumeric());
        }

        /// <summary>
        /// Returns a pattern that matches an alphanumeric character from minimal to maximum times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Alphanumeric(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Alphanumeric());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an alphanumeric character. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotAlphanumeric()
        {
            return NotCharacter(CharGroupings.Alphanumeric());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an alphanumeric character specified number of times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAlphanumeric(int exactCount)
        {
            return Count(exactCount, NotAlphanumeric());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an alphanumeric character from minimal to maximum times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAlphanumeric(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAlphanumeric());
        }

        /// <summary>
        /// Returns a pattern that matches an lower-case alphanumeric character. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup AlphanumericLower()
        {
            return Character(CharGroupings.AlphanumericLower());
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of lower-case alphanumeric characters. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AlphanumericLower(int exactCount)
        {
            return Count(exactCount, AlphanumericLower());
        }

        /// <summary>
        /// Returns a pattern that matches an lower-case alphanumeric character from minimal to maximum times. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AlphanumericLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AlphanumericLower());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an lower-case alphanumeric character. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotAlphanumericLower()
        {
            return NotCharacter(CharGroupings.AlphanumericLower());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an lower-case alphanumeric character specified number of times. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAlphanumericLower(int exactCount)
        {
            return Count(exactCount, NotAlphanumericLower());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an lower-case alphanumeric character from minimal to maximum times. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAlphanumericLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAlphanumericLower());
        }

        /// <summary>
        /// Returns a pattern that matches an upper-case alphanumeric character. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup AlphanumericUpper()
        {
            return Character(CharGroupings.AlphanumericUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of upper-case alphanumeric characters. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AlphanumericUpper(int exactCount)
        {
            return Count(exactCount, AlphanumericUpper());
        }

        /// <summary>
        /// Returns a pattern that matches an upper-case alphanumeric character from minimal to maximum times. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AlphanumericUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AlphanumericUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an upper-case alphanumeric character. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotAlphanumericUpper()
        {
            return NotCharacter(CharGroupings.AlphanumericUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an upper-case alphanumeric character specified number of times. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAlphanumericUpper(int exactCount)
        {
            return Count(exactCount, NotAlphanumericUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an upper-case alphanumeric character from minimal to maximum times. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAlphanumericUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAlphanumericUpper());
        }

        /// <summary>
        /// Returns a pattern that matches an alphanumeric character or an underscore. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup AlphanumericUnderscore()
        {
            return Character(CharGroupings.AlphanumericUnderscore());
        }

        /// <summary>
        /// Returns a pattern that matches an alphanumeric character or an underscore specified number of times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AlphanumericUnderscore(int exactCount)
        {
            return Count(exactCount, AlphanumericUnderscore());
        }

        /// <summary>
        /// Returns a pattern that matches an alphanumeric character or an underscore from minimal to maximum times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AlphanumericUnderscore(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, AlphanumericUnderscore());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither alphanumeric character nor underscore. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotAlphanumericUnderscore()
        {
            return NotCharacter(CharGroupings.AlphanumericUnderscore());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither alphanumeric character nor underscore specified number of times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAlphanumericUnderscore(int exactCount)
        {
            return Count(exactCount, NotAlphanumericUnderscore());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither alphanumeric character nor underscore from minimal to maximum times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAlphanumericUnderscore(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotAlphanumericUnderscore());
        }

        /// <summary>
        /// Returns a pattern that matches a latin alphabet letter.
        /// </summary>
        /// <returns></returns>
        public static CharGroup LatinLetter()
        {
            return Character(CharGroupings.LatinLetter());
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of latin alphabet letters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LatinLetter(int exactCount)
        {
            return Count(exactCount, LatinLetter());
        }

        /// <summary>
        /// Returns a pattern that matches a latin alphabet letter from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LatinLetter(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LatinLetter());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a latin alphabet letter.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotLatinLetter()
        {
            return NotCharacter(CharGroupings.LatinLetter());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a latin alphabet letter specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLatinLetter(int exactCount)
        {
            return Count(exactCount, NotLatinLetter());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a latin alphabet letter from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLatinLetter(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLatinLetter());
        }

        /// <summary>
        /// Returns a pattern that matches a latin alphabet lower-case letter.
        /// </summary>
        /// <returns></returns>
        public static CharGroup LatinLetterLower()
        {
            return Character(CharGroupings.LatinLetterLower());
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of latin alphabet lower-case letters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LatinLetterLower(int exactCount)
        {
            return Count(exactCount, LatinLetterLower());
        }

        /// <summary>
        /// Returns a pattern that matches a latin alphabet lower-case letter from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LatinLetterLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LatinLetterLower());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a latin alphabet lower-case letter.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotLatinLetterLower()
        {
            return NotCharacter(CharGroupings.LatinLetterLower());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a latin alphabet lower-case letter specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLatinLetterLower(int exactCount)
        {
            return Count(exactCount, NotLatinLetterLower());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a latin alphabet lower-case letter from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLatinLetterLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLatinLetterLower());
        }

        /// <summary>
        /// Returns a pattern that matches a latin alphabet upper-case letter.
        /// </summary>
        /// <returns></returns>
        public static CharGroup LatinLetterUpper()
        {
            return Character(CharGroupings.LatinLetterUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of latin alphabet upper-case letters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LatinLetterUpper(int exactCount)
        {
            return Count(exactCount, LatinLetterUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a latin alphabet upper-case letter from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LatinLetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LatinLetterUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a latin alphabet upper-case letter.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotLatinLetterUpper()
        {
            return NotCharacter(CharGroupings.LatinLetterUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a latin alphabet upper-case letter specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLatinLetterUpper(int exactCount)
        {
            return Count(exactCount, NotLatinLetterUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a latin alphabet upper-case letter from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLatinLetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLatinLetterUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a letter from Unicode general category LetterLowercase.
        /// </summary>
        /// <returns></returns>
        public static CharPattern LetterLower()
        {
            return Character(GeneralCategory.LetterLowercase);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of letters from Unicode general category LetterLowercase.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LetterLower(int exactCount)
        {
            return Count(exactCount, LetterLower());
        }

        /// <summary>
        /// Returns a pattern that matches a letter from Unicode general category LetterLowercase from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LetterLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LetterLower());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a letter from Unicode general category LetterLowercase.
        /// </summary>
        /// <returns></returns>
        public static CharPattern NotLetterLower()
        {
            return NotCharacter(GeneralCategory.LetterLowercase);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a letter from Unicode general category LetterLowercase specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLetterLower(int exactCount)
        {
            return Count(exactCount, NotLetterLower());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a letter from Unicode general category LetterLowercase from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLetterLower(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLetterLower());
        }

        /// <summary>
        /// Returns a pattern that matches a letter from Unicode general category LetterUppercase.
        /// </summary>
        /// <returns></returns>
        public static CharPattern LetterUpper()
        {
            return Character(GeneralCategory.LetterUppercase);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of letters from Unicode general category LetterUppercase.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LetterUpper(int exactCount)
        {
            return Count(exactCount, LetterUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a letter from Unicode general category LetterUppercase from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, LetterUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a letter from Unicode general category LetterUppercase.
        /// </summary>
        /// <returns></returns>
        public static CharPattern NotLetterUpper()
        {
            return NotCharacter(GeneralCategory.LetterUppercase);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a letter from Unicode general category LetterUppercase specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLetterUpper(int exactCount)
        {
            return Count(exactCount, NotLetterUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a letter from Unicode general category LetterUppercase from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLetterUpper(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotLetterUpper());
        }

        /// <summary>
        /// Returns a pattern that matches an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup ArabicDigit()
        {
            return Character(CharGroupings.ArabicDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of arabic digits.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup ArabicDigit(int exactCount)
        {
            return Count(exactCount, ArabicDigit());
        }

        /// <summary>
        /// Returns a pattern that matches an arabic digit from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup ArabicDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, ArabicDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotArabicDigit()
        {
            return NotCharacter(CharGroupings.ArabicDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an arabic digit specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotArabicDigit(int exactCount)
        {
            return Count(exactCount, NotArabicDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an arabic digit from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotArabicDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotArabicDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a hexadecimal digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup HexadecimalDigit()
        {
            return Character(CharGroupings.HexadecimalDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of hexadecimal digits.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup HexadecimalDigit(int exactCount)
        {
            return Count(exactCount, HexadecimalDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a hexadecimal digit from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup HexadecimalDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, HexadecimalDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a hexadecimal digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotHexadecimalDigit()
        {
            return NotCharacter(CharGroupings.HexadecimalDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a hexadecimal digit specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotHexadecimalDigit(int exactCount)
        {
            return Count(exactCount, NotHexadecimalDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a hexadecimal digit from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotHexadecimalDigit(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotHexadecimalDigit());
        }

        /// <summary>
        /// Returns a pattern that matches starting or ending parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharGroup Parenthesis()
        {
            return Character(CharGroupings.Parenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches starting or ending parenthesis specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Parenthesis(int exactCount)
        {
            return Count(exactCount, Parenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches starting or ending parenthesis from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Parenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, Parenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither starting nor ending parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotParenthesis()
        {
            return NotCharacter(CharGroupings.Parenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither starting nor ending parenthesis specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotParenthesis(int exactCount)
        {
            return Count(exactCount, NotParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither starting nor ending parenthesis from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotParenthesis(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches starting or ending curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGroup CurlyBracket()
        {
            return Character(CharGroupings.CurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches starting or ending curly bracket specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CurlyBracket(int exactCount)
        {
            return Count(exactCount, CurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches starting or ending curly bracket from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, CurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither starting nor ending curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotCurlyBracket()
        {
            return NotCharacter(CharGroupings.CurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither starting nor ending curly bracket specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither starting nor ending curly bracket from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCurlyBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches starting or ending square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGroup SquareBracket()
        {
            return Character(CharGroupings.SquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches starting or ending square bracket specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup SquareBracket(int exactCount)
        {
            return Count(exactCount, SquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches starting or ending square bracket from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup SquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, SquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither starting nor ending square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotSquareBracket()
        {
            return NotCharacter(CharGroupings.SquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither starting nor ending square bracket specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSquareBracket(int exactCount)
        {
            return Count(exactCount, NotSquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither starting nor ending square bracket from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSquareBracket(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, NotSquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a white-space character except carriage return and linefeed.
        /// </summary>
        /// <returns></returns>
        public static CharSubtraction WhiteSpaceExceptNewLine()
        {
            return WhiteSpace().Except(NewLineChar());
        }

        /// <summary>
        /// Returns a pattern that matches a white-space character except carriage return and linefeed. The character has to be matched specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup WhiteSpaceExceptNewLine(int exactCount)
        {
            return Count(exactCount, WhiteSpaceExceptNewLine());
        }

        /// <summary>
        /// Returns a pattern that matches a white-space character except carriage return and linefeed. The character has to be matched from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup WhiteSpaceExceptNewLine(int minCount, int maxCount)
        {
            return Count(minCount, maxCount, WhiteSpaceExceptNewLine());
        }

        /// <summary>
        /// Returns a pattern that matches two apostrophes.
        /// </summary>
        /// <returns></returns>
        public static Pattern Apostrophes()
        {
            return Apostrophe().Apostrophe();
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with apostrophes.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern Apostrophes(object content)
        {
            return Pattern.Surround(AsciiChar.Apostrophe, content);
        }

        /// <summary>
        /// Returns a pattern that matches two quotation marks.
        /// </summary>
        /// <returns></returns>
        public static Pattern QuoteMarks()
        {
            return QuoteMark().QuoteMark();
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with quotation marks.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern QuoteMarks(object content)
        {
            return Pattern.Surround(AsciiChar.QuoteMark, content);
        }

        /// <summary>
        /// Returns a pattern that matches starting parenthesis followed with ending parenthesis.
        /// </summary>
        /// <returns></returns>
        public static Pattern Parentheses()
        {
            return StartParenthesis().EndParenthesis();
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with starting and ending parenthesis.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern Parentheses(object content)
        {
            return Pattern.Surround(AsciiChar.StartParenthesis, content, AsciiChar.EndParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches starting curly bracket followed with ending curly bracket.
        /// </summary>
        /// <returns></returns>
        public static Pattern CurlyBrackets()
        {
            return StartCurlyBracket().EndCurlyBracket();
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with starting and ending curly bracket.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern CurlyBrackets(object content)
        {
            return Pattern.Surround(AsciiChar.StartCurlyBracket, content, AsciiChar.EndCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches starting square bracket followed with ending square bracket.
        /// </summary>
        /// <returns></returns>
        public static Pattern SquareBrackets()
        {
            return StartSquareBracket().EndSquareBracket();
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with starting and ending square bracket.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SquareBrackets(object content)
        {
            return Pattern.Surround(AsciiChar.StartSquareBracket, content, AsciiChar.EndSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches starting angle bracket followed with ending angle bracket.
        /// </summary>
        /// <returns></returns>
        public static Pattern AngleBrackets()
        {
            return StartAngleBracket().EndAngleBracket();
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with starting and ending angle bracket.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern AngleBrackets(object content)
        {
            return Pattern.Surround(AsciiChar.StartAngleBracket, content, AsciiChar.EndAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified character zero or many times.
        /// </summary>
        /// <param name="value">The Unicode character.</param>
        /// <returns></returns>
        public static QuantifiedPattern WhileChar(char value)
        {
            return Character(value).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches a specified character zero or many times.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public static QuantifiedPattern WhileChar(AsciiChar value)
        {
            return Character(value).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches a specified character zero or many times.
        /// </summary>
        /// <param name="value">A set of Unicode characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedPattern WhileChar(CharGrouping value)
        {
            return Character(value).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches a white-space character zero or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedPattern WhileWhiteSpace()
        {
            return WhiteSpace().MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a specified character zero or many times.
        /// </summary>
        /// <param name="value">The Unicode character.</param>
        /// <returns></returns>
        public static QuantifiedPattern WhileNotChar(char value)
        {
            return NotCharacter(value).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a specified character zero or many times.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public static QuantifiedPattern WhileNotChar(AsciiChar value)
        {
            return NotCharacter(value).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a specified character zero or many times.
        /// </summary>
        /// <param name="value">A set of Unicode characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedPattern WhileNotChar(CharGrouping value)
        {
            return NotCharacter(value).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither a carriage return not a linefeed zero or many times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedPattern WhileNotNewLine()
        {
            return WhileNotChar(CharGroupings.NewLineChar());
        }

#if DEBUG
        /// <summary>
        /// Returns a pattern that matches a character that is not a specified character zero or many times followed with a specified character.
        /// </summary>
        /// <param name="value">The Unicode character.</param>
        /// <returns></returns>
        public static QuantifiablePattern GoToChar(char value)
        {
            return NotCharacter(value).MaybeMany().Character(value).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a specified character zero or many times followed with a specified character.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public static QuantifiablePattern GoToChar(AsciiChar value)
        {
            return NotCharacter(value).MaybeMany().Character(value).AsNoncapturingGroup();
        }
#endif

        /// <summary>
        /// Returns a pattern that matches any character except linefeed (or any character if the Singleline option is applied) zero or many times but as few times as possible.
        /// </summary>
        /// <returns></returns>
        public static Pattern Crawl()
        {
            return Any().MaybeMany().Lazy();
        }

        /// <summary>
        /// Returns a pattern that matches any character zero or many times but as few times as possible.
        /// </summary>
        /// <returns></returns>
        public static Pattern CrawlInvariant()
        {
            return AnyInvariant().MaybeMany().Lazy();
        }

        /// <summary>
        /// Returns a pattern that matches a linefeed and an optional carriage return before it. Carriage return will be matched if present and not already consumed by regex engine..
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NewLine()
        {
            return CarriageReturn().Maybe().Linefeed().AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that is never matched. The pattern is an empty negative lookahead assertion.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern Never()
        {
            return NotAssert(string.Empty);
        }

        internal static Pattern ValidGroupName()
        {
            return EntireInput(
                Group(Range('1', '9').ArabicDigit().MaybeMany()) |
                WordChar().Except(ArabicDigit()).WordChar().MaybeMany());
        }
    }
}
