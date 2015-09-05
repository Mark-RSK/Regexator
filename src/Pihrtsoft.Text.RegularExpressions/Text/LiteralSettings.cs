// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions
{
    /// <summary>
    /// Specifies a set of features to support on the <see cref="LiteralConverter"/> object. This class cannot be inherited.
    /// </summary>
    public sealed class LiteralSettings
    {
        private string _concatOperator;

        /// <summary>
        /// Initializes a new instance of the <see cref="LiteralSettings"/> class.
        /// </summary>
        public LiteralSettings()
        {
            _concatOperator = "+";
        }

        public bool HasOptions(LiteralOptions options) => (Options & options) == options;

        /// <summary>
        /// Gets or sets a text that is used to create new line.
        /// </summary>
        public NewLineKind NewLineLiteral { get; set; }

        /// <summary>
        /// Gets the options of this instance.
        /// </summary>
        public LiteralOptions Options { get; set; }

        /// <summary>
        /// Gets or sets a concatenating operator.
        /// </summary>
        public string ConcatOperator
        {
            get { return _concatOperator; }
            set { _concatOperator = value ?? string.Empty; }
        }
    }
}
