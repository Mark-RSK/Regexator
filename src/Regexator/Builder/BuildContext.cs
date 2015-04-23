// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace Pihrtsoft.Regexator.Builder
{
    internal class BuildContext
        : IDisposable
    {
        private readonly HashSet<Expression> _expressions;
        private readonly TextWriter _writer;
        private BuildSettings _settings;
        private bool _disposed;

        public BuildContext()
            : this(new StringWriter(CultureInfo.CurrentCulture))
        {
        }

        public BuildContext(TextWriter writer)
        {
            if (writer == null) { throw new ArgumentNullException("writer"); }
            _writer = writer;
            _expressions = new HashSet<Expression>();
            _settings = new BuildSettings();
        }

        public override string ToString()
        {
            return _writer.ToString();
        }

        public void Write(string value)
        {
            _writer.Write(value);
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

        public HashSet<Expression> Expressions
        {
            get { return _expressions; }
        }

        public BuildSettings Settings
        {
            get { return _settings; }
            set
            {
                if (value == null) { throw new ArgumentNullException("value"); }
                _settings = value;
            }
        }
    }
}