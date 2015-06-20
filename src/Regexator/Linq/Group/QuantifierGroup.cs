// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class QuantifierGroup
        : Pattern
    {
        private readonly object _content;

        protected QuantifierGroup(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content;
        }

        public Pattern Lazy()
        {
            return ConcatInternal(new LazyQuantifier());
        }

        protected abstract void WriteQuantifierTo(PatternWriter writer);

        internal override void WriteTo(PatternWriter writer)
        {
            if (AddGroup)
            {
                writer.WriteNoncapturingGroupStart();
            }

            writer.WriteGroupContent(Content);

            if (AddGroup)
            {
                writer.WriteGroupEnd();
            }

            WriteQuantifierTo(writer);
        }

        private bool AddGroup
        {
            get
            {
                Pattern exp = Content as QuantifiablePattern;
                if (exp != null)
                {
                    return (exp.Previous != null);
                }
                else
                {
                    string s = Content as string;
                    if (s != null)
                    {
                        return s.Length > 1;
                    }
                    else
                    {
                        return !(Content is CharGroupItem);
                    }
                }
            }
        }

        internal object Content
        {
            get { return _content; }
        }
    }
}
