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
        private ReadOnlyCollection<string> _values;
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

        private string[] Split()
        {
            if (Limit == MatchData.InfiniteLimit)
            {
                return Regex.Split(Input);
            }
            else
            {
                return Regex.Split(Input, Limit);
            }
        }

        private IEnumerable<SplitItem> CreateItems()
        {
            if (Limit == MatchData.InfiniteLimit)
            {
                return CreateItems(f => f.Success);
            }
            else
            {
                return CreateItems(f => f.Success && f.ItemIndex < Limit);
            }
        }

        private IEnumerable<SplitItem> CreateItems(Func<SplitItem, bool> predicate)
        {
            var item = new MatchSplitItem(this);

            while (predicate(item))
            {
                yield return item;
                foreach (var item2 in item.SplitItems.Where(predicate))
                {
                    yield return item2;
                }
                item = item.NextItem();
            }

            _limitState = (item.Success && item.ItemIndex > 0) ? LimitState.Limited : LimitState.NotLimited;
        }

        public Match Match() => Regex.Match(Input);

        public ReadOnlyCollection<string> Values
        {
            get
            {
                if (_values == null)
                {
                    _values = Array.AsReadOnly(Split());
                }

                return _values;
            }
        }

        public SplitItemCollection Items
        {
            get
            {
                if (_items == null)
                {
                    if (_values == null)
                    {
                        _values = Array.AsReadOnly(Split());
                    }

                    _items = new SplitItemCollection(CreateItems().ToArray(), GroupInfos);
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
