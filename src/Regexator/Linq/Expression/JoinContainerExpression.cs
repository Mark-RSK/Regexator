// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class JoinContainerExpression
        : Expression
    {
        private readonly object _separator;
        private readonly object _values;

        public JoinContainerExpression(object separator, object values)
        {
            if (values == null)
            {
                throw new ArgumentNullException("values");
            }

            _separator = separator;
            _values = values;
        }

        internal override void BuildContent(BuildContext context)
        {
            var values = _values as object[];
            if (values != null)
            {
                if (values.Length > 0)
                {
                    Expression.BuildContent(values[0], context);

                    if (values.Length > 1)
                    {
                        string separator = GetValue(_separator, context);

                        for (int i = 1; i < values.Length; i++)
                        {
                            context.Write(separator);
                            Expression.BuildContent(values[i], context);
                        }
                    }
                }
            }
            else
            {
                var items = _values as IEnumerable<object>;
                using (IEnumerator<object> en = items.GetEnumerator())
                {
                    if (en.MoveNext())
                    {
                        Expression.BuildContent(en.Current, context);

                        if (en.MoveNext())
                        {
                            string separator = GetValue(_separator, context);

                            context.Write(separator);
                            Expression.BuildContent(en.Current, context);

                            while (en.MoveNext())
                            {
                                context.Write(separator);
                                Expression.BuildContent(en.Current, context);
                            }
                        }
                    }
                }
            }
        }
    }
}
