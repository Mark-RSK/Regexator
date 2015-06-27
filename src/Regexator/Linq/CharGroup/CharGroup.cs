// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;
using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    /// <summary>
    /// Represents a character group pattern.
    /// </summary>
    public abstract class CharGroup
        : QuantifiablePattern, IExcludedGroup, IInvertible<CharGroup>
    {
        protected CharGroup()
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

        public CharGroup Invert()
        {
            return new GroupCharGroup(this, !Negative);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static CharGroup operator !(CharGroup value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            return value.Invert();
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static explicit operator CharGroup(string characters)
        {
            return new CharactersGroup(characters);
        }

        [SuppressMessage("Microsoft.Usage", "CA2225:OperatorOverloadsHaveNamedAlternates")]
        public static explicit operator CharGroup(CharGroupItem item)
        {
            return new CharGroupItemGroup(item);
        }

        public virtual bool Negative
        {
            get { return false; }
        }
    }
}
