// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class CharGroup
        : QuantifiablePattern, IBaseGroup, IExcludedGroup
    {
        protected CharGroup()
        {
        }

        public static CharGroup Create(string characters)
        {
            return new CharactersGroup(characters);
        }

        public static CharGroup Create(CharGroupItem item)
        {
            return new CharGroupItemGroup(item);
        }

        public CharSubtraction Except(IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(this, excludedGroup);
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

        public virtual bool Negative
        {
            get { return false; }
        }
    }
}
