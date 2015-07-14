// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class Pattern
    {
        /// <summary>
        /// Appends a pattern that is a negation of the specified pattern.
        /// </summary>
        /// <typeparam name="TPattern"></typeparam>
        /// <param name="value">A pattern to be negated.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public TPattern Not<TPattern>(INegateable<TPattern> value) where TPattern : Pattern
        {
            return ConcatInternal(Patterns.Not(value));
        }

        /// <summary>
        /// Appends a pattern that matches the current instance or a specified content.
        /// </summary>
        /// <param name="content">Alternate content to match if the current instance if not matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Pattern Or(object content)
        {
            return Patterns.Or(this, content);
        }

        /// <summary>
        /// Appends a pattern that matches any one of the patterns specified in the collection.
        /// </summary>
        /// <param name="values">A collection that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        public QuantifiablePattern Any(IEnumerable<object> values)
        {
            return ConcatInternal(Patterns.Any(values));
        }

        /// <summary>
        /// Appends a pattern that matches any one of the patterns specified in the object array.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern Any(params object[] content)
        {
            return ConcatInternal(Patterns.Any(content));
        }

        /// <summary>
        /// Appends an if construct with the specified content to assert and a content to match if the assertion succeeds.
        /// </summary>
        /// <param name="testContent">The content to assert.</param>
        /// <param name="trueContent">The content to be matched if the assertion succeeds.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern IfAssert(Pattern testContent, object trueContent)
        {
            return ConcatInternal(Patterns.IfAssert(testContent, trueContent));
        }

        /// <summary>
        /// Appends an if construct with the specified content to assert and a content to match if the assertion succeeds and a content to match if the assertion fails.
        /// </summary>
        /// <param name="testContent">The content to assert.</param>
        /// <param name="trueContent">The content to be matched if the assertion succeeds.</param>
        /// <param name="falseContent">The content to be matched if the assertion fails.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern IfAssert(Pattern testContent, object trueContent, object falseContent)
        {
            return ConcatInternal(Patterns.IfAssert(testContent, trueContent, falseContent));
        }

        /// <summary>
        /// Appends an if construct with a content to match if the named group is matched.
        /// </summary>
        /// <param name="groupName">A name of the group.</param>
        /// <param name="trueContent">The content to be matched if the named group is matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public QuantifiablePattern IfGroup(string groupName, object trueContent)
        {
            return ConcatInternal(Patterns.IfGroup(groupName, trueContent));
        }

        /// <summary>
        /// Appends an if construct with a content to match if the named group is matched and a content to match if the named group is not matched.
        /// </summary>
        /// <param name="groupName">A name of the group.</param>
        /// <param name="trueContent">The content to be matched if the named group is matched.</param>
        /// <param name="falseContent">The content to be matched if the named group is not matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public QuantifiablePattern IfGroup(string groupName, object trueContent, object falseContent)
        {
            return ConcatInternal(Patterns.IfGroup(groupName, trueContent, falseContent));
        }

        /// <summary>
        /// Appends an if construct with a content to match if the numbered group is matched.
        /// </summary>
        /// <param name="groupNumber">A number of the group.</param>
        /// <param name="trueContent">The content to be matched if the numbered group is matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiablePattern IfGroup(int groupNumber, object trueContent)
        {
            return ConcatInternal(Patterns.IfGroup(groupNumber, trueContent));
        }

        /// <summary>
        /// Appends an if construct with a content to match if the numbered group is matched and a content to match if the numbered group is not matched.
        /// </summary>
        /// <param name="groupNumber">A number of the group.</param>
        /// <param name="trueContent">The content to be matched if the numbered group is matched.</param>
        /// <param name="falseContent">The content to be matched if the numbered group is not matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiablePattern IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            return ConcatInternal(Patterns.IfGroup(groupNumber, trueContent, falseContent));
        }

        /// <summary>
        /// Appends a pattern that is matched at the beginning of the string.
        /// </summary>
        public QuantifiablePattern BeginInput()
        {
            return ConcatInternal(Patterns.BeginInput());
        }

        /// <summary>
        /// Appends a pattern that is matched at the beginning of the string (or line if the multiline option is applied).
        /// </summary>
        public QuantifiablePattern BeginLine()
        {
            return ConcatInternal(Patterns.BeginLine());
        }

        /// <summary>
        /// Appends a pattern that is matched at the beginning of the line.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern BeginLineInvariant()
        {
            return ConcatInternal(Patterns.BeginLineInvariant());
        }

        /// <summary>
        /// Appends a pattern that is matched at the end of the string.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern EndInput()
        {
            return ConcatInternal(Patterns.EndInput());
        }

        /// <summary>
        /// Appends a pattern that is matched at the end of the string (or line if the multiline option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern EndLine()
        {
            return ConcatInternal(Patterns.EndLine());
        }

        /// <summary>
        /// Appends a pattern that is matched (before carriage return) at the end of the string (or (before carriage return) at the end of line if the multiline option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="beforeCarriageReturn">Indicates whether a position of the match should be before a carriage return if present and not already consumed by regex engine.</param>
        /// <returns></returns>
        public Pattern EndLine(bool beforeCarriageReturn)
        {
            return ConcatInternal(Patterns.EndLine(beforeCarriageReturn));
        }

        /// <summary>
        /// Appends a pattern that is matched at the end of the string or line. End of line is defined as the position before a linefeed.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern EndLineInvariant()
        {
            return ConcatInternal(Patterns.EndLineInvariant());
        }

        /// <summary>
        /// Appends a pattern that is matched (before carriage return) at the end of the string or line. End of line is defined as the position before a linefeed.
        /// </summary>
        /// <param name="beforeCarriageReturn">Indicates whether a position of the match should be before a carriage return if present and not already consumed by regex engine</param>
        /// <returns></returns>
        public QuantifiablePattern EndLineInvariant(bool beforeCarriageReturn)
        {
            return ConcatInternal(Patterns.EndLineInvariant(beforeCarriageReturn));
        }

        /// <summary>
        /// Appends a pattern that is matched at the end of the string or before linefeed at the end of the string.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern EndInputOrBeforeEndingLinefeed()
        {
            return ConcatInternal(Patterns.EndInputOrBeforeEndingLinefeed());
        }

        /// <summary>
        /// Appends a pattern that is matched at the position where the previous match ended.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern PreviousMatchEnd()
        {
            return ConcatInternal(Patterns.PreviousMatchEnd());
        }

        /// <summary>
        /// Appends a pattern that is matched on a boundary between a word character (\w) and a non-word character (\W). The pattern may be also matched on a word boundary at the beginning or end of the string.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern WordBoundary()
        {
            return ConcatInternal(Patterns.WordBoundary());
        }

        /// <summary>
        /// Appends a pattern that is not matched on a boundary between a word character (\w) and a non-word character (\W).
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotWordBoundary()
        {
            return ConcatInternal(Patterns.NotWordBoundary());
        }

        /// <summary>
        /// Appends a pattern that matches one or more word characters surrounded with a word boundary.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Word()
        {
            return ConcatInternal(Patterns.Word());
        }

        /// <summary>
        /// Appends a pattern that matches specified text surrounded with a word boundary.
        /// </summary>
        /// <param name="text">A text to surround.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern Word(string text)
        {
            return ConcatInternal(Patterns.Word(text));
        }

        /// <summary>
        /// Appends a pattern that matches any one of the specified values surrounded with a word boundary.
        /// </summary>
        /// <param name="values">An object array that contains zero or more values any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern Word(params string[] values)
        {
            return ConcatInternal(Patterns.Word(values));
        }

        /// <summary>
        /// Returns a pattern that matches current instance surrounded with the beginning and the end of the string (or line if the multiline option is applied). End of line is defined as the position before a linefeed.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern AsLine()
        {
            return Patterns.EntireLine(this);
        }

        /// <summary>
        /// Returns a pattern that matches current instance surrounded with the beginning and the end of string or line. End of line is defined as the position before a linefeed.
        /// </summary>
        /// <returns></returns>
        public Pattern AsLineInvariant()
        {
            return Patterns.EntireLineInvariant(this);
        }

        /// <summary>
        /// Returns a pattern that matches current instance surrounded with the beginning and the end of the string.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern AsEntireInput()
        {
            return Patterns.EntireInput(this);
        }

        /// <summary>
        /// Appends a zero-width positive lookahead assertion with a specified content to be matched.
        /// </summary>
        /// <param name="content">A content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern Assert(object content)
        {
            return ConcatInternal(Patterns.Assert(content));
        }

        /// <summary>
        /// Appends a zero-width positive lookahead assertion that matches any one pattern specified in the object array.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern Assert(params object[] content)
        {
            return ConcatInternal(Patterns.Assert(content));
        }

        /// <summary>
        /// Appends a zero-width negative lookahead assertion with a specified content not to be matched.
        /// </summary>
        /// <param name="content">A content not to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern NotAssert(object content)
        {
            return ConcatInternal(Patterns.NotAssert(content));
        }

        /// <summary>
        /// Appends a zero-width negative lookahead assertion that matches none of patterns specified in the object array.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns none of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern NotAssert(params object[] content)
        {
            return ConcatInternal(Patterns.NotAssert(content));
        }

        /// <summary>
        /// Appends a zero-width positive lookbehind assertion with a specified content to be matched.
        /// </summary>
        /// <param name="content">A content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern AssertBack(object content)
        {
            return ConcatInternal(Patterns.AssertBack(content));
        }

        /// <summary>
        /// Appends a zero-width positive lookbehind assertion that matches any one pattern specified in the object array.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern AssertBack(params object[] content)
        {
            return ConcatInternal(Patterns.AssertBack(content));
        }

        /// <summary>
        /// Appends a zero-width negative lookbehind assertion with a specified content not to be matched.
        /// </summary>
        /// <param name="content">A content not to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern NotAssertBack(object content)
        {
            return ConcatInternal(Patterns.NotAssertBack(content));
        }

        /// <summary>
        /// Appends a zero-width negative lookbehind assertion that matches none of patterns specified in the object array.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns none of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern NotAssertBack(params object[] content)
        {
            return ConcatInternal(Patterns.NotAssertBack(content));
        }

        /// <summary>
        /// Appends an empty numbered group.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Group()
        {
            return ConcatInternal(Patterns.Group());
        }

        /// <summary>
        /// Appends a numbered group with a specified content.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern Group(object content)
        {
            return ConcatInternal(Patterns.Group(content));
        }

        /// <summary>
        /// Appends a numbered group with a specified content.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern Group(params object[] content)
        {
            return ConcatInternal(Patterns.Group(content));
        }

        /// <summary>
        /// Appends a numbered group containing a specified character.
        /// </summary>
        /// <param name="value">The Unicode character.</param>
        /// <returns></returns>
        public QuantifiablePattern Group(char value)
        {
            return ConcatInternal(Patterns.Group(value));
        }

        /// <summary>
        /// Appends a named group with a specified name and content.
        /// </summary>
        /// <param name="name">A name of the group.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public QuantifiablePattern NamedGroup(string name, object content)
        {
            return ConcatInternal(Patterns.NamedGroup(name, content));
        }

        /// <summary>
        /// Appends a named group with a specified name and content.
        /// </summary>
        /// <param name="name">A name of the group.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public QuantifiablePattern NamedGroup(string name, params object[] content)
        {
            return ConcatInternal(Patterns.NamedGroup(name, content));
        }

        /// <summary>
        /// Appends a named group with a specified name containing a specified Unicode character..
        /// </summary>
        /// <param name="name">A name of the group.</param>
        /// <param name="value">The Unicode character.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public QuantifiablePattern NamedGroup(string name, char value)
        {
            return ConcatInternal(Patterns.NamedGroup(name, value));
        }

        /// <summary>
        /// Appends a noncapturing group with a specified content.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern NoncapturingGroup(object content)
        {
            return ConcatInternal(Patterns.NoncapturingGroup((content)));
        }

        /// <summary>
        /// Appends a noncapturing group with a specified content.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern NoncapturingGroup(params object[] content)
        {
            return ConcatInternal(Patterns.NoncapturingGroup(content));
        }

        /// <summary>
        /// Appends a balancing group with specified group names and a content.
        /// </summary>
        /// <param name="name1">Current group name.</param>
        /// <param name="name2">Previously defined group name.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public QuantifiablePattern BalancingGroup(string name1, string name2, object content)
        {
            return ConcatInternal(Patterns.BalancingGroup(name1, name2, content));
        }

        /// <summary>
        /// Appends a balancing group with specified group names and a content.
        /// </summary>
        /// <param name="name1">Current group name.</param>
        /// <param name="name2">Previously defined group name.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public QuantifiablePattern BalancingGroup(string name1, string name2, params object[] content)
        {
            return ConcatInternal(Patterns.BalancingGroup(name1, name2, content));
        }

        /// <summary>
        /// Appends a nonbacktracking group with a specified content.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern NonbacktrackingGroup(object content)
        {
            return ConcatInternal(Patterns.NonbacktrackingGroup(content));
        }

        /// <summary>
        /// Appends a nonbacktracking group with a specified content.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern NonbacktrackingGroup(params object[] content)
        {
            return ConcatInternal(Patterns.NonbacktrackingGroup(content));
        }

        /// <summary>
        /// Appends a pattern that applies specified options.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <returns></returns>
        public Pattern Options(RegexOptions applyOptions)
        {
            return ConcatInternal(Patterns.Options(applyOptions));
        }

        /// <summary>
        /// Appends a pattern that applies specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern Options(RegexOptions applyOptions, object content)
        {
            return ConcatInternal(Patterns.Options(applyOptions, content));
        }

        /// <summary>
        /// Appends a pattern that applies specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern Options(RegexOptions applyOptions, params object[] content)
        {
            return ConcatInternal(Patterns.Options(applyOptions, content));
        }

        /// <summary>
        /// Appends a pattern that applies and disables specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="disableOptions">A bitwise combination of the enumeration values that are disabled.</param>
        /// <returns></returns>
        public Pattern Options(RegexOptions applyOptions, RegexOptions disableOptions)
        {
            return ConcatInternal(Patterns.Options(applyOptions, disableOptions));
        }

        /// <summary>
        /// Appends a pattern that applies and disables specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="disableOptions">A bitwise combination of the enumeration values that are disabled.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern Options(RegexOptions applyOptions, RegexOptions disableOptions, object content)
        {
            return ConcatInternal(Patterns.Options(applyOptions, disableOptions, content));
        }

        /// <summary>
        /// Appends a pattern that applies and disables specified options to a specified pattern.
        /// </summary>
        /// <param name="applyOptions">A bitwise combination of the enumeration values that are applied.</param>
        /// <param name="disableOptions">A bitwise combination of the enumeration values that are disabled.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        public QuantifiablePattern Options(RegexOptions applyOptions, RegexOptions disableOptions, params object[] content)
        {
            return ConcatInternal(Patterns.Options(applyOptions, disableOptions, content));
        }

        /// <summary>
        /// Appends a pattern that disables specified options.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values that are disabled.</param>
        /// <returns></returns>
        public Pattern DisableOptions(RegexOptions options)
        {
            return ConcatInternal(Patterns.DisableOptions(options));
        }

        /// <summary>
        /// Appends a pattern that disables specified options to a specified pattern.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values that are disabled.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern DisableOptions(RegexOptions options, object content)
        {
            return ConcatInternal(Patterns.DisableOptions(options, content));
        }

        /// <summary>
        /// Appends a pattern that disables specified options to a specified pattern.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values that are disabled.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern DisableOptions(RegexOptions options, params object[] content)
        {
            return ConcatInternal(Patterns.DisableOptions(options, content));
        }

        /// <summary>
        /// Returns a numbered group with current instance as a content.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern AsGroup()
        {
            return Patterns.Group(this);
        }

        /// <summary>
        /// Returns a named group with a specified name and current instance as a content.
        /// </summary>
        /// <param name="groupName">A name of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public QuantifiablePattern AsNamedGroup(string groupName)
        {
            return Patterns.NamedGroup(groupName, this);
        }

        /// <summary>
        /// Returns a noncapturing group with current instance as a content.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern AsNoncapturingGroup()
        {
            return Patterns.NoncapturingGroup(this);
        }

        /// <summary>
        /// Returns a nonbacktracking group with a current instance as a content.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern AsNonbacktrackingGroup()
        {
            return Patterns.NonbacktrackingGroup(this);
        }

        /// <summary>
        /// Appends a pattern that matches two apostrophes.
        /// </summary>
        /// <returns></returns>
        public Pattern Apostrophes()
        {
            return ConcatInternal(Patterns.Apostrophes());
        }

        /// <summary>
        /// Appends a pattern that matches specified pattern surrounded with apostrophes.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Pattern Apostrophes(object content)
        {
            return ConcatInternal(Patterns.Apostrophes(content));
        }

        /// <summary>
        /// Appends a pattern that matches two quotation marks.
        /// </summary>
        /// <returns></returns>
        public Pattern QuoteMarks()
        {
            return ConcatInternal(Patterns.QuoteMarks());
        }

        /// <summary>
        /// Appends a pattern that matches specified pattern surrounded with quotation marks.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Pattern QuoteMarks(object content)
        {
            return ConcatInternal(Patterns.QuoteMarks(content));
        }

        /// <summary>
        /// Appends a pattern that matches a text consisting of left and right parenthesis.
        /// </summary>
        /// <returns></returns>
        public Pattern Parentheses()
        {
            return ConcatInternal(Patterns.Parentheses());
        }

        /// <summary>
        /// Appends a pattern that matches specified pattern surrounded with left and right parenthesis.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Pattern Parentheses(object content)
        {
            return ConcatInternal(Patterns.Parentheses(content));
        }

        /// <summary>
        /// Appends a pattern that matches a text consisting of left and right curly bracket.
        /// </summary>
        /// <returns></returns>
        public Pattern CurlyBrackets()
        {
            return ConcatInternal(Patterns.CurlyBrackets());
        }

        /// <summary>
        /// Appends a pattern that matches specified pattern surrounded with left and right curly bracket.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Pattern CurlyBrackets(object content)
        {
            return ConcatInternal(Patterns.CurlyBrackets(content));
        }

        /// <summary>
        /// Appends a pattern that matches a text consisting of left and right square bracket.
        /// </summary>
        /// <returns></returns>
        public Pattern SquareBrackets()
        {
            return ConcatInternal(Patterns.SquareBrackets());
        }

        /// <summary>
        /// Appends a pattern that matches specified pattern surrounded with left and right square bracket.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Pattern SquareBrackets(object content)
        {
            return ConcatInternal(Patterns.SquareBrackets(content));
        }

        /// <summary>
        /// Appends a pattern that matches a text consisting of left and right angle bracket.
        /// </summary>
        /// <returns></returns>
        public Pattern AngleBrackets()
        {
            return ConcatInternal(Patterns.AngleBrackets());
        }

        /// <summary>
        /// Appends a pattern that matches specified pattern surrounded with left and right angle bracket.
        /// </summary>
        /// <param name="content"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Pattern AngleBrackets(object content)
        {
            return ConcatInternal(Patterns.AngleBrackets(content));
        }

        /// <summary>
        /// Appends a pattern that matches a character in the specified range.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiablePattern Range(char first, char last)
        {
            return ConcatInternal(Patterns.Range(first, last));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not in the specified range.
        /// </summary>
        /// <param name="first">The first character of the range.</param>
        /// <param name="last">The last character of the range.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiablePattern NotRange(char first, char last)
        {
            return ConcatInternal(Patterns.NotRange(first, last));
        }

        /// <summary>
        /// Appends a pattern that matches a white-space character except carriage return and linefeed.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern WhiteSpaceExceptNewLine()
        {
            return ConcatInternal(Patterns.WhiteSpaceExceptNewLine());
        }

        /// <summary>
        /// Appends a pattern that matches a white-space character except carriage return and linefeed. The character has to be matched specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup WhiteSpaceExceptNewLine(int exactCount)
        {
            return ConcatInternal(Patterns.WhiteSpaceExceptNewLine(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a white-space character except carriage return and linefeed. The character has to be matched from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup WhiteSpaceExceptNewLine(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.WhiteSpaceExceptNewLine(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a specified character zero or more times.
        /// </summary>
        /// <param name="value">The Unicode character.</param>
        /// <returns></returns>
        public Pattern WhileChar(char value)
        {
            return ConcatInternal(Patterns.WhileChar(value));
        }

        /// <summary>
        /// Appends a pattern that matches a specified character zero or more times.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public Pattern WhileChar(AsciiChar value)
        {
            return ConcatInternal(Patterns.WhileChar(value));
        }

        /// <summary>
        /// Appends a pattern that matches a specified character zero or more times.
        /// </summary>
        /// <param name="value">A set of Unicode characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Pattern WhileChar(CharGrouping value)
        {
            return ConcatInternal(Patterns.WhileChar(value));
        }

        /// <summary>
        /// Appends a pattern that matches a digit character zero or more times.
        /// </summary>
        /// <returns></returns>
        public QuantifiedPattern WhileDigit()
        {
            return ConcatInternal(Patterns.WhileDigit());
        }

        /// <summary>
        /// Appends a pattern that matches a word character zero or more times.
        /// </summary>
        /// <returns></returns>
        public QuantifiedPattern WhileWordChar()
        {
            return ConcatInternal(Patterns.WhileWordChar());
        }

        /// <summary>
        /// Appends a pattern that matches a white-space character zero or more times.
        /// </summary>
        /// <returns></returns>
        public QuantifiedPattern WhileWhiteSpace()
        {
            return ConcatInternal(Patterns.WhileWhiteSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a specified character zero or more times.
        /// </summary>
        /// <param name="value">The Unicode character.</param>
        /// <returns></returns>
        public Pattern WhileNotChar(char value)
        {
            return ConcatInternal(Patterns.WhileNotChar(value));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a specified character zero or more times.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public Pattern WhileNotChar(AsciiChar value)
        {
            return ConcatInternal(Patterns.WhileNotChar(value));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a specified character zero or more times.
        /// </summary>
        /// <param name="value">A set of Unicode characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public Pattern WhileNotChar(CharGrouping value)
        {
            return ConcatInternal(Patterns.WhileNotChar(value));
        }

        /// <summary>
        /// Appends a pattern that matches any character except linefeed (or any character if the Singleline option is applied).
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Any()
        {
            return ConcatInternal(Patterns.Any());
        }

        /// <summary>
        /// Appends a pattern that matches any character except linefeed (or any character if the Singleline option is applied) specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Any(int exactCount)
        {
            return ConcatInternal(Patterns.Any(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches any character except linefeed (or any character if the Singleline option is applied) from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Any(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Any(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches any character.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern AnyInvariant()
        {
            return ConcatInternal(Patterns.AnyInvariant());
        }

        /// <summary>
        /// Appends a pattern that matches any character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup AnyInvariant(int exactCount)
        {
            return ConcatInternal(Patterns.AnyInvariant(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches any character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup AnyInvariant(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.AnyInvariant(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches any character except linefeed (or any character if the Singleline option is applied) zero or more times but as few times as possible.
        /// </summary>
        /// <returns></returns>
        public Pattern Crawl()
        {
            return ConcatInternal(Patterns.Crawl());
        }

        /// <summary>
        /// Appends a pattern that matches any character zero or more times but as few times as possible.
        /// </summary>
        /// <returns></returns>
        public Pattern CrawlInvariant()
        {
            return ConcatInternal(Patterns.CrawlInvariant());
        }

        /// <summary>
        /// Appends a pattern that matches an alphanumeric character. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGroup Alphanumeric()
        {
            return ConcatInternal(Patterns.Alphanumeric());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of alphanumeric characters. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Alphanumeric(int exactCount)
        {
            return ConcatInternal(Patterns.Alphanumeric(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches an alphanumeric character from minimal to maximum times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Alphanumeric(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Alphanumeric(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an alphanumeric character. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGroup NotAlphanumeric()
        {
            return ConcatInternal(Patterns.NotAlphanumeric());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an alphanumeric character specified number of times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAlphanumeric(int exactCount)
        {
            return ConcatInternal(Patterns.NotAlphanumeric(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an alphanumeric character from minimal to maximum times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAlphanumeric(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotAlphanumeric(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a lower-case alphanumeric character. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also match upper-case latin letter.
        /// </summary>
        /// <returns></returns>
        public CharGroup AlphanumericLower()
        {
            return ConcatInternal(Patterns.AlphanumericLower());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of lower-case alphanumeric characters. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also match upper-case latin letter.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup AlphanumericLower(int exactCount)
        {
            return ConcatInternal(Patterns.AlphanumericLower(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a lower-case alphanumeric character from minimal to maximum times. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also match upper-case latin letter.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup AlphanumericLower(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.AlphanumericLower(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a lower-case alphanumeric character. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also not match upper-case latin letter.
        /// </summary>
        /// <returns></returns>
        public CharGroup NotAlphanumericLower()
        {
            return ConcatInternal(Patterns.NotAlphanumericLower());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a lower-case alphanumeric character specified number of times. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also not match upper-case latin letter.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAlphanumericLower(int exactCount)
        {
            return ConcatInternal(Patterns.NotAlphanumericLower(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a lower-case alphanumeric character from minimal to maximum times. Alphanumeric character is a latin alphabet lower-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also not match upper-case latin letter.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAlphanumericLower(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotAlphanumericLower(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches an upper-case alphanumeric character. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also match lower-case latin letter.
        /// </summary>
        /// <returns></returns>
        public CharGroup AlphanumericUpper()
        {
            return ConcatInternal(Patterns.AlphanumericUpper());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of upper-case alphanumeric characters. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also match lower-case latin letter.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup AlphanumericUpper(int exactCount)
        {
            return ConcatInternal(Patterns.AlphanumericUpper(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches an upper-case alphanumeric character from minimal to maximum times. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also match lower-case latin letter.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup AlphanumericUpper(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.AlphanumericUpper(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an upper-case alphanumeric character. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also not match lower-case latin letter.
        /// </summary>
        /// <returns></returns>
        public CharGroup NotAlphanumericUpper()
        {
            return ConcatInternal(Patterns.NotAlphanumericUpper());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an upper-case alphanumeric character specified number of times. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also not match lower-case latin letter.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAlphanumericUpper(int exactCount)
        {
            return ConcatInternal(Patterns.NotAlphanumericUpper(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an upper-case alphanumeric character from minimal to maximum times. Alphanumeric character is a latin alphabet upper-case letter or an arabic digit.
        /// If the "ignore case" option is applied the pattern will also not match lower-case latin letter.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAlphanumericUpper(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotAlphanumericUpper(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches an alphanumeric character or an underscore. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGroup AlphanumericUnderscore()
        {
            return ConcatInternal(Patterns.AlphanumericUnderscore());
        }

        /// <summary>
        /// Appends a pattern that matches an alphanumeric character or an underscore specified number of times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup AlphanumericUnderscore(int exactCount)
        {
            return ConcatInternal(Patterns.AlphanumericUnderscore(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches an alphanumeric character or an underscore from minimal to maximum times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup AlphanumericUnderscore(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.AlphanumericUnderscore(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is neither alphanumeric character nor underscore. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <returns></returns>
        public CharGroup NotAlphanumericUnderscore()
        {
            return ConcatInternal(Patterns.NotAlphanumericUnderscore());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is neither alphanumeric character nor underscore specified number of times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAlphanumericUnderscore(int exactCount)
        {
            return ConcatInternal(Patterns.NotAlphanumericUnderscore(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is neither alphanumeric character nor underscore from minimal to maximum times. Alphanumeric character is a latin alphabet letter or an arabic digit.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAlphanumericUnderscore(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotAlphanumericUnderscore(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet letter.
        /// </summary>
        /// <returns></returns>
        public CharGroup LatinLetter()
        {
            return ConcatInternal(Patterns.LatinLetter());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of latin alphabet letters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LatinLetter(int exactCount)
        {
            return ConcatInternal(Patterns.LatinLetter(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet letter from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LatinLetter(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LatinLetter(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet lower-case letter. If the "ignore case" option is applied the pattern will also match upper-case latin letter.
        /// </summary>
        /// <returns></returns>
        public CharGroup LatinLetterLower()
        {
            return ConcatInternal(Patterns.LatinLetterLower());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of latin alphabet lower-case letters. If the "ignore case" option is applied the pattern will also match upper-case latin letter.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LatinLetterLower(int exactCount)
        {
            return ConcatInternal(Patterns.LatinLetterLower(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet lower-case letter from minimal to maximum times. If the "ignore case" option is applied the pattern will also match upper-case latin letter.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LatinLetterLower(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LatinLetterLower(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet upper-case letter. If the "ignore case" option is applied the pattern will also match lower-case latin letter.
        /// </summary>
        /// <returns></returns>
        public CharGroup LatinLetterUpper()
        {
            return ConcatInternal(Patterns.LatinLetterUpper());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of latin alphabet upper-case letters. If the "ignore case" option is applied the pattern will also match lower-case latin letter.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LatinLetterUpper(int exactCount)
        {
            return ConcatInternal(Patterns.LatinLetterUpper(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet upper-case letter from minimal to maximum times. If the "ignore case" option is applied the pattern will also match lower-case latin letter.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LatinLetterUpper(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LatinLetterUpper(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a latin alphabet letter.
        /// </summary>
        /// <returns></returns>
        public CharGroup NotLatinLetter()
        {
            return ConcatInternal(Patterns.NotLatinLetter());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a latin alphabet letter specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLatinLetter(int exactCount)
        {
            return ConcatInternal(Patterns.NotLatinLetter(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a latin alphabet letter from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLatinLetter(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLatinLetter(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a latin alphabet lower-case letter.
        /// </summary>
        /// <returns></returns>
        public CharGroup NotLatinLetterLower()
        {
            return ConcatInternal(Patterns.NotLatinLetterLower());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a latin alphabet lower-case letter specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLatinLetterLower(int exactCount)
        {
            return ConcatInternal(Patterns.NotLatinLetterLower(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a latin alphabet lower-case letter from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLatinLetterLower(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLatinLetterLower(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a latin alphabet upper-case letter.
        /// If the "ignore case" option is applied the pattern will also not match lower-case latin letter.
        /// </summary>
        /// <returns></returns>
        public CharGroup NotLatinLetterUpper()
        {
            return ConcatInternal(Patterns.NotLatinLetterUpper());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a latin alphabet upper-case letter specified number of times.
        /// If the "ignore case" option is applied the pattern will also not match lower-case latin letter.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLatinLetterUpper(int exactCount)
        {
            return ConcatInternal(Patterns.NotLatinLetterUpper(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a latin alphabet upper-case letter from minimal to maximum times.
        /// If the "ignore case" option is applied the pattern will also not match lower-case latin letter.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLatinLetterUpper(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLatinLetterUpper(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// If the "ignore case" option is applied the pattern will also match a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// </summary>
        /// <returns></returns>
        public CharPattern LetterLower()
        {
            return ConcatInternal(Patterns.LetterLower());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of letters from <see cref="GeneralCategory.LetterLowercase"/>.
        /// If the "ignore case" option is applied the pattern will also match a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LetterLower(int exactCount)
        {
            return ConcatInternal(Patterns.LetterLower(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character from <see cref="GeneralCategory.LetterLowercase"/> from minimal to maximum times.
        /// If the "ignore case" option is applied the pattern will also match a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LetterLower(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LetterLower(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// If the "ignore case" option is applied the pattern will also not match a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// </summary>
        /// <returns></returns>
        public CharPattern NotLetterLower()
        {
            return ConcatInternal(Patterns.NotLetterLower());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a character from <see cref="GeneralCategory.LetterLowercase"/> specified number of times.
        /// If the "ignore case" option is applied the pattern will also not match a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLetterLower(int exactCount)
        {
            return ConcatInternal(Patterns.NotLetterLower(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a character from <see cref="GeneralCategory.LetterLowercase"/> from minimal to maximum times.
        /// If the "ignore case" option is applied the pattern will also not match a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLetterLower(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLetterLower(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// If the "ignore case" option is applied the pattern will also match a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// </summary>
        /// <returns></returns>
        public CharPattern LetterUpper()
        {
            return ConcatInternal(Patterns.LetterUpper());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of letters from <see cref="GeneralCategory.LetterUppercase"/>.
        /// If the "ignore case" option is applied the pattern will also match a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LetterUpper(int exactCount)
        {
            return ConcatInternal(Patterns.LetterUpper(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character from <see cref="GeneralCategory.LetterUppercase"/> from minimal to maximum times.
        /// If the "ignore case" option is applied the pattern will also match a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LetterUpper(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LetterUpper(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a character from <see cref="GeneralCategory.LetterUppercase"/>.
        /// If the "ignore case" option is applied the pattern will also not match a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// </summary>
        /// <returns></returns>
        public CharPattern NotLetterUpper()
        {
            return ConcatInternal(Patterns.NotLetterUpper());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a character from <see cref="GeneralCategory.LetterUppercase"/> specified number of times.
        /// If the "ignore case" option is applied the pattern will also not match a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLetterUpper(int exactCount)
        {
            return ConcatInternal(Patterns.NotLetterUpper(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a character from <see cref="GeneralCategory.LetterUppercase"/> from minimal to maximum times.
        /// If the "ignore case" option is applied the pattern will also not match a character from <see cref="GeneralCategory.LetterLowercase"/>.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLetterUpper(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLetterUpper(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches an arabic digit.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern ArabicDigit()
        {
            return ConcatInternal(Patterns.ArabicDigit());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of arabic digits.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup ArabicDigit(int exactCount)
        {
            return ConcatInternal(Patterns.ArabicDigit(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches an arabic digit from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup ArabicDigit(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.ArabicDigit(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an arabic digit.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotArabicDigit()
        {
            return ConcatInternal(Patterns.NotArabicDigit());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an arabic digit specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotArabicDigit(int exactCount)
        {
            return ConcatInternal(Patterns.NotArabicDigit(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an arabic digit from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotArabicDigit(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotArabicDigit(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a hexadecimal digit.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern HexadecimalDigit()
        {
            return ConcatInternal(Patterns.HexadecimalDigit());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of hexadecimal digits.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup HexadecimalDigit(int exactCount)
        {
            return ConcatInternal(Patterns.HexadecimalDigit(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a hexadecimal digit from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup HexadecimalDigit(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.HexadecimalDigit(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a hexadecimal digit.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotHexadecimalDigit()
        {
            return ConcatInternal(Patterns.NotHexadecimalDigit());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a hexadecimal digit specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotHexadecimalDigit(int exactCount)
        {
            return ConcatInternal(Patterns.NotHexadecimalDigit(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a hexadecimal digit from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotHexadecimalDigit(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotHexadecimalDigit(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a digit character.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Digit()
        {
            return ConcatInternal(Patterns.Digit());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of digit characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Digit(int exactCount)
        {
            return ConcatInternal(Patterns.Digit(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a digit character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Digit(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Digit(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches one or more digit characters.
        /// </summary>
        /// <returns></returns>
        public QuantifiedGroup Digits()
        {
            return ConcatInternal(Patterns.Digits());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a digit character.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotDigit()
        {
            return ConcatInternal(Patterns.NotDigit());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a digit character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotDigit(int exactCount)
        {
            return ConcatInternal(Patterns.NotDigit(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a digit character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotDigit(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotDigit(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches one or more characters that are not a digit character.
        /// </summary>
        /// <returns></returns>
        public QuantifiedGroup NotDigits()
        {
            return ConcatInternal(Patterns.NotDigits());
        }

        /// <summary>
        /// Appends a pattern that matches a white-space character.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern WhiteSpace()
        {
            return ConcatInternal(Patterns.WhiteSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of white-space characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup WhiteSpace(int exactCount)
        {
            return ConcatInternal(Patterns.WhiteSpace(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a white-space character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup WhiteSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.WhiteSpace(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches one or more white-space characters.
        /// </summary>
        /// <returns></returns>
        public QuantifiedGroup WhiteSpaces()
        {
            return ConcatInternal(Patterns.WhiteSpaces());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a white-space character.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotWhiteSpace()
        {
            return ConcatInternal(Patterns.NotWhiteSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a white-space character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotWhiteSpace(int exactCount)
        {
            return ConcatInternal(Patterns.NotWhiteSpace(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a white-space character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotWhiteSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotWhiteSpace(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches one or more characters that are not a white-space character.
        /// </summary>
        /// <returns></returns>
        public QuantifiedGroup NotWhiteSpaces()
        {
            return ConcatInternal(Patterns.NotWhiteSpaces());
        }

        /// <summary>
        /// Appends a pattern that matches a word character.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern WordChar()
        {
            return ConcatInternal(Patterns.WordChar());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of word characters.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup WordChar(int exactCount)
        {
            return ConcatInternal(Patterns.WordChar(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a word character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup WordChar(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.WordChar(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches one or more word characters.
        /// </summary>
        /// <returns></returns>
        public QuantifiedGroup WordChars()
        {
            return ConcatInternal(Patterns.WordChars());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a word character.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotWordChar()
        {
            return ConcatInternal(Patterns.NotWordChar());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a word character specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotWordChar(int exactCount)
        {
            return ConcatInternal(Patterns.NotWordChar(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a word character from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotWordChar(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotWordChar(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches one or more characters that are not a word character.
        /// </summary>
        /// <returns></returns>
        public QuantifiedGroup NotWordChars()
        {
            return ConcatInternal(Patterns.NotWordChars());
        }

        /// <summary>
        /// Appends a pattern that matches a specified character.
        /// </summary>
        /// <param name="value">The Unicode character.</param>
        /// <returns></returns>
        public QuantifiablePattern Character(char value)
        {
            return ConcatInternal(Patterns.Character(value));
        }

        /// <summary>
        /// Appends a pattern that matches a specified character.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public QuantifiablePattern Character(AsciiChar value)
        {
            return ConcatInternal(Patterns.Character(value));
        }

        /// <summary>
        /// Appends a pattern that matches a character from a specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        /// <returns></returns>
        public QuantifiablePattern Character(NamedBlock block)
        {
            return ConcatInternal(Patterns.Character(block));
        }

        /// <summary>
        /// Appends a pattern that matches a character from a specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        /// <returns></returns>
        public QuantifiablePattern Character(GeneralCategory category)
        {
            return ConcatInternal(Patterns.Character(category));
        }

        /// <summary>
        /// Appends a character group containing specified characters.
        /// </summary>
        /// <param name="characters">A set of characters any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public QuantifiablePattern Character(string characters)
        {
            return ConcatInternal(Patterns.Character(characters));
        }

        /// <summary>
        /// Appends a character group containing specified <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">A content of a character group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern Character(CharGrouping value)
        {
            return ConcatInternal(Patterns.Character(value));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a specified character..
        /// </summary>
        /// <param name="value">The Unicode character.</param>
        /// <returns></returns>
        public QuantifiablePattern Not(char value)
        {
            return ConcatInternal(Patterns.Not(value));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a specified character..
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public QuantifiablePattern Not(AsciiChar value)
        {
            return ConcatInternal(Patterns.Not(value));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not from a specified Unicode block.
        /// </summary>
        /// <param name="block">An enumerated constant that identifies Unicode block.</param>
        /// <returns></returns>
        public QuantifiablePattern Not(NamedBlock block)
        {
            return ConcatInternal(Patterns.Not(block));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not from a specified Unicode category.
        /// </summary>
        /// <param name="category">An enumerated constant that identifies Unicode category.</param>
        /// <returns></returns>
        public QuantifiablePattern Not(GeneralCategory category)
        {
            return ConcatInternal(Patterns.Not(category));
        }

        /// <summary>
        /// Appends a negative character group containing specified characters.
        /// </summary>
        /// <param name="characters">A set of Unicode characters none of which can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public QuantifiablePattern Not(string characters)
        {
            return ConcatInternal(Patterns.Not(characters));
        }

        /// <summary>
        /// Appends a negative character group containing specified <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">A content of a character group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern Not(CharGrouping value)
        {
            return ConcatInternal(Patterns.Not(value));
        }

        /// <summary>
        /// Appends a pattern that matches a tab.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Tab()
        {
            return ConcatInternal(Patterns.Tab());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of tabs.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Tab(int exactCount)
        {
            return ConcatInternal(Patterns.Tab(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a tab from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Tab(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Tab(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a tab.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotTab()
        {
            return ConcatInternal(Patterns.NotTab());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a tab.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotTab(int exactCount)
        {
            return ConcatInternal(Patterns.NotTab(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a tab from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotTab(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotTab(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a linefeed.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Linefeed()
        {
            return ConcatInternal(Patterns.Linefeed());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of linefeeds.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Linefeed(int exactCount)
        {
            return ConcatInternal(Patterns.Linefeed(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a linefeed from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Linefeed(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Linefeed(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a linefeed.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotLinefeed()
        {
            return ConcatInternal(Patterns.NotLinefeed());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a linefeed.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLinefeed(int exactCount)
        {
            return ConcatInternal(Patterns.NotLinefeed(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a linefeed from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLinefeed(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLinefeed(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a carriage return.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern CarriageReturn()
        {
            return ConcatInternal(Patterns.CarriageReturn());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of carriage returns.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup CarriageReturn(int exactCount)
        {
            return ConcatInternal(Patterns.CarriageReturn(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a carriage return from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup CarriageReturn(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.CarriageReturn(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a carriage return.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotCarriageReturn()
        {
            return ConcatInternal(Patterns.NotCarriageReturn());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a carriage return.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotCarriageReturn(int exactCount)
        {
            return ConcatInternal(Patterns.NotCarriageReturn(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a carriage return from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotCarriageReturn(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotCarriageReturn(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a space.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Space()
        {
            return ConcatInternal(Patterns.Space());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of spaces.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Space(int exactCount)
        {
            return ConcatInternal(Patterns.Space(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a space from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Space(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Space(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a space.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotSpace()
        {
            return ConcatInternal(Patterns.NotSpace());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a space.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotSpace(int exactCount)
        {
            return ConcatInternal(Patterns.NotSpace(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a space from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotSpace(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches an exclamation mark.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern ExclamationMark()
        {
            return ConcatInternal(Patterns.ExclamationMark());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of exclamation marks.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup ExclamationMark(int exactCount)
        {
            return ConcatInternal(Patterns.ExclamationMark(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches an exclamation mark from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup ExclamationMark(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.ExclamationMark(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an exclamation mark.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotExclamationMark()
        {
            return ConcatInternal(Patterns.NotExclamationMark());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not an exclamation mark.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotExclamationMark(int exactCount)
        {
            return ConcatInternal(Patterns.NotExclamationMark(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an exclamation mark from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotExclamationMark(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotExclamationMark(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a quote mark.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern QuoteMark()
        {
            return ConcatInternal(Patterns.QuoteMark());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of quote marks.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup QuoteMark(int exactCount)
        {
            return ConcatInternal(Patterns.QuoteMark(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a quote mark from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup QuoteMark(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.QuoteMark(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a quote mark.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotQuoteMark()
        {
            return ConcatInternal(Patterns.NotQuoteMark());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a quote mark.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotQuoteMark(int exactCount)
        {
            return ConcatInternal(Patterns.NotQuoteMark(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a quote mark from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotQuoteMark(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotQuoteMark(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a number sign.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NumberSign()
        {
            return ConcatInternal(Patterns.NumberSign());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of number signs.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NumberSign(int exactCount)
        {
            return ConcatInternal(Patterns.NumberSign(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a number sign from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NumberSign(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NumberSign(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a number sign.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotNumberSign()
        {
            return ConcatInternal(Patterns.NotNumberSign());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a number sign.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotNumberSign(int exactCount)
        {
            return ConcatInternal(Patterns.NotNumberSign(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a number sign from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotNumberSign(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotNumberSign(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a dollar.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Dollar()
        {
            return ConcatInternal(Patterns.Dollar());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of dollars.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Dollar(int exactCount)
        {
            return ConcatInternal(Patterns.Dollar(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a dollar from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Dollar(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Dollar(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a dollar.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotDollar()
        {
            return ConcatInternal(Patterns.NotDollar());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a dollar.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotDollar(int exactCount)
        {
            return ConcatInternal(Patterns.NotDollar(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a dollar from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotDollar(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotDollar(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a percent.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Percent()
        {
            return ConcatInternal(Patterns.Percent());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of percents.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Percent(int exactCount)
        {
            return ConcatInternal(Patterns.Percent(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a percent from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Percent(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Percent(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a percent.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotPercent()
        {
            return ConcatInternal(Patterns.NotPercent());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a percent.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotPercent(int exactCount)
        {
            return ConcatInternal(Patterns.NotPercent(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a percent from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotPercent(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotPercent(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches an ampersand.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Ampersand()
        {
            return ConcatInternal(Patterns.Ampersand());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of ampersands.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Ampersand(int exactCount)
        {
            return ConcatInternal(Patterns.Ampersand(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches an ampersand from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Ampersand(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Ampersand(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an ampersand.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotAmpersand()
        {
            return ConcatInternal(Patterns.NotAmpersand());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not an ampersand.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAmpersand(int exactCount)
        {
            return ConcatInternal(Patterns.NotAmpersand(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an ampersand from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAmpersand(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotAmpersand(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches an apostrophe.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Apostrophe()
        {
            return ConcatInternal(Patterns.Apostrophe());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of apostrophes.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Apostrophe(int exactCount)
        {
            return ConcatInternal(Patterns.Apostrophe(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches an apostrophe from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Apostrophe(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Apostrophe(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an apostrophe.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotApostrophe()
        {
            return ConcatInternal(Patterns.NotApostrophe());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not an apostrophe.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotApostrophe(int exactCount)
        {
            return ConcatInternal(Patterns.NotApostrophe(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an apostrophe from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotApostrophe(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotApostrophe(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a left parenthesis.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern LeftParenthesis()
        {
            return ConcatInternal(Patterns.LeftParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of left parentheses.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LeftParenthesis(int exactCount)
        {
            return ConcatInternal(Patterns.LeftParenthesis(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a left parenthesis from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LeftParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LeftParenthesis(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a left parenthesis.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotLeftParenthesis()
        {
            return ConcatInternal(Patterns.NotLeftParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a left parenthesis.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLeftParenthesis(int exactCount)
        {
            return ConcatInternal(Patterns.NotLeftParenthesis(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a left parenthesis from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLeftParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLeftParenthesis(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a right parenthesis.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern RightParenthesis()
        {
            return ConcatInternal(Patterns.RightParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of right parentheses.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup RightParenthesis(int exactCount)
        {
            return ConcatInternal(Patterns.RightParenthesis(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a right parenthesis from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup RightParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.RightParenthesis(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a right parenthesis.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotRightParenthesis()
        {
            return ConcatInternal(Patterns.NotRightParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a right parenthesis.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotRightParenthesis(int exactCount)
        {
            return ConcatInternal(Patterns.NotRightParenthesis(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a right parenthesis from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotRightParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotRightParenthesis(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches an asterisk.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Asterisk()
        {
            return ConcatInternal(Patterns.Asterisk());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of asterisks.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Asterisk(int exactCount)
        {
            return ConcatInternal(Patterns.Asterisk(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches an asterisk from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Asterisk(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Asterisk(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an asterisk.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotAsterisk()
        {
            return ConcatInternal(Patterns.NotAsterisk());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not an asterisk.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAsterisk(int exactCount)
        {
            return ConcatInternal(Patterns.NotAsterisk(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an asterisk from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAsterisk(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotAsterisk(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a plus.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Plus()
        {
            return ConcatInternal(Patterns.Plus());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of pluses.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Plus(int exactCount)
        {
            return ConcatInternal(Patterns.Plus(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a plus from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Plus(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Plus(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a plus.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotPlus()
        {
            return ConcatInternal(Patterns.NotPlus());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a plus.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotPlus(int exactCount)
        {
            return ConcatInternal(Patterns.NotPlus(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a plus from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotPlus(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotPlus(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a comma.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Comma()
        {
            return ConcatInternal(Patterns.Comma());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of commas.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Comma(int exactCount)
        {
            return ConcatInternal(Patterns.Comma(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a comma from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Comma(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Comma(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a comma.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotComma()
        {
            return ConcatInternal(Patterns.NotComma());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a comma.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotComma(int exactCount)
        {
            return ConcatInternal(Patterns.NotComma(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a comma from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotComma(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotComma(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a hyphen.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Hyphen()
        {
            return ConcatInternal(Patterns.Hyphen());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of hyphens.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Hyphen(int exactCount)
        {
            return ConcatInternal(Patterns.Hyphen(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a hyphen from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Hyphen(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Hyphen(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a hyphen.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotHyphen()
        {
            return ConcatInternal(Patterns.NotHyphen());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a hyphen.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotHyphen(int exactCount)
        {
            return ConcatInternal(Patterns.NotHyphen(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a hyphen from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotHyphen(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotHyphen(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a dot.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Dot()
        {
            return ConcatInternal(Patterns.Dot());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of dots.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Dot(int exactCount)
        {
            return ConcatInternal(Patterns.Dot(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a dot from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Dot(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Dot(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a dot.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotDot()
        {
            return ConcatInternal(Patterns.NotDot());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a dot.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotDot(int exactCount)
        {
            return ConcatInternal(Patterns.NotDot(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a dot from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotDot(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotDot(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a slash.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Slash()
        {
            return ConcatInternal(Patterns.Slash());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of slashes.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Slash(int exactCount)
        {
            return ConcatInternal(Patterns.Slash(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a slash from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Slash(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Slash(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a slash.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotSlash()
        {
            return ConcatInternal(Patterns.NotSlash());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a slash.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotSlash(int exactCount)
        {
            return ConcatInternal(Patterns.NotSlash(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a slash from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotSlash(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotSlash(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a colon.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Colon()
        {
            return ConcatInternal(Patterns.Colon());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of colons.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Colon(int exactCount)
        {
            return ConcatInternal(Patterns.Colon(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a colon from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Colon(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Colon(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a colon.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotColon()
        {
            return ConcatInternal(Patterns.NotColon());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a colon.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotColon(int exactCount)
        {
            return ConcatInternal(Patterns.NotColon(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a colon from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotColon(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotColon(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a semicolon.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Semicolon()
        {
            return ConcatInternal(Patterns.Semicolon());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of semicolons.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Semicolon(int exactCount)
        {
            return ConcatInternal(Patterns.Semicolon(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a semicolon from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Semicolon(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Semicolon(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a semicolon.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotSemicolon()
        {
            return ConcatInternal(Patterns.NotSemicolon());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a semicolon.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotSemicolon(int exactCount)
        {
            return ConcatInternal(Patterns.NotSemicolon(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a semicolon from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotSemicolon(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotSemicolon(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a left angle bracket (less-than sign).
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern LeftAngleBracket()
        {
            return ConcatInternal(Patterns.LeftAngleBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of left angle brackets (less-than signs).
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LeftAngleBracket(int exactCount)
        {
            return ConcatInternal(Patterns.LeftAngleBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a left angle bracket (less-than sign) from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LeftAngleBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LeftAngleBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a left angle bracket (less-than sign).
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotLeftAngleBracket()
        {
            return ConcatInternal(Patterns.NotLeftAngleBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a left angle bracket (less-than sign).
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLeftAngleBracket(int exactCount)
        {
            return ConcatInternal(Patterns.NotLeftAngleBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a left angle bracket (less-than sign) from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLeftAngleBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLeftAngleBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches an equals sign.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern EqualsSign()
        {
            return ConcatInternal(Patterns.EqualsSign());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of equals signs.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup EqualsSign(int exactCount)
        {
            return ConcatInternal(Patterns.EqualsSign(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches an equals sign from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup EqualsSign(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.EqualsSign(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an equals sign.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotEqualsSign()
        {
            return ConcatInternal(Patterns.NotEqualsSign());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not an equals sign.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotEqualsSign(int exactCount)
        {
            return ConcatInternal(Patterns.NotEqualsSign(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an equals sign from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotEqualsSign(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotEqualsSign(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a right angle bracket (greater-than sign).
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern RightAngleBracket()
        {
            return ConcatInternal(Patterns.RightAngleBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of right angle brackets (greater-than signs).
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup RightAngleBracket(int exactCount)
        {
            return ConcatInternal(Patterns.RightAngleBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a right angle bracket (greater-than sign) from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup RightAngleBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.RightAngleBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an right angle bracket (greater-than sign).
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotRightAngleBracket()
        {
            return ConcatInternal(Patterns.NotRightAngleBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a right angle bracket (greater-than sign).
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotRightAngleBracket(int exactCount)
        {
            return ConcatInternal(Patterns.NotRightAngleBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a right angle bracket (greater-than sign) from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotRightAngleBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotRightAngleBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a question mark.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern QuestionMark()
        {
            return ConcatInternal(Patterns.QuestionMark());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of question marks.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup QuestionMark(int exactCount)
        {
            return ConcatInternal(Patterns.QuestionMark(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a question mark from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup QuestionMark(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.QuestionMark(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a question mark.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotQuestionMark()
        {
            return ConcatInternal(Patterns.NotQuestionMark());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a question mark.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotQuestionMark(int exactCount)
        {
            return ConcatInternal(Patterns.NotQuestionMark(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a question mark from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotQuestionMark(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotQuestionMark(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches an at sign.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern AtSign()
        {
            return ConcatInternal(Patterns.AtSign());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of at signs.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup AtSign(int exactCount)
        {
            return ConcatInternal(Patterns.AtSign(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches an at sign from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup AtSign(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.AtSign(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an at sign.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotAtSign()
        {
            return ConcatInternal(Patterns.NotAtSign());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not an at sign.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAtSign(int exactCount)
        {
            return ConcatInternal(Patterns.NotAtSign(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an at sign from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotAtSign(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotAtSign(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a left square bracket.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern LeftSquareBracket()
        {
            return ConcatInternal(Patterns.LeftSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of left square brackets.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LeftSquareBracket(int exactCount)
        {
            return ConcatInternal(Patterns.LeftSquareBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a left square bracket from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LeftSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LeftSquareBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a left square bracket.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotLeftSquareBracket()
        {
            return ConcatInternal(Patterns.NotLeftSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a left square bracket.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLeftSquareBracket(int exactCount)
        {
            return ConcatInternal(Patterns.NotLeftSquareBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a left square bracket from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLeftSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLeftSquareBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a backslash.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Backslash()
        {
            return ConcatInternal(Patterns.Backslash());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of backslashes.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Backslash(int exactCount)
        {
            return ConcatInternal(Patterns.Backslash(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a backslash from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Backslash(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Backslash(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a backslash.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotBackslash()
        {
            return ConcatInternal(Patterns.NotBackslash());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a backslash.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotBackslash(int exactCount)
        {
            return ConcatInternal(Patterns.NotBackslash(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a backslash from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotBackslash(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotBackslash(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a right square bracket.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern RightSquareBracket()
        {
            return ConcatInternal(Patterns.RightSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of right square brackets.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup RightSquareBracket(int exactCount)
        {
            return ConcatInternal(Patterns.RightSquareBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a right square bracket from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup RightSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.RightSquareBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a right square bracket.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotRightSquareBracket()
        {
            return ConcatInternal(Patterns.NotRightSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a right square bracket.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotRightSquareBracket(int exactCount)
        {
            return ConcatInternal(Patterns.NotRightSquareBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a right square bracket from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotRightSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotRightSquareBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a circumflex accent.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern CircumflexAccent()
        {
            return ConcatInternal(Patterns.CircumflexAccent());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of circumflex accents.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup CircumflexAccent(int exactCount)
        {
            return ConcatInternal(Patterns.CircumflexAccent(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a circumflex accent from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup CircumflexAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.CircumflexAccent(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a circumflex accent.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotCircumflexAccent()
        {
            return ConcatInternal(Patterns.NotCircumflexAccent());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a circumflex accent.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotCircumflexAccent(int exactCount)
        {
            return ConcatInternal(Patterns.NotCircumflexAccent(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a circumflex accent from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotCircumflexAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotCircumflexAccent(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches an underscore.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Underscore()
        {
            return ConcatInternal(Patterns.Underscore());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of underscores.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Underscore(int exactCount)
        {
            return ConcatInternal(Patterns.Underscore(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches an underscore from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Underscore(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Underscore(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an underscore.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotUnderscore()
        {
            return ConcatInternal(Patterns.NotUnderscore());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not an underscore.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotUnderscore(int exactCount)
        {
            return ConcatInternal(Patterns.NotUnderscore(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not an underscore from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotUnderscore(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotUnderscore(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a grave accent.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern GraveAccent()
        {
            return ConcatInternal(Patterns.GraveAccent());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of grave accents.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup GraveAccent(int exactCount)
        {
            return ConcatInternal(Patterns.GraveAccent(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a grave accent from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup GraveAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.GraveAccent(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a grave accent.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotGraveAccent()
        {
            return ConcatInternal(Patterns.NotGraveAccent());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a grave accent.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotGraveAccent(int exactCount)
        {
            return ConcatInternal(Patterns.NotGraveAccent(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a grave accent from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotGraveAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotGraveAccent(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a left curly bracket.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern LeftCurlyBracket()
        {
            return ConcatInternal(Patterns.LeftCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of left curly brackets.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LeftCurlyBracket(int exactCount)
        {
            return ConcatInternal(Patterns.LeftCurlyBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a left curly bracket from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup LeftCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LeftCurlyBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a left curly bracket.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotLeftCurlyBracket()
        {
            return ConcatInternal(Patterns.NotLeftCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a left curly bracket.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLeftCurlyBracket(int exactCount)
        {
            return ConcatInternal(Patterns.NotLeftCurlyBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a left curly bracket from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLeftCurlyBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a vertical line.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern VerticalLine()
        {
            return ConcatInternal(Patterns.VerticalLine());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of vertical lines.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup VerticalLine(int exactCount)
        {
            return ConcatInternal(Patterns.VerticalLine(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a vertical line from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup VerticalLine(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.VerticalLine(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a vertical line.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotVerticalLine()
        {
            return ConcatInternal(Patterns.NotVerticalLine());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a vertical line.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotVerticalLine(int exactCount)
        {
            return ConcatInternal(Patterns.NotVerticalLine(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a vertical line from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotVerticalLine(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotVerticalLine(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a right curly bracket.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern RightCurlyBracket()
        {
            return ConcatInternal(Patterns.RightCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of right curly brackets.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup RightCurlyBracket(int exactCount)
        {
            return ConcatInternal(Patterns.RightCurlyBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a right curly bracket from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup RightCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.RightCurlyBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a right curly bracket.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotRightCurlyBracket()
        {
            return ConcatInternal(Patterns.NotRightCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a right curly bracket.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotRightCurlyBracket(int exactCount)
        {
            return ConcatInternal(Patterns.NotRightCurlyBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a right curly bracket from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotRightCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotRightCurlyBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a tilde.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern Tilde()
        {
            return ConcatInternal(Patterns.Tilde());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of tildes.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Tilde(int exactCount)
        {
            return ConcatInternal(Patterns.Tilde(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a tilde from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Tilde(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Tilde(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a tilde.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotTilde()
        {
            return ConcatInternal(Patterns.NotTilde());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of characters that are not a tilde.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotTilde(int exactCount)
        {
            return ConcatInternal(Patterns.NotTilde(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a tilde from minimum to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotTilde(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotTilde(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches left or right parenthesis.
        /// </summary>
        /// <returns></returns>
        public CharGroup Parenthesis()
        {
            return ConcatInternal(Patterns.Parenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches left or right parenthesis specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Parenthesis(int exactCount)
        {
            return ConcatInternal(Patterns.Parenthesis(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches left or right parenthesis from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Parenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Parenthesis(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is neither left nor right parenthesis.
        /// </summary>
        /// <returns></returns>
        public CharGroup NotParenthesis()
        {
            return ConcatInternal(Patterns.NotParenthesis());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is neither left nor right parenthesis specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotParenthesis(int exactCount)
        {
            return ConcatInternal(Patterns.NotParenthesis(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is neither left nor right parenthesis from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotParenthesis(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches left or right curly bracket.
        /// </summary>
        /// <returns></returns>
        public CharGroup CurlyBracket()
        {
            return ConcatInternal(Patterns.CurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches left or right curly bracket specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup CurlyBracket(int exactCount)
        {
            return ConcatInternal(Patterns.CurlyBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches left or right curly bracket from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup CurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.CurlyBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is neither left nor right curly bracket.
        /// </summary>
        /// <returns></returns>
        public CharGroup NotCurlyBracket()
        {
            return ConcatInternal(Patterns.NotCurlyBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is neither left nor right curly bracket specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotCurlyBracket(int exactCount)
        {
            return ConcatInternal(Patterns.NotCurlyBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is neither left nor right curly bracket from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotCurlyBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches left or right square bracket.
        /// </summary>
        /// <returns></returns>
        public CharGroup SquareBracket()
        {
            return ConcatInternal(Patterns.SquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches left or right square bracket specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup SquareBracket(int exactCount)
        {
            return ConcatInternal(Patterns.SquareBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches left or right square bracket from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup SquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.SquareBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is neither left nor right square bracket.
        /// </summary>
        /// <returns></returns>
        public CharGroup NotSquareBracket()
        {
            return ConcatInternal(Patterns.NotSquareBracket());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is neither left nor right square bracket specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotSquareBracket(int exactCount)
        {
            return ConcatInternal(Patterns.NotSquareBracket(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is neither left nor right square bracket from minimal to maximum times.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotSquareBracket(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches specified content zero or one times.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiedGroup Maybe(object content)
        {
            return ConcatInternal(Patterns.Maybe(content));
        }

        /// <summary>
        /// Appends a pattern that matches any one element of the specified content zero or one times.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiedGroup Maybe(params object[] content)
        {
            return ConcatInternal(Patterns.Maybe(content));
        }

        /// <summary>
        /// Appends a pattern that matches specified content zero or more times.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiedGroup MaybeMany(object content)
        {
            return ConcatInternal(Patterns.MaybeMany(content));
        }

        /// <summary>
        /// Appends a pattern that matches any one element of the specified content zero or more times.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiedGroup MaybeMany(params object[] content)
        {
            return ConcatInternal(Patterns.MaybeMany(content));
        }

        /// <summary>
        /// Appends a pattern that matches specified content one or more times.
        /// </summary>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiedGroup OneMany(object content)
        {
            return ConcatInternal(Patterns.OneMany(content));
        }

        /// <summary>
        /// Appends a pattern that matches any one element of the specified content one or more times.
        /// </summary>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiedGroup OneMany(params object[] content)
        {
            return ConcatInternal(Patterns.OneMany(content));
        }

        /// <summary>
        /// Appends a pattern that matches specified pattern specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times the pattern has to be matched.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Count(int exactCount, object content)
        {
            return ConcatInternal(Patterns.Count(exactCount, content));
        }

        /// <summary>
        /// Appends a pattern that matches any one pattern specified number of times.
        /// </summary>
        /// <param name="exactCount">A number of times the pattern has to be matched.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Count(int exactCount, params object[] content)
        {
            return ConcatInternal(Patterns.Count(exactCount, content));
        }

        /// <summary>
        /// Appends a pattern that matches specified pattern from minimal to maximum number of times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Count(int minCount, int maxCount, object content)
        {
            return ConcatInternal(Patterns.Count(minCount, maxCount, content));
        }

        /// <summary>
        /// Appends a pattern that matches any one pattern from minimal to maximum number of times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup Count(int minCount, int maxCount, params object[] content)
        {
            return ConcatInternal(Patterns.Count(minCount, maxCount, content));
        }

        /// <summary>
        /// Appends a pattern that matches specified pattern at least specified number of times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup CountFrom(int minCount, object content)
        {
            return ConcatInternal(Patterns.CountFrom(minCount, content));
        }

        /// <summary>
        /// Appends a pattern that matches any one pattern at least specified number of times.
        /// </summary>
        /// <param name="minCount">A minimal number of times the pattern must be matched.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup CountFrom(int minCount, params object[] content)
        {
            return ConcatInternal(Patterns.CountFrom(minCount, content));
        }

        /// <summary>
        /// Appends a pattern that matches specified pattern at most specified number of times.
        /// </summary>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <param name="content">The content to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup CountTo(int maxCount, object content)
        {
            return ConcatInternal(Patterns.CountTo(maxCount, content));
        }

        /// <summary>
        /// Appends a pattern that matches any one pattern at most specified number of times.
        /// </summary>
        /// <param name="maxCount">A maximum number of times the pattern can be matched.</param>
        /// <param name="content">An object array that contains zero or more patterns any one of which has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup CountTo(int maxCount, params object[] content)
        {
            return ConcatInternal(Patterns.CountTo(maxCount, content));
        }

        /// <summary>
        /// Appends a pattern that matches previously defined numbered group.
        /// </summary>
        /// <param name="groupNumber">A number of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiablePattern GroupReference(int groupNumber)
        {
            return ConcatInternal(Patterns.GroupReference(groupNumber));
        }

        /// <summary>
        /// Appends a pattern that matches previously defined named group.
        /// </summary>
        /// <param name="groupName">A name of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public QuantifiablePattern GroupReference(string groupName)
        {
            return ConcatInternal(Patterns.GroupReference(groupName));
        }

        /// <summary>
        /// Appends an inline comment.
        /// </summary>
        /// <param name="value">A comment text.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public Pattern Comment(string value)
        {
            return ConcatInternal(Patterns.Comment(value));
        }

        /// <summary>
        /// Appends a pattern that matches a linefeed and an optional carriage return before it. Carriage return will be matched if present and not already consumed by regex engine..
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NewLine()
        {
            return ConcatInternal(Patterns.NewLine());
        }

        /// <summary>
        /// Appends a pattern that matches a newline character. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NewLineChar()
        {
            return ConcatInternal(Patterns.NewLineChar());
        }

        /// <summary>
        /// Appends a pattern that matches a specified number of newline characters. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NewLineChar(int exactCount)
        {
            return ConcatInternal(Patterns.NewLineChar(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a newline character from minimal to maximum times. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NewLineChar(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NewLineChar(minCount, maxCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a newline character. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern NotNewLineChar()
        {
            return ConcatInternal(Patterns.NotNewLineChar());
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a newline character specified number of times. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <param name="exactCount">A number of times a character has to be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotNewLineChar(int exactCount)
        {
            return ConcatInternal(Patterns.NotNewLineChar(exactCount));
        }

        /// <summary>
        /// Appends a pattern that matches a character that is not a newline character from minimal to maximum times. Newline character is a carriage return or a linefeed.
        /// </summary>
        /// <param name="minCount">A minimal number of times a character has to be matched.</param>
        /// <param name="maxCount">A maximum number of times a character can be matched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public QuantifiedGroup NotNewLineChar(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotNewLineChar(minCount, maxCount));
        }

#if DEBUG
        /// <summary>
        /// Appends a pattern that matches zero or more characters that are not a specified character followed with a specified character.
        /// </summary>
        /// <param name="value">The Unicode character.</param>
        /// <returns></returns>
        public QuantifiablePattern GoToChar(char value)
        {
            return ConcatInternal(Patterns.GoToChar(value));
        }

        /// <summary>
        /// Appends a pattern that matches zero or more characters that are not a specified character followed with a specified character.
        /// </summary>
        /// <param name="value">An enumerated constant that identifies ASCII character.</param>
        /// <returns></returns>
        public QuantifiablePattern GoToChar(AsciiChar value)
        {
            return ConcatInternal(Patterns.GoToChar(value));
        }

        /// <summary>
        /// Appends a pattern that matches zero or more characters that are not matched by a specified <see cref="CharGrouping"/> followed with a character that is matched by a specified <see cref="CharGrouping"/>.
        /// </summary>
        /// <param name="value">A content of a character group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public QuantifiablePattern GoToChar(CharGrouping value)
        {
            return ConcatInternal(Patterns.GoToChar(value));
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet lower-case vowel. If the "ignore case" option is applied the pattern will also match upper-case vowel.
        /// </summary>
        /// <returns></returns>
        public CharGroup LatinVowelLower()
        {
            return ConcatInternal(Patterns.LatinVowelLower());
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet upper-case vowel. If the "ignore case" option is applied the pattern will also match lower-case vowel.
        /// </summary>
        /// <returns></returns>
        public CharGroup LatinVowelUpper()
        {
            return ConcatInternal(Patterns.LatinVowelUpper());
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet vowel.
        /// </summary>
        /// <returns></returns>
        public CharGroup LatinVowel()
        {
            return ConcatInternal(Patterns.LatinVowel());
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet lower-case consonant. If the "ignore case" option is applied the pattern will also match upper-case consonant.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern LatinConsonantLower()
        {
            return ConcatInternal(Patterns.LatinConsonantLower());
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet upper-case consonant. If the "ignore case" option is applied the pattern will also match lower-case consonant.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern LatinConsonantUpper()
        {
            return ConcatInternal(Patterns.LatinConsonantUpper());
        }

        /// <summary>
        /// Appends a pattern that matches a latin alphabet consonant.
        /// </summary>
        /// <returns></returns>
        public QuantifiablePattern LatinConsonant()
        {
            return ConcatInternal(Patterns.LatinConsonant());
        }

        /// <summary>
        /// Appends a pattern that matches two apostrophes, optionally allowing zero or more characters that are not an apostrophe between the apostrophes.
        /// </summary>
        /// <param name="allowContent">Indicates whether a content is allowed between the apostrophes.</param>
        /// <returns></returns>
        public Pattern Apostrophes(bool allowContent)
        {
            return ConcatInternal(Patterns.Apostrophes(allowContent));
        }

        /// <summary>
        /// Appends a pattern that matches two quotation marks, optionally allowing zero or more characters that are not a quotation mark between the quotation marks.
        /// </summary>
        /// <param name="allowContent">Indicates whether a content is allowed between the quotation marks.</param>
        /// <returns></returns>
        public Pattern QuoteMarks(bool allowContent)
        {
            return ConcatInternal(Patterns.QuoteMarks(allowContent));
        }

        /// <summary>
        /// Appends a pattern that matches a text consisting of a left parenthesis and a right parenthesis, optionally allowing zero or more characters that are not a right parenthesis between the parentheses.
        /// </summary>
        /// <param name="allowContent">Indicates whether a content is allowed between the parentheses.</param>
        /// <returns></returns>
        public Pattern Parentheses(bool allowContent)
        {
            return ConcatInternal(Patterns.Parentheses(allowContent));
        }

        /// <summary>
        /// Appends a pattern that matches a text consisting of left and right curly bracket, optionally allowing zero or more characters that are not a right curly bracket between the brackets.
        /// </summary>
        /// <param name="allowContent">Indicates whether a content is allowed between the brackets.</param>
        /// <returns></returns>
        public Pattern CurlyBrackets(bool allowContent)
        {
            return ConcatInternal(Patterns.CurlyBrackets(allowContent));
        }

        /// <summary>
        /// Appends a pattern that matches a text consisting of left and right square bracket, optionally allowing zero or more characters that are not a right square bracket between the brackets.
        /// </summary>
        /// <param name="allowContent">Indicates whether a content is allowed between the brackets.</param>
        /// <returns></returns>
        public Pattern SquareBrackets(bool allowContent)
        {
            return ConcatInternal(Patterns.SquareBrackets(allowContent));
        }

        /// <summary>
        /// Appends a pattern that matches a text consisting of left and right angle bracket, optionally allowing zero or more characters that are not a right angle bracket between the brackets.
        /// </summary>
        /// <param name="allowContent">Indicates whether a content is allowed between the brackets.</param>
        /// <returns></returns>
        public Pattern AngleBrackets(bool allowContent)
        {
            return ConcatInternal(Patterns.AngleBrackets(allowContent));
        }
#endif
    }
}
