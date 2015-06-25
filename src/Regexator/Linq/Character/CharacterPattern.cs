// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class CharacterPattern
        : QuantifiablePattern, IBaseGroup, IExcludedGroup, IInvertible<CharGroup>
    {
        internal CharacterPattern()
        {
        }

        public abstract CharGroup Invert();

        public CharSubtraction Except(IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(this, excludedGroup);
        }

        protected virtual void WriteGroupContentTo(PatternWriter writer)
        {
            WriteTo(writer);
        }

        public void WriteBaseGroupTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            WriteGroupContentTo(writer);
        }

        public void WriteExcludedGroupTo(PatternWriter writer)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }

            writer.WriteCharGroupStart();
            WriteGroupContentTo(writer);
            writer.WriteCharGroupEnd();
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroup operator !(CharacterPattern value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }
    }
}
