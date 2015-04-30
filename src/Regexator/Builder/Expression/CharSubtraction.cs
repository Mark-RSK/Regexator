// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    public sealed class CharSubtraction
        : QuantifiableExpression, IExcludedGroup
    {
        private readonly IBaseGroup _baseGroup;
        private readonly IExcludedGroup _excludedGroup;
        private readonly bool _negative;

        internal CharSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup)
            : this(baseGroup, excludedGroup, false)
        {
        }

        internal CharSubtraction(IBaseGroup baseGroup, IExcludedGroup excludedGroup, bool negative)
            : base()
        {
            if (baseGroup == null) { throw new ArgumentNullException("baseGroup"); }
            if (excludedGroup == null) { throw new ArgumentNullException("excludedGroup"); }
            _baseGroup = baseGroup;
            _excludedGroup = excludedGroup;
            _negative = negative;
        }

        public string ExcludedGroupValue
        {
            get { return ValueInternal; }
        }

        internal override string Value(BuildContext context)
        {
            return ValueInternal;
        }

        private string ValueInternal
        {
            get { return Syntax.CharGroup(_baseGroup.BaseGroupValue + "-" + _excludedGroup.ExcludedGroupValue, _negative); }
        }

        public bool Negative
        {
            get { return _negative; }
        }

        internal override ExpressionKind Kind
        {
            get { return ExpressionKind.CharSubtraction; }
        }
    }
}
