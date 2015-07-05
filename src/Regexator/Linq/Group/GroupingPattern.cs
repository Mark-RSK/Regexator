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

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupingPattern"/> class.
        /// </summary>
        protected GroupingPattern()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupingPattern"/> class with a specified content.
        /// </summary>
        /// <param name="content">A content of the grouping.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected GroupingPattern(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GroupingPattern"/> class with a specified content.
        /// </summary>
        /// <param name="content">A content of the grouping.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected GroupingPattern(GroupingPattern content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content.Content;
        }

        internal object Content
        {
            get { return _content; }
        }
    }
}
