// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System.Diagnostics.CodeAnalysis;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class CharGroup
        : QuantifiablePattern, IExcludedGroup
    {
        protected CharGroup()
        {
        }

        protected abstract void WriteContentTo(PatternWriter writer);

        public void WriteBaseGroupTo(PatternWriter writer)
        {
            WriteContentTo(writer);
        }

        public void WriteExcludedGroupTo(PatternWriter writer)
        {
            WriteTo(writer);
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
