// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public class CharacterSubtraction
        : QuantifiablePattern, IExcludedGroup, IInvertible<NotCharacterSubtraction>
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

        public NotCharacterSubtraction Invert()
        {
            return new NotCharacterSubtraction(_baseGroup, _excludedGroup);
        }

        public void WriteExcludedGroupTo(PatternWriter writer)
        {
            WriteTo(writer);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteSubtraction(_baseGroup, _excludedGroup);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static NotCharacterSubtraction operator !(CharacterSubtraction value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }
    }
}
