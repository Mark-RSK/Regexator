// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class Assert
        : GroupPattern
    {
        internal Assert(object content)
            : base(content)
        {
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteAssert(Content);
        }

        public static NotAssert operator !(Assert value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return new NotAssert(value);
        }
    }
}