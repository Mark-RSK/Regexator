// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    public class ReplaceData
    {
        private readonly Regex _regex;
        private readonly string _input;
        private readonly string _replacement;
        private readonly int _limit;
        private readonly ResultMode _resultMode;
        private string _output;
        private ReplaceItemCollection _items;
        private List<ReplaceItem> _lst;
        private LimitState _limitState;
        private int _offset;
        private int _count;

        public ReplaceData(Regex regex, string input, string replacement)
            : this(regex, input, replacement, ResultMode.None, MatchData.InfiniteLimit)
        {
        }

        public ReplaceData(Regex regex, string input, string replacement, ResultMode mode)
            : this(regex, input, replacement, mode, MatchData.InfiniteLimit)
        {
        }

        public ReplaceData(Regex regex, string input, string replacement, int limit)
            : this(regex, input, replacement, ResultMode.None, limit)
        {
        }

        public ReplaceData(Regex regex, string input, string replacement, ResultMode resultMode, int limit)
        {
            if (regex == null)
            {
                throw new ArgumentNullException("regex");
            }

            if (input == null)
            {
                throw new ArgumentNullException("input");
            }

            if (replacement == null)
            {
                throw new ArgumentNullException("replacement");
            }

            if (limit < 0)
            {
                throw new ArgumentOutOfRangeException("limit");
            }

            _regex = regex;
            _input = input;
            _replacement = replacement;
            _resultMode = resultMode;
            _limit = limit;
        }

        private string Replace()
        {
            _lst = new List<ReplaceItem>();

            if (Limit == MatchData.InfiniteLimit)
            {
                return this.Regex.Replace(Input, Evaluator);
            }
            else
            {
                return this.Regex.Replace(Input, Evaluator, Limit);
            }
        }

        private string Evaluator(Match match)
        {
            var item = new ReplaceItem(match, ProcessResult(match.Result(Replacement)), match.Index + _offset, _count);
            _lst.Add(item);
            _offset += item.Result.Length - match.Length;
            _count++;

            if (Limit != MatchData.InfiniteLimit && _count == Limit && match.NextMatch().Success)
            {
                _limitState = LimitState.Limited;
            }
            else
            {
                _limitState = LimitState.NotLimited;
            }

            return item.Result.Value;
        }

        private string ProcessResult(string result)
        {
            switch (ResultMode)
            {
                case ResultMode.ToUpper:
                    return result.ToUpper(CultureInfo.CurrentCulture);
                case ResultMode.ToLower:
                    return result.ToLower(CultureInfo.CurrentCulture);
                default:
                    return result;
            }
        }

        public Regex Regex
        {
            get { return _regex; }
        }

        public string Input
        {
            get { return _input; }
        }

        public string Output
        {
            get
            {
                if (_lst == null)
                {
                    _output = Replace();
                }

                return _output;
            }
        }

        public string Replacement
        {
            get { return _replacement; }
        }

        public ReplaceItemCollection Items
        {
            get
            {
                if (_items == null)
                {
                    if (_lst == null)
                    {
                        _output = Replace();
                    }

                    _items = new ReplaceItemCollection(_lst);
                }

                return _items;
            }
        }

        public int Limit
        {
            get { return _limit; }
        }

        public LimitState LimitState
        {
            get { return _limitState; }
        }

        public ResultMode ResultMode
        {
            get { return _resultMode; }
        }
    }
}
