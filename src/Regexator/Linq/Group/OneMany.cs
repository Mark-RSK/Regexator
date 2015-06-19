// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class OneMany
        : QuantifierGroup
    {
        public OneMany(object content)
            : base(content)
        {
        }

        public OneMany(params object[] content)
            : this((object)content)
        {
        }

        protected override void WriteQuantifierTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteOneMany();
        }
    }
}
