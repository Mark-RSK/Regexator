// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a positive or a negative character group pattern.
    /// </summary>
    public abstract partial class CharacterGroup
        : QuantifiablePattern, IExcludedGroup, IInvertible<CharacterGroup>
    {
        protected CharacterGroup()
        {
        }

        internal static CharacterGroup Create(char value, bool negative)
        {
            return new CharCharacterGroup(value, negative);
        }

        internal static CharacterGroup Create(int charCode, bool negative)
        {
            return new CharCodeCharacterGroup(charCode, negative);
        }

        internal static CharacterGroup Create(AsciiChar value, bool negative)
        {
            return new AsciiCharCharacterGroup(value, negative);
        }

        internal static CharacterGroup Create(string characters, bool negative)
        {
            return new CharsCharacterGroup(characters, negative);
        }

        internal static CharacterGroup Create(char firstChar, char lastChar, bool negative)
        {
            return new CharRangeCharacterGroup(firstChar, lastChar, negative);
        }

        internal static CharacterGroup Create(int firstCharCode, int lastCharCode, bool negative)
        {
            return new CharCodeRangeCharacterGroup(firstCharCode, lastCharCode, negative);
        }

        internal static CharacterGroup Create(GeneralCategory category, bool negative)
        {
            return new GeneralCategoryCharacterGroup(category, negative);
        }

        internal static CharacterGroup Create(NamedBlock block, bool negative)
        {
            return new NamedBlockCharacterGroup(block, negative);
        }

        internal static CharacterGroup Create(CharClass value)
        {
            return new CharClassCharacterGroup(value);
        }

        internal static CharacterGroup Create(CharGrouping value, bool negative)
        {
            return new CharGroupingCharacterGroup(value, negative);
        }

        internal abstract void WriteContentTo(PatternWriter writer);

        /// <summary>
        /// Writes the current instance of the character group to the output.
        /// </summary>
        /// <param name="writer">The output to be written to.</param>
        public void WriteExcludedGroupTo(PatternWriter writer)
        {
            WriteTo(writer);
        }

        /// <summary>
        /// If the current instance is a positive character group, it returns a negative character group. Otherwise, it returns a positive character group. Newly created group has the same content as the current instance.
        /// </summary>
        public CharacterGroup Invert()
        {
            return new CharacterGroupCharacterGroup(this, !Negative);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharacterGroup operator !(CharacterGroup value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static explicit operator CharacterGroup(string characters)
        {
            return new CharsCharacterGroup(characters);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static explicit operator CharacterGroup(CharGrouping value)
        {
            return new CharGroupingCharacterGroup(value);
        }

        /// <summary>
        /// Gets a value that indicates whether the current instance is a positive or a negative character group.
        /// </summary>
        public virtual bool Negative
        {
            get { return false; }
        }
    }
}
