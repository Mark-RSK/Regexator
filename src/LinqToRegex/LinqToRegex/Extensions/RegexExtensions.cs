// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq.Extensions
{
    /// <summary>
    /// Provides a set of static methods that extends the <see cref="Regex"/> class.
    /// </summary>
    public static class RegexExtensions
    {
        /// <summary>
        /// Searches the specified input string and returns enumerable collection of regular expression matches.
        /// </summary>
        /// <param name="regex">The regular expression to be matched.</param>
        /// <param name="input">The string to search for a match.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<Match> EnumerateMatches(this Regex regex, string input)
        {
            if (regex == null)
            {
                throw new ArgumentNullException("regex");
            }

            return EnumerateMatches(input, (f) => regex.Match(f));
        }

        /// <summary>
        /// Searches the specified input string beginning at the specified position and returns enumerable collection of regular expression matches.
        /// </summary>
        /// <param name="regex">The regular expression to be matched.</param>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="startAt">The position at which to start the search.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<Match> EnumerateMatches(this Regex regex, string input, int startAt)
        {
            if (regex == null)
            {
                throw new ArgumentNullException("regex");
            }

            return EnumerateMatches(input, (f) => regex.Match(f, startAt));
        }

        /// <summary>
        /// Searches the specified input string beginning at the specified position and searching only the specified number of characters and returns enumerable collection of regular expression matches.
        /// </summary>
        /// <param name="regex">The regular expression to be matched.</param>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="beginning">The position at which to start the search.</param>
        /// <param name="length">A number of characters to be searched.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<Match> EnumerateMatches(this Regex regex, string input, int beginning, int length)
        {
            if (regex == null)
            {
                throw new ArgumentNullException("regex");
            }

            return EnumerateMatches(input, (f) => regex.Match(f, beginning, length));
        }

        /// <summary>
        /// Searches the specified input string and returns enumerable collection of groups.
        /// </summary>
        /// <param name="regex">The regular expression to be matched.</param>
        /// <param name="input">The string to search for a match.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<Group> EnumerateGroups(this Regex regex, string input)
        {
            return EnumerateMatches(regex, input)
                .EnumerateGroups();
        }

        /// <summary>
        /// Searches the specified input string and returns enumerable collection of groups with a specified name.
        /// </summary>
        /// <param name="regex">The regular expression to be matched.</param>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupName">A name of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<Group> EnumerateGroups(this Regex regex, string input, string groupName)
        {
            return EnumerateMatches(regex, input)
                .EnumerateGroups(groupName);
        }

        /// <summary>
        /// Searches the specified input string and returns enumerable collection of groups that have a specified number.
        /// </summary>
        /// <param name="regex">The regular expression to be matched.</param>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupNumber">A number of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<Group> EnumerateGroups(this Regex regex, string input, int groupNumber)
        {
            return EnumerateMatches(regex, input)
                .EnumerateGroups(groupNumber);
        }

        /// <summary>
        /// Searches the specified input string and returns enumerable collection of groups that have at least one capture.
        /// </summary>
        /// <param name="regex">The regular expression to be matched.</param>
        /// <param name="input">The string to search for a match.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<Group> EnumerateSuccessGroups(this Regex regex, string input)
        {
            return EnumerateMatches(regex, input)
                .EnumerateSuccessGroups();
        }

        /// <summary>
        /// Searches the specified input string and returns enumerable collection of groups that have a specified name and have at least one capture.
        /// </summary>
        /// <param name="regex">The regular expression to be matched.</param>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupName">A name of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<Group> EnumerateSuccessGroups(this Regex regex, string input, string groupName)
        {
            return EnumerateMatches(regex, input)
                .EnumerateSuccessGroups(groupName);
        }

        /// <summary>
        /// Searches the specified input string and returns enumerable collection of groups that have a specified number and have at least one capture.
        /// </summary>
        /// <param name="regex">The regular expression to be matched.</param>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupNumber">A number of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<Group> EnumerateSuccessGroups(this Regex regex, string input, int groupNumber)
        {
            return EnumerateMatches(regex, input)
                .EnumerateSuccessGroups(groupNumber);
        }

        /// <summary>
        /// Searches the specified input string and returns enumerable collection of captures.
        /// </summary>
        /// <param name="regex">The regular expression to be matched.</param>
        /// <param name="input">The string to search for a match.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<Capture> EnumerateCaptures(this Regex regex, string input)
        {
            return EnumerateMatches(regex, input)
                .EnumerateCaptures();
        }

        /// <summary>
        /// Searches the specified input string and returns enumerable collection of captures from groups that have a specified name.
        /// </summary>
        /// <param name="regex">The regular expression to be matched.</param>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupName">A name of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static IEnumerable<Capture> EnumerateCaptures(this Regex regex, string input, string groupName)
        {
            return EnumerateMatches(regex, input)
                .EnumerateCaptures(groupName);
        }

        /// <summary>
        /// Searches the specified input string and returns enumerable collection of captures from groups that have a specified number.
        /// </summary>
        /// <param name="regex">The regular expression to be matched.</param>
        /// <param name="input">The string to search for a match.</param>
        /// <param name="groupNumber">A number of the group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public static IEnumerable<Capture> EnumerateCaptures(this Regex regex, string input, int groupNumber)
        {
            return EnumerateMatches(regex, input)
                .EnumerateCaptures(groupNumber);
        }

        private static IEnumerable<Match> EnumerateMatches(string input, Func<string, Match> matchFactory)
        {
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
    }
}
