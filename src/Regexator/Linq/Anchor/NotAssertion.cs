// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// A zero-width negative lookahead assertion.
    /// </summary>
    public sealed class NotAssertion
        : GroupPattern
    {
        internal NotAssertion(object content)
            : base(content)
        {
        }

        internal NotAssertion(Assertion value)
            : base(value)
        {
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteNotAssert(Content);
        }
    }
}