// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        private static Regex _isValidGroupName;

        public static bool IsValidGroupName(string groupName)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            if (groupName.Length > 0)
            {
                Match match = IsValidGroupNameRegex.Match(groupName);
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
            if (!IsValidGroupName(groupName))
            {
                throw new ArgumentException("Invalid group name.", "groupName");
            }
        }

        public static bool IsValidInlineOptions(RegexOptions options)
        {
            return (options & ~InlineRegexOptions) == RegexOptions.None;
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
                switch (s_escapeModes[charCode])
                {
                    case EscapeMode.Backslash:
                        {
                            return EscapeChar(charCode);
                        }
                    case EscapeMode.Metachar:
                        {
                            if (!inCharGroup)
                            {
                                return EscapeChar(charCode);
                            }
                            break;
                        }
                    case EscapeMode.CharGroupMetachar:
                        {
                            if (inCharGroup)
                            {
                                return EscapeChar(charCode);
                            }
                            break;
                        }
                    case EscapeMode.Control:
                        {
                            return Syntax.AsciiHexadecimal(charCode);
                        }
                    case EscapeMode.SpecialControl:
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
            return ((char)charCode).ToString();
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
                if (s_escapeModes[input[i]] != EscapeMode.None)
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
                            if (s_escapeModes[ch] != EscapeMode.None)
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
                switch (s_escapeModes[charCode])
                {
                    case EscapeMode.Backslash:
                        {
                            yield return new CharMatchInfo(EscapeChar(charCode), "Escaped character");
                            break;
                        }
                    case EscapeMode.Metachar:
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
                    case EscapeMode.CharGroupMetachar:
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
                    case EscapeMode.Control:
                        {
                            if (inCharGroup && charCode == 8)
                            {
                                yield return new CharMatchInfo(Syntax.Backspace, "Escaped character");
                            }
                            break;
                        }
                    case EscapeMode.SpecialControl:
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
                    yield return new CharMatchInfo(Syntax.AsciiControlStart + Convert.ToChar('a' + charCode - 1), "ASCII control character");
                    yield return new CharMatchInfo(Syntax.AsciiControlStart + Convert.ToChar('A' + charCode - 1), "ASCII control character");
                }
            }
        }

        internal static Regex IsValidGroupNameRegex
        {
            get
            {
                if (_isValidGroupName == null)
                {
                    _isValidGroupName = Alternations.Any(
                        Chars.Range('1', '9').ArabicDigit().MaybeMany().AsCapturing(),
                        Chars.WordChar().Except(Chars.ArabicDigit()).WordChar().MaybeMany()
                    ).AsEntireInput().ToRegex();
                }
                return _isValidGroupName;
            }
        }

        private static readonly EscapeMode[] s_escapeModes = new EscapeMode[] {
            // 0 0x00
            EscapeMode.Control,
            // 1 0x01
            EscapeMode.Control,
            // 2 0x02
            EscapeMode.Control,
            // 3 0x03
            EscapeMode.Control,
            // 4 0x04
            EscapeMode.Control,
            // 5 0x05
            EscapeMode.Control,
            // 6 0x06
            EscapeMode.Control,
            // 7 0x07
            EscapeMode.SpecialControl,
            // 8 0x08
            EscapeMode.Control,
            // 9 0x09
            EscapeMode.SpecialControl,
            // 10 0x0A
            EscapeMode.SpecialControl,
            // 11 0x0B
            EscapeMode.SpecialControl,
            // 12 0x0C
            EscapeMode.SpecialControl,
            // 13 0x0D
            EscapeMode.SpecialControl,
            // 14 0x0E
            EscapeMode.Control,
            // 15 0x0F
            EscapeMode.Control,
            // 16 0x10
            EscapeMode.Control,
            // 17 0x11
            EscapeMode.Control,
            // 18 0x12
            EscapeMode.Control,
            // 19 0x13
            EscapeMode.Control,
            // 20 0x14
            EscapeMode.Control,
            // 21 0x15
            EscapeMode.Control,
            // 22 0x16
            EscapeMode.Control,
            // 23 0x17
            EscapeMode.Control,
            // 24 0x18
            EscapeMode.Control,
            // 25 0x19
            EscapeMode.Control,
            // 26 0x1A
            EscapeMode.Control,
            // 27 0x1B
            EscapeMode.SpecialControl,
            // 28 0x1C
            EscapeMode.Control,
            // 29 0x1D
            EscapeMode.Control,
            // 30 0x1E
            EscapeMode.Control,
            // 31 0x1F
            EscapeMode.Control,
            // 32 0x20
            EscapeMode.Metachar,
            // 33 0x21 !
            EscapeMode.None,
            // 34 0x22 "
            EscapeMode.None,
            // 35 0x23 #
            EscapeMode.Metachar,
            // 36 0x24 $
            EscapeMode.Metachar,
            // 37 0x25 %
            EscapeMode.None,
            // 38 0x26 &
            EscapeMode.None,
            // 39 0x27 '
            EscapeMode.None,
            // 40 0x28 (
            EscapeMode.Metachar,
            // 41 0x29 )
            EscapeMode.Metachar,
            // 42 0x2A *
            EscapeMode.Metachar,
            // 43 0x2B +
            EscapeMode.Metachar,
            // 44 0x2C ,
            EscapeMode.None,
            // 45 0x2D -
            EscapeMode.CharGroupMetachar,
            // 46 0x2E .
            EscapeMode.Metachar,
            // 47 0x2F /
            EscapeMode.None,
            // 48 0x30 0
            EscapeMode.None,
            // 49 0x31 1
            EscapeMode.None,
            // 50 0x32 2
            EscapeMode.None,
            // 51 0x33 3
            EscapeMode.None,
            // 52 0x34 4
            EscapeMode.None,
            // 53 0x35 5
            EscapeMode.None,
            // 54 0x36 6
            EscapeMode.None,
            // 55 0x37 7
            EscapeMode.None,
            // 56 0x38 8
            EscapeMode.None,
            // 57 0x39 9
            EscapeMode.None,
            // 58 0x3A :
            EscapeMode.None,
            // 59 0x3B ;
            EscapeMode.None,
            // 60 0x3C <
            EscapeMode.None,
            // 61 0x3D =
            EscapeMode.None,
            // 62 0x3E >
            EscapeMode.None,
            // 63 0x3F ?
            EscapeMode.Metachar,
            // 64 0x40 @
            EscapeMode.None,
            // 65 0x41 A
            EscapeMode.None,
            // 66 0x42 B
            EscapeMode.None,
            // 67 0x43 C
            EscapeMode.None,
            // 68 0x44 D
            EscapeMode.None,
            // 69 0x45 E
            EscapeMode.None,
            // 70 0x46 F
            EscapeMode.None,
            // 71 0x47 G
            EscapeMode.None,
            // 72 0x48 H
            EscapeMode.None,
            // 73 0x49 I
            EscapeMode.None,
            // 74 0x4A J
            EscapeMode.None,
            // 75 0x4B K
            EscapeMode.None,
            // 76 0x4C L
            EscapeMode.None,
            // 77 0x4D M
            EscapeMode.None,
            // 78 0x4E N
            EscapeMode.None,
            // 79 0x4F O
            EscapeMode.None,
            // 80 0x50 P
            EscapeMode.None,
            // 81 0x51 Q
            EscapeMode.None,
            // 82 0x52 R
            EscapeMode.None,
            // 83 0x53 S
            EscapeMode.None,
            // 84 0x54 T
            EscapeMode.None,
            // 85 0x55 U
            EscapeMode.None,
            // 86 0x56 V
            EscapeMode.None,
            // 87 0x57 W
            EscapeMode.None,
            // 88 0x58 X
            EscapeMode.None,
            // 89 0x59 Y
            EscapeMode.None,
            // 90 0x5A Z
            EscapeMode.None,
            // 91 0x5B [
            EscapeMode.Metachar,
            // 92 0x5C \
            EscapeMode.Backslash,
            // 93 0x5D ]
            EscapeMode.CharGroupMetachar,
            // 94 0x5E ^
            EscapeMode.Metachar,
            // 95 0x5F _
            EscapeMode.None,
            // 96 0x60 `
            EscapeMode.None,
            // 97 0x61 a
            EscapeMode.None,
            // 98 0x62 b
            EscapeMode.None,
            // 99 0x63 c
            EscapeMode.None,
            // 100 0x64 d
            EscapeMode.None,
            // 101 0x65 e
            EscapeMode.None,
            // 102 0x66 f
            EscapeMode.None,
            // 103 0x67 g
            EscapeMode.None,
            // 104 0x68 h
            EscapeMode.None,
            // 105 0x69 i
            EscapeMode.None,
            // 106 0x6A j
            EscapeMode.None,
            // 107 0x6B k
            EscapeMode.None,
            // 108 0x6C l
            EscapeMode.None,
            // 109 0x6D m
            EscapeMode.None,
            // 110 0x6E n
            EscapeMode.None,
            // 111 0x6F o
            EscapeMode.None,
            // 112 0x70 p
            EscapeMode.None,
            // 113 0x71 q
            EscapeMode.None,
            // 114 0x72 r
            EscapeMode.None,
            // 115 0x73 s
            EscapeMode.None,
            // 116 0x74 t
            EscapeMode.None,
            // 117 0x75 u
            EscapeMode.None,
            // 118 0x76 v
            EscapeMode.None,
            // 119 0x77 w
            EscapeMode.None,
            // 120 0x78 x
            EscapeMode.None,
            // 121 0x79 y
            EscapeMode.None,
            // 122 0x7A z
            EscapeMode.None,
            // 123 0x7B {
            EscapeMode.Metachar,
            // 124 0x7C |
            EscapeMode.Metachar,
            // 125 0x7D }
            EscapeMode.None,
            // 126 0x7E ~
            EscapeMode.None,
            // 127 0x7F
            EscapeMode.Control,
            // 128 0x80
            EscapeMode.Control,
            // 129 0x81
            EscapeMode.Control,
            // 130 0x82
            EscapeMode.Control,
            // 131 0x83
            EscapeMode.Control,
            // 132 0x84
            EscapeMode.Control,
            // 133 0x85
            EscapeMode.Control,
            // 134 0x86
            EscapeMode.Control,
            // 135 0x87
            EscapeMode.Control,
            // 136 0x88
            EscapeMode.Control,
            // 137 0x89
            EscapeMode.Control,
            // 138 0x8A
            EscapeMode.Control,
            // 139 0x8B
            EscapeMode.Control,
            // 140 0x8C
            EscapeMode.Control,
            // 141 0x8D
            EscapeMode.Control,
            // 142 0x8E
            EscapeMode.Control,
            // 143 0x8F
            EscapeMode.Control,
            // 144 0x90
            EscapeMode.Control,
            // 145 0x91
            EscapeMode.Control,
            // 146 0x92
            EscapeMode.Control,
            // 147 0x93
            EscapeMode.Control,
            // 148 0x94
            EscapeMode.Control,
            // 149 0x95
            EscapeMode.Control,
            // 150 0x96
            EscapeMode.Control,
            // 151 0x97
            EscapeMode.Control,
            // 152 0x98
            EscapeMode.Control,
            // 153 0x99
            EscapeMode.Control,
            // 154 0x9A
            EscapeMode.Control,
            // 155 0x9B
            EscapeMode.Control,
            // 156 0x9C
            EscapeMode.Control,
            // 157 0x9D
            EscapeMode.Control,
            // 158 0x9E
            EscapeMode.Control,
            // 159 0x9F
            EscapeMode.Control,
            // 160 0xA0
            EscapeMode.None,
            // 161 0xA1 ¡
            EscapeMode.None,
            // 162 0xA2 ¢
            EscapeMode.None,
            // 163 0xA3 £
            EscapeMode.None,
            // 164 0xA4 ¤
            EscapeMode.None,
            // 165 0xA5 ¥
            EscapeMode.None,
            // 166 0xA6 ¦
            EscapeMode.None,
            // 167 0xA7 §
            EscapeMode.None,
            // 168 0xA8 ¨
            EscapeMode.None,
            // 169 0xA9 ©
            EscapeMode.None,
            // 170 0xAA ª
            EscapeMode.None,
            // 171 0xAB «
            EscapeMode.None,
            // 172 0xAC ¬
            EscapeMode.None,
            // 173 0xAD ­
            EscapeMode.None,
            // 174 0xAE ®
            EscapeMode.None,
            // 175 0xAF ¯
            EscapeMode.None,
            // 176 0xB0 °
            EscapeMode.None,
            // 177 0xB1 ±
            EscapeMode.None,
            // 178 0xB2 ²
            EscapeMode.None,
            // 179 0xB3 ³
            EscapeMode.None,
            // 180 0xB4 ´
            EscapeMode.None,
            // 181 0xB5 µ
            EscapeMode.None,
            // 182 0xB6 ¶
            EscapeMode.None,
            // 183 0xB7 ·
            EscapeMode.None,
            // 184 0xB8 ¸
            EscapeMode.None,
            // 185 0xB9 ¹
            EscapeMode.None,
            // 186 0xBA º
            EscapeMode.None,
            // 187 0xBB »
            EscapeMode.None,
            // 188 0xBC ¼
            EscapeMode.None,
            // 189 0xBD ½
            EscapeMode.None,
            // 190 0xBE ¾
            EscapeMode.None,
            // 191 0xBF ¿
            EscapeMode.None,
            // 192 0xC0 À
            EscapeMode.None,
            // 193 0xC1 Á
            EscapeMode.None,
            // 194 0xC2 Â
            EscapeMode.None,
            // 195 0xC3 Ã
            EscapeMode.None,
            // 196 0xC4 Ä
            EscapeMode.None,
            // 197 0xC5 Å
            EscapeMode.None,
            // 198 0xC6 Æ
            EscapeMode.None,
            // 199 0xC7 Ç
            EscapeMode.None,
            // 200 0xC8 È
            EscapeMode.None,
            // 201 0xC9 É
            EscapeMode.None,
            // 202 0xCA Ê
            EscapeMode.None,
            // 203 0xCB Ë
            EscapeMode.None,
            // 204 0xCC Ì
            EscapeMode.None,
            // 205 0xCD Í
            EscapeMode.None,
            // 206 0xCE Î
            EscapeMode.None,
            // 207 0xCF Ï
            EscapeMode.None,
            // 208 0xD0 Ð
            EscapeMode.None,
            // 209 0xD1 Ñ
            EscapeMode.None,
            // 210 0xD2 Ò
            EscapeMode.None,
            // 211 0xD3 Ó
            EscapeMode.None,
            // 212 0xD4 Ô
            EscapeMode.None,
            // 213 0xD5 Õ
            EscapeMode.None,
            // 214 0xD6 Ö
            EscapeMode.None,
            // 215 0xD7 ×
            EscapeMode.None,
            // 216 0xD8 Ø
            EscapeMode.None,
            // 217 0xD9 Ù
            EscapeMode.None,
            // 218 0xDA Ú
            EscapeMode.None,
            // 219 0xDB Û
            EscapeMode.None,
            // 220 0xDC Ü
            EscapeMode.None,
            // 221 0xDD Ý
            EscapeMode.None,
            // 222 0xDE Þ
            EscapeMode.None,
            // 223 0xDF ß
            EscapeMode.None,
            // 224 0xE0 à
            EscapeMode.None,
            // 225 0xE1 á
            EscapeMode.None,
            // 226 0xE2 â
            EscapeMode.None,
            // 227 0xE3 ã
            EscapeMode.None,
            // 228 0xE4 ä
            EscapeMode.None,
            // 229 0xE5 å
            EscapeMode.None,
            // 230 0xE6 æ
            EscapeMode.None,
            // 231 0xE7 ç
            EscapeMode.None,
            // 232 0xE8 è
            EscapeMode.None,
            // 233 0xE9 é
            EscapeMode.None,
            // 234 0xEA ê
            EscapeMode.None,
            // 235 0xEB ë
            EscapeMode.None,
            // 236 0xEC ì
            EscapeMode.None,
            // 237 0xED í
            EscapeMode.None,
            // 238 0xEE î
            EscapeMode.None,
            // 239 0xEF ï
            EscapeMode.None,
            // 240 0xF0 ð
            EscapeMode.None,
            // 241 0xF1 ñ
            EscapeMode.None,
            // 242 0xF2 ò
            EscapeMode.None,
            // 243 0xF3 ó
            EscapeMode.None,
            // 244 0xF4 ô
            EscapeMode.None,
            // 245 0xF5 õ
            EscapeMode.None,
            // 246 0xF6 ö
            EscapeMode.None,
            // 247 0xF7 ÷
            EscapeMode.None,
            // 248 0xF8 ø
            EscapeMode.None,
            // 249 0xF9 ù
            EscapeMode.None,
            // 250 0xFA ú
            EscapeMode.None,
            // 251 0xFB û
            EscapeMode.None,
            // 252 0xFC ü
            EscapeMode.None,
            // 253 0xFD ý
            EscapeMode.None,
            // 254 0xFE þ
            EscapeMode.None,
            // 255 0xFF ÿ
            EscapeMode.None,
        };
    }
}
