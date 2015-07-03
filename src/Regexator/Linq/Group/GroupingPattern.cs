// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a base class for all kind of grouping constructs including assertions. This class is abstract.
    /// </summary>
    public abstract class GroupingPattern
        : QuantifiablePattern
    {
        private readonly object _content;

        protected GroupingPattern()
        {
        }

        protected GroupingPattern(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content;
        }

        protected GroupingPattern(GroupingPattern group)
        {
            if (group == null)
            {
                throw new ArgumentNullException("group");
            }

            _content = group.Content;
        }

        internal object Content
        {
            get { return _content; }
        }
    }
}
