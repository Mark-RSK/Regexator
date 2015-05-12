﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Builder
{
    internal class GeneralCategoryExpression
        : CharacterExpression
    {
        private readonly GeneralCategory _category;

        internal GeneralCategoryExpression(GeneralCategory category)
        {
            _category = category;
        }

        protected override CharGroupExpression ToGroup()
        {
            return new GeneralCategoryGroup(_category);
        }

        internal override string Value(BuildContext context)
        {
            return Syntax.GeneralCategory(_category);
        }

        public GeneralCategory Category
        {
            get { return _category; }
        }
    }
}
