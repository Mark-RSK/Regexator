// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Specifies a set of features to support on the <see cref="PatternBuilder"/> object. This class cannot be inherited.
    /// </summary>
    public sealed class PatternSettings
    {
        private readonly PatternOptions _options;
        private readonly IdentifierBoundary _boundary;
        private static readonly PatternOptions _defaultOptions = PatternOptions.IfConditionAsAssertion | PatternOptions.SeparateGroupNumberReference;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatternSettings"/> class.
        /// </summary>
        public PatternSettings()
            : this(_defaultOptions)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatternSettings"/> class with a specified options.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values.</param>
        public PatternSettings(PatternOptions options)
            : this(options, IdentifierBoundary.AngleBrackets)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatternSettings"/> class with a specified identifier boundary.
        /// </summary>
        /// <param name="boundary">Indicates whether a group name will be enclosed in angle brackets or apostrophes.</param>
        public PatternSettings(IdentifierBoundary boundary)
            : this(_defaultOptions, boundary)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PatternSettings"/> class with a specified options and an identifier boundary.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values.</param>
        /// <param name="boundary">Indicates whether a group name will be enclosed in angle brackets or apostrophes.</param>
        public PatternSettings(PatternOptions options, IdentifierBoundary boundary)
        {
            _options = options;
            _boundary = boundary;
        }

        /// <summary>
        /// Determines whether specified options are set in the options of the current instance.
        /// </summary>
        /// <param name="options">A bitwise combination of the enumeration values.</param>
        /// <returns></returns>
        public bool HasOptions(PatternOptions options)
        {
            return (Options & options) == options;
        }

        /// <summary>
        /// Get the options of this instance.
        /// </summary>
        public PatternOptions Options
        {
            get { return _options; }
        }

        /// <summary>
        /// Get a value indicating whether a group name will be enclosed in angle brackets or apostrophes.
        /// </summary>
        public IdentifierBoundary IdentifierBoundary
        {
            get { return _boundary; }
        }
    }
}
