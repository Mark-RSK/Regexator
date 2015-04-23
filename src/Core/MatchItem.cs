// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Regexator
{
    public sealed class MatchItem
    {
        private readonly GroupInfoCollection _groupInfos;
        private readonly Match _match;
        private readonly int _itemIndex;
        private string _key;
        private GroupItemCollection _groupItems;

        internal MatchItem(Match match, GroupInfoCollection groups)
        {
            _match = match;
            _groupInfos = groups;
            Initialize();
        }

        private MatchItem(MatchItem previousItem, GroupInfoCollection groups)
        {
            _match = previousItem.Match.NextMatch();
            _itemIndex = previousItem.ItemIndex + 1;
            _groupInfos = groups;
            Initialize();
        }

        private void Initialize()
        {
            _key = ItemIndex.ToString(CultureInfo.CurrentCulture);
            _groupItems = new GroupItemCollection(_groupInfos.Select((g, i) => new GroupItem(Match.Groups[g.Index], g, i, this)).ToArray());
        }

        public MatchItem NextItem()
        {
            return new MatchItem(this, _groupInfos);
        }

        public override string ToString()
        {
            return Value;
        }

        public IEnumerable<GroupItem> EnumerateGroupItems(GroupSettings settings)
        {
            return GroupItems.FilterAndSort(settings);
        }

        public IEnumerable<CaptureItem> EnumerateCaptureItems
        {
            get { return GroupItems.ToCaptureItems(); }
        }

        public string Value
        {
            get { return Match.Value; }
        }

        public int Index
        {
            get { return Match.Index; }
        }

        public int Length
        {
            get { return Match.Length; }
        }

        public bool Success
        {
            get { return Match.Success; }
        }

        public Match Match
        {
            get { return _match; }
        }

        public int ItemIndex
        {
            get { return _itemIndex; }
        }

        public string Key
        {
            get { return _key; }
        }

        public GroupItemCollection GroupItems
        {
            get { return _groupItems; }
        }
    }
}
