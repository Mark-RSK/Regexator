// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Extensions
{
    public static class EnumerableExtensions
    {
        internal static IEnumerable<Group> EnumerateGroups(this IEnumerable<Match> matches)
        {
            if (matches == null)
            {
                throw new ArgumentNullException("matches");
            }

            return matches.SelectMany(match => match.Groups.Cast<Group>());
        }

        internal static IEnumerable<Group> EnumerateGroups(this IEnumerable<Match> matches, string groupName)
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

        internal static IEnumerable<Group> EnumerateSuccessGroups(this IEnumerable<Match> matches)
        {
            return EnumerateGroups(matches).Where(group => group.Success);
        }

        internal static IEnumerable<Group> EnumerateSuccessGroups(this IEnumerable<Match> matches, string groupName)
        {
            return EnumerateGroups(matches, groupName).Where(group => group.Success);
        }

        internal static IEnumerable<Capture> EnumerateCaptures(this IEnumerable<Match> matches)
        {
            return EnumerateSuccessGroups(matches).EnumerateCaptures();
        }

        internal static IEnumerable<Capture> EnumerateCaptures(this IEnumerable<Match> matches, string groupName)
        {
            return EnumerateSuccessGroups(matches, groupName).EnumerateCaptures();
        }

        internal static IEnumerable<Capture> EnumerateCaptures(this IEnumerable<Group> groups)
        {
            if (groups == null)
            {
                throw new ArgumentNullException("groups");
            }

            return groups.SelectMany(group => group.Captures.Cast<Capture>());
        }
    }
}
