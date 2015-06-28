// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class Options
        : Pattern
    {
        private readonly RegexOptions _applyOptions;
        private readonly RegexOptions _disableOptions;

        public Options(RegexOptions applyOptions)
            : this(applyOptions, RegexOptions.None)
        {
        }

        public Options(RegexOptions applyOptions, RegexOptions disableOptions)
        {
            if (!RegexUtilities.IsValidInlineOptions(applyOptions))
            {
                throw new ArgumentNullException("applyOptions");
            }

            if (!RegexUtilities.IsValidInlineOptions(disableOptions))
            {
                throw new ArgumentNullException("disableOptions");
            }

            _applyOptions = applyOptions;
            _disableOptions = disableOptions;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteOptions(_applyOptions, _disableOptions);
        }
    }
}
