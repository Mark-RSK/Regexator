// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal abstract class AlternationExpression
        : QuantifiableExpression
    {
        private readonly object _trueContent;
        private readonly object _falseContent;

        protected AlternationExpression(object trueContent, object falseContent)
            : base()
        {
            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            _trueContent = trueContent;
            _falseContent = falseContent;
        }

        protected abstract void BuildCondition(PatternContext context);

        internal override void BuildContent(PatternContext context)
        {
            BuildCondition(context);

            Expression.Build(_trueContent, context);

            if (_falseContent != null)
            {
                context.Write(Syntax.Or);

                Expression.Build(_falseContent, context);
            }
        }

        internal override void BuildOpening(PatternContext context)
        {
            context.Write(Syntax.IfStart);
        }

        internal override void BuildClosing(PatternContext context)
        {
            context.WriteGroupEnd();
        }
    }
}
