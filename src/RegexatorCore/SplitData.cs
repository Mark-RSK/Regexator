// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    public class SplitData
    {
        private LimitState _limitState;
        private SplitItemCollection _items;

        public SplitData(Regex regex, string input)
            : this(regex, input, MatchData.InfiniteLimit)
        {
        }

        public SplitData(Regex regex, string input, int limit)
        {
            if (regex == null)
            {
                throw new ArgumentNullException(nameof(regex));
            }

            if (input == null)
            {
                throw new ArgumentNullException(nameof(input));
            }

            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(limit));
            }

            Regex = regex;
            Input = input;
            Limit = limit;
            GroupInfos = new GroupInfoCollection(regex);
        }

        private IEnumerable<Match> EnumerateMatches(Match match)
        {
            if (Regex.RightToLeft)
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
                var matches = new List<Match>();
                while (match.Success)
                {
                    yield return match;
                    match = match.NextMatch();
                }
            }
        }

        private IEnumerable<SplitItem> EnumerateItems()
        {
            if (Limit == 1)
            {
                yield return new MatchSplitItem(Input);
                yield break;
            }

            Match firstMatch = Regex.Match(Input);
            if (!firstMatch.Success)
            {
                yield return new MatchSplitItem(Input);
                yield break;
            }

            int prevIndex = 0;
            int itemIndex = 0;
            int splitIndex = 0;

            foreach (var match in EnumerateMatches(firstMatch))
            {
                yield return new MatchSplitItem(Input.Substring(prevIndex, match.Index - prevIndex), prevIndex, itemIndex, splitIndex);
                itemIndex++;
                splitIndex++;
                prevIndex = match.Index + match.Length;

                if (Regex.RightToLeft)
                {
                    for (int i = (GroupInfos.Count - 1); i >= 0; i--)
                    {
                        if (GroupInfos[i].Index != 0)
                        {
                            var group = match.Groups[GroupInfos[i].Index];
                            if (group.Success)
                            {
                                yield return new GroupSplitItem(group, GroupInfos[i], itemIndex);
                                itemIndex++;
                            }
                        }
                    }
                }
                else
                {
                    foreach (var info in GroupInfos)
                    {
                        if (info.Index != 0)
                        {
                            var group = match.Groups[info.Index];
                            if (group.Success)
                            {
                                yield return new GroupSplitItem(group, info, itemIndex);
                                itemIndex++;
                            }
                        }
                    }
                }
            }

            yield return new MatchSplitItem(Input.Substring(prevIndex, Input.Length - prevIndex), prevIndex, itemIndex, splitIndex);
        }

        private IList<SplitItem> GetItems()
        {
            if (Limit == MatchData.InfiniteLimit)
            {
                _limitState = LimitState.NotLimited;
                return EnumerateItems().ToArray();
            }
            else
            {
                int cnt = 0;
                var lst = new List<SplitItem>();

                foreach (var item in EnumerateItems())
                {
                    if (cnt < Limit)
                    {
                        lst.Add(item);
                        if (item.Kind == SplitItemKind.Split)
                        {
                            cnt++;
                        }
                    }
                    else
                    {
                        _limitState = LimitState.Limited;
                        return lst;
                    }
                }

                _limitState = LimitState.NotLimited;
                return lst;
            }
        }

        public SplitItemCollection Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new SplitItemCollection(GetItems(), GroupInfos);
#if DEBUG
                    var splits = (Limit == MatchData.InfiniteLimit)
                        ? Regex.Split(Input)
                        : Regex.Split(Input, Limit);

                    System.Diagnostics.Debug.Assert(splits.Length == _items.Count);

                    int i = 0;
                    foreach (var item in _items)
                    {
                        if (item.Value != splits[i])
                        {
                            System.Diagnostics.Debug.WriteLine(i);
                            System.Diagnostics.Debug.WriteLine(splits[i]);
                            System.Diagnostics.Debug.WriteLine(item.Value);
                            System.Diagnostics.Debug.Assert(false);
                        }

                        i++;
                    }
#endif
                }

                return _items;
            }
        }

        public ReadOnlyCollection<GroupInfo> SuccessGroups => Items.SuccessGroups;

        public ReadOnlyCollection<GroupInfo> UnsuccessGroups => Items.UnsuccessGroups;

        public Regex Regex { get; }

        public GroupInfoCollection GroupInfos { get; }

        public string Input { get; }

        public int Limit { get; }

        public LimitState LimitState => _limitState;
    }
}
