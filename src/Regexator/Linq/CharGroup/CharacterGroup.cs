// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a character group pattern.
    /// </summary>
    public abstract class CharacterGroup
        : QuantifiablePattern, IExcludedGroup, IInvertible<CharacterGroup>
    {
        protected CharacterGroup()
        {
        }

        internal abstract void WriteContentTo(PatternWriter writer);

        public void WriteBaseGroupTo(PatternWriter writer)
        {
            WriteContentTo(writer);
        }

        public void WriteExcludedGroupTo(PatternWriter writer)
        {
            WriteTo(writer);
        }

        public CharacterGroup Invert()
        {
            return new GroupCharGroup(this, !Negative);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharacterGroup operator !(CharacterGroup value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static explicit operator CharacterGroup(string characters)
        {
            return new LiteralsCharacterGroup(characters);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static explicit operator CharacterGroup(CharGroupItem item)
        {
            return new CharGroupItemGroup(item);
        }

        public virtual bool Negative
        {
            get { return false; }
        }
    }
}
