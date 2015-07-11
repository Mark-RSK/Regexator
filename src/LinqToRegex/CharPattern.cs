﻿// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a pattern that matches a single character. This includes a character literal, Unicode category, Unicode block or character class ((non-)digit, (non-)white-space, (non-)word). This class is abstract.
    /// </summary>
    public abstract partial class CharPattern
        : QuantifiablePattern, IBaseGroup, IExcludedGroup, INegateable<CharGroup>
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
        /// Returns a patterns that matches what is not matched by the current instance.
        /// </summary>
        /// <returns></returns>
        public abstract CharGroup Negate();

        /// <summary>
        /// Appends the current instance to a specified <see cref="PatternBuilder"/>. The current instance is interpreted as a part of the character group.
        /// </summary>
        /// <param name="builder">The builder to use for appending the text.</param>
        /// <exception cref="ArgumentNullException"></exception>
        protected virtual void AppendGroupContentTo(PatternBuilder builder)
        {
            if (builder == null)
            {
                throw new ArgumentNullException("builder");
            }

            AppendTo(builder);
        }

        /// <summary>
        /// Appends the text representation of the current instance of the character pattern to the specified <see cref="PatternBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to use for appending the text.</param>
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
        /// <param name="builder">The builder to use for appending the text.</param>
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

        /// <summary>
        /// Returns a patterns that matches what is not matched by the current instance.
        /// </summary>
        /// <param name="value">A value to negate.</param>
        /// <returns></returns>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroup operator !(CharPattern value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Negate();
        }

        /// <summary>
        /// Returns a pattern that matches a character from a specified base group except characters from a specified excluded group.
        /// </summary>
        /// <param name="baseGroup">A base group.</param>
        /// <param name="excludedGroup">An excluded group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        [SuppressMessage("Microsoft.Design", "CA1013:OverloadOperatorEqualsOnOverloadingAddAndSubtract")]
        public static CharSubtraction operator -(CharPattern baseGroup, CharPattern excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup);
        }

        /// <summary>
        /// Returns a pattern that matches a character from a specified base group except characters from a specified excluded group.
        /// </summary>
        /// <param name="baseGroup">A base group.</param>
        /// <param name="excludedGroup">An excluded group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharSubtraction operator -(CharPattern baseGroup, CharGroup excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup);
        }

        /// <summary>
        /// Returns a pattern that matches a character from a specified base group except characters from a specified excluded group.
        /// </summary>
        /// <param name="baseGroup">A base group.</param>
        /// <param name="excludedGroup">An excluded group.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharSubtraction operator -(CharPattern baseGroup, CharGrouping excludedGroup)
        {
            return new CharSubtraction(baseGroup, excludedGroup);
        }
    }
}
