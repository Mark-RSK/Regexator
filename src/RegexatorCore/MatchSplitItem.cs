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
        private readonly int _index;
        private readonly int _length;
        private readonly Match _match;
        private readonly bool _success;
        private readonly int _itemIndex;
        private readonly string _name;
        private readonly string _key;
        private readonly int _splitIndex;
        private readonly SplitContext _context;
        private ReadOnlyCollection<SplitItem> _splitItems;

        public MatchSplitItem(SplitData data)
        {
            if (data == null)
            {
                throw new ArgumentNullException("data");
            }

            _context = new SplitContext(data);
            _match = data.Match();
            _success = true;
            _length = _match.Success ? _match.Index : data.Input.Length;
            _name = "0";
            _key = "0";
        }

        internal MatchSplitItem(MatchSplitItem prevItem, SplitContext context)
        {
            _context = context;
            _match = prevItem._match.NextMatch();
            _success = prevItem._match.Success;
            _index = prevItem._match.Index + prevItem._match.Length;
            _length = (_match.Success ? _match.Index : _context.InputLength) - Index;
            _itemIndex = prevItem.ItemIndex + prevItem.SplitItems.Count + 1;
            _splitIndex = prevItem._splitIndex + 1;
            _key = ItemIndex.ToString(CultureInfo.CurrentCulture);
            _name = _splitIndex.ToString(CultureInfo.CurrentCulture);
        }

        public MatchSplitItem NextItem()
        {
            return new MatchSplitItem(this, _context);
        }

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

        public override string Value
        {
            get { return _context.Values[ItemIndex]; }
        }

        public override int Index
        {
            get { return _index; }
        }

        public override int Length
        {
            get { return _length; }
        }

        public override Capture Capture
        {
            get { return _match; }
        }

        public override bool Success
        {
            get { return _success; }
        }

        public override int ItemIndex
        {
            get { return _itemIndex; }
        }

        public override string Name
        {
            get { return _name; }
        }

        public override SplitItemKind Kind
        {
            get { return SplitItemKind.Split; }
        }

        public override string Key
        {
            get { return _key; }
        }
    }
}
