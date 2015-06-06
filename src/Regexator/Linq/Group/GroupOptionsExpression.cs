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

        internal override string Opening(BuildContext context)
        {
            string options = Syntax.GetInlineChars(_applyOptions, _disableOptions);

            return (!string.IsNullOrEmpty(options))
                ? "(?" + options + ":"
                : Syntax.NoncapturingGroupStart;
        }
    }
}
