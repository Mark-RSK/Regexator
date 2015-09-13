// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions
{
    public class GroupItemCollection
        : ReadOnlyCollection<GroupItem>
    {
        private int _captureCount = -1;
        private ReadOnlyCollection<GroupInfo> _successGroups;
        private ReadOnlyCollection<GroupInfo> _unsuccessGroups;

        internal GroupItemCollection(IList<GroupItem> list)
            : base(list)
        {
        }

        public int CaptureCount
        {
            get
            {
                if (_captureCount == -1)
                    _captureCount = Items.ToCaptureItems().Count();

                return _captureCount;
            }
        }

        public ReadOnlyCollection<GroupInfo> SuccessGroups
        {
            get
            {
                if (_successGroups == null)
                {
                    _successGroups = Items
                        .Where(f => f.Success)
                        .Select(f => f.GroupInfo)
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
                    _unsuccessGroups = Items
                        .ToGroupInfos()
                        .Except(SuccessGroups, new GroupInfoIndexEqualityComparer())
                        .ToList()
                        .AsReadOnly();
                }

                return _unsuccessGroups;
            }
        }
    }
}
