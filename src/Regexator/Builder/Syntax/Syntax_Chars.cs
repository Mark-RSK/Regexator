// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Syntax
    {
        public const string Digit = @"\d";
        public const string NotDigit = @"\D";
        public const string WhiteSpace = @"\s";
        public const string NotWhiteSpace = @"\S";
        public const string Word = @"\w";
        public const string NotWord = @"\W";
        public const string Bell = @"\a";
        public const string Backspace = @"\b";
        public const string Escape = @"\e";
        public const string FormFeed = @"\f";
        public const string Linefeed = @"\n";
        public const string CarriageReturn = @"\r";
        public const string Tab = @"\t";
        public const string VerticalTab = @"\v";

        internal const string CharGroupStart = "[";
        internal const string NotCharGroupStart = "[^";
        internal const string CharGroupEnd = "]";
        internal const string AsciiStart = @"\x";
        internal const string AsciiOctalStart = @"\";
        internal const string AsciiControlStart = @"\c";

        internal static string CharGroup(string value)
        {
            return CharGroup(value, false);
        }

        internal static string CharGroup(string value, bool negative)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            if (value.Length == 0) { throw new ArgumentException("Character group cannot be empty.", "value"); }
            return (negative ? NotCharGroupStart : CharGroupStart) + value + CharGroupEnd;
        }

        public static string CharClass(CharClass value)
        {
            switch (value)
            {
                case Builder.CharClass.Digit:
                    return Digit;
                case Builder.CharClass.Word:
                    return Word;
                case Builder.CharClass.WhiteSpace:
                    return WhiteSpace;
                case Builder.CharClass.NotDigit:
                    return NotDigit;
                case Builder.CharClass.NotWord:
                    return NotWord;
                case Builder.CharClass.NotWhiteSpace:
                    return NotWhiteSpace;
            }
            return string.Empty;
        }

        public static string CharClasses(params CharClass[] values)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            return string.Concat(values.Select(f => CharClass(f)));
        }

        public static string Range(char first, char last)
        {
            return Syntax.Char(first, true) + "-" + Syntax.Char(last, true);
        }

        public static string Range(int first, int last)
        {
            return Syntax.Char(first, true) + "-" + Syntax.Char(last, true);
        }

        public static string Char(char value, bool inCharGroup)
        {
            return Utilities.EscapeInternal((int)value, inCharGroup);
        }

        public static string Char(int charCode)
        {
            return Char(charCode, false);
        }

        public static string Char(int charCode, bool inCharGroup)
        {
            return Utilities.Escape(charCode, inCharGroup);
        }

        public static string Char(AsciiChar value)
        {
            return Char(value, false);
        }

        public static string Char(AsciiChar value, bool inCharGroup)
        {
            return Utilities.EscapeInternal((int)value, inCharGroup);
        }

        public static string Char(char value)
        {
            return Char(value, false);
        }

        public static string Chars(IEnumerable<char> values)
        {
            return Chars(values, false);
        }

        public static string Chars(IEnumerable<char> values, bool inCharGroup)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            return string.Concat(values.Select(f => Char(f, inCharGroup)));
        }

        public static string Chars(IEnumerable<int> charCodes)
        {
            return Chars(charCodes, false);
        }

        public static string Chars(IEnumerable<int> charCodes, bool inCharGroup)
        {
            if (charCodes == null) { throw new ArgumentNullException("charCodes"); }
            return string.Concat(charCodes.Select(f => Char(f, inCharGroup)));
        }

        public static string Chars(IEnumerable<AsciiChar> values)
        {
            return Chars(values, false);
        }

        public static string Chars(IEnumerable<AsciiChar> values, bool inCharGroup)
        {
            if (values == null) { throw new ArgumentNullException("values"); }
            return string.Concat(values.Select(f => Char(f, inCharGroup)));
        }
    }
}