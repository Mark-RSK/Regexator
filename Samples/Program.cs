    // Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("email");

            var left = Patterns.OneMany(CharGroupings.Alphanumeric() + "!#$%&'*+/=?^_`{|}~-");

            var right = Patterns.Maybe(Patterns.MaybeMany(CharGroupings.Alphanumeric() + "-").Alphanumeric());

            var exp = left
                .MaybeMany("." + left)
                .AtSign()
                .OneMany(Patterns.Alphanumeric() + right + ".")
                .Alphanumeric()
                .Concat(right);

            Console.WriteLine(exp);
            Console.WriteLine("");

            Console.WriteLine("cdata value");
            Console.WriteLine(Patterns
                .AngleBrackets(
                    "!" + Patterns.SquareBrackets(
                        "CDATA" + Patterns.SquareBrackets(
                            Patterns.CrawlInvariant().AsGroup()
                        )
                    )
                ));
            Console.WriteLine("");

            var values = new string[] { "one", "two", "three" };

            Console.WriteLine("multiple words 2");
            Console.WriteLine(
                Patterns.WordBoundary()
                .CountFrom(3,
                    Patterns.Any(values.Select(f => Patterns.Text(f).AsGroup()))
                    .WordBoundary()
                    .NotWordChar().MaybeMany().Lazy())
                .GroupReference(1)
                .GroupReference(2)
                .GroupReference(3));
            Console.WriteLine("");

            var quotedChar = (!CharGroupings.QuoteMark().NewLineChar()).MaybeMany();

            Console.WriteLine("quoted text");
            Console.WriteLine(Patterns.QuoteMarks(
                quotedChar
                .MaybeMany(Patterns.QuoteMark(2) + quotedChar)));
            Console.WriteLine("");

            Console.WriteLine("digits inside b element value");
            Console.WriteLine(Patterns
                .Digits()
                .Assert(
                    Patterns.MaybeMany(Patterns.NotAssert("<b>").Any())
                    .Text("</b>")));
            Console.WriteLine("");

            Console.WriteLine("repeated word");
            Console.WriteLine(Patterns.Word().AsGroup()
                .WhiteSpaces()
                .GroupReference(1)
                .WordBoundary());
            Console.WriteLine("");

            Console.WriteLine("any word");
            Console.WriteLine(Patterns.Word("word1", "word2", "word3"));
            Console.WriteLine("");

            Console.WriteLine("words in any order:");
            Console.WriteLine(Patterns.BeginLine()
                .Assert(Patterns.CrawlInvariant().Word("word1"))
                .Assert(Patterns.CrawlInvariant().Word("word2"))
                .AnyInvariant().MaybeMany());
            Console.WriteLine("");

            Console.WriteLine("leading whitespace:");
            Console.WriteLine(Patterns.BeginLine().WhiteSpaceExceptNewLine().OneMany());
            Console.WriteLine("");

            Console.WriteLine("trailing whitespace:");
            Console.WriteLine(Patterns.WhiteSpaceExceptNewLine().OneMany().EndLine(true));
            Console.WriteLine("");

            Console.WriteLine("leading trailing whitespace:");
            Console.WriteLine(Patterns.Any(
                Patterns.BeginLine().WhiteSpaceExceptNewLine().OneMany(),
                Patterns.WhiteSpaceExceptNewLine().OneMany().EndLine(true)));
            Console.WriteLine("");

            Console.WriteLine("whitespace lines:");
            Console.WriteLine(
                Patterns.BeginLineInvariant().WhiteSpace().MaybeMany().NewLine() |
                Patterns.NewLine().WhiteSpace().MaybeMany().EndInput());
            Console.WriteLine("");

            Console.WriteLine("empty lines:");
            Console.WriteLine(
                Patterns.BeginLineInvariant().NewLine() |
                Patterns.NewLine().Assert(Patterns.NewLine().MaybeMany().EndInput()));
            Console.WriteLine("");

            Console.WriteLine("first line:");
            Console.WriteLine(
                Patterns.BeginInput()
                .NotNewLineChar().MaybeMany());
            Console.WriteLine("");

            Console.WriteLine("lf without cr:");
            Console.WriteLine(Patterns.NotAssertBack(Patterns.CarriageReturn()).Linefeed().AsNonbacktrackingGroup());
            Console.WriteLine((Patterns.NotAssertBack("\r") + "\n").AsNonbacktrackingGroup());
            Console.WriteLine("");

            Console.WriteLine("invalid file name chars:");
            var chars = Path.GetInvalidFileNameChars().OrderBy(f => (int)f).Select(f => Patterns.Character(f));
            Console.WriteLine(Patterns.Any(chars).AsNonbacktrackingGroup());
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
