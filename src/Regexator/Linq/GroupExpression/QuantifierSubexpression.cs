// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Linq
{
    internal sealed class QuantifierSubexpression
        : GroupExpression
    {
        internal QuantifierSubexpression(string text)
            : base(text)
        {
        }

        internal QuantifierSubexpression(Expression expression)
            : base(expression)
        {
        }

        internal override string Opening(BuildContext context)
        {
            return (EncloseRequired)
                ? Syntax.SubexpressionStart
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
