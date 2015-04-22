// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.ComponentModel;
using System.Collections.Generic;

namespace Pihrtsoft.Regexator
{
    [Serializable]
    public class GroupInfoSorter
        : IComparer<GroupInfo>
    {
        private readonly GroupSortProperty _sortPropertyName;
        private readonly ListSortDirection _sortDirection;

        public GroupInfoSorter()
            : this(GroupSettings.DefaultSortProperty, GroupSettings.DefaultSortDirection)
        {
        }

        public GroupInfoSorter(GroupSortProperty sortPropertyName, ListSortDirection sortDirection)
        {
            _sortPropertyName = sortPropertyName;
            _sortDirection = sortDirection;
        }

        public int Compare(GroupInfo x, GroupInfo y)
        {
            if (object.ReferenceEquals(x, y))
            {
                return 0;
            }
            if (object.ReferenceEquals(x, null))
            {
                return -1;
            }
            if (object.ReferenceEquals(y, null))
            {
                return 1;
            }
            int value = (SortPropertyName == GroupSortProperty.Name) ? string.Compare(x.Name, y.Name, StringComparison.CurrentCulture) : x.Index.CompareTo(y.Index);
            return SortDirection == ListSortDirection.Ascending ? value : -value;
        }

        public GroupSortProperty SortPropertyName
        {
            get { return _sortPropertyName; }
        }

        public ListSortDirection SortDirection
        {
            get { return _sortDirection; }
        }
    }
}
