// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
        public QuantifiableExpression Any(params Expression[] expressions)
        {
            return AppendInternal(Alternation.Any(expressions));
        }

        public QuantifiableExpression Any(params string[] values)
        {
            return AppendInternal(Alternation.Any(values));
        }

        public QuantifiableExpression IfGroup(string groupName, Expression yes)
        {
            return AppendInternal(Alternation.IfGroup(groupName, yes));
        }

        public QuantifiableExpression IfGroup(string groupName, Expression yes, Expression no)
        {
            return AppendInternal(Alternation.IfGroup(groupName, yes, no));
        }

        public QuantifiableExpression IfGroup(string groupName, string yes)
        {
            return AppendInternal(Alternation.IfGroup(groupName, yes));
        }

        public QuantifiableExpression IfGroup(string groupName, string yes, string no)
        {
            return AppendInternal(Alternation.IfGroup(groupName, yes, no));
        }

        public QuantifiableExpression IfGroup(int groupNumber, Expression yes)
        {
            return AppendInternal(Alternation.IfGroup(groupNumber, yes));
        }

        public QuantifiableExpression IfGroup(int groupNumber, Expression yes, Expression no)
        {
            return AppendInternal(Alternation.IfGroup(groupNumber, yes, no));
        }

        public QuantifiableExpression IfGroup(int groupNumber, string yes)
        {
            return AppendInternal(Alternation.IfGroup(groupNumber, yes));
        }

        public QuantifiableExpression IfGroup(int groupNumber, string yes, string no)
        {
            return AppendInternal(Alternation.IfGroup(groupNumber, yes, no));
        }

        public QuantifiableExpression If(Expression condition, Expression yes)
        {
            return AppendInternal(Alternation.If(condition, yes));
        }

        public QuantifiableExpression If(Expression condition, Expression yes, Expression no)
        {
            return AppendInternal(Alternation.If(condition, yes, no));
        }

        public QuantifiableExpression If(Expression condition, string yes)
        {
            return AppendInternal(Alternation.If(condition, yes));
        }

        public QuantifiableExpression If(Expression condition, string yes, string no)
        {
            return AppendInternal(Alternation.If(condition, yes, no));
        }

        public Expression Or()
        {
            return AppendInternal(Alternation.Or());
        }

        public QuantifiableExpression Start()
        {
            return AppendInternal(Anchor.Start());
        }

        public QuantifiableExpression StartOfLine()
        {
            return AppendInternal(Anchor.StartOfLine());
        }

        public QuantifiableExpression StartOfLineInvariant()
        {
            return AppendInternal(Anchor.StartOfLineInvariant());
        }

        public QuantifiableExpression EndOfLine()
        {
            return AppendInternal(Anchor.EndOfLine());
        }

        public QuantifiableExpression EndOfLineInvariant()
        {
            return AppendInternal(Anchor.EndOfLineInvariant());
        }

        public QuantifiableExpression EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true);
        }

        internal QuantifiableExpression EndOfLine(bool beforeCarriageReturn)
        {
            return AppendInternal(Anchor.EndOfLine(beforeCarriageReturn));
        }

        public QuantifiableExpression End()
        {
            return AppendInternal(Anchor.End());
        }

        public QuantifiableExpression EndOrBeforeEndingNewLine()
        {
            return AppendInternal(Anchor.EndOrBeforeEndingNewLine());
        }

        public QuantifiableExpression PreviousMatchEnd()
        {
            return AppendInternal(Anchor.PreviousMatchEnd());
        }

        public QuantifiableExpression WordBoundary()
        {
            return AppendInternal(Anchor.WordBoundary());
        }

        public QuantifiableExpression NotWordBoundary()
        {
            return AppendInternal(Anchor.NotWordBoundary());
        }

        public QuantifiableExpression AsLine()
        {
            return Anchor.Line(this);
        }

        public QuantifiableExpression AsLineInvariant()
        {
            return Anchor.LineInvariant(this);
        }

        public QuantifiableExpression AsEntireInput()
        {
            return Anchor.EntireInput(this);
        }

        public QuantifiableExpression Lookahead(Expression value)
        {
            return AppendInternal(Assertion.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(string value)
        {
            return AppendInternal(Assertion.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(params char[] values)
        {
            return AppendInternal(Assertion.Lookahead(values));
        }

        public QuantifiableExpression Lookahead(params int[] charCodes)
        {
            return AppendInternal(Assertion.Lookahead(charCodes));
        }

        public QuantifiableExpression Lookahead(params AsciiChar[] values)
        {
            return AppendInternal(Assertion.Lookahead(values));
        }

        public QuantifiableExpression Lookahead(params CharClass[] values)
        {
            return AppendInternal(Assertion.Lookahead(values));
        }

        public QuantifiableExpression Lookahead(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Assertion.Lookahead(blocks));
        }

        public QuantifiableExpression Lookahead(UnicodeCategory[] categories)
        {
            return AppendInternal(Assertion.Lookahead(categories));
        }

        public QuantifiableExpression NotLookahead(Expression value)
        {
            return AppendInternal(Assertion.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(string value)
        {
            return AppendInternal(Assertion.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(params char[] values)
        {
            return AppendInternal(Assertion.NotLookahead(values));
        }

        public QuantifiableExpression NotLookahead(params int[] charCodes)
        {
            return AppendInternal(Assertion.NotLookahead(charCodes));
        }

        public QuantifiableExpression NotLookahead(params AsciiChar[] values)
        {
            return AppendInternal(Assertion.NotLookahead(values));
        }

        public QuantifiableExpression NotLookahead(params CharClass[] values)
        {
            return AppendInternal(Assertion.NotLookahead(values));
        }

        public QuantifiableExpression NotLookahead(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Assertion.NotLookahead(blocks));
        }

        public QuantifiableExpression NotLookahead(UnicodeCategory[] categories)
        {
            return AppendInternal(Assertion.NotLookahead(categories));
        }

        public QuantifiableExpression Lookbehind(Expression value)
        {
            return AppendInternal(Assertion.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(string value)
        {
            return AppendInternal(Assertion.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(params char[] values)
        {
            return AppendInternal(Assertion.Lookbehind(values));
        }

        public QuantifiableExpression Lookbehind(params int[] charCodes)
        {
            return AppendInternal(Assertion.Lookbehind(charCodes));
        }

        public QuantifiableExpression Lookbehind(params AsciiChar[] values)
        {
            return AppendInternal(Assertion.Lookbehind(values));
        }

        public QuantifiableExpression Lookbehind(params CharClass[] values)
        {
            return AppendInternal(Assertion.Lookbehind(values));
        }

        public QuantifiableExpression Lookbehind(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Assertion.Lookbehind(blocks));
        }

        public QuantifiableExpression Lookbehind(UnicodeCategory[] categories)
        {
            return AppendInternal(Assertion.Lookbehind(categories));
        }

        public QuantifiableExpression NotLookbehind(Expression value)
        {
            return AppendInternal(Assertion.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(string value)
        {
            return AppendInternal(Assertion.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(params char[] values)
        {
            return AppendInternal(Assertion.NotLookbehind(values));
        }

        public QuantifiableExpression NotLookbehind(params int[] charCodes)
        {
            return AppendInternal(Assertion.NotLookbehind(charCodes));
        }

        public QuantifiableExpression NotLookbehind(params AsciiChar[] values)
        {
            return AppendInternal(Assertion.NotLookbehind(values));
        }

        public QuantifiableExpression NotLookbehind(params CharClass[] values)
        {
            return AppendInternal(Assertion.NotLookbehind(values));
        }

        public QuantifiableExpression NotLookbehind(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Assertion.NotLookbehind(blocks));
        }

        public QuantifiableExpression NotLookbehind(UnicodeCategory[] categories)
        {
            return AppendInternal(Assertion.NotLookbehind(categories));
        }

        public QuantifiableExpression AsLookahead()
        {
            return Assertion.Lookahead(this);
        }

        public QuantifiableExpression AsNotLookahead()
        {
            return Assertion.NotLookahead(this);
        }

        public QuantifiableExpression AsLookbehind()
        {
            return Assertion.Lookbehind(this);
        }

        public QuantifiableExpression AsNotLookbehind()
        {
            return Assertion.NotLookbehind(this);
        }

        public QuantifiableExpression NamedGroup(string name, Expression value)
        {
            return AppendInternal(Grouping.NamedGroup(name, value));
        }

        public QuantifiableExpression NamedGroup(string name, string value)
        {
            return AppendInternal(Grouping.NamedGroup(name, value));
        }

        public QuantifiableExpression AsNamedGroup(string name)
        {
            return Grouping.NamedGroup(name, this);
        }

        public QuantifiableExpression Subexpression(Expression value)
        {
            return AppendInternal(Grouping.Subexpression(value));
        }

        public QuantifiableExpression Subexpression(string value)
        {
            return AppendInternal(Grouping.Subexpression(value));
        }

        public QuantifiableExpression AsSubexpression()
        {
            return Grouping.Subexpression(this);
        }

        public QuantifiableExpression Noncapturing(Expression value)
        {
            return AppendInternal(Grouping.Noncapturing(value));
        }

        public QuantifiableExpression Noncapturing(string value)
        {
            return AppendInternal(Grouping.Noncapturing(value));
        }

        public QuantifiableExpression AsNoncapturing()
        {
            return Grouping.Noncapturing(this);
        }

        public QuantifiableExpression Nonbacktracking(Expression value)
        {
            return AppendInternal(Grouping.Nonbacktracking(value));
        }

        public QuantifiableExpression Nonbacktracking(string value)
        {
            return AppendInternal(Grouping.Nonbacktracking(value));
        }

        public QuantifiableExpression AsNonbacktracking()
        {
            return Grouping.Nonbacktracking(this);
        }

        public QuantifiableExpression Balancing(string name1, string name2, Expression value)
        {
            return AppendInternal(Grouping.Balancing(name1, name2, value));
        }

        public QuantifiableExpression Balancing(string name1, string name2, string value)
        {
            return AppendInternal(Grouping.Balancing(name1, name2, value));
        }

        public QuantifiableExpression AsBalancing(string name1, string name2)
        {
            return Grouping.Balancing(name1, name2, this);
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, Expression value)
        {
            return AppendInternal(Grouping.GroupOptions(applyOptions, value));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, string value)
        {
            return AppendInternal(Grouping.GroupOptions(applyOptions, value));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, Expression value)
        {
            return AppendInternal(Grouping.GroupOptions(applyOptions, disableOptions, value));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string value)
        {
            return AppendInternal(Grouping.GroupOptions(applyOptions, disableOptions, value));
        }

        public QuantifiableExpression AsGroupOptions(InlineOptions applyOptions)
        {
            return Grouping.GroupOptions(applyOptions, this);
        }

        public QuantifiableExpression AsGroupOptions(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return Grouping.GroupOptions(applyOptions, disableOptions, this);
        }

        public QuantifiableExpression Chars(string value)
        {
            return AppendInternal(Character.Group(value));
        }

        public QuantifiableExpression Chars(CharGroupItem item)
        {
            return AppendInternal(Character.Group(item));
        }

        public QuantifiableExpression Chars(params char[] values)
        {
            return AppendInternal(Character.Group(values));
        }

        public QuantifiableExpression Chars(params int[] charCodes)
        {
            return AppendInternal(Character.Group(charCodes));
        }

        public QuantifiableExpression Chars(params AsciiChar[] values)
        {
            return AppendInternal(Character.Group(values));
        }

        public QuantifiableExpression Chars(params CharClass[] values)
        {
            return AppendInternal(Character.Group(values));
        }

        public QuantifiableExpression Chars(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Character.Group(blocks));
        }

        public QuantifiableExpression Chars(params UnicodeCategory[] categories)
        {
            return AppendInternal(Character.Group(categories));
        }

        public QuantifiableExpression NotChars(string value)
        {
            return AppendInternal(Character.NotGroup(value));
        }

        public QuantifiableExpression NotChars(CharGroupItem item)
        {
            return AppendInternal(Character.NotGroup(item));
        }

        public QuantifiableExpression NotChars(params char[] values)
        {
            return AppendInternal(Character.NotGroup(values));
        }

        public QuantifiableExpression NotChars(params int[] charCodes)
        {
            return AppendInternal(Character.NotGroup(charCodes));
        }

        public QuantifiableExpression NotChars(params AsciiChar[] values)
        {
            return AppendInternal(Character.NotGroup(values));
        }

        public QuantifiableExpression NotChars(params UnicodeBlock[] blocks)
        {
            return AppendInternal(Character.NotGroup(blocks));
        }

        public QuantifiableExpression NotChars(params UnicodeCategory[] categories)
        {
            return AppendInternal(Character.NotGroup(categories));
        }

        public QuantifiableExpression Range(char first, char last)
        {
            return AppendInternal(Character.Range(first, last));
        }

        public QuantifiableExpression Range(int first, int last)
        {
            return AppendInternal(Character.Range(first, last));
        }

        public QuantifiableExpression NotRange(char first, char last)
        {
            return AppendInternal(Character.NotRange(first, last));
        }

        public QuantifiableExpression NotRange(int first, int last)
        {
            return AppendInternal(Character.NotRange(first, last));
        }

        public QuantifiableExpression Subtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return AppendInternal(Character.Subtraction(baseGroup, excludedGroup));
        }

        public QuantifiableExpression NotSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return AppendInternal(Character.NotSubtraction(baseGroup, excludedGroup));
        }

        public QuantifiableExpression WhiteSpaceExceptNewLine()
        {
            return AppendInternal(Character.WhiteSpaceExceptNewLine());
        }

        public CharGroupExpression Alphanumeric()
        {
            return AppendInternal(Character.Alphanumeric());
        }

        public QuantifiableExpression Any()
        {
            return AppendInternal(Character.Any());
        }

        public QuantifiableExpression Digit()
        {
            return AppendInternal(Character.Digit());
        }

        public QuantifierExpression Digit(int count)
        {
            return AppendInternal(Character.Digit(count));
        }

        public QuantifierExpression Digit(int minCount, int maxCount)
        {
            return AppendInternal(Character.Digit(minCount, maxCount));
        }

        public QuantifiableExpression NotDigit()
        {
            return AppendInternal(Character.NotDigit());
        }

        public QuantifierExpression NotDigit(int count)
        {
            return AppendInternal(Character.NotDigit(count));
        }

        public QuantifierExpression NotDigit(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotDigit(minCount, maxCount));
        }

        public QuantifiableExpression WhiteSpace()
        {
            return AppendInternal(Character.WhiteSpace());
        }

        public QuantifierExpression WhiteSpace(int count)
        {
            return AppendInternal(Character.WhiteSpace(count));
        }

        public QuantifierExpression WhiteSpace(int minCount, int maxCount)
        {
            return AppendInternal(Character.WhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression NotWhiteSpace()
        {
            return AppendInternal(Character.NotWhiteSpace());
        }

        public QuantifierExpression NotWhiteSpace(int count)
        {
            return AppendInternal(Character.NotWhiteSpace(count));
        }

        public QuantifierExpression NotWhiteSpace(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotWhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression Word()
        {
            return AppendInternal(Character.Word());
        }

        public QuantifierExpression Word(int count)
        {
            return AppendInternal(Character.Word(count));
        }

        public QuantifierExpression Word(int minCount, int maxCount)
        {
            return AppendInternal(Character.Word(minCount, maxCount));
        }

        public QuantifiableExpression NotWord()
        {
            return AppendInternal(Character.NotWord());
        }

        public QuantifierExpression NotWord(int count)
        {
            return AppendInternal(Character.NotWord(count));
        }

        public QuantifierExpression NotWord(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotWord(minCount, maxCount));
        }

        public QuantifiableExpression Char(char value)
        {
            return AppendInternal(Character.Char(value));
        }

        public QuantifiableExpression Char(int charCode)
        {
            return AppendInternal(Character.Char(charCode));
        }

        public QuantifiableExpression Char(AsciiChar value)
        {
            return AppendInternal(Character.Char(value));
        }

        public QuantifiableExpression Char(CharClass value)
        {
            return AppendInternal(Character.Char(value));
        }

        public QuantifiableExpression UnicodeBlock(UnicodeBlock block)
        {
            return AppendInternal(Character.UnicodeBlock(block));
        }

        public QuantifiableExpression UnicodeCategory(UnicodeCategory category)
        {
            return AppendInternal(Character.UnicodeCategory(category));
        }

        public QuantifiableExpression NotChar(char value)
        {
            return AppendInternal(Character.NotChar(value));
        }

        public QuantifiableExpression NotChar(int charCode)
        {
            return AppendInternal(Character.NotChar(charCode));
        }

        public QuantifiableExpression NotChar(AsciiChar value)
        {
            return AppendInternal(Character.NotChar(value));
        }

        public QuantifiableExpression NotUnicodeBlock(UnicodeBlock block)
        {
            return AppendInternal(Character.NotUnicodeBlock(block));
        }

        public QuantifiableExpression NotUnicodeCategory(UnicodeCategory category)
        {
            return AppendInternal(Character.NotUnicodeCategory(category));
        }

        public QuantifiableExpression Tab()
        {
            return AppendInternal(Character.Tab());
        }

        public QuantifierExpression Tab(int exactCount)
        {
            return AppendInternal(Character.Tab(exactCount));
        }

        public QuantifierExpression Tab(int minCount, int maxCount)
        {
            return AppendInternal(Character.Tab(minCount, maxCount));
        }

        public QuantifiableExpression NotTab()
        {
            return AppendInternal(Character.NotTab());
        }

        public QuantifierExpression NotTab(int exactCount)
        {
            return AppendInternal(Character.NotTab(exactCount));
        }

        public QuantifierExpression NotTab(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotTab(minCount, maxCount));
        }

        public QuantifiableExpression Linefeed()
        {
            return AppendInternal(Character.Linefeed());
        }

        public QuantifierExpression Linefeed(int exactCount)
        {
            return AppendInternal(Character.Linefeed(exactCount));
        }

        public QuantifierExpression Linefeed(int minCount, int maxCount)
        {
            return AppendInternal(Character.Linefeed(minCount, maxCount));
        }

        public QuantifiableExpression NotLinefeed()
        {
            return AppendInternal(Character.NotLinefeed());
        }

        public QuantifierExpression NotLinefeed(int exactCount)
        {
            return AppendInternal(Character.NotLinefeed(exactCount));
        }

        public QuantifierExpression NotLinefeed(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotLinefeed(minCount, maxCount));
        }

        public QuantifiableExpression CarriageReturn()
        {
            return AppendInternal(Character.CarriageReturn());
        }

        public QuantifierExpression CarriageReturn(int exactCount)
        {
            return AppendInternal(Character.CarriageReturn(exactCount));
        }

        public QuantifierExpression CarriageReturn(int minCount, int maxCount)
        {
            return AppendInternal(Character.CarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression NotCarriageReturn()
        {
            return AppendInternal(Character.NotCarriageReturn());
        }

        public QuantifierExpression NotCarriageReturn(int exactCount)
        {
            return AppendInternal(Character.NotCarriageReturn(exactCount));
        }

        public QuantifierExpression NotCarriageReturn(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotCarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression Space()
        {
            return AppendInternal(Character.Space());
        }

        public QuantifierExpression Space(int exactCount)
        {
            return AppendInternal(Character.Space(exactCount));
        }

        public QuantifierExpression Space(int minCount, int maxCount)
        {
            return AppendInternal(Character.Space(minCount, maxCount));
        }

        public QuantifiableExpression NotSpace()
        {
            return AppendInternal(Character.NotSpace());
        }

        public QuantifierExpression NotSpace(int exactCount)
        {
            return AppendInternal(Character.NotSpace(exactCount));
        }

        public QuantifierExpression NotSpace(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotSpace(minCount, maxCount));
        }

        public QuantifiableExpression ExclamationMark()
        {
            return AppendInternal(Character.ExclamationMark());
        }

        public QuantifierExpression ExclamationMark(int exactCount)
        {
            return AppendInternal(Character.ExclamationMark(exactCount));
        }

        public QuantifierExpression ExclamationMark(int minCount, int maxCount)
        {
            return AppendInternal(Character.ExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotExclamationMark()
        {
            return AppendInternal(Character.NotExclamationMark());
        }

        public QuantifierExpression NotExclamationMark(int exactCount)
        {
            return AppendInternal(Character.NotExclamationMark(exactCount));
        }

        public QuantifierExpression NotExclamationMark(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression QuotationMark()
        {
            return AppendInternal(Character.QuotationMark());
        }

        public QuantifierExpression QuotationMark(int exactCount)
        {
            return AppendInternal(Character.QuotationMark(exactCount));
        }

        public QuantifierExpression QuotationMark(int minCount, int maxCount)
        {
            return AppendInternal(Character.QuotationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuotationMark()
        {
            return AppendInternal(Character.NotQuotationMark());
        }

        public QuantifierExpression NotQuotationMark(int exactCount)
        {
            return AppendInternal(Character.NotQuotationMark(exactCount));
        }

        public QuantifierExpression NotQuotationMark(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotQuotationMark(minCount, maxCount));
        }

        public QuantifiableExpression NumberSign()
        {
            return AppendInternal(Character.NumberSign());
        }

        public QuantifierExpression NumberSign(int exactCount)
        {
            return AppendInternal(Character.NumberSign(exactCount));
        }

        public QuantifierExpression NumberSign(int minCount, int maxCount)
        {
            return AppendInternal(Character.NumberSign(minCount, maxCount));
        }

        public QuantifiableExpression NotNumberSign()
        {
            return AppendInternal(Character.NotNumberSign());
        }

        public QuantifierExpression NotNumberSign(int exactCount)
        {
            return AppendInternal(Character.NotNumberSign(exactCount));
        }

        public QuantifierExpression NotNumberSign(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotNumberSign(minCount, maxCount));
        }

        public QuantifiableExpression Dollar()
        {
            return AppendInternal(Character.Dollar());
        }

        public QuantifierExpression Dollar(int exactCount)
        {
            return AppendInternal(Character.Dollar(exactCount));
        }

        public QuantifierExpression Dollar(int minCount, int maxCount)
        {
            return AppendInternal(Character.Dollar(minCount, maxCount));
        }

        public QuantifiableExpression NotDollar()
        {
            return AppendInternal(Character.NotDollar());
        }

        public QuantifierExpression NotDollar(int exactCount)
        {
            return AppendInternal(Character.NotDollar(exactCount));
        }

        public QuantifierExpression NotDollar(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotDollar(minCount, maxCount));
        }

        public QuantifiableExpression Percent()
        {
            return AppendInternal(Character.Percent());
        }

        public QuantifierExpression Percent(int exactCount)
        {
            return AppendInternal(Character.Percent(exactCount));
        }

        public QuantifierExpression Percent(int minCount, int maxCount)
        {
            return AppendInternal(Character.Percent(minCount, maxCount));
        }

        public QuantifiableExpression NotPercent()
        {
            return AppendInternal(Character.NotPercent());
        }

        public QuantifierExpression NotPercent(int exactCount)
        {
            return AppendInternal(Character.NotPercent(exactCount));
        }

        public QuantifierExpression NotPercent(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotPercent(minCount, maxCount));
        }

        public QuantifiableExpression Ampersand()
        {
            return AppendInternal(Character.Ampersand());
        }

        public QuantifierExpression Ampersand(int exactCount)
        {
            return AppendInternal(Character.Ampersand(exactCount));
        }

        public QuantifierExpression Ampersand(int minCount, int maxCount)
        {
            return AppendInternal(Character.Ampersand(minCount, maxCount));
        }

        public QuantifiableExpression NotAmpersand()
        {
            return AppendInternal(Character.NotAmpersand());
        }

        public QuantifierExpression NotAmpersand(int exactCount)
        {
            return AppendInternal(Character.NotAmpersand(exactCount));
        }

        public QuantifierExpression NotAmpersand(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotAmpersand(minCount, maxCount));
        }

        public QuantifiableExpression Apostrophe()
        {
            return AppendInternal(Character.Apostrophe());
        }

        public QuantifierExpression Apostrophe(int exactCount)
        {
            return AppendInternal(Character.Apostrophe(exactCount));
        }

        public QuantifierExpression Apostrophe(int minCount, int maxCount)
        {
            return AppendInternal(Character.Apostrophe(minCount, maxCount));
        }

        public QuantifiableExpression NotApostrophe()
        {
            return AppendInternal(Character.NotApostrophe());
        }

        public QuantifierExpression NotApostrophe(int exactCount)
        {
            return AppendInternal(Character.NotApostrophe(exactCount));
        }

        public QuantifierExpression NotApostrophe(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotApostrophe(minCount, maxCount));
        }

        public QuantifiableExpression LeftParenthesis()
        {
            return AppendInternal(Character.LeftParenthesis());
        }

        public QuantifierExpression LeftParenthesis(int exactCount)
        {
            return AppendInternal(Character.LeftParenthesis(exactCount));
        }

        public QuantifierExpression LeftParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Character.LeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftParenthesis()
        {
            return AppendInternal(Character.NotLeftParenthesis());
        }

        public QuantifierExpression NotLeftParenthesis(int exactCount)
        {
            return AppendInternal(Character.NotLeftParenthesis(exactCount));
        }

        public QuantifierExpression NotLeftParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotLeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression RightParenthesis()
        {
            return AppendInternal(Character.RightParenthesis());
        }

        public QuantifierExpression RightParenthesis(int exactCount)
        {
            return AppendInternal(Character.RightParenthesis(exactCount));
        }

        public QuantifierExpression RightParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Character.RightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotRightParenthesis()
        {
            return AppendInternal(Character.NotRightParenthesis());
        }

        public QuantifierExpression NotRightParenthesis(int exactCount)
        {
            return AppendInternal(Character.NotRightParenthesis(exactCount));
        }

        public QuantifierExpression NotRightParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotRightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression Asterisk()
        {
            return AppendInternal(Character.Asterisk());
        }

        public QuantifierExpression Asterisk(int exactCount)
        {
            return AppendInternal(Character.Asterisk(exactCount));
        }

        public QuantifierExpression Asterisk(int minCount, int maxCount)
        {
            return AppendInternal(Character.Asterisk(minCount, maxCount));
        }

        public QuantifiableExpression NotAsterisk()
        {
            return AppendInternal(Character.NotAsterisk());
        }

        public QuantifierExpression NotAsterisk(int exactCount)
        {
            return AppendInternal(Character.NotAsterisk(exactCount));
        }

        public QuantifierExpression NotAsterisk(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotAsterisk(minCount, maxCount));
        }

        public QuantifiableExpression Plus()
        {
            return AppendInternal(Character.Plus());
        }

        public QuantifierExpression Plus(int exactCount)
        {
            return AppendInternal(Character.Plus(exactCount));
        }

        public QuantifierExpression Plus(int minCount, int maxCount)
        {
            return AppendInternal(Character.Plus(minCount, maxCount));
        }

        public QuantifiableExpression NotPlus()
        {
            return AppendInternal(Character.NotPlus());
        }

        public QuantifierExpression NotPlus(int exactCount)
        {
            return AppendInternal(Character.NotPlus(exactCount));
        }

        public QuantifierExpression NotPlus(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotPlus(minCount, maxCount));
        }

        public QuantifiableExpression Comma()
        {
            return AppendInternal(Character.Comma());
        }

        public QuantifierExpression Comma(int exactCount)
        {
            return AppendInternal(Character.Comma(exactCount));
        }

        public QuantifierExpression Comma(int minCount, int maxCount)
        {
            return AppendInternal(Character.Comma(minCount, maxCount));
        }

        public QuantifiableExpression NotComma()
        {
            return AppendInternal(Character.NotComma());
        }

        public QuantifierExpression NotComma(int exactCount)
        {
            return AppendInternal(Character.NotComma(exactCount));
        }

        public QuantifierExpression NotComma(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotComma(minCount, maxCount));
        }

        public QuantifiableExpression Hyphen()
        {
            return AppendInternal(Character.Hyphen());
        }

        public QuantifierExpression Hyphen(int exactCount)
        {
            return AppendInternal(Character.Hyphen(exactCount));
        }

        public QuantifierExpression Hyphen(int minCount, int maxCount)
        {
            return AppendInternal(Character.Hyphen(minCount, maxCount));
        }

        public QuantifiableExpression NotHyphen()
        {
            return AppendInternal(Character.NotHyphen());
        }

        public QuantifierExpression NotHyphen(int exactCount)
        {
            return AppendInternal(Character.NotHyphen(exactCount));
        }

        public QuantifierExpression NotHyphen(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotHyphen(minCount, maxCount));
        }

        public QuantifiableExpression Period()
        {
            return AppendInternal(Character.Period());
        }

        public QuantifierExpression Period(int exactCount)
        {
            return AppendInternal(Character.Period(exactCount));
        }

        public QuantifierExpression Period(int minCount, int maxCount)
        {
            return AppendInternal(Character.Period(minCount, maxCount));
        }

        public QuantifiableExpression NotPeriod()
        {
            return AppendInternal(Character.NotPeriod());
        }

        public QuantifierExpression NotPeriod(int exactCount)
        {
            return AppendInternal(Character.NotPeriod(exactCount));
        }

        public QuantifierExpression NotPeriod(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotPeriod(minCount, maxCount));
        }

        public QuantifiableExpression Slash()
        {
            return AppendInternal(Character.Slash());
        }

        public QuantifierExpression Slash(int exactCount)
        {
            return AppendInternal(Character.Slash(exactCount));
        }

        public QuantifierExpression Slash(int minCount, int maxCount)
        {
            return AppendInternal(Character.Slash(minCount, maxCount));
        }

        public QuantifiableExpression NotSlash()
        {
            return AppendInternal(Character.NotSlash());
        }

        public QuantifierExpression NotSlash(int exactCount)
        {
            return AppendInternal(Character.NotSlash(exactCount));
        }

        public QuantifierExpression NotSlash(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotSlash(minCount, maxCount));
        }

        public QuantifiableExpression Colon()
        {
            return AppendInternal(Character.Colon());
        }

        public QuantifierExpression Colon(int exactCount)
        {
            return AppendInternal(Character.Colon(exactCount));
        }

        public QuantifierExpression Colon(int minCount, int maxCount)
        {
            return AppendInternal(Character.Colon(minCount, maxCount));
        }

        public QuantifiableExpression NotColon()
        {
            return AppendInternal(Character.NotColon());
        }

        public QuantifierExpression NotColon(int exactCount)
        {
            return AppendInternal(Character.NotColon(exactCount));
        }

        public QuantifierExpression NotColon(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotColon(minCount, maxCount));
        }

        public QuantifiableExpression Semicolon()
        {
            return AppendInternal(Character.Semicolon());
        }

        public QuantifierExpression Semicolon(int exactCount)
        {
            return AppendInternal(Character.Semicolon(exactCount));
        }

        public QuantifierExpression Semicolon(int minCount, int maxCount)
        {
            return AppendInternal(Character.Semicolon(minCount, maxCount));
        }

        public QuantifiableExpression NotSemicolon()
        {
            return AppendInternal(Character.NotSemicolon());
        }

        public QuantifierExpression NotSemicolon(int exactCount)
        {
            return AppendInternal(Character.NotSemicolon(exactCount));
        }

        public QuantifierExpression NotSemicolon(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotSemicolon(minCount, maxCount));
        }

        public QuantifiableExpression LessThan()
        {
            return AppendInternal(Character.LessThan());
        }

        public QuantifierExpression LessThan(int exactCount)
        {
            return AppendInternal(Character.LessThan(exactCount));
        }

        public QuantifierExpression LessThan(int minCount, int maxCount)
        {
            return AppendInternal(Character.LessThan(minCount, maxCount));
        }

        public QuantifiableExpression NotLessThan()
        {
            return AppendInternal(Character.NotLessThan());
        }

        public QuantifierExpression NotLessThan(int exactCount)
        {
            return AppendInternal(Character.NotLessThan(exactCount));
        }

        public QuantifierExpression NotLessThan(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotLessThan(minCount, maxCount));
        }

        public QuantifiableExpression EqualsSign()
        {
            return AppendInternal(Character.EqualsSign());
        }

        public QuantifierExpression EqualsSign(int exactCount)
        {
            return AppendInternal(Character.EqualsSign(exactCount));
        }

        public QuantifierExpression EqualsSign(int minCount, int maxCount)
        {
            return AppendInternal(Character.EqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression NotEqualsSign()
        {
            return AppendInternal(Character.NotEqualsSign());
        }

        public QuantifierExpression NotEqualsSign(int exactCount)
        {
            return AppendInternal(Character.NotEqualsSign(exactCount));
        }

        public QuantifierExpression NotEqualsSign(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotEqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression GreaterThan()
        {
            return AppendInternal(Character.GreaterThan());
        }

        public QuantifierExpression GreaterThan(int exactCount)
        {
            return AppendInternal(Character.GreaterThan(exactCount));
        }

        public QuantifierExpression GreaterThan(int minCount, int maxCount)
        {
            return AppendInternal(Character.GreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression NotGreaterThan()
        {
            return AppendInternal(Character.NotGreaterThan());
        }

        public QuantifierExpression NotGreaterThan(int exactCount)
        {
            return AppendInternal(Character.NotGreaterThan(exactCount));
        }

        public QuantifierExpression NotGreaterThan(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotGreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression QuestionMark()
        {
            return AppendInternal(Character.QuestionMark());
        }

        public QuantifierExpression QuestionMark(int exactCount)
        {
            return AppendInternal(Character.QuestionMark(exactCount));
        }

        public QuantifierExpression QuestionMark(int minCount, int maxCount)
        {
            return AppendInternal(Character.QuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuestionMark()
        {
            return AppendInternal(Character.NotQuestionMark());
        }

        public QuantifierExpression NotQuestionMark(int exactCount)
        {
            return AppendInternal(Character.NotQuestionMark(exactCount));
        }

        public QuantifierExpression NotQuestionMark(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotQuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression At()
        {
            return AppendInternal(Character.At());
        }

        public QuantifierExpression At(int exactCount)
        {
            return AppendInternal(Character.At(exactCount));
        }

        public QuantifierExpression At(int minCount, int maxCount)
        {
            return AppendInternal(Character.At(minCount, maxCount));
        }

        public QuantifiableExpression NotAt()
        {
            return AppendInternal(Character.NotAt());
        }

        public QuantifierExpression NotAt(int exactCount)
        {
            return AppendInternal(Character.NotAt(exactCount));
        }

        public QuantifierExpression NotAt(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotAt(minCount, maxCount));
        }

        public QuantifiableExpression LeftSquareBracket()
        {
            return AppendInternal(Character.LeftSquareBracket());
        }

        public QuantifierExpression LeftSquareBracket(int exactCount)
        {
            return AppendInternal(Character.LeftSquareBracket(exactCount));
        }

        public QuantifierExpression LeftSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Character.LeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftSquareBracket()
        {
            return AppendInternal(Character.NotLeftSquareBracket());
        }

        public QuantifierExpression NotLeftSquareBracket(int exactCount)
        {
            return AppendInternal(Character.NotLeftSquareBracket(exactCount));
        }

        public QuantifierExpression NotLeftSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotLeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression Backslash()
        {
            return AppendInternal(Character.Backslash());
        }

        public QuantifierExpression Backslash(int exactCount)
        {
            return AppendInternal(Character.Backslash(exactCount));
        }

        public QuantifierExpression Backslash(int minCount, int maxCount)
        {
            return AppendInternal(Character.Backslash(minCount, maxCount));
        }

        public QuantifiableExpression NotBackslash()
        {
            return AppendInternal(Character.NotBackslash());
        }

        public QuantifierExpression NotBackslash(int exactCount)
        {
            return AppendInternal(Character.NotBackslash(exactCount));
        }

        public QuantifierExpression NotBackslash(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotBackslash(minCount, maxCount));
        }

        public QuantifiableExpression RightSquareBracket()
        {
            return AppendInternal(Character.RightSquareBracket());
        }

        public QuantifierExpression RightSquareBracket(int exactCount)
        {
            return AppendInternal(Character.RightSquareBracket(exactCount));
        }

        public QuantifierExpression RightSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Character.RightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightSquareBracket()
        {
            return AppendInternal(Character.NotRightSquareBracket());
        }

        public QuantifierExpression NotRightSquareBracket(int exactCount)
        {
            return AppendInternal(Character.NotRightSquareBracket(exactCount));
        }

        public QuantifierExpression NotRightSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotRightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression CircumflexAccent()
        {
            return AppendInternal(Character.CircumflexAccent());
        }

        public QuantifierExpression CircumflexAccent(int exactCount)
        {
            return AppendInternal(Character.CircumflexAccent(exactCount));
        }

        public QuantifierExpression CircumflexAccent(int minCount, int maxCount)
        {
            return AppendInternal(Character.CircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotCircumflexAccent()
        {
            return AppendInternal(Character.NotCircumflexAccent());
        }

        public QuantifierExpression NotCircumflexAccent(int exactCount)
        {
            return AppendInternal(Character.NotCircumflexAccent(exactCount));
        }

        public QuantifierExpression NotCircumflexAccent(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotCircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression Underscore()
        {
            return AppendInternal(Character.Underscore());
        }

        public QuantifierExpression Underscore(int exactCount)
        {
            return AppendInternal(Character.Underscore(exactCount));
        }

        public QuantifierExpression Underscore(int minCount, int maxCount)
        {
            return AppendInternal(Character.Underscore(minCount, maxCount));
        }

        public QuantifiableExpression NotUnderscore()
        {
            return AppendInternal(Character.NotUnderscore());
        }

        public QuantifierExpression NotUnderscore(int exactCount)
        {
            return AppendInternal(Character.NotUnderscore(exactCount));
        }

        public QuantifierExpression NotUnderscore(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotUnderscore(minCount, maxCount));
        }

        public QuantifiableExpression GraveAccent()
        {
            return AppendInternal(Character.GraveAccent());
        }

        public QuantifierExpression GraveAccent(int exactCount)
        {
            return AppendInternal(Character.GraveAccent(exactCount));
        }

        public QuantifierExpression GraveAccent(int minCount, int maxCount)
        {
            return AppendInternal(Character.GraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotGraveAccent()
        {
            return AppendInternal(Character.NotGraveAccent());
        }

        public QuantifierExpression NotGraveAccent(int exactCount)
        {
            return AppendInternal(Character.NotGraveAccent(exactCount));
        }

        public QuantifierExpression NotGraveAccent(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotGraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression LeftCurlyBracket()
        {
            return AppendInternal(Character.LeftCurlyBracket());
        }

        public QuantifierExpression LeftCurlyBracket(int exactCount)
        {
            return AppendInternal(Character.LeftCurlyBracket(exactCount));
        }

        public QuantifierExpression LeftCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Character.LeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftCurlyBracket()
        {
            return AppendInternal(Character.NotLeftCurlyBracket());
        }

        public QuantifierExpression NotLeftCurlyBracket(int exactCount)
        {
            return AppendInternal(Character.NotLeftCurlyBracket(exactCount));
        }

        public QuantifierExpression NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotLeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression VerticalLine()
        {
            return AppendInternal(Character.VerticalLine());
        }

        public QuantifierExpression VerticalLine(int exactCount)
        {
            return AppendInternal(Character.VerticalLine(exactCount));
        }

        public QuantifierExpression VerticalLine(int minCount, int maxCount)
        {
            return AppendInternal(Character.VerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression NotVerticalLine()
        {
            return AppendInternal(Character.NotVerticalLine());
        }

        public QuantifierExpression NotVerticalLine(int exactCount)
        {
            return AppendInternal(Character.NotVerticalLine(exactCount));
        }

        public QuantifierExpression NotVerticalLine(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotVerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression RightCurlyBracket()
        {
            return AppendInternal(Character.RightCurlyBracket());
        }

        public QuantifierExpression RightCurlyBracket(int exactCount)
        {
            return AppendInternal(Character.RightCurlyBracket(exactCount));
        }

        public QuantifierExpression RightCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Character.RightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightCurlyBracket()
        {
            return AppendInternal(Character.NotRightCurlyBracket());
        }

        public QuantifierExpression NotRightCurlyBracket(int exactCount)
        {
            return AppendInternal(Character.NotRightCurlyBracket(exactCount));
        }

        public QuantifierExpression NotRightCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotRightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression Tilde()
        {
            return AppendInternal(Character.Tilde());
        }

        public QuantifierExpression Tilde(int exactCount)
        {
            return AppendInternal(Character.Tilde(exactCount));
        }

        public QuantifierExpression Tilde(int minCount, int maxCount)
        {
            return AppendInternal(Character.Tilde(minCount, maxCount));
        }

        public QuantifiableExpression NotTilde()
        {
            return AppendInternal(Character.NotTilde());
        }

        public QuantifierExpression NotTilde(int exactCount)
        {
            return AppendInternal(Character.NotTilde(exactCount));
        }

        public QuantifierExpression NotTilde(int minCount, int maxCount)
        {
            return AppendInternal(Character.NotTilde(minCount, maxCount));
        }

        public QuantifierExpression Maybe(string value)
        {
            return AppendInternal(Grouping.Maybe(value));
        }

        public QuantifierExpression Maybe(Expression value)
        {
            return AppendInternal(Grouping.Maybe(value));
        }

        public QuantifierExpression MaybeMany(string value)
        {
            return AppendInternal(Grouping.MaybeMany(value));
        }

        public QuantifierExpression MaybeMany(Expression value)
        {
            return AppendInternal(Grouping.MaybeMany(value));
        }

        public QuantifierExpression OneMany(string value)
        {
            return AppendInternal(Grouping.OneMany(value));
        }

        public QuantifierExpression OneMany(Expression value)
        {
            return AppendInternal(Grouping.OneMany(value));
        }

        public QuantifierExpression Count(string value, int exactCount)
        {
            return AppendInternal(Grouping.Count(value, exactCount));
        }

        public QuantifierExpression Count(Expression expression, int exactCount)
        {
            return AppendInternal(Grouping.Count(expression, exactCount));
        }

        public QuantifierExpression AtLeast(string value, int minCount)
        {
            return AppendInternal(Grouping.AtLeast(value, minCount));
        }

        public QuantifierExpression AtLeast(Expression expression, int minCount)
        {
            return AppendInternal(Grouping.AtLeast(expression, minCount));
        }

        public QuantifierExpression Count(string value, int minCount, int maxCount)
        {
            return AppendInternal(Grouping.Count(value, minCount, maxCount));
        }

        public QuantifierExpression Count(Expression expression, int minCount, int maxCount)
        {
            return AppendInternal(Grouping.Count(expression, minCount, maxCount));
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

        public Expression InlineComment(string value)
        {
            return AppendInternal(Miscellaneous.InlineComment(value));
        }

        public QuantifiableExpression NewLine()
        {
            return AppendInternal(Expressions.NewLine());
        }

        public Expression Text(string value)
        {
            return AppendInternal(Expressions.Text(value));
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal QuantifiableExpression InsignificantSeparator()
        {
            return AppendInternal(Expressions.InsignificantSeparator());
        }
    }
}
