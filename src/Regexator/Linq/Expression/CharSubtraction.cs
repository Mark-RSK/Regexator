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

        public void BuildExcludedGroup(PatternWriter writer)
        {
            BuildOpening(writer);

            BuildContent(writer);

            BuildClosing(writer);
        }

        internal override void BuildContent(PatternWriter writer)
        {
            //todo check empty
            _baseGroup.BuildBaseGroup(writer);

            writer.WriteGroupSeparator();

            //todo check empty
            _excludedGroup.BuildExcludedGroup(writer);
        }

        internal override void BuildOpening(PatternWriter writer)
        {
            writer.WriteCharGroupStart(Negative);
        }

        internal override void BuildClosing(PatternWriter writer)
        {
            writer.WriteCharGroupEnd();
        }

        public virtual bool Negative
        {
            get { return false; }
        }
    }
}
