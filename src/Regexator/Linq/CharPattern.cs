// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a single character pattern. This includes a character literal, Unicode general category or named block pattern, character class pattern ((non-)digit, (non-)white-space, (non-)word). This class is abstract.
    /// </summary>
    public abstract partial class CharPattern
        : QuantifiablePattern, IBaseGroup, IExcludedGroup, IInvertible<CharGroup>
    {
        internal CharPattern()
        {
        }

        internal static CharPattern Create(char value)
        {
            return new CharCharPattern(value);
        }

        internal static CharPattern Create(int charCode)
        {
            return new CharCodeCharPattern(charCode);
        }

        internal static CharPattern Create(AsciiChar value)
        {
            return new AsciiCharCharPattern(value);
        }

        internal static CharPattern Create(CharClass value)
        {
            return new CharClassCharPattern(value);
        }

        internal static CharPattern Create(GeneralCategory category, bool negative)
        {
            return new GeneralCategoryCharPattern(category, negative);
        }

        internal static CharPattern Create(NamedBlock block, bool negative)
        {
            return new NamedBlockCharPattern(block, negative);
        }

        /// <summary>
        /// Returns a patterns that matches what is not matched by the current instance./>
        /// </summary>
        /// <returns></returns>
        public abstract CharGroup Invert();

        /// <summary>
        /// Specifies a pattern that matches a character matched by the current instance but not matched by the excluded character group.
        /// </summary>
        /// <param name="excludedGroup">Excluded group pattern to be subtracted.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public CharSubtraction Except(IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(this, excludedGroup);
        }

        protected virtual void AppendGroupContentTo(PatternBuilder builder)
        {
            AppendTo(builder);
        }

        /// <summary>
        /// Appends the text representation of the current instance of the character pattern to the specified <see cref="PatternBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to use for appending the character pattern text.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AppendBaseGroupTo(PatternBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            AppendGroupContentTo(builder);
        }

        /// <summary>
        /// Appends the text representation of the character group containing the current instance to the specified <see cref="PatternBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to use for appending the character group text.</param>
        /// <exception cref="ArgumentNullException"></exception>
        public void AppendExcludedGroupTo(PatternBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            builder.AppendCharGroupStart();
            AppendGroupContentTo(builder);
            builder.AppendCharGroupEnd();
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroup operator !(CharPattern value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }
    }
}
