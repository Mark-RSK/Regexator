// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using static Pihrtsoft.Text.RegularExpressions.Linq.Patterns;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Dump(Any());

            Dump("c# quotation or comment", Snippets.CSharpQuoteMarksOrComment());
            Dump("cdata value", Snippets.XmlCData());

            var left = OneMany(Chars.Alphanumeric() + "!#$%&'*+/=?^_`{|}~-");

            var right = Maybe(MaybeMany(Chars.Alphanumeric() + "-").Alphanumeric());

            var exp = left
                .MaybeMany("." + left)
                .AtSign()
                .OneMany(Alphanumeric() + right + ".")
                .Alphanumeric()
                .Append(right);

            Dump("email address", exp);

            var values = new string[] { "one", "two", "three" };

            exp = WordBoundary()
                .CountFrom(3,
                    Any(values.Select(f => Group(Patterns.Text(f))))
                    .WordBoundary()
                    .NotWordChar().MaybeMany().Lazy())
                .GroupReference(1)
                .GroupReference(2)
                .GroupReference(3);

            Dump("multiple words", exp);

            exp = "@" + SurroundQuoteMarks(
                WhileNotChar('"')
                .MaybeMany(QuoteMark(2).WhileNotChar('"')));

            Dump("verbatim quoted text", exp);

            exp = Digits().Assert(MaybeMany(NotAssert("<b>").Any()) + "</b>");

            Dump("digits inside b element value", exp);

            exp = Group(Word())
                .WhiteSpaces()
                .GroupReference(1)
                .WordBoundary();

            Dump("repeated word", exp);

            exp = SurroundWordBoundary("word1", "word2", "word3");

            Dump("any word", exp);

            exp = BeginInput()
                .Assert(Crawl().SurroundWordBoundary("word1"))
                .Assert(Crawl().SurroundWordBoundary("word2"))
                .Any().MaybeMany();

            Dump("words in any order", exp);

            exp = BeginInputOrLine().WhiteSpaceExceptNewLine().OneMany();

            Dump("leading whitespace", exp);

            exp = WhiteSpaceExceptNewLine().OneMany().EndInputOrLine(true);

            Dump("trailing whitespace", exp);

            exp = BeginLine().WhileWhiteSpaceExceptNewLine().Assert(NewLine());

            Dump("empty or whitespace line", exp);

            exp = BeginLine().Assert(NewLine());

            Dump("empty line", exp);

            exp = BeginInput().WhileNotNewLineChar();

            Dump("first line without new line", exp);

            exp = NotAssertBack(CarriageReturn()).Linefeed();

            Dump("linefeed without carriage return", exp);

            exp = Any(Path.GetInvalidFileNameChars());

            Dump("invalid file name chars", exp);

            Console.ReadKey();
        }

        private static void Dump(Pattern pattern)
        {
            Dump(null, pattern);
        }

        private static void Dump(string title, Pattern pattern)
        {
            var options = PatternOptions.FormatAndComment;

            if (!string.IsNullOrEmpty(title))
            {
                Console.WriteLine("{0}:", title);
            }

            Console.WriteLine(pattern.ToString(options));
            Console.WriteLine(string.Empty);
        }
    }
}
