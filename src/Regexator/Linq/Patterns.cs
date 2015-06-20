// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Patterns
    {
        internal static QuantifiablePattern Or(object left, object right)
        {
            return new OrContainer(left, right);
        }

        public static QuantifiablePattern IfGroup(string groupName, object trueContent)
        {
            return new IfGroup(groupName, trueContent);
        }

        public static QuantifiablePattern IfGroup(string groupName, object trueContent, object falseContent)
        {
            return new IfGroup(groupName, trueContent, falseContent);
        }

        public static QuantifiablePattern IfGroup(int groupNumber, object trueContent)
        {
            return new IfGroup(groupNumber, trueContent);
        }

        public static QuantifiablePattern IfGroup(int groupNumber, object trueContent, object falseContent)
        {
            return new IfGroup(groupNumber, trueContent, falseContent);
        }

        public static QuantifiablePattern If(Pattern testContent, object trueContent)
        {
            return new IfAssert(testContent, trueContent);
        }

        public static QuantifiablePattern If(Pattern testContent, object trueContent, object falseContent)
        {
            return new IfAssert(testContent, trueContent, falseContent);
        }

        public static QuantifiablePattern Assert(object content)
        {
            return new Assert(content);
        }

        public static QuantifiablePattern Assert(params object[] content)
        {
            return Assert((object)content);
        }

        public static QuantifiablePattern NotAssert(object content)
        {
            return new NotAssert(content);
        }

        public static QuantifiablePattern NotAssert(params object[] content)
        {
            return NotAssert((object)content);
        }

        public static QuantifiablePattern AssertBack(object content)
        {
            return new AssertBack(content);
        }

        public static QuantifiablePattern AssertBack(params object[] content)
        {
            return AssertBack((object)content);
        }

        public static QuantifiablePattern NotAssertBack(object content)
        {
            return new NotAssertBack(content);
        }

        public static QuantifiablePattern NotAssertBack(params object[] content)
        {
            return NotAssertBack((object)content);
        }

        public static Pattern AssertSurround(object surroundContent, object content)
        {
            return AssertSurround(surroundContent, content, surroundContent);
        }

        public static Pattern AssertSurround(object contentBefore, object content, object contentAfter)
        {
            return new AssertSurround(contentBefore, content, contentAfter);
        }

        public static Pattern NotAssertSurround(object surroundContent, object content)
        {
            return NotAssertSurround(surroundContent, content, surroundContent);
        }

        public static Pattern NotAssertSurround(object contentBefore, object content, object contentAfter)
        {
            return new NotAssertSurround(contentBefore, content, contentAfter);
        }

        public static QuantifiablePattern StartOfInput()
        {
            return new StartOfInput();
        }

        public static QuantifiablePattern StartOfLine()
        {
            return new StartOfLine();
        }

        public static QuantifiablePattern StartOfLineInvariant()
        {
            return GroupOptions.Apply(InlineOptions.Multiline, StartOfLine());
        }

        public static QuantifiablePattern EndOfLine()
        {
            return new EndOfLine();
        }

        public static QuantifiablePattern EndOfLineInvariant()
        {
            return GroupOptions.Apply(InlineOptions.Multiline, EndOfLine());
        }

        public static QuantifiablePattern EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true, false);
        }

        public static QuantifiablePattern EndOfLineOrBeforeCarriageReturnInvariant()
        {
            return EndOfLine(true, true);
        }

        internal static QuantifiablePattern EndOfLine(bool beforeCarriageReturn, bool invariant)
        {
            if (beforeCarriageReturn)
            {
                if (invariant)
                {
                    return new NotAssertBack(Chars.CarriageReturn()).Assert(Chars.CarriageReturn().Maybe().EndOfLineInvariant());
                }
                else
                {
                    return new NotAssertBack(Chars.CarriageReturn()).Assert(Chars.CarriageReturn().Maybe().EndOfLine());
                }
            }
            else
            {
                if (invariant)
                {
                    return new EndOfLineInvariant();
                }
                else
                {
                    return new EndOfLine();
                }
            }
        }

        public static QuantifiablePattern EndOfInput()
        {
            return new EndOfInput();
        }

        public static QuantifiablePattern EndOrBeforeEndingNewLine()
        {
            return new EndOrBeforeEndingNewLine();
        }

        public static QuantifiablePattern PreviousMatchEnd()
        {
            return new PreviousMatchEnd();
        }

        public static QuantifiablePattern WordBoundary()
        {
            return new WordBoundary();
        }

        public static QuantifiablePattern NotWordBoundary()
        {
            return new NotWordBoundary();
        }

        public static QuantifiablePattern Word()
        {
            return Pattern.Surround(new WordBoundary(), Chars.WordChars()).AsNoncapturing();
        }

        public static QuantifiablePattern Word(string text)
        {
            return Pattern.Surround(new WordBoundary(), text).AsNoncapturing();
        }

        public static QuantifiablePattern Word(params string[] values)
        {
            return Pattern.Surround(new WordBoundary(), new AnyGroup(values)).AsNoncapturing();
        }

        public static Pattern Line(object content)
        {
            return Pattern.Surround(new StartOfLine(), content, new EndOfLine());
        }

        public static Pattern Line(params object[] content)
        {
            return Line((object)content);
        }

        public static Pattern LineInvariant(object content)
        {
            return Pattern.Surround(new StartOfLineInvariant(), content, new EndOfLineInvariant());
        }

        public static Pattern EntireInput(object content)
        {
            return Pattern.Surround(new StartOfInput(), content, new EndOfInput());
        }

        public static Pattern EntireInput(params object[] content)
        {
            return EntireInput((object)content);
        }

        public static QuantifiablePattern Any(IEnumerable<object> values)
        {
            return new AnyGroup(values);
        }

        public static QuantifiablePattern Any(params object[] content)
        {
            return new AnyGroup(content);
        }

        public static QuantifiablePattern NamedGroup(string name, object content)
        {
            return new NamedGroup(name, content);
        }

        public static QuantifiablePattern NamedGroup(string name, params object[] content)
        {
            return NamedGroup(name, (object)content);
        }

        public static QuantifiablePattern Group()
        {
            return new CapturingGroup(string.Empty);
        }

        public static QuantifiablePattern Group(object content)
        {
            return new CapturingGroup(content);
        }

        public static QuantifiablePattern Group(params object[] content)
        {
            return Group((object)content);
        }

        public static QuantifiablePattern Noncapturing(object content)
        {
            return new NoncapturingGroup(content);
        }

        public static QuantifiablePattern Noncapturing(params object[] content)
        {
            return Noncapturing((object)content);
        }

        public static QuantifiablePattern BalanceGroup(string name1, string name2, object content)
        {
            return new BalanceGroup(name1, name2, content);
        }

        public static QuantifiablePattern BalanceGroup(string name1, string name2, params object[] content)
        {
            return BalanceGroup(name1, name2, (object)content);
        }

        public static QuantifiablePattern Nonbacktracking(object content)
        {
            return new NonbacktrackingGroup(content);
        }

        public static QuantifiablePattern Nonbacktracking(params object[] content)
        {
            return Nonbacktracking((object)content);
        }

        public static QuantifierGroup Maybe(object content)
        {
            return new Maybe(content);
        }

        public static QuantifierGroup Maybe(params object[] content)
        {
            return new Maybe((object)content);
        }

        public static QuantifierGroup MaybeMany(object content)
        {
            return new MaybeMany(content);
        }

        public static QuantifierGroup MaybeMany(params object[] content)
        {
            return new MaybeMany((object)content);
        }

        public static QuantifierGroup OneMany(object content)
        {
            return new OneMany(content);
        }

        public static QuantifierGroup OneMany(params object[] content)
        {
            return new OneMany((object)content);
        }

        public static QuantifierGroup Count(int exactCount, object content)
        {
            return new Count(exactCount, content);
        }

        public static QuantifierGroup Count(int exactCount, params object[] content)
        {
            return new Count(exactCount, (object)content);
        }

        public static QuantifierGroup CountFrom(int minCount, object content)
        {
            return new CountFrom(minCount, content);
        }

        public static QuantifierGroup CountFrom(int minCount, params object[] content)
        {
            return new CountFrom(minCount, (object)content);
        }

        public static QuantifierGroup CountRange(int minCount, int maxCount, object content)
        {
            return new CountRange(minCount, maxCount, content);
        }

        public static QuantifierGroup CountRange(int minCount, int maxCount, params object[] content)
        {
            return new CountRange(minCount, maxCount, (object)content);
        }

        public static QuantifierGroup CountTo(int maxCount, object content)
        {
            return new CountTo(maxCount, content);
        }

        public static QuantifierGroup CountTo(int maxCount, params object[] content)
        {
            return new CountTo(maxCount, (object)content);
        }

        public static QuantifiablePattern GroupReference(int groupNumber)
        {
            return new NumberedGroupReference(groupNumber);
        }

        public static QuantifiablePattern GroupReference(string groupName)
        {
            return new NamedGroupReference(groupName);
        }

        public static Pattern ApplyOptions(InlineOptions options)
        {
            return new Options(options, InlineOptions.None);
        }

        public static QuantifiablePattern ApplyOptions(InlineOptions options, object content)
        {
            return new GroupOptions(options, InlineOptions.None, content);
        }

        public static QuantifiablePattern ApplyOptions(InlineOptions options, params object[] content)
        {
            return new GroupOptions(options, InlineOptions.None, content);
        }

        public static Pattern DisableOptions(InlineOptions options)
        {
            return new Options(InlineOptions.None, options);
        }

        public static QuantifiablePattern DisableOptions(InlineOptions options, object content)
        {
            return new GroupOptions(InlineOptions.None, options, content);
        }

        public static QuantifiablePattern DisableOptions(InlineOptions options, params object[] content)
        {
            return new GroupOptions(InlineOptions.None, options, (object)content);
        }

        public static Pattern Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            return new Options(applyOptions, disableOptions);
        }

        public static QuantifiablePattern Options(InlineOptions applyOptions, InlineOptions disableOptions, params object[] content)
        {
            return Options(applyOptions, disableOptions, (object)content);
        }

        public static QuantifiablePattern Options(InlineOptions applyOptions, InlineOptions disableOptions, object content)
        {
            return new GroupOptions(applyOptions, disableOptions, content);
        }

        public static Pattern Comment(string value)
        {
            return new InlineComment(value);
        }

        public static Pattern Crawl()
        {
            return Chars.Any().MaybeMany().Lazy();
        }

        public static Pattern CrawlInvariant()
        {
            return Chars.AnyInvariant().MaybeMany().Lazy();
        }

        public static QuantifiablePattern Never()
        {
            return new NotAssert(string.Empty);
        }

        public static QuantifiablePattern NewLine()
        {
            return Chars.CarriageReturn().Maybe().Linefeed().AsNoncapturing();
        }

        public static QuantifiablePattern LinefeedWithoutCarriageReturn()
        {
            return new NotAssertBack(Chars.CarriageReturn()).Linefeed().AsNonbacktracking();
        }

        public static Pattern LeadingWhiteSpace()
        {
            return new StartOfLine().WhiteSpaceExceptNewLine().OneMany();
        }

        public static Pattern TrailingWhiteSpace()
        {
            return Chars.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn();
        }

        public static QuantifiablePattern LeadingTrailingWhiteSpace()
        {
            return new AnyGroup(LeadingWhiteSpace(), TrailingWhiteSpace());
        }

        public static QuantifiablePattern WhiteSpaceLine()
        {
            return new StartOfLineInvariant().WhiteSpace().MaybeMany().NewLine() |
                Patterns.NewLine().WhiteSpace().MaybeMany().EndOfInput();
        }

        public static QuantifiablePattern EmptyLine()
        {
            return new StartOfLineInvariant().NewLine() |
                Patterns.NewLine().Assert(Patterns.NewLine().MaybeMany().EndOfInput());
        }

        public static Pattern FirstLine()
        {
            return new StartOfInput().NotNewLineChar().MaybeMany();
        }

        public static Pattern ValidGroupName()
        {
            return Patterns.EntireInput(
                new CapturingGroup(Chars.Range('1', '9').ArabicDigit().MaybeMany()) |
                Chars.WordChar().Except(Chars.ArabicDigit()).WordChar().MaybeMany());
        }

        internal static Pattern TrimInlineComment()
        {
            return new StartOfInput().WhileNot(')');
        }
    }
}
