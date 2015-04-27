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
        private static readonly Lazy<Regex> s_trimCommentRegex = new Lazy<Regex>(() => Anchor.Start().NotRightParenthesis().MaybeMany().ToRegex());

        internal InlineCommentExpression(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            _value = value;
        }

        internal override string Value
        {
            get { return Syntax.InlineComment(s_trimCommentRegex.Value.Match(_value).Value); }
        }
    }
}
