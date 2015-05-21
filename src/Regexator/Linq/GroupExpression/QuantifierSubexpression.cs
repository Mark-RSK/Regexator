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
            if (EncloseRequired)
            {
                return Syntax.SubexpressionStart;
            }
            else
            {
                return string.Empty;
            }
        }

        internal override string Closing(BuildContext context)
        {
            if (EncloseRequired)
            {
                return base.Closing(context);
            }
            else
            {
                return string.Empty;
            }
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
