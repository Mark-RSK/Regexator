// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Specifies whether the <see cref="AnyGroup"/> will be enclosed in a certain kind of a group construct.
    /// </summary>
    internal enum GroupMode
    {
        /// <summary>
        /// <see cref="AnyGroup"/> will not be enclosed in the group.
        /// </summary>
        None,

        /// <summary>
        /// <see cref="AnyGroup"/> will be enclosed in the group.
        /// </summary>
        Group,

        /// <summary>
        /// <see cref="AnyGroup"/> will be enclosed in the noncapturing group.
        /// </summary>
        NoncapturingGroup
    }
}
