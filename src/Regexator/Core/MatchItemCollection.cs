// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions
{
    public class MatchItemCollection
        : ReadOnlyCollection<MatchItem>
    {
        private CaptureItemCollection _captureItems;
        private ReadOnlyCollection<GroupInfo> _successGroups;
        private ReadOnlyCollection<GroupInfo> _unsuccessGroups;
        private readonly GroupInfoCollection _groupInfos;

        internal MatchItemCollection(IList<MatchItem> list, GroupInfoCollection groupInfos)
            : base(list)
        {
            _groupInfos = groupInfos;
        }

        public int CaptureCount
        {
            get { return CaptureItems.Count; }
        }

        public CaptureItemCollection CaptureItems
        {
            get
            {
                if (_captureItems == null)
                {
                    _captureItems = new CaptureItemCollection(this.ToCaptureItems().ToArray());
                }
                return _captureItems;
            }
        }

        public ReadOnlyCollection<GroupInfo> SuccessGroups
        {
            get
            {
                if (_successGroups == null)
                {
                    _successGroups = this.ToGroupItems(true)
                        .Select(f => f.GroupInfo)
                        .Distinct(new GroupInfoIndexEqualityComparer())
                        .ToList()
                        .AsReadOnly();
                }
                return _successGroups;
            }
        }

        public ReadOnlyCollection<GroupInfo> UnsuccessGroups
        {
            get
            {
                if (_unsuccessGroups == null)
                {
                    _unsuccessGroups = GroupInfos
                        .Except(SuccessGroups, new GroupInfoIndexEqualityComparer())
                        .ToList()
                        .AsReadOnly();
                }
                return _unsuccessGroups;
            }
        }

        public GroupInfoCollection GroupInfos
        {
            get { return _groupInfos; }
        }
    }
}
