// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions
{
    public class ReplaceData
    {
        private string _output;
        private ReplaceItemCollection _items;
        private List<ReplaceItem> _lst;
        private LimitState _limitState;
        private int _offset;
        private int _count;

        public ReplaceData(Regex regex, string input)
            : this(regex, input, string.Empty)
        {
        }

        public ReplaceData(Regex regex, string input, string replacement)
            : this(regex, input, replacement, ReplacementSettings.Default)
        {
        }

        public ReplaceData(Regex regex, string input, string replacement, ReplacementSettings settings)
        {
            if (regex == null)
                throw new ArgumentNullException(nameof(regex));

            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (replacement == null)
                throw new ArgumentNullException(nameof(replacement));

            if (settings == null)
                throw new ArgumentNullException(nameof(settings));

            Regex = regex;
            Input = input;
            Replacement = replacement;
            Settings = settings;
        }

        private string Replace()
        {
            _lst = new List<ReplaceItem>();

            if (Settings.Limit == MatchData.InfiniteLimit)
                return Regex.Replace(Input, Evaluator);
            else
                return Regex.Replace(Input, Evaluator, Settings.Limit);
        }

        private string Evaluator(Match match)
        {
            var item = new ReplaceItem(match, GetResult(match), match.Index + _offset, _count);
            _lst.Add(item);
            _offset += item.Result.Length - match.Length;
            _count++;

            if (Settings.Limit != MatchData.InfiniteLimit && _count == Settings.Limit && match.NextMatch().Success)
                _limitState = LimitState.Limited;
            else
                _limitState = LimitState.NotLimited;

            return item.Result.Value;
        }

        private string GetResult(Match match)
        {
            if (Settings.Character != null)
                return new string(Settings.Character.Value, match.Length);

            switch (Settings.Mode)
            {
                case ReplacementMode.ToUpper:
                    return match.Result(Replacement).ToUpper(CultureInfo.CurrentCulture);
                case ReplacementMode.ToLower:
                    return match.Result(Replacement).ToLower(CultureInfo.CurrentCulture);
                default:
                    return match.Result(Replacement);
            }
        }

        public Regex Regex { get; }

        public string Input { get; }

        public string Output
        {
            get
            {
                if (_lst == null)
                    _output = Replace();

                return _output;
            }
        }

        public string Replacement { get; }

        public ReplaceItemCollection Items
        {
            get
            {
                if (_items == null)
                {
                    if (_lst == null)
                        _output = Replace();

                    _items = new ReplaceItemCollection(_lst);
                }

                return _items;
            }
        }

        public LimitState LimitState => _limitState;

        public ReplacementSettings Settings { get; }
    }
}
