// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions
{
    public class ReplaceResult
    {
        private readonly string _value;
        private readonly int _index;
        private readonly ReplaceItem _replaceItem;

        internal ReplaceResult(string value, int index, ReplaceItem replaceItem)
        {
            _value = value;
            _index = index;
            _replaceItem = replaceItem;
        }

        public override string ToString()
        {
            return _value;
        }

        public string Value
        {
            get { return _value; }
        }

        public int Index
        {
            get { return _index; }
        }

        public int Length
        {
            get { return _value.Length; }
        }

        public int EndIndex
        {
            get { return _index + _value.Length; }
        }

        public ReplaceItem ReplaceItem
        {
            get { return _replaceItem; }
        }
    }
}
