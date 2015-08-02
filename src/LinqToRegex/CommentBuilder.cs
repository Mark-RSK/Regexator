// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class CommentBuilder
    {
        private int _index;
        private StringBuilder _sb;
        private List<SyntaxKind> _items;

        private static readonly Regex _newLineRegex = new Regex(@"\r?\n");

        public string AddComments(string pattern, List<SyntaxKind> items)
        {
            _index = 0;
            _sb = new StringBuilder();
            _items = items;
            var lines = _newLineRegex.Split(pattern);
            int maxLength = lines.Max(f => f.Length);

            foreach (var line in lines)
            {
                _sb.Append(line);
                AppendComment(maxLength - line.Length + 1);
            }

            return _sb.ToString();
        }

        private void AppendComment(int indexOffset)
        {
            if (_index < _items.Count)
            {
                string s = GetComment();
                Debug.Assert(s != null);

                if (s != null)
                {
                    _sb.Append(' ', indexOffset);
                    _sb.Append("# ");
                    _sb.Append(s);
                    _index++;

                    if (_index < _items.Count)
                    {
                        AppendQuantifierComment();
                    }

                    _sb.AppendLine();
                }
            }
        }

        private void AppendQuantifierComment()
        {
            string s = GetQuantifierComment(_items[_index]);
            if (s != null)
            {
                _sb.Append(" ");
                _sb.Append(s);
                _index++;

                if (_index < _items.Count)
                {
                    if (_items[_index] == SyntaxKind.Lazy)
                    {
                        _sb.Append(" but as few times as possible");
                        _index++;
                    }
                }
            }
        }

        private string GetComment()
        {
            if (_items[_index] == SyntaxKind.GroupEnd)
            {
                if ((_index + 1) < _items.Count)
                {
                    if (GetQuantifierComment(_items[_index + 1]) != null)
                    {
                        return "group";
                    }
                }
            }

            return _comments[(int)_items[_index]];
        }

        private static string GetQuantifierComment(SyntaxKind kind)
        {
            switch (kind)
            {
                case SyntaxKind.Maybe:
                    return "zero or one times";
                case SyntaxKind.MaybeMany:
                    return "zero or more times";
                case SyntaxKind.OneMany:
                    return "one or more times";
                case SyntaxKind.Count:
                    return "exactly n times";
                case SyntaxKind.CountRange:
                    return "from n to m times";
                case SyntaxKind.CountFrom:
                    return "at least n times";
                case SyntaxKind.MaybeCount:
                    return "from zero to n times";
            }

            return null;
        }

        private static readonly string[] _comments = new string[] {
            "if",
            "if",
            "or",
            "beginning of input",
            "beginning of input or line",
            "end of input",
            "end of input or line",
            "end of input or before ending linefeed",
            "word boundary",
            "non-word boundary",
            "previous match end",
            "positive lookahead assertion",
            "negative lookahead assertion",
            "positive lookbehind assertion",
            "negative lookbehind assertion",
            "numbered group",
            "named group",
            "noncapturing group",
            "nonbacktracking group",
            "balancing group",
            "group options",
            "group end",
            "digit",
            "non-digit",
            "white-space",
            "non-white-space",
            "word character",
            "non-word character",
            "character group",
            "negative character group",
            "Unicode category",
            "not Unicode category",
            "Unicode block",
            "not Unicode block",
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            null,
            "options",
            "group reference",
            "text",
            "character",
        };
    }
}
