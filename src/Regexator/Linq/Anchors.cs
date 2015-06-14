// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public static class Anchors
    {
        public static QuantifiableExpression Assert(object content)
        {
            return new AssertExpression(content);
        }

        public static QuantifiableExpression Assert(params object[] content)
        {
            return Assert((object)content);
        }

        public static QuantifiableExpression NotAssert(object content)
        {
            return new NotAssertExpression(content);
        }

        public static QuantifiableExpression NotAssert(params object[] content)
        {
            return NotAssert((object)content);
        }

        public static QuantifiableExpression AssertBack(object content)
        {
            return new AssertBackExpression(content);
        }

        public static QuantifiableExpression AssertBack(params object[] content)
        {
            return AssertBack((object)content);
        }

        public static QuantifiableExpression NotAssertBack(object content)
        {
            return new NotAssertBackExpression(content);
        }

        public static QuantifiableExpression NotAssertBack(params object[] content)
        {
            return NotAssertBack((object)content);
        }

        public static Expression AssertSurround(object content, object surroundContent)
        {
            return Expressions.Surround(Anchors.AssertBack(surroundContent), content, Anchors.Assert(surroundContent));
        }

        public static Expression AssertSurround(object contentBefore, object content, object contentAfter)
        {
            return Expressions.Surround(Anchors.AssertBack(contentBefore), content, Anchors.Assert(contentAfter));
        }

        public static Expression NotAssertSurround(object content, object surroundContent)
        {
            return Expressions.Surround(Anchors.NotAssertBack(surroundContent), content, Anchors.NotAssert(surroundContent));
        }

        public static Expression NotAssertSurround(object contentBefore, object content, object contentAfter)
        {
            return Expressions.Surround(Anchors.NotAssertBack(contentBefore), content, Anchors.NotAssert(contentAfter));
        }

        public static QuantifiableExpression StartOfInput()
        {
            return new StartOfInput();
        }

        public static QuantifiableExpression StartOfLine()
        {
            return new StartOfLine();
        }

        public static QuantifiableExpression StartOfLineInvariant()
        {
            return Expressions.ApplyOptions(InlineOptions.Multiline, Anchors.StartOfLine());
        }

        public static QuantifiableExpression EndOfLine()
        {
            return new EndOfLine();
        }

        public static QuantifiableExpression EndOfLineInvariant()
        {
            return Expressions.ApplyOptions(InlineOptions.Multiline, Anchors.EndOfLine());
        }

        public static QuantifiableExpression EndOfLineOrBeforeCarriageReturn()
        {
            return EndOfLine(true, false);
        }

        public static QuantifiableExpression EndOfLineOrBeforeCarriageReturnInvariant()
        {
            return EndOfLine(true, true);
        }

        internal static QuantifiableExpression EndOfLine(bool beforeCarriageReturn, bool invariant)
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

        public static QuantifiableExpression EndOfInput()
        {
            return new EndOfInput();
        }

        public static QuantifiableExpression EndOrBeforeEndingNewLine()
        {
            return new EndOrBeforeEndingNewLine();
        }

        public static QuantifiableExpression PreviousMatchEnd()
        {
            return new PreviousMatchEnd();
        }

        public static QuantifiableExpression WordBoundary()
        {
            return new WordBoundary();
        }

        public static QuantifiableExpression Word()
        {
            return Expressions.Surround(Chars.WordChars(), WordBoundary()).AsNoncapturing();
        }

        public static QuantifiableExpression Word(string text)
        {
            return Expressions.Surround(text, WordBoundary()).AsNoncapturing();
        }

        public static QuantifiableExpression Word(params string[] values)
        {
            return Expressions.Surround(Alternations.Any(values), WordBoundary()).AsNoncapturing();
        }

        public static QuantifiableExpression NotWordBoundary()
        {
            return new NotWordBoundary();
        }

        public static Expression Line(object content)
        {
            return Expressions.Surround(StartOfLine(), content, EndOfLine());
        }

        public static Expression LineInvariant(object content)
        {
            return Expressions.Surround(StartOfLineInvariant(), content, EndOfLineInvariant());
        }

        public static Expression EntireInput(object content)
        {
            return Expressions.Surround(StartOfInput(), content, EndOfInput());
        }
    }
}
