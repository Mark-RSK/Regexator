// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class QuantifierCapturingExpression
        : GroupExpression
    {
        public QuantifierCapturingExpression(object content)
            : base(content)
        {
        }

        internal override string Opening(BuildContext context)
        {
            return (AddCapturingGroup)
                ? Syntax.CapturingGroupStart
                : string.Empty;
        }

        internal override string Closing(BuildContext context)
        {
            return (AddCapturingGroup)
                ? base.Closing(context)
                : string.Empty;
        }

        private bool AddCapturingGroup
        {
            get
            {
                Expression exp = Content as Expression;
                return exp == null 
                    || !(exp is QuantifiableExpression) 
                    || exp.Previous != null;
            }
        }
    }
}
