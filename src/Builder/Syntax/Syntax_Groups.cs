// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

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

        internal static string GroupStart(string name, IdentifierSeparatorKind separator)
        {
            if (name == null) { throw new ArgumentNullException("name"); }
            switch (separator)
            {
                case IdentifierSeparatorKind.LessThan:
                    return @"(?<" + name + @">";
                case IdentifierSeparatorKind.Apostrophe:
                    return @"(?'" + name + @"'";
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

        public static string OptionsGroup(InlineOptions applyOptions, string value)
        {
            return OptionsGroup(applyOptions, InlineOptions.None, value);
        }

        public static string OptionsGroup(InlineOptions applyOptions, InlineOptions disableOptions, string value)
        {
            return OptionsGroupStart(applyOptions, disableOptions) + value + GroupEnd;
        }

        internal static string OptionsGroupStart(InlineOptions applyOptions, InlineOptions disableOptions)
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
