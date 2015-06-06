// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class GroupOptionsExpression
        : GroupExpression
    {
        private readonly InlineOptions _applyOptions;
        private readonly InlineOptions _disableOptions;

        public GroupOptionsExpression(InlineOptions applyOptions, object content)
            : this(applyOptions, InlineOptions.None, content)
        {
        }

        public GroupOptionsExpression(InlineOptions applyOptions, InlineOptions disableOptions, object content)
            : base(content)
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

        internal override string Closing(BuildContext context)
        {
            return (ApplyOptions != InlineOptions.None || DisableOptions != InlineOptions.None)
                ? base.Closing(context)
                : string.Empty;
        }
    }
}
