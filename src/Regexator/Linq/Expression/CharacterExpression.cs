// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class CharacterExpression
        : QuantifiableExpression, IExcludedGroup
    {
        internal CharacterExpression()
        {
        }

        public abstract CharGroupExpression ToGroup();

        public CharSubtraction Except(IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(ToGroup(), excludedGroup);
        }

        public void BuildExcludedGroup(PatternContext context)
        {
            context.Write(Syntax.CharGroupStart);

            BuildContent(context);
            
            context.Write(Syntax.CharGroupEnd);
        }
    }
}
