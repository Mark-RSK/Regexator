// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal abstract class AlternationExpression
        : QuantifiableExpression
    {
        private readonly object _yes;
        private readonly object _no;

        protected AlternationExpression(object yes, object no)
            : base()
        {
            if (yes == null)
            {
                throw new ArgumentNullException("yes");
            }

            _yes = yes;
            _no = no;
        }

        protected abstract IEnumerable<string> EnumerateCondition(BuildContext context);

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            foreach (var value in EnumerateCondition(context))
            {
                yield return value;
            }
            foreach (var value in Expression.EnumerateValues(_yes, context))
            {
                yield return value;
            }
            if (_no != null)
            {
                yield return Syntax.Or;
                foreach (var value in Expression.EnumerateValues(_no, context))
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

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.If; }
        }
    }
}