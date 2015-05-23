﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class InlineOptionsExpression
        : Expression
    {
        private readonly InlineOptions _applyOptions;
        private readonly InlineOptions _disableOptions;

        internal InlineOptionsExpression(InlineOptions applyOptions)
            : this(applyOptions, InlineOptions.None)
        {
        }

        internal InlineOptionsExpression(InlineOptions applyOptions, InlineOptions disableOptions)
        {
            _applyOptions = applyOptions;
            _disableOptions = disableOptions;
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.Options(_applyOptions, _disableOptions);
        }
    }
}
