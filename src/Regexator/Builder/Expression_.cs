// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Regexator.Builder
{
    public partial class Expression
    {
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

        public Expression WordBoundary(string value)
        {
            return AppendInternal(Anchors.WordBoundary(value));
        }

        public Expression WordBoundary(Expression expression)
        {
            return AppendInternal(Anchors.WordBoundary(expression));
        }

        public QuantifiableExpression NotWordBoundary()
        {
            return AppendInternal(Anchors.NotWordBoundary());
        }

        public Expression AsWordBoundary()
        {
            return Anchors.WordBoundary(this);
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

        public QuantifiableExpression Lookahead(Expression value)
        {
            return AppendInternal(Assertions.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(string value)
        {
            return AppendInternal(Assertions.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(char value)
        {
            return AppendInternal(Assertions.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(int charCode)
        {
            return AppendInternal(Assertions.Lookahead(charCode));
        }

        public QuantifiableExpression Lookahead(AsciiChar value)
        {
            return AppendInternal(Assertions.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(CharClass value)
        {
            return AppendInternal(Assertions.Lookahead(value));
        }

        public QuantifiableExpression Lookahead(UnicodeBlock block)
        {
            return AppendInternal(Assertions.Lookahead(block));
        }

        public QuantifiableExpression Lookahead(UnicodeCategory category)
        {
            return AppendInternal(Assertions.Lookahead(category));
        }

        public QuantifiableExpression NotLookahead(Expression value)
        {
            return AppendInternal(Assertions.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(string value)
        {
            return AppendInternal(Assertions.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(char value)
        {
            return AppendInternal(Assertions.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(int charCode)
        {
            return AppendInternal(Assertions.NotLookahead(charCode));
        }

        public QuantifiableExpression NotLookahead(AsciiChar value)
        {
            return AppendInternal(Assertions.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(CharClass value)
        {
            return AppendInternal(Assertions.NotLookahead(value));
        }

        public QuantifiableExpression NotLookahead(UnicodeBlock block)
        {
            return AppendInternal(Assertions.NotLookahead(block));
        }

        public QuantifiableExpression NotLookahead(UnicodeCategory category)
        {
            return AppendInternal(Assertions.NotLookahead(category));
        }

        public QuantifiableExpression Lookbehind(Expression value)
        {
            return AppendInternal(Assertions.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(string value)
        {
            return AppendInternal(Assertions.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(char value)
        {
            return AppendInternal(Assertions.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(int charCodes)
        {
            return AppendInternal(Assertions.Lookbehind(charCodes));
        }

        public QuantifiableExpression Lookbehind(AsciiChar value)
        {
            return AppendInternal(Assertions.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(CharClass value)
        {
            return AppendInternal(Assertions.Lookbehind(value));
        }

        public QuantifiableExpression Lookbehind(UnicodeBlock block)
        {
            return AppendInternal(Assertions.Lookbehind(block));
        }

        public QuantifiableExpression Lookbehind(UnicodeCategory category)
        {
            return AppendInternal(Assertions.Lookbehind(category));
        }

        public QuantifiableExpression NotLookbehind(Expression value)
        {
            return AppendInternal(Assertions.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(string value)
        {
            return AppendInternal(Assertions.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(char value)
        {
            return AppendInternal(Assertions.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(int charCode)
        {
            return AppendInternal(Assertions.NotLookbehind(charCode));
        }

        public QuantifiableExpression NotLookbehind(AsciiChar value)
        {
            return AppendInternal(Assertions.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(CharClass value)
        {
            return AppendInternal(Assertions.NotLookbehind(value));
        }

        public QuantifiableExpression NotLookbehind(UnicodeBlock block)
        {
            return AppendInternal(Assertions.NotLookbehind(block));
        }

        public QuantifiableExpression NotLookbehind(UnicodeCategory category)
        {
            return AppendInternal(Assertions.NotLookbehind(category));
        }

        public QuantifiableExpression AsLookahead()
        {
            return Assertions.Lookahead(this);
        }

        public QuantifiableExpression AsNotLookahead()
        {
            return Assertions.NotLookahead(this);
        }

        public QuantifiableExpression AsLookbehind()
        {
            return Assertions.Lookbehind(this);
        }

        public QuantifiableExpression AsNotLookbehind()
        {
            return Assertions.NotLookbehind(this);
        }

        public QuantifiableExpression NamedGroup(string name, Expression value)
        {
            return AppendInternal(Groups.NamedGroup(name, value));
        }

        public QuantifiableExpression NamedGroup(string name, string value)
        {
            return AppendInternal(Groups.NamedGroup(name, value));
        }

        public QuantifiableExpression AsNamedGroup(string name)
        {
            return Groups.NamedGroup(name, this);
        }

        public QuantifiableExpression Subexpression(Expression value)
        {
            return AppendInternal(Groups.Subexpression(value));
        }

        public QuantifiableExpression Subexpression(string value)
        {
            return AppendInternal(Groups.Subexpression(value));
        }

        public QuantifiableExpression AsSubexpression()
        {
            return Groups.Subexpression(this);
        }

        public QuantifiableExpression Noncapturing(Expression value)
        {
            return AppendInternal(Groups.Noncapturing(value));
        }

        public QuantifiableExpression Noncapturing(string value)
        {
            return AppendInternal(Groups.Noncapturing(value));
        }

        public QuantifiableExpression AsNoncapturing()
        {
            return Groups.Noncapturing(this);
        }

        public QuantifiableExpression Nonbacktracking(Expression value)
        {
            return AppendInternal(Groups.Nonbacktracking(value));
        }

        public QuantifiableExpression Nonbacktracking(string value)
        {
            return AppendInternal(Groups.Nonbacktracking(value));
        }

        public QuantifiableExpression AsNonbacktracking()
        {
            return Groups.Nonbacktracking(this);
        }

        public QuantifiableExpression Balancing(string name1, string name2, Expression value)
        {
            return AppendInternal(Groups.Balancing(name1, name2, value));
        }

        public QuantifiableExpression Balancing(string name1, string name2, string value)
        {
            return AppendInternal(Groups.Balancing(name1, name2, value));
        }

        public QuantifiableExpression AsBalancing(string name1, string name2)
        {
            return Groups.Balancing(name1, name2, this);
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, Expression value)
        {
            return AppendInternal(Groups.GroupOptions(applyOptions, value));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, string value)
        {
            return AppendInternal(Groups.GroupOptions(applyOptions, value));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, Expression value)
        {
            return AppendInternal(Groups.GroupOptions(applyOptions, disableOptions, value));
        }

        public QuantifiableExpression GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string value)
        {
            return AppendInternal(Groups.GroupOptions(applyOptions, disableOptions, value));
        }

        public QuantifiableExpression AsGroupOptions(InlineOptions applyOptions)
        {
            return Groups.GroupOptions(applyOptions, this);
        }

        public QuantifiableExpression AsGroupOptions(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return Groups.GroupOptions(applyOptions, disableOptions, this);
        }

        public QuantifiableExpression Chars(string value)
        {
            return AppendInternal(Characters.Group(value));
        }

        public QuantifiableExpression Chars(CharGroupItem item)
        {
            return AppendInternal(Characters.Group(item));
        }

        public QuantifiableExpression Chars(IEnumerable<char> values)
        {
            return AppendInternal(Characters.Group(values));
        }

        public QuantifiableExpression Chars(IEnumerable<int> charCodes)
        {
            return AppendInternal(Characters.Group(charCodes));
        }

        public QuantifiableExpression Chars(IEnumerable<AsciiChar> values)
        {
            return AppendInternal(Characters.Group(values));
        }

        public QuantifiableExpression Chars(IEnumerable<CharClass> values)
        {
            return AppendInternal(Characters.Group(values));
        }

        public QuantifiableExpression Chars(IEnumerable<UnicodeBlock> blocks)
        {
            return AppendInternal(Characters.Group(blocks));
        }

        public QuantifiableExpression Chars(IEnumerable<UnicodeCategory> categories)
        {
            return AppendInternal(Characters.Group(categories));
        }

        public QuantifiableExpression NotChars(string value)
        {
            return AppendInternal(Characters.NotGroup(value));
        }

        public QuantifiableExpression NotChars(CharGroupItem item)
        {
            return AppendInternal(Characters.NotGroup(item));
        }

        public QuantifiableExpression NotChars(IEnumerable<char> values)
        {
            return AppendInternal(Characters.NotGroup(values));
        }

        public QuantifiableExpression NotChars(IEnumerable<int> charCodes)
        {
            return AppendInternal(Characters.NotGroup(charCodes));
        }

        public QuantifiableExpression NotChars(IEnumerable<AsciiChar> values)
        {
            return AppendInternal(Characters.NotGroup(values));
        }

        public QuantifiableExpression NotChars(IEnumerable<UnicodeBlock> blocks)
        {
            return AppendInternal(Characters.NotGroup(blocks));
        }

        public QuantifiableExpression NotChars(IEnumerable<UnicodeCategory> categories)
        {
            return AppendInternal(Characters.NotGroup(categories));
        }

        public QuantifiableExpression Range(char first, char last)
        {
            return AppendInternal(Characters.Range(first, last));
        }

        public QuantifiableExpression Range(int first, int last)
        {
            return AppendInternal(Characters.Range(first, last));
        }

        public QuantifiableExpression NotRange(char first, char last)
        {
            return AppendInternal(Characters.NotRange(first, last));
        }

        public QuantifiableExpression NotRange(int first, int last)
        {
            return AppendInternal(Characters.NotRange(first, last));
        }

        public QuantifiableExpression Subtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return AppendInternal(Characters.Subtraction(baseGroup, excludedGroup));
        }

        public QuantifiableExpression NotSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            return AppendInternal(Characters.NotSubtraction(baseGroup, excludedGroup));
        }

        public QuantifiableExpression WhiteSpaceExceptNewLine()
        {
            return AppendInternal(Characters.WhiteSpaceExceptNewLine());
        }

        public CharGroupExpression Alphanumeric()
        {
            return AppendInternal(Characters.Alphanumeric());
        }

        public QuantifiableExpression Any()
        {
            return AppendInternal(Characters.Any());
        }

        public QuantifiableExpression AnyInvariant()
        {
            return AppendInternal(Characters.AnyInvariant());
        }

#if DEBUG
        public Expression AnyMaybeManyLazy()
        {
            return AppendInternal(Characters.AnyMaybeManyLazy());
        }
#endif

        public QuantifiableExpression Digit()
        {
            return AppendInternal(Characters.Digit());
        }

        public QuantifierExpression Digit(int count)
        {
            return AppendInternal(Characters.Digit(count));
        }

        public QuantifierExpression Digit(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Digit(minCount, maxCount));
        }

        public QuantifiableExpression NotDigit()
        {
            return AppendInternal(Characters.NotDigit());
        }

        public QuantifierExpression NotDigit(int count)
        {
            return AppendInternal(Characters.NotDigit(count));
        }

        public QuantifierExpression NotDigit(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotDigit(minCount, maxCount));
        }

        public QuantifiableExpression WhiteSpace()
        {
            return AppendInternal(Characters.WhiteSpace());
        }

        public QuantifierExpression WhiteSpace(int count)
        {
            return AppendInternal(Characters.WhiteSpace(count));
        }

        public QuantifierExpression WhiteSpace(int minCount, int maxCount)
        {
            return AppendInternal(Characters.WhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression NotWhiteSpace()
        {
            return AppendInternal(Characters.NotWhiteSpace());
        }

        public QuantifierExpression NotWhiteSpace(int count)
        {
            return AppendInternal(Characters.NotWhiteSpace(count));
        }

        public QuantifierExpression NotWhiteSpace(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotWhiteSpace(minCount, maxCount));
        }

        public QuantifiableExpression Word()
        {
            return AppendInternal(Characters.Word());
        }

        public QuantifierExpression Word(int count)
        {
            return AppendInternal(Characters.Word(count));
        }

        public QuantifierExpression Word(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Word(minCount, maxCount));
        }

        public QuantifiableExpression NotWord()
        {
            return AppendInternal(Characters.NotWord());
        }

        public QuantifierExpression NotWord(int count)
        {
            return AppendInternal(Characters.NotWord(count));
        }

        public QuantifierExpression NotWord(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotWord(minCount, maxCount));
        }

        public QuantifiableExpression Char(char value)
        {
            return AppendInternal(Characters.Char(value));
        }

        public QuantifiableExpression Char(int charCode)
        {
            return AppendInternal(Characters.Char(charCode));
        }

        public QuantifiableExpression Char(AsciiChar value)
        {
            return AppendInternal(Characters.Char(value));
        }

        public QuantifiableExpression Char(CharClass value)
        {
            return AppendInternal(Characters.Char(value));
        }

        public QuantifiableExpression UnicodeBlock(UnicodeBlock block)
        {
            return AppendInternal(Characters.UnicodeBlock(block));
        }

        public QuantifiableExpression UnicodeCategory(UnicodeCategory category)
        {
            return AppendInternal(Characters.UnicodeCategory(category));
        }

        public QuantifiableExpression NotChar(char value)
        {
            return AppendInternal(Characters.NotChar(value));
        }

        public QuantifiableExpression NotChar(int charCode)
        {
            return AppendInternal(Characters.NotChar(charCode));
        }

        public QuantifiableExpression NotChar(AsciiChar value)
        {
            return AppendInternal(Characters.NotChar(value));
        }

        public QuantifiableExpression NotUnicodeBlock(UnicodeBlock block)
        {
            return AppendInternal(Characters.NotUnicodeBlock(block));
        }

        public QuantifiableExpression NotUnicodeCategory(UnicodeCategory category)
        {
            return AppendInternal(Characters.NotUnicodeCategory(category));
        }

        public QuantifiableExpression Tab()
        {
            return AppendInternal(Characters.Tab());
        }

        public QuantifierExpression Tab(int exactCount)
        {
            return AppendInternal(Characters.Tab(exactCount));
        }

        public QuantifierExpression Tab(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Tab(minCount, maxCount));
        }

        public QuantifiableExpression NotTab()
        {
            return AppendInternal(Characters.NotTab());
        }

        public QuantifierExpression NotTab(int exactCount)
        {
            return AppendInternal(Characters.NotTab(exactCount));
        }

        public QuantifierExpression NotTab(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotTab(minCount, maxCount));
        }

        public QuantifiableExpression Linefeed()
        {
            return AppendInternal(Characters.Linefeed());
        }

        public QuantifierExpression Linefeed(int exactCount)
        {
            return AppendInternal(Characters.Linefeed(exactCount));
        }

        public QuantifierExpression Linefeed(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Linefeed(minCount, maxCount));
        }

        public QuantifiableExpression NotLinefeed()
        {
            return AppendInternal(Characters.NotLinefeed());
        }

        public QuantifierExpression NotLinefeed(int exactCount)
        {
            return AppendInternal(Characters.NotLinefeed(exactCount));
        }

        public QuantifierExpression NotLinefeed(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotLinefeed(minCount, maxCount));
        }

        public QuantifiableExpression CarriageReturn()
        {
            return AppendInternal(Characters.CarriageReturn());
        }

        public QuantifierExpression CarriageReturn(int exactCount)
        {
            return AppendInternal(Characters.CarriageReturn(exactCount));
        }

        public QuantifierExpression CarriageReturn(int minCount, int maxCount)
        {
            return AppendInternal(Characters.CarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression NotCarriageReturn()
        {
            return AppendInternal(Characters.NotCarriageReturn());
        }

        public QuantifierExpression NotCarriageReturn(int exactCount)
        {
            return AppendInternal(Characters.NotCarriageReturn(exactCount));
        }

        public QuantifierExpression NotCarriageReturn(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotCarriageReturn(minCount, maxCount));
        }

        public QuantifiableExpression Space()
        {
            return AppendInternal(Characters.Space());
        }

        public QuantifierExpression Space(int exactCount)
        {
            return AppendInternal(Characters.Space(exactCount));
        }

        public QuantifierExpression Space(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Space(minCount, maxCount));
        }

        public QuantifiableExpression NotSpace()
        {
            return AppendInternal(Characters.NotSpace());
        }

        public QuantifierExpression NotSpace(int exactCount)
        {
            return AppendInternal(Characters.NotSpace(exactCount));
        }

        public QuantifierExpression NotSpace(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotSpace(minCount, maxCount));
        }

        public QuantifiableExpression ExclamationMark()
        {
            return AppendInternal(Characters.ExclamationMark());
        }

        public QuantifierExpression ExclamationMark(int exactCount)
        {
            return AppendInternal(Characters.ExclamationMark(exactCount));
        }

        public QuantifierExpression ExclamationMark(int minCount, int maxCount)
        {
            return AppendInternal(Characters.ExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotExclamationMark()
        {
            return AppendInternal(Characters.NotExclamationMark());
        }

        public QuantifierExpression NotExclamationMark(int exactCount)
        {
            return AppendInternal(Characters.NotExclamationMark(exactCount));
        }

        public QuantifierExpression NotExclamationMark(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotExclamationMark(minCount, maxCount));
        }

        public QuantifiableExpression QuotationMark()
        {
            return AppendInternal(Characters.QuotationMark());
        }

        public QuantifierExpression QuotationMark(int exactCount)
        {
            return AppendInternal(Characters.QuotationMark(exactCount));
        }

        public QuantifierExpression QuotationMark(int minCount, int maxCount)
        {
            return AppendInternal(Characters.QuotationMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuotationMark()
        {
            return AppendInternal(Characters.NotQuotationMark());
        }

        public QuantifierExpression NotQuotationMark(int exactCount)
        {
            return AppendInternal(Characters.NotQuotationMark(exactCount));
        }

        public QuantifierExpression NotQuotationMark(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotQuotationMark(minCount, maxCount));
        }

        public QuantifiableExpression NumberSign()
        {
            return AppendInternal(Characters.NumberSign());
        }

        public QuantifierExpression NumberSign(int exactCount)
        {
            return AppendInternal(Characters.NumberSign(exactCount));
        }

        public QuantifierExpression NumberSign(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NumberSign(minCount, maxCount));
        }

        public QuantifiableExpression NotNumberSign()
        {
            return AppendInternal(Characters.NotNumberSign());
        }

        public QuantifierExpression NotNumberSign(int exactCount)
        {
            return AppendInternal(Characters.NotNumberSign(exactCount));
        }

        public QuantifierExpression NotNumberSign(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotNumberSign(minCount, maxCount));
        }

        public QuantifiableExpression Dollar()
        {
            return AppendInternal(Characters.Dollar());
        }

        public QuantifierExpression Dollar(int exactCount)
        {
            return AppendInternal(Characters.Dollar(exactCount));
        }

        public QuantifierExpression Dollar(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Dollar(minCount, maxCount));
        }

        public QuantifiableExpression NotDollar()
        {
            return AppendInternal(Characters.NotDollar());
        }

        public QuantifierExpression NotDollar(int exactCount)
        {
            return AppendInternal(Characters.NotDollar(exactCount));
        }

        public QuantifierExpression NotDollar(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotDollar(minCount, maxCount));
        }

        public QuantifiableExpression Percent()
        {
            return AppendInternal(Characters.Percent());
        }

        public QuantifierExpression Percent(int exactCount)
        {
            return AppendInternal(Characters.Percent(exactCount));
        }

        public QuantifierExpression Percent(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Percent(minCount, maxCount));
        }

        public QuantifiableExpression NotPercent()
        {
            return AppendInternal(Characters.NotPercent());
        }

        public QuantifierExpression NotPercent(int exactCount)
        {
            return AppendInternal(Characters.NotPercent(exactCount));
        }

        public QuantifierExpression NotPercent(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotPercent(minCount, maxCount));
        }

        public QuantifiableExpression Ampersand()
        {
            return AppendInternal(Characters.Ampersand());
        }

        public QuantifierExpression Ampersand(int exactCount)
        {
            return AppendInternal(Characters.Ampersand(exactCount));
        }

        public QuantifierExpression Ampersand(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Ampersand(minCount, maxCount));
        }

        public QuantifiableExpression NotAmpersand()
        {
            return AppendInternal(Characters.NotAmpersand());
        }

        public QuantifierExpression NotAmpersand(int exactCount)
        {
            return AppendInternal(Characters.NotAmpersand(exactCount));
        }

        public QuantifierExpression NotAmpersand(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotAmpersand(minCount, maxCount));
        }

        public QuantifiableExpression Apostrophe()
        {
            return AppendInternal(Characters.Apostrophe());
        }

        public QuantifierExpression Apostrophe(int exactCount)
        {
            return AppendInternal(Characters.Apostrophe(exactCount));
        }

        public QuantifierExpression Apostrophe(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Apostrophe(minCount, maxCount));
        }

        public QuantifiableExpression NotApostrophe()
        {
            return AppendInternal(Characters.NotApostrophe());
        }

        public QuantifierExpression NotApostrophe(int exactCount)
        {
            return AppendInternal(Characters.NotApostrophe(exactCount));
        }

        public QuantifierExpression NotApostrophe(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotApostrophe(minCount, maxCount));
        }

        public QuantifiableExpression LeftParenthesis()
        {
            return AppendInternal(Characters.LeftParenthesis());
        }

        public QuantifierExpression LeftParenthesis(int exactCount)
        {
            return AppendInternal(Characters.LeftParenthesis(exactCount));
        }

        public QuantifierExpression LeftParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Characters.LeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftParenthesis()
        {
            return AppendInternal(Characters.NotLeftParenthesis());
        }

        public QuantifierExpression NotLeftParenthesis(int exactCount)
        {
            return AppendInternal(Characters.NotLeftParenthesis(exactCount));
        }

        public QuantifierExpression NotLeftParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotLeftParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression RightParenthesis()
        {
            return AppendInternal(Characters.RightParenthesis());
        }

        public QuantifierExpression RightParenthesis(int exactCount)
        {
            return AppendInternal(Characters.RightParenthesis(exactCount));
        }

        public QuantifierExpression RightParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Characters.RightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression NotRightParenthesis()
        {
            return AppendInternal(Characters.NotRightParenthesis());
        }

        public QuantifierExpression NotRightParenthesis(int exactCount)
        {
            return AppendInternal(Characters.NotRightParenthesis(exactCount));
        }

        public QuantifierExpression NotRightParenthesis(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotRightParenthesis(minCount, maxCount));
        }

        public QuantifiableExpression Asterisk()
        {
            return AppendInternal(Characters.Asterisk());
        }

        public QuantifierExpression Asterisk(int exactCount)
        {
            return AppendInternal(Characters.Asterisk(exactCount));
        }

        public QuantifierExpression Asterisk(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Asterisk(minCount, maxCount));
        }

        public QuantifiableExpression NotAsterisk()
        {
            return AppendInternal(Characters.NotAsterisk());
        }

        public QuantifierExpression NotAsterisk(int exactCount)
        {
            return AppendInternal(Characters.NotAsterisk(exactCount));
        }

        public QuantifierExpression NotAsterisk(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotAsterisk(minCount, maxCount));
        }

        public QuantifiableExpression Plus()
        {
            return AppendInternal(Characters.Plus());
        }

        public QuantifierExpression Plus(int exactCount)
        {
            return AppendInternal(Characters.Plus(exactCount));
        }

        public QuantifierExpression Plus(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Plus(minCount, maxCount));
        }

        public QuantifiableExpression NotPlus()
        {
            return AppendInternal(Characters.NotPlus());
        }

        public QuantifierExpression NotPlus(int exactCount)
        {
            return AppendInternal(Characters.NotPlus(exactCount));
        }

        public QuantifierExpression NotPlus(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotPlus(minCount, maxCount));
        }

        public QuantifiableExpression Comma()
        {
            return AppendInternal(Characters.Comma());
        }

        public QuantifierExpression Comma(int exactCount)
        {
            return AppendInternal(Characters.Comma(exactCount));
        }

        public QuantifierExpression Comma(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Comma(minCount, maxCount));
        }

        public QuantifiableExpression NotComma()
        {
            return AppendInternal(Characters.NotComma());
        }

        public QuantifierExpression NotComma(int exactCount)
        {
            return AppendInternal(Characters.NotComma(exactCount));
        }

        public QuantifierExpression NotComma(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotComma(minCount, maxCount));
        }

        public QuantifiableExpression Hyphen()
        {
            return AppendInternal(Characters.Hyphen());
        }

        public QuantifierExpression Hyphen(int exactCount)
        {
            return AppendInternal(Characters.Hyphen(exactCount));
        }

        public QuantifierExpression Hyphen(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Hyphen(minCount, maxCount));
        }

        public QuantifiableExpression NotHyphen()
        {
            return AppendInternal(Characters.NotHyphen());
        }

        public QuantifierExpression NotHyphen(int exactCount)
        {
            return AppendInternal(Characters.NotHyphen(exactCount));
        }

        public QuantifierExpression NotHyphen(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotHyphen(minCount, maxCount));
        }

        public QuantifiableExpression Period()
        {
            return AppendInternal(Characters.Period());
        }

        public QuantifierExpression Period(int exactCount)
        {
            return AppendInternal(Characters.Period(exactCount));
        }

        public QuantifierExpression Period(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Period(minCount, maxCount));
        }

        public QuantifiableExpression NotPeriod()
        {
            return AppendInternal(Characters.NotPeriod());
        }

        public QuantifierExpression NotPeriod(int exactCount)
        {
            return AppendInternal(Characters.NotPeriod(exactCount));
        }

        public QuantifierExpression NotPeriod(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotPeriod(minCount, maxCount));
        }

        public QuantifiableExpression Slash()
        {
            return AppendInternal(Characters.Slash());
        }

        public QuantifierExpression Slash(int exactCount)
        {
            return AppendInternal(Characters.Slash(exactCount));
        }

        public QuantifierExpression Slash(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Slash(minCount, maxCount));
        }

        public QuantifiableExpression NotSlash()
        {
            return AppendInternal(Characters.NotSlash());
        }

        public QuantifierExpression NotSlash(int exactCount)
        {
            return AppendInternal(Characters.NotSlash(exactCount));
        }

        public QuantifierExpression NotSlash(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotSlash(minCount, maxCount));
        }

        public QuantifiableExpression Colon()
        {
            return AppendInternal(Characters.Colon());
        }

        public QuantifierExpression Colon(int exactCount)
        {
            return AppendInternal(Characters.Colon(exactCount));
        }

        public QuantifierExpression Colon(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Colon(minCount, maxCount));
        }

        public QuantifiableExpression NotColon()
        {
            return AppendInternal(Characters.NotColon());
        }

        public QuantifierExpression NotColon(int exactCount)
        {
            return AppendInternal(Characters.NotColon(exactCount));
        }

        public QuantifierExpression NotColon(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotColon(minCount, maxCount));
        }

        public QuantifiableExpression Semicolon()
        {
            return AppendInternal(Characters.Semicolon());
        }

        public QuantifierExpression Semicolon(int exactCount)
        {
            return AppendInternal(Characters.Semicolon(exactCount));
        }

        public QuantifierExpression Semicolon(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Semicolon(minCount, maxCount));
        }

        public QuantifiableExpression NotSemicolon()
        {
            return AppendInternal(Characters.NotSemicolon());
        }

        public QuantifierExpression NotSemicolon(int exactCount)
        {
            return AppendInternal(Characters.NotSemicolon(exactCount));
        }

        public QuantifierExpression NotSemicolon(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotSemicolon(minCount, maxCount));
        }

        public QuantifiableExpression LessThan()
        {
            return AppendInternal(Characters.LessThan());
        }

        public QuantifierExpression LessThan(int exactCount)
        {
            return AppendInternal(Characters.LessThan(exactCount));
        }

        public QuantifierExpression LessThan(int minCount, int maxCount)
        {
            return AppendInternal(Characters.LessThan(minCount, maxCount));
        }

        public QuantifiableExpression NotLessThan()
        {
            return AppendInternal(Characters.NotLessThan());
        }

        public QuantifierExpression NotLessThan(int exactCount)
        {
            return AppendInternal(Characters.NotLessThan(exactCount));
        }

        public QuantifierExpression NotLessThan(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotLessThan(minCount, maxCount));
        }

        public QuantifiableExpression EqualsSign()
        {
            return AppendInternal(Characters.EqualsSign());
        }

        public QuantifierExpression EqualsSign(int exactCount)
        {
            return AppendInternal(Characters.EqualsSign(exactCount));
        }

        public QuantifierExpression EqualsSign(int minCount, int maxCount)
        {
            return AppendInternal(Characters.EqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression NotEqualsSign()
        {
            return AppendInternal(Characters.NotEqualsSign());
        }

        public QuantifierExpression NotEqualsSign(int exactCount)
        {
            return AppendInternal(Characters.NotEqualsSign(exactCount));
        }

        public QuantifierExpression NotEqualsSign(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotEqualsSign(minCount, maxCount));
        }

        public QuantifiableExpression GreaterThan()
        {
            return AppendInternal(Characters.GreaterThan());
        }

        public QuantifierExpression GreaterThan(int exactCount)
        {
            return AppendInternal(Characters.GreaterThan(exactCount));
        }

        public QuantifierExpression GreaterThan(int minCount, int maxCount)
        {
            return AppendInternal(Characters.GreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression NotGreaterThan()
        {
            return AppendInternal(Characters.NotGreaterThan());
        }

        public QuantifierExpression NotGreaterThan(int exactCount)
        {
            return AppendInternal(Characters.NotGreaterThan(exactCount));
        }

        public QuantifierExpression NotGreaterThan(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotGreaterThan(minCount, maxCount));
        }

        public QuantifiableExpression QuestionMark()
        {
            return AppendInternal(Characters.QuestionMark());
        }

        public QuantifierExpression QuestionMark(int exactCount)
        {
            return AppendInternal(Characters.QuestionMark(exactCount));
        }

        public QuantifierExpression QuestionMark(int minCount, int maxCount)
        {
            return AppendInternal(Characters.QuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression NotQuestionMark()
        {
            return AppendInternal(Characters.NotQuestionMark());
        }

        public QuantifierExpression NotQuestionMark(int exactCount)
        {
            return AppendInternal(Characters.NotQuestionMark(exactCount));
        }

        public QuantifierExpression NotQuestionMark(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotQuestionMark(minCount, maxCount));
        }

        public QuantifiableExpression At()
        {
            return AppendInternal(Characters.At());
        }

        public QuantifierExpression At(int exactCount)
        {
            return AppendInternal(Characters.At(exactCount));
        }

        public QuantifierExpression At(int minCount, int maxCount)
        {
            return AppendInternal(Characters.At(minCount, maxCount));
        }

        public QuantifiableExpression NotAt()
        {
            return AppendInternal(Characters.NotAt());
        }

        public QuantifierExpression NotAt(int exactCount)
        {
            return AppendInternal(Characters.NotAt(exactCount));
        }

        public QuantifierExpression NotAt(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotAt(minCount, maxCount));
        }

        public QuantifiableExpression LeftSquareBracket()
        {
            return AppendInternal(Characters.LeftSquareBracket());
        }

        public QuantifierExpression LeftSquareBracket(int exactCount)
        {
            return AppendInternal(Characters.LeftSquareBracket(exactCount));
        }

        public QuantifierExpression LeftSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.LeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftSquareBracket()
        {
            return AppendInternal(Characters.NotLeftSquareBracket());
        }

        public QuantifierExpression NotLeftSquareBracket(int exactCount)
        {
            return AppendInternal(Characters.NotLeftSquareBracket(exactCount));
        }

        public QuantifierExpression NotLeftSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotLeftSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression Backslash()
        {
            return AppendInternal(Characters.Backslash());
        }

        public QuantifierExpression Backslash(int exactCount)
        {
            return AppendInternal(Characters.Backslash(exactCount));
        }

        public QuantifierExpression Backslash(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Backslash(minCount, maxCount));
        }

        public QuantifiableExpression NotBackslash()
        {
            return AppendInternal(Characters.NotBackslash());
        }

        public QuantifierExpression NotBackslash(int exactCount)
        {
            return AppendInternal(Characters.NotBackslash(exactCount));
        }

        public QuantifierExpression NotBackslash(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotBackslash(minCount, maxCount));
        }

        public QuantifiableExpression RightSquareBracket()
        {
            return AppendInternal(Characters.RightSquareBracket());
        }

        public QuantifierExpression RightSquareBracket(int exactCount)
        {
            return AppendInternal(Characters.RightSquareBracket(exactCount));
        }

        public QuantifierExpression RightSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.RightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightSquareBracket()
        {
            return AppendInternal(Characters.NotRightSquareBracket());
        }

        public QuantifierExpression NotRightSquareBracket(int exactCount)
        {
            return AppendInternal(Characters.NotRightSquareBracket(exactCount));
        }

        public QuantifierExpression NotRightSquareBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotRightSquareBracket(minCount, maxCount));
        }

        public QuantifiableExpression CircumflexAccent()
        {
            return AppendInternal(Characters.CircumflexAccent());
        }

        public QuantifierExpression CircumflexAccent(int exactCount)
        {
            return AppendInternal(Characters.CircumflexAccent(exactCount));
        }

        public QuantifierExpression CircumflexAccent(int minCount, int maxCount)
        {
            return AppendInternal(Characters.CircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotCircumflexAccent()
        {
            return AppendInternal(Characters.NotCircumflexAccent());
        }

        public QuantifierExpression NotCircumflexAccent(int exactCount)
        {
            return AppendInternal(Characters.NotCircumflexAccent(exactCount));
        }

        public QuantifierExpression NotCircumflexAccent(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotCircumflexAccent(minCount, maxCount));
        }

        public QuantifiableExpression Underscore()
        {
            return AppendInternal(Characters.Underscore());
        }

        public QuantifierExpression Underscore(int exactCount)
        {
            return AppendInternal(Characters.Underscore(exactCount));
        }

        public QuantifierExpression Underscore(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Underscore(minCount, maxCount));
        }

        public QuantifiableExpression NotUnderscore()
        {
            return AppendInternal(Characters.NotUnderscore());
        }

        public QuantifierExpression NotUnderscore(int exactCount)
        {
            return AppendInternal(Characters.NotUnderscore(exactCount));
        }

        public QuantifierExpression NotUnderscore(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotUnderscore(minCount, maxCount));
        }

        public QuantifiableExpression GraveAccent()
        {
            return AppendInternal(Characters.GraveAccent());
        }

        public QuantifierExpression GraveAccent(int exactCount)
        {
            return AppendInternal(Characters.GraveAccent(exactCount));
        }

        public QuantifierExpression GraveAccent(int minCount, int maxCount)
        {
            return AppendInternal(Characters.GraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression NotGraveAccent()
        {
            return AppendInternal(Characters.NotGraveAccent());
        }

        public QuantifierExpression NotGraveAccent(int exactCount)
        {
            return AppendInternal(Characters.NotGraveAccent(exactCount));
        }

        public QuantifierExpression NotGraveAccent(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotGraveAccent(minCount, maxCount));
        }

        public QuantifiableExpression LeftCurlyBracket()
        {
            return AppendInternal(Characters.LeftCurlyBracket());
        }

        public QuantifierExpression LeftCurlyBracket(int exactCount)
        {
            return AppendInternal(Characters.LeftCurlyBracket(exactCount));
        }

        public QuantifierExpression LeftCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.LeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotLeftCurlyBracket()
        {
            return AppendInternal(Characters.NotLeftCurlyBracket());
        }

        public QuantifierExpression NotLeftCurlyBracket(int exactCount)
        {
            return AppendInternal(Characters.NotLeftCurlyBracket(exactCount));
        }

        public QuantifierExpression NotLeftCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotLeftCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression VerticalLine()
        {
            return AppendInternal(Characters.VerticalLine());
        }

        public QuantifierExpression VerticalLine(int exactCount)
        {
            return AppendInternal(Characters.VerticalLine(exactCount));
        }

        public QuantifierExpression VerticalLine(int minCount, int maxCount)
        {
            return AppendInternal(Characters.VerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression NotVerticalLine()
        {
            return AppendInternal(Characters.NotVerticalLine());
        }

        public QuantifierExpression NotVerticalLine(int exactCount)
        {
            return AppendInternal(Characters.NotVerticalLine(exactCount));
        }

        public QuantifierExpression NotVerticalLine(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotVerticalLine(minCount, maxCount));
        }

        public QuantifiableExpression RightCurlyBracket()
        {
            return AppendInternal(Characters.RightCurlyBracket());
        }

        public QuantifierExpression RightCurlyBracket(int exactCount)
        {
            return AppendInternal(Characters.RightCurlyBracket(exactCount));
        }

        public QuantifierExpression RightCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.RightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression NotRightCurlyBracket()
        {
            return AppendInternal(Characters.NotRightCurlyBracket());
        }

        public QuantifierExpression NotRightCurlyBracket(int exactCount)
        {
            return AppendInternal(Characters.NotRightCurlyBracket(exactCount));
        }

        public QuantifierExpression NotRightCurlyBracket(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotRightCurlyBracket(minCount, maxCount));
        }

        public QuantifiableExpression Tilde()
        {
            return AppendInternal(Characters.Tilde());
        }

        public QuantifierExpression Tilde(int exactCount)
        {
            return AppendInternal(Characters.Tilde(exactCount));
        }

        public QuantifierExpression Tilde(int minCount, int maxCount)
        {
            return AppendInternal(Characters.Tilde(minCount, maxCount));
        }

        public QuantifiableExpression NotTilde()
        {
            return AppendInternal(Characters.NotTilde());
        }

        public QuantifierExpression NotTilde(int exactCount)
        {
            return AppendInternal(Characters.NotTilde(exactCount));
        }

        public QuantifierExpression NotTilde(int minCount, int maxCount)
        {
            return AppendInternal(Characters.NotTilde(minCount, maxCount));
        }

        public QuantifierExpression Maybe(string value)
        {
            return AppendInternal(Quantifiers.Maybe(value));
        }

        public QuantifierExpression Maybe(Expression value)
        {
            return AppendInternal(Quantifiers.Maybe(value));
        }

        public QuantifierExpression MaybeMany(string value)
        {
            return AppendInternal(Quantifiers.MaybeMany(value));
        }

        public QuantifierExpression MaybeMany(Expression value)
        {
            return AppendInternal(Quantifiers.MaybeMany(value));
        }

        public QuantifierExpression OneMany(string value)
        {
            return AppendInternal(Quantifiers.OneMany(value));
        }

        public QuantifierExpression OneMany(Expression value)
        {
            return AppendInternal(Quantifiers.OneMany(value));
        }

        public QuantifierExpression Count(string value, int exactCount)
        {
            return AppendInternal(Quantifiers.Count(value, exactCount));
        }

        public QuantifierExpression Count(Expression expression, int exactCount)
        {
            return AppendInternal(Quantifiers.Count(expression, exactCount));
        }

        public QuantifierExpression CountFrom(string value, int minCount)
        {
            return AppendInternal(Quantifiers.CountFrom(value, minCount));
        }

        public QuantifierExpression CountFrom(Expression expression, int minCount)
        {
            return AppendInternal(Quantifiers.CountFrom(expression, minCount));
        }

        public QuantifierExpression CountRange(string value, int minCount, int maxCount)
        {
            return AppendInternal(Quantifiers.CountRange(value, minCount, maxCount));
        }

        public QuantifierExpression CountRange(Expression expression, int minCount, int maxCount)
        {
            return AppendInternal(Quantifiers.CountRange(expression, minCount, maxCount));
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
