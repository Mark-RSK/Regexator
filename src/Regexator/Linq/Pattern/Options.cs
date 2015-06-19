﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class Options
        : Pattern
    {
        private readonly InlineOptions _applyOptions;
        private readonly InlineOptions _disableOptions;

        internal Options(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            _applyOptions = applyOptions;
            _disableOptions = disableOptions;
        }

        public static Pattern Apply(InlineOptions options)
        {
            return new Options(options, InlineOptions.None);
        }

        public static Pattern Disable(InlineOptions options)
        {
            return new Options(InlineOptions.None, options);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteOptions(_applyOptions, _disableOptions);
        }
    }
}