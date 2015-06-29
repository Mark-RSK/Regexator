// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a single character pattern. This includes a character literal, Unicode general category or named block pattern, character class pattern ((non-)digit, (non-)white-space, (non-)word).
    /// </summary>
    public abstract partial class CharacterPattern
        : QuantifiablePattern, IBaseGroup, IExcludedGroup, IInvertible<CharacterGroup>
    {
        internal CharacterPattern()
        {
        }

        internal static CharacterPattern Create(char value)
        {
            return new CharCharacterPattern(value);
        }

        internal static CharacterPattern Create(int charCode)
        {
            return new CharCodeCharacterPattern(charCode);
        }

        internal static CharacterPattern Create(AsciiChar value)
        {
            return new AsciiCharCharacterPattern(value);
        }

        internal static CharacterPattern Create(CharClass value)
        {
            return new CharClassCharacterPattern(value);
        }

        internal static CharacterPattern Create(GeneralCategory category, bool negative)
        {
            return new GeneralCategoryCharacterPattern(category, negative);
        }

        internal static CharacterPattern Create(NamedBlock block, bool negative)
        {
            return new NamedBlockCharacterPattern(block, negative);
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

        protected virtual void AppendGroupContentTo(PatternBuilder builder)
        {
            AppendTo(builder);
        }

        /// <summary>
        /// Appends the text representation of the current instance of the character pattern to the specified <see cref="PatternBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to use for appending the character pattern text.</param>
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
