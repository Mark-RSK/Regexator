// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

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

        protected abstract IEnumerable<string> EnumerateCondition(BuildContext context);

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            foreach (var value in EnumerateCondition(context))
            {
                yield return value;
            }

            foreach (var value in Expression.GetValues(_trueContent, context))
            {
                yield return value;
            }

            if (_falseContent != null)
            {
                yield return Syntax.Or;
                foreach (var value in Expression.GetValues(_falseContent, context))
                {
                    yield return value;
                }
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
