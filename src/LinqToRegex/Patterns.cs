// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Provides static methods that returns various kinds of patterns.
    /// </summary>
    public static class Patterns
    {
        /// <summary>
        /// Concatenates the elements of a <see cref="IEnumerable"/> collection.
        /// </summary>
        /// <param name="content">A collection object that implements <see cref="IEnumerable"/>.</param>
        /// <returns></returns>
        public static Pattern Concat(IEnumerable content)
        {
            return new ConcatPattern(content);
        }

        /// <summary>
        /// Concatenates the elements in a specified Object array.
        /// </summary>
        /// <param name="content">An object array that contains the elements to concatenate.</param>
        /// <returns></returns>
        public static Pattern Concat(params object[] content)
        {
            return new ConcatPattern(content);
        }

        /// <summary>
        /// Concatenates the elements of a <see cref="IEnumerable"/> collection using the specified separator between each element.
        /// </summary>
        /// <param name="separator">The pattern to use as a separator.</param>
        /// <param name="values">A collection object that implements <see cref="IEnumerable"/>.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern Join(object separator, IEnumerable values)
        {
            return new JoinContainer(separator, values);
        }

        /// <summary>
        /// Concatenates the elements of an object array, using the specified separator between each element.
        /// </summary>
        /// <param name="separator">The pattern to use as a separator.</param>
        /// <param name="values">An object array that contains the patterns to concatenate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern Join(object separator, params object[] values)
        {
            return new JoinContainer(separator, values);
        }

        /// <summary>
        /// Surrounds a specified pattern with another specified pattern.
        /// </summary>
        /// <param name="surroundContent">A pattern to be surrounding the base pattern.</param>
        /// <param name="content">A base pattern to be surrounded.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static Pattern Surround(object surroundContent, object content)
        {
            return Surround(surroundContent, content, surroundContent);
        }

        /// <summary>
        /// Surrounds a specified pattern with a specified patterns.
        /// </summary>
        /// <param name="contentBefore">A pattern to be placed before the base pattern.</param>
        /// <param name="content">A base pattern to be surrounded.</param>
        /// <param name="contentAfter">A pattern to be placed after the base pattern.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static Pattern Surround(object contentBefore, object content, object contentAfter)
        {
            return new SurroundPattern(contentBefore, content, contentAfter);
        }

        /// <summary>
        /// Surrounds specified pattern with a specified character.
        /// </summary>
        /// <param name="surroundChar">A character to be surrounding the base pattern.</param>
        /// <param name="value">A base pattern to be surrounded.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static Pattern Surround(AsciiChar surroundChar, object value)
        {
            return Surround(surroundChar, value, surroundChar);
        }

        /// <summary>
        /// Surrounds specified pattern with a specified character.
        /// </summary>
        /// <param name="charBefore">A character to be placed before the base pattern.</param>
        /// <param name="value">A base pattern to be surrounded.</param>
        /// <param name="charAfter">A character to be placed after the base pattern.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        internal static Pattern Surround(AsciiChar charBefore, object value, AsciiChar charAfter)
        {
            return new AsciiCharSurroundPattern(charBefore, value, charAfter);
        }

        /// <summary>
        /// Returns a pattern that matches a specified text.
        /// </summary>
        /// <param name="value">A text to append.</param>
        /// <returns></returns>
        public static Pattern Text(string value)
        {
            return new TextPattern(value);
        }

        /// <summary>
        /// Returns a pattern that matches a specified text, ignoring or honoring its case.
        /// </summary>
        /// <param name="value">A text to append.</param>
        /// <param name="ignoreCase">true to ignore case during the matching; otherwise, false.</param>
        /// <returns></returns>
        public static QuantifiablePattern Text(string value, bool ignoreCase)
        {
            return new CaseAwareTextPattern(value, ignoreCase);
        }

        /// <summary>
        /// Returns a pattern that is a negation of the specified pattern.
        /// </summary>
        /// <typeparam name="TPattern">The type of the pattern.</typeparam>
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
        /// Returns an if construct with the specified content to assert and a content to match if the assertion succeeds.
        /// </summary>
        /// <param name="testContent">The content to assert.</param>
        /// <param name="trueContent">The content to be matched if the assertion succeeds.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern IfAssert(object testContent, object trueContent)
        {
            return IfAssert(testContent, trueContent, null);
        }

        /// <summary>
        /// Returns an if construct with the specified content to assert and a content to match if the assertion succeeds and a content to match if the assertion fails.
        /// </summary>
        /// <param name="testContent">The content to assert.</param>
        /// <param name="trueContent">The content to be matched if the assertion succeeds.</param>
        /// <param name="falseContent">The content to be matched if the assertion fails.</param>
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
        public static QuantifiablePattern BeginInput()
        {
            return new StartOfInput();
        }

        /// <summary>
        /// Returns a pattern that is matched at the end of the string.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EndInput()
        {
            return new EndOfInput();
        }

        /// <summary>
        /// Returns a pattern that is matched at the beginning of the line.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern BeginLine()
        {
            return Options(RegexOptions.Multiline, BeginInputOrLine());
        }

        /// <summary>
        /// Returns a pattern that is matched at the beginning of the string (or line if the <see cref="RegexOptions.Multiline"/> option is applied).
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern BeginInputOrLine()
        {
            return new StartOfLine();
        }

        /// <summary>
        /// Returns a pattern that is matched at the end of the string or line. End of line is defined as the position before a linefeed.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EndLine()
        {
            return Options(RegexOptions.Multiline, EndInputOrLine());
        }

        /// <summary>
        /// Returns a pattern that is matched (before carriage return) at the end of the string or line. End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="beforeCarriageReturn">Indicates whether a position of the match should be before a carriage return if present and not already consumed by regex engine</param>
        /// <returns></returns>
        public static Pattern EndLine(bool beforeCarriageReturn)
        {
            if (beforeCarriageReturn)
            {
                return Assert(CarriageReturn().Maybe().EndLine());
            }
            else
            {
                return EndLine();
            }
        }

        /// <summary>
        /// Returns a pattern that is matched at the end of the string (or line if the <see cref="RegexOptions.Multiline"/> option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EndInputOrLine()
        {
            return new EndOfLine();
        }

        /// <summary>
        /// Returns a pattern that is matched (before carriage return) at the end of the string (or (before carriage return) at the end of line if the <see cref="RegexOptions.Multiline"/> option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="beforeCarriageReturn">Indicates whether a position of the match should be before a carriage return if present and not already consumed by regex engine</param>
        /// <returns></returns>
        public static QuantifiablePattern EndInputOrLine(bool beforeCarriageReturn)
        {
            if (beforeCarriageReturn)
            {
                return Assert(CarriageReturn().Maybe().EndInputOrLine());
            }
            else
            {
                return EndInputOrLine();
            }
        }

        /// <summary>
        /// Returns a pattern that is matched at the end of the string or before linefeed at the end of the string.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EndInputOrBeforeEndingLinefeed()
        {
            return new EndOfInputOrBeforeEndingLinefeed();
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
        /// Returns a pattern that is matched on a boundary between a word character and a non-word character. The pattern may be also matched on a word boundary at the beginning or end of the string.
        /// </summary>
        /// <returns></returns>
        public static WordBoundary WordBoundary()
        {
            return new WordBoundary();
        }

        /// <summary>
        /// Returns a pattern that is not matched on a boundary between a word character and a non-word character.
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
            return Surround(WordBoundary(), WordChars()).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches spefified pattern surrounded with a word boundary.
        /// </summary>
        /// <param name="content">A text to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern SurroundWordBoundary(object content)
        {
            return Surround(WordBoundary(), content).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches specified content surrounded with a word boundary.
        /// </summary>
        /// <param name="content">An object array that contains zero or more values any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern SurroundWordBoundary(params object[] content)
        {
            return SurroundWordBoundary((object)content);
        }

        /// <summary>
        /// Returns a pattern that matches a specified content surrounded with the beginning and the end of the string.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern EntireInput(object content)
        {
            return Surround(BeginInput(), content, EndInput()).AsNoncapturingGroup();
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
        /// Returns a pattern that is matched from the beginning of the line to the position (before carriage return) at the end of line. End of line is defined as the position before a linefeed.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern EntireLine()
        {
            return EntireLine(WhileNotNewLineChar());
        }

        /// <summary>
        /// Returns a pattern that is matched from the beginning of the line to the position (before carriage return) at the end of line. End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern EntireLine(object content)
        {
            return Surround(BeginLine(), content, EndLine(true)).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that is matched from the beginning of the line to the position (before carriage return) at the end of line. End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="content">An object array that contains zero or more values any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern EntireLine(params object[] content)
        {
            return EntireLine((object)content);
        }

        /// <summary>
        /// Returns a pattern that is matched from the beginning of the string (or line if the <see cref="RegexOptions.Multiline"/> option is applied) to the position (before carriage return) at the end of string (or line if the <see cref="RegexOptions.Multiline"/> option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        /// <returns></returns>
        public static Pattern EntireInputOrLine()
        {
            return EntireInputOrLine(WhileNotNewLineChar());
        }

        /// <summary>
        /// Returns a pattern that is matched from the beginning of the string (or line if the <see cref="RegexOptions.Multiline"/> option is applied) to the position (before carriage return) at the end of string (or line if the <see cref="RegexOptions.Multiline"/> option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern EntireInputOrLine(object content)
        {
            return Surround(BeginInputOrLine(), content, EndInputOrLine(true));
        }

        /// <summary>
        /// Returns a pattern that is matched from the beginning of the string (or line if the <see cref="RegexOptions.Multiline"/> option is applied) to the position (before carriage return) at the end of string (or line if the <see cref="RegexOptions.Multiline"/> option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="content">An object array that contains zero or more values any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern EntireInputOrLine(params object[] content)
        {
            return EntireInputOrLine((object)content);
        }

        /// <summary>
        /// Returns a pattern that matches any one of the patterns specified in the collection.
        /// </summary>
        /// <param name="content">A collection that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        public static QuantifiablePattern Any(IEnumerable content)
        {
            return new AnyGroup(content);
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
        /// Returns a pattern that matches specified content zero or more times.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedGroup MaybeMany(object content)
        {
            return new QuantifiedGroup.MaybeManyQuantifiedGroup(content);
        }

        /// <summary>
        /// Returns a pattern that matches any one element of the specified content zero or more times.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedGroup MaybeMany(params object[] content)
        {
            return MaybeMany((object)content);
        }

        /// <summary>
        /// Returns a pattern that matches specified content one or more times.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedGroup OneMany(object content)
        {
            return new QuantifiedGroup.OneManyQuantifiedGroup(content);
        }

        /// <summary>
        /// Returns a pattern that matches any one element of the specified content one or more times.
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
        public static QuantifiedGroup MaybeCount(int maxCount, object content)
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
        public static QuantifiedGroup MaybeCount(int maxCount, params object[] content)
        {
            return MaybeCount(maxCount, (object)content);
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
        /// <param name="value">A Unicode character.</param>
        /// <returns></returns>
        public static CharPattern Character(char value)
        {
            return CharPattern.Create(value);
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
        /// Returns a pattern that matches a character from a specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        /// <returns></returns>
        public static CharPattern Character(NamedBlock block)
        {
            return CharPattern.Create(block, false);
        }

        /// <summary>
        /// Returns a pattern that matches a character from a specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
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
        /// Returns a pattern that matches a character that is not a specified character.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns></returns>
        public static CharGroup Not(char value)
        {
            return CharGroup.Create(value, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a specified character.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public static CharGroup Not(AsciiChar value)
        {
            return CharGroup.Create(value, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from a specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        /// <returns></returns>
        public static CharPattern Not(NamedBlock block)
        {
            return CharPattern.Create(block, true);
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not from a specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        /// <returns></returns>
        public static CharPattern Not(GeneralCategory category)
        {
            return CharPattern.Create(category, true);
        }

        /// <summary>
        /// Returns a pattern that matches any character that is not contained in the specified <see cref="string"/>.
        /// </summary>
        /// <param name="characters">Unicode characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static CharGroup Not(string characters)
        {
            return CharGroup.Create(characters, true);
        }

        /// <summary>
        /// Returns a pattern that matches any character that is not contained in the specified characters.
        /// </summary>
        /// <param name="characters">Unicode characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static CharGroup Not(params char[] characters)
        {
            return CharGroup.Create(characters, true);
        }

        /// <summary>
        /// Returns a negative character group containing specified <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">A content of a character group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static CharGroup Not(CharGrouping value)
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
        /// Returns a pattern that matches a character from a specified base group except characters from a specified excluded group.
        /// </summary>
        /// <param name="baseGroup">A base group.</param>
        /// <param name="excludedGroup">An excluded group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static CharSubtraction Except(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
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
        /// Returns a pattern that matches a specified number of tabs.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Tab(int exactCount)
        {
            return Count(exactCount, Tab());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a tab.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotTab()
        {
            return Not(AsciiChar.Tab);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a tab.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotTab(int exactCount)
        {
            return Count(exactCount, NotTab());
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
        /// Returns a pattern that matches a specified number of linefeeds.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Linefeed(int exactCount)
        {
            return Count(exactCount, Linefeed());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a linefeed.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotLinefeed()
        {
            return Not(AsciiChar.Linefeed);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a linefeed.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLinefeed(int exactCount)
        {
            return Count(exactCount, NotLinefeed());
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
        /// Returns a pattern that matches a specified number of carriage returns.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CarriageReturn(int exactCount)
        {
            return Count(exactCount, CarriageReturn());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a carriage return.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotCarriageReturn()
        {
            return Not(AsciiChar.CarriageReturn);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a carriage return.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCarriageReturn(int exactCount)
        {
            return Count(exactCount, NotCarriageReturn());
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
        /// Returns a pattern that matches a specified number of spaces.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Space(int exactCount)
        {
            return Count(exactCount, Space());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a space.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotSpace()
        {
            return Not(AsciiChar.Space);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a space.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSpace(int exactCount)
        {
            return Count(exactCount, NotSpace());
        }

        /// <summary>
        /// Returns a pattern that matches an exclamation mark.
        /// </summary>
        /// <returns></returns>
        public static CharPattern ExclamationMark()
        {
            return Character(AsciiChar.ExclamationMark);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of exclamation marks.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup ExclamationMark(int exactCount)
        {
            return Count(exactCount, ExclamationMark());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an exclamation mark.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotExclamationMark()
        {
            return Not(AsciiChar.ExclamationMark);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not an exclamation mark.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotExclamationMark(int exactCount)
        {
            return Count(exactCount, NotExclamationMark());
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
        /// Returns a pattern that matches a specified number of quote marks.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup QuoteMark(int exactCount)
        {
            return Count(exactCount, QuoteMark());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a quote mark.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotQuoteMark()
        {
            return Not(AsciiChar.QuoteMark);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a quote mark.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotQuoteMark(int exactCount)
        {
            return Count(exactCount, NotQuoteMark());
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
        /// Returns a pattern that matches a specified number of number signs.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NumberSign(int exactCount)
        {
            return Count(exactCount, NumberSign());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a number sign.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotNumberSign()
        {
            return Not(AsciiChar.NumberSign);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a number sign.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotNumberSign(int exactCount)
        {
            return Count(exactCount, NotNumberSign());
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
        /// Returns a pattern that matches a specified number of dollars.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Dollar(int exactCount)
        {
            return Count(exactCount, Dollar());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a dollar.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotDollar()
        {
            return Not(AsciiChar.Dollar);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a dollar.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDollar(int exactCount)
        {
            return Count(exactCount, NotDollar());
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
        /// Returns a pattern that matches a specified number of percents.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Percent(int exactCount)
        {
            return Count(exactCount, Percent());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a percent.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotPercent()
        {
            return Not(AsciiChar.Percent);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a percent.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotPercent(int exactCount)
        {
            return Count(exactCount, NotPercent());
        }

        /// <summary>
        /// Returns a pattern that matches an ampersand.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Ampersand()
        {
            return Character(AsciiChar.Ampersand);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of ampersands.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Ampersand(int exactCount)
        {
            return Count(exactCount, Ampersand());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an ampersand.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotAmpersand()
        {
            return Not(AsciiChar.Ampersand);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not an ampersand.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAmpersand(int exactCount)
        {
            return Count(exactCount, NotAmpersand());
        }

        /// <summary>
        /// Returns a pattern that matches an apostrophe.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Apostrophe()
        {
            return Character(AsciiChar.Apostrophe);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of apostrophes.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Apostrophe(int exactCount)
        {
            return Count(exactCount, Apostrophe());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an apostrophe.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotApostrophe()
        {
            return Not(AsciiChar.Apostrophe);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not an apostrophe.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotApostrophe(int exactCount)
        {
            return Count(exactCount, NotApostrophe());
        }

        /// <summary>
        /// Returns a pattern that matches a left parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharPattern LeftParenthesis()
        {
            return Character(AsciiChar.LeftParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of left parentheses.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LeftParenthesis(int exactCount)
        {
            return Count(exactCount, LeftParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a left parenthesis.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotLeftParenthesis()
        {
            return Not(AsciiChar.LeftParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a left parenthesis.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLeftParenthesis(int exactCount)
        {
            return Count(exactCount, NotLeftParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a right parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharPattern RightParenthesis()
        {
            return Character(AsciiChar.RightParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of right parentheses.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup RightParenthesis(int exactCount)
        {
            return Count(exactCount, RightParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a right parenthesis.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotRightParenthesis()
        {
            return Not(AsciiChar.RightParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a right parenthesis.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotRightParenthesis(int exactCount)
        {
            return Count(exactCount, NotRightParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches an asterisk.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Asterisk()
        {
            return Character(AsciiChar.Asterisk);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of asterisks.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Asterisk(int exactCount)
        {
            return Count(exactCount, Asterisk());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an asterisk.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotAsterisk()
        {
            return Not(AsciiChar.Asterisk);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not an asterisk.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAsterisk(int exactCount)
        {
            return Count(exactCount, NotAsterisk());
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
        /// Returns a pattern that matches a specified number of pluses.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Plus(int exactCount)
        {
            return Count(exactCount, Plus());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a plus.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotPlus()
        {
            return Not(AsciiChar.Plus);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a plus.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotPlus(int exactCount)
        {
            return Count(exactCount, NotPlus());
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
        /// Returns a pattern that matches a specified number of commas.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Comma(int exactCount)
        {
            return Count(exactCount, Comma());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a comma.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotComma()
        {
            return Not(AsciiChar.Comma);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a comma.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotComma(int exactCount)
        {
            return Count(exactCount, NotComma());
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
        /// Returns a pattern that matches a specified number of hyphens.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Hyphen(int exactCount)
        {
            return Count(exactCount, Hyphen());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a hyphen.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotHyphen()
        {
            return Not(AsciiChar.Hyphen);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a hyphen.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotHyphen(int exactCount)
        {
            return Count(exactCount, NotHyphen());
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
        /// Returns a pattern that matches a specified number of dots.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Dot(int exactCount)
        {
            return Count(exactCount, Dot());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a dot.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotDot()
        {
            return Not(AsciiChar.Dot);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a dot.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotDot(int exactCount)
        {
            return Count(exactCount, NotDot());
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
        /// Returns a pattern that matches a specified number of slashes.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Slash(int exactCount)
        {
            return Count(exactCount, Slash());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a slash.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotSlash()
        {
            return Not(AsciiChar.Slash);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a slash.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSlash(int exactCount)
        {
            return Count(exactCount, NotSlash());
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
        /// Returns a pattern that matches a specified number of colons.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Colon(int exactCount)
        {
            return Count(exactCount, Colon());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a colon.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotColon()
        {
            return Not(AsciiChar.Colon);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a colon.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotColon(int exactCount)
        {
            return Count(exactCount, NotColon());
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
        /// Returns a pattern that matches a specified number of semicolons.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Semicolon(int exactCount)
        {
            return Count(exactCount, Semicolon());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a semicolon.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotSemicolon()
        {
            return Not(AsciiChar.Semicolon);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a semicolon.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSemicolon(int exactCount)
        {
            return Count(exactCount, NotSemicolon());
        }

        /// <summary>
        /// Returns a pattern that matches a left angle bracket (less-than sign).
        /// </summary>
        /// <returns></returns>
        public static CharPattern LeftAngleBracket()
        {
            return Character(AsciiChar.LeftAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of left angle brackets (less-than signs).
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LeftAngleBracket(int exactCount)
        {
            return Count(exactCount, LeftAngleBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a left angle bracket (less-than sign).
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotLeftAngleBracket()
        {
            return Not(AsciiChar.LeftAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a left angle bracket (less-than sign).
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLeftAngleBracket(int exactCount)
        {
            return Count(exactCount, NotLeftAngleBracket());
        }

        /// <summary>
        /// Returns a pattern that matches an equals sign.
        /// </summary>
        /// <returns></returns>
        public static CharPattern EqualsSign()
        {
            return Character(AsciiChar.EqualsSign);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of equals signs.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup EqualsSign(int exactCount)
        {
            return Count(exactCount, EqualsSign());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an equals sign.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotEqualsSign()
        {
            return Not(AsciiChar.EqualsSign);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not an equals sign.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotEqualsSign(int exactCount)
        {
            return Count(exactCount, NotEqualsSign());
        }

        /// <summary>
        /// Returns a pattern that matches a right angle bracket (greater-than sign).
        /// </summary>
        /// <returns></returns>
        public static CharPattern RightAngleBracket()
        {
            return Character(AsciiChar.RightAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of right angle brackets (greater-than signs).
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup RightAngleBracket(int exactCount)
        {
            return Count(exactCount, RightAngleBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a right angle bracket (greater-than sign).
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotRightAngleBracket()
        {
            return Not(AsciiChar.RightAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a right angle bracket (greater-than sign).
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotRightAngleBracket(int exactCount)
        {
            return Count(exactCount, NotRightAngleBracket());
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
        /// Returns a pattern that matches a specified number of question marks.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup QuestionMark(int exactCount)
        {
            return Count(exactCount, QuestionMark());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a question mark.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotQuestionMark()
        {
            return Not(AsciiChar.QuestionMark);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a question mark.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotQuestionMark(int exactCount)
        {
            return Count(exactCount, NotQuestionMark());
        }

        /// <summary>
        /// Returns a pattern that matches an at sign.
        /// </summary>
        /// <returns></returns>
        public static CharPattern AtSign()
        {
            return Character(AsciiChar.AtSign);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of at signs.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AtSign(int exactCount)
        {
            return Count(exactCount, AtSign());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an at sign.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotAtSign()
        {
            return Not(AsciiChar.AtSign);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not an at sign.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAtSign(int exactCount)
        {
            return Count(exactCount, NotAtSign());
        }

        /// <summary>
        /// Returns a pattern that matches a left square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern LeftSquareBracket()
        {
            return Character(AsciiChar.LeftSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of left square brackets.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LeftSquareBracket(int exactCount)
        {
            return Count(exactCount, LeftSquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a left square bracket.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotLeftSquareBracket()
        {
            return Not(AsciiChar.LeftSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a left square bracket.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLeftSquareBracket(int exactCount)
        {
            return Count(exactCount, NotLeftSquareBracket());
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
        /// Returns a pattern that matches a specified number of backslashes.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Backslash(int exactCount)
        {
            return Count(exactCount, Backslash());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a backslash.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotBackslash()
        {
            return Not(AsciiChar.Backslash);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a backslash.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotBackslash(int exactCount)
        {
            return Count(exactCount, NotBackslash());
        }

        /// <summary>
        /// Returns a pattern that matches a right square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern RightSquareBracket()
        {
            return Character(AsciiChar.RightSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of right square brackets.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup RightSquareBracket(int exactCount)
        {
            return Count(exactCount, RightSquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a right square bracket.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotRightSquareBracket()
        {
            return Not(AsciiChar.RightSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a right square bracket.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotRightSquareBracket(int exactCount)
        {
            return Count(exactCount, NotRightSquareBracket());
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
        /// Returns a pattern that matches a specified number of circumflex accents.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CircumflexAccent(int exactCount)
        {
            return Count(exactCount, CircumflexAccent());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a circumflex accent.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotCircumflexAccent()
        {
            return Not(AsciiChar.CircumflexAccent);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a circumflex accent.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCircumflexAccent(int exactCount)
        {
            return Count(exactCount, NotCircumflexAccent());
        }

        /// <summary>
        /// Returns a pattern that matches an underscore.
        /// </summary>
        /// <returns></returns>
        public static CharPattern Underscore()
        {
            return Character(AsciiChar.Underscore);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of underscores.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Underscore(int exactCount)
        {
            return Count(exactCount, Underscore());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not an underscore.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotUnderscore()
        {
            return Not(AsciiChar.Underscore);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not an underscore.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotUnderscore(int exactCount)
        {
            return Count(exactCount, NotUnderscore());
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
        /// Returns a pattern that matches a specified number of grave accents.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup GraveAccent(int exactCount)
        {
            return Count(exactCount, GraveAccent());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a grave accent.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotGraveAccent()
        {
            return Not(AsciiChar.GraveAccent);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a grave accent.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotGraveAccent(int exactCount)
        {
            return Count(exactCount, NotGraveAccent());
        }

        /// <summary>
        /// Returns a pattern that matches a left curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern LeftCurlyBracket()
        {
            return Character(AsciiChar.LeftCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of left curly brackets.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LeftCurlyBracket(int exactCount)
        {
            return Count(exactCount, LeftCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a left curly bracket.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotLeftCurlyBracket()
        {
            return Not(AsciiChar.LeftCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a left curly bracket.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLeftCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotLeftCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a vertical bar.
        /// </summary>
        /// <returns></returns>
        public static CharPattern VerticalBar()
        {
            return Character(AsciiChar.VerticalBar);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of vertical bars.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup VerticalBar(int exactCount)
        {
            return Count(exactCount, VerticalBar());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a vertical bar.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotVerticalBar()
        {
            return Not(AsciiChar.VerticalBar);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a vertical bar.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotVerticalBar(int exactCount)
        {
            return Count(exactCount, NotVerticalBar());
        }

        /// <summary>
        /// Returns a pattern that matches a right curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharPattern RightCurlyBracket()
        {
            return Character(AsciiChar.RightCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of right curly brackets.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup RightCurlyBracket(int exactCount)
        {
            return Count(exactCount, RightCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a right curly bracket.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotRightCurlyBracket()
        {
            return Not(AsciiChar.RightCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a right curly bracket.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotRightCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotRightCurlyBracket());
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
        /// Returns a pattern that matches a specified number of tildes.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Tilde(int exactCount)
        {
            return Count(exactCount, Tilde());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a tilde.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotTilde()
        {
            return Not(AsciiChar.Tilde);
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of characters that are not a tilde.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotTilde(int exactCount)
        {
            return Count(exactCount, NotTilde());
        }

        /// <summary>
        /// Returns a pattern that matches any character.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern Any()
        {
            return Character(Chars.WhiteSpace().NotWhiteSpace());
        }

        /// <summary>
        /// Returns a pattern that matches any character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Any(int exactCount)
        {
            return Count(exactCount, Any());
        }

        /// <summary>
        /// Returns a pattern that matches any character except linefeed.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern AnyExceptLinefeed()
        {
            return DisableOptions(RegexOptions.Singleline, new AnyChar());
        }

        /// <summary>
        /// Returns a pattern that matches any character except linefeed specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AnyExceptLinefeed(int exactCount)
        {
            return Count(exactCount, AnyExceptLinefeed());
        }

        /// <summary>
        /// Returns a pattern that matches any character except linefeed (or any character if the <see cref="RegexOptions.Singleline"/> option is applied).
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern AnyNative()
        {
            return new AnyChar();
        }

        /// <summary>
        /// Returns a pattern that matches any character except linefeed (or any character if the <see cref="RegexOptions.Singleline"/> option is applied) specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup AnyNative(int exactCount)
        {
            return Count(exactCount, AnyNative());
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
        /// Returns a pattern that matches one or more digit characters.
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
        /// Returns a pattern that matches one or more characters that are not a digit character.
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
        /// Returns a pattern that matches one or more white-space characters.
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
        /// Returns a pattern that matches one or more characters that are not a white-space character.
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
        /// Returns a pattern that matches one or more word characters.
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
        /// Returns a pattern that matches one or more characters that are not a word character.
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
            return Character("\r\n");
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
        /// Returns a pattern that matches a character that is not a newline character. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotNewLineChar()
        {
            return Not("\r\n");
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
        /// Returns a pattern that matches an alphanumeric character. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup Alphanumeric()
        {
            return Character(Chars.Alphanumeric());
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
        /// Returns a pattern that matches a character that is not an alphanumeric character. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotAlphanumeric()
        {
            return Not(Chars.Alphanumeric());
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
        /// Returns a pattern that matches a lower-case alphanumeric character. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern AlphanumericLower()
        {
            return DisableOptions(RegexOptions.IgnoreCase, Chars.Range('a', 'z').ArabicDigit());
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
        /// Returns a pattern that matches a character that is not a lower-case alphanumeric character. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotAlphanumericLower()
        {
            return DisableOptions(RegexOptions.IgnoreCase, !Chars.Range('a', 'z').ArabicDigit());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a lower-case alphanumeric character specified number of times. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotAlphanumericLower(int exactCount)
        {
            return Count(exactCount, NotAlphanumericLower());
        }

        /// <summary>
        /// Returns a pattern that matches an upper-case alphanumeric character. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern AlphanumericUpper()
        {
            return DisableOptions(RegexOptions.IgnoreCase, Chars.Range('A', 'Z').ArabicDigit());
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
        /// Returns a pattern that matches a character that is not an upper-case alphanumeric character. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotAlphanumericUpper()
        {
            return DisableOptions(RegexOptions.IgnoreCase, !Chars.Range('A', 'Z').ArabicDigit());
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
        /// Returns a pattern that matches an alphanumeric character or an underscore. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup AlphanumericUnderscore()
        {
            return Character(Chars.AlphanumericUnderscore());
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
        /// Returns a pattern that matches a character that is neither alphanumeric character nor underscore. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotAlphanumericUnderscore()
        {
            return Not(Chars.AlphanumericUnderscore());
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
        /// Returns a pattern that matches a latin alphabet letter.
        /// </summary>
        /// <returns></returns>
        public static CharGroup LatinLetter()
        {
            return Character(Chars.LatinLetter());
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
        /// Returns a pattern that matches a character that is not a latin alphabet letter.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotLatinLetter()
        {
            return Not(Chars.LatinLetter());
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
        /// Returns a pattern that matches a latin alphabet lower-case letter.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern LatinLetterLower()
        {
            return DisableOptions(RegexOptions.IgnoreCase, Range('a', 'z'));
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
        /// Returns a pattern that matches a character that is not a latin alphabet lower-case letter.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotLatinLetterLower()
        {
            return DisableOptions(RegexOptions.IgnoreCase, NotRange('a', 'z'));
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
        /// Returns a pattern that matches a latin alphabet upper-case letter.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern LatinLetterUpper()
        {
            return DisableOptions(RegexOptions.IgnoreCase, Range('A', 'Z'));
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
        /// Returns a pattern that matches a character that is not a latin alphabet upper-case letter.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotLatinLetterUpper()
        {
            return DisableOptions(RegexOptions.IgnoreCase, NotRange('A', 'Z'));
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
        /// Returns a pattern that matches a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern LetterLower()
        {
            return DisableOptions(RegexOptions.IgnoreCase, Character(GeneralCategory.LetterLowercase));
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of letters from <see cref="GeneralCategory.LetterLowercase"/>.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LetterLower(int exactCount)
        {
            return Count(exactCount, LetterLower());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotLetterLower()
        {
            return DisableOptions(RegexOptions.IgnoreCase, Not(GeneralCategory.LetterLowercase));
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a character from <see cref="GeneralCategory.LetterLowercase"/> specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLetterLower(int exactCount)
        {
            return Count(exactCount, NotLetterLower());
        }

        /// <summary>
        /// Returns a pattern that matches a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern LetterUpper()
        {
            return DisableOptions(RegexOptions.IgnoreCase, Character(GeneralCategory.LetterUppercase));
        }

        /// <summary>
        /// Returns a pattern that matches a specified number of letters from <see cref="GeneralCategory.LetterUppercase"/>.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup LetterUpper(int exactCount)
        {
            return Count(exactCount, LetterUpper());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NotLetterUpper()
        {
            return DisableOptions(RegexOptions.IgnoreCase, Not(GeneralCategory.LetterUppercase));
        }

        /// <summary>
        /// Returns a pattern that matches a character that is not a character from <see cref="GeneralCategory.LetterUppercase"/> specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotLetterUpper(int exactCount)
        {
            return Count(exactCount, NotLetterUpper());
        }

        /// <summary>
        /// Returns a pattern that matches an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup ArabicDigit()
        {
            return Character(Chars.ArabicDigit());
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
        /// Returns a pattern that matches a character that is not an arabic digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotArabicDigit()
        {
            return Not(Chars.ArabicDigit());
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
        /// Returns a pattern that matches a hexadecimal digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup HexadecimalDigit()
        {
            return Character(Chars.HexadecimalDigit());
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
        /// Returns a pattern that matches a character that is not a hexadecimal digit.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotHexadecimalDigit()
        {
            return Not(Chars.HexadecimalDigit());
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
        /// Returns a pattern that matches left or right parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharGroup Parenthesis()
        {
            return Character(Chars.Parenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches left or right parenthesis specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup Parenthesis(int exactCount)
        {
            return Count(exactCount, Parenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither left nor right parenthesis.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotParenthesis()
        {
            return Not(Chars.Parenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither left nor right parenthesis specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotParenthesis(int exactCount)
        {
            return Count(exactCount, NotParenthesis());
        }

        /// <summary>
        /// Returns a pattern that matches left or right curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGroup CurlyBracket()
        {
            return Character(Chars.CurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches left or right curly bracket specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup CurlyBracket(int exactCount)
        {
            return Count(exactCount, CurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither left nor right curly bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotCurlyBracket()
        {
            return Not(Chars.CurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither left nor right curly bracket specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotCurlyBracket(int exactCount)
        {
            return Count(exactCount, NotCurlyBracket());
        }

        /// <summary>
        /// Returns a pattern that matches left or right square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGroup SquareBracket()
        {
            return Character(Chars.SquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches left or right square bracket specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup SquareBracket(int exactCount)
        {
            return Count(exactCount, SquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither left nor right square bracket.
        /// </summary>
        /// <returns></returns>
        public static CharGroup NotSquareBracket()
        {
            return Not(Chars.SquareBracket());
        }

        /// <summary>
        /// Returns a pattern that matches a character that is neither left nor right square bracket specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static QuantifiedGroup NotSquareBracket(int exactCount)
        {
            return Count(exactCount, NotSquareBracket());
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
        /// Returns a pattern that matches two apostrophes, allowing zero or more characters that are not an apostrophe between the apostrophes.
        /// </summary>
        /// <returns></returns>
        public static Pattern SurroundApostrophes()
        {
            return SurroundApostrophes(WhileNotChar('\''));
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with apostrophes.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SurroundApostrophes(object content)
        {
            return Surround(AsciiChar.Apostrophe, content);
        }

        /// <summary>
        /// Returns a pattern that matches specified content surrounded with apostrophes.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SurroundApostrophes(params object[] content)
        {
            return Surround(AsciiChar.Apostrophe, (object)content);
        }

        /// <summary>
        /// Returns a pattern that matches two quotation marks, allowing zero or more characters that are not a quotation mark between the quotation marks.
        /// </summary>
        /// <returns></returns>
        public static Pattern SurroundQuoteMarks()
        {
            return SurroundQuoteMarks(WhileNotChar('"'));
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with quotation marks.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SurroundQuoteMarks(object content)
        {
            return Surround(AsciiChar.QuoteMark, content);
        }

        /// <summary>
        /// Returns a pattern that matches specified content surrounded with quotation marks.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SurroundQuoteMarks(params object[] content)
        {
            return Surround(AsciiChar.QuoteMark, (object)content);
        }

#if DEBUG
        /// <summary>
        /// Returns a pattern that matches two quotation marks (apostrophes), allowing zero or more characters that are not a quotation mark (apostrophe) between the quotation marks (apostrophes).
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern SurroundQuoteMarksOrApostrophes()
        {
            return SurroundQuoteMarks() | SurroundApostrophes();
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with quotation marks or apostrophes.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern SurroundQuoteMarksOrApostrophes(object content)
        {
            return SurroundQuoteMarks(content) | SurroundApostrophes(content);
        }

        /// <summary>
        /// Returns a pattern that matches specified content surrounded with quotation marks or apostrophes.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern SurroundQuoteMarksOrApostrophes(params object[] content)
        {
            return SurroundQuoteMarks(content) | SurroundApostrophes(content);
        }
#endif

        /// <summary>
        /// Returns a pattern that matches a text consisting of a left parenthesis and a right parenthesis, allowing zero or more characters that are not a right parenthesis between the parentheses.
        /// </summary>
        /// <returns></returns>
        public static Pattern SurroundParentheses()
        {
            return SurroundParentheses(WhileNotChar(')'));
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with left and right parenthesis.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SurroundParentheses(object content)
        {
            return Surround(AsciiChar.LeftParenthesis, content, AsciiChar.RightParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches specified content surrounded with left and right parenthesis.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SurroundParentheses(params object[] content)
        {
            return Surround(AsciiChar.LeftParenthesis, (object)content, AsciiChar.RightParenthesis);
        }

        /// <summary>
        /// Returns a pattern that matches a text consisting of left and right curly bracket, allowing zero or more characters that are not a right curly bracket between the brackets.
        /// </summary>
        /// <returns></returns>
        public static Pattern SurroundCurlyBrackets()
        {
            return SurroundCurlyBrackets(WhileNotChar('}'));
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with left and right curly bracket.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SurroundCurlyBrackets(object content)
        {
            return Surround(AsciiChar.LeftCurlyBracket, content, AsciiChar.RightCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches specified content surrounded with left and right curly bracket.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SurroundCurlyBrackets(params object[] content)
        {
            return Surround(AsciiChar.LeftCurlyBracket, (object)content, AsciiChar.RightCurlyBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a text consisting of left and right square bracket, allowing zero or more characters that are not a right square bracket between the brackets.
        /// </summary>
        /// <returns></returns>
        public static Pattern SurroundSquareBrackets()
        {
            return SurroundSquareBrackets(WhileNotChar(']'));
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with left and right square bracket.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SurroundSquareBrackets(object content)
        {
            return Surround(AsciiChar.LeftSquareBracket, content, AsciiChar.RightSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches specified content surrounded with left and right square bracket.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SurroundSquareBrackets(params object[] content)
        {
            return Surround(AsciiChar.LeftSquareBracket, (object)content, AsciiChar.RightSquareBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a text consisting of left and right angle bracket, allowing zero or more characters that are not a right angle bracket between the brackets.
        /// </summary>
        /// <returns></returns>
        public static Pattern SurroundAngleBrackets()
        {
            return SurroundAngleBrackets(WhileNotChar('>'));
        }

        /// <summary>
        /// Returns a pattern that matches specified pattern surrounded with left and right angle bracket.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SurroundAngleBrackets(object content)
        {
            return Surround(AsciiChar.LeftAngleBracket, content, AsciiChar.RightAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches specified content surrounded with left and right angle bracket.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static Pattern SurroundAngleBrackets(params object[] content)
        {
            return Surround(AsciiChar.LeftAngleBracket, (object)content, AsciiChar.RightAngleBracket);
        }

        /// <summary>
        /// Returns a pattern that matches a specified character zero or more times.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns></returns>
        public static QuantifiedPattern WhileChar(char value)
        {
            return Character(value).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches a specified character zero or more times.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public static QuantifiedPattern WhileChar(AsciiChar value)
        {
            return Character(value).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches a specified character zero or more times.
        /// </summary>
        /// <param name="value">A set of Unicode characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedPattern WhileChar(CharGrouping value)
        {
            return Character(value).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches a digit character zero or more times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedPattern WhileDigit()
        {
            return Digit().MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches a word character zero or more times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedPattern WhileWordChar()
        {
            return WordChar().MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches a white-space character zero or more times.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedPattern WhileWhiteSpace()
        {
            return WhiteSpace().MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches zero or more characters that are white-space characters but neither a carriage return nor a linefeed.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedPattern WhileWhiteSpaceExceptNewLine()
        {
            return WhiteSpaceExceptNewLine().MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches zero or more characters that are not a specified character.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns></returns>
        public static QuantifiedPattern WhileNotChar(char value)
        {
            return Not(value).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches zero or more characters that are not contained in the specified characters
        /// </summary>
        /// <param name="characters">Unicode characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static QuantifiedPattern WhileNotChar(params char[] characters)
        {
            return Not(characters).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches zero or more characters that are not contained in the specified <see cref="string"/>.
        /// </summary>
        /// <param name="characters">Unicode characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static QuantifiedPattern WhileNotChar(string characters)
        {
            return Not(characters).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches zero or more characters that are not a specified character.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public static QuantifiedPattern WhileNotChar(AsciiChar value)
        {
            return Not(value).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches zero or more characters that are not matched by a specified <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">A set of Unicode characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiedPattern WhileNotChar(CharGrouping value)
        {
            return Not(value).MaybeMany();
        }

        /// <summary>
        /// Returns a pattern that matches zero or more characters that are neither a carriage return nor a linefeed.
        /// </summary>
        /// <returns></returns>
        public static QuantifiedPattern WhileNotNewLineChar()
        {
            return WhileNotChar("\r\n");
        }

        /// <summary>
        /// Returns a pattern that matches zero or more characters that are not a specified character and a specified character.
        /// </summary>
        /// <param name="value">A Unicode character.</param>
        /// <returns></returns>
        public static QuantifiablePattern UntilChar(char value)
        {
            return WhileNotChar(value).Character(value).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches zero or more characters that are not a specified character and a specified character.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public static QuantifiablePattern UntilChar(AsciiChar value)
        {
            return WhileNotChar(value).Character(value).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches zero or more characters that are not matched by a specified <see cref="CharGrouping"/> and a character that is matched by a specified <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">A content of a character group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static QuantifiablePattern UntilChar(CharGrouping value)
        {
            return WhileNotChar(value).Character(value).AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns a pattern that matches zero or more characters that are not a linefeed and a linefeed.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern UntilNewLine()
        {
            return UntilChar(AsciiChar.Linefeed);
        }

        /// <summary>
        /// Returns a pattern that matches any character zero or more times but as few times as possible.
        /// </summary>
        /// <returns></returns>
        public static Pattern Crawl()
        {
            return Any().MaybeMany().Lazy();
        }

        /// <summary>
        /// Returns a pattern that matches any character except linefeed (or any character if the <see cref="RegexOptions.Singleline"/> option is applied) zero or more times but as few times as possible.
        /// </summary>
        /// <returns></returns>
        public static Pattern CrawlNative()
        {
            return AnyNative().MaybeMany().Lazy();
        }

        /// <summary>
        /// Returns a pattern that matches a combination of an optional carriage return and a linefeed.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern NewLine()
        {
            return CarriageReturn().Maybe().Linefeed().AsNoncapturingGroup();
        }

        /// <summary>
        /// Returns an empty negative lookahead assertion. This pattern is never matched.
        /// </summary>
        /// <returns></returns>
        public static QuantifiablePattern Never()
        {
            return NotAssert(string.Empty);
        }

        /// <summary>
        /// Returns a pattern that matches one or many opening characters balanced with one or many closing characters.
        /// Between the characters can be zero or many characters that are neither opening nor closing character.
        /// A name for the group containing opening character is randomly generated and if the characters are balanced, the group has no captures.
        /// </summary>
        /// <param name="openingCharacter">Opening Unicode character to balance.</param>
        /// <param name="closingCharacter">Closing Unicode character to balance.</param>
        /// <param name="groupName">A name of the group that contains balanced content of the opening and closing character.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static Pattern Balance(char openingCharacter, char closingCharacter, string groupName)
        {
            RegexUtility.CheckGroupName(groupName);

            return BalanceInternal(openingCharacter, closingCharacter, groupName, groupName + "_" + RegexUtility.GetRandomGroupName());
        }

        /// <summary>
        /// Returns a pattern that matches one or many opening characters balanced with one or many closing characters.
        /// Between the characters can be zero or many characters that are neither opening nor closing character.
        /// If the characters are balanced, group containing opening character has no captures.
        /// </summary>
        /// <param name="openingCharacter">Opening Unicode character to balance.</param>
        /// <param name="closingCharacter">Closing Unicode character to balance.</param>
        /// <param name="groupName">A name of the group that contains balanced content of the opening and closing character.</param>
        /// <param name="openGroupName">A name of the group that contains opening character.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static Pattern Balance(char openingCharacter, char closingCharacter, string groupName, string openGroupName)
        {
            RegexUtility.CheckGroupName(groupName);
            RegexUtility.CheckGroupName(openGroupName, "openGroupName");

            return BalanceInternal(openingCharacter, closingCharacter, groupName, openGroupName);
        }

        internal static Pattern BalanceInternal(char openChar, char closeChar, string groupName, string openGroupName)
        {
            return Patterns
                .OneMany(Patterns
                    .NamedGroup(openGroupName, openChar)
                    .WhileNotChar(openChar, closeChar))
                .OneMany(Patterns
                    .BalancingGroup(groupName, openGroupName, closeChar)
                    .WhileNotChar(openChar, closeChar));
        }
    }
}
