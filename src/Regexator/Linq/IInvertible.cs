// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Returns a patterns that has opposite meaning than the current instance. For example word boundary will be inverted into a non-word boundary.
    /// </summary>
    /// <typeparam name="TPattern">A pattern to be inverted.</typeparam>
    public interface IInvertible<TPattern> where TPattern : Pattern
    {
        TPattern Invert();
    }
}
