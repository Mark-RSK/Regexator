// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Text.RegularExpressions;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class GroupOptions
        : GroupingPattern
    {
        private readonly RegexOptions _applyOptions;
        private readonly RegexOptions _disableOptions;

        public GroupOptions(RegexOptions applyOptions, object content)
            : this(applyOptions, RegexOptions.None, content)
        {
        }

        public GroupOptions(RegexOptions applyOptions, RegexOptions disableOptions, object content)
            : base(content)
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

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendOptions(_applyOptions, _disableOptions, Content);
        }
    }
}
