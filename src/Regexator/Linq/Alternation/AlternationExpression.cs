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

        protected abstract void ProcessCondition(BuildContext context);

        internal override void BuildContent(BuildContext context)
        {
            ProcessCondition(context);

            Expression.BuildContent(_trueContent, context);

            if (_falseContent != null)
            {
                context.Write(Syntax.Or);

                Expression.BuildContent(_falseContent, context);
            }
        }

        internal override string Opening(BuildContext context)
        {
            return Syntax.IfStart;
        }

        internal override string Closing(BuildContext context)
        {
            return Syntax.GroupEnd;
        }
    }
}
