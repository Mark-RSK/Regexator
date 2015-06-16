// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using Pihrtsoft.Text.RegularExpressions.Linq;

namespace Pihrtsoft.Text.RegularExpressions
{
    public static class RegexUtilities
    {
        internal static readonly RegexOptions InlineRegexOptions = RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.ExplicitCapture | RegexOptions.Singleline | RegexOptions.IgnorePatternWhitespace;

        internal static readonly Expression TrimInlineComment = Patterns.TrimInlineComment();
        internal static readonly Expression ValidGroupName = Patterns.ValidGroupName();

        public static bool IsValidGroupName(string groupName)
        {
            return IsValidGroupName(groupName, "groupName");
        }

        internal static bool IsValidGroupName(string groupName, string paramName)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException(paramName);
            }

            if (groupName.Length > 0)
            {
                Match match = ValidGroupName.Match(groupName);
                if (match.Success)
                {
                    Group g = match.Groups[1];
                    if (g.Success && g.Value.Length > 9)
                    {
                        int result;
                        return (int.TryParse(g.Value, out result));
                    }

                    return true;
                }
            }

            return false;
        }

        internal static void CheckGroupName(string groupName)
        {
            CheckGroupName(groupName, "groupName");
        }

        internal static void CheckGroupName(string groupName, string paramName)
        {
            if (!IsValidGroupName(groupName, paramName))
            {
                throw new ArgumentException("Invalid group name.", paramName);
            }
        }

        public static bool IsValidInlineOptions(RegexOptions options)
        {
            return (options & ~InlineRegexOptions) == RegexOptions.None;
        }

        public static RegexOptions Convert(InlineOptions options)
        {
            RegexOptions value = RegexOptions.None;

            if ((options & InlineOptions.IgnoreCase) == InlineOptions.IgnoreCase)
            {
                value |= RegexOptions.IgnoreCase;
            }

            if ((options & InlineOptions.Multiline) == InlineOptions.Multiline)
            {
                value |= RegexOptions.Multiline;
            }

            if ((options & InlineOptions.ExplicitCapture) == InlineOptions.ExplicitCapture)
            {
                value |= RegexOptions.ExplicitCapture;
            }

            if ((options & InlineOptions.Singleline) == InlineOptions.Singleline)
            {
                value |= RegexOptions.Singleline;
            }

            if ((options & InlineOptions.IgnorePatternWhitespace) == InlineOptions.IgnorePatternWhitespace)
            {
                value |= RegexOptions.IgnorePatternWhitespace;
            }

            return value;
        }

        public static InlineOptions Convert(RegexOptions options)
        {
            if (!IsValidInlineOptions(options))
            {
                throw new ArgumentException();
            }

            InlineOptions value = InlineOptions.None;

            if ((options & RegexOptions.IgnoreCase) == RegexOptions.IgnoreCase)
            {
                value |= InlineOptions.IgnoreCase;
            }

            if ((options & RegexOptions.Multiline) == RegexOptions.Multiline)
            {
                value |= InlineOptions.Multiline;
            }

            if ((options & RegexOptions.ExplicitCapture) == RegexOptions.ExplicitCapture)
            {
                value |= InlineOptions.ExplicitCapture;
            }

            if ((options & RegexOptions.Singleline) == RegexOptions.Singleline)
            {
                value |= InlineOptions.Singleline;
            }

            if ((options & RegexOptions.IgnorePatternWhitespace) == RegexOptions.IgnorePatternWhitespace)
            {
                value |= InlineOptions.IgnorePatternWhitespace;
            }

            return value;
        }

        internal static bool EscapeRequired(int charCode, bool inCharGroup)
        {
            if (charCode <= 0xFF)
            {
                switch (_charKinds[charCode])
                {
                    case CharKind.Backslash:
                        return true;
                    case CharKind.Metachar:
                        return !inCharGroup;
                    case CharKind.CharGroupMetachar:
                        return inCharGroup;
                    case CharKind.Control:
                        return true;
                    case CharKind.SpecialControl:
                        {
                            switch (charCode)
                            {
                                case 7:
                                    return true;
                                case 9:
                                    return true;
                                case 10:
                                    return true;
                                case 11:
                                    return true;
                                case 12:
                                    return true;
                                case 13:
                                    return true;
                                case 27:
                                    return true;
                            }

                            break;
                        }
                }
            }

            return false;
        }

        public static string Escape(char value)
        {
            return Escape(value, false);
        }

        public static string Escape(char value, bool inCharGroup)
        {
            return EscapeInternal((int)value, inCharGroup);
        }

        public static string Escape(int charCode)
        {
            return Escape(charCode, false);
        }

        [SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal static string EscapeInternal(int charCode)
        {
            return EscapeInternal(charCode, false);
        }

        public static string Escape(int charCode, bool inCharGroup)
        {
            if (charCode < 0 || charCode > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("charCode");
            }

            return EscapeInternal(charCode, inCharGroup);
        }

        internal static string EscapeInternal(int charCode, bool inCharGroup)
        {
            if (charCode <= 0xFF)
            {
                switch (_charKinds[charCode])
                {
                    case CharKind.Backslash:
                        {
                            return EscapeChar(charCode);
                        }
                    case CharKind.Metachar:
                        {
                            if (!inCharGroup)
                            {
                                return EscapeChar(charCode);
                            }
                            break;
                        }
                    case CharKind.CharGroupMetachar:
                        {
                            if (inCharGroup)
                            {
                                return EscapeChar(charCode);
                            }
                            break;
                        }
                    case CharKind.Control:
                        {
                            return Syntax.AsciiHexadecimal(charCode);
                        }
                    case CharKind.SpecialControl:
                        {
                            switch (charCode)
                            {
                                case 7:
                                    return Syntax.Bell;
                                case 9:
                                    return Syntax.Tab;
                                case 10:
                                    return Syntax.Linefeed;
                                case 11:
                                    return Syntax.VerticalTab;
                                case 12:
                                    return Syntax.FormFeed;
                                case 13:
                                    return Syntax.CarriageReturn;
                                case 27:
                                    return Syntax.Escape;
                            }
                            break;
                        }
                }
            }

            Debug.Assert(false);

            return ((char)charCode).ToString();
        }

        internal static CharEscapeMode GetEscapeMode(int charCode, bool inCharGroup)
        {
            if (charCode <= 0xFF)
            {
                switch (_charKinds[charCode])
                {
                    case CharKind.Backslash:
                        {
                            return CharEscapeMode.BackslashEscape;
                        }
                    case CharKind.Metachar:
                        {
                            return inCharGroup 
                                ? CharEscapeMode.None 
                                : CharEscapeMode.BackslashEscape;
                        }
                    case CharKind.CharGroupMetachar:
                        {
                            return inCharGroup 
                                ? CharEscapeMode.BackslashEscape 
                                : CharEscapeMode.None;
                        }
                    case CharKind.Control:
                        {
                            return CharEscapeMode.AsciiEscape;
                        }
                    case CharKind.SpecialControl:
                        {
                            switch (charCode)
                            {
                                case 7:
                                    return CharEscapeMode.Bell;
                                case 9:
                                    return CharEscapeMode.Tab;
                                case 10:
                                    return CharEscapeMode.Linefeed;
                                case 11:
                                    return CharEscapeMode.VerticalTab;
                                case 12:
                                    return CharEscapeMode.FormFeed;
                                case 13:
                                    return CharEscapeMode.CarriageReturn;
                                case 27:
                                    return CharEscapeMode.Escape;
                            }

                            break;
                        }
                }
            }

            return CharEscapeMode.None;
        }

        private static string EscapeChar(int charCode)
        {
            return @"\" + ((char)charCode).ToString();
        }

        public static string Escape(string input)
        {
            return Escape(input, false);
        }

        public static string Escape(string input, bool inCharGroup)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (EscapeRequired((int)input[i], inCharGroup))
                {
                    StringBuilder sb = new StringBuilder();
                    char ch = input[i];
                    int lastPos;
                    sb.Append(input, 0, i);

                    do
                    {
                        sb.Append(EscapeInternal((int)ch, inCharGroup));
                        i++;
                        lastPos = i;

                        while (i < input.Length)
                        {
                            ch = input[i];
                            if (EscapeRequired((int)ch, inCharGroup))
                            {
                                break;
                            }
                            i++;
                        }

                        sb.Append(input, lastPos, i - lastPos);

                    } while (i < input.Length);

                    return sb.ToString();
                }
            }

            return input;
        }

        public static string EscapeSubstitution(string input)
        {
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            for (int i = 0; i < input.Length; i++)
            {
                if (input[i] == '$')
                {
                    StringBuilder sb = new StringBuilder();
                    char ch = input[i];
                    int lastPos;
                    sb.Append(input, 0, i);

                    do
                    {
                        sb.Append("$$");
                        i++;
                        lastPos = i;

                        while (i < input.Length)
                        {
                            ch = input[i];
                            if (ch == '$')
                            {
                                break;
                            }
                            i++;
                        }

                        sb.Append(input, lastPos, i - lastPos);

                    } while (i < input.Length);

                    return sb.ToString();
                }
            }

            return input;
        }

        public static IEnumerable<CharMatchInfo> GetMatchingPatterns(char value)
        {
            return GetMatchingPatterns(value, false);
        }

        public static IEnumerable<CharMatchInfo> GetMatchingPatterns(char value, bool inCharGroup)
        {
            return GetMatchingPatterns(value, inCharGroup, RegexOptions.None);
        }

        public static IEnumerable<CharMatchInfo> GetMatchingPatterns(char value, RegexOptions options)
        {
            return GetMatchingPatterns(value, false, options);
        }

        public static IEnumerable<CharMatchInfo> GetMatchingPatterns(char value, bool inCharGroup, RegexOptions options)
        {
            return GetMatchingPatterns((int)value, inCharGroup, options);
        }

        public static IEnumerable<CharMatchInfo> GetMatchingPatterns(int charCode)
        {
            return GetMatchingPatterns(charCode, RegexOptions.None);
        }

        public static IEnumerable<CharMatchInfo> GetMatchingPatterns(int charCode, bool inCharGroup)
        {
            return GetMatchingPatterns(charCode, inCharGroup, RegexOptions.None);
        }

        public static IEnumerable<CharMatchInfo> GetMatchingPatterns(int charCode, RegexOptions options)
        {
            return GetMatchingPatterns(charCode, false, options);
        }

        public static IEnumerable<CharMatchInfo> GetMatchingPatterns(int charCode, bool inCharGroup, RegexOptions options)
        {
            if (charCode < 0 || charCode > 0xFFFF)
            {
                throw new ArgumentOutOfRangeException("charCode");
            }

            string s = ((char)charCode).ToString();

            if (Regex.IsMatch(s, @"\d", options))
            {
                yield return new CharMatchInfo(@"\d", "Digit character");
            }
            else
            {
                yield return new CharMatchInfo(@"\D", "Non-digit character");
            }

            if (Regex.IsMatch(s, @"\s", options))
            {
                yield return new CharMatchInfo(@"\s", "Whitespace character");
            }
            else
            {
                yield return new CharMatchInfo(@"\S", "Non-whitespace character");
            }

            if (Regex.IsMatch(s, @"\w", options))
            {
                yield return new CharMatchInfo(@"\w", "Word character");
            }
            else
            {
                yield return new CharMatchInfo(@"\W", "Non-word character");
            }

            foreach (var category in Enum.GetValues(typeof(GeneralCategory)).Cast<GeneralCategory>())
            {
                string pattern = Syntax.GeneralCategory(category);
                if (Regex.IsMatch(s, pattern, options))
                {
                    MemberInfo[] info = typeof(GeneralCategory).GetMember(category.ToString());
                    object[] attributes = info[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    yield return new CharMatchInfo(pattern, string.Format("Unicode general category: {0}", ((DescriptionAttribute)attributes[0]).Description));
                }
            }

            foreach (var block in Enum.GetValues(typeof(NamedBlock)).Cast<NamedBlock>())
            {
                string pattern = Syntax.NamedBlock(block);
                if (Regex.IsMatch(s, pattern, options))
                {
                    MemberInfo[] info = typeof(NamedBlock).GetMember(block.ToString());
                    object[] attributes = info[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    yield return new CharMatchInfo(pattern, string.Format("Unicode named block: {0}", ((DescriptionAttribute)attributes[0]).Description));
                    break;
                }
            }

            if (charCode <= 0xFF)
            {
                switch (_charKinds[charCode])
                {
                    case CharKind.Backslash:
                        {
                            yield return new CharMatchInfo(EscapeChar(charCode), "Escaped character");
                            break;
                        }
                    case CharKind.Metachar:
                        {
                            if (!inCharGroup)
                            {
                                yield return new CharMatchInfo(EscapeChar(charCode), "Escaped character");
                            }
                            else
                            {
                                yield return new CharMatchInfo(((char)charCode).ToString());
                            }
                            break;
                        }
                    case CharKind.CharGroupMetachar:
                        {
                            if (inCharGroup)
                            {
                                yield return new CharMatchInfo(EscapeChar(charCode), "Escaped character");
                            }
                            else
                            {
                                yield return new CharMatchInfo(((char)charCode).ToString());
                            }
                            break;
                        }
                    case CharKind.Control:
                        {
                            if (inCharGroup && charCode == 8)
                            {
                                yield return new CharMatchInfo(Syntax.Backspace, "Escaped character");
                            }
                            break;
                        }
                    case CharKind.SpecialControl:
                        {
                            switch (charCode)
                            {
                                case 7:
                                    yield return new CharMatchInfo(Syntax.Bell);
                                    break;
                                case 9:
                                    yield return new CharMatchInfo(Syntax.Tab);
                                    break;
                                case 10:
                                    yield return new CharMatchInfo(Syntax.Linefeed);
                                    break;
                                case 11:
                                    yield return new CharMatchInfo(Syntax.VerticalTab);
                                    break;
                                case 12:
                                    yield return new CharMatchInfo(Syntax.FormFeed);
                                    break;
                                case 13:
                                    yield return new CharMatchInfo(Syntax.CarriageReturn);
                                    break;
                                case 27:
                                    yield return new CharMatchInfo(Syntax.Escape);
                                    break;
                            }
                            break;
                        }
                    default:
                        yield return new CharMatchInfo(((char)charCode).ToString());
                        break;

                }

                yield return new CharMatchInfo(Syntax.Unicode(charCode), "Unicode character (four hexadecimal digits)");

                yield return new CharMatchInfo(Syntax.AsciiHexadecimal(charCode), "ASCII character (two hexadecimal digits)");

                yield return new CharMatchInfo(Syntax.AsciiOctal(charCode), "ASCII character (two or three octal digits)");

                if (charCode > 0 && charCode <= 0x1A)
                {
                    yield return new CharMatchInfo(Syntax.AsciiControlStart + System.Convert.ToChar('a' + charCode - 1), "ASCII control character");
                    yield return new CharMatchInfo(Syntax.AsciiControlStart + System.Convert.ToChar('A' + charCode - 1), "ASCII control character");
                }
            }
        }

        private static readonly CharKind[] _charKinds = new CharKind[] {
            // 0 0x00
            CharKind.Control,
            // 1 0x01
            CharKind.Control,
            // 2 0x02
            CharKind.Control,
            // 3 0x03
            CharKind.Control,
            // 4 0x04
            CharKind.Control,
            // 5 0x05
            CharKind.Control,
            // 6 0x06
            CharKind.Control,
            // 7 0x07
            CharKind.SpecialControl,
            // 8 0x08
            CharKind.Control,
            // 9 0x09
            CharKind.SpecialControl,
            // 10 0x0A
            CharKind.SpecialControl,
            // 11 0x0B
            CharKind.SpecialControl,
            // 12 0x0C
            CharKind.SpecialControl,
            // 13 0x0D
            CharKind.SpecialControl,
            // 14 0x0E
            CharKind.Control,
            // 15 0x0F
            CharKind.Control,
            // 16 0x10
            CharKind.Control,
            // 17 0x11
            CharKind.Control,
            // 18 0x12
            CharKind.Control,
            // 19 0x13
            CharKind.Control,
            // 20 0x14
            CharKind.Control,
            // 21 0x15
            CharKind.Control,
            // 22 0x16
            CharKind.Control,
            // 23 0x17
            CharKind.Control,
            // 24 0x18
            CharKind.Control,
            // 25 0x19
            CharKind.Control,
            // 26 0x1A
            CharKind.Control,
            // 27 0x1B
            CharKind.SpecialControl,
            // 28 0x1C
            CharKind.Control,
            // 29 0x1D
            CharKind.Control,
            // 30 0x1E
            CharKind.Control,
            // 31 0x1F
            CharKind.Control,
            // 32 0x20
            CharKind.Metachar,
            // 33 0x21 !
            CharKind.None,
            // 34 0x22 "
            CharKind.None,
            // 35 0x23 #
            CharKind.Metachar,
            // 36 0x24 $
            CharKind.Metachar,
            // 37 0x25 %
            CharKind.None,
            // 38 0x26 &
            CharKind.None,
            // 39 0x27 '
            CharKind.None,
            // 40 0x28 (
            CharKind.Metachar,
            // 41 0x29 )
            CharKind.Metachar,
            // 42 0x2A *
            CharKind.Metachar,
            // 43 0x2B +
            CharKind.Metachar,
            // 44 0x2C ,
            CharKind.None,
            // 45 0x2D -
            CharKind.CharGroupMetachar,
            // 46 0x2E .
            CharKind.Metachar,
            // 47 0x2F /
            CharKind.None,
            // 48 0x30 0
            CharKind.None,
            // 49 0x31 1
            CharKind.None,
            // 50 0x32 2
            CharKind.None,
            // 51 0x33 3
            CharKind.None,
            // 52 0x34 4
            CharKind.None,
            // 53 0x35 5
            CharKind.None,
            // 54 0x36 6
            CharKind.None,
            // 55 0x37 7
            CharKind.None,
            // 56 0x38 8
            CharKind.None,
            // 57 0x39 9
            CharKind.None,
            // 58 0x3A :
            CharKind.None,
            // 59 0x3B ;
            CharKind.None,
            // 60 0x3C <
            CharKind.None,
            // 61 0x3D =
            CharKind.None,
            // 62 0x3E >
            CharKind.None,
            // 63 0x3F ?
            CharKind.Metachar,
            // 64 0x40 @
            CharKind.None,
            // 65 0x41 A
            CharKind.None,
            // 66 0x42 B
            CharKind.None,
            // 67 0x43 C
            CharKind.None,
            // 68 0x44 D
            CharKind.None,
            // 69 0x45 E
            CharKind.None,
            // 70 0x46 F
            CharKind.None,
            // 71 0x47 G
            CharKind.None,
            // 72 0x48 H
            CharKind.None,
            // 73 0x49 I
            CharKind.None,
            // 74 0x4A J
            CharKind.None,
            // 75 0x4B K
            CharKind.None,
            // 76 0x4C L
            CharKind.None,
            // 77 0x4D M
            CharKind.None,
            // 78 0x4E N
            CharKind.None,
            // 79 0x4F O
            CharKind.None,
            // 80 0x50 P
            CharKind.None,
            // 81 0x51 Q
            CharKind.None,
            // 82 0x52 R
            CharKind.None,
            // 83 0x53 S
            CharKind.None,
            // 84 0x54 T
            CharKind.None,
            // 85 0x55 U
            CharKind.None,
            // 86 0x56 V
            CharKind.None,
            // 87 0x57 W
            CharKind.None,
            // 88 0x58 X
            CharKind.None,
            // 89 0x59 Y
            CharKind.None,
            // 90 0x5A Z
            CharKind.None,
            // 91 0x5B [
            CharKind.Metachar,
            // 92 0x5C \
            CharKind.Backslash,
            // 93 0x5D ]
            CharKind.CharGroupMetachar,
            // 94 0x5E ^
            CharKind.Metachar,
            // 95 0x5F _
            CharKind.None,
            // 96 0x60 `
            CharKind.None,
            // 97 0x61 a
            CharKind.None,
            // 98 0x62 b
            CharKind.None,
            // 99 0x63 c
            CharKind.None,
            // 100 0x64 d
            CharKind.None,
            // 101 0x65 e
            CharKind.None,
            // 102 0x66 f
            CharKind.None,
            // 103 0x67 g
            CharKind.None,
            // 104 0x68 h
            CharKind.None,
            // 105 0x69 i
            CharKind.None,
            // 106 0x6A j
            CharKind.None,
            // 107 0x6B k
            CharKind.None,
            // 108 0x6C l
            CharKind.None,
            // 109 0x6D m
            CharKind.None,
            // 110 0x6E n
            CharKind.None,
            // 111 0x6F o
            CharKind.None,
            // 112 0x70 p
            CharKind.None,
            // 113 0x71 q
            CharKind.None,
            // 114 0x72 r
            CharKind.None,
            // 115 0x73 s
            CharKind.None,
            // 116 0x74 t
            CharKind.None,
            // 117 0x75 u
            CharKind.None,
            // 118 0x76 v
            CharKind.None,
            // 119 0x77 w
            CharKind.None,
            // 120 0x78 x
            CharKind.None,
            // 121 0x79 y
            CharKind.None,
            // 122 0x7A z
            CharKind.None,
            // 123 0x7B {
            CharKind.Metachar,
            // 124 0x7C |
            CharKind.Metachar,
            // 125 0x7D }
            CharKind.None,
            // 126 0x7E ~
            CharKind.None,
            // 127 0x7F
            CharKind.Control,
            // 128 0x80
            CharKind.Control,
            // 129 0x81
            CharKind.Control,
            // 130 0x82
            CharKind.Control,
            // 131 0x83
            CharKind.Control,
            // 132 0x84
            CharKind.Control,
            // 133 0x85
            CharKind.Control,
            // 134 0x86
            CharKind.Control,
            // 135 0x87
            CharKind.Control,
            // 136 0x88
            CharKind.Control,
            // 137 0x89
            CharKind.Control,
            // 138 0x8A
            CharKind.Control,
            // 139 0x8B
            CharKind.Control,
            // 140 0x8C
            CharKind.Control,
            // 141 0x8D
            CharKind.Control,
            // 142 0x8E
            CharKind.Control,
            // 143 0x8F
            CharKind.Control,
            // 144 0x90
            CharKind.Control,
            // 145 0x91
            CharKind.Control,
            // 146 0x92
            CharKind.Control,
            // 147 0x93
            CharKind.Control,
            // 148 0x94
            CharKind.Control,
            // 149 0x95
            CharKind.Control,
            // 150 0x96
            CharKind.Control,
            // 151 0x97
            CharKind.Control,
            // 152 0x98
            CharKind.Control,
            // 153 0x99
            CharKind.Control,
            // 154 0x9A
            CharKind.Control,
            // 155 0x9B
            CharKind.Control,
            // 156 0x9C
            CharKind.Control,
            // 157 0x9D
            CharKind.Control,
            // 158 0x9E
            CharKind.Control,
            // 159 0x9F
            CharKind.Control,
            // 160 0xA0
            CharKind.None,
            // 161 0xA1 ¡
            CharKind.None,
            // 162 0xA2 ¢
            CharKind.None,
            // 163 0xA3 £
            CharKind.None,
            // 164 0xA4 ¤
            CharKind.None,
            // 165 0xA5 ¥
            CharKind.None,
            // 166 0xA6 ¦
            CharKind.None,
            // 167 0xA7 §
            CharKind.None,
            // 168 0xA8 ¨
            CharKind.None,
            // 169 0xA9 ©
            CharKind.None,
            // 170 0xAA ª
            CharKind.None,
            // 171 0xAB «
            CharKind.None,
            // 172 0xAC ¬
            CharKind.None,
            // 173 0xAD ­
            CharKind.None,
            // 174 0xAE ®
            CharKind.None,
            // 175 0xAF ¯
            CharKind.None,
            // 176 0xB0 °
            CharKind.None,
            // 177 0xB1 ±
            CharKind.None,
            // 178 0xB2 ²
            CharKind.None,
            // 179 0xB3 ³
            CharKind.None,
            // 180 0xB4 ´
            CharKind.None,
            // 181 0xB5 µ
            CharKind.None,
            // 182 0xB6 ¶
            CharKind.None,
            // 183 0xB7 ·
            CharKind.None,
            // 184 0xB8 ¸
            CharKind.None,
            // 185 0xB9 ¹
            CharKind.None,
            // 186 0xBA º
            CharKind.None,
            // 187 0xBB »
            CharKind.None,
            // 188 0xBC ¼
            CharKind.None,
            // 189 0xBD ½
            CharKind.None,
            // 190 0xBE ¾
            CharKind.None,
            // 191 0xBF ¿
            CharKind.None,
            // 192 0xC0 À
            CharKind.None,
            // 193 0xC1 Á
            CharKind.None,
            // 194 0xC2 Â
            CharKind.None,
            // 195 0xC3 Ã
            CharKind.None,
            // 196 0xC4 Ä
            CharKind.None,
            // 197 0xC5 Å
            CharKind.None,
            // 198 0xC6 Æ
            CharKind.None,
            // 199 0xC7 Ç
            CharKind.None,
            // 200 0xC8 È
            CharKind.None,
            // 201 0xC9 É
            CharKind.None,
            // 202 0xCA Ê
            CharKind.None,
            // 203 0xCB Ë
            CharKind.None,
            // 204 0xCC Ì
            CharKind.None,
            // 205 0xCD Í
            CharKind.None,
            // 206 0xCE Î
            CharKind.None,
            // 207 0xCF Ï
            CharKind.None,
            // 208 0xD0 Ð
            CharKind.None,
            // 209 0xD1 Ñ
            CharKind.None,
            // 210 0xD2 Ò
            CharKind.None,
            // 211 0xD3 Ó
            CharKind.None,
            // 212 0xD4 Ô
            CharKind.None,
            // 213 0xD5 Õ
            CharKind.None,
            // 214 0xD6 Ö
            CharKind.None,
            // 215 0xD7 ×
            CharKind.None,
            // 216 0xD8 Ø
            CharKind.None,
            // 217 0xD9 Ù
            CharKind.None,
            // 218 0xDA Ú
            CharKind.None,
            // 219 0xDB Û
            CharKind.None,
            // 220 0xDC Ü
            CharKind.None,
            // 221 0xDD Ý
            CharKind.None,
            // 222 0xDE Þ
            CharKind.None,
            // 223 0xDF ß
            CharKind.None,
            // 224 0xE0 à
            CharKind.None,
            // 225 0xE1 á
            CharKind.None,
            // 226 0xE2 â
            CharKind.None,
            // 227 0xE3 ã
            CharKind.None,
            // 228 0xE4 ä
            CharKind.None,
            // 229 0xE5 å
            CharKind.None,
            // 230 0xE6 æ
            CharKind.None,
            // 231 0xE7 ç
            CharKind.None,
            // 232 0xE8 è
            CharKind.None,
            // 233 0xE9 é
            CharKind.None,
            // 234 0xEA ê
            CharKind.None,
            // 235 0xEB ë
            CharKind.None,
            // 236 0xEC ì
            CharKind.None,
            // 237 0xED í
            CharKind.None,
            // 238 0xEE î
            CharKind.None,
            // 239 0xEF ï
            CharKind.None,
            // 240 0xF0 ð
            CharKind.None,
            // 241 0xF1 ñ
            CharKind.None,
            // 242 0xF2 ò
            CharKind.None,
            // 243 0xF3 ó
            CharKind.None,
            // 244 0xF4 ô
            CharKind.None,
            // 245 0xF5 õ
            CharKind.None,
            // 246 0xF6 ö
            CharKind.None,
            // 247 0xF7 ÷
            CharKind.None,
            // 248 0xF8 ø
            CharKind.None,
            // 249 0xF9 ù
            CharKind.None,
            // 250 0xFA ú
            CharKind.None,
            // 251 0xFB û
            CharKind.None,
            // 252 0xFC ü
            CharKind.None,
            // 253 0xFD ý
            CharKind.None,
            // 254 0xFE þ
            CharKind.None,
            // 255 0xFF ÿ
            CharKind.None,
        };
    }
}
