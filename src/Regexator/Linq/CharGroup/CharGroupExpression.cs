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
            context.Write(Opening(context));
            
            //todo check empty
            BuildContent(context);

            context.Write(Closing(context));
        }

        internal override string Opening(PatternContext context)
        {
            return Negative 
                ? Syntax.NotCharGroupStart 
                : Syntax.CharGroupStart;
        }

        internal override string Closing(PatternContext context)
        {
            return Syntax.CharGroupEnd;
        }

        public virtual bool Negative
        {
            get { return false; }
        }
    }
}
