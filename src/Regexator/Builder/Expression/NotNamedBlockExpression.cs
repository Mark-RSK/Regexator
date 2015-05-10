﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NotNamedBlockExpression
        : NamedBlockExpression
    {
        internal NotNamedBlockExpression(NamedBlock block)
            : base(block)
        {
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.NamedBlock(Block, true);
        }
    }
}