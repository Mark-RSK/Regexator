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

        public QuantifiableExpression DisallowGroups(string groupName1, string groupName2)
        {
            return DisallowGroup(groupName1).DisallowGroup(groupName2);
        }

        public QuantifiableExpression DisallowGroups(string groupName1, string groupName2, string groupName3)
        {
            return DisallowGroups(groupName1, groupName2).DisallowGroup(groupName3);
        }

        public QuantifiableExpression DisallowGroup(int groupNumber)
        {
            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }
            return ConcatInternal(Alternations.IfGroup(groupNumber, Expressions.Never()));
        }

        public QuantifiableExpression DisallowGroups(int groupNumber1, int groupNumber2)
        {
            return DisallowGroup(groupNumber1).DisallowGroup(groupNumber2);
        }

        public QuantifiableExpression DisallowGroups(int groupNumber1, int groupNumber2, int groupNumber3)
        {
            return DisallowGroups(groupNumber1, groupNumber2).DisallowGroup(groupNumber3);
        }

        public QuantifiableExpression RequireGroup(string groupName)
        {
            RegexUtilities.CheckGroupName(groupName);
            return ConcatInternal(Alternations.IfGroup(groupName, new Expression(), Expressions.Never()));
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
            return ConcatInternal(Alternations.IfGroup(groupNumber, new Expression(), Expressions.Never()));
        }

        public QuantifiableExpression RequireGroups(int groupNumber1, int groupNumber2)
        {
            return RequireGroup(groupNumber1).RequireGroup(groupNumber2);
        }

        public QuantifiableExpression RequireGroups(int groupNumber1, int groupNumber2, int groupNumber3)
        {
            return RequireGroups(groupNumber1, groupNumber2).RequireGroup(groupNumber3);
        }

        public QuantifiableExpression Any(IEnumerable<Expression> expressions)
        {
            return ConcatInternal(Alternations.Any(expressions));
        }

        public QuantifiableExpression Any(params Expression[] expressions)
        {
            return ConcatInternal(Alternations.Any(expressions));
        }

        public QuantifiableExpression Any(IEnumerable<string> values)
        {
            return ConcatInternal(Alternations.Any(values));
        }

        public QuantifiableExpression Any(params string[] values)
        {
            return ConcatInternal(Alternations.Any(values));
        }

        public QuantifiableExpression IfGroup(string groupName, Expression yes)
        {
            return ConcatInternal(Alternations.IfGroup(groupName, yes));
        }

        public QuantifiableExpression IfGroup(string groupName, Expression yes, Expression no)
        {
            return ConcatInternal(Alternations.IfGroup(groupName, yes, no));
        }

        public QuantifiableExpression IfGroup(string groupName, string yes)
        {
            return ConcatInternal(Alternations.IfGroup(groupName, yes));
        }

        public QuantifiableExpression IfGroup(string groupName, string yes, string no)
        {
            return ConcatInternal(Alternations.IfGroup(groupName, yes, no));
        }

        public QuantifiableExpression IfGroup(int groupNumber, Expression yes)
        {
            return ConcatInternal(Alternations.IfGroup(groupNumber, yes));
        }

        public QuantifiableExpression IfGroup(int groupNumber, Expression yes, Expression no)
        {
            return ConcatInternal(Alternations.IfGroup(groupNumber, yes, no));
        }

        public QuantifiableExpression IfGroup(int groupNumber, string yes)
        {
            return ConcatInternal(Alternations.IfGroup(groupNumber, yes));
        }

        public QuantifiableExpression IfGroup(int groupNumber, string yes, string no)
        {
            return ConcatInternal(Alternations.IfGroup(groupNumber, yes, no));
        }

        public QuantifiableExpression If(Expression condition, Expression yes)
        {
            return ConcatInternal(Alternations.If(condition, yes));
        }

        public QuantifiableExpression If(Expression condition, Expression yes, Expression no)
        {
            return ConcatInternal(Alternations.If(condition, yes, no));
        }

        public QuantifiableExpression If(Expression condition, string yes)
        {
            return ConcatInternal(Alternations.If(condition, yes));
        }

        public QuantifiableExpression If(Expression condition, string yes, string no)
        {
            return ConcatInternal(Alternations.If(condition, yes, no));
        }

        public Expression Or()
        {
            return ConcatInternal(Alternations.Or());
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

        public QuantifiableExpression End()
        {
            return ConcatInternal(Anchors.End());
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

        public Expression Word(string text)
        {
            return ConcatInternal(Anchors.Word(text));
        }

        public Expression Word(Expression expression)
        {
            return ConcatInternal(Anchors.Word(expression));
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

        public QuantifiableExpression Assert(Expression expression)
        {
            return ConcatInternal(Anchors.Assert(expression));
        }

        public QuantifiableExpression Assert(string text)
        {
            return ConcatInternal(Anchors.Assert(text));
        }

        public QuantifiableExpression Assert(params Expression[] expressions)
        {
            return ConcatInternal(Anchors.Assert(expressions));
        }

        public QuantifiableExpression Assert(params string[] values)
        {
            return ConcatInternal(Anchors.Assert(values));
        }

        public QuantifiableExpression Assert(CharGroupItem item)
        {
            return ConcatInternal(Anchors.Assert(item));
        }

        public QuantifiableExpression Assert(char value)
        {
            return ConcatInternal(Anchors.Assert(value));
        }

        public QuantifiableExpression Assert(int charCode)
        {
            return ConcatInternal(Anchors.Assert(charCode));
        }

        public QuantifiableExpression Assert(AsciiChar value)
        {
            return ConcatInternal(Anchors.Assert(value));
        }

        public QuantifiableExpression Assert(NamedBlock block)
        {
            return ConcatInternal(Anchors.Assert(block));
        }

        public QuantifiableExpression Assert(GeneralCategory category)
        {
            return ConcatInternal(Anchors.Assert(category));
        }

        public QuantifiableExpression NotAssert(Expression expression)
        {
            return ConcatInternal(Anchors.NotAssert(expression));
        }

        public QuantifiableExpression NotAssert(string text)
        {
            return ConcatInternal(Anchors.NotAssert(text));
        }

        public QuantifiableExpression NotAssert(params Expression[] expressions)
        {
            return ConcatInternal(Anchors.NotAssert(expressions));
        }

        public QuantifiableExpression NotAssert(params string[] values)
        {
            return ConcatInternal(Anchors.NotAssert(values));
        }

        public QuantifiableExpression NotAssert(CharGroupItem item)
        {
            return ConcatInternal(Anchors.NotAssert(item));
        }

        public QuantifiableExpression NotAssert(char value)
        {
            return ConcatInternal(Anchors.NotAssert(value));
        }

        public QuantifiableExpression NotAssert(int charCode)
        {
            return ConcatInternal(Anchors.NotAssert(charCode));
        }

        public QuantifiableExpression NotAssert(AsciiChar value)
        {
            return ConcatInternal(Anchors.NotAssert(value));
        }

        public QuantifiableExpression NotAssert(NamedBlock block)
        {
            return ConcatInternal(Anchors.NotAssert(block));
        }

        public QuantifiableExpression NotAssert(GeneralCategory category)
        {
            return ConcatInternal(Anchors.NotAssert(category));
        }

        public QuantifiableExpression AssertBack(Expression expression)
        {
            return ConcatInternal(Anchors.AssertBack(expression));
        }

        public QuantifiableExpression AssertBack(string text)
        {
            return ConcatInternal(Anchors.AssertBack(text));
        }

        public QuantifiableExpression AssertBack(params Expression[] expressions)
        {
            return ConcatInternal(Anchors.AssertBack(expressions));
        }

        public QuantifiableExpression AssertBack(params string[] values)
        {
            return ConcatInternal(Anchors.AssertBack(values));
        }

        public QuantifiableExpression AssertBack(CharGroupItem item)
        {
            return ConcatInternal(Anchors.AssertBack(item));
        }

        public QuantifiableExpression AssertBack(char value)
        {
            return ConcatInternal(Anchors.AssertBack(value));
        }

        public QuantifiableExpression AssertBack(int charCodes)
        {
            return ConcatInternal(Anchors.AssertBack(charCodes));
        }

        public QuantifiableExpression AssertBack(AsciiChar value)
        {
            return ConcatInternal(Anchors.AssertBack(value));
        }

        public QuantifiableExpression AssertBack(NamedBlock block)
        {
            return ConcatInternal(Anchors.AssertBack(block));
        }

        public QuantifiableExpression AssertBack(GeneralCategory category)
        {
            return ConcatInternal(Anchors.AssertBack(category));
        }

        public QuantifiableExpression NotAssertBack(Expression expression)
        {
            return ConcatInternal(Anchors.NotAssertBack(expression));
        }

        public QuantifiableExpression NotAssertBack(string text)
        {
            return ConcatInternal(Anchors.NotAssertBack(text));
        }

        public QuantifiableExpression NotAssertBack(params Expression[] expressions)
        {
            return ConcatInternal(Anchors.NotAssertBack(expressions));
        }

        public QuantifiableExpression NotAssertBack(params string[] values)
        {
            return ConcatInternal(Anchors.NotAssertBack(values));
        }

        public QuantifiableExpression NotAssertBack(CharGroupItem item)
        {
            return ConcatInternal(Anchors.NotAssertBack(item));
        }

        public QuantifiableExpression NotAssertBack(char value)
        {
            return ConcatInternal(Anchors.NotAssertBack(value));
        }

        public QuantifiableExpression NotAssertBack(int charCode)
        {
            return ConcatInternal(Anchors.NotAssertBack(charCode));
        }

        public QuantifiableExpression NotAssertBack(AsciiChar value)
        {
            return ConcatInternal(Anchors.NotAssertBack(value));
        }

        public QuantifiableExpression NotAssertBack(NamedBlock block)
        {
            return ConcatInternal(Anchors.NotAssertBack(block));
        }

        public QuantifiableExpression NotAssertBack(GeneralCategory category)
        {
            return ConcatInternal(Anchors.NotAssertBack(category));
        }

        public QuantifiableExpression NamedGroup(string name, Expression expression)
        {
            return ConcatInternal(Linq.Groups.NamedGroup(name, expression));
        }

        public QuantifiableExpression NamedGroup(string name, string text)
        {
            return ConcatInternal(Linq.Groups.NamedGroup(name, text));
        }

        public QuantifiableExpression NamedGroup(string name, params Expression[] expressions)
        {
            return ConcatInternal(Linq.Groups.NamedGroup(name, expressions));
        }

        public QuantifiableExpression NamedGroup(string name, params string[] values)
        {
            return ConcatInternal(Linq.Groups.NamedGroup(name, values));
        }

        public QuantifiableExpression Capturing()
        {
            return ConcatInternal(Linq.Groups.Capturing());
        }

        public QuantifiableExpression Capturing(Expression expression)
        {
            return ConcatInternal(Linq.Groups.Capturing(expression));
        }

        public QuantifiableExpression Capturing(string text)
        {
            return ConcatInternal(Linq.Groups.Capturing(text));
        }

        public QuantifiableExpression Capturing(params Expression[] expressions)
        {
            return ConcatInternal(Linq.Groups.Capturing(expressions));
        }

        public QuantifiableExpression Capturing(params string[] values)
        {
            return ConcatInternal(Linq.Groups.Capturing(values));
        }

        public QuantifiableExpression Noncapturing(Expression expression)
        {
            return ConcatInternal(Linq.Groups.Noncapturing(expression));
        }

        public QuantifiableExpression Noncapturing(string text)
        {
            return ConcatInternal(Linq.Groups.Noncapturing(text));
        }

        public QuantifiableExpression Noncapturing(params Expression[] expressions)
        {
            return ConcatInternal(Linq.Groups.Noncapturing(expressions));
        }

        public QuantifiableExpression Noncapturing(params string[] values)
        {
            return ConcatInternal(Linq.Groups.Noncapturing(values));
        }

        public QuantifiableExpression Nonbacktracking(Expression expression)
        {
            return ConcatInternal(Linq.Groups.Nonbacktracking(expression));
        }

        public QuantifiableExpression Nonbacktracking(string text)
        {
            return ConcatInternal(Linq.Groups.Nonbacktracking(text));
        }

        public QuantifiableExpression Nonbacktracking(params Expression[] expressions)
        {
            return ConcatInternal(Linq.Groups.Nonbacktracking(expressions));
        }

        public QuantifiableExpression Nonbacktracking(params string[] values)
        {
            return ConcatInternal(Linq.Groups.Nonbacktracking(values));
        }

        public QuantifiableExpression BalanceGroup(string name1, string name2, Expression expression)
        {
            return ConcatInternal(Linq.Groups.BalanceGroup(name1, name2, expression));
        }

        public QuantifiableExpression BalanceGroup(string name1, string name2, string text)
        {
            return ConcatInternal(Linq.Groups.BalanceGroup(name1, name2, text));
        }

        public QuantifiableExpression BalanceGroup(string name1, string name2, params Expression[] expressions)
        {
            return ConcatInternal(Linq.Groups.BalanceGroup(name1, name2, expressions));
        }

        public QuantifiableExpression BalanceGroup(string name1, string name2, params string[] values)
        {
            return ConcatInternal(Linq.Groups.BalanceGroup(name1, name2, values));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, Expression expression)
        {
            return ConcatInternal(Linq.Groups.GroupOptions(applyOptions, expression));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, string text)
        {
            return ConcatInternal(Linq.Groups.GroupOptions(applyOptions, text));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, params Expression[] expressions)
        {
            return ConcatInternal(Linq.Groups.GroupOptions(applyOptions, expressions));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, params string[] values)
        {
            return ConcatInternal(Linq.Groups.GroupOptions(applyOptions, values));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, Expression expression)
        {
            return ConcatInternal(Linq.Groups.GroupOptions(applyOptions, disableOptions, expression));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string text)
        {
            return ConcatInternal(Linq.Groups.GroupOptions(applyOptions, disableOptions, text));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, params Expression[] expressions)
        {
            return ConcatInternal(Linq.Groups.GroupOptions(applyOptions, disableOptions, expressions));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, params string[] values)
        {
            return ConcatInternal(Linq.Groups.GroupOptions(applyOptions, disableOptions, values));
        }

        public QuantifiableExpression WithOptions(InlineOptions applyOptions)
        {
            return Linq.Groups.GroupOptions(applyOptions, this);
        }

        public QuantifiableExpression WithOptions(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return Linq.Groups.GroupOptions(applyOptions, disableOptions, this);
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

        public Expression Apostrophes(Expression expression)
        {
            return ConcatInternal(Expressions.Apostrophes(expression));
        }

        public Expression Apostrophes(string text)
        {
            return ConcatInternal(Expressions.Apostrophes(text));
        }

        public Expression QuoteMarks(Expression expression)
        {
            return ConcatInternal(Expressions.QuoteMarks(expression));
        }

        public Expression QuoteMarks(string text)
        {
            return ConcatInternal(Expressions.QuoteMarks(text));
        }

        public Expression Parentheses(Expression expression)
        {
            return ConcatInternal(Expressions.Parentheses(expression));
        }

        public Expression Parentheses(string text)
        {
            return ConcatInternal(Expressions.Parentheses(text));
        }

        public Expression CurlyBrackets(Expression expression)
        {
            return ConcatInternal(Expressions.CurlyBrackets(expression));
        }

        public Expression CurlyBrackets(string text)
        {
            return ConcatInternal(Expressions.CurlyBrackets(text));
        }

        public Expression SquareBrackets(Expression expression)
        {
            return ConcatInternal(Expressions.SquareBrackets(expression));
        }

        public Expression SquareBrackets(string text)
        {
            return ConcatInternal(Expressions.SquareBrackets(text));
        }

        public Expression LessThanGreaterThan(Expression expression)
        {
            return ConcatInternal(Expressions.LessThanGreaterThan(expression));
        }

        public Expression LessThanGreaterThan(string text)
        {
            return ConcatInternal(Expressions.LessThanGreaterThan(text));
        }

        public QuantifiableExpression Char(string chars)
        {
            return ConcatInternal(Chars.Char(chars));
        }

        public QuantifiableExpression Char(CharGroupItem item)
        {
            return ConcatInternal(Chars.Char(item));
        }

        public QuantifiableExpression Char(IEnumerable<char> values)
        {
            return ConcatInternal(Chars.Char(values));
        }

        public QuantifiableExpression Char(IEnumerable<int> charCodes)
        {
            return ConcatInternal(Chars.Char(charCodes));
        }

        public QuantifiableExpression Char(IEnumerable<AsciiChar> values)
        {
            return ConcatInternal(Chars.Char(values));
        }

        public QuantifiableExpression Char(IEnumerable<NamedBlock> blocks)
        {
            return ConcatInternal(Chars.Char(blocks));
        }

        public QuantifiableExpression Char(IEnumerable<GeneralCategory> categories)
        {
            return ConcatInternal(Chars.Char(categories));
        }

        public QuantifiableExpression NotChar(string chars)
        {
            return ConcatInternal(Chars.NotChar(chars));
        }

        public QuantifiableExpression NotChar(CharGroupItem item)
        {
            return ConcatInternal(Chars.NotChar(item));
        }

        public QuantifiableExpression NotChar(IEnumerable<char> values)
        {
            return ConcatInternal(Chars.NotChar(values));
        }

        public QuantifiableExpression NotChar(IEnumerable<int> charCodes)
        {
            return ConcatInternal(Chars.NotChar(charCodes));
        }

        public QuantifiableExpression NotChar(IEnumerable<AsciiChar> values)
        {
            return ConcatInternal(Chars.NotChar(values));
        }

        public QuantifiableExpression NotChar(IEnumerable<NamedBlock> blocks)
        {
            return ConcatInternal(Chars.NotChar(blocks));
        }

        public QuantifiableExpression NotChar(IEnumerable<GeneralCategory> categories)
        {
            return ConcatInternal(Chars.NotChar(categories));
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

        public CharGroupExpression Alphanumeric()
        {
            return ConcatInternal(Chars.Alphanumeric());
        }

        public CharGroupExpression NotAlphanumeric()
        {
            return ConcatInternal(Chars.NotAlphanumeric());
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

        public QuantifiableExpression Parentheses()
        {
            return ConcatInternal(Chars.Parenthesis());
        }

        public QuantifiableExpression NotParentheses()
        {
            return ConcatInternal(Chars.NotParenthesis());
        }

        public QuantifiableExpression CurlyBrackets()
        {
            return ConcatInternal(Chars.CurlyBracket());
        }

        public QuantifiableExpression NotCurlyBrackets()
        {
            return ConcatInternal(Chars.NotCurlyBracket());
        }

        public QuantifiableExpression SquareBrackets()
        {
            return ConcatInternal(Chars.SquareBracket());
        }

        public QuantifiableExpression NotSquareBrackets()
        {
            return ConcatInternal(Chars.NotSquareBracket());
        }

        public QuantifierExpression Maybe(string text)
        {
            return ConcatInternal(Linq.Groups.Maybe(text));
        }

        public QuantifierExpression Maybe(Expression expression)
        {
            return ConcatInternal(Linq.Groups.Maybe(expression));
        }

        public QuantifierExpression Maybe(params string[] values)
        {
            return ConcatInternal(Linq.Groups.Maybe(values));
        }

        public QuantifierExpression Maybe(params Expression[] expressions)
        {
            return ConcatInternal(Linq.Groups.Maybe(expressions));
        }

        public QuantifierExpression MaybeMany(string text)
        {
            return ConcatInternal(Linq.Groups.MaybeMany(text));
        }

        public QuantifierExpression MaybeMany(Expression expression)
        {
            return ConcatInternal(Linq.Groups.MaybeMany(expression));
        }

        public QuantifierExpression MaybeMany(params string[] values)
        {
            return ConcatInternal(Linq.Groups.MaybeMany(values));
        }

        public QuantifierExpression MaybeMany(params Expression[] expressions)
        {
            return ConcatInternal(Linq.Groups.MaybeMany(expressions));
        }

        public QuantifierExpression OneMany(string text)
        {
            return ConcatInternal(Linq.Groups.OneMany(text));
        }

        public QuantifierExpression OneMany(Expression expression)
        {
            return ConcatInternal(Linq.Groups.OneMany(expression));
        }

        public QuantifierExpression OneMany(params string[] values)
        {
            return ConcatInternal(Linq.Groups.OneMany(values));
        }

        public QuantifierExpression OneMany(params Expression[] expressions)
        {
            return ConcatInternal(Linq.Groups.OneMany(expressions));
        }

        public QuantifiableExpression Backreference(int groupNumber)
        {
            return ConcatInternal(Expressions.Backreference(groupNumber));
        }

        public QuantifiableExpression Backreference(string groupName)
        {
            return ConcatInternal(Expressions.Backreference(groupName));
        }

        public Expression Options(InlineOptions applyOptions)
        {
            return ConcatInternal(Expressions.Options(applyOptions));
        }

        public Expression Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return ConcatInternal(Expressions.Options(applyOptions, disableOptions));
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

        public Expression Text(string value)
        {
            return ConcatInternal(Expressions.Text(value));
        }
    }
}
