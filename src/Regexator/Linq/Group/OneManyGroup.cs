// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class OneManyGroup
        : QuantifiedGroup
    {
        public OneManyGroup(object content)
            : base(content)
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