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

        internal override void WriteContentTo(PatternWriter writer)
        {
            var values = _values as object[];
            if (values != null)
            {
                if (values.Length > 0)
                {
                    writer.Write(values[0]);

                    if (values.Length > 1)
                    {
                        string separator = GetPattern(_separator, writer.Settings);

                        for (int i = 1; i < values.Length; i++)
                        {
                            writer.WriteInternal(separator);
                            writer.Write(values[i]);
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
                        writer.Write(en.Current);

                        if (en.MoveNext())
                        {
                            string separator = GetPattern(_separator, writer.Settings);

                            writer.WriteInternal(separator);
                            writer.Write(en.Current);

                            while (en.MoveNext())
                            {
                                writer.WriteInternal(separator);
                                writer.Write(en.Current);
                            }
                        }
                    }
                }
            }
        }
    }
}
