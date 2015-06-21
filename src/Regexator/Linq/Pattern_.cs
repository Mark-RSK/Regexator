// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public partial class Pattern
    {
        public QuantifiablePattern DisallowGroup(string groupName)
        {
            RegexUtilities.CheckGroupName(groupName);

            return ConcatInternal(new IfGroup(groupName, Patterns.Never()));
        }

        public Pattern DisallowGroups(params string[] groupNames)
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

        public QuantifiablePattern DisallowGroup(int groupNumber)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            return ConcatInternal(new IfGroup(groupNumber, Patterns.Never()));
        }

        public Pattern DisallowGroups(params int[] groupNumbers)
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

        public QuantifiablePattern RequireGroup(string groupName)
        {
            RegexUtilities.CheckGroupName(groupName);

            return ConcatInternal(new IfGroup(groupName, Pattern.Empty, Patterns.Never()));
        }

        public Pattern RequireGroups(params string[] groupNames)
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

        public QuantifiablePattern RequireGroup(int groupNumber)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            return ConcatInternal(new IfGroup(groupNumber, Pattern.Empty, Patterns.Never()));
        }

        public Pattern RequireGroups(params int[] groupNumbers)
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

        public QuantifiablePattern Any(IEnumerable<object> content)
        {
            return ConcatInternal(new AnyGroup(content));
        }

        public QuantifiablePattern Any(params object[] content)
        {
            return ConcatInternal(new AnyGroup(content));
        }

        public QuantifiablePattern IfGroup(string groupName, object trueContent)
        {
            return ConcatInternal(new IfGroup(groupName, trueContent));
        }

        public QuantifiablePattern IfGroup(string groupName, object trueContent, object falseContent)
        {
            return ConcatInternal(new IfGroup(groupName, trueContent, falseContent));
        }

        public QuantifiablePattern IfGroup(int groupNumber, object trueContent)
        {
            return ConcatInternal(new IfGroup(groupNumber, trueContent));
        }

        public QuantifiablePattern IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            return ConcatInternal(new IfGroup(groupNumber, trueContent, falseContent));
        }

        public QuantifiablePattern IfAssert(Pattern testContent, object trueContent)
        {
            return ConcatInternal(new IfAssert(testContent, trueContent));
        }

        public QuantifiablePattern IfAssert(Pattern testContent, object trueContent, object falseContent)
        {
            return ConcatInternal(new IfAssert(testContent, trueContent, falseContent));
        }

        public Pattern Or(object content)
        {
            return Patterns.Or(this, content);
        }

        public QuantifiablePattern StartOfInput()
        {
            return ConcatInternal(new StartOfInput());
        }

        public QuantifiablePattern StartOfLine()
        {
            return ConcatInternal(new StartOfLine());
        }

        public QuantifiablePattern StartOfLineInvariant()
        {
            return ConcatInternal(new StartOfLineInvariant());
        }

        public QuantifiablePattern EndOfInput()
        {
            return ConcatInternal(new EndOfInput());
        }

        public QuantifiablePattern EndOfLine()
        {
            return ConcatInternal(new EndOfLine());
        }

        public QuantifiablePattern EndOfLineInvariant()
        {
            return ConcatInternal(new EndOfLineInvariant());
        }

        public Pattern EndOfLineOrBeforeCarriageReturn()
        {
            return ConcatInternal(new EndOfLineOrBeforeCarriageReturn());
        }

        public Pattern EndOfLineOrBeforeCarriageReturnInvariant()
        {
            return ConcatInternal(new EndOfLineOrBeforeCarriageReturnInvariant());
        }

        public QuantifiablePattern EndOrBeforeEndingNewLine()
        {
            return ConcatInternal(new EndOrBeforeEndingNewLine());
        }

        public QuantifiablePattern PreviousMatchEnd()
        {
            return ConcatInternal(new PreviousMatchEnd());
        }

        public QuantifiablePattern WordBoundary()
        {
            return ConcatInternal(new WordBoundary());
        }

        public QuantifiablePattern Word()
        {
            return ConcatInternal(new Word());
        }

        public QuantifiablePattern Word(string text)
        {
            return ConcatInternal(new Word(text));
        }

        public QuantifiablePattern Word(params string[] values)
        {
            return ConcatInternal(new Word(values));
        }

        public QuantifiablePattern NotWordBoundary()
        {
            return ConcatInternal(new NotWordBoundary());
        }

        public Pattern AsLine()
        {
            return Patterns.Line(this);
        }

        public Pattern AsLineInvariant()
        {
            return Patterns.LineInvariant(this);
        }

        public Pattern AsEntireInput()
        {
            return Patterns.EntireInput(this);
        }

        public QuantifiablePattern Assert(object content)
        {
            return ConcatInternal(new Assert(content));
        }

        public QuantifiablePattern Assert(params object[] content)
        {
            return ConcatInternal(new Assert(content));
        }

        public QuantifiablePattern Assert(CharGroupItem item)
        {
            return ConcatInternal(new Assert(item));
        }

        public QuantifiablePattern NotAssert(object content)
        {
            return ConcatInternal(new NotAssert(content));
        }

        public QuantifiablePattern NotAssert(params object[] content)
        {
            return ConcatInternal(new NotAssert(content));
        }

        public QuantifiablePattern NotAssert(CharGroupItem item)
        {
            return ConcatInternal(new NotAssert(item));
        }

        public QuantifiablePattern AssertBack(object content)
        {
            return ConcatInternal(new AssertBack(content));
        }

        public QuantifiablePattern AssertBack(params object[] content)
        {
            return ConcatInternal(new AssertBack(content));
        }

        public QuantifiablePattern AssertBack(CharGroupItem item)
        {
            return ConcatInternal(new AssertBack(item));
        }

        public QuantifiablePattern NotAssertBack(object content)
        {
            return ConcatInternal(new NotAssertBack(content));
        }

        public QuantifiablePattern NotAssertBack(params object[] content)
        {
            return ConcatInternal(new NotAssertBack(content));
        }

        public QuantifiablePattern NotAssertBack(CharGroupItem item)
        {
            return ConcatInternal(new NotAssertBack(item));
        }

        public QuantifiablePattern Group()
        {
            return ConcatInternal(new CapturingGroup());
        }

        public QuantifiablePattern Group(object content)
        {
            return ConcatInternal(new CapturingGroup(content));
        }

        public QuantifiablePattern Group(params object[] content)
        {
            return ConcatInternal(new CapturingGroup(content));
        }

        public QuantifiablePattern NamedGroup(string name, object content)
        {
            return ConcatInternal(new NamedGroup(name, content));
        }

        public QuantifiablePattern NamedGroup(string name, params object[] content)
        {
            return ConcatInternal(new NamedGroup(name, content));
        }

        public QuantifiablePattern Noncapturing(object content)
        {
            return ConcatInternal(new NoncapturingGroup(content));
        }

        public QuantifiablePattern Noncapturing(params object[] content)
        {
            return ConcatInternal(new NoncapturingGroup(content));
        }

        public QuantifiablePattern Nonbacktracking(object content)
        {
            return ConcatInternal(new NonbacktrackingGroup(content));
        }

        public QuantifiablePattern Nonbacktracking(params object[] content)
        {
            return ConcatInternal(new NonbacktrackingGroup(content));
        }

        public QuantifiablePattern BalanceGroup(string name1, string name2, object content)
        {
            return ConcatInternal(new BalanceGroup(name1, name2, content));
        }

        public QuantifiablePattern BalanceGroup(string name1, string name2, params object[] content)
        {
            return ConcatInternal(new BalanceGroup(name1, name2, content));
        }

        public Pattern Options(InlineOptions applyOptions)
        {
            return ConcatInternal(Patterns.Options(applyOptions));
        }

        public QuantifiablePattern Options(InlineOptions applyOptions, object content)
        {
            return ConcatInternal(Patterns.Options(applyOptions, content));
        }

        public QuantifiablePattern Options(InlineOptions applyOptions, params object[] content)
        {
            return ConcatInternal(Patterns.Options(applyOptions, content));
        }

        public Pattern Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return ConcatInternal(Patterns.Options(applyOptions, disableOptions));
        }

        public QuantifiablePattern Options(InlineOptions applyOptions, InlineOptions disableOptions, object content)
        {
            return ConcatInternal(Patterns.Options(applyOptions, disableOptions, content));
        }

        public QuantifiablePattern Options(InlineOptions applyOptions, InlineOptions disableOptions, params object[] content)
        {
            return ConcatInternal(Patterns.Options(applyOptions, disableOptions, content));
        }

        public Pattern DisableOptions(InlineOptions options)
        {
            return ConcatInternal(Patterns.DisableOptions(options));
        }

        public QuantifiablePattern DisableOptions(InlineOptions options, object content)
        {
            return ConcatInternal(Patterns.DisableOptions(options, content));
        }

        public QuantifiablePattern DisableOptions(InlineOptions options, params object[] content)
        {
            return ConcatInternal(Patterns.DisableOptions(options, content));
        }

        public QuantifiablePattern AsGroup()
        {
            return new CapturingGroup(this);
        }

        public QuantifiablePattern AsGroup(string groupName)
        {
            return new NamedGroup(groupName, this);
        }

        internal QuantifiablePattern AsNoncapturing()
        {
            return new NoncapturingGroup(this);
        }

        public QuantifiablePattern AsNonbacktracking()
        {
            return new NonbacktrackingGroup(this);
        }

        public Pattern Apostrophes()
        {
            return ConcatInternal(Chars.Apostrophes());
        }

        public Pattern Apostrophes(object content)
        {
            return ConcatInternal(Chars.Apostrophes(content));
        }

        public Pattern QuoteMarks()
        {
            return ConcatInternal(Chars.QuoteMarks());
        }

        public Pattern QuoteMarks(object content)
        {
            return ConcatInternal(Chars.QuoteMarks(content));
        }

        public Pattern Parentheses()
        {
            return ConcatInternal(Chars.Parentheses());
        }

        public Pattern Parentheses(object content)
        {
            return ConcatInternal(Chars.Parentheses(content));
        }

        public Pattern CurlyBrackets()
        {
            return ConcatInternal(Chars.CurlyBrackets());
        }

        public Pattern CurlyBrackets(object content)
        {
            return ConcatInternal(Chars.CurlyBrackets(content));
        }

        public Pattern SquareBrackets()
        {
            return ConcatInternal(Chars.SquareBrackets());
        }

        public Pattern SquareBrackets(object content)
        {
            return ConcatInternal(Chars.SquareBrackets(content));
        }

        public Pattern LessThanGreaterThan(object content)
        {
            return ConcatInternal(Chars.LessThanGreaterThan(content));
        }

#if DEBUG
        public Pattern GoTo(char value)
        {
            return ConcatInternal(Chars.GoTo(value));
        }

        public Pattern GoTo(AsciiChar value)
        {
            return ConcatInternal(Chars.GoTo(value));
        }
#endif

        public QuantifiablePattern Char(string characters)
        {
            return ConcatInternal(Chars.Char(characters));
        }

        public QuantifiablePattern Char(CharGroupItem item)
        {
            return ConcatInternal(Chars.Char(item));
        }

        public QuantifiablePattern NotChar(string characters)
        {
            return ConcatInternal(Chars.NotChar(characters));
        }

        public QuantifiablePattern NotChar(CharGroupItem item)
        {
            return ConcatInternal(Chars.NotChar(item));
        }

        public QuantifiablePattern Range(char first, char last)
        {
            return ConcatInternal(Chars.Range(first, last));
        }

        public QuantifiablePattern Range(int firstCharCode, int lastCharCode)
        {
            return ConcatInternal(Chars.Range(firstCharCode, lastCharCode));
        }

        public QuantifiablePattern NotRange(char first, char last)
        {
            return ConcatInternal(Chars.NotRange(first, last));
        }

        public QuantifiablePattern NotRange(int firstCharCode, int lastCharCode)
        {
            return ConcatInternal(Chars.NotRange(firstCharCode, lastCharCode));
        }

        public QuantifiablePattern Subtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return ConcatInternal(Chars.Subtract(baseGroup, excludedGroup));
        }

        public QuantifiablePattern NotSubtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return ConcatInternal(Chars.NotSubtract(baseGroup, excludedGroup));
        }

        public QuantifiablePattern WhiteSpaceExceptNewLine()
        {
            return ConcatInternal(Chars.WhiteSpaceExceptNewLine());
        }

        public Pattern While(char value)
        {
            return ConcatInternal(Chars.While(value));
        }

        public Pattern While(AsciiChar value)
        {
            return ConcatInternal(Chars.While(value));
        }

        public Pattern While(CharGroupItem item)
        {
            return ConcatInternal(Chars.While(item));
        }

        public Pattern WhileNot(char value)
        {
            return ConcatInternal(Chars.WhileNot(value));
        }

        public Pattern WhileNot(AsciiChar value)
        {
            return ConcatInternal(Chars.WhileNot(value));
        }

        public Pattern WhileNot(CharGroupItem item)
        {
            return ConcatInternal(Chars.WhileNot(item));
        }

        public Pattern WhileNotNewLine()
        {
            return ConcatInternal(Chars.WhileNotNewLine());
        }

        public CharGroup Alphanumeric()
        {
            return ConcatInternal(Chars.Alphanumeric());
        }

        public CharGroup NotAlphanumeric()
        {
            return ConcatInternal(Chars.NotAlphanumeric());
        }

        public CharGroup AlphanumericLower()
        {
            return ConcatInternal(Chars.AlphanumericLower());
        }

        public CharGroup NotAlphanumericLower()
        {
            return ConcatInternal(Chars.NotAlphanumericLower());
        }

        public CharGroup AlphanumericUpper()
        {
            return ConcatInternal(Chars.AlphanumericUpper());
        }

        public CharGroup NotAlphanumericUpper()
        {
            return ConcatInternal(Chars.NotAlphanumericUpper());
        }

        public CharGroup AlphanumericUnderscore()
        {
            return ConcatInternal(Chars.AlphanumericUnderscore());
        }

        public CharGroup NotAlphanumericUnderscore()
        {
            return ConcatInternal(Chars.NotAlphanumericUnderscore());
        }

        public CharGroup LatinLetter()
        {
            return ConcatInternal(Chars.LatinLetter());
        }

        public CharGroup LatinLetterLower()
        {
            return ConcatInternal(Chars.LatinLetterLower());
        }

        public CharGroup LatinLetterUpper()
        {
            return ConcatInternal(Chars.LatinLetterUpper());
        }

        public CharGroup NotLatinLetter()
        {
            return ConcatInternal(Chars.NotLatinLetter());
        }

        public CharGroup NotLatinLetterLower()
        {
            return ConcatInternal(Chars.NotLatinLetterLower());
        }

        public CharGroup NotLatinLetterUpper()
        {
            return ConcatInternal(Chars.NotLatinLetterUpper());
        }

        public QuantifiablePattern Any()
        {
            return ConcatInternal(Chars.Any());
        }

        public QuantifiablePattern AnyInvariant()
        {
            return ConcatInternal(Chars.AnyInvariant());
        }

        public Pattern Crawl()
        {
            return ConcatInternal(Patterns.Crawl());
        }

        public Pattern CrawlInvariant()
        {
            return ConcatInternal(Patterns.CrawlInvariant());
        }

        public QuantifiablePattern ArabicDigit()
        {
            return ConcatInternal(Chars.ArabicDigit());
        }

        public QuantifiablePattern NotArabicDigit()
        {
            return ConcatInternal(Chars.NotArabicDigit());
        }

        public QuantifiablePattern HexadecimalDigit()
        {
            return ConcatInternal(Chars.HexadecimalDigit());
        }

        public QuantifiablePattern NotHexadecimalDigit()
        {
            return ConcatInternal(Chars.NotHexadecimalDigit());
        }

        public QuantifiablePattern Digit()
        {
            return ConcatInternal(Chars.Digit());
        }

        public QuantifierGroup Digit(int count)
        {
            return ConcatInternal(Chars.Digit(count));
        }

        public QuantifierGroup Digit(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Digit(minCount, maxCount));
        }

        public QuantifierGroup Digits()
        {
            return ConcatInternal(Chars.Digits());
        }

        public QuantifiablePattern NotDigit()
        {
            return ConcatInternal(Chars.NotDigit());
        }

        public QuantifierGroup NotDigit(int count)
        {
            return ConcatInternal(Chars.NotDigit(count));
        }

        public QuantifierGroup NotDigit(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotDigit(minCount, maxCount));
        }

        public QuantifierGroup NotDigits()
        {
            return ConcatInternal(Chars.NotDigits());
        }

        public QuantifiablePattern WhiteSpace()
        {
            return ConcatInternal(Chars.WhiteSpace());
        }

        public QuantifierGroup WhiteSpace(int count)
        {
            return ConcatInternal(Chars.WhiteSpace(count));
        }

        public QuantifierGroup WhiteSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.WhiteSpace(minCount, maxCount));
        }

        public QuantifierGroup WhiteSpaces()
        {
            return ConcatInternal(Chars.WhiteSpaces());
        }

        public QuantifierGroup WhileWhiteSpace()
        {
            return ConcatInternal(Chars.WhileWhiteSpace());
        }

        public QuantifiablePattern NotWhiteSpace()
        {
            return ConcatInternal(Chars.NotWhiteSpace());
        }

        public QuantifierGroup NotWhiteSpace(int count)
        {
            return ConcatInternal(Chars.NotWhiteSpace(count));
        }

        public QuantifierGroup NotWhiteSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotWhiteSpace(minCount, maxCount));
        }

        public QuantifierGroup NotWhiteSpaces()
        {
            return ConcatInternal(Chars.NotWhiteSpaces());
        }

        public QuantifiablePattern WordChar()
        {
            return ConcatInternal(Chars.WordChar());
        }

        public QuantifierGroup WordChar(int count)
        {
            return ConcatInternal(Chars.WordChar(count));
        }

        public QuantifierGroup WordChar(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.WordChar(minCount, maxCount));
        }

        public QuantifierGroup WordChars()
        {
            return ConcatInternal(Chars.WordChars());
        }

        public QuantifiablePattern NotWordChar()
        {
            return ConcatInternal(Chars.NotWordChar());
        }

        public QuantifierGroup NotWordChar(int count)
        {
            return ConcatInternal(Chars.NotWordChar(count));
        }

        public QuantifierGroup NotWordChar(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotWordChar(minCount, maxCount));
        }

        public QuantifierGroup NotWordChars()
        {
            return ConcatInternal(Chars.NotWordChars());
        }

        public QuantifiablePattern Char(char value)
        {
            return ConcatInternal(Chars.Char(value));
        }

        public QuantifiablePattern Char(int charCode)
        {
            return ConcatInternal(Chars.Char(charCode));
        }

        public QuantifiablePattern Char(AsciiChar value)
        {
            return ConcatInternal(Chars.Char(value));
        }

        public QuantifiablePattern Char(NamedBlock block)
        {
            return ConcatInternal(Chars.Char(block));
        }

        public QuantifiablePattern Char(GeneralCategory category)
        {
            return ConcatInternal(Chars.Char(category));
        }

        public QuantifiablePattern NotChar(char value)
        {
            return ConcatInternal(Chars.NotChar(value));
        }

        public QuantifiablePattern NotChar(int charCode)
        {
            return ConcatInternal(Chars.NotChar(charCode));
        }

        public QuantifiablePattern NotChar(AsciiChar value)
        {
            return ConcatInternal(Chars.NotChar(value));
        }

        public QuantifiablePattern NotChar(NamedBlock block)
        {
            return ConcatInternal(Chars.NotChar(block));
        }

        public QuantifiablePattern NotChar(GeneralCategory category)
        {
            return ConcatInternal(Chars.NotChar(category));
        }

        public QuantifiablePattern Tab()
        {
            return ConcatInternal(Chars.Tab());
        }

        public QuantifierGroup Tab(int exactCount)
        {
            return ConcatInternal(Chars.Tab(exactCount));
        }

        public QuantifierGroup Tab(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Tab(minCount, maxCount));
        }

        public QuantifiablePattern NotTab()
        {
            return ConcatInternal(Chars.NotTab());
        }

        public QuantifierGroup NotTab(int exactCount)
        {
            return ConcatInternal(Chars.NotTab(exactCount));
        }

        public QuantifierGroup NotTab(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotTab(minCount, maxCount));
        }

        public QuantifiablePattern Linefeed()
        {
            return ConcatInternal(Chars.Linefeed());
        }

        public QuantifierGroup Linefeed(int exactCount)
        {
            return ConcatInternal(Chars.Linefeed(exactCount));
        }

        public QuantifierGroup Linefeed(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Linefeed(minCount, maxCount));
        }

        public QuantifiablePattern NotLinefeed()
        {
            return ConcatInternal(Chars.NotLinefeed());
        }

        public QuantifierGroup NotLinefeed(int exactCount)
        {
            return ConcatInternal(Chars.NotLinefeed(exactCount));
        }

        public QuantifierGroup NotLinefeed(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLinefeed(minCount, maxCount));
        }

        public QuantifiablePattern CarriageReturn()
        {
            return ConcatInternal(Chars.CarriageReturn());
        }

        public QuantifierGroup CarriageReturn(int exactCount)
        {
            return ConcatInternal(Chars.CarriageReturn(exactCount));
        }

        public QuantifierGroup CarriageReturn(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.CarriageReturn(minCount, maxCount));
        }

        public QuantifiablePattern NotCarriageReturn()
        {
            return ConcatInternal(Chars.NotCarriageReturn());
        }

        public QuantifierGroup NotCarriageReturn(int exactCount)
        {
            return ConcatInternal(Chars.NotCarriageReturn(exactCount));
        }

        public QuantifierGroup NotCarriageReturn(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotCarriageReturn(minCount, maxCount));
        }

        public QuantifiablePattern Space()
        {
            return ConcatInternal(Chars.Space());
        }

        public QuantifierGroup Space(int exactCount)
        {
            return ConcatInternal(Chars.Space(exactCount));
        }

        public QuantifierGroup Space(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Space(minCount, maxCount));
        }

        public QuantifiablePattern NotSpace()
        {
            return ConcatInternal(Chars.NotSpace());
        }

        public QuantifierGroup NotSpace(int exactCount)
        {
            return ConcatInternal(Chars.NotSpace(exactCount));
        }

        public QuantifierGroup NotSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotSpace(minCount, maxCount));
        }

        public QuantifiablePattern ExclamationMark()
        {
            return ConcatInternal(Chars.ExclamationMark());
        }

        public QuantifierGroup ExclamationMark(int exactCount)
        {
            return ConcatInternal(Chars.ExclamationMark(exactCount));
        }

        public QuantifierGroup ExclamationMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.ExclamationMark(minCount, maxCount));
        }

        public QuantifiablePattern NotExclamationMark()
        {
            return ConcatInternal(Chars.NotExclamationMark());
        }

        public QuantifierGroup NotExclamationMark(int exactCount)
        {
            return ConcatInternal(Chars.NotExclamationMark(exactCount));
        }

        public QuantifierGroup NotExclamationMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotExclamationMark(minCount, maxCount));
        }

        public QuantifiablePattern QuoteMark()
        {
            return ConcatInternal(Chars.QuoteMark());
        }

        public QuantifierGroup QuoteMark(int exactCount)
        {
            return ConcatInternal(Chars.QuoteMark(exactCount));
        }

        public QuantifierGroup QuoteMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.QuoteMark(minCount, maxCount));
        }

        public QuantifiablePattern NotQuoteMark()
        {
            return ConcatInternal(Chars.NotQuoteMark());
        }

        public QuantifierGroup NotQuoteMark(int exactCount)
        {
            return ConcatInternal(Chars.NotQuoteMark(exactCount));
        }

        public QuantifierGroup NotQuoteMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotQuoteMark(minCount, maxCount));
        }

        public QuantifiablePattern NumberSign()
        {
            return ConcatInternal(Chars.NumberSign());
        }

        public QuantifierGroup NumberSign(int exactCount)
        {
            return ConcatInternal(Chars.NumberSign(exactCount));
        }

        public QuantifierGroup NumberSign(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NumberSign(minCount, maxCount));
        }

        public QuantifiablePattern NotNumberSign()
        {
            return ConcatInternal(Chars.NotNumberSign());
        }

        public QuantifierGroup NotNumberSign(int exactCount)
        {
            return ConcatInternal(Chars.NotNumberSign(exactCount));
        }

        public QuantifierGroup NotNumberSign(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotNumberSign(minCount, maxCount));
        }

        public QuantifiablePattern Dollar()
        {
            return ConcatInternal(Chars.Dollar());
        }

        public QuantifierGroup Dollar(int exactCount)
        {
            return ConcatInternal(Chars.Dollar(exactCount));
        }

        public QuantifierGroup Dollar(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Dollar(minCount, maxCount));
        }

        public QuantifiablePattern NotDollar()
        {
            return ConcatInternal(Chars.NotDollar());
        }

        public QuantifierGroup NotDollar(int exactCount)
        {
            return ConcatInternal(Chars.NotDollar(exactCount));
        }

        public QuantifierGroup NotDollar(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotDollar(minCount, maxCount));
        }

        public QuantifiablePattern Percent()
        {
            return ConcatInternal(Chars.Percent());
        }

        public QuantifierGroup Percent(int exactCount)
        {
            return ConcatInternal(Chars.Percent(exactCount));
        }

        public QuantifierGroup Percent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Percent(minCount, maxCount));
        }

        public QuantifiablePattern NotPercent()
        {
            return ConcatInternal(Chars.NotPercent());
        }

        public QuantifierGroup NotPercent(int exactCount)
        {
            return ConcatInternal(Chars.NotPercent(exactCount));
        }

        public QuantifierGroup NotPercent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotPercent(minCount, maxCount));
        }

        public QuantifiablePattern Ampersand()
        {
            return ConcatInternal(Chars.Ampersand());
        }

        public QuantifierGroup Ampersand(int exactCount)
        {
            return ConcatInternal(Chars.Ampersand(exactCount));
        }

        public QuantifierGroup Ampersand(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Ampersand(minCount, maxCount));
        }

        public QuantifiablePattern NotAmpersand()
        {
            return ConcatInternal(Chars.NotAmpersand());
        }

        public QuantifierGroup NotAmpersand(int exactCount)
        {
            return ConcatInternal(Chars.NotAmpersand(exactCount));
        }

        public QuantifierGroup NotAmpersand(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotAmpersand(minCount, maxCount));
        }

        public QuantifiablePattern Apostrophe()
        {
            return ConcatInternal(Chars.Apostrophe());
        }

        public QuantifierGroup Apostrophe(int exactCount)
        {
            return ConcatInternal(Chars.Apostrophe(exactCount));
        }

        public QuantifierGroup Apostrophe(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Apostrophe(minCount, maxCount));
        }

        public QuantifiablePattern NotApostrophe()
        {
            return ConcatInternal(Chars.NotApostrophe());
        }

        public QuantifierGroup NotApostrophe(int exactCount)
        {
            return ConcatInternal(Chars.NotApostrophe(exactCount));
        }

        public QuantifierGroup NotApostrophe(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotApostrophe(minCount, maxCount));
        }

        public QuantifiablePattern LeftParenthesis()
        {
            return ConcatInternal(Chars.LeftParenthesis());
        }

        public QuantifierGroup LeftParenthesis(int exactCount)
        {
            return ConcatInternal(Chars.LeftParenthesis(exactCount));
        }

        public QuantifierGroup LeftParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.LeftParenthesis(minCount, maxCount));
        }

        public QuantifiablePattern NotLeftParenthesis()
        {
            return ConcatInternal(Chars.NotLeftParenthesis());
        }

        public QuantifierGroup NotLeftParenthesis(int exactCount)
        {
            return ConcatInternal(Chars.NotLeftParenthesis(exactCount));
        }

        public QuantifierGroup NotLeftParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLeftParenthesis(minCount, maxCount));
        }

        public QuantifiablePattern RightParenthesis()
        {
            return ConcatInternal(Chars.RightParenthesis());
        }

        public QuantifierGroup RightParenthesis(int exactCount)
        {
            return ConcatInternal(Chars.RightParenthesis(exactCount));
        }

        public QuantifierGroup RightParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.RightParenthesis(minCount, maxCount));
        }

        public QuantifiablePattern NotRightParenthesis()
        {
            return ConcatInternal(Chars.NotRightParenthesis());
        }

        public QuantifierGroup NotRightParenthesis(int exactCount)
        {
            return ConcatInternal(Chars.NotRightParenthesis(exactCount));
        }

        public QuantifierGroup NotRightParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotRightParenthesis(minCount, maxCount));
        }

        public QuantifiablePattern Asterisk()
        {
            return ConcatInternal(Chars.Asterisk());
        }

        public QuantifierGroup Asterisk(int exactCount)
        {
            return ConcatInternal(Chars.Asterisk(exactCount));
        }

        public QuantifierGroup Asterisk(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Asterisk(minCount, maxCount));
        }

        public QuantifiablePattern NotAsterisk()
        {
            return ConcatInternal(Chars.NotAsterisk());
        }

        public QuantifierGroup NotAsterisk(int exactCount)
        {
            return ConcatInternal(Chars.NotAsterisk(exactCount));
        }

        public QuantifierGroup NotAsterisk(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotAsterisk(minCount, maxCount));
        }

        public QuantifiablePattern Plus()
        {
            return ConcatInternal(Chars.Plus());
        }

        public QuantifierGroup Plus(int exactCount)
        {
            return ConcatInternal(Chars.Plus(exactCount));
        }

        public QuantifierGroup Plus(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Plus(minCount, maxCount));
        }

        public QuantifiablePattern NotPlus()
        {
            return ConcatInternal(Chars.NotPlus());
        }

        public QuantifierGroup NotPlus(int exactCount)
        {
            return ConcatInternal(Chars.NotPlus(exactCount));
        }

        public QuantifierGroup NotPlus(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotPlus(minCount, maxCount));
        }

        public QuantifiablePattern Comma()
        {
            return ConcatInternal(Chars.Comma());
        }

        public QuantifierGroup Comma(int exactCount)
        {
            return ConcatInternal(Chars.Comma(exactCount));
        }

        public QuantifierGroup Comma(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Comma(minCount, maxCount));
        }

        public QuantifiablePattern NotComma()
        {
            return ConcatInternal(Chars.NotComma());
        }

        public QuantifierGroup NotComma(int exactCount)
        {
            return ConcatInternal(Chars.NotComma(exactCount));
        }

        public QuantifierGroup NotComma(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotComma(minCount, maxCount));
        }

        public QuantifiablePattern Hyphen()
        {
            return ConcatInternal(Chars.Hyphen());
        }

        public QuantifierGroup Hyphen(int exactCount)
        {
            return ConcatInternal(Chars.Hyphen(exactCount));
        }

        public QuantifierGroup Hyphen(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Hyphen(minCount, maxCount));
        }

        public QuantifiablePattern NotHyphen()
        {
            return ConcatInternal(Chars.NotHyphen());
        }

        public QuantifierGroup NotHyphen(int exactCount)
        {
            return ConcatInternal(Chars.NotHyphen(exactCount));
        }

        public QuantifierGroup NotHyphen(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotHyphen(minCount, maxCount));
        }

        public QuantifiablePattern Period()
        {
            return ConcatInternal(Chars.Period());
        }

        public QuantifierGroup Period(int exactCount)
        {
            return ConcatInternal(Chars.Period(exactCount));
        }

        public QuantifierGroup Period(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Period(minCount, maxCount));
        }

        public QuantifiablePattern NotPeriod()
        {
            return ConcatInternal(Chars.NotPeriod());
        }

        public QuantifierGroup NotPeriod(int exactCount)
        {
            return ConcatInternal(Chars.NotPeriod(exactCount));
        }

        public QuantifierGroup NotPeriod(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotPeriod(minCount, maxCount));
        }

        public QuantifiablePattern Slash()
        {
            return ConcatInternal(Chars.Slash());
        }

        public QuantifierGroup Slash(int exactCount)
        {
            return ConcatInternal(Chars.Slash(exactCount));
        }

        public QuantifierGroup Slash(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Slash(minCount, maxCount));
        }

        public QuantifiablePattern NotSlash()
        {
            return ConcatInternal(Chars.NotSlash());
        }

        public QuantifierGroup NotSlash(int exactCount)
        {
            return ConcatInternal(Chars.NotSlash(exactCount));
        }

        public QuantifierGroup NotSlash(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotSlash(minCount, maxCount));
        }

        public QuantifiablePattern Colon()
        {
            return ConcatInternal(Chars.Colon());
        }

        public QuantifierGroup Colon(int exactCount)
        {
            return ConcatInternal(Chars.Colon(exactCount));
        }

        public QuantifierGroup Colon(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Colon(minCount, maxCount));
        }

        public QuantifiablePattern NotColon()
        {
            return ConcatInternal(Chars.NotColon());
        }

        public QuantifierGroup NotColon(int exactCount)
        {
            return ConcatInternal(Chars.NotColon(exactCount));
        }

        public QuantifierGroup NotColon(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotColon(minCount, maxCount));
        }

        public QuantifiablePattern Semicolon()
        {
            return ConcatInternal(Chars.Semicolon());
        }

        public QuantifierGroup Semicolon(int exactCount)
        {
            return ConcatInternal(Chars.Semicolon(exactCount));
        }

        public QuantifierGroup Semicolon(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Semicolon(minCount, maxCount));
        }

        public QuantifiablePattern NotSemicolon()
        {
            return ConcatInternal(Chars.NotSemicolon());
        }

        public QuantifierGroup NotSemicolon(int exactCount)
        {
            return ConcatInternal(Chars.NotSemicolon(exactCount));
        }

        public QuantifierGroup NotSemicolon(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotSemicolon(minCount, maxCount));
        }

        public QuantifiablePattern LessThan()
        {
            return ConcatInternal(Chars.LessThan());
        }

        public QuantifierGroup LessThan(int exactCount)
        {
            return ConcatInternal(Chars.LessThan(exactCount));
        }

        public QuantifierGroup LessThan(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.LessThan(minCount, maxCount));
        }

        public QuantifiablePattern NotLessThan()
        {
            return ConcatInternal(Chars.NotLessThan());
        }

        public QuantifierGroup NotLessThan(int exactCount)
        {
            return ConcatInternal(Chars.NotLessThan(exactCount));
        }

        public QuantifierGroup NotLessThan(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLessThan(minCount, maxCount));
        }

        public QuantifiablePattern EqualsSign()
        {
            return ConcatInternal(Chars.EqualsSign());
        }

        public QuantifierGroup EqualsSign(int exactCount)
        {
            return ConcatInternal(Chars.EqualsSign(exactCount));
        }

        public QuantifierGroup EqualsSign(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.EqualsSign(minCount, maxCount));
        }

        public QuantifiablePattern NotEqualsSign()
        {
            return ConcatInternal(Chars.NotEqualsSign());
        }

        public QuantifierGroup NotEqualsSign(int exactCount)
        {
            return ConcatInternal(Chars.NotEqualsSign(exactCount));
        }

        public QuantifierGroup NotEqualsSign(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotEqualsSign(minCount, maxCount));
        }

        public QuantifiablePattern GreaterThan()
        {
            return ConcatInternal(Chars.GreaterThan());
        }

        public QuantifierGroup GreaterThan(int exactCount)
        {
            return ConcatInternal(Chars.GreaterThan(exactCount));
        }

        public QuantifierGroup GreaterThan(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.GreaterThan(minCount, maxCount));
        }

        public QuantifiablePattern NotGreaterThan()
        {
            return ConcatInternal(Chars.NotGreaterThan());
        }

        public QuantifierGroup NotGreaterThan(int exactCount)
        {
            return ConcatInternal(Chars.NotGreaterThan(exactCount));
        }

        public QuantifierGroup NotGreaterThan(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotGreaterThan(minCount, maxCount));
        }

        public QuantifiablePattern QuestionMark()
        {
            return ConcatInternal(Chars.QuestionMark());
        }

        public QuantifierGroup QuestionMark(int exactCount)
        {
            return ConcatInternal(Chars.QuestionMark(exactCount));
        }

        public QuantifierGroup QuestionMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.QuestionMark(minCount, maxCount));
        }

        public QuantifiablePattern NotQuestionMark()
        {
            return ConcatInternal(Chars.NotQuestionMark());
        }

        public QuantifierGroup NotQuestionMark(int exactCount)
        {
            return ConcatInternal(Chars.NotQuestionMark(exactCount));
        }

        public QuantifierGroup NotQuestionMark(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotQuestionMark(minCount, maxCount));
        }

        public QuantifiablePattern At()
        {
            return ConcatInternal(Chars.At());
        }

        public QuantifierGroup At(int exactCount)
        {
            return ConcatInternal(Chars.At(exactCount));
        }

        public QuantifierGroup At(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.At(minCount, maxCount));
        }

        public QuantifiablePattern NotAt()
        {
            return ConcatInternal(Chars.NotAt());
        }

        public QuantifierGroup NotAt(int exactCount)
        {
            return ConcatInternal(Chars.NotAt(exactCount));
        }

        public QuantifierGroup NotAt(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotAt(minCount, maxCount));
        }

        public QuantifiablePattern LeftSquareBracket()
        {
            return ConcatInternal(Chars.LeftSquareBracket());
        }

        public QuantifierGroup LeftSquareBracket(int exactCount)
        {
            return ConcatInternal(Chars.LeftSquareBracket(exactCount));
        }

        public QuantifierGroup LeftSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.LeftSquareBracket(minCount, maxCount));
        }

        public QuantifiablePattern NotLeftSquareBracket()
        {
            return ConcatInternal(Chars.NotLeftSquareBracket());
        }

        public QuantifierGroup NotLeftSquareBracket(int exactCount)
        {
            return ConcatInternal(Chars.NotLeftSquareBracket(exactCount));
        }

        public QuantifierGroup NotLeftSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLeftSquareBracket(minCount, maxCount));
        }

        public QuantifiablePattern Backslash()
        {
            return ConcatInternal(Chars.Backslash());
        }

        public QuantifierGroup Backslash(int exactCount)
        {
            return ConcatInternal(Chars.Backslash(exactCount));
        }

        public QuantifierGroup Backslash(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Backslash(minCount, maxCount));
        }

        public QuantifiablePattern NotBackslash()
        {
            return ConcatInternal(Chars.NotBackslash());
        }

        public QuantifierGroup NotBackslash(int exactCount)
        {
            return ConcatInternal(Chars.NotBackslash(exactCount));
        }

        public QuantifierGroup NotBackslash(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotBackslash(minCount, maxCount));
        }

        public QuantifiablePattern RightSquareBracket()
        {
            return ConcatInternal(Chars.RightSquareBracket());
        }

        public QuantifierGroup RightSquareBracket(int exactCount)
        {
            return ConcatInternal(Chars.RightSquareBracket(exactCount));
        }

        public QuantifierGroup RightSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.RightSquareBracket(minCount, maxCount));
        }

        public QuantifiablePattern NotRightSquareBracket()
        {
            return ConcatInternal(Chars.NotRightSquareBracket());
        }

        public QuantifierGroup NotRightSquareBracket(int exactCount)
        {
            return ConcatInternal(Chars.NotRightSquareBracket(exactCount));
        }

        public QuantifierGroup NotRightSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotRightSquareBracket(minCount, maxCount));
        }

        public QuantifiablePattern CircumflexAccent()
        {
            return ConcatInternal(Chars.CircumflexAccent());
        }

        public QuantifierGroup CircumflexAccent(int exactCount)
        {
            return ConcatInternal(Chars.CircumflexAccent(exactCount));
        }

        public QuantifierGroup CircumflexAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.CircumflexAccent(minCount, maxCount));
        }

        public QuantifiablePattern NotCircumflexAccent()
        {
            return ConcatInternal(Chars.NotCircumflexAccent());
        }

        public QuantifierGroup NotCircumflexAccent(int exactCount)
        {
            return ConcatInternal(Chars.NotCircumflexAccent(exactCount));
        }

        public QuantifierGroup NotCircumflexAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotCircumflexAccent(minCount, maxCount));
        }

        public QuantifiablePattern Underscore()
        {
            return ConcatInternal(Chars.Underscore());
        }

        public QuantifierGroup Underscore(int exactCount)
        {
            return ConcatInternal(Chars.Underscore(exactCount));
        }

        public QuantifierGroup Underscore(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Underscore(minCount, maxCount));
        }

        public QuantifiablePattern NotUnderscore()
        {
            return ConcatInternal(Chars.NotUnderscore());
        }

        public QuantifierGroup NotUnderscore(int exactCount)
        {
            return ConcatInternal(Chars.NotUnderscore(exactCount));
        }

        public QuantifierGroup NotUnderscore(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotUnderscore(minCount, maxCount));
        }

        public QuantifiablePattern GraveAccent()
        {
            return ConcatInternal(Chars.GraveAccent());
        }

        public QuantifierGroup GraveAccent(int exactCount)
        {
            return ConcatInternal(Chars.GraveAccent(exactCount));
        }

        public QuantifierGroup GraveAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.GraveAccent(minCount, maxCount));
        }

        public QuantifiablePattern NotGraveAccent()
        {
            return ConcatInternal(Chars.NotGraveAccent());
        }

        public QuantifierGroup NotGraveAccent(int exactCount)
        {
            return ConcatInternal(Chars.NotGraveAccent(exactCount));
        }

        public QuantifierGroup NotGraveAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotGraveAccent(minCount, maxCount));
        }

        public QuantifiablePattern LeftCurlyBracket()
        {
            return ConcatInternal(Chars.LeftCurlyBracket());
        }

        public QuantifierGroup LeftCurlyBracket(int exactCount)
        {
            return ConcatInternal(Chars.LeftCurlyBracket(exactCount));
        }

        public QuantifierGroup LeftCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.LeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiablePattern NotLeftCurlyBracket()
        {
            return ConcatInternal(Chars.NotLeftCurlyBracket());
        }

        public QuantifierGroup NotLeftCurlyBracket(int exactCount)
        {
            return ConcatInternal(Chars.NotLeftCurlyBracket(exactCount));
        }

        public QuantifierGroup NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotLeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiablePattern VerticalLine()
        {
            return ConcatInternal(Chars.VerticalLine());
        }

        public QuantifierGroup VerticalLine(int exactCount)
        {
            return ConcatInternal(Chars.VerticalLine(exactCount));
        }

        public QuantifierGroup VerticalLine(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.VerticalLine(minCount, maxCount));
        }

        public QuantifiablePattern NotVerticalLine()
        {
            return ConcatInternal(Chars.NotVerticalLine());
        }

        public QuantifierGroup NotVerticalLine(int exactCount)
        {
            return ConcatInternal(Chars.NotVerticalLine(exactCount));
        }

        public QuantifierGroup NotVerticalLine(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotVerticalLine(minCount, maxCount));
        }

        public QuantifiablePattern RightCurlyBracket()
        {
            return ConcatInternal(Chars.RightCurlyBracket());
        }

        public QuantifierGroup RightCurlyBracket(int exactCount)
        {
            return ConcatInternal(Chars.RightCurlyBracket(exactCount));
        }

        public QuantifierGroup RightCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.RightCurlyBracket(minCount, maxCount));
        }

        public QuantifiablePattern NotRightCurlyBracket()
        {
            return ConcatInternal(Chars.NotRightCurlyBracket());
        }

        public QuantifierGroup NotRightCurlyBracket(int exactCount)
        {
            return ConcatInternal(Chars.NotRightCurlyBracket(exactCount));
        }

        public QuantifierGroup NotRightCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotRightCurlyBracket(minCount, maxCount));
        }

        public QuantifiablePattern Tilde()
        {
            return ConcatInternal(Chars.Tilde());
        }

        public QuantifierGroup Tilde(int exactCount)
        {
            return ConcatInternal(Chars.Tilde(exactCount));
        }

        public QuantifierGroup Tilde(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.Tilde(minCount, maxCount));
        }

        public QuantifiablePattern NotTilde()
        {
            return ConcatInternal(Chars.NotTilde());
        }

        public QuantifierGroup NotTilde(int exactCount)
        {
            return ConcatInternal(Chars.NotTilde(exactCount));
        }

        public QuantifierGroup NotTilde(int minCount, int maxCount)
        {
            return ConcatInternal(Chars.NotTilde(minCount, maxCount));
        }

        public CharGroup Parenthesis()
        {
            return ConcatInternal(Chars.Parenthesis());
        }

        public CharGroup NotParenthesis()
        {
            return ConcatInternal(Chars.NotParenthesis());
        }

        public CharGroup CurlyBracket()
        {
            return ConcatInternal(Chars.CurlyBracket());
        }

        public CharGroup NotCurlyBracket()
        {
            return ConcatInternal(Chars.NotCurlyBracket());
        }

        public CharGroup SquareBracket()
        {
            return ConcatInternal(Chars.SquareBracket());
        }

        public CharGroup NotSquareBracket()
        {
            return ConcatInternal(Chars.NotSquareBracket());
        }

        public QuantifierGroup Maybe(object content)
        {
            return ConcatInternal(new Maybe(content));
        }

        public QuantifierGroup Maybe(params object[] content)
        {
            return ConcatInternal(new Maybe(content));
        }

        public QuantifierGroup MaybeMany(object content)
        {
            return ConcatInternal(new MaybeMany(content));
        }

        public QuantifierGroup MaybeMany(params object[] content)
        {
            return ConcatInternal(new MaybeMany(content));
        }

        public QuantifierGroup OneMany(object content)
        {
            return ConcatInternal(new OneMany(content));
        }

        public QuantifierGroup OneMany(params object[] content)
        {
            return ConcatInternal(new OneMany(content));
        }

        public QuantifierGroup Count(int exactCount, object content)
        {
            return ConcatInternal(new Count(exactCount, content));
        }

        public QuantifierGroup Count(int minCount, int maxCount, object content)
        {
            return ConcatInternal(new Count(minCount, maxCount, content));
        }

        public QuantifierGroup Count(int exactCount, params object[] content)
        {
            return ConcatInternal(new Count(exactCount, content));
        }

        public QuantifierGroup Count(int minCount, int maxCount, params object[] content)
        {
            return ConcatInternal(new Count(minCount, maxCount, content));
        }
        
        public QuantifierGroup CountFrom(int minCount, object content)
        {
            return ConcatInternal(new CountFrom(minCount, content));
        }

        public QuantifierGroup CountFrom(int minCount, params object[] content)
        {
            return ConcatInternal(new CountFrom(minCount, content));
        }

        public QuantifierGroup CountTo(int maxCount, object content)
        {
            return ConcatInternal(new CountTo(maxCount, content));
        }

        public QuantifierGroup CountTo(int maxCount, params object[] content)
        {
            return ConcatInternal(new CountTo(maxCount, content));
        }

        public QuantifiablePattern GroupReference(int groupNumber)
        {
            return ConcatInternal(new GroupNumberReference(groupNumber));
        }

        public QuantifiablePattern GroupReference(string groupName)
        {
            return ConcatInternal(new GroupNameReference(groupName));
        }

        public Pattern Comment(string value)
        {
            return ConcatInternal(new InlineComment(value));
        }

        public QuantifiablePattern NewLine()
        {
            return ConcatInternal(new NewLine());
        }

        public QuantifiablePattern NewLineChar()
        {
            return ConcatInternal(Chars.NewLineChar());
        }

        public QuantifiablePattern NotNewLineChar()
        {
            return ConcatInternal(Chars.NotNewLineChar());
        }
    }
}
