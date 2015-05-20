// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator.Linq
{
    public partial class Expression
    {
        public QuantifiableExpression RequireGroup(string groupName)
        {
            RegexUtilities.CheckGroupName(groupName);
            return AppendInternal(Alternations.IfGroup(groupName, new Expression(), Expressions.Never()));
        }

        public QuantifiableExpression RequireGroups(string groupName1, string groupName2)
        {
            return RequireGroup(groupName1).RequireGroup(groupName2);
        }

        public QuantifiableExpression RequireGroups(string groupName1, string groupName2, string groupName3)
        {
            return RequireGroups(groupName1, groupName2).RequireGroup(groupName3);
        }

        public QuantifiableExpression RequireGroup(int groupNumber)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }
            return AppendInternal(Alternations.IfGroup(groupNumber, new Expression(), Expressions.Never()));
        }

        public QuantifiableExpression RequireGroups(int groupNumber1, int groupNumber2)
        {
            return RequireGroup(groupNumber1).RequireGroup(groupNumber2);
        }

        public QuantifiableExpression RequireGroups(int groupNumber1, int groupNumber2, int groupNumber3)
        {
            return RequireGroups(groupNumber1, groupNumber2).RequireGroup(groupNumber3);
        }

        public Expression Surround(Expression expression)
        {
            return Expressions.Surround(this, expression);
        }

        public QuantifiableExpression Any(IEnumerable<Expression> expressions)
        {
            return AppendInternal(Alternations.Any(expressions));
        }

        public QuantifiableExpression Any(params Expression[] expressions)
        {
            return AppendInternal(Alternations.Any(expressions));
        }

        public QuantifiableExpression Any(IEnumerable<string> values)
        {
            return AppendInternal(Alternations.Any(values));
        }

        public QuantifiableExpression Any(params string[] values)
        {
            return AppendInternal(Alternations.Any(values));
        }

        public QuantifiableExpression IfGroup(string groupName, Expression yes)
        {
            return AppendInternal(Alternations.IfGroup(groupName, yes));
        }

        public QuantifiableExpression IfGroup(string groupName, Expression yes, Expression no)
        {
            return AppendInternal(Alternations.IfGroup(groupName, yes, no));
        }

        public QuantifiableExpression IfGroup(string groupName, string yes)
        {
            return AppendInternal(Alternations.IfGroup(groupName, yes));
        }

        public QuantifiableExpression IfGroup(string groupName, string yes, string no)
        {
            return AppendInternal(Alternations.IfGroup(groupName, yes, no));
        }

        public QuantifiableExpression IfGroup(int groupNumber, Expression yes)
        {
            return AppendInternal(Alternations.IfGroup(groupNumber, yes));
        }

        public QuantifiableExpression IfGroup(int groupNumber, Expression yes, Expression no)
        {
            return AppendInternal(Alternations.IfGroup(groupNumber, yes, no));
        }

        public QuantifiableExpression IfGroup(int groupNumber, string yes)
        {
            return AppendInternal(Alternations.IfGroup(groupNumber, yes));
        }

        public QuantifiableExpression IfGroup(int groupNumber, string yes, string no)
        {
            return AppendInternal(Alternations.IfGroup(groupNumber, yes, no));
        }

        public QuantifiableExpression If(Expression condition, Expression yes)
        {
            return AppendInternal(Alternations.If(condition, yes));
        }

        public QuantifiableExpression If(Expression condition, Expression yes, Expression no)
        {
            return AppendInternal(Alternations.If(condition, yes, no));
        }

        public QuantifiableExpression If(Expression condition, string yes)
        {
            return AppendInternal(Alternations.If(condition, yes));
        }

        public QuantifiableExpression If(Expression condition, string yes, string no)
        {
            return AppendInternal(Alternations.If(condition, yes, no));
        }

        public Expression Or()
        {
            return AppendInternal(Alternations.Or());
        }

        public QuantifiableExpression Start()
        {
            return AppendInternal(Anchors.Start());
        }

        public QuantifiableExpression StartOfLine()
        {
            return AppendInternal(Anchors.StartOfLine());
        }

        public QuantifiableExpression StartOfLineInvariant()
        {
            return AppendInternal(Anchors.StartOfLineInvariant());
        }

        public QuantifiableExpression EndOfLine()
        {
            return AppendInternal(Anchors.EndOfLine());
        }

        public QuantifiableExpression EndOfLineInvariant()
        {
            return AppendInternal(Anchors.EndOfLineInvariant());
        }

        public QuantifiableExpression EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true);
        }

        internal QuantifiableExpression EndOfLine(bool beforeCarriageReturn)
        {
            return AppendInternal(Anchors.EndOfLine(beforeCarriageReturn));
        }

        public QuantifiableExpression End()
        {
            return AppendInternal(Anchors.End());
        }

        public QuantifiableExpression EndOrBeforeEndingNewLine()
        {
            return AppendInternal(Anchors.EndOrBeforeEndingNewLine());
        }

        public QuantifiableExpression PreviousMatchEnd()
        {
            return AppendInternal(Anchors.PreviousMatchEnd());
        }

        public QuantifiableExpression WordBoundary()
        {
            return AppendInternal(Anchors.WordBoundary());
        }

        public Expression Word(string text)
        {
            return AppendInternal(Anchors.Word(text));
        }

        public Expression Word(Expression expression)
        {
            return AppendInternal(Anchors.Word(expression));
        }

        public QuantifiableExpression NotWordBoundary()
        {
            return AppendInternal(Anchors.NotWordBoundary());
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

        public QuantifiableExpression Assert(Expression expression)
        {
            return AppendInternal(Anchors.Assert(expression));
        }

        public QuantifiableExpression Assert(string text)
        {
            return AppendInternal(Anchors.Assert(text));
        }

        public QuantifiableExpression Assert(CharGroupItem item)
        {
            return AppendInternal(Anchors.Assert(item));
        }

        public QuantifiableExpression Assert(char value)
        {
            return AppendInternal(Anchors.Assert(value));
        }

        public QuantifiableExpression Assert(int charCode)
        {
            return AppendInternal(Anchors.Assert(charCode));
        }

        public QuantifiableExpression Assert(AsciiChar value)
        {
            return AppendInternal(Anchors.Assert(value));
        }

        public QuantifiableExpression Assert(NamedBlock block)
        {
            return AppendInternal(Anchors.Assert(block));
        }

        public QuantifiableExpression Assert(GeneralCategory category)
        {
            return AppendInternal(Anchors.Assert(category));
        }

        public QuantifiableExpression NotAssert(Expression expression)
        {
            return AppendInternal(Anchors.NotAssert(expression));
        }

        public QuantifiableExpression NotAssert(string text)
        {
            return AppendInternal(Anchors.NotAssert(text));
        }

        public QuantifiableExpression NotAssert(CharGroupItem item)
        {
            return AppendInternal(Anchors.NotAssert(item));
        }

        public QuantifiableExpression NotAssert(char value)
        {
            return AppendInternal(Anchors.NotAssert(value));
        }

        public QuantifiableExpression NotAssert(int charCode)
        {
            return AppendInternal(Anchors.NotAssert(charCode));
        }

        public QuantifiableExpression NotAssert(AsciiChar value)
        {
            return AppendInternal(Anchors.NotAssert(value));
        }

        public QuantifiableExpression NotAssert(NamedBlock block)
        {
            return AppendInternal(Anchors.NotAssert(block));
        }

        public QuantifiableExpression NotAssert(GeneralCategory category)
        {
            return AppendInternal(Anchors.NotAssert(category));
        }

        public QuantifiableExpression AssertBack(Expression expression)
        {
            return AppendInternal(Anchors.AssertBack(expression));
        }

        public QuantifiableExpression AssertBack(string text)
        {
            return AppendInternal(Anchors.AssertBack(text));
        }

        public QuantifiableExpression AssertBack(CharGroupItem item)
        {
            return AppendInternal(Anchors.AssertBack(item));
        }

        public QuantifiableExpression AssertBack(char value)
        {
            return AppendInternal(Anchors.AssertBack(value));
        }

        public QuantifiableExpression AssertBack(int charCodes)
        {
            return AppendInternal(Anchors.AssertBack(charCodes));
        }

        public QuantifiableExpression AssertBack(AsciiChar value)
        {
            return AppendInternal(Anchors.AssertBack(value));
        }

        public QuantifiableExpression AssertBack(NamedBlock block)
        {
            return AppendInternal(Anchors.AssertBack(block));
        }

        public QuantifiableExpression AssertBack(GeneralCategory category)
        {
            return AppendInternal(Anchors.AssertBack(category));
        }

        public QuantifiableExpression NotAssertBack(Expression expression)
        {
            return AppendInternal(Anchors.NotAssertBack(expression));
        }

        public QuantifiableExpression NotAssertBack(string text)
        {
            return AppendInternal(Anchors.NotAssertBack(text));
        }

        public QuantifiableExpression NotAssertBack(CharGroupItem item)
        {
            return AppendInternal(Anchors.NotAssertBack(item));
        }

        public QuantifiableExpression NotAssertBack(char value)
        {
            return AppendInternal(Anchors.NotAssertBack(value));
        }

        public QuantifiableExpression NotAssertBack(int charCode)
        {
            return AppendInternal(Anchors.NotAssertBack(charCode));
        }

        public QuantifiableExpression NotAssertBack(AsciiChar value)
        {
            return AppendInternal(Anchors.NotAssertBack(value));
        }

        public QuantifiableExpression NotAssertBack(NamedBlock block)
        {
            return AppendInternal(Anchors.NotAssertBack(block));
        }

        public QuantifiableExpression NotAssertBack(GeneralCategory category)
        {
            return AppendInternal(Anchors.NotAssertBack(category));
        }

        public QuantifiableExpression AsAssert()
        {
            return Anchors.Assert(this);
        }

        public QuantifiableExpression AsNotAssert()
        {
            return Anchors.NotAssert(this);
        }

        public QuantifiableExpression AsAssertBack()
        {
            return Anchors.AssertBack(this);
        }

        public QuantifiableExpression AsNotAssertBack()
        {
            return Anchors.NotAssertBack(this);
        }

        public QuantifiableExpression NamedGroup(string name, Expression expression)
        {
            return AppendInternal(Groups.NamedGroup(name, expression));
        }

        public QuantifiableExpression NamedGroup(string name, string text)
        {
            return AppendInternal(Groups.NamedGroup(name, text));
        }

        public QuantifiableExpression AsNamedGroup(string name)
        {
            return Groups.NamedGroup(name, this);
        }

        public QuantifiableExpression Subexpression()
        {
            return AppendInternal(Groups.Subexpression());
        }

        public QuantifiableExpression Subexpression(string text)
        {
            return AppendInternal(Groups.Subexpression(text));
        }

        public QuantifiableExpression Subexpression(Expression expression)
        {
            return AppendInternal(Groups.Subexpression(expression));
        }

        public QuantifiableExpression AsSubexpression()
        {
            return Groups.Subexpression(this);
        }

        public QuantifiableExpression Noncapturing(Expression expression)
        {
            return AppendInternal(Groups.Noncapturing(expression));
        }

        public QuantifiableExpression Noncapturing(string text)
        {
            return AppendInternal(Groups.Noncapturing(text));
        }

        public QuantifiableExpression AsNoncapturing()
        {
            return Groups.Noncapturing(this);
        }

        public QuantifiableExpression Nonbacktracking(Expression expression)
        {
            return AppendInternal(Groups.Nonbacktracking(expression));
        }

        public QuantifiableExpression Nonbacktracking(string text)
        {
            return AppendInternal(Groups.Nonbacktracking(text));
        }

        public QuantifiableExpression AsNonbacktracking()
        {
            return Groups.Nonbacktracking(this);
        }

        public QuantifiableExpression Balancing(string name1, string name2, Expression expression)
        {
            return AppendInternal(Groups.Balancing(name1, name2, expression));
        }

        public QuantifiableExpression Balancing(string name1, string name2, string text)
        {
            return AppendInternal(Groups.Balancing(name1, name2, text));
        }

        public QuantifiableExpression AsBalancing(string name1, string name2)
        {
            return Groups.Balancing(name1, name2, this);
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, Expression expression)
        {
            return AppendInternal(Groups.GroupOptions(applyOptions, expression));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, string text)
        {
            return AppendInternal(Groups.GroupOptions(applyOptions, text));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, Expression expression)
        {
            return AppendInternal(Groups.GroupOptions(applyOptions, disableOptions, expression));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string text)
        {
            return AppendInternal(Groups.GroupOptions(applyOptions, disableOptions, text));
        }

        public QuantifiableExpression AsGroupOptions(InlineOptions applyOptions)
        {
            return Groups.GroupOptions(applyOptions, this);
        }

        public QuantifiableExpression AsGroupOptions(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return Groups.GroupOptions(applyOptions, disableOptions, this);
        }

        public QuantifiableExpression Char(string chars)
        {
            return AppendInternal(Chars.Char(chars));
        }

        public QuantifiableExpression Char(CharGroupItem item)
        {
            return AppendInternal(Chars.Char(item));
        }

        public QuantifiableExpression Char(IEnumerable<char> values)
        {
            return AppendInternal(Chars.Char(values));
        }

        public QuantifiableExpression Char(IEnumerable<int> charCodes)
        {
            return AppendInternal(Chars.Char(charCodes));
        }

        public QuantifiableExpression Char(IEnumerable<AsciiChar> values)
        {
            return AppendInternal(Chars.Char(values));
        }

        public QuantifiableExpression Char(IEnumerable<NamedBlock> blocks)
        {
            return AppendInternal(Chars.Char(blocks));
        }

        public QuantifiableExpression Char(IEnumerable<GeneralCategory> categories)
        {
            return AppendInternal(Chars.Char(categories));
        }

        public QuantifiableExpression NotChar(string chars)
        {
            return AppendInternal(Chars.NotChar(chars));
        }

        public QuantifiableExpression NotChar(CharGroupItem item)
        {
            return AppendInternal(Chars.NotChar(item));
        }

        public QuantifiableExpression NotChar(IEnumerable<char> values)
        {
            return AppendInternal(Chars.NotChar(values));
        }

        public QuantifiableExpression NotChar(IEnumerable<int> charCodes)
        {
            return AppendInternal(Chars.NotChar(charCodes));
        }

        public QuantifiableExpression NotChar(IEnumerable<AsciiChar> values)
        {
            return AppendInternal(Chars.NotChar(values));
        }

        public QuantifiableExpression NotChar(IEnumerable<NamedBlock> blocks)
        {
            return AppendInternal(Chars.NotChar(blocks));
        }

        public QuantifiableExpression NotChar(IEnumerable<GeneralCategory> categories)
        {
            return AppendInternal(Chars.NotChar(categories));
        }

        public QuantifiableExpression Range(char first, char last)
        {
            return AppendInternal(Chars.Range(first, last));
        }

        public QuantifiableExpression Range(int firstCharCode, int lastCharCode)
        {
            return AppendInternal(Chars.Range(firstCharCode, lastCharCode));
        }

        public QuantifiableExpression NotRange(char first, char last)
        {
            return AppendInternal(Chars.NotRange(first, last));
        }

        public QuantifiableExpression NotRange(int firstCharCode, int lastCharCode)
        {
            return AppendInternal(Chars.NotRange(firstCharCode, lastCharCode));
        }

        public QuantifiableExpression Subtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return AppendInternal(Chars.Subtract(baseGroup, excludedGroup));
        }

        public QuantifiableExpression NotSubtract(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return AppendInternal(Chars.NotSubtract(baseGroup, excludedGroup));
        }

        public QuantifiableExpression WhiteSpaceExceptNewLine()
        {
            return AppendInternal(Chars.WhiteSpaceExceptNewLine());
        }

        public CharGroupExpression Alphanumeric()
        {
            return AppendInternal(Chars.Alphanumeric());
        }

        public CharGroupExpression NotAlphanumeric()
        {
            return AppendInternal(Chars.NotAlphanumeric());
        }

        public CharGroupExpression AlphanumericUnderscore()
        {
            return AppendInternal(Chars.AlphanumericUnderscore());
        }

        public CharGroupExpression NotAlphanumericUnderscore()
        {
            return AppendInternal(Chars.NotAlphanumericUnderscore());
        }

        public CharGroupExpression LatinLetter()
        {
            return AppendInternal(Chars.LatinLetter());
        }

        public CharGroupExpression LatinLetterLower()
        {
            return AppendInternal(Chars.LatinLetterLower());
        }

        public CharGroupExpression LatinLetterUpper()
        {
            return AppendInternal(Chars.LatinLetterUpper());
        }

        public CharGroupExpression NotLatinLetter()
        {
            return AppendInternal(Chars.NotLatinLetter());
        }

        public CharGroupExpression NotLatinLetterLower()
        {
            return AppendInternal(Chars.NotLatinLetterLower());
        }

        public CharGroupExpression NotLatinLetterUpper()
        {
            return AppendInternal(Chars.NotLatinLetterUpper());
        }

        public QuantifiableExpression Any()
        {
            return AppendInternal(Chars.Any());
        }

        public QuantifiableExpression AnyInvariant()
        {
            return AppendInternal(Chars.AnyInvariant());
        }

        public Expression AnyMaybeManyLazy()
        {
            return AppendInternal(Chars.AnyMaybeManyLazy());
        }

        public QuantifiableExpression ArabicDigit()
        {
            return AppendInternal(Chars.ArabicDigit());
        }

        public QuantifiableExpression NotArabicDigit()
        {
            return AppendInternal(Chars.NotArabicDigit());
        }

        public QuantifiableExpression HexadecimalDigit()
        {
            return AppendInternal(Chars.HexadecimalDigit());
        }

        public QuantifiableExpression NotHexadecimalDigit()
        {
            return AppendInternal(Chars.NotHexadecimalDigit());
        }

        public QuantifiableExpression Digit()
        {
            return AppendInternal(Chars.Digit());
        }

        public QuantifierExpression Digit(int count)
        {
            return AppendInternal(Chars.Digit(count));
        }

        public QuantifierExpression Digit(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Digit(minCount, maxCount));
        }

        public QuantifiableExpression NotDigit()
        {
            return AppendInternal(Chars.NotDigit());
        }

        public QuantifierExpression NotDigit(int count)
        {
            return AppendInternal(Chars.NotDigit(count));
        }

        public QuantifierExpression NotDigit(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotDigit(minCount, maxCount));
        }

        public QuantifiableExpression WhiteSpace()
        {
            return AppendInternal(Chars.WhiteSpace());
        }

        public QuantifierExpression WhiteSpace(int count)
        {
            return AppendInternal(Chars.WhiteSpace(count));
        }

        public QuantifierExpression WhiteSpace(int minCount, int maxCount)
        {
            return AppendInternal(Chars.WhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression NotWhiteSpace()
        {
            return AppendInternal(Chars.NotWhiteSpace());
        }

        public QuantifierExpression NotWhiteSpace(int count)
        {
            return AppendInternal(Chars.NotWhiteSpace(count));
        }

        public QuantifierExpression NotWhiteSpace(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotWhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression WordChar()
        {
            return AppendInternal(Chars.WordChar());
        }

        public QuantifierExpression WordChar(int count)
        {
            return AppendInternal(Chars.WordChar(count));
        }

        public QuantifierExpression WordChar(int minCount, int maxCount)
        {
            return AppendInternal(Chars.WordChar(minCount, maxCount));
        }

        public QuantifiableExpression NotWordChar()
        {
            return AppendInternal(Chars.NotWordChar());
        }

        public QuantifierExpression NotWordChar(int count)
        {
            return AppendInternal(Chars.NotWordChar(count));
        }

        public QuantifierExpression NotWordChar(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotWordChar(minCount, maxCount));
        }

        public QuantifiableExpression Char(char value)
        {
            return AppendInternal(Chars.Char(value));
        }

        public QuantifiableExpression Char(int charCode)
        {
            return AppendInternal(Chars.Char(charCode));
        }

        public QuantifiableExpression Char(AsciiChar value)
        {
            return AppendInternal(Chars.Char(value));
        }

        public QuantifiableExpression NamedBlock(NamedBlock block)
        {
            return AppendInternal(Chars.NamedBlock(block));
        }

        public QuantifiableExpression GeneralCategory(GeneralCategory category)
        {
            return AppendInternal(Chars.GeneralCategory(category));
        }

        public QuantifiableExpression NotChar(char value)
        {
            return AppendInternal(Chars.NotChar(value));
        }

        public QuantifiableExpression NotChar(int charCode)
        {
            return AppendInternal(Chars.NotChar(charCode));
        }

        public QuantifiableExpression NotChar(AsciiChar value)
        {
            return AppendInternal(Chars.NotChar(value));
        }

        public QuantifiableExpression NotNamedBlock(NamedBlock block)
        {
            return AppendInternal(Chars.NotNamedBlock(block));
        }

        public QuantifiableExpression NotGeneralCategory(GeneralCategory category)
        {
            return AppendInternal(Chars.NotGeneralCategory(category));
        }

        public QuantifiableExpression Tab()
        {
            return AppendInternal(Chars.Tab());
        }

        public QuantifierExpression Tab(int exactCount)
        {
            return AppendInternal(Chars.Tab(exactCount));
        }

        public QuantifierExpression Tab(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Tab(minCount, maxCount));
        }

        public QuantifiableExpression NotTab()
        {
            return AppendInternal(Chars.NotTab());
        }

        public QuantifierExpression NotTab(int exactCount)
        {
            return AppendInternal(Chars.NotTab(exactCount));
        }

        public QuantifierExpression NotTab(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotTab(minCount, maxCount));
        }

        public QuantifiableExpression Linefeed()
        {
            return AppendInternal(Chars.Linefeed());
        }

        public QuantifierExpression Linefeed(int exactCount)
        {
            return AppendInternal(Chars.Linefeed(exactCount));
        }

        public QuantifierExpression Linefeed(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Linefeed(minCount, maxCount));
        }

        public QuantifiableExpression NotLinefeed()
        {
            return AppendInternal(Chars.NotLinefeed());
        }

        public QuantifierExpression NotLinefeed(int exactCount)
        {
            return AppendInternal(Chars.NotLinefeed(exactCount));
        }

        public QuantifierExpression NotLinefeed(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotLinefeed(minCount, maxCount));
        }

        public QuantifiableExpression CarriageReturn()
        {
            return AppendInternal(Chars.CarriageReturn());
        }

        public QuantifierExpression CarriageReturn(int exactCount)
        {
            return AppendInternal(Chars.CarriageReturn(exactCount));
        }

        public QuantifierExpression CarriageReturn(int minCount, int maxCount)
        {
            return AppendInternal(Chars.CarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression NotCarriageReturn()
        {
            return AppendInternal(Chars.NotCarriageReturn());
        }

        public QuantifierExpression NotCarriageReturn(int exactCount)
        {
            return AppendInternal(Chars.NotCarriageReturn(exactCount));
        }

        public QuantifierExpression NotCarriageReturn(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotCarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression Space()
        {
            return AppendInternal(Chars.Space());
        }

        public QuantifierExpression Space(int exactCount)
        {
            return AppendInternal(Chars.Space(exactCount));
        }

        public QuantifierExpression Space(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Space(minCount, maxCount));
        }

        public QuantifiableExpression NotSpace()
        {
            return AppendInternal(Chars.NotSpace());
        }

        public QuantifierExpression NotSpace(int exactCount)
        {
            return AppendInternal(Chars.NotSpace(exactCount));
        }

        public QuantifierExpression NotSpace(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotSpace(minCount, maxCount));
        }

        public QuantifiableExpression ExclamationMark()
        {
            return AppendInternal(Chars.ExclamationMark());
        }

        public QuantifierExpression ExclamationMark(int exactCount)
        {
            return AppendInternal(Chars.ExclamationMark(exactCount));
        }

        public QuantifierExpression ExclamationMark(int minCount, int maxCount)
        {
            return AppendInternal(Chars.ExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotExclamationMark()
        {
            return AppendInternal(Chars.NotExclamationMark());
        }

        public QuantifierExpression NotExclamationMark(int exactCount)
        {
            return AppendInternal(Chars.NotExclamationMark(exactCount));
        }

        public QuantifierExpression NotExclamationMark(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression QuoteMark()
        {
            return AppendInternal(Chars.QuoteMark());
        }

        public QuantifierExpression QuoteMark(int exactCount)
        {
            return AppendInternal(Chars.QuoteMark(exactCount));
        }

        public QuantifierExpression QuoteMark(int minCount, int maxCount)
        {
            return AppendInternal(Chars.QuoteMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuoteMark()
        {
            return AppendInternal(Chars.NotQuoteMark());
        }

        public QuantifierExpression NotQuoteMark(int exactCount)
        {
            return AppendInternal(Chars.NotQuoteMark(exactCount));
        }

        public QuantifierExpression NotQuoteMark(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotQuoteMark(minCount, maxCount));
        }

        public QuantifiableExpression NumberSign()
        {
            return AppendInternal(Chars.NumberSign());
        }

        public QuantifierExpression NumberSign(int exactCount)
        {
            return AppendInternal(Chars.NumberSign(exactCount));
        }

        public QuantifierExpression NumberSign(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NumberSign(minCount, maxCount));
        }

        public QuantifiableExpression NotNumberSign()
        {
            return AppendInternal(Chars.NotNumberSign());
        }

        public QuantifierExpression NotNumberSign(int exactCount)
        {
            return AppendInternal(Chars.NotNumberSign(exactCount));
        }

        public QuantifierExpression NotNumberSign(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotNumberSign(minCount, maxCount));
        }

        public QuantifiableExpression Dollar()
        {
            return AppendInternal(Chars.Dollar());
        }

        public QuantifierExpression Dollar(int exactCount)
        {
            return AppendInternal(Chars.Dollar(exactCount));
        }

        public QuantifierExpression Dollar(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Dollar(minCount, maxCount));
        }

        public QuantifiableExpression NotDollar()
        {
            return AppendInternal(Chars.NotDollar());
        }

        public QuantifierExpression NotDollar(int exactCount)
        {
            return AppendInternal(Chars.NotDollar(exactCount));
        }

        public QuantifierExpression NotDollar(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotDollar(minCount, maxCount));
        }

        public QuantifiableExpression Percent()
        {
            return AppendInternal(Chars.Percent());
        }

        public QuantifierExpression Percent(int exactCount)
        {
            return AppendInternal(Chars.Percent(exactCount));
        }

        public QuantifierExpression Percent(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Percent(minCount, maxCount));
        }

        public QuantifiableExpression NotPercent()
        {
            return AppendInternal(Chars.NotPercent());
        }

        public QuantifierExpression NotPercent(int exactCount)
        {
            return AppendInternal(Chars.NotPercent(exactCount));
        }

        public QuantifierExpression NotPercent(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotPercent(minCount, maxCount));
        }

        public QuantifiableExpression Ampersand()
        {
            return AppendInternal(Chars.Ampersand());
        }

        public QuantifierExpression Ampersand(int exactCount)
        {
            return AppendInternal(Chars.Ampersand(exactCount));
        }

        public QuantifierExpression Ampersand(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Ampersand(minCount, maxCount));
        }

        public QuantifiableExpression NotAmpersand()
        {
            return AppendInternal(Chars.NotAmpersand());
        }

        public QuantifierExpression NotAmpersand(int exactCount)
        {
            return AppendInternal(Chars.NotAmpersand(exactCount));
        }

        public QuantifierExpression NotAmpersand(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotAmpersand(minCount, maxCount));
        }

        public QuantifiableExpression Apostrophe()
        {
            return AppendInternal(Chars.Apostrophe());
        }

        public QuantifierExpression Apostrophe(int exactCount)
        {
            return AppendInternal(Chars.Apostrophe(exactCount));
        }

        public QuantifierExpression Apostrophe(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Apostrophe(minCount, maxCount));
        }

        public QuantifiableExpression NotApostrophe()
        {
            return AppendInternal(Chars.NotApostrophe());
        }

        public QuantifierExpression NotApostrophe(int exactCount)
        {
            return AppendInternal(Chars.NotApostrophe(exactCount));
        }

        public QuantifierExpression NotApostrophe(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotApostrophe(minCount, maxCount));
        }

        public QuantifiableExpression LeftParenthesis()
        {
            return AppendInternal(Chars.LeftParenthesis());
        }

        public QuantifierExpression LeftParenthesis(int exactCount)
        {
            return AppendInternal(Chars.LeftParenthesis(exactCount));
        }

        public QuantifierExpression LeftParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Chars.LeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftParenthesis()
        {
            return AppendInternal(Chars.NotLeftParenthesis());
        }

        public QuantifierExpression NotLeftParenthesis(int exactCount)
        {
            return AppendInternal(Chars.NotLeftParenthesis(exactCount));
        }

        public QuantifierExpression NotLeftParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotLeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression RightParenthesis()
        {
            return AppendInternal(Chars.RightParenthesis());
        }

        public QuantifierExpression RightParenthesis(int exactCount)
        {
            return AppendInternal(Chars.RightParenthesis(exactCount));
        }

        public QuantifierExpression RightParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Chars.RightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotRightParenthesis()
        {
            return AppendInternal(Chars.NotRightParenthesis());
        }

        public QuantifierExpression NotRightParenthesis(int exactCount)
        {
            return AppendInternal(Chars.NotRightParenthesis(exactCount));
        }

        public QuantifierExpression NotRightParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotRightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression Asterisk()
        {
            return AppendInternal(Chars.Asterisk());
        }

        public QuantifierExpression Asterisk(int exactCount)
        {
            return AppendInternal(Chars.Asterisk(exactCount));
        }

        public QuantifierExpression Asterisk(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Asterisk(minCount, maxCount));
        }

        public QuantifiableExpression NotAsterisk()
        {
            return AppendInternal(Chars.NotAsterisk());
        }

        public QuantifierExpression NotAsterisk(int exactCount)
        {
            return AppendInternal(Chars.NotAsterisk(exactCount));
        }

        public QuantifierExpression NotAsterisk(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotAsterisk(minCount, maxCount));
        }

        public QuantifiableExpression Plus()
        {
            return AppendInternal(Chars.Plus());
        }

        public QuantifierExpression Plus(int exactCount)
        {
            return AppendInternal(Chars.Plus(exactCount));
        }

        public QuantifierExpression Plus(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Plus(minCount, maxCount));
        }

        public QuantifiableExpression NotPlus()
        {
            return AppendInternal(Chars.NotPlus());
        }

        public QuantifierExpression NotPlus(int exactCount)
        {
            return AppendInternal(Chars.NotPlus(exactCount));
        }

        public QuantifierExpression NotPlus(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotPlus(minCount, maxCount));
        }

        public QuantifiableExpression Comma()
        {
            return AppendInternal(Chars.Comma());
        }

        public QuantifierExpression Comma(int exactCount)
        {
            return AppendInternal(Chars.Comma(exactCount));
        }

        public QuantifierExpression Comma(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Comma(minCount, maxCount));
        }

        public QuantifiableExpression NotComma()
        {
            return AppendInternal(Chars.NotComma());
        }

        public QuantifierExpression NotComma(int exactCount)
        {
            return AppendInternal(Chars.NotComma(exactCount));
        }

        public QuantifierExpression NotComma(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotComma(minCount, maxCount));
        }

        public QuantifiableExpression Hyphen()
        {
            return AppendInternal(Chars.Hyphen());
        }

        public QuantifierExpression Hyphen(int exactCount)
        {
            return AppendInternal(Chars.Hyphen(exactCount));
        }

        public QuantifierExpression Hyphen(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Hyphen(minCount, maxCount));
        }

        public QuantifiableExpression NotHyphen()
        {
            return AppendInternal(Chars.NotHyphen());
        }

        public QuantifierExpression NotHyphen(int exactCount)
        {
            return AppendInternal(Chars.NotHyphen(exactCount));
        }

        public QuantifierExpression NotHyphen(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotHyphen(minCount, maxCount));
        }

        public QuantifiableExpression Period()
        {
            return AppendInternal(Chars.Period());
        }

        public QuantifierExpression Period(int exactCount)
        {
            return AppendInternal(Chars.Period(exactCount));
        }

        public QuantifierExpression Period(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Period(minCount, maxCount));
        }

        public QuantifiableExpression NotPeriod()
        {
            return AppendInternal(Chars.NotPeriod());
        }

        public QuantifierExpression NotPeriod(int exactCount)
        {
            return AppendInternal(Chars.NotPeriod(exactCount));
        }

        public QuantifierExpression NotPeriod(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotPeriod(minCount, maxCount));
        }

        public QuantifiableExpression Slash()
        {
            return AppendInternal(Chars.Slash());
        }

        public QuantifierExpression Slash(int exactCount)
        {
            return AppendInternal(Chars.Slash(exactCount));
        }

        public QuantifierExpression Slash(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Slash(minCount, maxCount));
        }

        public QuantifiableExpression NotSlash()
        {
            return AppendInternal(Chars.NotSlash());
        }

        public QuantifierExpression NotSlash(int exactCount)
        {
            return AppendInternal(Chars.NotSlash(exactCount));
        }

        public QuantifierExpression NotSlash(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotSlash(minCount, maxCount));
        }

        public QuantifiableExpression Colon()
        {
            return AppendInternal(Chars.Colon());
        }

        public QuantifierExpression Colon(int exactCount)
        {
            return AppendInternal(Chars.Colon(exactCount));
        }

        public QuantifierExpression Colon(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Colon(minCount, maxCount));
        }

        public QuantifiableExpression NotColon()
        {
            return AppendInternal(Chars.NotColon());
        }

        public QuantifierExpression NotColon(int exactCount)
        {
            return AppendInternal(Chars.NotColon(exactCount));
        }

        public QuantifierExpression NotColon(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotColon(minCount, maxCount));
        }

        public QuantifiableExpression Semicolon()
        {
            return AppendInternal(Chars.Semicolon());
        }

        public QuantifierExpression Semicolon(int exactCount)
        {
            return AppendInternal(Chars.Semicolon(exactCount));
        }

        public QuantifierExpression Semicolon(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Semicolon(minCount, maxCount));
        }

        public QuantifiableExpression NotSemicolon()
        {
            return AppendInternal(Chars.NotSemicolon());
        }

        public QuantifierExpression NotSemicolon(int exactCount)
        {
            return AppendInternal(Chars.NotSemicolon(exactCount));
        }

        public QuantifierExpression NotSemicolon(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotSemicolon(minCount, maxCount));
        }

        public QuantifiableExpression LessThan()
        {
            return AppendInternal(Chars.LessThan());
        }

        public QuantifierExpression LessThan(int exactCount)
        {
            return AppendInternal(Chars.LessThan(exactCount));
        }

        public QuantifierExpression LessThan(int minCount, int maxCount)
        {
            return AppendInternal(Chars.LessThan(minCount, maxCount));
        }

        public QuantifiableExpression NotLessThan()
        {
            return AppendInternal(Chars.NotLessThan());
        }

        public QuantifierExpression NotLessThan(int exactCount)
        {
            return AppendInternal(Chars.NotLessThan(exactCount));
        }

        public QuantifierExpression NotLessThan(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotLessThan(minCount, maxCount));
        }

        public QuantifiableExpression EqualsSign()
        {
            return AppendInternal(Chars.EqualsSign());
        }

        public QuantifierExpression EqualsSign(int exactCount)
        {
            return AppendInternal(Chars.EqualsSign(exactCount));
        }

        public QuantifierExpression EqualsSign(int minCount, int maxCount)
        {
            return AppendInternal(Chars.EqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression NotEqualsSign()
        {
            return AppendInternal(Chars.NotEqualsSign());
        }

        public QuantifierExpression NotEqualsSign(int exactCount)
        {
            return AppendInternal(Chars.NotEqualsSign(exactCount));
        }

        public QuantifierExpression NotEqualsSign(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotEqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression GreaterThan()
        {
            return AppendInternal(Chars.GreaterThan());
        }

        public QuantifierExpression GreaterThan(int exactCount)
        {
            return AppendInternal(Chars.GreaterThan(exactCount));
        }

        public QuantifierExpression GreaterThan(int minCount, int maxCount)
        {
            return AppendInternal(Chars.GreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression NotGreaterThan()
        {
            return AppendInternal(Chars.NotGreaterThan());
        }

        public QuantifierExpression NotGreaterThan(int exactCount)
        {
            return AppendInternal(Chars.NotGreaterThan(exactCount));
        }

        public QuantifierExpression NotGreaterThan(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotGreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression QuestionMark()
        {
            return AppendInternal(Chars.QuestionMark());
        }

        public QuantifierExpression QuestionMark(int exactCount)
        {
            return AppendInternal(Chars.QuestionMark(exactCount));
        }

        public QuantifierExpression QuestionMark(int minCount, int maxCount)
        {
            return AppendInternal(Chars.QuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuestionMark()
        {
            return AppendInternal(Chars.NotQuestionMark());
        }

        public QuantifierExpression NotQuestionMark(int exactCount)
        {
            return AppendInternal(Chars.NotQuestionMark(exactCount));
        }

        public QuantifierExpression NotQuestionMark(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotQuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression At()
        {
            return AppendInternal(Chars.At());
        }

        public QuantifierExpression At(int exactCount)
        {
            return AppendInternal(Chars.At(exactCount));
        }

        public QuantifierExpression At(int minCount, int maxCount)
        {
            return AppendInternal(Chars.At(minCount, maxCount));
        }

        public QuantifiableExpression NotAt()
        {
            return AppendInternal(Chars.NotAt());
        }

        public QuantifierExpression NotAt(int exactCount)
        {
            return AppendInternal(Chars.NotAt(exactCount));
        }

        public QuantifierExpression NotAt(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotAt(minCount, maxCount));
        }

        public QuantifiableExpression LeftSquareBracket()
        {
            return AppendInternal(Chars.LeftSquareBracket());
        }

        public QuantifierExpression LeftSquareBracket(int exactCount)
        {
            return AppendInternal(Chars.LeftSquareBracket(exactCount));
        }

        public QuantifierExpression LeftSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Chars.LeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftSquareBracket()
        {
            return AppendInternal(Chars.NotLeftSquareBracket());
        }

        public QuantifierExpression NotLeftSquareBracket(int exactCount)
        {
            return AppendInternal(Chars.NotLeftSquareBracket(exactCount));
        }

        public QuantifierExpression NotLeftSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotLeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression Backslash()
        {
            return AppendInternal(Chars.Backslash());
        }

        public QuantifierExpression Backslash(int exactCount)
        {
            return AppendInternal(Chars.Backslash(exactCount));
        }

        public QuantifierExpression Backslash(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Backslash(minCount, maxCount));
        }

        public QuantifiableExpression NotBackslash()
        {
            return AppendInternal(Chars.NotBackslash());
        }

        public QuantifierExpression NotBackslash(int exactCount)
        {
            return AppendInternal(Chars.NotBackslash(exactCount));
        }

        public QuantifierExpression NotBackslash(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotBackslash(minCount, maxCount));
        }

        public QuantifiableExpression RightSquareBracket()
        {
            return AppendInternal(Chars.RightSquareBracket());
        }

        public QuantifierExpression RightSquareBracket(int exactCount)
        {
            return AppendInternal(Chars.RightSquareBracket(exactCount));
        }

        public QuantifierExpression RightSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Chars.RightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightSquareBracket()
        {
            return AppendInternal(Chars.NotRightSquareBracket());
        }

        public QuantifierExpression NotRightSquareBracket(int exactCount)
        {
            return AppendInternal(Chars.NotRightSquareBracket(exactCount));
        }

        public QuantifierExpression NotRightSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotRightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression CircumflexAccent()
        {
            return AppendInternal(Chars.CircumflexAccent());
        }

        public QuantifierExpression CircumflexAccent(int exactCount)
        {
            return AppendInternal(Chars.CircumflexAccent(exactCount));
        }

        public QuantifierExpression CircumflexAccent(int minCount, int maxCount)
        {
            return AppendInternal(Chars.CircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotCircumflexAccent()
        {
            return AppendInternal(Chars.NotCircumflexAccent());
        }

        public QuantifierExpression NotCircumflexAccent(int exactCount)
        {
            return AppendInternal(Chars.NotCircumflexAccent(exactCount));
        }

        public QuantifierExpression NotCircumflexAccent(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotCircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression Underscore()
        {
            return AppendInternal(Chars.Underscore());
        }

        public QuantifierExpression Underscore(int exactCount)
        {
            return AppendInternal(Chars.Underscore(exactCount));
        }

        public QuantifierExpression Underscore(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Underscore(minCount, maxCount));
        }

        public QuantifiableExpression NotUnderscore()
        {
            return AppendInternal(Chars.NotUnderscore());
        }

        public QuantifierExpression NotUnderscore(int exactCount)
        {
            return AppendInternal(Chars.NotUnderscore(exactCount));
        }

        public QuantifierExpression NotUnderscore(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotUnderscore(minCount, maxCount));
        }

        public QuantifiableExpression GraveAccent()
        {
            return AppendInternal(Chars.GraveAccent());
        }

        public QuantifierExpression GraveAccent(int exactCount)
        {
            return AppendInternal(Chars.GraveAccent(exactCount));
        }

        public QuantifierExpression GraveAccent(int minCount, int maxCount)
        {
            return AppendInternal(Chars.GraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotGraveAccent()
        {
            return AppendInternal(Chars.NotGraveAccent());
        }

        public QuantifierExpression NotGraveAccent(int exactCount)
        {
            return AppendInternal(Chars.NotGraveAccent(exactCount));
        }

        public QuantifierExpression NotGraveAccent(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotGraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression LeftCurlyBracket()
        {
            return AppendInternal(Chars.LeftCurlyBracket());
        }

        public QuantifierExpression LeftCurlyBracket(int exactCount)
        {
            return AppendInternal(Chars.LeftCurlyBracket(exactCount));
        }

        public QuantifierExpression LeftCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Chars.LeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftCurlyBracket()
        {
            return AppendInternal(Chars.NotLeftCurlyBracket());
        }

        public QuantifierExpression NotLeftCurlyBracket(int exactCount)
        {
            return AppendInternal(Chars.NotLeftCurlyBracket(exactCount));
        }

        public QuantifierExpression NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotLeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression VerticalLine()
        {
            return AppendInternal(Chars.VerticalLine());
        }

        public QuantifierExpression VerticalLine(int exactCount)
        {
            return AppendInternal(Chars.VerticalLine(exactCount));
        }

        public QuantifierExpression VerticalLine(int minCount, int maxCount)
        {
            return AppendInternal(Chars.VerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression NotVerticalLine()
        {
            return AppendInternal(Chars.NotVerticalLine());
        }

        public QuantifierExpression NotVerticalLine(int exactCount)
        {
            return AppendInternal(Chars.NotVerticalLine(exactCount));
        }

        public QuantifierExpression NotVerticalLine(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotVerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression RightCurlyBracket()
        {
            return AppendInternal(Chars.RightCurlyBracket());
        }

        public QuantifierExpression RightCurlyBracket(int exactCount)
        {
            return AppendInternal(Chars.RightCurlyBracket(exactCount));
        }

        public QuantifierExpression RightCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Chars.RightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightCurlyBracket()
        {
            return AppendInternal(Chars.NotRightCurlyBracket());
        }

        public QuantifierExpression NotRightCurlyBracket(int exactCount)
        {
            return AppendInternal(Chars.NotRightCurlyBracket(exactCount));
        }

        public QuantifierExpression NotRightCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotRightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression Tilde()
        {
            return AppendInternal(Chars.Tilde());
        }

        public QuantifierExpression Tilde(int exactCount)
        {
            return AppendInternal(Chars.Tilde(exactCount));
        }

        public QuantifierExpression Tilde(int minCount, int maxCount)
        {
            return AppendInternal(Chars.Tilde(minCount, maxCount));
        }

        public QuantifiableExpression NotTilde()
        {
            return AppendInternal(Chars.NotTilde());
        }

        public QuantifierExpression NotTilde(int exactCount)
        {
            return AppendInternal(Chars.NotTilde(exactCount));
        }

        public QuantifierExpression NotTilde(int minCount, int maxCount)
        {
            return AppendInternal(Chars.NotTilde(minCount, maxCount));
        }

        public QuantifiableExpression Parentheses()
        {
            return AppendInternal(Chars.Parentheses());
        }

        public QuantifiableExpression NotParentheses()
        {
            return AppendInternal(Chars.NotParentheses());
        }

        public QuantifiableExpression CurlyBrackets()
        {
            return AppendInternal(Chars.CurlyBrackets());
        }

        public QuantifiableExpression NotCurlyBrackets()
        {
            return AppendInternal(Chars.NotCurlyBrackets());
        }

        public QuantifiableExpression SquareBrackets()
        {
            return AppendInternal(Chars.SquareBrackets());
        }

        public QuantifiableExpression NotSquareBrackets()
        {
            return AppendInternal(Chars.NotSquareBrackets());
        }

        public QuantifierExpression Maybe(string text)
        {
            return AppendInternal(Groups.Maybe(text));
        }

        public QuantifierExpression Maybe(Expression expression)
        {
            return AppendInternal(Groups.Maybe(expression));
        }

        public QuantifierExpression MaybeMany(string text)
        {
            return AppendInternal(Groups.MaybeMany(text));
        }

        public QuantifierExpression MaybeMany(Expression expression)
        {
            return AppendInternal(Groups.MaybeMany(expression));
        }

        public QuantifierExpression OneMany(string text)
        {
            return AppendInternal(Groups.OneMany(text));
        }

        public QuantifierExpression OneMany(Expression expression)
        {
            return AppendInternal(Groups.OneMany(expression));
        }

        public QuantifiableExpression Backreference(int groupNumber)
        {
            return AppendInternal(Miscellaneous.Backreference(groupNumber));
        }

        public QuantifiableExpression Backreference(string groupName)
        {
            return AppendInternal(Miscellaneous.Backreference(groupName));
        }

        public Expression Options(InlineOptions applyOptions)
        {
            return AppendInternal(Miscellaneous.Options(applyOptions));
        }

        public Expression Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return AppendInternal(Miscellaneous.Options(applyOptions, disableOptions));
        }

        public Expression Comment(string value)
        {
            return AppendInternal(Miscellaneous.Comment(value));
        }

        public QuantifiableExpression NewLine()
        {
            return AppendInternal(Expressions.NewLine());
        }

        public QuantifiableExpression NewLineChar()
        {
            return AppendInternal(Chars.NewLineChar());
        }

        public QuantifiableExpression NotNewLineChar()
        {
            return AppendInternal(Chars.NotNewLineChar());
        }

        public Expression Text(string value)
        {
            return AppendInternal(Expressions.Text(value));
        }
    }
}
