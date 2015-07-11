// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Reflection;
using System.ComponentModel;
using System.Globalization;
using Pihrtsoft.Text.RegularExpressions.Linq;

namespace Pihrtsoft.Text.RegularExpressions
{
    public class CharMatchInfo
    {
        private readonly string _pattern;
        private readonly string _comment;

        private CharMatchInfo(string pattern)
            : this(pattern, string.Empty)
        {
        }

        private CharMatchInfo(string pattern, string comment)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }

            _pattern = pattern;
            _comment = comment;
        }

        public static IEnumerable<CharMatchInfo>  Create(char value)
        {
            return Create(value, false);
        }

        public static IEnumerable<CharMatchInfo> Create(char value, bool inCharGroup)
        {
            return Create(value, inCharGroup, RegexOptions.None);
        }

        public static IEnumerable<CharMatchInfo> Create(char value, RegexOptions options)
        {
            return Create(value, false, options);
        }

        public static IEnumerable<CharMatchInfo> Create(char value, bool inCharGroup, RegexOptions options)
        {
            return Create((int)value, inCharGroup, options);
        }

        public static IEnumerable<CharMatchInfo> Create(int charCode)
        {
            return Create(charCode, RegexOptions.None);
        }

        public static IEnumerable<CharMatchInfo> Create(int charCode, bool inCharGroup)
        {
            return Create(charCode, inCharGroup, RegexOptions.None);
        }

        public static IEnumerable<CharMatchInfo> Create(int charCode, RegexOptions options)
        {
            return Create(charCode, false, options);
        }

        public static IEnumerable<CharMatchInfo> Create(int charCode, bool inCharGroup, RegexOptions options)
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
                string pattern = Syntax.UnicodeStart + Syntax.GetCategoryDesignation(category) + Syntax.UnicodeEnd;
                if (Regex.IsMatch(s, pattern, options))
                {
                    MemberInfo[] info = typeof(GeneralCategory).GetMember(category.ToString());
                    object[] attributes = info[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    yield return new CharMatchInfo(pattern, string.Format("Unicode category: {0}", ((DescriptionAttribute)attributes[0]).Description));
                }
            }

            foreach (var block in Enum.GetValues(typeof(NamedBlock)).Cast<NamedBlock>())
            {
                string pattern = Syntax.UnicodeStart + Syntax.GetBlockDesignation(block) + Syntax.UnicodeEnd;
                if (Regex.IsMatch(s, pattern, options))
                {
                    MemberInfo[] info = typeof(NamedBlock).GetMember(block.ToString());
                    object[] attributes = info[0].GetCustomAttributes(typeof(DescriptionAttribute), false);
                    yield return new CharMatchInfo(pattern, string.Format("Unicode block: {0}", ((DescriptionAttribute)attributes[0]).Description));
                    break;
                }
            }

            if (charCode <= 0xFF)
            {
                switch (RegexUtility.GetEscapeMode(charCode, inCharGroup))
                {
                    case CharEscapeMode.Backslash:
                        yield return new CharMatchInfo(@"\" + ((char)charCode).ToString(), "Escaped character");
                        break;
                    case CharEscapeMode.Bell:
                        yield return new CharMatchInfo(Syntax.Bell);
                        break;
                    case CharEscapeMode.CarriageReturn:
                        yield return new CharMatchInfo(Syntax.CarriageReturn);
                        break;
                    case CharEscapeMode.Escape:
                        yield return new CharMatchInfo(Syntax.Escape);
                        break;
                    case CharEscapeMode.FormFeed:
                        yield return new CharMatchInfo(Syntax.FormFeed);
                        break;
                    case CharEscapeMode.Linefeed:
                        yield return new CharMatchInfo(Syntax.Linefeed);
                        break;
                    case CharEscapeMode.Tab:
                        yield return new CharMatchInfo(Syntax.Tab);
                        break;
                    case CharEscapeMode.VerticalTab:
                        yield return new CharMatchInfo(Syntax.VerticalTab);
                        break;
                    case CharEscapeMode.None:
                        yield return new CharMatchInfo(((char)charCode).ToString());
                        break;
                }

                if (inCharGroup && charCode == 8)
                {
                    yield return new CharMatchInfo(Syntax.WordBoundary, "Escaped character");
                }

                yield return new CharMatchInfo(Syntax.UnicodeHexadecimalStart + charCode.ToString("X4", CultureInfo.InvariantCulture), "Unicode character (four hexadecimal digits)");

                yield return new CharMatchInfo(Syntax.AsciiHexadecimalStart + charCode.ToString("X2", CultureInfo.InvariantCulture), "ASCII character (two hexadecimal digits)");

                yield return new CharMatchInfo(@"\" + Convert.ToString(charCode, 8).PadLeft(2, '0'), "ASCII character (two or three octal digits)");

                if (charCode > 0 && charCode <= 0x1A)
                {
                    yield return new CharMatchInfo(Syntax.AsciiControlStart + System.Convert.ToChar('a' + charCode - 1), "ASCII control character");
                    yield return new CharMatchInfo(Syntax.AsciiControlStart + System.Convert.ToChar('A' + charCode - 1), "ASCII control character");
                }
            }
        }

        public string Pattern
        {
            get { return _pattern; }
        }

        public string Comment
        {
            get { return _comment; }
        }
    }
}
