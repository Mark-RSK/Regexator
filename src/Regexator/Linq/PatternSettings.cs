// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public class PatternSettings
        : ICloneable
    {
        private readonly PatternOptions _options;
        private readonly IdentifierBoundary _boundary;

        public PatternSettings()
            : this(PatternOptions.None)
        {
        }

        public PatternSettings(PatternOptions options)
            : this(options, IdentifierBoundary.LessThan)
        {
        }

        public PatternSettings(IdentifierBoundary boundary)
            : this(PatternOptions.None, boundary)
        {
        }

        public PatternSettings(PatternOptions options, IdentifierBoundary boundary)
        {
            _options = options;
            _boundary = boundary;
        }

        public bool HasOptions(PatternOptions options)
        {
            return (Options & options) == options;
        }

        public object Clone()
        {
            return new PatternSettings(Options, IdentifierBoundary);
        }

        public PatternOptions Options
        {
            get { return _options; }
        }

        public IdentifierBoundary IdentifierBoundary
        {
            get { return _boundary; }
        }
    }
}
