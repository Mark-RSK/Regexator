// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// A pattern consisting of a base pattern that is surrounded with patterns interpreted as lookbehind and lookahead assertion, respectively. This class cannot be inherited.
    /// </summary>
    public sealed class SurroundAssertion
        : Pattern, IInvertible<NegativeSurroundAssertion>
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

        /// <summary>
        /// Returns an instance of the <see cref="NegativeSurroundAssertion"/> class.
        /// </summary>
        /// <returns></returns>
        public NegativeSurroundAssertion Invert()
        {
            return new NegativeSurroundAssertion(_contentBefore, _content, _contentAfter);
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendAssertBack(_contentBefore);
            builder.Append(_content);
            builder.AppendAssert(_contentAfter);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static NegativeSurroundAssertion operator !(SurroundAssertion value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }
    }
}
