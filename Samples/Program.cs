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
            var left = Patterns.OneMany(Chars.Alphanumeric() + "!#$%&'*+/=?^_`{|}~-");

            var right = Patterns.Maybe(Patterns.MaybeMany(Chars.Alphanumeric() + "-").Alphanumeric());

            var exp = left
                .MaybeMany("." + left)
                .AtSign()
                .OneMany(Patterns.Alphanumeric() + right + ".")
                .Alphanumeric()
                .Append(right);

            Dump("email", exp);

            exp = Patterns
                .SurroundAngleBrackets(
                    "!" + Patterns.SurroundSquareBrackets(
                        "CDATA" + Patterns.SurroundSquareBrackets(
                            Patterns.Group(Patterns.Crawl())
                        )
                    )
                );

            Dump("cdata value", exp);

            var values = new string[] { "one", "two", "three" };

            exp = Patterns.WordBoundary()
                .CountFrom(3,
                    Patterns.Any(values.Select(f => Patterns.Group(Patterns.Text(f))))
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

            Dump("digits inside b element value", exp);

            exp = Patterns.Group(Patterns.Word())
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
                .WhiteSpaceExceptNewLine().OneMany();

            Dump("leading whitespace", exp);

            exp = Patterns
                .WhiteSpaceExceptNewLine().OneMany()
                .EndInputOrLine(true);

            Dump("trailing whitespace", exp);

            exp = Patterns
                .BeginLine()
                .WhileWhiteSpaceExceptNewLine()
                .Assert(Patterns.NewLine());

            Dump("empty or whitespace line", exp);

            exp = Patterns
                .BeginLine()
                .Assert(Patterns.NewLine());

            Dump("empty line", exp);

            exp = Patterns.BeginInput().WhileNotNewLineChar();

            Dump("first line without new line", exp);

            exp = Patterns
                .NotAssertBack(Patterns.CarriageReturn())
                .Linefeed();

            Dump("linefeed without carriage return", exp);

            exp = Patterns.Any(Path.GetInvalidFileNameChars());

            Dump("invalid file name chars", exp);

            Console.ReadKey();
        }

        private static void Dump(string title, Pattern pattern)
        {
            Console.WriteLine("{0}:", title);
            Console.WriteLine(pattern);
            Console.WriteLine(string.Empty);
        }
    }
}
