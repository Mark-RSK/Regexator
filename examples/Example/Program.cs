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
            Console.WriteLine("email");

            var left = new OneMany(CharGroupItem.Create("!#$%&'*+/=?^_`{|}~-").Alphanumeric());

            var right = new Maybe(new MaybeMany(CharGroupItem.Create("-").Alphanumeric()).Alphanumeric());

            var exp = left
                .MaybeMany("." + left)
                .At()
                .OneMany(Chars.Alphanumeric() + right + ".")
                .Alphanumeric()
                .Concat(right);

            Console.WriteLine(exp);
            Console.WriteLine("");

            Console.WriteLine("cdata value");
            Console.WriteLine(Chars
                .LessThanGreaterThan(
                    "!" + Chars.SquareBrackets(
                        "CDATA" + Chars.SquareBrackets(
                            Patterns.CrawlInvariant().AsGroup()
                        )
                    )
                ));
            Console.WriteLine("");

            var values = new string[] { "one", "two", "three" };

            Console.WriteLine("multiple words");
            Console.WriteLine(
                new WordBoundary()
                .Count(3, 
                    new AnyGroup(values.Select(f => new CapturingGroup(f)))
                    .WordBoundary()
                    .NotWordChar().MaybeMany().Lazy())
                .RequireGroups(1, 2, 3));
            Console.WriteLine("");

            Console.WriteLine("multiple words 2");
            Console.WriteLine(
                new WordBoundary()
                .CountFrom(3,
                    new AnyGroup(values.Select(f => Pattern.Create(f).Group()))
                    .WordBoundary()
                    .NotWordChar().MaybeMany().Lazy())
                .GroupReference(1)
                .GroupReference(2)
                .GroupReference(3));
            Console.WriteLine("");

            var quotedChar = Chars.NotChar(CharGroupItems.QuoteMark().NewLineChar()).MaybeMany();

            Console.WriteLine("quoted text");
            Console.WriteLine(Chars.QuoteMarks(
                quotedChar
                .MaybeMany(Chars.QuoteMark(2) + quotedChar)));
            Console.WriteLine("");

            Console.WriteLine("digits inside b element value");
            Console.WriteLine(Chars
                .Digits()
                .Assert(
                    new MaybeMany(new NotAssert("<b>").Any())
                    .Concat("</b>")));
            Console.WriteLine("");

            Console.WriteLine("repeated word");
            Console.WriteLine(new Word().AsGroup()
                .WhiteSpaces()
                .GroupReference(1)
                .WordBoundary());
            Console.WriteLine("");

            Console.WriteLine("any word");
            Console.WriteLine(new Word("word1", "word2", "word3"));
            Console.WriteLine("");

            Console.WriteLine("words in any order:");
            Console.WriteLine(new StartOfLine()
                .Assert(Patterns.CrawlInvariant().Word("word1"))
                .Assert(Patterns.CrawlInvariant().Word("word2"))
                .AnyInvariant().MaybeMany());
            Console.WriteLine("");

            Console.WriteLine("leading whitespace:");
            Console.WriteLine(new StartOfLine().WhiteSpaceExceptNewLine().OneMany());
            Console.WriteLine("");

            Console.WriteLine("trailing whitespace:");
            Console.WriteLine(Chars.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn());
            Console.WriteLine("");

            Console.WriteLine("leading trailing whitespace:");
            Console.WriteLine(new AnyGroup(
                new StartOfLine().WhiteSpaceExceptNewLine().OneMany(),
                Chars.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn()));
            Console.WriteLine("");

            Console.WriteLine("whitespace lines:");
            Console.WriteLine(
                new StartOfLineInvariant().WhiteSpace().MaybeMany().NewLine() |
                Patterns.NewLine().WhiteSpace().MaybeMany().EndOfInput());
            Console.WriteLine("");

            Console.WriteLine("empty lines:");
            Console.WriteLine(
                new StartOfLineInvariant().NewLine() |
                Patterns.NewLine().Assert(Patterns.NewLine().MaybeMany().EndOfInput()));
            Console.WriteLine("");

            Console.WriteLine("first line:");
            Console.WriteLine(
                new StartOfInput()
                .NotNewLineChar().MaybeMany());
            Console.WriteLine("");

            Console.WriteLine("lf without cr:");
            Console.WriteLine(new NotAssertBack(Chars.CarriageReturn()).Linefeed().AsNonbacktracking());
            Console.WriteLine((new NotAssertBack("\r") + "\n").AsNonbacktracking());
            Console.WriteLine("");

            Console.WriteLine("invalid file name chars:");
            var chars = Path.GetInvalidFileNameChars().OrderBy(f => (int)f).Select(f => Chars.Char(f));
            Console.WriteLine(new AnyGroup(chars).AsNonbacktracking());
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
