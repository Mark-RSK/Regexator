// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents the base part of the character subtraction pattern.
    /// </summary>
    public interface IBaseGroup
    {
        /// <summary>
        /// Writes the base group to the output.
        /// </summary>
        /// <param name="writer">The output to be written to.</param>
        void WriteBaseGroupTo(PatternWriter writer);
    }
}