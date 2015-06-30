// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

//TODO add xml comments

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Specifies a set of features to support on the <see cref="PatternBuilder"/> object. This class cannot be inherited.
    /// </summary>
    public sealed class PatternSettings
        : ICloneable
    {
        private readonly PatternOptions _options;
        private readonly IdentifierBoundary _boundary;

        /// <summary>
        /// Initializes a new instance of the <see cref="PatternSettings"/> class.
        /// </summary>
        public PatternSettings()
            : this(PatternOptions.None)
        {
        }

        public PatternSettings(PatternOptions options)
            : this(options, IdentifierBoundary.AngleBrackets)
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
