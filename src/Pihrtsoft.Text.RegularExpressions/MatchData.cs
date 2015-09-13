// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    public class MatchData
    {
        private LimitState _limitState;
        private MatchItemCollection _items;

        public const int InfiniteLimit = 0;

        public MatchData(Regex regex, string input)
            : this(regex, input, InfiniteLimit)
        {
        }

        public MatchData(Regex regex, string input, int limit)
        {
            if (regex == null)
                throw new ArgumentNullException(nameof(regex));

            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (limit < 0)
                throw new ArgumentOutOfRangeException(nameof(limit));

            Regex = regex;
            GroupInfos = new GroupInfoCollection(regex);
            Input = input;
            Limit = limit;
        }

        private IEnumerable<MatchItem> CreateItems()
        {
            if (Limit == InfiniteLimit)
                return CreateItems(f => f.Success);
            else
                return CreateItems(f => f.Success && f.ItemIndex < Limit);
        }

        private IEnumerable<MatchItem> CreateItems(Func<MatchItem, bool> predicate)
        {
            MatchItem item = MatchItem();
            while (predicate(item))
            {
                yield return item;
                item = item.NextItem();
            }

            _limitState = (item.Success && item.ItemIndex > 0) ? LimitState.Limited : LimitState.NotLimited;
        }

        public IEnumerable<CaptureItem> EnumerateCaptureItems() => Items.ToCaptureItems();

        public IEnumerable<GroupItem> EnumerateGroupItems() => Items.ToGroupItems();

        public IEnumerable<GroupItem> EnumerateGroupItems(int groupIndex) => Items.ToGroupItems(groupIndex);

        public IEnumerable<GroupItem> EnumerateGroupItems(string groupName) => Items.ToGroupItems(groupName);

        public IEnumerable<GroupItem> EnumerateGroupItems(bool successOnly) => Items.ToGroupItems(successOnly);

        public MatchItem MatchItem() => new MatchItem(Match(), GroupInfos);

        public Match Match() => Regex.Match(Input);

        public MatchItemCollection Items
        {
            get
            {
                if (_items == null)
                    _items = new MatchItemCollection(CreateItems().ToArray(), GroupInfos);

                return _items;
            }
        }

        public int MatchCount => Items.Count;

        public int CaptureCount => Items.CaptureCount;

        public ReadOnlyCollection<GroupInfo> SuccessGroups => Items.SuccessGroups;

        public ReadOnlyCollection<GroupInfo> UnsuccessGroups => Items.UnsuccessGroups;

        public Regex Regex { get; }

        public GroupInfoCollection GroupInfos { get; }

        public string Input { get; }

        public int Limit { get; }

        public LimitState LimitState => _limitState;
    }
}
