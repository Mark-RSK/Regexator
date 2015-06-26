// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public partial class Pattern
    {
        public TPattern Not<TPattern>(IInvertible<TPattern> value) where TPattern : Pattern
        {
            return ConcatInternal(Patterns.Not(value));
        }

        public QuantifiablePattern DisallowGroup(string groupName)
        {
            return ConcatInternal(Patterns.DisallowGroup(groupName));
        }

        public Pattern DisallowGroups(params string[] groupNames)
        {
            return ConcatInternal(Patterns.DisallowGroups(groupNames));
        }

        public QuantifiablePattern DisallowGroup(int groupNumber)
        {
            return ConcatInternal(Patterns.DisallowGroup(groupNumber));
        }

        public Pattern DisallowGroups(params int[] groupNumbers)
        {
            return ConcatInternal(Patterns.DisallowGroups(groupNumbers));
        }

        public QuantifiablePattern RequireGroup(string groupName)
        {
            return ConcatInternal(Patterns.RequireGroup(groupName));
        }

        public Pattern RequireGroups(params string[] groupNames)
        {
            return ConcatInternal(Patterns.RequireGroups(groupNames));
        }

        public QuantifiablePattern RequireGroup(int groupNumber)
        {
            return ConcatInternal(Patterns.RequireGroup(groupNumber));
        }

        public Pattern RequireGroups(params int[] groupNumbers)
        {
            return ConcatInternal(Patterns.RequireGroups(groupNumbers));
        }

        public QuantifiablePattern Any(IEnumerable<object> content)
        {
            return ConcatInternal(Patterns.Any(content));
        }

        public QuantifiablePattern Any(params object[] content)
        {
            return ConcatInternal(Patterns.Any(content));
        }

        public QuantifiablePattern IfGroup(string groupName, object trueContent)
        {
            return ConcatInternal(Patterns.IfGroup(groupName, trueContent));
        }

        public QuantifiablePattern IfGroup(string groupName, object trueContent, object falseContent)
        {
            return ConcatInternal(Patterns.IfGroup(groupName, trueContent, falseContent));
        }

        public QuantifiablePattern IfGroup(int groupNumber, object trueContent)
        {
            return ConcatInternal(Patterns.IfGroup(groupNumber, trueContent));
        }

        public QuantifiablePattern IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            return ConcatInternal(Patterns.IfGroup(groupNumber, trueContent, falseContent));
        }

        public QuantifiablePattern IfAssert(Pattern testContent, object trueContent)
        {
            return ConcatInternal(Patterns.IfAssert(testContent, trueContent));
        }

        public QuantifiablePattern IfAssert(Pattern testContent, object trueContent, object falseContent)
        {
            return ConcatInternal(Patterns.IfAssert(testContent, trueContent, falseContent));
        }

        public Pattern Or(object content)
        {
            return Patterns.Or(this, content);
        }

        public QuantifiablePattern StartOfInput()
        {
            return ConcatInternal(Patterns.StartOfInput());
        }

        public QuantifiablePattern StartOfLine()
        {
            return ConcatInternal(Patterns.StartOfLine());
        }

        public QuantifiablePattern StartOfLineInvariant()
        {
            return ConcatInternal(Patterns.StartOfLineInvariant());
        }

        public QuantifiablePattern EndOfInput()
        {
            return ConcatInternal(Patterns.EndOfInput());
        }

        public QuantifiablePattern EndOfLine()
        {
            return ConcatInternal(Patterns.EndOfLine());
        }

        public QuantifiablePattern EndOfLineInvariant()
        {
            return ConcatInternal(Patterns.EndOfLineInvariant());
        }

        public Pattern EndOfLineOrBeforeCarriageReturn()
        {
            return ConcatInternal(Patterns.EndOfLineOrBeforeCarriageReturn());
        }

        public Pattern EndOfLineOrBeforeCarriageReturnInvariant()
        {
            return ConcatInternal(Patterns.EndOfLineOrBeforeCarriageReturnInvariant());
        }

        public QuantifiablePattern EndOrBeforeEndingNewLine()
        {
            return ConcatInternal(Patterns.EndOrBeforeEndingNewLine());
        }

        public QuantifiablePattern PreviousMatchEnd()
        {
            return ConcatInternal(Patterns.PreviousMatchEnd());
        }

        public QuantifiablePattern WordBoundary()
        {
            return ConcatInternal(Patterns.WordBoundary());
        }

        public QuantifiablePattern Word()
        {
            return ConcatInternal(Patterns.Word());
        }

        public QuantifiablePattern Word(string text)
        {
            return ConcatInternal(Patterns.Word(text));
        }

        public QuantifiablePattern Word(params string[] values)
        {
            return ConcatInternal(Patterns.Word(values));
        }

        public QuantifiablePattern NotWordBoundary()
        {
            return ConcatInternal(Patterns.NotWordBoundary());
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
            return ConcatInternal(Patterns.Assert(content));
        }

        public QuantifiablePattern Assert(params object[] content)
        {
            return ConcatInternal(Patterns.Assert(content));
        }

        public QuantifiablePattern Assert(CharGroupItem item)
        {
            return ConcatInternal(Patterns.Assert(item));
        }

        public QuantifiablePattern NotAssert(object content)
        {
            return ConcatInternal(Patterns.NotAssert(content));
        }

        public QuantifiablePattern NotAssert(params object[] content)
        {
            return ConcatInternal(Patterns.NotAssert(content));
        }

        public QuantifiablePattern NotAssert(CharGroupItem item)
        {
            return ConcatInternal(Patterns.NotAssert(item));
        }

        public QuantifiablePattern AssertBack(object content)
        {
            return ConcatInternal(Patterns.AssertBack(content));
        }

        public QuantifiablePattern AssertBack(params object[] content)
        {
            return ConcatInternal(Patterns.AssertBack(content));
        }

        public QuantifiablePattern AssertBack(CharGroupItem item)
        {
            return ConcatInternal(Patterns.AssertBack(item));
        }

        public QuantifiablePattern NotAssertBack(object content)
        {
            return ConcatInternal(Patterns.NotAssertBack(content));
        }

        public QuantifiablePattern NotAssertBack(params object[] content)
        {
            return ConcatInternal(Patterns.NotAssertBack(content));
        }

        public QuantifiablePattern NotAssertBack(CharGroupItem item)
        {
            return ConcatInternal(Patterns.NotAssertBack(item));
        }

        public QuantifiablePattern Group()
        {
            return ConcatInternal(Patterns.Group());
        }

        public QuantifiablePattern Group(object content)
        {
            return ConcatInternal(Patterns.Group(content));
        }

        public QuantifiablePattern Group(params object[] content)
        {
            return ConcatInternal(Patterns.Group(content));
        }

        public QuantifiablePattern NamedGroup(string name, object content)
        {
            return ConcatInternal(Patterns.NamedGroup(name, content));
        }

        public QuantifiablePattern NamedGroup(string name, params object[] content)
        {
            return ConcatInternal(Patterns.NamedGroup(name, content));
        }

        public QuantifiablePattern NoncapturingGroup(object content)
        {
            return ConcatInternal(Patterns.NoncapturingGroup((content)));
        }

        public QuantifiablePattern NoncapturingGroup(params object[] content)
        {
            return ConcatInternal(Patterns.NoncapturingGroup(content));
        }

        public QuantifiablePattern NonbacktrackingGroup(object content)
        {
            return ConcatInternal(Patterns.NonbacktrackingGroup(content));
        }

        public QuantifiablePattern NonbacktrackingGroup(params object[] content)
        {
            return ConcatInternal(Patterns.NonbacktrackingGroup(content));
        }

        public QuantifiablePattern BalancingGroup(string name1, string name2, object content)
        {
            return ConcatInternal(Patterns.BalancingGroup(name1, name2, content));
        }

        public QuantifiablePattern BalancingGroup(string name1, string name2, params object[] content)
        {
            return ConcatInternal(Patterns.BalancingGroup(name1, name2, content));
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
            return Patterns.Group(this);
        }

        public QuantifiablePattern AsNamedGroup(string groupName)
        {
            return Patterns.NamedGroup(groupName, this);
        }

        public QuantifiablePattern AsNoncapturingGroup()
        {
            return Patterns.NoncapturingGroup(this);
        }

        public QuantifiablePattern AsNonbacktrackingGroup()
        {
            return Patterns.NonbacktrackingGroup(this);
        }

        public Pattern Apostrophes()
        {
            return ConcatInternal(Patterns.Apostrophes());
        }

        public Pattern Apostrophes(object content)
        {
            return ConcatInternal(Patterns.Apostrophes(content));
        }

        public Pattern QuoteMarks()
        {
            return ConcatInternal(Patterns.QuoteMarks());
        }

        public Pattern QuoteMarks(object content)
        {
            return ConcatInternal(Patterns.QuoteMarks(content));
        }

        public Pattern Parentheses()
        {
            return ConcatInternal(Patterns.Parentheses());
        }

        public Pattern Parentheses(object content)
        {
            return ConcatInternal(Patterns.Parentheses(content));
        }

        public Pattern CurlyBrackets()
        {
            return ConcatInternal(Patterns.CurlyBrackets());
        }

        public Pattern CurlyBrackets(object content)
        {
            return ConcatInternal(Patterns.CurlyBrackets(content));
        }

        public Pattern SquareBrackets()
        {
            return ConcatInternal(Patterns.SquareBrackets());
        }

        public Pattern SquareBrackets(object content)
        {
            return ConcatInternal(Patterns.SquareBrackets(content));
        }

        public Pattern LessThanGreaterThan(object content)
        {
            return ConcatInternal(Patterns.LessThanGreaterThan(content));
        }

#if DEBUG
        public QuantifiablePattern GoToChar(char value)
        {
            return ConcatInternal(Patterns.GoToChar(value));
        }

        public QuantifiablePattern GoToChar(AsciiChar value)
        {
            return ConcatInternal(Patterns.GoToChar(value));
        }
#endif

        public QuantifiablePattern Character(string characters)
        {
            return ConcatInternal(Patterns.Character(characters));
        }

        public QuantifiablePattern Character(CharGroupItem item)
        {
            return ConcatInternal(Patterns.Character(item));
        }

        public QuantifiablePattern NotCharacter(string characters)
        {
            return ConcatInternal(Patterns.NotCharacter(characters));
        }

        public QuantifiablePattern NotCharacter(CharGroupItem item)
        {
            return ConcatInternal(Patterns.NotCharacter(item));
        }

        public QuantifiablePattern Range(char first, char last)
        {
            return ConcatInternal(Patterns.Range(first, last));
        }

        public QuantifiablePattern Range(int firstCharCode, int lastCharCode)
        {
            return ConcatInternal(Patterns.Range(firstCharCode, lastCharCode));
        }

        public QuantifiablePattern NotRange(char first, char last)
        {
            return ConcatInternal(Patterns.NotRange(first, last));
        }

        public QuantifiablePattern NotRange(int firstCharCode, int lastCharCode)
        {
            return ConcatInternal(Patterns.NotRange(firstCharCode, lastCharCode));
        }

        public QuantifiablePattern Subtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return ConcatInternal(Patterns.Subtract(baseGroup, excludedGroup));
        }

        public QuantifiablePattern NotSubtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return ConcatInternal(Patterns.NotSubtract(baseGroup, excludedGroup));
        }

        public QuantifiablePattern WhiteSpaceExceptNewLine()
        {
            return ConcatInternal(Patterns.WhiteSpaceExceptNewLine());
        }

        public Pattern WhileChar(char value)
        {
            return ConcatInternal(Patterns.WhileChar(value));
        }

        public Pattern WhileChar(AsciiChar value)
        {
            return ConcatInternal(Patterns.WhileChar(value));
        }

        public Pattern WhileChar(CharGroupItem item)
        {
            return ConcatInternal(Patterns.WhileChar(item));
        }

        public Pattern WhileNotChar(char value)
        {
            return ConcatInternal(Patterns.WhileNotChar(value));
        }

        public Pattern WhileNotChar(AsciiChar value)
        {
            return ConcatInternal(Patterns.WhileNotChar(value));
        }

        public Pattern WhileNotChar(CharGroupItem item)
        {
            return ConcatInternal(Patterns.WhileNotChar(item));
        }

        public Pattern WhileNotNewLine()
        {
            return ConcatInternal(Patterns.WhileNotNewLine());
        }

        public CharGroup Alphanumeric()
        {
            return ConcatInternal(Patterns.Alphanumeric());
        }

        public CharGroup NotAlphanumeric()
        {
            return ConcatInternal(Patterns.NotAlphanumeric());
        }

        public CharGroup AlphanumericLower()
        {
            return ConcatInternal(Patterns.AlphanumericLower());
        }

        public CharGroup NotAlphanumericLower()
        {
            return ConcatInternal(Patterns.NotAlphanumericLower());
        }

        public CharGroup AlphanumericUpper()
        {
            return ConcatInternal(Patterns.AlphanumericUpper());
        }

        public CharGroup NotAlphanumericUpper()
        {
            return ConcatInternal(Patterns.NotAlphanumericUpper());
        }

        public CharGroup AlphanumericUnderscore()
        {
            return ConcatInternal(Patterns.AlphanumericUnderscore());
        }

        public CharGroup NotAlphanumericUnderscore()
        {
            return ConcatInternal(Patterns.NotAlphanumericUnderscore());
        }

        public CharGroup LatinLetter()
        {
            return ConcatInternal(Patterns.LatinLetter());
        }

        public CharGroup LatinLetterLower()
        {
            return ConcatInternal(Patterns.LatinLetterLower());
        }

        public CharGroup LatinLetterUpper()
        {
            return ConcatInternal(Patterns.LatinLetterUpper());
        }

        public CharGroup NotLatinLetter()
        {
            return ConcatInternal(Patterns.NotLatinLetter());
        }

        public CharGroup NotLatinLetterLower()
        {
            return ConcatInternal(Patterns.NotLatinLetterLower());
        }

        public CharGroup NotLatinLetterUpper()
        {
            return ConcatInternal(Patterns.NotLatinLetterUpper());
        }

        public QuantifiablePattern Any()
        {
            return ConcatInternal(Patterns.Any());
        }

        public QuantifiablePattern AnyInvariant()
        {
            return ConcatInternal(Patterns.AnyInvariant());
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
            return ConcatInternal(Patterns.ArabicDigit());
        }

        public QuantifiablePattern NotArabicDigit()
        {
            return ConcatInternal(Patterns.NotArabicDigit());
        }

        public QuantifiablePattern HexadecimalDigit()
        {
            return ConcatInternal(Patterns.HexadecimalDigit());
        }

        public QuantifiablePattern NotHexadecimalDigit()
        {
            return ConcatInternal(Patterns.NotHexadecimalDigit());
        }

        public QuantifiablePattern Digit()
        {
            return ConcatInternal(Patterns.Digit());
        }

        public QuantifiedGroup Digit(int count)
        {
            return ConcatInternal(Patterns.Digit(count));
        }

        public QuantifiedGroup Digit(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Digit(minCount, maxCount));
        }

        public QuantifiedGroup Digits()
        {
            return ConcatInternal(Patterns.Digits());
        }

        public QuantifiablePattern NotDigit()
        {
            return ConcatInternal(Patterns.NotDigit());
        }

        public QuantifiedGroup NotDigit(int count)
        {
            return ConcatInternal(Patterns.NotDigit(count));
        }

        public QuantifiedGroup NotDigit(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotDigit(minCount, maxCount));
        }

        public QuantifiedGroup NotDigits()
        {
            return ConcatInternal(Patterns.NotDigits());
        }

        public QuantifiablePattern WhiteSpace()
        {
            return ConcatInternal(Patterns.WhiteSpace());
        }

        public QuantifiedGroup WhiteSpace(int count)
        {
            return ConcatInternal(Patterns.WhiteSpace(count));
        }

        public QuantifiedGroup WhiteSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.WhiteSpace(minCount, maxCount));
        }

        public QuantifiedGroup WhiteSpaces()
        {
            return ConcatInternal(Patterns.WhiteSpaces());
        }

        public QuantifiedPattern WhileWhiteSpace()
        {
            return ConcatInternal(Patterns.WhileWhiteSpace());
        }

        public QuantifiablePattern NotWhiteSpace()
        {
            return ConcatInternal(Patterns.NotWhiteSpace());
        }

        public QuantifiedGroup NotWhiteSpace(int count)
        {
            return ConcatInternal(Patterns.NotWhiteSpace(count));
        }

        public QuantifiedGroup NotWhiteSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotWhiteSpace(minCount, maxCount));
        }

        public QuantifiedGroup NotWhiteSpaces()
        {
            return ConcatInternal(Patterns.NotWhiteSpaces());
        }

        public QuantifiablePattern WordChar()
        {
            return ConcatInternal(Patterns.WordChar());
        }

        public QuantifiedGroup WordChar(int count)
        {
            return ConcatInternal(Patterns.WordChar(count));
        }

        public QuantifiedGroup WordChar(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.WordChar(minCount, maxCount));
        }

        public QuantifiedGroup WordChars()
        {
            return ConcatInternal(Patterns.WordChars());
        }

        public QuantifiablePattern NotWordChar()
        {
            return ConcatInternal(Patterns.NotWordChar());
        }

        public QuantifiedGroup NotWordChar(int count)
        {
            return ConcatInternal(Patterns.NotWordChar(count));
        }

        public QuantifiedGroup NotWordChar(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotWordChar(minCount, maxCount));
        }

        public QuantifiedGroup NotWordChars()
        {
            return ConcatInternal(Patterns.NotWordChars());
        }

        public QuantifiablePattern Character(char value)
        {
            return ConcatInternal(Patterns.Character(value));
        }

        public QuantifiablePattern Character(int charCode)
        {
            return ConcatInternal(Patterns.Character(charCode));
        }

        public QuantifiablePattern Character(AsciiChar value)
        {
            return ConcatInternal(Patterns.Character(value));
        }

        public QuantifiablePattern Character(NamedBlock block)
        {
            return ConcatInternal(Patterns.Character(block));
        }

        public QuantifiablePattern Character(GeneralCategory category)
        {
            return ConcatInternal(Patterns.Character(category));
        }

        public QuantifiablePattern NotCharacter(char value)
        {
            return ConcatInternal(Patterns.NotCharacter(value));
        }

        public QuantifiablePattern NotCharacter(int charCode)
        {
            return ConcatInternal(Patterns.NotCharacter(charCode));
        }

        public QuantifiablePattern NotCharacter(AsciiChar value)
        {
            return ConcatInternal(Patterns.NotCharacter(value));
        }

        public QuantifiablePattern NotCharacter(NamedBlock block)
        {
            return ConcatInternal(Patterns.NotCharacter(block));
        }

        public QuantifiablePattern NotCharacter(GeneralCategory category)
        {
            return ConcatInternal(Patterns.NotCharacter(category));
        }

        public QuantifiablePattern Tab()
        {
            return ConcatInternal(Patterns.Tab());
        }

        public QuantifiedGroup Tab(int exactCount)
        {
            return ConcatInternal(Patterns.Tab(exactCount));
        }

        public QuantifiedGroup Tab(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Tab(minCount, maxCount));
        }

        public QuantifiablePattern NotTab()
        {
            return ConcatInternal(Patterns.NotTab());
        }

        public QuantifiedGroup NotTab(int exactCount)
        {
            return ConcatInternal(Patterns.NotTab(exactCount));
        }

        public QuantifiedGroup NotTab(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotTab(minCount, maxCount));
        }

        public QuantifiablePattern Linefeed()
        {
            return ConcatInternal(Patterns.Linefeed());
        }

        public QuantifiedGroup Linefeed(int exactCount)
        {
            return ConcatInternal(Patterns.Linefeed(exactCount));
        }

        public QuantifiedGroup Linefeed(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Linefeed(minCount, maxCount));
        }

        public QuantifiablePattern NotLinefeed()
        {
            return ConcatInternal(Patterns.NotLinefeed());
        }

        public QuantifiedGroup NotLinefeed(int exactCount)
        {
            return ConcatInternal(Patterns.NotLinefeed(exactCount));
        }

        public QuantifiedGroup NotLinefeed(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLinefeed(minCount, maxCount));
        }

        public QuantifiablePattern CarriageReturn()
        {
            return ConcatInternal(Patterns.CarriageReturn());
        }

        public QuantifiedGroup CarriageReturn(int exactCount)
        {
            return ConcatInternal(Patterns.CarriageReturn(exactCount));
        }

        public QuantifiedGroup CarriageReturn(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.CarriageReturn(minCount, maxCount));
        }

        public QuantifiablePattern NotCarriageReturn()
        {
            return ConcatInternal(Patterns.NotCarriageReturn());
        }

        public QuantifiedGroup NotCarriageReturn(int exactCount)
        {
            return ConcatInternal(Patterns.NotCarriageReturn(exactCount));
        }

        public QuantifiedGroup NotCarriageReturn(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotCarriageReturn(minCount, maxCount));
        }

        public QuantifiablePattern Space()
        {
            return ConcatInternal(Patterns.Space());
        }

        public QuantifiedGroup Space(int exactCount)
        {
            return ConcatInternal(Patterns.Space(exactCount));
        }

        public QuantifiedGroup Space(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Space(minCount, maxCount));
        }

        public QuantifiablePattern NotSpace()
        {
            return ConcatInternal(Patterns.NotSpace());
        }

        public QuantifiedGroup NotSpace(int exactCount)
        {
            return ConcatInternal(Patterns.NotSpace(exactCount));
        }

        public QuantifiedGroup NotSpace(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotSpace(minCount, maxCount));
        }

        public QuantifiablePattern ExclamationMark()
        {
            return ConcatInternal(Patterns.ExclamationMark());
        }

        public QuantifiedGroup ExclamationMark(int exactCount)
        {
            return ConcatInternal(Patterns.ExclamationMark(exactCount));
        }

        public QuantifiedGroup ExclamationMark(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.ExclamationMark(minCount, maxCount));
        }

        public QuantifiablePattern NotExclamationMark()
        {
            return ConcatInternal(Patterns.NotExclamationMark());
        }

        public QuantifiedGroup NotExclamationMark(int exactCount)
        {
            return ConcatInternal(Patterns.NotExclamationMark(exactCount));
        }

        public QuantifiedGroup NotExclamationMark(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotExclamationMark(minCount, maxCount));
        }

        public QuantifiablePattern QuoteMark()
        {
            return ConcatInternal(Patterns.QuoteMark());
        }

        public QuantifiedGroup QuoteMark(int exactCount)
        {
            return ConcatInternal(Patterns.QuoteMark(exactCount));
        }

        public QuantifiedGroup QuoteMark(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.QuoteMark(minCount, maxCount));
        }

        public QuantifiablePattern NotQuoteMark()
        {
            return ConcatInternal(Patterns.NotQuoteMark());
        }

        public QuantifiedGroup NotQuoteMark(int exactCount)
        {
            return ConcatInternal(Patterns.NotQuoteMark(exactCount));
        }

        public QuantifiedGroup NotQuoteMark(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotQuoteMark(minCount, maxCount));
        }

        public QuantifiablePattern NumberSign()
        {
            return ConcatInternal(Patterns.NumberSign());
        }

        public QuantifiedGroup NumberSign(int exactCount)
        {
            return ConcatInternal(Patterns.NumberSign(exactCount));
        }

        public QuantifiedGroup NumberSign(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NumberSign(minCount, maxCount));
        }

        public QuantifiablePattern NotNumberSign()
        {
            return ConcatInternal(Patterns.NotNumberSign());
        }

        public QuantifiedGroup NotNumberSign(int exactCount)
        {
            return ConcatInternal(Patterns.NotNumberSign(exactCount));
        }

        public QuantifiedGroup NotNumberSign(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotNumberSign(minCount, maxCount));
        }

        public QuantifiablePattern Dollar()
        {
            return ConcatInternal(Patterns.Dollar());
        }

        public QuantifiedGroup Dollar(int exactCount)
        {
            return ConcatInternal(Patterns.Dollar(exactCount));
        }

        public QuantifiedGroup Dollar(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Dollar(minCount, maxCount));
        }

        public QuantifiablePattern NotDollar()
        {
            return ConcatInternal(Patterns.NotDollar());
        }

        public QuantifiedGroup NotDollar(int exactCount)
        {
            return ConcatInternal(Patterns.NotDollar(exactCount));
        }

        public QuantifiedGroup NotDollar(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotDollar(minCount, maxCount));
        }

        public QuantifiablePattern Percent()
        {
            return ConcatInternal(Patterns.Percent());
        }

        public QuantifiedGroup Percent(int exactCount)
        {
            return ConcatInternal(Patterns.Percent(exactCount));
        }

        public QuantifiedGroup Percent(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Percent(minCount, maxCount));
        }

        public QuantifiablePattern NotPercent()
        {
            return ConcatInternal(Patterns.NotPercent());
        }

        public QuantifiedGroup NotPercent(int exactCount)
        {
            return ConcatInternal(Patterns.NotPercent(exactCount));
        }

        public QuantifiedGroup NotPercent(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotPercent(minCount, maxCount));
        }

        public QuantifiablePattern Ampersand()
        {
            return ConcatInternal(Patterns.Ampersand());
        }

        public QuantifiedGroup Ampersand(int exactCount)
        {
            return ConcatInternal(Patterns.Ampersand(exactCount));
        }

        public QuantifiedGroup Ampersand(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Ampersand(minCount, maxCount));
        }

        public QuantifiablePattern NotAmpersand()
        {
            return ConcatInternal(Patterns.NotAmpersand());
        }

        public QuantifiedGroup NotAmpersand(int exactCount)
        {
            return ConcatInternal(Patterns.NotAmpersand(exactCount));
        }

        public QuantifiedGroup NotAmpersand(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotAmpersand(minCount, maxCount));
        }

        public QuantifiablePattern Apostrophe()
        {
            return ConcatInternal(Patterns.Apostrophe());
        }

        public QuantifiedGroup Apostrophe(int exactCount)
        {
            return ConcatInternal(Patterns.Apostrophe(exactCount));
        }

        public QuantifiedGroup Apostrophe(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Apostrophe(minCount, maxCount));
        }

        public QuantifiablePattern NotApostrophe()
        {
            return ConcatInternal(Patterns.NotApostrophe());
        }

        public QuantifiedGroup NotApostrophe(int exactCount)
        {
            return ConcatInternal(Patterns.NotApostrophe(exactCount));
        }

        public QuantifiedGroup NotApostrophe(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotApostrophe(minCount, maxCount));
        }

        public QuantifiablePattern LeftParenthesis()
        {
            return ConcatInternal(Patterns.LeftParenthesis());
        }

        public QuantifiedGroup LeftParenthesis(int exactCount)
        {
            return ConcatInternal(Patterns.LeftParenthesis(exactCount));
        }

        public QuantifiedGroup LeftParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LeftParenthesis(minCount, maxCount));
        }

        public QuantifiablePattern NotLeftParenthesis()
        {
            return ConcatInternal(Patterns.NotLeftParenthesis());
        }

        public QuantifiedGroup NotLeftParenthesis(int exactCount)
        {
            return ConcatInternal(Patterns.NotLeftParenthesis(exactCount));
        }

        public QuantifiedGroup NotLeftParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLeftParenthesis(minCount, maxCount));
        }

        public QuantifiablePattern RightParenthesis()
        {
            return ConcatInternal(Patterns.RightParenthesis());
        }

        public QuantifiedGroup RightParenthesis(int exactCount)
        {
            return ConcatInternal(Patterns.RightParenthesis(exactCount));
        }

        public QuantifiedGroup RightParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.RightParenthesis(minCount, maxCount));
        }

        public QuantifiablePattern NotRightParenthesis()
        {
            return ConcatInternal(Patterns.NotRightParenthesis());
        }

        public QuantifiedGroup NotRightParenthesis(int exactCount)
        {
            return ConcatInternal(Patterns.NotRightParenthesis(exactCount));
        }

        public QuantifiedGroup NotRightParenthesis(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotRightParenthesis(minCount, maxCount));
        }

        public QuantifiablePattern Asterisk()
        {
            return ConcatInternal(Patterns.Asterisk());
        }

        public QuantifiedGroup Asterisk(int exactCount)
        {
            return ConcatInternal(Patterns.Asterisk(exactCount));
        }

        public QuantifiedGroup Asterisk(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Asterisk(minCount, maxCount));
        }

        public QuantifiablePattern NotAsterisk()
        {
            return ConcatInternal(Patterns.NotAsterisk());
        }

        public QuantifiedGroup NotAsterisk(int exactCount)
        {
            return ConcatInternal(Patterns.NotAsterisk(exactCount));
        }

        public QuantifiedGroup NotAsterisk(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotAsterisk(minCount, maxCount));
        }

        public QuantifiablePattern Plus()
        {
            return ConcatInternal(Patterns.Plus());
        }

        public QuantifiedGroup Plus(int exactCount)
        {
            return ConcatInternal(Patterns.Plus(exactCount));
        }

        public QuantifiedGroup Plus(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Plus(minCount, maxCount));
        }

        public QuantifiablePattern NotPlus()
        {
            return ConcatInternal(Patterns.NotPlus());
        }

        public QuantifiedGroup NotPlus(int exactCount)
        {
            return ConcatInternal(Patterns.NotPlus(exactCount));
        }

        public QuantifiedGroup NotPlus(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotPlus(minCount, maxCount));
        }

        public QuantifiablePattern Comma()
        {
            return ConcatInternal(Patterns.Comma());
        }

        public QuantifiedGroup Comma(int exactCount)
        {
            return ConcatInternal(Patterns.Comma(exactCount));
        }

        public QuantifiedGroup Comma(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Comma(minCount, maxCount));
        }

        public QuantifiablePattern NotComma()
        {
            return ConcatInternal(Patterns.NotComma());
        }

        public QuantifiedGroup NotComma(int exactCount)
        {
            return ConcatInternal(Patterns.NotComma(exactCount));
        }

        public QuantifiedGroup NotComma(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotComma(minCount, maxCount));
        }

        public QuantifiablePattern Hyphen()
        {
            return ConcatInternal(Patterns.Hyphen());
        }

        public QuantifiedGroup Hyphen(int exactCount)
        {
            return ConcatInternal(Patterns.Hyphen(exactCount));
        }

        public QuantifiedGroup Hyphen(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Hyphen(minCount, maxCount));
        }

        public QuantifiablePattern NotHyphen()
        {
            return ConcatInternal(Patterns.NotHyphen());
        }

        public QuantifiedGroup NotHyphen(int exactCount)
        {
            return ConcatInternal(Patterns.NotHyphen(exactCount));
        }

        public QuantifiedGroup NotHyphen(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotHyphen(minCount, maxCount));
        }

        public QuantifiablePattern Period()
        {
            return ConcatInternal(Patterns.Period());
        }

        public QuantifiedGroup Period(int exactCount)
        {
            return ConcatInternal(Patterns.Period(exactCount));
        }

        public QuantifiedGroup Period(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Period(minCount, maxCount));
        }

        public QuantifiablePattern NotPeriod()
        {
            return ConcatInternal(Patterns.NotPeriod());
        }

        public QuantifiedGroup NotPeriod(int exactCount)
        {
            return ConcatInternal(Patterns.NotPeriod(exactCount));
        }

        public QuantifiedGroup NotPeriod(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotPeriod(minCount, maxCount));
        }

        public QuantifiablePattern Slash()
        {
            return ConcatInternal(Patterns.Slash());
        }

        public QuantifiedGroup Slash(int exactCount)
        {
            return ConcatInternal(Patterns.Slash(exactCount));
        }

        public QuantifiedGroup Slash(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Slash(minCount, maxCount));
        }

        public QuantifiablePattern NotSlash()
        {
            return ConcatInternal(Patterns.NotSlash());
        }

        public QuantifiedGroup NotSlash(int exactCount)
        {
            return ConcatInternal(Patterns.NotSlash(exactCount));
        }

        public QuantifiedGroup NotSlash(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotSlash(minCount, maxCount));
        }

        public QuantifiablePattern Colon()
        {
            return ConcatInternal(Patterns.Colon());
        }

        public QuantifiedGroup Colon(int exactCount)
        {
            return ConcatInternal(Patterns.Colon(exactCount));
        }

        public QuantifiedGroup Colon(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Colon(minCount, maxCount));
        }

        public QuantifiablePattern NotColon()
        {
            return ConcatInternal(Patterns.NotColon());
        }

        public QuantifiedGroup NotColon(int exactCount)
        {
            return ConcatInternal(Patterns.NotColon(exactCount));
        }

        public QuantifiedGroup NotColon(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotColon(minCount, maxCount));
        }

        public QuantifiablePattern Semicolon()
        {
            return ConcatInternal(Patterns.Semicolon());
        }

        public QuantifiedGroup Semicolon(int exactCount)
        {
            return ConcatInternal(Patterns.Semicolon(exactCount));
        }

        public QuantifiedGroup Semicolon(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Semicolon(minCount, maxCount));
        }

        public QuantifiablePattern NotSemicolon()
        {
            return ConcatInternal(Patterns.NotSemicolon());
        }

        public QuantifiedGroup NotSemicolon(int exactCount)
        {
            return ConcatInternal(Patterns.NotSemicolon(exactCount));
        }

        public QuantifiedGroup NotSemicolon(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotSemicolon(minCount, maxCount));
        }

        public QuantifiablePattern LessThan()
        {
            return ConcatInternal(Patterns.LessThan());
        }

        public QuantifiedGroup LessThan(int exactCount)
        {
            return ConcatInternal(Patterns.LessThan(exactCount));
        }

        public QuantifiedGroup LessThan(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LessThan(minCount, maxCount));
        }

        public QuantifiablePattern NotLessThan()
        {
            return ConcatInternal(Patterns.NotLessThan());
        }

        public QuantifiedGroup NotLessThan(int exactCount)
        {
            return ConcatInternal(Patterns.NotLessThan(exactCount));
        }

        public QuantifiedGroup NotLessThan(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLessThan(minCount, maxCount));
        }

        public QuantifiablePattern EqualsSign()
        {
            return ConcatInternal(Patterns.EqualsSign());
        }

        public QuantifiedGroup EqualsSign(int exactCount)
        {
            return ConcatInternal(Patterns.EqualsSign(exactCount));
        }

        public QuantifiedGroup EqualsSign(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.EqualsSign(minCount, maxCount));
        }

        public QuantifiablePattern NotEqualsSign()
        {
            return ConcatInternal(Patterns.NotEqualsSign());
        }

        public QuantifiedGroup NotEqualsSign(int exactCount)
        {
            return ConcatInternal(Patterns.NotEqualsSign(exactCount));
        }

        public QuantifiedGroup NotEqualsSign(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotEqualsSign(minCount, maxCount));
        }

        public QuantifiablePattern GreaterThan()
        {
            return ConcatInternal(Patterns.GreaterThan());
        }

        public QuantifiedGroup GreaterThan(int exactCount)
        {
            return ConcatInternal(Patterns.GreaterThan(exactCount));
        }

        public QuantifiedGroup GreaterThan(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.GreaterThan(minCount, maxCount));
        }

        public QuantifiablePattern NotGreaterThan()
        {
            return ConcatInternal(Patterns.NotGreaterThan());
        }

        public QuantifiedGroup NotGreaterThan(int exactCount)
        {
            return ConcatInternal(Patterns.NotGreaterThan(exactCount));
        }

        public QuantifiedGroup NotGreaterThan(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotGreaterThan(minCount, maxCount));
        }

        public QuantifiablePattern QuestionMark()
        {
            return ConcatInternal(Patterns.QuestionMark());
        }

        public QuantifiedGroup QuestionMark(int exactCount)
        {
            return ConcatInternal(Patterns.QuestionMark(exactCount));
        }

        public QuantifiedGroup QuestionMark(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.QuestionMark(minCount, maxCount));
        }

        public QuantifiablePattern NotQuestionMark()
        {
            return ConcatInternal(Patterns.NotQuestionMark());
        }

        public QuantifiedGroup NotQuestionMark(int exactCount)
        {
            return ConcatInternal(Patterns.NotQuestionMark(exactCount));
        }

        public QuantifiedGroup NotQuestionMark(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotQuestionMark(minCount, maxCount));
        }

        public QuantifiablePattern AtSign()
        {
            return ConcatInternal(Patterns.AtSign());
        }

        public QuantifiedGroup AtSign(int exactCount)
        {
            return ConcatInternal(Patterns.AtSign(exactCount));
        }

        public QuantifiedGroup AtSign(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.AtSign(minCount, maxCount));
        }

        public QuantifiablePattern NotAtSign()
        {
            return ConcatInternal(Patterns.NotAtSign());
        }

        public QuantifiedGroup NotAtSign(int exactCount)
        {
            return ConcatInternal(Patterns.NotAtSign(exactCount));
        }

        public QuantifiedGroup NotAtSign(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotAtSign(minCount, maxCount));
        }

        public QuantifiablePattern LeftSquareBracket()
        {
            return ConcatInternal(Patterns.LeftSquareBracket());
        }

        public QuantifiedGroup LeftSquareBracket(int exactCount)
        {
            return ConcatInternal(Patterns.LeftSquareBracket(exactCount));
        }

        public QuantifiedGroup LeftSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LeftSquareBracket(minCount, maxCount));
        }

        public QuantifiablePattern NotLeftSquareBracket()
        {
            return ConcatInternal(Patterns.NotLeftSquareBracket());
        }

        public QuantifiedGroup NotLeftSquareBracket(int exactCount)
        {
            return ConcatInternal(Patterns.NotLeftSquareBracket(exactCount));
        }

        public QuantifiedGroup NotLeftSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLeftSquareBracket(minCount, maxCount));
        }

        public QuantifiablePattern Backslash()
        {
            return ConcatInternal(Patterns.Backslash());
        }

        public QuantifiedGroup Backslash(int exactCount)
        {
            return ConcatInternal(Patterns.Backslash(exactCount));
        }

        public QuantifiedGroup Backslash(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Backslash(minCount, maxCount));
        }

        public QuantifiablePattern NotBackslash()
        {
            return ConcatInternal(Patterns.NotBackslash());
        }

        public QuantifiedGroup NotBackslash(int exactCount)
        {
            return ConcatInternal(Patterns.NotBackslash(exactCount));
        }

        public QuantifiedGroup NotBackslash(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotBackslash(minCount, maxCount));
        }

        public QuantifiablePattern RightSquareBracket()
        {
            return ConcatInternal(Patterns.RightSquareBracket());
        }

        public QuantifiedGroup RightSquareBracket(int exactCount)
        {
            return ConcatInternal(Patterns.RightSquareBracket(exactCount));
        }

        public QuantifiedGroup RightSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.RightSquareBracket(minCount, maxCount));
        }

        public QuantifiablePattern NotRightSquareBracket()
        {
            return ConcatInternal(Patterns.NotRightSquareBracket());
        }

        public QuantifiedGroup NotRightSquareBracket(int exactCount)
        {
            return ConcatInternal(Patterns.NotRightSquareBracket(exactCount));
        }

        public QuantifiedGroup NotRightSquareBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotRightSquareBracket(minCount, maxCount));
        }

        public QuantifiablePattern CircumflexAccent()
        {
            return ConcatInternal(Patterns.CircumflexAccent());
        }

        public QuantifiedGroup CircumflexAccent(int exactCount)
        {
            return ConcatInternal(Patterns.CircumflexAccent(exactCount));
        }

        public QuantifiedGroup CircumflexAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.CircumflexAccent(minCount, maxCount));
        }

        public QuantifiablePattern NotCircumflexAccent()
        {
            return ConcatInternal(Patterns.NotCircumflexAccent());
        }

        public QuantifiedGroup NotCircumflexAccent(int exactCount)
        {
            return ConcatInternal(Patterns.NotCircumflexAccent(exactCount));
        }

        public QuantifiedGroup NotCircumflexAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotCircumflexAccent(minCount, maxCount));
        }

        public QuantifiablePattern Underscore()
        {
            return ConcatInternal(Patterns.Underscore());
        }

        public QuantifiedGroup Underscore(int exactCount)
        {
            return ConcatInternal(Patterns.Underscore(exactCount));
        }

        public QuantifiedGroup Underscore(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Underscore(minCount, maxCount));
        }

        public QuantifiablePattern NotUnderscore()
        {
            return ConcatInternal(Patterns.NotUnderscore());
        }

        public QuantifiedGroup NotUnderscore(int exactCount)
        {
            return ConcatInternal(Patterns.NotUnderscore(exactCount));
        }

        public QuantifiedGroup NotUnderscore(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotUnderscore(minCount, maxCount));
        }

        public QuantifiablePattern GraveAccent()
        {
            return ConcatInternal(Patterns.GraveAccent());
        }

        public QuantifiedGroup GraveAccent(int exactCount)
        {
            return ConcatInternal(Patterns.GraveAccent(exactCount));
        }

        public QuantifiedGroup GraveAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.GraveAccent(minCount, maxCount));
        }

        public QuantifiablePattern NotGraveAccent()
        {
            return ConcatInternal(Patterns.NotGraveAccent());
        }

        public QuantifiedGroup NotGraveAccent(int exactCount)
        {
            return ConcatInternal(Patterns.NotGraveAccent(exactCount));
        }

        public QuantifiedGroup NotGraveAccent(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotGraveAccent(minCount, maxCount));
        }

        public QuantifiablePattern LeftCurlyBracket()
        {
            return ConcatInternal(Patterns.LeftCurlyBracket());
        }

        public QuantifiedGroup LeftCurlyBracket(int exactCount)
        {
            return ConcatInternal(Patterns.LeftCurlyBracket(exactCount));
        }

        public QuantifiedGroup LeftCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.LeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiablePattern NotLeftCurlyBracket()
        {
            return ConcatInternal(Patterns.NotLeftCurlyBracket());
        }

        public QuantifiedGroup NotLeftCurlyBracket(int exactCount)
        {
            return ConcatInternal(Patterns.NotLeftCurlyBracket(exactCount));
        }

        public QuantifiedGroup NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotLeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiablePattern VerticalLine()
        {
            return ConcatInternal(Patterns.VerticalLine());
        }

        public QuantifiedGroup VerticalLine(int exactCount)
        {
            return ConcatInternal(Patterns.VerticalLine(exactCount));
        }

        public QuantifiedGroup VerticalLine(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.VerticalLine(minCount, maxCount));
        }

        public QuantifiablePattern NotVerticalLine()
        {
            return ConcatInternal(Patterns.NotVerticalLine());
        }

        public QuantifiedGroup NotVerticalLine(int exactCount)
        {
            return ConcatInternal(Patterns.NotVerticalLine(exactCount));
        }

        public QuantifiedGroup NotVerticalLine(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotVerticalLine(minCount, maxCount));
        }

        public QuantifiablePattern RightCurlyBracket()
        {
            return ConcatInternal(Patterns.RightCurlyBracket());
        }

        public QuantifiedGroup RightCurlyBracket(int exactCount)
        {
            return ConcatInternal(Patterns.RightCurlyBracket(exactCount));
        }

        public QuantifiedGroup RightCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.RightCurlyBracket(minCount, maxCount));
        }

        public QuantifiablePattern NotRightCurlyBracket()
        {
            return ConcatInternal(Patterns.NotRightCurlyBracket());
        }

        public QuantifiedGroup NotRightCurlyBracket(int exactCount)
        {
            return ConcatInternal(Patterns.NotRightCurlyBracket(exactCount));
        }

        public QuantifiedGroup NotRightCurlyBracket(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotRightCurlyBracket(minCount, maxCount));
        }

        public QuantifiablePattern Tilde()
        {
            return ConcatInternal(Patterns.Tilde());
        }

        public QuantifiedGroup Tilde(int exactCount)
        {
            return ConcatInternal(Patterns.Tilde(exactCount));
        }

        public QuantifiedGroup Tilde(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.Tilde(minCount, maxCount));
        }

        public QuantifiablePattern NotTilde()
        {
            return ConcatInternal(Patterns.NotTilde());
        }

        public QuantifiedGroup NotTilde(int exactCount)
        {
            return ConcatInternal(Patterns.NotTilde(exactCount));
        }

        public QuantifiedGroup NotTilde(int minCount, int maxCount)
        {
            return ConcatInternal(Patterns.NotTilde(minCount, maxCount));
        }

        public CharGroup Parenthesis()
        {
            return ConcatInternal(Patterns.Parenthesis());
        }

        public CharGroup NotParenthesis()
        {
            return ConcatInternal(Patterns.NotParenthesis());
        }

        public CharGroup CurlyBracket()
        {
            return ConcatInternal(Patterns.CurlyBracket());
        }

        public CharGroup NotCurlyBracket()
        {
            return ConcatInternal(Patterns.NotCurlyBracket());
        }

        public CharGroup SquareBracket()
        {
            return ConcatInternal(Patterns.SquareBracket());
        }

        public CharGroup NotSquareBracket()
        {
            return ConcatInternal(Patterns.NotSquareBracket());
        }

        public QuantifiedGroup Maybe(object content)
        {
            return ConcatInternal(Patterns.Maybe(content));
        }

        public QuantifiedGroup Maybe(params object[] content)
        {
            return ConcatInternal(Patterns.Maybe(content));
        }

        public QuantifiedGroup MaybeMany(object content)
        {
            return ConcatInternal(Patterns.MaybeMany(content));
        }

        public QuantifiedGroup MaybeMany(params object[] content)
        {
            return ConcatInternal(Patterns.MaybeMany(content));
        }

        public QuantifiedGroup OneMany(object content)
        {
            return ConcatInternal(Patterns.OneMany(content));
        }

        public QuantifiedGroup OneMany(params object[] content)
        {
            return ConcatInternal(Patterns.OneMany(content));
        }

        public QuantifiedGroup Count(int exactCount, object content)
        {
            return ConcatInternal(Patterns.Count(exactCount, content));
        }

        public QuantifiedGroup Count(int minCount, int maxCount, object content)
        {
            return ConcatInternal(Patterns.Count(minCount, maxCount, content));
        }

        public QuantifiedGroup Count(int exactCount, params object[] content)
        {
            return ConcatInternal(Patterns.Count(exactCount, content));
        }

        public QuantifiedGroup Count(int minCount, int maxCount, params object[] content)
        {
            return ConcatInternal(Patterns.Count(minCount, maxCount, content));
        }

        public QuantifiedGroup CountFrom(int minCount, object content)
        {
            return ConcatInternal(Patterns.CountFrom(minCount, content));
        }

        public QuantifiedGroup CountFrom(int minCount, params object[] content)
        {
            return ConcatInternal(Patterns.CountFrom(minCount, content));
        }

        public QuantifiedGroup CountTo(int maxCount, object content)
        {
            return ConcatInternal(Patterns.CountTo(maxCount, content));
        }

        public QuantifiedGroup CountTo(int maxCount, params object[] content)
        {
            return ConcatInternal(Patterns.CountTo(maxCount, content));
        }

        public QuantifiablePattern GroupReference(int groupNumber)
        {
            return ConcatInternal(Patterns.GroupReference(groupNumber));
        }

        public QuantifiablePattern GroupReference(string groupName)
        {
            return ConcatInternal(Patterns.GroupReference(groupName));
        }

        public Pattern Comment(string value)
        {
            return ConcatInternal(Patterns.Comment(value));
        }

        public QuantifiablePattern NewLine()
        {
            return ConcatInternal(Patterns.NewLine());
        }

        public QuantifiablePattern NewLineChar()
        {
            return ConcatInternal(Patterns.NewLineChar());
        }

        public QuantifiablePattern NotNewLineChar()
        {
            return ConcatInternal(Patterns.NotNewLineChar());
        }
    }
}
