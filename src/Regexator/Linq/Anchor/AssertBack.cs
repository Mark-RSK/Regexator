// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class AssertBack
        : GroupPattern
    {
        public AssertBack(object content)
            : base(content)
        {
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteAssertBack(Content);
        }

        public static NotAssertBack operator !(AssertBack value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return new NotAssertBack(value);
        }
    }
}