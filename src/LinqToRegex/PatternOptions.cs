// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Provides enumerated values to use when creating a text representation of a pattern.
    /// </summary>
    [Flags]
    public enum PatternOptions
    {
        /// <summary>
        /// Specifies that no options are set.
        /// </summary>
        None = 0,

        /// <summary>
        /// Specifies that an if construct condition will be expressed as an assertion.
        /// </summary>
        ConditionWithAssertion = 1,

        /// <summary>
        /// Specifies that an empty (noncapturing) group will be added after the group number backreference.
        /// </summary>
        SeparateGroupNumberReference = 2,

        /// <summary>
        /// Specifies that a pattern text will be formatted.
        /// </summary>
        Format = 4,

        /// <summary>
        /// Specifies that a comment will be added to the end of each line. This options is relevant only in combination with <see cref="PatternOptions.Format"/> option.
        /// </summary>
        Comment = 8,

        /// <summary>
        /// Indicates that the <see cref="PatternOptions.Format"/> and <see cref="PatternOptions.Comment"/> options are used. This is a composite options.
        /// </summary>
        FormatAndComment = 12
    }
}
