﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class Options
        : Pattern
    {
        private readonly InlineOptions _applyOptions;
        private readonly InlineOptions _disableOptions;

        public Options(InlineOptions applyOptions)
            : this(applyOptions, InlineOptions.None)
        {
        }

        public Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            _applyOptions = applyOptions;
            _disableOptions = disableOptions;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteOptions(_applyOptions, _disableOptions);
        }
    }
}
