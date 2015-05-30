    // Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            var exp = Expressions.LessThanGreaterThan(
                Chars.ExclamationMark().SquareBrackets(
                    Expressions.Text("CDATA").SquareBrackets(
                        Chars.AnyMaybeManyLazyInvariant()
                    )
                )
            );
            Console.WriteLine(exp);
            Console.WriteLine("");

            var values = new string[] { "one?", "two", "three" };

            Console.WriteLine("multiple words");
            Console.WriteLine(Anchors
                .WordBoundary()
                .Noncapturing(Alternations
                    .Any(values.Select(f => Groups.Capturing(f)))
                    .WordBoundary()
                    .NotWordChar().MaybeMany().Lazy()
                ).Count(3)
                .RequireGroups(1, 2, 3));
            Console.WriteLine("");

            Console.WriteLine("multiple words 2");
            Console.WriteLine(Anchors
                .WordBoundary()
                .Noncapturing(Alternations
                    .Any(values.Select(f => Expressions.Text(f).Capturing()))
                    .WordBoundary()
                    .NotWordChar().MaybeMany().Lazy()
                ).CountFrom(3)
                .Backreference(1)
                .Backreference(2)
                .Backreference(3));
            Console.WriteLine("");

            var quotedChar = Chars.NotChar(CharGroupItems.QuoteMark().NewLineChar()).MaybeMany();

            Console.WriteLine("quoted text");
            Console.WriteLine(Expressions.QuoteMarks(
                quotedChar
                .MaybeMany(Chars.QuoteMark(2).Concat(quotedChar))));
            Console.WriteLine("");

            Console.WriteLine("digits inside b element value");
            Console.WriteLine(Chars
                .Digit().OneMany()
                .Assert(Groups
                    .MaybeMany(Anchors.NotAssert("<b>").Any())
                    .Text("</b>")));
            Console.WriteLine("");

            Console.WriteLine("repeated word");
            Console.WriteLine(Anchors.Word(Chars
                .WordChar().OneMany().AsCapturing()
                .WhiteSpace().OneMany()
                .Backreference(1)));
            Console.WriteLine("");

            Console.WriteLine("any word");
            Console.WriteLine(Anchors.Word(Alternations.Any("word1", "word2", "word3")));
            Console.WriteLine("");

            Console.WriteLine("words in any order:");
            Console.WriteLine(Anchors.StartOfLine()
                .Assert(Chars.AnyMaybeManyLazyInvariant().Word("word1"))
                .Assert(Chars.AnyMaybeManyLazyInvariant().Word("word2"))
                .AnyInvariant().MaybeMany());
            Console.WriteLine("");

            Console.WriteLine("leading whitespace:");
            Console.WriteLine(Anchors.StartOfLine().WhiteSpaceExceptNewLine().OneMany());
            Console.WriteLine("");

            Console.WriteLine("trailing whitespace:");
            Console.WriteLine(Chars.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn());
            Console.WriteLine("");

            Console.WriteLine("leading trailing whitespace:");
            Console.WriteLine(Alternations.Any(
                Anchors.StartOfLine().WhiteSpaceExceptNewLine().OneMany(),
                Chars.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn()));
            Console.WriteLine("");

            Console.WriteLine("whitespace lines:");
            Console.WriteLine(Alternations.Any(Anchors
                    .StartOfLine().WhiteSpace().MaybeMany().NewLine(),
                    Expressions.NewLine().WhiteSpace().MaybeMany().End())
                .WithOptions(InlineOptions.Multiline));
            Console.WriteLine("");

            Console.WriteLine("empty lines:");
            Console.WriteLine(Alternations.Any(Anchors
                    .StartOfLine().NewLine(),
                    Expressions.NewLine().OneMany().End())
                .WithOptions(InlineOptions.Multiline));
            Console.WriteLine("");

            Console.WriteLine("first line:");
            Console.WriteLine(Anchors
                .Start()
                .NotNewLineChar().MaybeMany()
                .EndOfLineOrBeforeCarriageReturnInvariant());
            Console.WriteLine("");

            Console.WriteLine("lf without cr:");
            Console.WriteLine(Anchors.NotAssertBack(Chars.CarriageReturn()).Linefeed().AsNonbacktracking());
            Console.WriteLine("");

            Console.WriteLine("invalid file name chars:");
            var chars = Path.GetInvalidFileNameChars().OrderBy(f => (int)f).Select(f => Chars.Char(f));
            Console.WriteLine(Alternations.Any(chars).AsNonbacktracking());
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
