// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    public class BuildSettings
        : ICloneable
    {
        public BuildSettings()
        {
            IdentifierSeparator = IdentifierSeparatorKind.LessThan;
            NonbacktrackingAny = true;
            SeparatorAfterNumberBackreference = true;
        }

        public object Clone()
        {
            return new BuildSettings() {
                ConditionWithAssertion = ConditionWithAssertion,
                IdentifierSeparator = IdentifierSeparator,
                NonbacktrackingAny = NonbacktrackingAny,
                SeparatorAfterNumberBackreference = SeparatorAfterNumberBackreference};
        }

        public IdentifierSeparatorKind IdentifierSeparator { get; set; }
        public bool NonbacktrackingAny { get; set; }
        public bool ConditionWithAssertion { get; set; }
        public bool SeparatorAfterNumberBackreference { get; set; }
    }
}
