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
            var left = Patterns.OneMany(CharGroupings.Alphanumeric() + "!#$%&'*+/=?^_`{|}~-");

            var right = Patterns.Maybe(Patterns.MaybeMany(CharGroupings.Alphanumeric() + "-").Alphanumeric());

            var exp = left
                .MaybeMany("." + left)
                .AtSign()
                .OneMany(Patterns.Alphanumeric() + right + ".")
                .Alphanumeric()
                .Concat(right);

            Dump("email", exp);

            exp = Patterns
                .SurroundAngleBrackets(
                    "!" + Patterns.SurroundSquareBrackets(
                        "CDATA" + Patterns.SurroundSquareBrackets(
                            Patterns.Crawl().AsGroup()
                        )
                    )
                );

            Dump("cdata value", exp);

            var values = new string[] { "one", "two", "three" };

            exp = Patterns.WordBoundary()
                .CountFrom(3,
                    Patterns.Any(values.Select(f => Patterns.Text(f).AsGroup()))
                    .WordBoundary()
                    .NotWordChar().MaybeMany().Lazy())
                .GroupReference(1)
                .GroupReference(2)
                .GroupReference(3);

            Dump("multiple words", exp);

            exp = Patterns.AtSign().SurroundQuoteMarks(
                Patterns.WhileNotChar('"')
                .MaybeMany(Patterns.QuoteMark(2).WhileNotChar('"')));

            Dump("verbatim quoted text", exp);

            exp = Patterns
                .Digits()
                .Assert(
                    Patterns.MaybeMany(Patterns.NotAssert("<b>").Any())
                    .Text("</b>"));

            Console.WriteLine("digits inside b element value", exp);

            exp = Patterns.Word().AsGroup()
                .WhiteSpaces()
                .GroupReference(1)
                .WordBoundary();

            Dump("repeated word", exp);

            exp = Patterns.SurroundWordBoundary("word1", "word2", "word3");

            Dump("any word", exp);

            exp = Patterns.BeginInput()
                .Assert(Patterns.Crawl().SurroundWordBoundary("word1"))
                .Assert(Patterns.Crawl().SurroundWordBoundary("word2"))
                .Any().MaybeMany();

            Dump("words in any order", exp);

            exp = Patterns
                .BeginInputOrLine()
                .WhiteSpaceExceptNewLine().OneMany()
                .AsNoncapturingGroup();
            
            Dump("leading whitespace", exp);

            exp = Patterns
                .WhiteSpaceExceptNewLine().OneMany()
                .EndLine(true)
                .AsNoncapturingGroup();
            
            Dump("trailing whitespace", exp);

            exp = Patterns
                .BeginLine()
                .WhiteSpaceExceptNewLine().MaybeMany()
                .Assert(Patterns.NewLine());

            Dump("empty or whitespace line", exp);

            exp = Patterns
                .BeginLine()
                .Assert(Patterns.NewLine());

            Dump("empty line", exp);

            exp = Patterns
                .BeginInput()
                .NotNewLineChar().MaybeMany()
                .AsNoncapturingGroup();

            Dump("first line", exp);

            exp = Patterns
                .NotAssertBack(Patterns.CarriageReturn())
                .Linefeed()
                .AsNoncapturingGroup();

            Dump("linefeed without carriage return", exp);

            exp = Patterns.NonbacktrackingGroup(Path.GetInvalidFileNameChars().OrderBy(f => (int)f).Select(f => Patterns.Character(f)));

            Dump("invalid file name chars", exp);

            Console.ReadKey();
        }

        private static void Dump(string title, Pattern pattern)
        {
            Console.Write(title);
            Console.WriteLine(":");
            Console.WriteLine(pattern);
            Console.WriteLine(string.Empty);
        }
    }
}
