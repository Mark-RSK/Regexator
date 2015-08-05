// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using System.Linq;

namespace Pihrtsoft.Text.RegularExpressions
{
    internal class SplitContext
    {
        public SplitContext(SplitData data)
        {
            Values = data.Values;
            GroupInfos = data.GroupInfos.ExceptZero().ToList().AsReadOnly();
            InputLength = data.Input.Length;
        }

        public ReadOnlyCollection<string> Values { get; }

        public ReadOnlyCollection<GroupInfo> GroupInfos { get; }

        public int InputLength { get; }
    }
}
