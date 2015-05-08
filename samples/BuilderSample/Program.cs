using System;
using System.IO;

namespace Pihrtsoft.Regexator.Builder.Samples
{
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Console.WriteLine(Alternations.Any(
                Groups
                    .NamedGroup("y", Characters.Digit(2))
                    .NamedGroup("m", Characters.Digit(2))
                    .NamedGroup("d", Characters.Digit(2))
                    .Maybe(Characters.Slash().Digit(4)),
                Groups
                    .NamedGroup("d", Characters.Digit(2)).Period()
                    .NamedGroup("m", Characters.Digit(2)).Period()
                    .NamedGroup("y", Characters.Digit(4))));

            Console.WriteLine("repeated word");
            Console.WriteLine(Characters.WordChar().OneMany().AsSubexpression()
                .WhiteSpace().OneMany()
                .Backreference(1)
                .AsWordBoundary());
            Console.WriteLine("");

            Console.WriteLine("any word");
            Console.WriteLine(Alternations.Any("word1", "word2", "word3").AsWordBoundary());
            Console.WriteLine("");

            Console.WriteLine("words in any order:");
            Console.WriteLine(Anchors.StartOfLine()
                .Lookahead(Characters.AnyInvariant().MaybeMany().Lazy().WordBoundary("word1"))
                .Lookahead(Characters.AnyInvariant().MaybeMany().Lazy().WordBoundary("word2"))
                .AnyInvariant().MaybeMany());
            Console.WriteLine("");

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
            Console.WriteLine(Characters.Char(Path.GetInvalidFileNameChars()).AsNonbacktracking());
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
