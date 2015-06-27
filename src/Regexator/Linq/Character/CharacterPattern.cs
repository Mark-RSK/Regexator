// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a single character pattern. This includes a character literal, Unicode general category or named block pattern, character class pattern ((non-)digit, (non-)white-space, (non-)word). 
    /// </summary>
    public abstract class CharacterPattern
        : QuantifiablePattern, IBaseGroup, IExcludedGroup, IInvertible<CharacterGroup>
    {
        internal CharacterPattern()
        {
        }

        /// <summary>
        /// Returns a patterns that matches what is not matched by the current instance./>
        /// </summary>
        /// <returns></returns>
        public abstract CharacterGroup Invert();

        /// <summary>
        /// Specifies a pattern that matches a character matched by the current instance but not matched by the excluded character group.
        /// </summary>
        /// <param name="excludedGroup">Excluded group pattern to be subtracted.</param>
        /// <returns></returns>
        public CharacterSubtraction Except(IExcludedGroup excludedGroup)
        {
            return new CharacterSubtraction(this, excludedGroup);
        }

        protected virtual void WriteGroupContentTo(PatternWriter writer)
        {
            WriteTo(writer);
        }

        /// <summary>
        /// Writes the character pattern to the output.
        /// </summary>
        /// <param name="writer">The output to be written to.</param>
        public void WriteBaseGroupTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            WriteGroupContentTo(writer);
        }

        /// <summary>
        /// A character group containing the current instance is written to the output.
        /// </summary>
        /// <param name="writer">The output to be written to.</param>
        public void WriteExcludedGroupTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteCharGroupStart();
            WriteGroupContentTo(writer);
            writer.WriteCharGroupEnd();
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharacterGroup operator !(CharacterPattern value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }
    }
}
