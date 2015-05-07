// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Regexator
{
    public sealed class GroupSplitItem
        : SplitItem
    {
        private readonly Group _group;
        private readonly GroupInfo _groupInfo;
        private readonly int _itemIndex;
        private readonly string _key;
        private readonly SplitContext _context;
        private static readonly ReadOnlyCollection<SplitItem> _empty = Array.AsReadOnly(new SplitItem[] { });

        internal GroupSplitItem(Group group, GroupInfo groupInfo, int itemIndex, SplitContext context)
        {
            _group = group;
            _groupInfo = groupInfo;
            _itemIndex = itemIndex;
            _key = itemIndex.ToString(CultureInfo.CurrentCulture);
            _context = context;
        }

        public override ReadOnlyCollection<SplitItem> SplitItems
        {
            get { return _empty; }
        }

        public override string Value
        {
            get { return _context.Values[ItemIndex]; }
        }

        public override int Index
        {
            get { return _group.Index; }
        }

        public override int Length
        {
            get { return _group.Length; }
        }

        public override int ItemIndex
        {
            get { return _itemIndex; }
        }

        public override string Name
        {
            get { return _groupInfo.Name; }
        }

        public override GroupInfo GroupInfo
        {
            get { return _groupInfo; }
        }

        public override SplitItemKind Kind
        {
            get { return SplitItemKind.Group; }
        }

        public override string Key
        {
            get { return _key; }
        }

        public override Capture Capture
        {
            get { return _group; }
        }
    }
}
