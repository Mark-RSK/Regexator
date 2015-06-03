// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Extensions
{
    public static class RegexExtensions
    {
        internal static IEnumerable<Match> EnumerateMatches(this Regex regex, string input)
        {
            return EnumerateMatches(regex, input, (f) => regex.Match(f));
        }

        internal static IEnumerable<Match> EnumerateMatches(this Regex regex, string input, int startAt)
        {
            return EnumerateMatches(regex, input, (f) => regex.Match(f, startAt));
        }

        internal static IEnumerable<Match> EnumerateMatches(this Regex regex, string input, int beginning, int length)
        {
            return EnumerateMatches(regex, input, (f) => regex.Match(f, beginning, length));
        }

        internal static IEnumerable<Group> EnumerateGroups(this Regex regex, string input)
        {
            return EnumerateMatches(regex, input).EnumerateGroups();
        }

        internal static IEnumerable<Group> EnumerateGroups(this Regex regex, string input, int startAt)
        {
            return EnumerateMatches(regex, input, startAt).EnumerateGroups();
        }

        internal static IEnumerable<Group> EnumerateGroups(this Regex regex, string input, int beginning, int length)
        {
            return EnumerateMatches(regex, input, beginning, length).EnumerateGroups();
        }

        internal static IEnumerable<Group> EnumerateGroups(this Regex regex, string groupName, string input)
        {
            return EnumerateMatches(regex, input).EnumerateGroups(groupName);
        }

        internal static IEnumerable<Group> EnumerateGroups(this Regex regex, string groupName, string input, int startAt)
        {
            return EnumerateMatches(regex, input, startAt).EnumerateGroups(groupName);
        }

        internal static IEnumerable<Group> EnumerateGroups(this Regex regex, string groupName, string input, int beginning, int length)
        {
            return EnumerateMatches(regex, input, beginning, length).EnumerateGroups(groupName);
        }

        internal static IEnumerable<Group> EnumerateSuccessGroups(this Regex regex, string input)
        {
            return EnumerateMatches(regex, input).EnumerateSuccessGroups();
        }

        internal static IEnumerable<Group> EnumerateSuccessGroups(this Regex regex, string input, int startAt)
        {
            return EnumerateMatches(regex, input, startAt).EnumerateSuccessGroups();
        }

        internal static IEnumerable<Group> EnumerateSuccessGroups(this Regex regex, string input, int beginning, int length)
        {
            return EnumerateMatches(regex, input, beginning, length).EnumerateSuccessGroups();
        }

        internal static IEnumerable<Group> EnumerateSuccessGroups(this Regex regex, string groupName, string input)
        {
            return EnumerateMatches(regex, input).EnumerateSuccessGroups(groupName);
        }

        internal static IEnumerable<Group> EnumerateSuccessGroups(this Regex regex, string groupName, string input, int startAt)
        {
            return EnumerateMatches(regex, input, startAt).EnumerateSuccessGroups(groupName);
        }

        internal static IEnumerable<Group> EnumerateSuccessGroups(this Regex regex, string groupName, string input, int beginning, int length)
        {
            return EnumerateMatches(regex, input, beginning, length).EnumerateSuccessGroups(groupName);
        }

        internal static IEnumerable<Capture> EnumerateCaptures(this Regex regex, string input)
        {
            return EnumerateMatches(regex, input).EnumerateCaptures();
        }

        internal static IEnumerable<Capture> EnumerateCaptures(this Regex regex, string input, int startAt)
        {
            return EnumerateMatches(regex, input, startAt).EnumerateCaptures();
        }

        internal static IEnumerable<Capture> EnumerateCaptures(this Regex regex, string input, int beginning, int length)
        {
            return EnumerateMatches(regex, input, beginning, length).EnumerateCaptures();
        }

        internal static IEnumerable<Capture> EnumerateCaptures(this Regex regex, string groupName, string input)
        {
            return EnumerateMatches(regex, input).EnumerateCaptures(groupName);
        }

        internal static IEnumerable<Capture> EnumerateCaptures(this Regex regex, string groupName, string input, int startAt)
        {
            return EnumerateMatches(regex, input, startAt).EnumerateCaptures(groupName);
        }

        internal static IEnumerable<Capture> EnumerateCaptures(this Regex regex, string groupName, string input, int beginning, int length)
        {
            return EnumerateMatches(regex, input, beginning, length).EnumerateCaptures(groupName);
        }

        private static IEnumerable<Match> EnumerateMatches(this Regex regex, string input, Func<string, Match> matchFactory)
        {
            if (regex == null)
            {
                throw new ArgumentNullException("regex");
            }

            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            Match match = matchFactory(input);
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