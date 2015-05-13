using System;
using System.Diagnostics;
using System.IO;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Regexator.Builder.Samples
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine("repeated word");
            Console.WriteLine(Chars.WordChar().OneMany().AsSubexpression()
                .WhiteSpace().OneMany()
                .Backreference(1)
                .Surround(Anchors.WordBoundary()));
            Console.WriteLine("");

            Console.WriteLine("any word");
            Console.WriteLine(Alternations.Any("word1", "word2", "word3").Surround(Anchors.WordBoundary()));
            Console.WriteLine("");

            Console.WriteLine("words in any order:");
            Console.WriteLine(Anchors.StartOfLine()
                .Lookahead(Chars.AnyInvariant().MaybeMany().Lazy().Word("word1"))
                .Lookahead(Chars.AnyInvariant().MaybeMany().Lazy().Word("word2"))
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
            Console.WriteLine(Miscellaneous.Options(InlineOptions.Multiline).Any(
                Anchors.StartOfLine().WhiteSpace().MaybeMany().NewLine(),
                Expressions.NewLine().WhiteSpace().MaybeMany().End()));
            Console.WriteLine("");

            Console.WriteLine("empty lines:");
            Console.WriteLine(Miscellaneous.Options(InlineOptions.Multiline).Any(
                Anchors.StartOfLine().NewLine(),
                Expressions.NewLine().OneMany().End()
            ));
            Console.WriteLine("");

            Console.WriteLine("first line:");
            Console.WriteLine(Miscellaneous.Options(InlineOptions.Multiline).Start().Any().MaybeMany().Lazy().EndOfLineOrBeforeCarriageReturn());
            Console.WriteLine("");

            Console.WriteLine("lf without cr:");
            Console.WriteLine(Chars.CarriageReturn().AsNotLookbehind().Linefeed().AsNonbacktracking());
            Console.WriteLine("");

            Console.WriteLine("file name invalid chars:");
            Console.WriteLine(Chars.Char(Path.GetInvalidFileNameChars()).AsNonbacktracking());
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
