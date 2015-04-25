// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    public class PatternSettings
        : ICloneable
    {
        public PatternSettings()
        {
            IdentifierSeparator = IdentifierSeparatorKind.LessThan;
            NoncapturingAny = true;
            NoncapturingQuantifierGroup = true;
            SeparatorAfterNumberBackreference = true;
        }

        public object Clone()
        {
            return new PatternSettings() {
                ConditionWithAssertion = ConditionWithAssertion,
                IdentifierSeparator = IdentifierSeparator,
                NoncapturingAny = NoncapturingAny,
                NoncapturingQuantifierGroup = NoncapturingQuantifierGroup,
                SeparatorAfterNumberBackreference = SeparatorAfterNumberBackreference};
        }

        public IdentifierSeparatorKind IdentifierSeparator { get; set; }
        public bool NoncapturingAny { get; set; }
        public bool NoncapturingQuantifierGroup { get; set; }
        public bool ConditionWithAssertion { get; set; }
        public bool SeparatorAfterNumberBackreference { get; set; }
    }
}
