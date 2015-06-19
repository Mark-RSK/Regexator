// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class QuantifierGroup
        : GroupingPattern
    {
        public QuantifierGroup(object content)
            : base(content)
        {
        }

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
    }
}
