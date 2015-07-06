// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Supports inverting a pattern to a pattern that has an opposite meaning.
    /// </summary>
    /// <typeparam name="TPattern">A pattern to be inverted.</typeparam>
    public interface INegateable<TPattern> where TPattern : Pattern
    {
        /// <summary>
        /// Returns a pattern that has opposite meaning than the current instance. For example a word boundary is inverted into a non-word boundary.
        /// </summary>
        /// <returns></returns>
        TPattern Negate();
    }
}
