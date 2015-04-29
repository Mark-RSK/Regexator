using System;
using System.IO;
using Pihrtsoft.Regexator.Builder;

namespace Pihrtsoft.Regexator.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(@"\A(?=.*?\bword1\b)(?=.*?\bword2\b).*\z");
            Console.WriteLine(Assertions.Lookahead(Characters.AnyMaybeManyLazy().WordBoundary("word1"))
                .Lookahead(Characters.AnyMaybeManyLazy().WordBoundary("word2")).Any().MaybeMany()
                .AsEntireInput());

            Console.WriteLine(@"^(?=[\s\S]*?\bword1\b)(?=[\s\S]*?\bword2\b)[\s\S]*");
            Console.WriteLine(Anchors.StartOfLine()
                .Lookahead(Characters.AnyInvariant().MaybeMany().Lazy().WordBoundary("word1"))
                .Lookahead(Characters.AnyInvariant().MaybeMany().Lazy().WordBoundary("word2"))
                .AnyInvariant().MaybeMany());

            Console.WriteLine("leading whitespace:");
            Console.WriteLine(Anchors.StartOfLine().WhiteSpaceExceptNewLine().OneMany());
            Console.WriteLine("");

            Console.WriteLine("trailing whitespace:");
            Console.WriteLine(Characters.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn());
            Console.WriteLine("");

            Console.WriteLine("leading trailing whitespace:");
            Console.WriteLine(Alternations.Any(
                Anchors.StartOfLine().WhiteSpaceExceptNewLine().OneMany(),
                Characters.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn()));
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
            Console.WriteLine(Characters.CarriageReturn().AsNotLookbehind().Linefeed().AsNonbacktracking());
            Console.WriteLine("");

            Console.WriteLine("file name invalid chars:");
            Console.WriteLine(Characters.Group(Path.GetInvalidFileNameChars()).AsNonbacktracking());
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
