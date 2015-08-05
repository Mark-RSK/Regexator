// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    public sealed class MatchSplitItem
        : SplitItem
    {
        private readonly Match _match;
        private readonly int _splitIndex;
        private readonly SplitContext _context;
        private ReadOnlyCollection<SplitItem> _splitItems;

        public MatchSplitItem(SplitData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }

            _context = new SplitContext(data);
            _match = data.Match();
            Success = true;
            Length = _match.Success ? _match.Index : data.Input.Length;
            Name = "0";
            Key = "0";
        }

        internal MatchSplitItem(MatchSplitItem prevItem, SplitContext context)
        {
            _context = context;
            _match = prevItem._match.NextMatch();
            Success = prevItem._match.Success;
            Index = prevItem._match.Index + prevItem._match.Length;
            Length = (_match.Success ? _match.Index : _context.InputLength) - Index;
            ItemIndex = prevItem.ItemIndex + prevItem.SplitItems.Count + 1;
            _splitIndex = prevItem._splitIndex + 1;
            Key = ItemIndex.ToString(CultureInfo.CurrentCulture);
            Name = _splitIndex.ToString(CultureInfo.CurrentCulture);
        }

        public MatchSplitItem NextItem() => new MatchSplitItem(this, _context);

        public override ReadOnlyCollection<SplitItem> SplitItems
        {
            get
            {
                if (_splitItems == null)
                {
                    _splitItems = CreateItems().ToList().AsReadOnly();
                }

                return _splitItems;
            }
        }

        private IEnumerable<SplitItem> CreateItems()
        {
            int index = ItemIndex + 1;

            if (_match.Success)
            {
                foreach (var info in _context.GroupInfos)
                {
                    var group = _match.Groups[info.Index];
                    if (group.Success)
                    {
                        yield return new GroupSplitItem(group, info, index, _context);
                        index++;
                    }
                }
            }
        }

        public override string Value => _context.Values[ItemIndex];

        public override int Index { get; }

        public override int Length { get; }

        public override Capture Capture => _match;

        public override bool Success { get; }

        public override int ItemIndex { get; }

        public override string Name { get; }

        public override SplitItemKind Kind => SplitItemKind.Split;

        public override string Key { get; }
    }
}
