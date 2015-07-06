// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// A pattern consisting of a base pattern that is surrounded with patterns interpreted as lookbehind and lookahead assertion, respectively. This class cannot be inherited.
    /// </summary>
    public sealed class SurroundAssertion
        : Pattern
    {
        private readonly object _content;
        private readonly object _contentBefore;
        private readonly object _contentAfter;

        internal SurroundAssertion(object contentBefore, object content, object contentAfter)
        {
            if (contentBefore == null)
            {
                throw new ArgumentNullException("contentBefore");
            }

            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            if (contentAfter == null)
            {
                throw new ArgumentNullException("contentAfter");
            }

            _contentBefore = contentBefore;
            _content = content;
            _contentAfter = contentAfter;
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendBackAssertion(_contentBefore);
            builder.Append(_content);
            builder.AppendAssertion(_contentAfter);
        }
    }
}
