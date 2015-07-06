// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a pattern that is quantified, i.e. the quantifier is applied on it. If required, pattern will be enclosed in the the (noncapturing) group. This class is abstract.
    /// </summary>
    public abstract partial class QuantifiedGroup
        : QuantifiedPattern
    {
        private readonly object _content;

        /// <summary>
        /// Initializes a new instance of the <see cref="QuantifiedGroup"/> class with a specified content.
        /// </summary>
        /// <param name="content">The content of the group.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected QuantifiedGroup(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content;
        }

        /// <summary>
        /// Appends a quantifier to a specified <see cref="PatternBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to use for appending the text.</param>
        protected abstract void AppendQuantifierTo(PatternBuilder builder);

        internal override void AppendTo(PatternBuilder builder)
        {
            bool addGroup = AddGroup;

            if (addGroup)
            {
                builder.AppendNoncapturingGroupStart();
            }

            builder.AppendGroupContent(Content);

            if (addGroup)
            {
                builder.AppendGroupEnd();
            }

            AppendQuantifierTo(builder);
        }

        private bool AddGroup
        {
            get
            {
                Pattern exp = Content as QuantifiablePattern;
                if (exp != null)
                {
                    return (exp.Previous != null);
                }
                else
                {
                    string s = Content as string;
                    if (s != null)
                    {
                        return s.Length > 1;
                    }
                    else
                    {
                        return !(Content is CharGrouping);
                    }
                }
            }
        }

        internal object Content
        {
            get { return _content; }
        }
    }
}
