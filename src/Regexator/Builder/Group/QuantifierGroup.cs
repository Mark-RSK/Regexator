// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class QuantifierGroup
        : GroupingConstruct
    {
        internal QuantifierGroup(string value)
            : base(value)
        {
        }

        internal QuantifierGroup(Expression expression)
            : base(expression)
        {
        }

        internal override string Opening(BuildContext context)
        {
            return context.Settings.NoncapturingQuantifierGroup ? Syntax.NoncapturingGroupStart : Syntax.SubexpressionStart;
        }
    }
}
