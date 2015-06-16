﻿    // Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("email");

            var left = Quantifiers.OneMany(CharGroupItems.Alphanumeric().Concat("!#$%&'*+/=?^_`{|}~-"));

            var right = Quantifiers.Maybe(Quantifiers.MaybeMany(CharGroupItems.Alphanumeric().Hyphen()).Alphanumeric());

            var exp = left
                .MaybeMany("." + left)
                .At()
                .OneMany(Chars.Alphanumeric() + right + ".")
                .Alphanumeric()
                .Concat(right);
            Console.WriteLine(exp);
            Console.WriteLine("");

            Console.WriteLine("cdata value");
            Console.WriteLine(Expressions
                .LessThanGreaterThan(
                    "!" + Expressions.SquareBrackets(
                        "CDATA" + Expressions.SquareBrackets(
                            Expressions.CrawlInvariant().AsGroup()
                        )
                    )
                ));
            Console.WriteLine("");

            var values = new string[] { "one", "two", "three" };

            Console.WriteLine("multiple words");
            Console.WriteLine(Anchors
                .WordBoundary()
                .Count(3, Alternations
                    .Any(values.Select(f => Groups.Group(f)))
                    .WordBoundary()
                    .NotWordChar().MaybeMany().Lazy())
                .RequireGroups(1, 2, 3));
            Console.WriteLine("");

            Console.WriteLine("multiple words 2");
            Console.WriteLine(Anchors
                .WordBoundary()
                .CountFrom(3, Alternations
                    .Any(values.Select(f => Expression.Create(f).Group()))
                    .WordBoundary()
                    .NotWordChar().MaybeMany().Lazy())
                .Backreference(1)
                .Backreference(2)
                .Backreference(3));
            Console.WriteLine("");

            var quotedChar = Chars.NotChar(CharGroupItems.QuoteMark().NewLineChar()).MaybeMany();

            Console.WriteLine("quoted text");
            Console.WriteLine(Expressions.QuoteMarks(
                quotedChar
                .MaybeMany(Chars.QuoteMark(2) + quotedChar)));
            Console.WriteLine("");

            Console.WriteLine("digits inside b element value");
            Console.WriteLine(Chars
                .Digits()
                .Assert(Quantifiers
                    .MaybeMany(Anchors.NotAssert("<b>").Any())
                    .Concat("</b>")));
            Console.WriteLine("");

            Console.WriteLine("repeated word");
            Console.WriteLine(Anchors.Word().AsGroup()
                .WhiteSpaces()
                .Backreference(1)
                .WordBoundary());
            Console.WriteLine("");

            Console.WriteLine("any word");
            Console.WriteLine(Anchors.Word("word1", "word2", "word3"));
            Console.WriteLine("");

            Console.WriteLine("words in any order:");
            Console.WriteLine(Anchors.StartOfLine()
                .Assert(Expressions.CrawlInvariant().Word("word1"))
                .Assert(Expressions.CrawlInvariant().Word("word2"))
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
                    .StartOfLineInvariant().WhileWhiteSpace().NewLine(),
                    Expressions.NewLine().WhileWhiteSpace().EndOfInput()));
            Console.WriteLine("");

            Console.WriteLine("empty lines:");
            Console.WriteLine(Alternations.Any(Anchors
                    .StartOfLineInvariant().NewLine(),
                    Expressions.NewLine().OneMany().EndOfInput()));
            Console.WriteLine("");

            Console.WriteLine("first line:");
            Console.WriteLine(Anchors
                .Start()
                .NotNewLineChar().MaybeMany());
            Console.WriteLine("");

            Console.WriteLine("lf without cr:");
            Console.WriteLine(Anchors.NotAssertBack(Chars.CarriageReturn()).Linefeed().AsNonbacktracking());
            Console.WriteLine((Anchors.NotAssertBack("\r") + "\n").AsNonbacktracking());
            Console.WriteLine("");

            Console.WriteLine("invalid file name chars:");
            var chars = Path.GetInvalidFileNameChars().OrderBy(f => (int)f).Select(f => Chars.Char(f));
            Console.WriteLine(Alternations.Any(chars).AsNonbacktracking());
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
