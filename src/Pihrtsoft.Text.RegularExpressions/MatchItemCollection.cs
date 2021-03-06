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

        internal MatchItemCollection(IList<MatchItem> list, GroupInfoCollection groupInfos)
            : base(list)
        {
            GroupInfos = groupInfos;
        }

        public int CaptureCount => CaptureItems.Count;

        public CaptureItemCollection CaptureItems
        {
            get { return _captureItems ?? (_captureItems = new CaptureItemCollection(this.ToCaptureItems().ToArray())); }
        }

        public ReadOnlyCollection<GroupInfo> SuccessGroups
        {
            get
            {
                if (_successGroups == null)
                {
                    _successGroups = this.ToSuccessGroupItems()
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

        public GroupInfoCollection GroupInfos { get; }
    }
}
