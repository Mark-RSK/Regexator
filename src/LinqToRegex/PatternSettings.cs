// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Specifies a set of features to support on the <see cref="PatternBuilder"/> object. This class cannot be inherited.
    /// </summary>
    public sealed class PatternSettings
    {
        private int _indentSize;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatternSettings"/> class.
        /// </summary>
        public PatternSettings()
            : this(PatternOptions.None)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatternSettings"/> class with a specified options.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values.</param>
        public PatternSettings(PatternOptions options)
        {
            Options = options;
            IdentifierBoundary = IdentifierBoundary.AngleBrackets;
            IndentSize = 4;
        }

        /// <summary>
        /// Determines whether specified options are set in the options of the current instance.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values.</param>
        /// <returns></returns>
        public bool HasOptions(PatternOptions options) => (Options & options) == options;

        /// <summary>
        /// Get the options of this instance.
        /// </summary>
        public PatternOptions Options { get; set; }

        /// <summary>
        /// Get a value indicating whether a group name will be enclosed in angle brackets or apostrophes.
        /// </summary>
        public IdentifierBoundary IdentifierBoundary { get; set; }

        /// <summary>
        /// Gets or sets the number of spaces in an indent.
        /// </summary>
        public int IndentSize
        {
            get { return _indentSize; }
            set { _indentSize = Math.Max(value, 1); }
        }
    }
}
