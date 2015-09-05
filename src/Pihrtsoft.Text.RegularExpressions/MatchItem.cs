// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    public sealed class MatchItem
    {
        private readonly GroupInfoCollection _groupInfos;

        internal MatchItem(Match match, GroupInfoCollection groups)
        {
            Match = match;
            _groupInfos = groups;
            Key = ItemIndex.ToString(CultureInfo.CurrentCulture);
            GroupItems = new GroupItemCollection(_groupInfos.Select((g, i) => new GroupItem(Match.Groups[g.Index], g, i, this)).ToArray());
        }

        private MatchItem(MatchItem previousItem, GroupInfoCollection groups)
        {
            Match = previousItem.Match.NextMatch();
            ItemIndex = previousItem.ItemIndex + 1;
            _groupInfos = groups;
            Key = ItemIndex.ToString(CultureInfo.CurrentCulture);
            GroupItems = new GroupItemCollection(_groupInfos.Select((g, i) => new GroupItem(Match.Groups[g.Index], g, i, this)).ToArray());
        }

        public MatchItem NextItem() => new MatchItem(this, _groupInfos);

        public override string ToString() => Value;

        public IEnumerable<GroupItem> EnumerateGroupItems(GroupSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            return GroupItems
                .Where(f => !settings.IsIgnored(f.Name))
                .OrderBy(f => f.GroupInfo, settings.Sorter);
        }

        public IEnumerable<CaptureItem> EnumerateCaptureItems => GroupItems.ToCaptureItems();

        public string Value => Match.Value;

        public int Index => Match.Index;

        public int Length => Match.Length;

        public bool Success => Match.Success;

        public Match Match { get; }

        public int ItemIndex { get; }

        public string Key { get; }

        public GroupItemCollection GroupItems { get; }
    }
}
