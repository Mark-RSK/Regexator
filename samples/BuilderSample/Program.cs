using System;
using System.IO;
using Pihrtsoft.Regexator.Builder;

namespace Pihrtsoft.Regexator.Samples
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Expressions.WhiteSpace().AsSubexpression().Backreference(1));
            Console.WriteLine("");

            Console.WriteLine("leading whitespace:");
            Console.WriteLine(Expressions.StartOfLine().WhiteSpaceExceptNewLine().OneMany());
            Console.WriteLine("");

            Console.WriteLine("trailing whitespace:");
            Console.WriteLine(Expressions.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn());
            Console.WriteLine("");

            Console.WriteLine("leading trailing whitespace:");
            Console.WriteLine(Expressions.Any(
                Expressions.StartOfLine().WhiteSpaceExceptNewLine().OneMany(), 
                Expressions.WhiteSpaceExceptNewLine().OneMany().EndOfLineOrBeforeCarriageReturn()));
            Console.WriteLine("");

            Console.WriteLine("whitespace lines:");
            Console.WriteLine(Expressions.Options(InlineOptions.Multiline).Any(
                Expressions.StartOfLine().WhiteSpace().MaybeMany().NewLine(),
                Expressions.NewLine().WhiteSpace().MaybeMany().End()));
            Console.WriteLine("");

            Console.WriteLine("empty lines:");
            Console.WriteLine(Expressions.Options(InlineOptions.Multiline).Any(
                Expressions.StartOfLine().NewLine(),
                Expressions.NewLine().OneMany().End()
            ));
            Console.WriteLine("");

            Console.WriteLine("first line:");
            Console.WriteLine(Expressions.Start().Any().MaybeMany().Lazy().EndOfLineOrBeforeCarriageReturn());
            Console.WriteLine("");

            Console.WriteLine("lf without cr:");
            Console.WriteLine(Expressions.CarriageReturn().AsNotLookbehind().Linefeed().AsNonbacktracking());
            Console.WriteLine("");

            Console.WriteLine("file name invalid chars:");
            Console.WriteLine(Expressions.Chars(Path.GetInvalidFileNameChars()).AsNonbacktracking());
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
