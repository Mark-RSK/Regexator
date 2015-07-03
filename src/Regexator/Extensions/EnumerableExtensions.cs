// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

//TODO add xml comments

namespace Pihrtsoft.Text.RegularExpressions.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<Group> EnumerateGroups(this IEnumerable<Match> matches)
        {
            if (matches == null)
            {
                throw new ArgumentNullException("matches");
            }

            return matches.SelectMany(match => match.Groups.Cast<Group>());
        }

        public static IEnumerable<Group> EnumerateGroups(this IEnumerable<Match> matches, string groupName)
        {
            if (matches == null)
            {
                throw new ArgumentNullException("matches");
            }

            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }

            return matches.Select(match => match.Groups[groupName]);
        }

        public static IEnumerable<Group> EnumerateGroups(this IEnumerable<Match> matches, int groupNumber)
        {
            if (matches == null)
            {
                throw new ArgumentNullException("matches");
            }

            if (groupNumber < 0)
            {
                throw new ArgumentOutOfRangeException("groupNumber");
            }

            return matches.Select(match => match.Groups[groupNumber]);
        }

        public static IEnumerable<Group> EnumerateSuccessGroups(this IEnumerable<Match> matches)
        {
            return EnumerateGroups(matches)
                .Where(group => group.Success);
        }

        public static IEnumerable<Group> EnumerateSuccessGroups(this IEnumerable<Match> matches, string groupName)
        {
            return EnumerateGroups(matches, groupName)
                .Where(group => group.Success);
        }

        public static IEnumerable<Group> EnumerateSuccessGroups(this IEnumerable<Match> matches, int groupNumber)
        {
            return EnumerateGroups(matches, groupNumber)
                .Where(group => group.Success);
        }

        public static IEnumerable<Capture> EnumerateCaptures(this IEnumerable<Match> matches)
        {
            return EnumerateSuccessGroups(matches)
                .EnumerateCaptures();
        }

        public static IEnumerable<Capture> EnumerateCaptures(this IEnumerable<Match> matches, string groupName)
        {
            return EnumerateSuccessGroups(matches, groupName)
                .EnumerateCaptures();
        }

        public static IEnumerable<Capture> EnumerateCaptures(this IEnumerable<Match> matches, int groupNumber)
        {
            return EnumerateSuccessGroups(matches, groupNumber)
                .EnumerateCaptures();
        }

        public static IEnumerable<Capture> EnumerateCaptures(this IEnumerable<Group> groups)
        {
            if (groups == null)
            {
                throw new ArgumentNullException("groups");
            }

            return groups.SelectMany(group => group.Captures.Cast<Capture>());
        }
    }
}
