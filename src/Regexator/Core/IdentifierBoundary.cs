// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions
{
    /// <summary>
    /// Specifies which characters will be used to enclose group name in the named group, balancing group and named group backreference.
    /// </summary>
    public enum IdentifierBoundary
    {
        /// <summary>
        /// Group name will be enclosed in less-than character on the left side and greater-than character on the right side.
        /// </summary>
        AngleBrackets,

        /// <summary>
        /// Group name will be enclosed in apostrophes.
        /// </summary>
        Apostrophe
    }
}
