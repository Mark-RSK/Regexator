// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using System.Collections.Generic;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions
{
    public class SplitItemCollection
        : ReadOnlyCollection<SplitItem>
    {
        private readonly GroupInfoCollection _groupInfos;
        private ReadOnlyCollection<GroupInfo> _unsuccessGroups;
        private ReadOnlyCollection<GroupInfo> _successGroups;

        internal SplitItemCollection(IList<SplitItem> list, GroupInfoCollection groupInfos)
            : base(list)
        {
            _groupInfos = groupInfos;
        }

        public ReadOnlyCollection<GroupInfo> SuccessGroups
        {
            get
            {
                if (_successGroups == null)
                {
                    _successGroups = this
                        .Where(f => f.Kind == SplitItemKind.Group)
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
