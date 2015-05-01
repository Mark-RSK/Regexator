using System;
using System.IO;
using Pihrtsoft.Regexator.Builder;

namespace Pihrtsoft.Regexator.Builder.Samples
{
    class Program
    {
#if DEBUG
        public static Expression Words(params string[] values)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            if (values.Length > 0)
            {
                Expression e = Alternations.IfGroup(values.Length, Expressions.Never());
                for (int i = values.Length - 1; i >= 1; i--)
                {
                    e = e.Append(Alternations.IfGroup(i, e));
                }
                return e;
            }
            return Expressions.Empty();
        }
#endif
        static void Main(string[] args)
        {
            //Console.WriteLine(@"\b(?:(?>(word1)|(word2)|(word3)|(?(1)|(?(2)|(?(3)|(?!))))\w+)\b");
            Console.WriteLine(Alternations.IfGroup(1, Expressions.Never()));
            Console.WriteLine(Words("word1", "word2", "word3"));

            Console.WriteLine(Quantifiers.OneMany(Assertions.NotLookahead("cat").Word()).SurroundWordBoundary());

            Console.WriteLine("any word");
            Console.WriteLine(Anchors.WordBoundary(Alternations.Any("word1", "word2", "word3")));
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
            Console.WriteLine(Characters.Group(Path.GetInvalidFileNameChars()).AsNonbacktracking());
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
