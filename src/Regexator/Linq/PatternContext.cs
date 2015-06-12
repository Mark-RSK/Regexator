// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class PatternContext
        : StringWriter
    {
#if DEBUG
        private readonly HashSet<Expression> _expressions;
#endif
        private PatternSettings _settings;

        public PatternContext()
            : this(new PatternSettings())
        {
        }

        public PatternContext(PatternSettings settings)
            : base()
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            _settings = settings;
#if DEBUG
            _expressions = new HashSet<Expression>();
#endif
        }

        public override void Write(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                base.Write(value);
            }
        }

#if DEBUG
        public HashSet<Expression> Expressions
        {
            get { return _expressions; }
        }
#endif

        public PatternSettings Settings
        {
            get { return _settings; }
        }
    }
}