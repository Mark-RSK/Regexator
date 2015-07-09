    // Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Pihrtsoft.Text.RegularExpressions.Linq.Extensions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            foreach (var item in Enum.GetValues(typeof(NamedBlock)).Cast<NamedBlock>())
            {
                Debug.Assert(Syntax.GetNamedBlockValue(item) == Syntax._blocks[(int)item]);
                Console.WriteLine(Syntax._blocks[(int)item]);
            }
            foreach (var item in Enum.GetValues(typeof(GeneralCategory)).Cast<GeneralCategory>())
            {
                Debug.Assert(Syntax.GetGeneralCategoryValue(item) == Syntax._categories[(int)item]);
                Console.WriteLine(Syntax._categories[(int)item]);
            }

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
                    Patterns.Any(values.Select(f => Pattern.Create(f).AsGroup()))
                    .WordBoundary()
                    .NotWordChar().MaybeMany().Lazy())
                .GroupReference(1)
                .GroupReference(2)
                .GroupReference(3));
            Console.WriteLine("");

            var quotedChar = Patterns.NotCharacter(CharGroupings.QuoteMark().NewLineChar()).MaybeMany();

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
                    .Concat("</b>")));
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
            Console.WriteLine(Patterns.StartOfLine()
                .Assert(Patterns.CrawlInvariant().Word("word1"))
                .Assert(Patterns.CrawlInvariant().Word("word2"))
                .AnyInvariant().MaybeMany());
            Console.WriteLine("");

            Console.WriteLine("leading whitespace:");
            Console.WriteLine(Patterns.StartOfLine().WhiteSpaceExceptNewLine().OneMany());
            Console.WriteLine("");

            Console.WriteLine("trailing whitespace:");
            Console.WriteLine(Patterns.WhiteSpaceExceptNewLine().OneMany().EndOfLine(true));
            Console.WriteLine("");

            Console.WriteLine("leading trailing whitespace:");
            Console.WriteLine(Patterns.Any(
                Patterns.StartOfLine().WhiteSpaceExceptNewLine().OneMany(),
                Patterns.WhiteSpaceExceptNewLine().OneMany().EndOfLine(true)));
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
