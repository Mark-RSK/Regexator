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
        /// <summary>
        /// Initializes a new instance of the <see cref="CharGroup"/> class.
        /// </summary>
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

        internal static CharGroup Create(CharGroup value, bool negative)
        {
            return new CharGroupCharGroup(value, negative);
        }

        internal abstract void AppendContentTo(PatternBuilder builder);

        /// <summary>
        /// Appends the text representation of the current instance of the character group to the specified <see cref="PatternBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to use for appending the character group text.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AppendExcludedGroupTo(PatternBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            AppendTo(builder);
        }

        /// <summary>
        /// If the current instance is a positive character group, it returns a negative character group. Otherwise, it returns a positive character group. Newly created group has the same content as the current instance.
        /// </summary>
        public CharGroup Invert()
        {
            return Create(this, !Negative);
        }

        /// <summary>
        /// If the current instance is a positive character group, it returns a negative character group. Otherwise, it returns a positive character group. Newly created group has the same content as the current instance.
        /// </summary>
        /// <param name="value">A value to negate.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroup operator !(CharGroup value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }

        /// <summary>
        /// Converts specified characters to an instance of the <see cref="CharGroup"/> class.
        /// </summary>
        /// <param name="characters">A set of characters.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static explicit operator CharGroup(string characters)
        {
            return Create(characters, false);
        }

        /// <summary>
        /// Converts specified <see cref="CharGrouping"/> to an instance of the <see cref="CharGroup"/> class.
        /// </summary>
        /// <param name="value">An instance of the <see cref="CharGrouping"/> class.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static explicit operator CharGroup(CharGrouping value)
        {
            return Create(value, false);
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
