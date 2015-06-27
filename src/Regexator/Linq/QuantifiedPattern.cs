// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class QuantifiedPattern
        : Pattern
    {
        protected QuantifiedPattern()
        {
        }

        public Pattern Lazy()
        {
            return ConcatInternal(new LazyQuantifier());
        }
    }
}
