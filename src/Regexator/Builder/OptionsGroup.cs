// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class OptionsGroup
        : GroupingConstruct
    {
        private readonly InlineOptions _applyOptions;
        private readonly InlineOptions _disableOptions;

        internal OptionsGroup(InlineOptions applyOptions, string value)
            : this(applyOptions, InlineOptions.None, value)
        {
        }

        internal OptionsGroup(InlineOptions applyOptions, InlineOptions disableOptions, string value)
            : base(value)
        {
            _applyOptions = applyOptions;
            _disableOptions = disableOptions;
        }

        internal OptionsGroup(InlineOptions applyOptions, Expression childExpression)
            : this(applyOptions, InlineOptions.None, childExpression)
        {
        }

        internal OptionsGroup(InlineOptions applyOptions, InlineOptions disableOptions, Expression childExpression)
            : base(childExpression)
        {
            _applyOptions = applyOptions;
            _disableOptions = disableOptions;
        }

        public InlineOptions ApplyOptions
        {
            get { return _applyOptions; }
        }

        public InlineOptions DisableOptions
        {
            get { return _disableOptions; }
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.OptionsGroupStart(ApplyOptions, DisableOptions);
        }
    }
}
