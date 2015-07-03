// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a positive or a negative character group pattern. This class is abstract.
    /// </summary>
    public abstract partial class CharGroup
        : QuantifiablePattern, IExcludedGroup, IInvertible<CharGroup>
    {
        protected CharGroup()
        {
        }

        internal static CharGroup Create(char value, bool negative)
        {
            return new CharCharGroup(value, negative);
        }

        internal static CharGroup Create(int charCode, bool negative)
        {
            return new CharCodeCharGroup(charCode, negative);
        }

        internal static CharGroup Create(AsciiChar value, bool negative)
        {
            return new AsciiCharCharGroup(value, negative);
        }

        internal static CharGroup Create(string characters, bool negative)
        {
            return new CharsCharGroup(characters, negative);
        }

        internal static CharGroup Create(char firstChar, char lastChar, bool negative)
        {
            return new CharRangeCharGroup(firstChar, lastChar, negative);
        }

        internal static CharGroup Create(int firstCharCode, int lastCharCode, bool negative)
        {
            return new CharCodeRangeCharGroup(firstCharCode, lastCharCode, negative);
        }

        internal static CharGroup Create(GeneralCategory category, bool negative)
        {
            return new GeneralCategoryCharGroup(category, negative);
        }

        internal static CharGroup Create(NamedBlock block, bool negative)
        {
            return new NamedBlockCharGroup(block, negative);
        }

        internal static CharGroup Create(CharClass value)
        {
            return new CharClassCharGroup(value);
        }

        internal static CharGroup Create(CharGrouping value, bool negative)
        {
            return new CharGroupingCharGroup(value, negative);
        }

        internal abstract void AppendContentTo(PatternBuilder builder);

        /// <summary>
        /// Appends the text representation of the current instance of the character group to the specified <see cref="PatternBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to use for appending the character group text.</param>
        public void AppendExcludedGroupTo(PatternBuilder builder)
        {
            AppendTo(builder);
        }

        /// <summary>
        /// If the current instance is a positive character group, it returns a negative character group. Otherwise, it returns a positive character group. Newly created group has the same content as the current instance.
        /// </summary>
        public CharGroup Invert()
        {
            return new CharGroupCharGroup(this, !Negative);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroup operator !(CharGroup value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static explicit operator CharGroup(string characters)
        {
            return new CharsCharGroup(characters);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static explicit operator CharGroup(CharGrouping value)
        {
            return new CharGroupingCharGroup(value);
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
