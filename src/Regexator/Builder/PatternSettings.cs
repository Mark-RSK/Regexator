// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    public class PatternSettings
        : ICloneable
    {
        public PatternSettings()
        {
            IdentifierBoundary = IdentifierBoundary.LessThan;
            NoncapturingQuantifierGroup = true;
            SeparatorAfterNumberBackreference = true;
        }

        public object Clone()
        {
            return new PatternSettings() {
                ConditionWithAssertion = ConditionWithAssertion,
                IdentifierBoundary = IdentifierBoundary,
                NoncapturingQuantifierGroup = NoncapturingQuantifierGroup,
                SeparatorAfterNumberBackreference = SeparatorAfterNumberBackreference,
                UseInvariant = UseInvariant
            };
        }

        public IdentifierBoundary IdentifierBoundary { get; set; }
        public bool NoncapturingQuantifierGroup { get; set; }
        public bool ConditionWithAssertion { get; set; }
        public bool SeparatorAfterNumberBackreference { get; set; }
        public bool UseInvariant { get; set; }
    }
}
