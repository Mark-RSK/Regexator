// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract class CharGroupExpression
        : QuantifiableExpression, IBaseGroup, IExcludedGroup
    {
        protected CharGroupExpression()
        {
        }

        public CharSubtraction Except(IExcludedGroup excludedGroup)
        {
            return new CharSubtraction(this, excludedGroup);
        }

        public void WriteBaseGroupTo(PatternWriter writer)
        {
            WriteContentTo(writer);
        }

        public void WriteExcludedGroupTo(PatternWriter writer)
        {
            WriteStartTo(writer);

            //todo check empty
            WriteContentTo(writer);

            WriteEndTo(writer);
        }

        internal override void WriteStartTo(PatternWriter writer)
        {
            writer.WriteCharGroupStart(Negative);
        }

        internal override void WriteEndTo(PatternWriter writer)
        {
            writer.WriteCharGroupEnd();
        }

        public virtual bool Negative
        {
            get { return false; }
        }
    }
}
