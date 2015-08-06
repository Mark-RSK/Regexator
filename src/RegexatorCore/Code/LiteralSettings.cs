// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions
{
    /// <summary>
    /// Specifies a set of features to support on the <see cref="LiteralBuilder"/> object. This class cannot be inherited.
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

        /// <summary>
        /// Gets or sets a text that is used to create new line.
        /// </summary>
        public NewLineLiteral NewLineLiteral { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a new line literal is at the end or at the beginning of line.
        /// </summary>
        public bool ConcatAtBeginningOfLine { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a literal is verbatim. This value is relevant for a C# only.
        /// </summary>
        public bool Verbatim { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether a literal is multiline.
        /// </summary>
        public bool Multiline { get; set; }

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
