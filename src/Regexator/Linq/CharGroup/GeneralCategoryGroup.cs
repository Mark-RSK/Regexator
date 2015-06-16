// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class GeneralCategoryGroup
        : CharGroupExpression
    {
        private readonly GeneralCategory _category;

        public GeneralCategoryGroup(GeneralCategory category)
        {
            _category = category;
        }

        protected override void WriteContentTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteGeneralCategory(_category, Negative);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteCharGroup(_category, Negative);
        }
    }
}
