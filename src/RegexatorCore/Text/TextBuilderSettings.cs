// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions
{
    public class TextBuilderSettings
    {
        private string _concatOperator;

        public TextBuilderSettings()
        {
            _concatOperator = "+";
        }

        public NewLineLiteral NewLineLiteral { get; set; }
        public bool ConcatAtBeginningOfLine { get; set; }
        public bool Verbatim { get; set; }
        public bool Singleline { get; set; }

        public string ConcatOperator
        {
            get { return _concatOperator; }
            set { _concatOperator = value ?? string.Empty; }
        }
    }
}
