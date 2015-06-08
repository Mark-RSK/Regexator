// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class BuildContext
        : IDisposable
    {
#if DEBUG
        private readonly HashSet<Expression> _expressions;
#endif
        private readonly TextWriter _writer;
        private PatternSettings _settings;
        private bool _disposed;

        public BuildContext()
            : this(new PatternSettings())
        {
        }

        public BuildContext(PatternSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException("settings");
            }

            _settings = settings;
            _writer = new StringWriter(CultureInfo.CurrentCulture);
#if DEBUG
            _expressions = new HashSet<Expression>();
#endif
        }

        public override string ToString()
        {
            return _writer.ToString();
        }

        public void Write(string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                _writer.Write(value);
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _writer.Dispose();
                }
                _disposed = true;
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
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                _settings = value;
            }
        }
    }
}