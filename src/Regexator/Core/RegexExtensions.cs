// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    public static class RegexExtensions
    {
        internal static IEnumerable<Match> EnumerateMatches(this Regex regex, string input)
        {
            if (regex == null)
            {
                throw new ArgumentNullException("regex");
            }

            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            Match match = regex.Match(input);
            while (match.Success)
            {
                yield return match;
                match = match.NextMatch();
            }
        }

        public static MatchItem MatchItem(this Regex regex, string input)
        {
            return new MatchData(regex, input).MatchItem();
        }

        public static MatchItem MatchItem(this Regex regex, string input, int limit)
        {
            return new MatchData(regex, input, limit).MatchItem();
        }

        public static MatchItemCollection MatchItems(this Regex regex, string input)
        {
            return new MatchData(regex, input).Items;
        }

        public static MatchItemCollection MatchItems(this Regex regex, string input, int limit)
        {
            return new MatchData(regex, input, limit).Items;
        }

        public static ReplaceItemCollection ReplaceItems(this Regex regex, string input, string replacement)
        {
            return new ReplaceData(regex, input, replacement).Items;
        }

        public static ReplaceItemCollection ReplaceItems(this Regex regex, string input, string replacement, ResultMode mode)
        {
            return new ReplaceData(regex, input, replacement, mode).Items;
        }

        public static ReplaceItemCollection ReplaceItems(this Regex regex, string input, string replacement, int limit)
        {
            return new ReplaceData(regex, input, replacement, limit).Items;
        }

        public static ReplaceItemCollection ReplaceItems(this Regex regex, string input, string replacement, ResultMode mode, int limit)
        {
            return new ReplaceData(regex, input, replacement, mode, limit).Items;
        }

        public static SplitItemCollection SplitItems(this Regex regex, string input)
        {
            return new SplitData(regex, input).Items;
        }

        public static SplitItemCollection SplitItems(this Regex regex, string input, int limit)
        {
            return new SplitData(regex, input, limit).Items;
        }
    }
}
