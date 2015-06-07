// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class ContainerExpression
        : Expression
    {
        private readonly object _content;

        public ContainerExpression(object content)
        {
            _content = content;
        }

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            return Expression.EnumerateValues(_content, context);
        }
    }
}
