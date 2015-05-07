// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using System.Linq;

namespace Pihrtsoft.Regexator
{
    internal class SplitContext
    {
        private readonly ReadOnlyCollection<string> _values;
        private readonly ReadOnlyCollection<GroupInfo> _groupInfos;
        private readonly int _inputLength;

        public SplitContext(SplitData data)
        {
            _values = data.Values;
            _groupInfos = data.GroupInfos.ExceptZero().ToList().AsReadOnly();
            _inputLength = data.Input.Length;
        }

        public ReadOnlyCollection<string> Values
        {
            get { return _values; }
        }

        public ReadOnlyCollection<GroupInfo> GroupInfos
        {
            get { return _groupInfos; }
        }

        public int InputLength
        {
            get { return _inputLength; }
        }
    }
}
