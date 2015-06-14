// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class CharGroupExpression
        : QuantifiableExpression, IBaseGroup, IExcludedGroup
    {
        protected CharGroupExpression()
        {
        }

        public CharSubtraction Except(IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(this, excludedGroup);
        }

        public void BuildBaseGroup(PatternWriter writer)
        {
            BuildContent(writer);
        }

        public void BuildExcludedGroup(PatternWriter writer)
        {
            BuildOpening(writer);

            //todo check empty
            BuildContent(writer);

            BuildClosing(writer);
        }

        internal override void BuildOpening(PatternWriter writer)
        {
            writer.WriteCharGroupStart(Negative);
        }

        internal override void BuildClosing(PatternWriter writer)
        {
            writer.WriteCharGroupEnd();
        }

        public virtual bool Negative
        {
            get { return false; }
        }
    }
}
