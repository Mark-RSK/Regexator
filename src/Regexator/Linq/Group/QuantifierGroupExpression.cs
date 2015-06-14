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

        internal override void BuildOpening(PatternWriter writer)
        {
            writer.Write(AddGroup
                ? Syntax.NoncapturingGroupStart
                : string.Empty);
        }

        internal override void BuildClosing(PatternWriter writer)
        {
            if (AddGroup)
            {
                base.BuildClosing(writer);
            }
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
