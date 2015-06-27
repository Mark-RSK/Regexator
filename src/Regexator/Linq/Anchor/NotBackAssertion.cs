// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// A zero-width negative lookbehind assertion.
    /// </summary>
    public sealed class NotBackAssertion
        : GroupingPattern
    {
        internal NotBackAssertion(object content)
            : base(content)
        {
        }

        internal NotBackAssertion(BackAssertion value)
            : base(value)
        {
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteNotAssertBack(Content);
        }
    }
}