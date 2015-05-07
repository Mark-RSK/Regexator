// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Regexator
{
    public class GroupInfoCollection
        : ReadOnlyCollection<GroupInfo>
    {
        private readonly Dictionary<string, GroupInfo> _names;
        private readonly Dictionary<int, GroupInfo> _indexes;

        public GroupInfoCollection(Regex regex)
            : base(Initialize(regex))
        {
            _names = ToNameDictionary();
            _indexes = ToIndexDictionary();
        }

        private static GroupInfo[] Initialize(Regex regex)
        {
            if (regex == null)
            {
                throw new ArgumentNullException("regex");
            }
            return regex.GetGroupNames().Select((n, i) => new GroupInfo(i, n)).ToArray();
        }

        public bool Contains(string groupName)
        {
            if (groupName == null)
            {
                throw new ArgumentNullException("groupName");
            }
            return _names.ContainsKey(groupName);
        }

        public bool Contains(int groupIndex)
        {
            if (groupIndex < 0)
            {
                throw new ArgumentOutOfRangeException("groupIndex");
            }
            return _indexes.ContainsKey(groupIndex);
        }

        internal Dictionary<string, GroupInfo> ToNameDictionary()
        {
            return Items.ToDictionary(f => f.Name, f => f);
        }

        internal Dictionary<int, GroupInfo> ToIndexDictionary()
        {
            return Items.ToDictionary(f => f.Index, f => f);
        }

        public GroupInfo this[string groupName]
        {
            get
            {
                if (groupName == null)
                {
                    throw new ArgumentNullException("groupName");
                }
                try
                {
                    return _names[groupName];
                }
                catch (KeyNotFoundException)
                {
                    throw new ArgumentOutOfRangeException("groupName");
                }
            }
        }
    }
}
