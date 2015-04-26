// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Globalization;

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Syntax
    {
        internal const string SubexpressionStart = "(";
        internal const string NoncapturingGroupStart = "(?:";
        internal const string NonbacktrackingGroupStart = "(?>";
        internal const string GroupEnd = ")";

        public static string Group(string name, string value, IdentifierSeparatorKind separator)
        {
            return GroupStart(name, separator) + value + GroupEnd;
        }

        internal static string GroupStart(int groupName, IdentifierSeparatorKind separator)
        {
            if (groupName < 1) { throw new ArgumentOutOfRangeException("groupName"); }
            return GroupStart(groupName.ToString(CultureInfo.InvariantCulture), separator);
        }

        internal static string GroupStart(string groupName, IdentifierSeparatorKind separator)
        {
            if (groupName == null) { throw new ArgumentNullException("groupName"); }
            switch (separator)
            {
                case IdentifierSeparatorKind.LessThan:
                    return @"(?<" + groupName + @">";
                case IdentifierSeparatorKind.Apostrophe:
                    return @"(?'" + groupName + @"'";
            }
            return null;
        }

        public static string BalancingGroup(string name1, string name2, string value, IdentifierSeparatorKind separator)
        {
            return BalancingGroupStart(name1, name2, separator) + value + GroupEnd;
        }

        internal static string BalancingGroupStart(string name1, string name2, IdentifierSeparatorKind separator)
        {
            if (name1 == null) { throw new ArgumentNullException("name1"); }
            if (name2 == null) { throw new ArgumentNullException("name2"); }
            switch (separator)
            {
                case IdentifierSeparatorKind.LessThan:
                    return @"(?<" + name1 + "-" + name2 + @">";
                case IdentifierSeparatorKind.Apostrophe:
                    return @"(?'" + name1 + "-" + name2 + @"'";
            }
            return null;
        }

        public static string Subexpression(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return SubexpressionStart + value + GroupEnd;
        }

        public static string NoncapturingGroup(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return NoncapturingGroupStart + value + GroupEnd;
        }

        public static string NonbacktrackingGroup(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            return NonbacktrackingGroupStart + value + GroupEnd;
        }

        public static string GroupOptions(InlineOptions applyOptions, string value)
        {
            return GroupOptions(applyOptions, InlineOptions.None, value);
        }

        public static string GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string value)
        {
            return GroupOptionsStart(applyOptions, disableOptions) + value + GroupEnd;
        }

        internal static string GroupOptionsStart(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            if ((applyOptions & InlineOptions) != InlineOptions.None)
            {
                if ((disableOptions & InlineOptions) != InlineOptions.None)
                {
                    return "(?" + GetInlineChars(applyOptions) + "-" + GetInlineChars(disableOptions) + ":";
                }
                else
                {
                    return "(?" + GetInlineChars(applyOptions) + ":";
                }
            }
            return string.Empty;
        }
    }
}
