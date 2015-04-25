// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

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
            _baseGroup = baseGroup;
            _excludedGroup = excludedGroup;
            _negative = negative;
        }

        public string ExcludedGroupValue
        {
            get { return Value; }
        }

        internal override string Value
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
