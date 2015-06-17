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

            return ConcatInternal(Expressions.IfGroup(groupName, Expressions.Never()));
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

            return ConcatInternal(Expressions.IfGroup(groupNumber, Expressions.Never()));
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

            return ConcatInternal(Expressions.IfGroup(groupName, Expression.Empty, Expressions.Never()));
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

            return ConcatInternal(Expressions.IfGroup(groupNumber, Expression.Empty, Expressions.Never()));
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
            return ConcatInternal(Expressions.Any(content));
        }

        public QuantifiableExpression Any(params object[] content)
        {
            return ConcatInternal(Expressions.Any(content));
        }

        public QuantifiableExpression IfGroup(string groupName, object trueContent)
        {
            return ConcatInternal(Expressions.IfGroup(groupName, trueContent));
        }

        public QuantifiableExpression IfGroup(string groupName, object trueContent, object falseContent)
        {
            return ConcatInternal(Expressions.IfGroup(groupName, trueContent, falseContent));
        }

        public QuantifiableExpression IfGroup(int groupNumber, object trueContent)
        {
            return ConcatInternal(Expressions.IfGroup(groupNumber, trueContent));
        }

        public QuantifiableExpression IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            return ConcatInternal(Expressions.IfGroup(groupNumber, trueContent, falseContent));
        }

        public QuantifiableExpression If(Expression testContent, object trueContent)
        {
            return ConcatInternal(Expressions.If(testContent, trueContent));
        }

        public QuantifiableExpression If(Expression testContent, object trueContent, object falseContent)
        {
            return ConcatInternal(Expressions.If(testContent, trueContent, falseContent));
        }

        public Expression Or(object content)
        {
            return Expressions.Or(this, content);
        }

        public QuantifiableExpression Start()
        {
            return ConcatInternal(Anchors.Start());
        }

        public QuantifiableExpression StartOfLine()
        {
            return ConcatInternal(Anchors.StartOfLine());
        }

        public QuantifiableExpression StartOfLineInvariant()
        {
            return ConcatInternal(Anchors.StartOfLineInvariant());
        }

        public QuantifiableExpression End()
        {
            return ConcatInternal(Anchors.End());
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

        public QuantifiableExpression Word()
        {
            return ConcatInternal(Anchors.Word());
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

        public QuantifiableExpression Group()
        {
            return ConcatInternal(Linq.Groups.Group());
        }

        public QuantifiableExpression Group(object content)
        {
            return ConcatInternal(Linq.Groups.Group(content));
        }

        public QuantifiableExpression Group(params object[] content)
        {
            return ConcatInternal(Linq.Groups.Group(content));
        }
        
        public QuantifiableExpression NamedGroup(string name, object content)
        {
            return ConcatInternal(Linq.Groups.NamedGroup(name, content));
        }

        public QuantifiableExpression NamedGroup(string name, params object[] content)
        {
            return ConcatInternal(Linq.Groups.NamedGroup(name, content));
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

        public QuantifiableExpression AsGroup()
        {
            return Linq.Groups.Group(this);
        }

        public QuantifiableExpression AsGroup(string groupName)
        {
            return Linq.Groups.NamedGroup(groupName, this);
        }

        public QuantifiableExpression AsNoncapturing()
        {
            return Linq.Groups.Noncapturing(this);
        }

        public QuantifiableExpression AsNonbacktracking()
        {
            return Linq.Groups.Nonbacktracking(this);
        }

        public Expression Apostrophes()
        {
            return ConcatInternal(Chars.Apostrophes());
        }

        public Expression Apostrophes(object content)
        {
            return ConcatInternal(Chars.Apostrophes(content));
        }

        public Expression QuoteMarks()
        {
            return ConcatInternal(Chars.QuoteMarks());
        }

        public Expression QuoteMarks(object content)
        {
            return ConcatInternal(Chars.QuoteMarks(content));
        }

        public Expression Parentheses()
        {
            return ConcatInternal(Chars.Parentheses());
        }

        public Expression Parentheses(object content)
        {
            return ConcatInternal(Chars.Parentheses(content));
        }

        public Expression CurlyBrackets()
        {
            return ConcatInternal(Chars.CurlyBrackets());
        }

        public Expression CurlyBrackets(object content)
        {
            return ConcatInternal(Chars.CurlyBrackets(content));
        }

        public Expression SquareBrackets()
        {
            return ConcatInternal(Chars.SquareBrackets());
        }

        public Expression SquareBrackets(object content)
        {
            return ConcatInternal(Chars.SquareBrackets(content));
        }

        public Expression LessThanGreaterThan(object content)
        {
            return ConcatInternal(Chars.LessThanGreaterThan(content));
        }

#if DEBUG
        public Expression GoTo(char value)
        {
            return ConcatInternal(Expressions.GoTo(value));
        }

        public Expression GoTo(AsciiChar value)
        {
            return ConcatInternal(Expressions.GoTo(value));
        }
#endif

        public QuantifiableExpression Char(string characters)
        {
            return ConcatInternal(Chars.Char(characters));
        }

        public QuantifiableExpression Char(CharGroupItem item)
        {
            return ConcatInternal(Chars.Char(item));
        }

        public QuantifiableExpression NotChar(string characters)
        {
            return ConcatInternal(Chars.NotChar(characters));
        }

        public QuantifiableExpression NotChar(CharGroupItem item)
        {
            return ConcatInternal(Chars.NotChar(item));
        }

        public QuantifiableExpression Range(char first, char last)
        {
            return ConcatInternal(Chars.Range(first, last));
        }

        public QuantifiableExpression Range(int firstCharCode, int lastCharCode)
        {
            return ConcatInternal(Chars.Range(firstCharCode, lastCharCode));
        }

        public QuantifiableExpression NotRange(char first, char last)
        {
            return ConcatInternal(Chars.NotRange(first, last));
        }

        public QuantifiableExpression NotRange(int firstCharCode, int lastCharCode)
        {
            return ConcatInternal(Chars.NotRange(firstCharCode, lastCharCode));
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

        public Expression While(char value)
        {
            return ConcatInternal(Chars.While(value));
        }

        public Expression While(AsciiChar value)
        {
            return ConcatInternal(Chars.While(value));
        }

        public Expression While(CharGroupItem item)
        {
            return ConcatInternal(Chars.While(item));
        }

        public Expression WhileNot(char value)
        {
            return ConcatInternal(Chars.WhileNot(value));
        }

        public Expression WhileNot(AsciiChar value)
        {
            return ConcatInternal(Chars.WhileNot(value));
        }

        public Expression WhileNot(CharGroupItem item)
        {
            return ConcatInternal(Chars.WhileNot(item));
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

        public QuantifierExpression Digit(int count)
        {
            return ConcatInternal(Chars.Digit(count));
        }

        public QuantifierExpression Digit(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Digit(minCount, maxCount));
        }

        public QuantifierExpression Digits()
        {
            return ConcatInternal(Chars.Digits());
        }

        public QuantifiableExpression NotDigit()
        {
            return ConcatInternal(Chars.NotDigit());
        }

        public QuantifierExpression NotDigit(int count)
        {
            return ConcatInternal(Chars.NotDigit(count));
        }

        public QuantifierExpression NotDigit(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotDigit(minCount, maxCount));
        }

        public QuantifierExpression NotDigits()
        {
            return ConcatInternal(Chars.NotDigits());
        }

        public QuantifiableExpression WhiteSpace()
        {
            return ConcatInternal(Chars.WhiteSpace());
        }

        public QuantifierExpression WhiteSpace(int count)
        {
            return ConcatInternal(Chars.WhiteSpace(count));
        }

        public QuantifierExpression WhiteSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.WhiteSpace(minCount, maxCount));
        }

        public QuantifierExpression WhiteSpaces()
        {
            return ConcatInternal(Chars.WhiteSpaces());
        }

        public QuantifierExpression WhileWhiteSpace()
        {
            return ConcatInternal(Chars.WhileWhiteSpace());
        }

        public QuantifiableExpression NotWhiteSpace()
        {
            return ConcatInternal(Chars.NotWhiteSpace());
        }

        public QuantifierExpression NotWhiteSpace(int count)
        {
            return ConcatInternal(Chars.NotWhiteSpace(count));
        }

        public QuantifierExpression NotWhiteSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotWhiteSpace(minCount, maxCount));
        }

        public QuantifierExpression NotWhiteSpaces()
        {
            return ConcatInternal(Chars.NotWhiteSpaces());
        }

        public QuantifiableExpression WordChar()
        {
            return ConcatInternal(Chars.WordChar());
        }

        public QuantifierExpression WordChar(int count)
        {
            return ConcatInternal(Chars.WordChar(count));
        }

        public QuantifierExpression WordChar(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.WordChar(minCount, maxCount));
        }

        public QuantifierExpression WordChars()
        {
            return ConcatInternal(Chars.WordChars());
        }

        public QuantifiableExpression NotWordChar()
        {
            return ConcatInternal(Chars.NotWordChar());
        }

        public QuantifierExpression NotWordChar(int count)
        {
            return ConcatInternal(Chars.NotWordChar(count));
        }

        public QuantifierExpression NotWordChar(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotWordChar(minCount, maxCount));
        }

        public QuantifierExpression NotWordChars()
        {
            return ConcatInternal(Chars.NotWordChars());
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

        public QuantifiableExpression Char(NamedBlock block)
        {
            return ConcatInternal(Chars.Char(block));
        }

        public QuantifiableExpression Char(GeneralCategory category)
        {
            return ConcatInternal(Chars.Char(category));
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

        public QuantifiableExpression NotChar(NamedBlock block)
        {
            return ConcatInternal(Chars.NotChar(block));
        }

        public QuantifiableExpression NotChar(GeneralCategory category)
        {
            return ConcatInternal(Chars.NotChar(category));
        }

        public QuantifiableExpression Tab()
        {
            return ConcatInternal(Chars.Tab());
        }

        public QuantifierExpression Tab(int exactCount)
        {
            return ConcatInternal(Chars.Tab(exactCount));
        }

        public QuantifierExpression Tab(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Tab(minCount, maxCount));
        }

        public QuantifiableExpression NotTab()
        {
            return ConcatInternal(Chars.NotTab());
        }

        public QuantifierExpression NotTab(int exactCount)
        {
            return ConcatInternal(Chars.NotTab(exactCount));
        }

        public QuantifierExpression NotTab(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotTab(minCount, maxCount));
        }

        public QuantifiableExpression Linefeed()
        {
            return ConcatInternal(Chars.Linefeed());
        }

        public QuantifierExpression Linefeed(int exactCount)
        {
            return ConcatInternal(Chars.Linefeed(exactCount));
        }

        public QuantifierExpression Linefeed(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Linefeed(minCount, maxCount));
        }

        public QuantifiableExpression NotLinefeed()
        {
            return ConcatInternal(Chars.NotLinefeed());
        }

        public QuantifierExpression NotLinefeed(int exactCount)
        {
            return ConcatInternal(Chars.NotLinefeed(exactCount));
        }

        public QuantifierExpression NotLinefeed(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLinefeed(minCount, maxCount));
        }

        public QuantifiableExpression CarriageReturn()
        {
            return ConcatInternal(Chars.CarriageReturn());
        }

        public QuantifierExpression CarriageReturn(int exactCount)
        {
            return ConcatInternal(Chars.CarriageReturn(exactCount));
        }

        public QuantifierExpression CarriageReturn(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.CarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression NotCarriageReturn()
        {
            return ConcatInternal(Chars.NotCarriageReturn());
        }

        public QuantifierExpression NotCarriageReturn(int exactCount)
        {
            return ConcatInternal(Chars.NotCarriageReturn(exactCount));
        }

        public QuantifierExpression NotCarriageReturn(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotCarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression Space()
        {
            return ConcatInternal(Chars.Space());
        }

        public QuantifierExpression Space(int exactCount)
        {
            return ConcatInternal(Chars.Space(exactCount));
        }

        public QuantifierExpression Space(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Space(minCount, maxCount));
        }

        public QuantifiableExpression NotSpace()
        {
            return ConcatInternal(Chars.NotSpace());
        }

        public QuantifierExpression NotSpace(int exactCount)
        {
            return ConcatInternal(Chars.NotSpace(exactCount));
        }

        public QuantifierExpression NotSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotSpace(minCount, maxCount));
        }

        public QuantifiableExpression ExclamationMark()
        {
            return ConcatInternal(Chars.ExclamationMark());
        }

        public QuantifierExpression ExclamationMark(int exactCount)
        {
            return ConcatInternal(Chars.ExclamationMark(exactCount));
        }

        public QuantifierExpression ExclamationMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.ExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotExclamationMark()
        {
            return ConcatInternal(Chars.NotExclamationMark());
        }

        public QuantifierExpression NotExclamationMark(int exactCount)
        {
            return ConcatInternal(Chars.NotExclamationMark(exactCount));
        }

        public QuantifierExpression NotExclamationMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression QuoteMark()
        {
            return ConcatInternal(Chars.QuoteMark());
        }

        public QuantifierExpression QuoteMark(int exactCount)
        {
            return ConcatInternal(Chars.QuoteMark(exactCount));
        }

        public QuantifierExpression QuoteMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.QuoteMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuoteMark()
        {
            return ConcatInternal(Chars.NotQuoteMark());
        }

        public QuantifierExpression NotQuoteMark(int exactCount)
        {
            return ConcatInternal(Chars.NotQuoteMark(exactCount));
        }

        public QuantifierExpression NotQuoteMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotQuoteMark(minCount, maxCount));
        }

        public QuantifiableExpression NumberSign()
        {
            return ConcatInternal(Chars.NumberSign());
        }

        public QuantifierExpression NumberSign(int exactCount)
        {
            return ConcatInternal(Chars.NumberSign(exactCount));
        }

        public QuantifierExpression NumberSign(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NumberSign(minCount, maxCount));
        }

        public QuantifiableExpression NotNumberSign()
        {
            return ConcatInternal(Chars.NotNumberSign());
        }

        public QuantifierExpression NotNumberSign(int exactCount)
        {
            return ConcatInternal(Chars.NotNumberSign(exactCount));
        }

        public QuantifierExpression NotNumberSign(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotNumberSign(minCount, maxCount));
        }

        public QuantifiableExpression Dollar()
        {
            return ConcatInternal(Chars.Dollar());
        }

        public QuantifierExpression Dollar(int exactCount)
        {
            return ConcatInternal(Chars.Dollar(exactCount));
        }

        public QuantifierExpression Dollar(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Dollar(minCount, maxCount));
        }

        public QuantifiableExpression NotDollar()
        {
            return ConcatInternal(Chars.NotDollar());
        }

        public QuantifierExpression NotDollar(int exactCount)
        {
            return ConcatInternal(Chars.NotDollar(exactCount));
        }

        public QuantifierExpression NotDollar(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotDollar(minCount, maxCount));
        }

        public QuantifiableExpression Percent()
        {
            return ConcatInternal(Chars.Percent());
        }

        public QuantifierExpression Percent(int exactCount)
        {
            return ConcatInternal(Chars.Percent(exactCount));
        }

        public QuantifierExpression Percent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Percent(minCount, maxCount));
        }

        public QuantifiableExpression NotPercent()
        {
            return ConcatInternal(Chars.NotPercent());
        }

        public QuantifierExpression NotPercent(int exactCount)
        {
            return ConcatInternal(Chars.NotPercent(exactCount));
        }

        public QuantifierExpression NotPercent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotPercent(minCount, maxCount));
        }

        public QuantifiableExpression Ampersand()
        {
            return ConcatInternal(Chars.Ampersand());
        }

        public QuantifierExpression Ampersand(int exactCount)
        {
            return ConcatInternal(Chars.Ampersand(exactCount));
        }

        public QuantifierExpression Ampersand(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Ampersand(minCount, maxCount));
        }

        public QuantifiableExpression NotAmpersand()
        {
            return ConcatInternal(Chars.NotAmpersand());
        }

        public QuantifierExpression NotAmpersand(int exactCount)
        {
            return ConcatInternal(Chars.NotAmpersand(exactCount));
        }

        public QuantifierExpression NotAmpersand(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotAmpersand(minCount, maxCount));
        }

        public QuantifiableExpression Apostrophe()
        {
            return ConcatInternal(Chars.Apostrophe());
        }

        public QuantifierExpression Apostrophe(int exactCount)
        {
            return ConcatInternal(Chars.Apostrophe(exactCount));
        }

        public QuantifierExpression Apostrophe(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Apostrophe(minCount, maxCount));
        }

        public QuantifiableExpression NotApostrophe()
        {
            return ConcatInternal(Chars.NotApostrophe());
        }

        public QuantifierExpression NotApostrophe(int exactCount)
        {
            return ConcatInternal(Chars.NotApostrophe(exactCount));
        }

        public QuantifierExpression NotApostrophe(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotApostrophe(minCount, maxCount));
        }

        public QuantifiableExpression LeftParenthesis()
        {
            return ConcatInternal(Chars.LeftParenthesis());
        }

        public QuantifierExpression LeftParenthesis(int exactCount)
        {
            return ConcatInternal(Chars.LeftParenthesis(exactCount));
        }

        public QuantifierExpression LeftParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.LeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftParenthesis()
        {
            return ConcatInternal(Chars.NotLeftParenthesis());
        }

        public QuantifierExpression NotLeftParenthesis(int exactCount)
        {
            return ConcatInternal(Chars.NotLeftParenthesis(exactCount));
        }

        public QuantifierExpression NotLeftParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression RightParenthesis()
        {
            return ConcatInternal(Chars.RightParenthesis());
        }

        public QuantifierExpression RightParenthesis(int exactCount)
        {
            return ConcatInternal(Chars.RightParenthesis(exactCount));
        }

        public QuantifierExpression RightParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.RightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotRightParenthesis()
        {
            return ConcatInternal(Chars.NotRightParenthesis());
        }

        public QuantifierExpression NotRightParenthesis(int exactCount)
        {
            return ConcatInternal(Chars.NotRightParenthesis(exactCount));
        }

        public QuantifierExpression NotRightParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotRightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression Asterisk()
        {
            return ConcatInternal(Chars.Asterisk());
        }

        public QuantifierExpression Asterisk(int exactCount)
        {
            return ConcatInternal(Chars.Asterisk(exactCount));
        }

        public QuantifierExpression Asterisk(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Asterisk(minCount, maxCount));
        }

        public QuantifiableExpression NotAsterisk()
        {
            return ConcatInternal(Chars.NotAsterisk());
        }

        public QuantifierExpression NotAsterisk(int exactCount)
        {
            return ConcatInternal(Chars.NotAsterisk(exactCount));
        }

        public QuantifierExpression NotAsterisk(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotAsterisk(minCount, maxCount));
        }

        public QuantifiableExpression Plus()
        {
            return ConcatInternal(Chars.Plus());
        }

        public QuantifierExpression Plus(int exactCount)
        {
            return ConcatInternal(Chars.Plus(exactCount));
        }

        public QuantifierExpression Plus(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Plus(minCount, maxCount));
        }

        public QuantifiableExpression NotPlus()
        {
            return ConcatInternal(Chars.NotPlus());
        }

        public QuantifierExpression NotPlus(int exactCount)
        {
            return ConcatInternal(Chars.NotPlus(exactCount));
        }

        public QuantifierExpression NotPlus(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotPlus(minCount, maxCount));
        }

        public QuantifiableExpression Comma()
        {
            return ConcatInternal(Chars.Comma());
        }

        public QuantifierExpression Comma(int exactCount)
        {
            return ConcatInternal(Chars.Comma(exactCount));
        }

        public QuantifierExpression Comma(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Comma(minCount, maxCount));
        }

        public QuantifiableExpression NotComma()
        {
            return ConcatInternal(Chars.NotComma());
        }

        public QuantifierExpression NotComma(int exactCount)
        {
            return ConcatInternal(Chars.NotComma(exactCount));
        }

        public QuantifierExpression NotComma(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotComma(minCount, maxCount));
        }

        public QuantifiableExpression Hyphen()
        {
            return ConcatInternal(Chars.Hyphen());
        }

        public QuantifierExpression Hyphen(int exactCount)
        {
            return ConcatInternal(Chars.Hyphen(exactCount));
        }

        public QuantifierExpression Hyphen(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Hyphen(minCount, maxCount));
        }

        public QuantifiableExpression NotHyphen()
        {
            return ConcatInternal(Chars.NotHyphen());
        }

        public QuantifierExpression NotHyphen(int exactCount)
        {
            return ConcatInternal(Chars.NotHyphen(exactCount));
        }

        public QuantifierExpression NotHyphen(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotHyphen(minCount, maxCount));
        }

        public QuantifiableExpression Period()
        {
            return ConcatInternal(Chars.Period());
        }

        public QuantifierExpression Period(int exactCount)
        {
            return ConcatInternal(Chars.Period(exactCount));
        }

        public QuantifierExpression Period(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Period(minCount, maxCount));
        }

        public QuantifiableExpression NotPeriod()
        {
            return ConcatInternal(Chars.NotPeriod());
        }

        public QuantifierExpression NotPeriod(int exactCount)
        {
            return ConcatInternal(Chars.NotPeriod(exactCount));
        }

        public QuantifierExpression NotPeriod(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotPeriod(minCount, maxCount));
        }

        public QuantifiableExpression Slash()
        {
            return ConcatInternal(Chars.Slash());
        }

        public QuantifierExpression Slash(int exactCount)
        {
            return ConcatInternal(Chars.Slash(exactCount));
        }

        public QuantifierExpression Slash(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Slash(minCount, maxCount));
        }

        public QuantifiableExpression NotSlash()
        {
            return ConcatInternal(Chars.NotSlash());
        }

        public QuantifierExpression NotSlash(int exactCount)
        {
            return ConcatInternal(Chars.NotSlash(exactCount));
        }

        public QuantifierExpression NotSlash(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotSlash(minCount, maxCount));
        }

        public QuantifiableExpression Colon()
        {
            return ConcatInternal(Chars.Colon());
        }

        public QuantifierExpression Colon(int exactCount)
        {
            return ConcatInternal(Chars.Colon(exactCount));
        }

        public QuantifierExpression Colon(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Colon(minCount, maxCount));
        }

        public QuantifiableExpression NotColon()
        {
            return ConcatInternal(Chars.NotColon());
        }

        public QuantifierExpression NotColon(int exactCount)
        {
            return ConcatInternal(Chars.NotColon(exactCount));
        }

        public QuantifierExpression NotColon(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotColon(minCount, maxCount));
        }

        public QuantifiableExpression Semicolon()
        {
            return ConcatInternal(Chars.Semicolon());
        }

        public QuantifierExpression Semicolon(int exactCount)
        {
            return ConcatInternal(Chars.Semicolon(exactCount));
        }

        public QuantifierExpression Semicolon(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Semicolon(minCount, maxCount));
        }

        public QuantifiableExpression NotSemicolon()
        {
            return ConcatInternal(Chars.NotSemicolon());
        }

        public QuantifierExpression NotSemicolon(int exactCount)
        {
            return ConcatInternal(Chars.NotSemicolon(exactCount));
        }

        public QuantifierExpression NotSemicolon(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotSemicolon(minCount, maxCount));
        }

        public QuantifiableExpression LessThan()
        {
            return ConcatInternal(Chars.LessThan());
        }

        public QuantifierExpression LessThan(int exactCount)
        {
            return ConcatInternal(Chars.LessThan(exactCount));
        }

        public QuantifierExpression LessThan(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.LessThan(minCount, maxCount));
        }

        public QuantifiableExpression NotLessThan()
        {
            return ConcatInternal(Chars.NotLessThan());
        }

        public QuantifierExpression NotLessThan(int exactCount)
        {
            return ConcatInternal(Chars.NotLessThan(exactCount));
        }

        public QuantifierExpression NotLessThan(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLessThan(minCount, maxCount));
        }

        public QuantifiableExpression EqualsSign()
        {
            return ConcatInternal(Chars.EqualsSign());
        }

        public QuantifierExpression EqualsSign(int exactCount)
        {
            return ConcatInternal(Chars.EqualsSign(exactCount));
        }

        public QuantifierExpression EqualsSign(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.EqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression NotEqualsSign()
        {
            return ConcatInternal(Chars.NotEqualsSign());
        }

        public QuantifierExpression NotEqualsSign(int exactCount)
        {
            return ConcatInternal(Chars.NotEqualsSign(exactCount));
        }

        public QuantifierExpression NotEqualsSign(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotEqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression GreaterThan()
        {
            return ConcatInternal(Chars.GreaterThan());
        }

        public QuantifierExpression GreaterThan(int exactCount)
        {
            return ConcatInternal(Chars.GreaterThan(exactCount));
        }

        public QuantifierExpression GreaterThan(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.GreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression NotGreaterThan()
        {
            return ConcatInternal(Chars.NotGreaterThan());
        }

        public QuantifierExpression NotGreaterThan(int exactCount)
        {
            return ConcatInternal(Chars.NotGreaterThan(exactCount));
        }

        public QuantifierExpression NotGreaterThan(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotGreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression QuestionMark()
        {
            return ConcatInternal(Chars.QuestionMark());
        }

        public QuantifierExpression QuestionMark(int exactCount)
        {
            return ConcatInternal(Chars.QuestionMark(exactCount));
        }

        public QuantifierExpression QuestionMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.QuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuestionMark()
        {
            return ConcatInternal(Chars.NotQuestionMark());
        }

        public QuantifierExpression NotQuestionMark(int exactCount)
        {
            return ConcatInternal(Chars.NotQuestionMark(exactCount));
        }

        public QuantifierExpression NotQuestionMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotQuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression At()
        {
            return ConcatInternal(Chars.At());
        }

        public QuantifierExpression At(int exactCount)
        {
            return ConcatInternal(Chars.At(exactCount));
        }

        public QuantifierExpression At(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.At(minCount, maxCount));
        }

        public QuantifiableExpression NotAt()
        {
            return ConcatInternal(Chars.NotAt());
        }

        public QuantifierExpression NotAt(int exactCount)
        {
            return ConcatInternal(Chars.NotAt(exactCount));
        }

        public QuantifierExpression NotAt(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotAt(minCount, maxCount));
        }

        public QuantifiableExpression LeftSquareBracket()
        {
            return ConcatInternal(Chars.LeftSquareBracket());
        }

        public QuantifierExpression LeftSquareBracket(int exactCount)
        {
            return ConcatInternal(Chars.LeftSquareBracket(exactCount));
        }

        public QuantifierExpression LeftSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.LeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftSquareBracket()
        {
            return ConcatInternal(Chars.NotLeftSquareBracket());
        }

        public QuantifierExpression NotLeftSquareBracket(int exactCount)
        {
            return ConcatInternal(Chars.NotLeftSquareBracket(exactCount));
        }

        public QuantifierExpression NotLeftSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression Backslash()
        {
            return ConcatInternal(Chars.Backslash());
        }

        public QuantifierExpression Backslash(int exactCount)
        {
            return ConcatInternal(Chars.Backslash(exactCount));
        }

        public QuantifierExpression Backslash(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Backslash(minCount, maxCount));
        }

        public QuantifiableExpression NotBackslash()
        {
            return ConcatInternal(Chars.NotBackslash());
        }

        public QuantifierExpression NotBackslash(int exactCount)
        {
            return ConcatInternal(Chars.NotBackslash(exactCount));
        }

        public QuantifierExpression NotBackslash(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotBackslash(minCount, maxCount));
        }

        public QuantifiableExpression RightSquareBracket()
        {
            return ConcatInternal(Chars.RightSquareBracket());
        }

        public QuantifierExpression RightSquareBracket(int exactCount)
        {
            return ConcatInternal(Chars.RightSquareBracket(exactCount));
        }

        public QuantifierExpression RightSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.RightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightSquareBracket()
        {
            return ConcatInternal(Chars.NotRightSquareBracket());
        }

        public QuantifierExpression NotRightSquareBracket(int exactCount)
        {
            return ConcatInternal(Chars.NotRightSquareBracket(exactCount));
        }

        public QuantifierExpression NotRightSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotRightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression CircumflexAccent()
        {
            return ConcatInternal(Chars.CircumflexAccent());
        }

        public QuantifierExpression CircumflexAccent(int exactCount)
        {
            return ConcatInternal(Chars.CircumflexAccent(exactCount));
        }

        public QuantifierExpression CircumflexAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.CircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotCircumflexAccent()
        {
            return ConcatInternal(Chars.NotCircumflexAccent());
        }

        public QuantifierExpression NotCircumflexAccent(int exactCount)
        {
            return ConcatInternal(Chars.NotCircumflexAccent(exactCount));
        }

        public QuantifierExpression NotCircumflexAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotCircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression Underscore()
        {
            return ConcatInternal(Chars.Underscore());
        }

        public QuantifierExpression Underscore(int exactCount)
        {
            return ConcatInternal(Chars.Underscore(exactCount));
        }

        public QuantifierExpression Underscore(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Underscore(minCount, maxCount));
        }

        public QuantifiableExpression NotUnderscore()
        {
            return ConcatInternal(Chars.NotUnderscore());
        }

        public QuantifierExpression NotUnderscore(int exactCount)
        {
            return ConcatInternal(Chars.NotUnderscore(exactCount));
        }

        public QuantifierExpression NotUnderscore(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotUnderscore(minCount, maxCount));
        }

        public QuantifiableExpression GraveAccent()
        {
            return ConcatInternal(Chars.GraveAccent());
        }

        public QuantifierExpression GraveAccent(int exactCount)
        {
            return ConcatInternal(Chars.GraveAccent(exactCount));
        }

        public QuantifierExpression GraveAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.GraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotGraveAccent()
        {
            return ConcatInternal(Chars.NotGraveAccent());
        }

        public QuantifierExpression NotGraveAccent(int exactCount)
        {
            return ConcatInternal(Chars.NotGraveAccent(exactCount));
        }

        public QuantifierExpression NotGraveAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotGraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression LeftCurlyBracket()
        {
            return ConcatInternal(Chars.LeftCurlyBracket());
        }

        public QuantifierExpression LeftCurlyBracket(int exactCount)
        {
            return ConcatInternal(Chars.LeftCurlyBracket(exactCount));
        }

        public QuantifierExpression LeftCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.LeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftCurlyBracket()
        {
            return ConcatInternal(Chars.NotLeftCurlyBracket());
        }

        public QuantifierExpression NotLeftCurlyBracket(int exactCount)
        {
            return ConcatInternal(Chars.NotLeftCurlyBracket(exactCount));
        }

        public QuantifierExpression NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression VerticalLine()
        {
            return ConcatInternal(Chars.VerticalLine());
        }

        public QuantifierExpression VerticalLine(int exactCount)
        {
            return ConcatInternal(Chars.VerticalLine(exactCount));
        }

        public QuantifierExpression VerticalLine(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.VerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression NotVerticalLine()
        {
            return ConcatInternal(Chars.NotVerticalLine());
        }

        public QuantifierExpression NotVerticalLine(int exactCount)
        {
            return ConcatInternal(Chars.NotVerticalLine(exactCount));
        }

        public QuantifierExpression NotVerticalLine(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotVerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression RightCurlyBracket()
        {
            return ConcatInternal(Chars.RightCurlyBracket());
        }

        public QuantifierExpression RightCurlyBracket(int exactCount)
        {
            return ConcatInternal(Chars.RightCurlyBracket(exactCount));
        }

        public QuantifierExpression RightCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.RightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightCurlyBracket()
        {
            return ConcatInternal(Chars.NotRightCurlyBracket());
        }

        public QuantifierExpression NotRightCurlyBracket(int exactCount)
        {
            return ConcatInternal(Chars.NotRightCurlyBracket(exactCount));
        }

        public QuantifierExpression NotRightCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotRightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression Tilde()
        {
            return ConcatInternal(Chars.Tilde());
        }

        public QuantifierExpression Tilde(int exactCount)
        {
            return ConcatInternal(Chars.Tilde(exactCount));
        }

        public QuantifierExpression Tilde(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Tilde(minCount, maxCount));
        }

        public QuantifiableExpression NotTilde()
        {
            return ConcatInternal(Chars.NotTilde());
        }

        public QuantifierExpression NotTilde(int exactCount)
        {
            return ConcatInternal(Chars.NotTilde(exactCount));
        }

        public QuantifierExpression NotTilde(int minCount, int maxCount)
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

        public QuantifierExpression Maybe(object content)
        {
            return ConcatInternal(Quantify.Maybe(content));
        }

        public QuantifierExpression Maybe(params object[] content)
        {
            return ConcatInternal(Quantify.Maybe(content));
        }

        public QuantifierExpression MaybeMany(object content)
        {
            return ConcatInternal(Quantify.MaybeMany(content));
        }

        public QuantifierExpression MaybeMany(params object[] content)
        {
            return ConcatInternal(Quantify.MaybeMany(content));
        }

        public QuantifierExpression OneMany(object content)
        {
            return ConcatInternal(Quantify.OneMany(content));
        }

        public QuantifierExpression OneMany(params object[] content)
        {
            return ConcatInternal(Quantify.OneMany(content));
        }

        public QuantifierExpression Count(int exactCount, object content)
        {
            return ConcatInternal(Quantify.Count(exactCount, content));
        }

        public QuantifierExpression Count(int exactCount, params object[] content)
        {
            return ConcatInternal(Quantify.Count(exactCount, content));
        }

        public QuantifierExpression CountFrom(int minCount, object content)
        {
            return ConcatInternal(Quantify.CountFrom(minCount, content));
        }

        public QuantifierExpression CountFrom(int minCount, params object[] content)
        {
            return ConcatInternal(Quantify.CountFrom(minCount, content));
        }

        public QuantifierExpression CountRange(int minCount, int maxCount, object content)
        {
            return ConcatInternal(Quantify.CountRange(minCount, maxCount, content));
        }

        public QuantifierExpression CountRange(int minCount, int maxCount, params object[] content)
        {
            return ConcatInternal(Quantify.CountRange(minCount, maxCount, content));
        }

        public QuantifierExpression CountTo(int maxCount, object content)
        {
            return ConcatInternal(Quantify.CountTo(maxCount, content));
        }

        public QuantifierExpression CountTo(int maxCount, params object[] content)
        {
            return ConcatInternal(Quantify.CountTo(maxCount, content));
        }

        public QuantifiableExpression GroupReference(int groupNumber)
        {
            return ConcatInternal(Expressions.GroupReference(groupNumber));
        }

        public QuantifiableExpression GroupReference(string groupName)
        {
            return ConcatInternal(Expressions.GroupReference(groupName));
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
