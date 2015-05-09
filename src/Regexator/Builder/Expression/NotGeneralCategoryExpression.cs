// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class NotGeneralCategoryExpression
        : GeneralCategoryExpression
    {
        internal NotGeneralCategoryExpression(GeneralCategory category)
            : base(category)
        {
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.UnicodeCategory(Category, true);
        }
    }
}
