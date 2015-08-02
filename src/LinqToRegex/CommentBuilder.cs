// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal static class CommentBuilder
    {
        private static readonly Regex _newLineRegex = new Regex(@"\r?\n");

        public static string AddComments(string pattern, List<SyntaxKind> tokens)
        {
            var i = 0;
            var sb = new StringBuilder();
            var lines = _newLineRegex.Split(pattern);
            var maxLength = lines.Max(f => f.Length);

            foreach (var line in lines)
            {
                sb.Append(line);

                if (i < tokens.Count)
                {
                    string s = _comments[(int)tokens[i]];
                    if (s != null)
                    {
                        sb.Append(' ', maxLength - line.Length + 1);
                        sb.Append("# ");
                        sb.Append(s);
                        i++;

                        if (i < tokens.Count)
                        {
                            s = GetQuantifierComment(tokens[i]);
                            if (s != null)
                            {
                                sb.Append(" ");
                                sb.Append(s);
                                i++;

                                if (i < tokens.Count)
                                {
                                    if (tokens[i] == SyntaxKind.Lazy)
                                    {
                                        sb.Append(" but as few times as possible");
                                        i++;
                                    }
                                }
                            }
                        }

                        sb.AppendLine();
                    }
                }
            }

            return sb.ToString();
        }

        private static string GetQuantifierComment(SyntaxKind token)
        {
            switch (token)
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
