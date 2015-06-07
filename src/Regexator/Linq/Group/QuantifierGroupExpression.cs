// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class QuantifierGroupExpression
        : GroupExpression
    {
        public QuantifierGroupExpression(object content)
            : base(content)
        {
        }

        internal override string Opening(BuildContext context)
        {
            return AddGroup
                ? Syntax.NoncapturingGroupStart
                : string.Empty;
        }

        internal override string Closing(BuildContext context)
        {
            return AddGroup
                ? base.Closing(context)
                : string.Empty;
        }

        private bool AddGroup
        {
            get
            {
                Expression exp = Content as QuantifiableExpression;
                if (exp != null)
                {
                    return (exp.Previous != null);
                }
                else
                {
                    return !(Content is CharGroupItem);
                }
            }
        }
    }
}
