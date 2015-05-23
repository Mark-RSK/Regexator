// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Collections.ObjectModel;

namespace Pihrtsoft.Text.RegularExpressions
{
    [Serializable]
    public class GroupSettings
        : ICloneable
    {
        private readonly GroupSortProperty _sortPropertyName;
        private readonly ListSortDirection _sortDirection;
        private readonly ReadOnlyCollection<string> _ignoredGroups;
        private readonly HashSet<string> _ignoredSet;
        private readonly bool _isZeroIgnored;
        private readonly GroupInfoSorter _sorter;
        private static readonly GroupSettings _default = new GroupSettings();

        public GroupSettings()
            : this(DefaultSortProperty, DefaultSortDirection)
        {
        }

        public GroupSettings(IList<string> ignoredGroups)
            : this(DefaultSortProperty, DefaultSortDirection, ignoredGroups)
        {
        }

        public GroupSettings(GroupSortProperty sortPropertyName, ListSortDirection sortDirection)
            : this(sortPropertyName, sortDirection, new string[] { })
        {
        }

        public GroupSettings(GroupSortProperty sortPropertyName, ListSortDirection sortDirection, IList<string> ignoredGroups)
        {
            if (ignoredGroups == null)
            {
                throw new ArgumentNullException("ignoredGroups");
            }
            _sortPropertyName = sortPropertyName;
            _sortDirection = sortDirection;
            _ignoredGroups = new ReadOnlyCollection<string>(ignoredGroups);
            _ignoredSet = new HashSet<string>(ignoredGroups);
            _isZeroIgnored = _ignoredGroups.Contains("0");
            _sorter = new GroupInfoSorter(SortProperty, SortDirection);
        }

        public static bool HasDefaultValues(GroupSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }
            return settings.IgnoredGroups.Count == 0 &&
                settings.SortProperty == GroupSettings.DefaultSortProperty &&
                settings.SortDirection == GroupSettings.DefaultSortDirection;
        }

        public bool IsIgnored(GroupInfo info)
        {
            if (info == null)
            {
                throw new ArgumentNullException("info");
            }
            return IsIgnored(info.Name);
        }

        public bool IsIgnored(string groupName)
        {
            return _ignoredSet.Contains(groupName);
        }

        public object Clone()
        {
            return new GroupSettings(SortProperty, SortDirection, IgnoredGroups.ToArray());
        }

        public bool IsZeroIgnored
        {
            get { return _isZeroIgnored; }
        }

        public GroupInfoSorter Sorter
        {
            get { return _sorter; }
        }

        public GroupSortProperty SortProperty
        {
            get { return _sortPropertyName; }
        }

        public ListSortDirection SortDirection
        {
            get { return _sortDirection; }
        }

        public ReadOnlyCollection<string> IgnoredGroups
        {
            get { return _ignoredGroups; }
        }

        public static ListSortDirection DefaultSortDirection
        {
            get { return ListSortDirection.Ascending; }
        }

        public static GroupSortProperty DefaultSortProperty
        {
            get { return GroupSortProperty.Index; }
        }

        public static GroupSettings Default
        {
            get { return _default; }
        }
    }
}
