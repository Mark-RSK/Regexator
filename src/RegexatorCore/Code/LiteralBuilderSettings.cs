// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions
{
    public class LiteralBuilderSettings
    {
        private string _concatOperator;

        public LiteralBuilderSettings()
        {
            _concatOperator = "+";
        }

        public NewLineMode NewLineLiteral { get; set; }
        public bool ConcatAtBeginningOfLine { get; set; }
        public bool Verbatim { get; set; }
        public bool Multiline { get; set; }

        public string ConcatOperator
        {
            get { return _concatOperator; }
            set { _concatOperator = value ?? string.Empty; }
        }
    }
}
