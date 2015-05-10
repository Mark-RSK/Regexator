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
            Debug.WriteLine(0x100);
            for (int i = 0; i < 0x100; i++)
            {
                Debug.WriteLine(i);
                Debug.Indent();
                foreach (var item in RegexUtilities.GetMatchingPatterns(i, false, RegexOptions.None))
                {
                    try
                    {
                        if (!Regex.IsMatch(Convert.ToChar(i).ToString(), item.Pattern))
                        {
                            Debug.Write("ERROR: ");
                        }
                    }
                    catch (ArgumentException)
                    {
                        Debug.Write("ERROR: ");
                    }
                    Debug.WriteLine(string.Format("{0} {1}", item.Pattern, item.Comment));
                }
                Debug.Unindent();
            }

            Console.WriteLine("repeated word");
            Console.WriteLine(Chars.WordChar().OneMany().AsSubexpression()
                .WhiteSpace().OneMany()
                .Backreference(1)
                .AsWordBoundary());
            Console.WriteLine("");

            Console.WriteLine("any word");
            Console.WriteLine(Alternations.Any("word1", "word2", "word3").AsWordBoundary());
            Console.WriteLine("");

            Console.WriteLine("words in any order:");
            Console.WriteLine(Anchors.StartOfLine()
                .Lookahead(Chars.AnyInvariant().MaybeMany().Lazy().WordBoundary("word1"))
                .Lookahead(Chars.AnyInvariant().MaybeMany().Lazy().WordBoundary("word2"))
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
