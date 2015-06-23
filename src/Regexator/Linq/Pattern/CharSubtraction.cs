// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public class CharSubtraction
        : QuantifiablePattern, IExcludedGroup
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
            WriteTo(writer);
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteSubtraction(_baseGroup, _excludedGroup, Negative);
        }

        internal virtual bool Negative
        {
            get { return false; }
        }
    }
}
