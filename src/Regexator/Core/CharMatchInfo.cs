// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions
{
    public class CharMatchInfo
    {
        private readonly string _pattern;
        private readonly string _comment;

        internal CharMatchInfo(string pattern)
            : this(pattern, string.Empty)
        {
        }

        internal CharMatchInfo(string pattern, string comment)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }
            if (comment == null)
            {
                throw new ArgumentNullException("comment");
            }
            _pattern = pattern;
            _comment = comment;
        }

        public string Pattern
        {
            get { return _pattern; }
        }

        public string Comment
        {
            get { return _comment; }
        }
    }
}
