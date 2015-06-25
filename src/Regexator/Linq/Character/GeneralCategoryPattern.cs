// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class GeneralCategoryPattern
        : CharacterPattern
    {
        private readonly GeneralCategory _category;

        internal GeneralCategoryPattern(GeneralCategory category)
        {
            _category = category;
        }

        public override CharGroup Invert()
        {
            return new GeneralCategoryCharGroup(_category, true);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteGeneralCategory(_category);
        }

        public GeneralCategory Category
        {
            get { return _category; }
        }
    }
}
