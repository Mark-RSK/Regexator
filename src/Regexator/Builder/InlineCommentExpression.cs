// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class InlineCommentExpression
        : Expression
    {
        private readonly string _value;
        private static Regex s_trimCommentRegex;

        internal InlineCommentExpression(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            _value = value;
        }

        private static Regex TrimCommentRegex
        {
            get
            {
                if (s_trimCommentRegex == null)
                {
                    s_trimCommentRegex = Expressions.Start().NotRightParenthesis().MaybeMany().ToRegex();
                }
                return s_trimCommentRegex;
            }
        }

        private static string TrimInlineComment(string value)
        {
            return TrimCommentRegex.Match(value).Value;
        }

        internal override string Value
        {
            get { return Syntax.InlineComment(TrimInlineComment(_value)); }
        }
    }
}
