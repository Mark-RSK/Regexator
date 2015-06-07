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

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            string separator = GetValue(_separator, context);

            var values = _values as object[];
            if (values != null)
            {
                foreach (var value in GetValues(separator, values, context))
                {
                    yield return value;
                }
            }
            else
            {
                var items = _values as IEnumerable<object>;
                foreach (var value in GetValues(separator, items, context))
                {
                    yield return value;
                }
            }
        }

        private static IEnumerable<string> GetValues(string separator, object[] values, BuildContext context)
        {
            if (values.Length == 0)
            {
                yield break;
            }

            foreach (var value in Expression.GetValues(values[0], context))
            {
                yield return value;
            }

            for (int i = 1; i < values.Length; i++)
            {
                yield return separator;

                foreach (var value in Expression.GetValues(values[i], context))
                {
                    yield return value;
                }
            }
        }

        private static IEnumerable<string> GetValues(string separator, IEnumerable<object> values, BuildContext context)
        {
            using (IEnumerator<object> en = values.GetEnumerator())
            {
                if (!en.MoveNext())
                {
                    yield break;
                }

                foreach (var value in Expression.GetValues(en.Current, context))
                {
                    yield return value;
                }

                while (en.MoveNext())
                {
                    yield return separator;

                    foreach (var value in Expression.GetValues(en.Current, context))
                    {
                        yield return value;
                    }
                }
            }
        }
    }
}
