// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics;

namespace Pihrtsoft.Regexator
{
    [DebuggerDisplay("Index: {Index}, Name: {Name}")]
    public class GroupInfo
    {
        private readonly int _index;
        private readonly string _name;
        private static readonly GroupInfo _default = new GroupInfo(0, "0");

        internal GroupInfo(int index, string name)
        {
            _index = index;
            _name = name;
        }

        protected GroupInfo(GroupInfo info)
        {
            if (info == null) { throw new ArgumentNullException("info"); }
            _index = info.Index;
            _name = info.Name;
        }

        public int Index
        {
            get { return _index; }
        }

        public string Name
        {
            get { return _name; ; }
        }

        public static GroupInfo Default
        {
            get { return _default; }
        }
    }
}
