// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public partial class Expression
    {
        public QuantifiableExpression DisallowGroup(string groupName)
        {
            RegexUtilities.CheckGroupName(groupName);

            return ConcatInternal(Alternations.IfGroup(groupName, Expressions.Never()));
        }

        public Expression DisallowGroups(params string[] groupNames)
        {
            if (groupNames == null || groupNames.Length == 0)
            {
                return Expression.Empty;
            }

            Expression exp = DisallowGroup(groupNames[0]);

            for (int i = 1; i < groupNames.Length; i++)
            {
                exp = exp.DisallowGroup(groupNames[i]);
            }

            return exp;
        }

        public QuantifiableExpression DisallowGroup(int groupNumber)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            return ConcatInternal(Alternations.IfGroup(groupNumber, Expressions.Never()));
        }

        public Expression DisallowGroups(params int[] groupNumbers)
        {
            if (groupNumbers == null || groupNumbers.Length == 0)
            {
                return Expression.Empty;
            }

            Expression exp = DisallowGroup(groupNumbers[0]);

            for (int i = 1; i < groupNumbers.Length; i++)
            {
                exp = exp.DisallowGroup(groupNumbers[i]);
            }

            return exp;
        }

        public QuantifiableExpression RequireGroup(string groupName)
        {
            RegexUtilities.CheckGroupName(groupName);

            return ConcatInternal(Alternations.IfGroup(groupName, Expression.Empty, Expressions.Never()));
        }

        public Expression RequireGroups(params string[] groupNames)
        {
            if (groupNames == null || groupNames.Length == 0)
            {
                return Expression.Empty;
            }

            Expression exp = RequireGroup(groupNames[0]);

            for (int i = 1; i < groupNames.Length; i++)
            {
                exp = exp.RequireGroup(groupNames[i]);
            }

            return exp;
        }

        public QuantifiableExpression RequireGroup(int groupNumber)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            return ConcatInternal(Alternations.IfGroup(groupNumber, Expression.Empty, Expressions.Never()));
        }

        public Expression RequireGroups(params int[] groupNumbers)
        {
            if (groupNumbers == null || groupNumbers.Length == 0)
            {
                return Expression.Empty;
            }

            Expression exp = RequireGroup(groupNumbers[0]);

            for (int i = 1; i < groupNumbers.Length; i++)
            {
                exp = exp.RequireGroup(groupNumbers[i]);
            }

            return exp;
        }

        public QuantifiableExpression Any(IEnumerable<object> content)
        {
            return ConcatInternal(Alternations.Any(content));
        }

        public QuantifiableExpression Any(params object[] content)
        {
            return ConcatInternal(Alternations.Any(content));
        }

        public QuantifiableExpression IfGroup(string groupName, object trueContent)
        {
            return ConcatInternal(Alternations.IfGroup(groupName, trueContent));
        }

        public QuantifiableExpression IfGroup(string groupName, object trueContent, object falseContent)
        {
            return ConcatInternal(Alternations.IfGroup(groupName, trueContent, falseContent));
        }

        public QuantifiableExpression IfGroup(int groupNumber, object trueContent)
        {
            return ConcatInternal(Alternations.IfGroup(groupNumber, trueContent));
        }

        public QuantifiableExpression IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            return ConcatInternal(Alternations.IfGroup(groupNumber, trueContent, falseContent));
        }

        public QuantifiableExpression If(Expression testContent, object trueContent)
        {
            return ConcatInternal(Alternations.If(testContent, trueContent));
        }

        public QuantifiableExpression If(Expression testContent, object trueContent, object falseContent)
        {
            return ConcatInternal(Alternations.If(testContent, trueContent, falseContent));
        }

        public Expression Or()
        {
            return ConcatInternal(Alternations.Or());
        }

        public Expression Or(object content)
        {
            return Join(Syntax.Or, this, content);
        }

        public QuantifiableExpression StartOfInput()
        {
            return ConcatInternal(Anchors.StartOfInput());
        }

        public QuantifiableExpression StartOfLine()
        {
            return ConcatInternal(Anchors.StartOfLine());
        }

        public QuantifiableExpression StartOfLineInvariant()
        {
            return ConcatInternal(Anchors.StartOfLineInvariant());
        }

        public QuantifiableExpression EndOfInput()
        {
            return ConcatInternal(Anchors.EndOfInput());
        }

        public QuantifiableExpression EndOfLine()
        {
            return ConcatInternal(Anchors.EndOfLine());
        }

        public QuantifiableExpression EndOfLineInvariant()
        {
            return ConcatInternal(Anchors.EndOfLineInvariant());
        }

        public QuantifiableExpression EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true, false);
        }

        public QuantifiableExpression EndOfLineOrBeforeCarriageReturnInvariant()
        {
            return EndOfLine(true, true);
        }

        internal QuantifiableExpression EndOfLine(bool beforeCarriageReturn, bool invariant)
        {
            return ConcatInternal(Anchors.EndOfLine(beforeCarriageReturn, invariant));
        }

        public QuantifiableExpression EndOrBeforeEndingNewLine()
        {
            return ConcatInternal(Anchors.EndOrBeforeEndingNewLine());
        }

        public QuantifiableExpression PreviousMatchEnd()
        {
            return ConcatInternal(Anchors.PreviousMatchEnd());
        }

        public QuantifiableExpression WordBoundary()
        {
            return ConcatInternal(Anchors.WordBoundary());
        }

        public QuantifiableExpression Word(string text)
        {
            return ConcatInternal(Anchors.Word(text));
        }

        public QuantifiableExpression Word(params string[] values)
        {
            return ConcatInternal(Anchors.Word(values));
        }

        public QuantifiableExpression NotWordBoundary()
        {
            return ConcatInternal(Anchors.NotWordBoundary());
        }

        public Expression AsLine()
        {
            return Anchors.Line(this);
        }

        public Expression AsLineInvariant()
        {
            return Anchors.LineInvariant(this);
        }

        public Expression AsEntireInput()
        {
            return Anchors.EntireInput(this);
        }

        public QuantifiableExpression Assert(object content)
        {
            return ConcatInternal(Anchors.Assert(content));
        }

        public QuantifiableExpression Assert(params object[] content)
        {
            return ConcatInternal(Anchors.Assert(content));
        }

        public QuantifiableExpression Assert(CharGroupItem item)
        {
            return ConcatInternal(Anchors.Assert(item));
        }

        public QuantifiableExpression NotAssert(object content)
        {
            return ConcatInternal(Anchors.NotAssert(content));
        }

        public QuantifiableExpression NotAssert(params object[] content)
        {
            return ConcatInternal(Anchors.NotAssert(content));
        }

        public QuantifiableExpression NotAssert(CharGroupItem item)
        {
            return ConcatInternal(Anchors.NotAssert(item));
        }

        public QuantifiableExpression AssertBack(object content)
        {
            return ConcatInternal(Anchors.AssertBack(content));
        }

        public QuantifiableExpression AssertBack(params object[] content)
        {
            return ConcatInternal(Anchors.AssertBack(content));
        }

        public QuantifiableExpression AssertBack(CharGroupItem item)
        {
            return ConcatInternal(Anchors.AssertBack(item));
        }

        public QuantifiableExpression NotAssertBack(object content)
        {
            return ConcatInternal(Anchors.NotAssertBack(content));
        }

        public QuantifiableExpression NotAssertBack(params object[] content)
        {
            return ConcatInternal(Anchors.NotAssertBack(content));
        }

        public QuantifiableExpression NotAssertBack(CharGroupItem item)
        {
            return ConcatInternal(Anchors.NotAssertBack(item));
        }

        public QuantifiableExpression NamedGroup(string name, object content)
        {
            return ConcatInternal(Linq.Groups.NamedGroup(name, content));
        }

        public QuantifiableExpression NamedGroup(string name, params object[] content)
        {
            return ConcatInternal(Linq.Groups.NamedGroup(name, content));
        }

        public QuantifiableExpression Capturing()
        {
            return ConcatInternal(Linq.Groups.Capturing());
        }

        public QuantifiableExpression Capturing(object content)
        {
            return ConcatInternal(Linq.Groups.Capturing(content));
        }

        public QuantifiableExpression Capturing(params object[] content)
        {
            return ConcatInternal(Linq.Groups.Capturing(content));
        }

        public QuantifiableExpression Noncapturing(object content)
        {
            return ConcatInternal(Linq.Groups.Noncapturing(content));
        }

        public QuantifiableExpression Noncapturing(params object[] content)
        {
            return ConcatInternal(Linq.Groups.Noncapturing(content));
        }

        public QuantifiableExpression Nonbacktracking(object content)
        {
            return ConcatInternal(Linq.Groups.Nonbacktracking(content));
        }

        public QuantifiableExpression Nonbacktracking(params object[] content)
        {
            return ConcatInternal(Linq.Groups.Nonbacktracking(content));
        }

        public QuantifiableExpression BalanceGroup(string name1, string name2, object content)
        {
            return ConcatInternal(Linq.Groups.BalanceGroup(name1, name2, content));
        }

        public QuantifiableExpression BalanceGroup(string name1, string name2, params object[] content)
        {
            return ConcatInternal(Linq.Groups.BalanceGroup(name1, name2, content));
        }

        public QuantifiableExpression ApplyOptions(InlineOptions options, object content)
        {
            return Options(options, InlineOptions.None, content);
        }

        public QuantifiableExpression ApplyOptions(InlineOptions options, params object[] content)
        {
            return Options(options, InlineOptions.None, content);
        }

        public QuantifiableExpression DisableOptions(InlineOptions options, object content)
        {
            return Options(InlineOptions.None, options, content);
        }

        public QuantifiableExpression DisableOptions(InlineOptions options, params object[] content)
        {
            return Options(InlineOptions.None, options, content);
        }

        public QuantifiableExpression Options(InlineOptions applyOptions, InlineOptions disableOptions, object content)
        {
            return ConcatInternal(Expressions.Options(applyOptions, disableOptions, content));
        }

        public QuantifiableExpression Options(InlineOptions applyOptions, InlineOptions disableOptions, params object[] content)
        {
            return ConcatInternal(Expressions.Options(applyOptions, disableOptions, content));
        }

        public Expression ApplyOptions(InlineOptions options)
        {
            return Options(options, InlineOptions.None);
        }

        public Expression DisableOptions(InlineOptions options)
        {
            return Options(InlineOptions.None, options);
        }

        public Expression Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return ConcatInternal(Expressions.Options(applyOptions, disableOptions));
        }

        public QuantifiableExpression AsCapturing()
        {
            return Linq.Groups.Capturing(this);
        }

        public QuantifiableExpression AsNoncapturing()
        {
            return Linq.Groups.Noncapturing(this);
        }

        public QuantifiableExpression AsNonbacktracking()
        {
            return Linq.Groups.Nonbacktracking(this);
        }

        public Expression Apostrophes(object content)
        {
            return ConcatInternal(Expressions.Apostrophes(content));
        }

        public Expression QuoteMarks(object content)
        {
            return ConcatInternal(Expressions.QuoteMarks(content));
        }

        public Expression Parentheses()
        {
            return ConcatInternal(Expressions.Parentheses());
        }

        public Expression Parentheses(object content)
        {
            return ConcatInternal(Expressions.Parentheses(content));
        }

        public Expression CurlyBrackets()
        {
            return ConcatInternal(Expressions.CurlyBrackets());
        }

        public Expression CurlyBrackets(object content)
        {
            return ConcatInternal(Expressions.CurlyBrackets(content));
        }

        public Expression SquareBrackets()
        {
            return ConcatInternal(Expressions.SquareBrackets());
        }

        public Expression SquareBrackets(object content)
        {
            return ConcatInternal(Expressions.SquareBrackets(content));
        }

        public Expression LessThanGreaterThan(object content)
        {
            return ConcatInternal(Expressions.LessThanGreaterThan(content));
        }

#if DEBUG
        public Expression GoTo(char value)
        {
            return ConcatInternal(Expressions.GoTo(value));
        }

        public Expression GoTo(int charValue)
        {
            return ConcatInternal(Expressions.GoTo(charValue));
        }

        public Expression GoTo(AsciiChar value)
        {
            return ConcatInternal(Expressions.GoTo(value));
        }
#endif

        public QuantifiableExpression Char(string chars)
        {
            return ConcatInternal(Chars.Char(chars));
        }

        public QuantifiableExpression Char(CharGroupItem item)
        {
            return ConcatInternal(Chars.Char(item));
        }

        public QuantifiableExpression NotChar(string chars)
        {
            return ConcatInternal(Chars.NotChar(chars));
        }

        public QuantifiableExpression NotChar(CharGroupItem item)
        {
            return ConcatInternal(Chars.NotChar(item));
        }

        public QuantifiableExpression CharRange(char first, char last)
        {
            return ConcatInternal(Chars.CharRange(first, last));
        }

        public QuantifiableExpression CharRange(int firstCharCode, int lastCharCode)
        {
            return ConcatInternal(Chars.CharRange(firstCharCode, lastCharCode));
        }

        public QuantifiableExpression NotCharRange(char first, char last)
        {
            return ConcatInternal(Chars.NotCharRange(first, last));
        }

        public QuantifiableExpression NotCharRange(int firstCharCode, int lastCharCode)
        {
            return ConcatInternal(Chars.NotCharRange(firstCharCode, lastCharCode));
        }

        public QuantifiableExpression Subtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return ConcatInternal(Chars.Subtract(baseGroup, excludedGroup));
        }

        public QuantifiableExpression NotSubtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return ConcatInternal(Chars.NotSubtract(baseGroup, excludedGroup));
        }

        public QuantifiableExpression WhiteSpaceExceptNewLine()
        {
            return ConcatInternal(Chars.WhiteSpaceExceptNewLine());
        }

        public CharGroupExpression Alphanumeric()
        {
            return ConcatInternal(Chars.Alphanumeric());
        }

        public CharGroupExpression NotAlphanumeric()
        {
            return ConcatInternal(Chars.NotAlphanumeric());
        }

        public CharGroupExpression AlphanumericLower()
        {
            return ConcatInternal(Chars.AlphanumericLower());
        }

        public CharGroupExpression NotAlphanumericLower()
        {
            return ConcatInternal(Chars.NotAlphanumericLower());
        }

        public CharGroupExpression AlphanumericUpper()
        {
            return ConcatInternal(Chars.AlphanumericUpper());
        }

        public CharGroupExpression NotAlphanumericUpper()
        {
            return ConcatInternal(Chars.NotAlphanumericUpper());
        }

        public CharGroupExpression AlphanumericUnderscore()
        {
            return ConcatInternal(Chars.AlphanumericUnderscore());
        }

        public CharGroupExpression NotAlphanumericUnderscore()
        {
            return ConcatInternal(Chars.NotAlphanumericUnderscore());
        }

        public CharGroupExpression LatinLetter()
        {
            return ConcatInternal(Chars.LatinLetter());
        }

        public CharGroupExpression LatinLetterLower()
        {
            return ConcatInternal(Chars.LatinLetterLower());
        }

        public CharGroupExpression LatinLetterUpper()
        {
            return ConcatInternal(Chars.LatinLetterUpper());
        }

        public CharGroupExpression NotLatinLetter()
        {
            return ConcatInternal(Chars.NotLatinLetter());
        }

        public CharGroupExpression NotLatinLetterLower()
        {
            return ConcatInternal(Chars.NotLatinLetterLower());
        }

        public CharGroupExpression NotLatinLetterUpper()
        {
            return ConcatInternal(Chars.NotLatinLetterUpper());
        }

        public QuantifiableExpression Any()
        {
            return ConcatInternal(Chars.Any());
        }

        public QuantifiableExpression AnyInvariant()
        {
            return ConcatInternal(Chars.AnyInvariant());
        }

        public Expression AnyMaybeManyLazy()
        {
            return ConcatInternal(Chars.AnyMaybeManyLazy());
        }

        public Expression Crawl()
        {
            return ConcatInternal(Expressions.Crawl());
        }

        public Expression CrawlInvariant()
        {
            return ConcatInternal(Expressions.CrawlInvariant());
        }

        public Expression AnyMaybeManyLazyInvariant()
        {
            return ConcatInternal(Chars.AnyMaybeManyLazyInvariant());
        }

        public QuantifiableExpression ArabicDigit()
        {
            return ConcatInternal(Chars.ArabicDigit());
        }

        public QuantifiableExpression NotArabicDigit()
        {
            return ConcatInternal(Chars.NotArabicDigit());
        }

        public QuantifiableExpression HexadecimalDigit()
        {
            return ConcatInternal(Chars.HexadecimalDigit());
        }

        public QuantifiableExpression NotHexadecimalDigit()
        {
            return ConcatInternal(Chars.NotHexadecimalDigit());
        }

        public QuantifiableExpression Digit()
        {
            return ConcatInternal(Chars.Digit());
        }

        public QuantifiedExpression Digit(int count)
        {
            return ConcatInternal(Chars.Digit(count));
        }

        public QuantifiedExpression Digit(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Digit(minCount, maxCount));
        }

        public QuantifiableExpression NotDigit()
        {
            return ConcatInternal(Chars.NotDigit());
        }

        public QuantifiedExpression NotDigit(int count)
        {
            return ConcatInternal(Chars.NotDigit(count));
        }

        public QuantifiedExpression NotDigit(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotDigit(minCount, maxCount));
        }

        public QuantifiableExpression WhiteSpace()
        {
            return ConcatInternal(Chars.WhiteSpace());
        }

        public QuantifiedExpression WhiteSpace(int count)
        {
            return ConcatInternal(Chars.WhiteSpace(count));
        }

        public QuantifiedExpression WhiteSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.WhiteSpace(minCount, maxCount));
        }

        public QuantifiedExpression SkipWhiteSpace()
        {
            return ConcatInternal(Chars.SkipWhiteSpace());
        }

        public QuantifiableExpression NotWhiteSpace()
        {
            return ConcatInternal(Chars.NotWhiteSpace());
        }

        public QuantifiedExpression NotWhiteSpace(int count)
        {
            return ConcatInternal(Chars.NotWhiteSpace(count));
        }

        public QuantifiedExpression NotWhiteSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotWhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression WordChar()
        {
            return ConcatInternal(Chars.WordChar());
        }

        public QuantifiedExpression WordChar(int count)
        {
            return ConcatInternal(Chars.WordChar(count));
        }

        public QuantifiedExpression WordChar(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.WordChar(minCount, maxCount));
        }

        public QuantifiableExpression NotWordChar()
        {
            return ConcatInternal(Chars.NotWordChar());
        }

        public QuantifiedExpression NotWordChar(int count)
        {
            return ConcatInternal(Chars.NotWordChar(count));
        }

        public QuantifiedExpression NotWordChar(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotWordChar(minCount, maxCount));
        }

        public QuantifiableExpression Char(char value)
        {
            return ConcatInternal(Chars.Char(value));
        }

        public QuantifiableExpression Char(int charCode)
        {
            return ConcatInternal(Chars.Char(charCode));
        }

        public QuantifiableExpression Char(AsciiChar value)
        {
            return ConcatInternal(Chars.Char(value));
        }

        public QuantifiableExpression NamedBlock(NamedBlock block)
        {
            return ConcatInternal(Chars.NamedBlock(block));
        }

        public QuantifiableExpression GeneralCategory(GeneralCategory category)
        {
            return ConcatInternal(Chars.GeneralCategory(category));
        }

        public QuantifiableExpression NotChar(char value)
        {
            return ConcatInternal(Chars.NotChar(value));
        }

        public QuantifiableExpression NotChar(int charCode)
        {
            return ConcatInternal(Chars.NotChar(charCode));
        }

        public QuantifiableExpression NotChar(AsciiChar value)
        {
            return ConcatInternal(Chars.NotChar(value));
        }

        public QuantifiableExpression NotNamedBlock(NamedBlock block)
        {
            return ConcatInternal(Chars.NotNamedBlock(block));
        }

        public QuantifiableExpression NotGeneralCategory(GeneralCategory category)
        {
            return ConcatInternal(Chars.NotGeneralCategory(category));
        }

        public QuantifiableExpression Tab()
        {
            return ConcatInternal(Chars.Tab());
        }

        public QuantifiedExpression Tab(int exactCount)
        {
            return ConcatInternal(Chars.Tab(exactCount));
        }

        public QuantifiedExpression Tab(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Tab(minCount, maxCount));
        }

        public QuantifiableExpression NotTab()
        {
            return ConcatInternal(Chars.NotTab());
        }

        public QuantifiedExpression NotTab(int exactCount)
        {
            return ConcatInternal(Chars.NotTab(exactCount));
        }

        public QuantifiedExpression NotTab(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotTab(minCount, maxCount));
        }

        public QuantifiableExpression Linefeed()
        {
            return ConcatInternal(Chars.Linefeed());
        }

        public QuantifiedExpression Linefeed(int exactCount)
        {
            return ConcatInternal(Chars.Linefeed(exactCount));
        }

        public QuantifiedExpression Linefeed(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Linefeed(minCount, maxCount));
        }

        public QuantifiableExpression NotLinefeed()
        {
            return ConcatInternal(Chars.NotLinefeed());
        }

        public QuantifiedExpression NotLinefeed(int exactCount)
        {
            return ConcatInternal(Chars.NotLinefeed(exactCount));
        }

        public QuantifiedExpression NotLinefeed(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLinefeed(minCount, maxCount));
        }

        public QuantifiableExpression CarriageReturn()
        {
            return ConcatInternal(Chars.CarriageReturn());
        }

        public QuantifiedExpression CarriageReturn(int exactCount)
        {
            return ConcatInternal(Chars.CarriageReturn(exactCount));
        }

        public QuantifiedExpression CarriageReturn(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.CarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression NotCarriageReturn()
        {
            return ConcatInternal(Chars.NotCarriageReturn());
        }

        public QuantifiedExpression NotCarriageReturn(int exactCount)
        {
            return ConcatInternal(Chars.NotCarriageReturn(exactCount));
        }

        public QuantifiedExpression NotCarriageReturn(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotCarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression Space()
        {
            return ConcatInternal(Chars.Space());
        }

        public QuantifiedExpression Space(int exactCount)
        {
            return ConcatInternal(Chars.Space(exactCount));
        }

        public QuantifiedExpression Space(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Space(minCount, maxCount));
        }

        public QuantifiableExpression NotSpace()
        {
            return ConcatInternal(Chars.NotSpace());
        }

        public QuantifiedExpression NotSpace(int exactCount)
        {
            return ConcatInternal(Chars.NotSpace(exactCount));
        }

        public QuantifiedExpression NotSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotSpace(minCount, maxCount));
        }

        public QuantifiableExpression ExclamationMark()
        {
            return ConcatInternal(Chars.ExclamationMark());
        }

        public QuantifiedExpression ExclamationMark(int exactCount)
        {
            return ConcatInternal(Chars.ExclamationMark(exactCount));
        }

        public QuantifiedExpression ExclamationMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.ExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotExclamationMark()
        {
            return ConcatInternal(Chars.NotExclamationMark());
        }

        public QuantifiedExpression NotExclamationMark(int exactCount)
        {
            return ConcatInternal(Chars.NotExclamationMark(exactCount));
        }

        public QuantifiedExpression NotExclamationMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression QuoteMark()
        {
            return ConcatInternal(Chars.QuoteMark());
        }

        public QuantifiedExpression QuoteMark(int exactCount)
        {
            return ConcatInternal(Chars.QuoteMark(exactCount));
        }

        public QuantifiedExpression QuoteMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.QuoteMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuoteMark()
        {
            return ConcatInternal(Chars.NotQuoteMark());
        }

        public QuantifiedExpression NotQuoteMark(int exactCount)
        {
            return ConcatInternal(Chars.NotQuoteMark(exactCount));
        }

        public QuantifiedExpression NotQuoteMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotQuoteMark(minCount, maxCount));
        }

        public QuantifiableExpression NumberSign()
        {
            return ConcatInternal(Chars.NumberSign());
        }

        public QuantifiedExpression NumberSign(int exactCount)
        {
            return ConcatInternal(Chars.NumberSign(exactCount));
        }

        public QuantifiedExpression NumberSign(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NumberSign(minCount, maxCount));
        }

        public QuantifiableExpression NotNumberSign()
        {
            return ConcatInternal(Chars.NotNumberSign());
        }

        public QuantifiedExpression NotNumberSign(int exactCount)
        {
            return ConcatInternal(Chars.NotNumberSign(exactCount));
        }

        public QuantifiedExpression NotNumberSign(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotNumberSign(minCount, maxCount));
        }

        public QuantifiableExpression Dollar()
        {
            return ConcatInternal(Chars.Dollar());
        }

        public QuantifiedExpression Dollar(int exactCount)
        {
            return ConcatInternal(Chars.Dollar(exactCount));
        }

        public QuantifiedExpression Dollar(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Dollar(minCount, maxCount));
        }

        public QuantifiableExpression NotDollar()
        {
            return ConcatInternal(Chars.NotDollar());
        }

        public QuantifiedExpression NotDollar(int exactCount)
        {
            return ConcatInternal(Chars.NotDollar(exactCount));
        }

        public QuantifiedExpression NotDollar(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotDollar(minCount, maxCount));
        }

        public QuantifiableExpression Percent()
        {
            return ConcatInternal(Chars.Percent());
        }

        public QuantifiedExpression Percent(int exactCount)
        {
            return ConcatInternal(Chars.Percent(exactCount));
        }

        public QuantifiedExpression Percent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Percent(minCount, maxCount));
        }

        public QuantifiableExpression NotPercent()
        {
            return ConcatInternal(Chars.NotPercent());
        }

        public QuantifiedExpression NotPercent(int exactCount)
        {
            return ConcatInternal(Chars.NotPercent(exactCount));
        }

        public QuantifiedExpression NotPercent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotPercent(minCount, maxCount));
        }

        public QuantifiableExpression Ampersand()
        {
            return ConcatInternal(Chars.Ampersand());
        }

        public QuantifiedExpression Ampersand(int exactCount)
        {
            return ConcatInternal(Chars.Ampersand(exactCount));
        }

        public QuantifiedExpression Ampersand(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Ampersand(minCount, maxCount));
        }

        public QuantifiableExpression NotAmpersand()
        {
            return ConcatInternal(Chars.NotAmpersand());
        }

        public QuantifiedExpression NotAmpersand(int exactCount)
        {
            return ConcatInternal(Chars.NotAmpersand(exactCount));
        }

        public QuantifiedExpression NotAmpersand(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotAmpersand(minCount, maxCount));
        }

        public QuantifiableExpression Apostrophe()
        {
            return ConcatInternal(Chars.Apostrophe());
        }

        public QuantifiedExpression Apostrophe(int exactCount)
        {
            return ConcatInternal(Chars.Apostrophe(exactCount));
        }

        public QuantifiedExpression Apostrophe(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Apostrophe(minCount, maxCount));
        }

        public QuantifiableExpression NotApostrophe()
        {
            return ConcatInternal(Chars.NotApostrophe());
        }

        public QuantifiedExpression NotApostrophe(int exactCount)
        {
            return ConcatInternal(Chars.NotApostrophe(exactCount));
        }

        public QuantifiedExpression NotApostrophe(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotApostrophe(minCount, maxCount));
        }

        public QuantifiableExpression LeftParenthesis()
        {
            return ConcatInternal(Chars.LeftParenthesis());
        }

        public QuantifiedExpression LeftParenthesis(int exactCount)
        {
            return ConcatInternal(Chars.LeftParenthesis(exactCount));
        }

        public QuantifiedExpression LeftParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.LeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftParenthesis()
        {
            return ConcatInternal(Chars.NotLeftParenthesis());
        }

        public QuantifiedExpression NotLeftParenthesis(int exactCount)
        {
            return ConcatInternal(Chars.NotLeftParenthesis(exactCount));
        }

        public QuantifiedExpression NotLeftParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression RightParenthesis()
        {
            return ConcatInternal(Chars.RightParenthesis());
        }

        public QuantifiedExpression RightParenthesis(int exactCount)
        {
            return ConcatInternal(Chars.RightParenthesis(exactCount));
        }

        public QuantifiedExpression RightParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.RightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotRightParenthesis()
        {
            return ConcatInternal(Chars.NotRightParenthesis());
        }

        public QuantifiedExpression NotRightParenthesis(int exactCount)
        {
            return ConcatInternal(Chars.NotRightParenthesis(exactCount));
        }

        public QuantifiedExpression NotRightParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotRightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression Asterisk()
        {
            return ConcatInternal(Chars.Asterisk());
        }

        public QuantifiedExpression Asterisk(int exactCount)
        {
            return ConcatInternal(Chars.Asterisk(exactCount));
        }

        public QuantifiedExpression Asterisk(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Asterisk(minCount, maxCount));
        }

        public QuantifiableExpression NotAsterisk()
        {
            return ConcatInternal(Chars.NotAsterisk());
        }

        public QuantifiedExpression NotAsterisk(int exactCount)
        {
            return ConcatInternal(Chars.NotAsterisk(exactCount));
        }

        public QuantifiedExpression NotAsterisk(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotAsterisk(minCount, maxCount));
        }

        public QuantifiableExpression Plus()
        {
            return ConcatInternal(Chars.Plus());
        }

        public QuantifiedExpression Plus(int exactCount)
        {
            return ConcatInternal(Chars.Plus(exactCount));
        }

        public QuantifiedExpression Plus(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Plus(minCount, maxCount));
        }

        public QuantifiableExpression NotPlus()
        {
            return ConcatInternal(Chars.NotPlus());
        }

        public QuantifiedExpression NotPlus(int exactCount)
        {
            return ConcatInternal(Chars.NotPlus(exactCount));
        }

        public QuantifiedExpression NotPlus(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotPlus(minCount, maxCount));
        }

        public QuantifiableExpression Comma()
        {
            return ConcatInternal(Chars.Comma());
        }

        public QuantifiedExpression Comma(int exactCount)
        {
            return ConcatInternal(Chars.Comma(exactCount));
        }

        public QuantifiedExpression Comma(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Comma(minCount, maxCount));
        }

        public QuantifiableExpression NotComma()
        {
            return ConcatInternal(Chars.NotComma());
        }

        public QuantifiedExpression NotComma(int exactCount)
        {
            return ConcatInternal(Chars.NotComma(exactCount));
        }

        public QuantifiedExpression NotComma(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotComma(minCount, maxCount));
        }

        public QuantifiableExpression Hyphen()
        {
            return ConcatInternal(Chars.Hyphen());
        }

        public QuantifiedExpression Hyphen(int exactCount)
        {
            return ConcatInternal(Chars.Hyphen(exactCount));
        }

        public QuantifiedExpression Hyphen(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Hyphen(minCount, maxCount));
        }

        public QuantifiableExpression NotHyphen()
        {
            return ConcatInternal(Chars.NotHyphen());
        }

        public QuantifiedExpression NotHyphen(int exactCount)
        {
            return ConcatInternal(Chars.NotHyphen(exactCount));
        }

        public QuantifiedExpression NotHyphen(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotHyphen(minCount, maxCount));
        }

        public QuantifiableExpression Period()
        {
            return ConcatInternal(Chars.Period());
        }

        public QuantifiedExpression Period(int exactCount)
        {
            return ConcatInternal(Chars.Period(exactCount));
        }

        public QuantifiedExpression Period(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Period(minCount, maxCount));
        }

        public QuantifiableExpression NotPeriod()
        {
            return ConcatInternal(Chars.NotPeriod());
        }

        public QuantifiedExpression NotPeriod(int exactCount)
        {
            return ConcatInternal(Chars.NotPeriod(exactCount));
        }

        public QuantifiedExpression NotPeriod(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotPeriod(minCount, maxCount));
        }

        public QuantifiableExpression Slash()
        {
            return ConcatInternal(Chars.Slash());
        }

        public QuantifiedExpression Slash(int exactCount)
        {
            return ConcatInternal(Chars.Slash(exactCount));
        }

        public QuantifiedExpression Slash(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Slash(minCount, maxCount));
        }

        public QuantifiableExpression NotSlash()
        {
            return ConcatInternal(Chars.NotSlash());
        }

        public QuantifiedExpression NotSlash(int exactCount)
        {
            return ConcatInternal(Chars.NotSlash(exactCount));
        }

        public QuantifiedExpression NotSlash(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotSlash(minCount, maxCount));
        }

        public QuantifiableExpression Colon()
        {
            return ConcatInternal(Chars.Colon());
        }

        public QuantifiedExpression Colon(int exactCount)
        {
            return ConcatInternal(Chars.Colon(exactCount));
        }

        public QuantifiedExpression Colon(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Colon(minCount, maxCount));
        }

        public QuantifiableExpression NotColon()
        {
            return ConcatInternal(Chars.NotColon());
        }

        public QuantifiedExpression NotColon(int exactCount)
        {
            return ConcatInternal(Chars.NotColon(exactCount));
        }

        public QuantifiedExpression NotColon(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotColon(minCount, maxCount));
        }

        public QuantifiableExpression Semicolon()
        {
            return ConcatInternal(Chars.Semicolon());
        }

        public QuantifiedExpression Semicolon(int exactCount)
        {
            return ConcatInternal(Chars.Semicolon(exactCount));
        }

        public QuantifiedExpression Semicolon(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Semicolon(minCount, maxCount));
        }

        public QuantifiableExpression NotSemicolon()
        {
            return ConcatInternal(Chars.NotSemicolon());
        }

        public QuantifiedExpression NotSemicolon(int exactCount)
        {
            return ConcatInternal(Chars.NotSemicolon(exactCount));
        }

        public QuantifiedExpression NotSemicolon(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotSemicolon(minCount, maxCount));
        }

        public QuantifiableExpression LessThan()
        {
            return ConcatInternal(Chars.LessThan());
        }

        public QuantifiedExpression LessThan(int exactCount)
        {
            return ConcatInternal(Chars.LessThan(exactCount));
        }

        public QuantifiedExpression LessThan(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.LessThan(minCount, maxCount));
        }

        public QuantifiableExpression NotLessThan()
        {
            return ConcatInternal(Chars.NotLessThan());
        }

        public QuantifiedExpression NotLessThan(int exactCount)
        {
            return ConcatInternal(Chars.NotLessThan(exactCount));
        }

        public QuantifiedExpression NotLessThan(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLessThan(minCount, maxCount));
        }

        public QuantifiableExpression EqualsSign()
        {
            return ConcatInternal(Chars.EqualsSign());
        }

        public QuantifiedExpression EqualsSign(int exactCount)
        {
            return ConcatInternal(Chars.EqualsSign(exactCount));
        }

        public QuantifiedExpression EqualsSign(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.EqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression NotEqualsSign()
        {
            return ConcatInternal(Chars.NotEqualsSign());
        }

        public QuantifiedExpression NotEqualsSign(int exactCount)
        {
            return ConcatInternal(Chars.NotEqualsSign(exactCount));
        }

        public QuantifiedExpression NotEqualsSign(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotEqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression GreaterThan()
        {
            return ConcatInternal(Chars.GreaterThan());
        }

        public QuantifiedExpression GreaterThan(int exactCount)
        {
            return ConcatInternal(Chars.GreaterThan(exactCount));
        }

        public QuantifiedExpression GreaterThan(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.GreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression NotGreaterThan()
        {
            return ConcatInternal(Chars.NotGreaterThan());
        }

        public QuantifiedExpression NotGreaterThan(int exactCount)
        {
            return ConcatInternal(Chars.NotGreaterThan(exactCount));
        }

        public QuantifiedExpression NotGreaterThan(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotGreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression QuestionMark()
        {
            return ConcatInternal(Chars.QuestionMark());
        }

        public QuantifiedExpression QuestionMark(int exactCount)
        {
            return ConcatInternal(Chars.QuestionMark(exactCount));
        }

        public QuantifiedExpression QuestionMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.QuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuestionMark()
        {
            return ConcatInternal(Chars.NotQuestionMark());
        }

        public QuantifiedExpression NotQuestionMark(int exactCount)
        {
            return ConcatInternal(Chars.NotQuestionMark(exactCount));
        }

        public QuantifiedExpression NotQuestionMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotQuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression At()
        {
            return ConcatInternal(Chars.At());
        }

        public QuantifiedExpression At(int exactCount)
        {
            return ConcatInternal(Chars.At(exactCount));
        }

        public QuantifiedExpression At(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.At(minCount, maxCount));
        }

        public QuantifiableExpression NotAt()
        {
            return ConcatInternal(Chars.NotAt());
        }

        public QuantifiedExpression NotAt(int exactCount)
        {
            return ConcatInternal(Chars.NotAt(exactCount));
        }

        public QuantifiedExpression NotAt(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotAt(minCount, maxCount));
        }

        public QuantifiableExpression LeftSquareBracket()
        {
            return ConcatInternal(Chars.LeftSquareBracket());
        }

        public QuantifiedExpression LeftSquareBracket(int exactCount)
        {
            return ConcatInternal(Chars.LeftSquareBracket(exactCount));
        }

        public QuantifiedExpression LeftSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.LeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftSquareBracket()
        {
            return ConcatInternal(Chars.NotLeftSquareBracket());
        }

        public QuantifiedExpression NotLeftSquareBracket(int exactCount)
        {
            return ConcatInternal(Chars.NotLeftSquareBracket(exactCount));
        }

        public QuantifiedExpression NotLeftSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression Backslash()
        {
            return ConcatInternal(Chars.Backslash());
        }

        public QuantifiedExpression Backslash(int exactCount)
        {
            return ConcatInternal(Chars.Backslash(exactCount));
        }

        public QuantifiedExpression Backslash(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Backslash(minCount, maxCount));
        }

        public QuantifiableExpression NotBackslash()
        {
            return ConcatInternal(Chars.NotBackslash());
        }

        public QuantifiedExpression NotBackslash(int exactCount)
        {
            return ConcatInternal(Chars.NotBackslash(exactCount));
        }

        public QuantifiedExpression NotBackslash(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotBackslash(minCount, maxCount));
        }

        public QuantifiableExpression RightSquareBracket()
        {
            return ConcatInternal(Chars.RightSquareBracket());
        }

        public QuantifiedExpression RightSquareBracket(int exactCount)
        {
            return ConcatInternal(Chars.RightSquareBracket(exactCount));
        }

        public QuantifiedExpression RightSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.RightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightSquareBracket()
        {
            return ConcatInternal(Chars.NotRightSquareBracket());
        }

        public QuantifiedExpression NotRightSquareBracket(int exactCount)
        {
            return ConcatInternal(Chars.NotRightSquareBracket(exactCount));
        }

        public QuantifiedExpression NotRightSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotRightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression CircumflexAccent()
        {
            return ConcatInternal(Chars.CircumflexAccent());
        }

        public QuantifiedExpression CircumflexAccent(int exactCount)
        {
            return ConcatInternal(Chars.CircumflexAccent(exactCount));
        }

        public QuantifiedExpression CircumflexAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.CircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotCircumflexAccent()
        {
            return ConcatInternal(Chars.NotCircumflexAccent());
        }

        public QuantifiedExpression NotCircumflexAccent(int exactCount)
        {
            return ConcatInternal(Chars.NotCircumflexAccent(exactCount));
        }

        public QuantifiedExpression NotCircumflexAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotCircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression Underscore()
        {
            return ConcatInternal(Chars.Underscore());
        }

        public QuantifiedExpression Underscore(int exactCount)
        {
            return ConcatInternal(Chars.Underscore(exactCount));
        }

        public QuantifiedExpression Underscore(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Underscore(minCount, maxCount));
        }

        public QuantifiableExpression NotUnderscore()
        {
            return ConcatInternal(Chars.NotUnderscore());
        }

        public QuantifiedExpression NotUnderscore(int exactCount)
        {
            return ConcatInternal(Chars.NotUnderscore(exactCount));
        }

        public QuantifiedExpression NotUnderscore(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotUnderscore(minCount, maxCount));
        }

        public QuantifiableExpression GraveAccent()
        {
            return ConcatInternal(Chars.GraveAccent());
        }

        public QuantifiedExpression GraveAccent(int exactCount)
        {
            return ConcatInternal(Chars.GraveAccent(exactCount));
        }

        public QuantifiedExpression GraveAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.GraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotGraveAccent()
        {
            return ConcatInternal(Chars.NotGraveAccent());
        }

        public QuantifiedExpression NotGraveAccent(int exactCount)
        {
            return ConcatInternal(Chars.NotGraveAccent(exactCount));
        }

        public QuantifiedExpression NotGraveAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotGraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression LeftCurlyBracket()
        {
            return ConcatInternal(Chars.LeftCurlyBracket());
        }

        public QuantifiedExpression LeftCurlyBracket(int exactCount)
        {
            return ConcatInternal(Chars.LeftCurlyBracket(exactCount));
        }

        public QuantifiedExpression LeftCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.LeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftCurlyBracket()
        {
            return ConcatInternal(Chars.NotLeftCurlyBracket());
        }

        public QuantifiedExpression NotLeftCurlyBracket(int exactCount)
        {
            return ConcatInternal(Chars.NotLeftCurlyBracket(exactCount));
        }

        public QuantifiedExpression NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression VerticalLine()
        {
            return ConcatInternal(Chars.VerticalLine());
        }

        public QuantifiedExpression VerticalLine(int exactCount)
        {
            return ConcatInternal(Chars.VerticalLine(exactCount));
        }

        public QuantifiedExpression VerticalLine(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.VerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression NotVerticalLine()
        {
            return ConcatInternal(Chars.NotVerticalLine());
        }

        public QuantifiedExpression NotVerticalLine(int exactCount)
        {
            return ConcatInternal(Chars.NotVerticalLine(exactCount));
        }

        public QuantifiedExpression NotVerticalLine(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotVerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression RightCurlyBracket()
        {
            return ConcatInternal(Chars.RightCurlyBracket());
        }

        public QuantifiedExpression RightCurlyBracket(int exactCount)
        {
            return ConcatInternal(Chars.RightCurlyBracket(exactCount));
        }

        public QuantifiedExpression RightCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.RightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightCurlyBracket()
        {
            return ConcatInternal(Chars.NotRightCurlyBracket());
        }

        public QuantifiedExpression NotRightCurlyBracket(int exactCount)
        {
            return ConcatInternal(Chars.NotRightCurlyBracket(exactCount));
        }

        public QuantifiedExpression NotRightCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotRightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression Tilde()
        {
            return ConcatInternal(Chars.Tilde());
        }

        public QuantifiedExpression Tilde(int exactCount)
        {
            return ConcatInternal(Chars.Tilde(exactCount));
        }

        public QuantifiedExpression Tilde(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Tilde(minCount, maxCount));
        }

        public QuantifiableExpression NotTilde()
        {
            return ConcatInternal(Chars.NotTilde());
        }

        public QuantifiedExpression NotTilde(int exactCount)
        {
            return ConcatInternal(Chars.NotTilde(exactCount));
        }

        public QuantifiedExpression NotTilde(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotTilde(minCount, maxCount));
        }

        public CharGroupExpression Parenthesis()
        {
            return ConcatInternal(Chars.Parenthesis());
        }

        public CharGroupExpression NotParenthesis()
        {
            return ConcatInternal(Chars.NotParenthesis());
        }

        public CharGroupExpression CurlyBracket()
        {
            return ConcatInternal(Chars.CurlyBracket());
        }

        public CharGroupExpression NotCurlyBracket()
        {
            return ConcatInternal(Chars.NotCurlyBracket());
        }

        public CharGroupExpression SquareBracket()
        {
            return ConcatInternal(Chars.SquareBracket());
        }

        public CharGroupExpression NotSquareBracket()
        {
            return ConcatInternal(Chars.NotSquareBracket());
        }

        public QuantifiedExpression Maybe(object content)
        {
            return ConcatInternal(Linq.Groups.Maybe(content));
        }

        public QuantifiedExpression Maybe(params object[] content)
        {
            return ConcatInternal(Linq.Groups.Maybe(content));
        }

        public QuantifiedExpression MaybeMany(object content)
        {
            return ConcatInternal(Linq.Groups.MaybeMany(content));
        }

        public QuantifiedExpression MaybeMany(params object[] content)
        {
            return ConcatInternal(Linq.Groups.MaybeMany(content));
        }

        public QuantifiedExpression OneMany(object content)
        {
            return ConcatInternal(Linq.Groups.OneMany(content));
        }

        public QuantifiedExpression OneMany(params object[] content)
        {
            return ConcatInternal(Linq.Groups.OneMany(content));
        }

        public QuantifiableExpression Backreference(int groupNumber)
        {
            return ConcatInternal(Expressions.Backreference(groupNumber));
        }

        public QuantifiableExpression Backreference(string groupName)
        {
            return ConcatInternal(Expressions.Backreference(groupName));
        }

        public Expression Comment(string value)
        {
            return ConcatInternal(Expressions.Comment(value));
        }

        public QuantifiableExpression NewLine()
        {
            return ConcatInternal(Expressions.NewLine());
        }

        public QuantifiableExpression NewLineChar()
        {
            return ConcatInternal(Chars.NewLineChar());
        }

        public QuantifiableExpression NotNewLineChar()
        {
            return ConcatInternal(Chars.NotNewLineChar());
        }
    }
}
