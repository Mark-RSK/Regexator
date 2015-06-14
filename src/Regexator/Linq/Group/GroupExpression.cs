// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal abstract class GroupExpression
        : QuantifiableExpression
    {
        private readonly object _content;

        public GroupExpression()
            : base()
        {
        }

        public GroupExpression(object content)
            : base()
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content;
        }

        internal override void BuildContent(PatternWriter writer)
        {
            string text = Content as string;
            if (text != null)
            {
                writer.Write(text);
            }
            else
            {
                object[] values = Content as object[];
                if (values != null)
                {
                    if (values.Length > 0)
                    {
                        writer.Write(values[0]);

                        for (int i = 1; i < values.Length; i++)
                        {
                            writer.WriteOr();
                            writer.Write(values[i]);
                        }
                    }
                }
                else
                {
                    IEnumerable items = Content as IEnumerable;
                    if (items != null)
                    {
                        IEnumerator en = items.GetEnumerator();

                        if (en.MoveNext())
                        {
                            writer.Write(en.Current);

                            while (en.MoveNext())
                            {
                                writer.WriteOr();
                                writer.Write(en.Current);
                            }
                        }
                    }
                    else
                    {
                        writer.Write(Content);
                    }
                }
            }
        }

        internal object Content
        {
            get { return _content; }
        }

        internal override void BuildOpening(PatternWriter writer)
        {
            writer.WriteGroupEnd();
        }
    }
}
