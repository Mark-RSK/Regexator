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
        private readonly Regex _regex;
        private readonly GroupInfoCollection _groupInfos;
        private readonly string _input;
        private readonly int _limit;
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
            {
                throw new ArgumentNullException("regex");
            }
            if (input == null)
            {
                throw new ArgumentNullException("input");
            }
            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException("limit");
            }
            _regex = regex;
            _groupInfos = new GroupInfoCollection(regex);
            _input = input;
            _limit = limit;
        }

        private IEnumerable<MatchItem> CreateItems()
        {
            if (Limit == InfiniteLimit)
            {
                return CreateItems(f => f.Success);
            }
            else
            {
                return CreateItems(f => f.Success && f.ItemIndex < Limit);
            }
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

        public IEnumerable<CaptureItem> EnumerateCaptureItems()
        {
            return Items.ToCaptureItems();
        }

        public IEnumerable<GroupItem> EnumerateGroupItems()
        {
            return Items.ToGroupItems();
        }

        public IEnumerable<GroupItem> EnumerateGroupItems(int groupIndex)
        {
            return Items.ToGroupItems(groupIndex);
        }

        public IEnumerable<GroupItem> EnumerateGroupItems(string groupName)
        {
            return Items.ToGroupItems(groupName);
        }

        public IEnumerable<GroupItem> EnumerateGroupItems(bool successOnly)
        {
            return Items.ToGroupItems(successOnly);
        }

        public MatchItem MatchItem()
        {
            return new MatchItem(Match(), GroupInfos);
        }

        public Match Match()
        {
            return Regex.Match(Input);
        }

        public MatchItemCollection Items
        {
            get
            {
                if (_items == null)
                {
                    _items = new MatchItemCollection(CreateItems().ToArray(), GroupInfos);
                }
                return _items;
            }
        }

        public int MatchCount
        {
            get { return Items.Count; }
        }

        public int CaptureCount
        {
            get { return Items.CaptureCount; }
        }

        public ReadOnlyCollection<GroupInfo> SuccessGroups
        {
            get { return Items.SuccessGroups; }
        }

        public ReadOnlyCollection<GroupInfo> UnsuccessGroups
        {
            get { return Items.UnsuccessGroups; }
        }

        public Regex Regex
        {
            get { return _regex; }
        }

        public GroupInfoCollection GroupInfos
        {
            get { return _groupInfos; }
        }

        public string Input
        {
            get { return _input; }
        }

        public int Limit
        {
            get { return _limit; }
        }

        public LimitState LimitState
        {
            get { return _limitState; }
        }
    }
}
