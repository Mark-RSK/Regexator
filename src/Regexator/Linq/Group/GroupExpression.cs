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
                writer.Write(RegexUtilities.Escape(text));
            }
            else
            {
                object[] values = Content as object[];
                if (values != null)
                {
                    if (values.Length > 0)
                    {
                        Expression.Build(values[0], writer);

                        for (int i = 1; i < values.Length; i++)
                        {
                            writer.Write(Syntax.Or);
                            Expression.Build(values[i], writer);
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
                            Expression.Build(en.Current, writer);

                            while (en.MoveNext())
                            {
                                writer.Write(Syntax.Or);
                                Expression.Build(en.Current, writer);
                            }
                        }
                    }
                    else
                    {
                        Expression.Build(Content, writer);
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
