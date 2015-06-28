// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a pattern that is quantified, i.e. quantifier is applied on it.
    /// </summary>
    public abstract partial class QuantifiedPattern
        : Pattern
    {
        protected QuantifiedPattern()
        {
        }

        /// <summary>
        /// Specifies that the quantifier is lazy. Quantified pattern will be matched as few times as possible.
        /// </summary>
        /// <returns></returns>
        public Pattern Lazy()
        {
            return ConcatInternal(new LazyQuantifier());
        }
    }
}
