// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal class GeneralCategoryCharItem
        : CharGroupItem
    {
        private readonly GeneralCategory _category;
        private readonly bool _negative;

        public GeneralCategoryCharItem(GeneralCategory category)
            : this(category, false)
        {
        }

        public GeneralCategoryCharItem(GeneralCategory category, bool negative)
        {
            _category = category;
            _negative = negative;
        }

        public virtual bool Negative
        {
            get { return _negative; }
        }

        protected override void WriteItemContentTo(PatternWriter writer)
        {
            writer.WriteGeneralCategory(_category, Negative);
        }
    }
}
