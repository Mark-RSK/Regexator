// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Collections;
using System.Collections.Generic;

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

        internal override IEnumerable<string> EnumerateContent(BuildContext context)
        {
            object[] values = Content as object[];
            if (values != null)
            {
                foreach (var value in EnumerateContent(values, context))
                {
                    yield return value;
                }
            }
            else
            {
                IEnumerable items = Content as IEnumerable;
                if (items != null)
                {
                    foreach (var value in EnumerateContent(items, context))
                    {
                        yield return value;
                    }
                }
                else
                {
                    foreach (var value in Expression.EnumerateValues(_content, context))
                    {
                        yield return value;
                    }
                }
            }
        }

        private static IEnumerable<string> EnumerateContent(object[] content, BuildContext context)
        {
            if (content.Length > 0)
            {
                foreach (var value in Expression.EnumerateValues(content[0], context))
                {
                    yield return value;
                }

                for (int i = 1; i < content.Length; i++)
                {
                    yield return Syntax.Or;

                    foreach (var value in Expression.EnumerateValues(content[i], context))
                    {
                        yield return value;
                    }
                }
            }
        }

        private static IEnumerable<string> EnumerateContent(IEnumerable items, BuildContext context)
        {
            IEnumerator en = items.GetEnumerator();

            if (en.MoveNext())
            {
                foreach (var value in Expression.EnumerateValues(en.Current, context))
                {
                    yield return value;
                }

                while (en.MoveNext())
                {
                    yield return Syntax.Or;

                    foreach (var value in Expression.EnumerateValues(en.Current, context))
                    {
                        yield return value;
                    }
                }
            }
        }

        internal object Content
        {
            get { return _content; }
        }

        internal override string Closing(BuildContext context)
        {
            return Syntax.GroupEnd;
        }
    }
}
