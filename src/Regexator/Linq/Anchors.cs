// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Anchors
    {
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
            return new AssertSurround(contentBefore, content, contentAfter, true);
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
            return GroupOptions.Apply(InlineOptions.Multiline, Anchors.StartOfLine());
        }

        public static QuantifiablePattern EndOfLine()
        {
            return new EndOfLine();
        }

        public static QuantifiablePattern EndOfLineInvariant()
        {
            return GroupOptions.Apply(InlineOptions.Multiline, Anchors.EndOfLine());
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
                    return NotAssertBack(Chars.CarriageReturn()).Assert(Chars.CarriageReturn().Maybe().EndOfLineInvariant());
                }
                else
                {
                    return NotAssertBack(Chars.CarriageReturn()).Assert(Chars.CarriageReturn().Maybe().EndOfLine());
                }
            }
            else
            {
                return invariant ? EndOfLineInvariant() : EndOfLine();
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

        public static QuantifiablePattern Word()
        {
            return Pattern.Surround(WordBoundary(), Chars.WordChars()).AsNoncapturing();
        }

        public static QuantifiablePattern Word(string text)
        {
            return Pattern.Surround(WordBoundary(), text).AsNoncapturing();
        }

        public static QuantifiablePattern Word(params string[] values)
        {
            return Pattern.Surround(WordBoundary(), new AnyGroup(values)).AsNoncapturing();
        }

        public static QuantifiablePattern NotWordBoundary()
        {
            return new NotWordBoundary();
        }

        public static Pattern Line(object content)
        {
            return Pattern.Surround(StartOfLine(), content, EndOfLine());
        }

        public static Pattern LineInvariant(object content)
        {
            return Pattern.Surround(StartOfLineInvariant(), content, EndOfLineInvariant());
        }

        public static Pattern EntireInput(object content)
        {
            return Pattern.Surround(StartOfInput(), content, EndOfInput());
        }
    }
}
