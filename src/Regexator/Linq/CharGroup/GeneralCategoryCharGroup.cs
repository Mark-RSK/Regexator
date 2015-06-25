// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class GeneralCategoryCharGroup
        : CharGroup
    {
        private readonly GeneralCategory _category;
        private readonly bool _negative;

        public GeneralCategoryCharGroup(GeneralCategory category, bool negative)
        {
            _category = category;
            _negative = negative;
        }

        internal override void WriteContentTo(PatternWriter writer)
        {
            writer.WriteGeneralCategory(_category, Negative);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteCharGroup(_category, Negative);
        }

        public override bool Negative
        {
            get { return _negative; }
        }
        
    }
}
