// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represent a character subtraction pattern.
    /// </summary>
    public class CharacterSubtraction
        : QuantifiablePattern, IExcludedGroup, IInvertible<NegativeCharacterSubtraction>
    {
        private readonly IBaseGroup _baseGroup;
        private readonly IExcludedGroup _excludedGroup;

        internal CharacterSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
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
        /// Writes the current instance of the character subtraction to the output.
        /// </summary>
        /// <param name="writer">The output to be written to.</param>
        public void WriteExcludedGroupTo(PatternWriter writer)
        {
            WriteTo(writer);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteSubtraction(_baseGroup, _excludedGroup);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static NegativeCharacterSubtraction operator !(CharacterSubtraction value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }
    }
}
