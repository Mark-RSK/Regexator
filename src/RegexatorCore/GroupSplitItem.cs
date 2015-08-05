// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    public sealed class GroupSplitItem
        : SplitItem
    {
        private readonly SplitContext _context;
        private readonly Group _group;
        private static readonly ReadOnlyCollection<SplitItem> _empty = Array.AsReadOnly(new SplitItem[] { });

        internal GroupSplitItem(Group group, GroupInfo groupInfo, int itemIndex, SplitContext context)
        {
            _group = group;
            GroupInfo = groupInfo;
            ItemIndex = itemIndex;
            Key = itemIndex.ToString(CultureInfo.CurrentCulture);
            _context = context;
        }

        public override ReadOnlyCollection<SplitItem> SplitItems => _empty;

        public override string Value => _context.Values[ItemIndex];

        public override int Index => _group.Index;

        public override int Length => _group.Length;

        public override int ItemIndex { get; }

        public override string Name => GroupInfo.Name;

        public override GroupInfo GroupInfo { get; }

        public override SplitItemKind Kind => SplitItemKind.Group;

        public override string Key { get; }

        public override Capture Capture { get; }
    }
}
