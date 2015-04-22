// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    public static partial class Syntax
    {
        internal const string LookaheadStart = "(?=";
        internal const string NotLookaheadStart = "(?!";
        internal const string LookbehindStart = "(?<=";
        internal const string NotLookbehindStart = "(?<!";
        public const string Start = @"\A";
        public const string StartOfLine = "^";
        public const string End = @"\z";
        public const string EndOfLine = "$";
        public const string EndOrBeforeEndingNewLine = @"\Z";
        public const string WordBoundary = @"\b";
        public const string NotWordBoundary = @"\B";
        public const string PreviousMatchEnd = @"\G";

        public static string Lookahead(string value)
        {
            return LookaheadStart + value + GroupEnd;
        }

        public static string NotLookahead(string value)
        {
            return NotLookaheadStart + value + GroupEnd;
        }

        public static string Lookbehind(string value)
        {
            return LookbehindStart + value + GroupEnd;
        }

        public static string NotLookbehind(string value)
        {
            return NotLookbehindStart + value + GroupEnd;
        }
    }
}