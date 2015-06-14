// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class GeneralCategoryGroup
        : CharGroupExpression
    {
        private readonly GeneralCategory _value;

        public GeneralCategoryGroup(GeneralCategory value)
        {
            _value = value;
        }

        internal override void BuildContent(PatternContext context)
        {
            context.Write(Syntax.GeneralCategory(_value));
        }
    }
}
