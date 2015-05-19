// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Regexator.Linq
{
    internal sealed class InlineCommentExpression
        : Expression
    {
        private readonly string _comment;
        private static readonly Lazy<Regex> s_trimCommentRegex = new Lazy<Regex>(() => Anchors.Start().NotRightParenthesis().MaybeMany().ToRegex());

        internal InlineCommentExpression(string comment)
        {
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }
            _comment = comment;
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.InlineComment(s_trimCommentRegex.Value.Match(_comment).Value);
        }
    }
}
