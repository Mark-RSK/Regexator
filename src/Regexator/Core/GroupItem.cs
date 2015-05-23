// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Linq;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    public sealed class GroupItem
    {
        private readonly Group _group;
        private readonly GroupInfo _groupInfo;
        private readonly int _itemIndex;
        private readonly string _key;
        private readonly CaptureItemCollection _captureItems;
        private readonly MatchItem _matchItem;

        internal GroupItem(Group group, GroupInfo groupInfo, int itemIndex, MatchItem matchItem)
        {
            _group = group;
            _groupInfo = groupInfo;
            _itemIndex = itemIndex;
            _matchItem = matchItem;
            _key = matchItem.Key + groupInfo.Name;
            _captureItems = new CaptureItemCollection(Captures
                .Cast<Capture>()
                .Select((c, i) => new CaptureItem(c, this, i))
                .ToArray());
        }

        public override string ToString()
        {
            return Group.ToString();
        }

        public CaptureCollection Captures
        {
            get { return Group.Captures; }
        }

        public int CaptureCount
        {
            get { return Captures.Count; }
        }

        public string Value
        {
            get { return Group.Value; }
        }

        public int Index
        {
            get { return Group.Index; }
        }

        public int Length
        {
            get { return Group.Length; }
        }

        public bool Success
        {
            get { return Group.Success; }
        }

        public bool IsDefaultGroup
        {
            get { return GroupInfo.Index == 0; }
        }

        public Group Group
        {
            get { return _group; }
        }

        public GroupInfo GroupInfo
        {
            get { return _groupInfo; }
        }

        public string Name
        {
            get { return GroupInfo.Name; }
        }

        public int ItemIndex
        {
            get { return _itemIndex; }
        }

        public string Key
        {
            get { return _key; }
        }

        public CaptureItemCollection CaptureItems
        {
            get { return _captureItems; }
        }

        public MatchItem MatchItem
        {
            get { return _matchItem; }
        }
    }
}
