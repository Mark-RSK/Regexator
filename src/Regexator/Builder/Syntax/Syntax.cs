// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Syntax
    {
        internal const string IfStart = "(?";
        internal const string InlineCommentStart = "(?#";
        public const string Or = "|";
        public const string Any = ".";

        public const char IgnoreCaseChar = 'i';
        public const char MultilineChar = 'm';
        public const char ExplicitCaptureChar = 'n';
        public const char SinglelineChar = 's';
        public const char IgnorePatternWhiteSpaceChar = 'x';

        internal static readonly InlineOptions InlineOptions = InlineOptions.IgnoreCase | InlineOptions.Multiline | InlineOptions.ExplicitCapture | InlineOptions.Singleline | InlineOptions.IgnorePatternWhitespace;

        public static string IfGroup(string groupName, string yes, string no)
        {
            if (yes == null) { throw new ArgumentNullException("yes"); }
            if (no == null) { throw new ArgumentNullException("no"); }
            return IfGroupStart(groupName) + yes + Or + no + GroupEnd;
        }

        internal static string IfGroupStart(string groupName)
        {
            if (groupName == null) { throw new ArgumentNullException("groupName"); }
            return IfStart + SubexpressionStart + groupName + GroupEnd;
        }

        public static string IfGroup(int groupNumber, string yes, string no)
        {
            if (groupNumber < 0) { throw new ArgumentOutOfRangeException("groupNumber"); }
            return IfGroup(groupNumber.ToString(CultureInfo.InvariantCulture), yes, no);
        }

        internal static string IfGroupStart(int groupNumber)
        {
            if (groupNumber < 0) { throw new ArgumentOutOfRangeException("groupNumber"); }
            return IfGroupStart(groupNumber.ToString(CultureInfo.InvariantCulture));
        }

        public static string Options(InlineOptions enableOptions)
        {
            return Options(enableOptions, InlineOptions.None);
        }

        public static string Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            if ((applyOptions & InlineOptions) != InlineOptions.None)
            {
                if ((disableOptions & InlineOptions) != InlineOptions.None)
                {
                    return "(?" + GetInlineChars(applyOptions) + "-" + GetInlineChars(disableOptions) + GroupEnd;
                }
                else
                {
                    return "(?" + GetInlineChars(applyOptions) + GroupEnd;
                }
            }
            return string.Empty;
        }

        public static string GetInlineChars(InlineOptions options)
        {
            return new string(EnumerateInlineChars(options).ToArray());
        }

        internal static IEnumerable<char> EnumerateInlineChars(InlineOptions options)
        {
            if ((options & InlineOptions.IgnoreCase) == InlineOptions.IgnoreCase)
            {
                yield return IgnoreCaseChar;
            }
            if ((options & InlineOptions.Multiline) == InlineOptions.Multiline)
            {
                yield return MultilineChar;
            }
            if ((options & InlineOptions.ExplicitCapture) == InlineOptions.ExplicitCapture)
            {
                yield return ExplicitCaptureChar;
            }
            if ((options & InlineOptions.Singleline) == InlineOptions.Singleline)
            {
                yield return SinglelineChar;
            }
            if ((options & InlineOptions.IgnorePatternWhitespace) == InlineOptions.IgnorePatternWhitespace)
            {
                yield return IgnorePatternWhiteSpaceChar;
            }
        }

        public static string InlineComment(string value)
        {
            return InlineCommentStart + value + GroupEnd;
        }

        public static string Backreference(int groupNumber)
        {
            return @"\" + groupNumber;
        }

        public static string Backreference(string groupName, IdentifierSeparatorKind separator)
        {
            if (groupName == null) { throw new ArgumentNullException("groupName"); }
            switch (separator)
            {
                case IdentifierSeparatorKind.LessThan:
                    return @"\k<" + groupName + ">";
                case IdentifierSeparatorKind.Apostrophe:
                    return @"\k'" + groupName + "'";
            }
            return null;
        }
    }
}
