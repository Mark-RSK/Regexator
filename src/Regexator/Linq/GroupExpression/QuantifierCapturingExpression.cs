// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class QuantifierCapturingExpression
        : GroupExpression
    {
        internal QuantifierCapturingExpression(string text)
            : base(text)
        {
        }

        internal QuantifierCapturingExpression(Expression expression)
            : base(expression)
        {
        }

        internal override string Opening(BuildContext context)
        {
            return (EncloseRequired)
                ? Syntax.CapturingGroupStart
                : string.Empty;
        }

        internal override string Closing(BuildContext context)
        {
            return (EncloseRequired)
                ? base.Closing(context)
                : string.Empty;
        }

        private bool EncloseRequired
        {
            get
            {
                return ChildExpression == null ||
                    !(ChildExpression is QuantifiableExpression) ||
                    ChildExpression.Previous != null;
            }
        }
    }
}
