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

        public void BuildBaseGroup(PatternContext context)
        {
            BuildContent(context);
        }

        public void BuildExcludedGroup(PatternContext context)
        {
            BuildOpening(context);
            
            //todo check empty
            BuildContent(context);

            BuildClosing(context);
        }

        internal override void BuildOpening(PatternContext context)
        {
            context.Write(Negative
                ? Syntax.NotCharGroupStart
                : Syntax.CharGroupStart);
        }

        internal override void BuildClosing(PatternContext context)
        {
            context.Write(Syntax.CharGroupEnd);
        }

        public virtual bool Negative
        {
            get { return false; }
        }
    }
}
