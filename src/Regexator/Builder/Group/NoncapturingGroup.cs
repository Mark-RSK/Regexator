// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NoncapturingGroup
        : GroupingConstruct
    {
        internal NoncapturingGroup(string value)
            : base(value)
        {
        }

        internal NoncapturingGroup(Expression expression)
            : base(expression)
        {
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.NoncapturingGroupStart;
        }
    }
}
