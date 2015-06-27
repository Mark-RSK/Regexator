// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents the excluded part of the character subtraction pattern.
    /// </summary>
    public interface IExcludedGroup
    {
        /// <summary>
        /// Writes the excluded group to the output.
        /// </summary>
        /// <param name="writer">The output to be written to.</param>
        void WriteExcludedGroupTo(PatternWriter writer);
    }
}