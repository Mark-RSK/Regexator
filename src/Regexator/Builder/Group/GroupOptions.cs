// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class GroupOptions
        : GroupExpression
    {
        private readonly InlineOptions _applyOptions;
        private readonly InlineOptions _disableOptions;

        internal GroupOptions(InlineOptions applyOptions, string value)
            : this(applyOptions, InlineOptions.None, value)
        {
        }

        internal GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, string value)
            : base(value)
        {
            _applyOptions = applyOptions;
            _disableOptions = disableOptions;
        }

        internal GroupOptions(InlineOptions applyOptions, Expression expression)
            : this(applyOptions, InlineOptions.None, expression)
        {
        }

        internal GroupOptions(InlineOptions applyOptions, InlineOptions disableOptions, Expression expression)
            : base(expression)
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
            return Syntax.GroupOptionsStart(ApplyOptions, DisableOptions);
        }
    }
}
