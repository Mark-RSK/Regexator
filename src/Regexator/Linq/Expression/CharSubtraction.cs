// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public class CharSubtraction
        : QuantifiableExpression, IExcludedGroup
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

        public void WriteExcludedGroupTo(PatternWriter writer)
        {
            WriteStartTo(writer);

            WriteContentTo(writer);

            WriteEndTo(writer);
        }

        internal override void WriteContentTo(PatternWriter writer)
        {
            //todo check empty
            _baseGroup.WriteBaseGroupTo(writer);

            writer.WriteGroupSeparator();

            //todo check empty
            _excludedGroup.WriteExcludedGroupTo(writer);
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
