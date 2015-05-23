// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Globalization;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    public sealed class ReplaceItem
    {
        private readonly Match _match;
        private readonly int _itemIndex;
        private readonly string _key;
        private readonly ReplaceResult _result;

        internal ReplaceItem(Match match, string resultValue, int resultIndex, int itemIndex)
        {
            _match = match;
            _itemIndex = itemIndex;
            _key = itemIndex.ToString(CultureInfo.CurrentCulture);
            _result = new ReplaceResult(resultValue, resultIndex, this);
        }

        public override string ToString()
        {
            return _result.ToString();
        }

        public int MatchEndIndex
        {
            get { return Match.Index + Match.Length; }
        }

        public Match Match
        {
            get { return _match; }
        }

        public int ItemIndex
        {
            get { return _itemIndex; }
        }

        public string Key
        {
            get { return _key; }
        }

        public ReplaceResult Result
        {
            get { return _result; }
        }
    }
}
