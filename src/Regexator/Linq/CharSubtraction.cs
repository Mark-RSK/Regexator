// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a character subtraction pattern.
    /// </summary>
    public class CharSubtraction
        : QuantifiablePattern, IExcludedGroup, IInvertible<NegativeCharacterSubtraction>
    {
        private readonly IBaseGroup _baseGroup;
        private readonly IExcludedGroup _excludedGroup;

        internal CharSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
        {
            if (baseGroup == null)
            {
                throw new ArgumentNullException("baseGroup");
            }

            if (excludedGroup == null)
            {
                throw new ArgumentNullException("excludedGroup");
            }

            _baseGroup = baseGroup;
            _excludedGroup = excludedGroup;
        }

        /// <summary>
        /// Returns a negative character subtraction that has the same content as the current instance./>
        /// </summary>
        /// <returns></returns>
        public NegativeCharacterSubtraction Invert()
        {
            return new NegativeCharacterSubtraction(_baseGroup, _excludedGroup);
        }

        /// <summary>
        /// Appends the text representation of the current instance of the character subtraction to the specified <see cref="PatternBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to use for appending the character subtraction text.</param>
        public void AppendExcludedGroupTo(PatternBuilder builder)
        {
            AppendTo(builder);
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendSubtraction(_baseGroup, _excludedGroup);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static NegativeCharacterSubtraction operator !(CharSubtraction value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }
    }
}
