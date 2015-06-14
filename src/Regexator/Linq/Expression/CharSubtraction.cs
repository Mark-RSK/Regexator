// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public class CharSubtraction
        : QuantifiableExpression, IExcludedGroup
    {
        private readonly IBaseGroup _baseGroup;
        private readonly IExcludedGroup _excludedGroup;

        internal CharSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            if (baseGroup == null)
            {
                throw new ArgumentNullException("baseGroup");
            }

            if (excludedGroup == null)
            {
                throw new ArgumentNullException("excludedGroup");
            }

            _baseGroup = baseGroup;
            _excludedGroup = excludedGroup;
        }

        public void BuildExcludedGroup(PatternContext context)
        {
            BuildOpening(context);

            BuildContent(context);
            
            BuildClosing(context);
        }

        internal override void BuildContent(PatternContext context)
        {
            //todo check empty
            _baseGroup.BuildBaseGroup(context);

            context.Write("-");

            //todo check empty
            _excludedGroup.BuildExcludedGroup(context);
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
