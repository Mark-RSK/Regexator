// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Text.RegularExpressions;

namespace Pihrtsoft.Regexator
{
    public sealed class CaptureItem
    {
        private readonly Capture _capture;
        private readonly GroupItem _groupItem;
        private readonly int _itemIndex;
        private readonly string _key;

        internal CaptureItem(Capture capture, GroupItem groupItem, int itemIndex)
        {
            _capture = capture;
            _groupItem = groupItem;
            _itemIndex = itemIndex;
            _key = groupItem.Key + itemIndex;
        }

        public override string ToString()
        {
            return Value;
        }

        public string Value
        {
            get { return Capture.Value; }
        }

        public int Index
        {
            get { return Capture.Index; }
        }

        public int Length
        {
            get { return Capture.Length; }
        }

        public MatchItem MatchItem
        {
            get { return GroupItem.MatchItem; }
        }

        public bool IsDefaultCapture
        {
            get { return GroupItem.IsDefaultGroup; }
        }

        public Capture Capture
        {
            get { return _capture; }
        }

        public GroupItem GroupItem
        {
            get { return _groupItem; }
        }

        public GroupInfo GroupInfo
        {
            get { return _groupItem.GroupInfo; }
        }

        public int ItemIndex
        {
            get { return _itemIndex; }
        }

        public string Key
        {
            get { return _key; }
        }
    }
}