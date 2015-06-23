﻿    // Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("email");

            var left = new OneMany(CharGroupItem.Create("!#$%&'*+/=?^_`{|}~-").Alphanumeric());

            var right = new Maybe(new MaybeMany(CharGroupItem.Create("-").Alphanumeric()).Alphanumeric());

            var exp = left
                .MaybeMany("." + left)
                .At()
                .OneMany(Patterns.Alphanumeric() + right + ".")
                .Alphanumeric()
                .Concat(right);

            Console.WriteLine(exp);
            Console.WriteLine("");

            Console.WriteLine("cdata value");
            Console.WriteLine(Patterns
                .LessThanGreaterThan(
                    "!" + Patterns.SquareBrackets(
                        "CDATA" + Patterns.SquareBrackets(
                            Patterns.CrawlInvariant().AsCapturingGroup()
                        )
                    )
                ));
            Console.WriteLine("");

            var values = new string[] { "one", "two", "three" };

            Console.WriteLine("multiple words");
            Console.WriteLine(
                Patterns.WordBoundary()
                .Count(3,
                    new AnyGroup(values.Select(f => new CapturingGroup(f)))
                    .WordBoundary()
                    .NotWordChar().MaybeMany().Lazy())
                .RequireGroups(1, 2, 3));
            Console.WriteLine("");

            Console.WriteLine("multiple words 2");
            Console.WriteLine(
                Patterns.WordBoundary()
                .CountFrom(3,
                    new AnyGroup(values.Select(f => Pattern.Create(f).AsCapturingGroup()))
                    .WordBoundary()
                    .NotWordChar().MaybeMany().Lazy())
                .GroupReference(1)
                .GroupReference(2)
                .GroupReference(3));
            Console.WriteLine("");

            var quotedChar = Patterns.NotChar(CharGroupItems.QuoteMark().NewLineChar()).MaybeMany();

            Console.WriteLine("quoted text");
            Console.WriteLine(Patterns.QuoteMarks(
                quotedChar
                .MaybeMany(Patterns.QuoteMark(2) + quotedChar)));
            Console.WriteLine("");

            Console.WriteLine("digits inside b element value");
            Console.WriteLine(Patterns
                .Digits()
                .Assert(
                    new MaybeMany(new NotAssert("<b>").Any())
                    .Concat("</b>")));
            Console.WriteLine("");

            Console.WriteLine("repeated word");
            Console.WriteLine(Patterns.Word().AsCapturingGroup()
                .WhiteSpaces()
                .GroupReference(1)
                .WordBoundary());
            Console.WriteLine("");

            Console.WriteLine("any word");
            Console.WriteLine(Patterns.Word("word1", "word2", "word3"));
            Console.WriteLine("");

            Console.WriteLine("words in any order:");
            Console.WriteLine(Patterns.StartOfLine()
                .Assert(Patterns.CrawlInvariant().Word("word1"))
                .Assert(Patterns.CrawlInvariant().Word("word2"))
                .AnyInvariant().MaybeMany());
            Console.WriteLine("");

            Console.WriteLine("leading whitespace:");
            Console.WriteLine(Patterns.StartOfLine().WhiteSpaceExceptNewLine().OneMany());
            Console.WriteLine("");

            Console.WriteLine("trailing whitespace:");
            Console.WriteLine(Patterns.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn());
            Console.WriteLine("");

            Console.WriteLine("leading trailing whitespace:");
            Console.WriteLine(new AnyGroup(
                Patterns.StartOfLine().WhiteSpaceExceptNewLine().OneMany(),
                Patterns.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn()));
            Console.WriteLine("");

            Console.WriteLine("whitespace lines:");
            Console.WriteLine(
                Patterns.StartOfLineInvariant().WhiteSpace().MaybeMany().NewLine() |
                Patterns.NewLine().WhiteSpace().MaybeMany().EndOfInput());
            Console.WriteLine("");

            Console.WriteLine("empty lines:");
            Console.WriteLine(
                Patterns.StartOfLineInvariant().NewLine() |
                Patterns.NewLine().Assert(Patterns.NewLine().MaybeMany().EndOfInput()));
            Console.WriteLine("");

            Console.WriteLine("first line:");
            Console.WriteLine(
                Patterns.StartOfInput()
                .NotNewLineChar().MaybeMany());
            Console.WriteLine("");

            Console.WriteLine("lf without cr:");
            Console.WriteLine(new NotAssertBack(Patterns.CarriageReturn()).Linefeed().AsNonbacktrackingGroup());
            Console.WriteLine((new NotAssertBack("\r") + "\n").AsNonbacktrackingGroup());
            Console.WriteLine("");

            Console.WriteLine("invalid file name chars:");
            var chars = Path.GetInvalidFileNameChars().OrderBy(f => (int)f).Select(f => Patterns.Char(f));
            Console.WriteLine(new AnyGroup(chars).AsNonbacktrackingGroup());
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
