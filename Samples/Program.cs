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
                .SurroundAngleBrackets(
                    "!" + Patterns.SurroundSquareBrackets(
                        "CDATA" + Patterns.SurroundSquareBrackets(
                            Patterns.Crawl().AsGroup()
                        )
                    )
                ));
            Console.WriteLine("");

            var values = new string[] { "one", "two", "three" };

            Console.WriteLine("multiple words");
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

            Console.WriteLine("verbatim quoted text");
            Console.WriteLine(Patterns.AtSign().SurroundQuoteMarks(
                Patterns.WhileNotChar('"')
                .MaybeMany(Patterns.QuoteMark(2).WhileNotChar('"'))));
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
                .Assert(Patterns.Crawl().Word("word1"))
                .Assert(Patterns.Crawl().Word("word2"))
                .Any().MaybeMany());
            Console.WriteLine("");

            Console.WriteLine("leading whitespace:");
            Console.WriteLine(Patterns
                .BeginLine()
                .WhiteSpaceExceptNewLine().OneMany()
                .AsNoncapturingGroup());
            Console.WriteLine("");

            Console.WriteLine("trailing whitespace:");
            Console.WriteLine(Patterns
                .WhiteSpaceExceptNewLine().OneMany()
                .EndLine(true)
                .AsNoncapturingGroup());
            Console.WriteLine("");

            Console.WriteLine("empty or whitespace line:");
            Console.WriteLine(Patterns
                    .BeginLine()
                    .WhiteSpaceExceptNewLine().MaybeMany()
                    .Assert(Patterns.NewLine()));
            Console.WriteLine("");

            Console.WriteLine("empty line:");
            Console.WriteLine(Patterns
                .BeginLine()
                .Assert(Patterns.NewLine()));
            Console.WriteLine("");

            Console.WriteLine("first line:");
            Console.WriteLine(Patterns
                .BeginInput()
                .NotNewLineChar().MaybeMany()
                .AsNoncapturingGroup());
            Console.WriteLine("");

            Console.WriteLine("linefeed without carriage return:");
            Console.WriteLine(Patterns
                .NotAssertBack(Patterns.CarriageReturn())
                .Linefeed()
                .AsNoncapturingGroup());
            Console.WriteLine("");

            Console.WriteLine("invalid file name chars:");
            Console.WriteLine(Patterns.NonbacktrackingGroup(Path.GetInvalidFileNameChars().OrderBy(f => (int)f).Select(f => Patterns.Character(f))));
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
