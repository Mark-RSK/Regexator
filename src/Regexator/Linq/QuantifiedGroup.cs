// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a pattern that is quantified, i.e. the quantifier is applied on it. If required, pattern will be enclosed in the the (noncapturing) group.
    /// </summary>
    public abstract partial class QuantifiedGroup
        : QuantifiedPattern
    {
        private readonly object _content;

        protected QuantifiedGroup(object content)
        {
            if (content == null)
            {
                throw new ArgumentNullException("content");
            }

            _content = content;
        }

        protected abstract void WriteQuantifierTo(PatternWriter writer);

        internal override void WriteTo(PatternWriter writer)
        {
            bool addGroup = AddGroup;

            if (addGroup)
            {
                writer.WriteNoncapturingGroupStart();
            }

            writer.WriteGroupContent(Content);

            if (addGroup)
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
                        return !(Content is CharGrouping);
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
