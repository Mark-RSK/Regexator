// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a negative character subtraction pattern.
    /// </summary>
    public class NegativeCharSubtraction
        : QuantifiablePattern, IExcludedGroup
    {
        private readonly IBaseGroup _baseGroup;
        private readonly IExcludedGroup _excludedGroup;

        internal NegativeCharSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
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
        /// Appends the text representation of the current instance of the negative character subtraction to the specified <see cref="PatternBuilder"/>.
        /// </summary>
        /// <param name="builder">The builder to use for appending the negative character subtraction text.</param>
        public void AppendExcludedGroupTo(PatternBuilder builder)
        {
            AppendTo(builder);
        }

        internal override void AppendTo(PatternBuilder builder)
        {
            builder.AppendSubtraction(_baseGroup, _excludedGroup, true);
        }
    }
}