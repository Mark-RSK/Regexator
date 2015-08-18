﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    internal static class RegexSplit
    {
        public static IEnumerable<string> EnumerateValues(Regex regex, string input)
        {
            return EnumerateValues(regex, input, 0);
        }

        public static IEnumerable<string> EnumerateValues(Regex regex, string input, int count)
        {
            if (regex == null)
            {
                throw new ArgumentNullException(nameof(regex));
            }

            return EnumerateValues(regex, input, count, regex.RightToLeft ? input.Length : 0);
        }

        public static IEnumerable<string> EnumerateValues(Regex regex, string input, int count, int startAt)
        {
            if (regex == null)
            {
                throw new ArgumentNullException(nameof(regex));
            }

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (count < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(count));
            }

            if (startAt < 0 || startAt > input.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(startAt));
            }

            if (count == 1)
            {
                yield return input;
                yield break;
            }

            Match firstMatch = regex.Match(input, startAt);
            if (!firstMatch.Success)
            {
                yield return input;
                yield break;
            }

            count--;
            int prevIndex = 0;

            foreach (var match in EnumerateMatches(firstMatch, regex.RightToLeft))
            {
                yield return input.Substring(prevIndex, match.Index - prevIndex);
                prevIndex = match.Index + match.Length;

                if (regex.RightToLeft)
                {
                    for (int i = (match.Groups.Count - 1); i >= 1; i--)
                    {
                        if (match.Groups[i].Success)
                        {
                            yield return match.Groups[i].Value;
                        }
                    }
                }
                else
                {
                    for (int i = 1; i < match.Groups.Count; i++)
                    {
                        if (match.Groups[i].Success)
                        {
                            yield return match.Groups[i].Value;
                        }
                    }
                }

                count--;
                if (count == 0)
                {
                    yield break;
                }
            }

            yield return input.Substring(prevIndex, input.Length - prevIndex);
        }

        private static IEnumerable<Match> EnumerateMatches(Match match, bool rightToLeft)
        {
            if (rightToLeft)
            {
                var matches = new List<Match>();
                while (match.Success)
                {
                    matches.Add(match);
                    match = match.NextMatch();
                }

                for (int i = (matches.Count - 1); i >= 0; i--)
                {
                    yield return matches[i];
                }
            }
            else
            {
                while (match.Success)
                {
                    yield return match;
                    match = match.NextMatch();
                }
            }
        }
    }}
