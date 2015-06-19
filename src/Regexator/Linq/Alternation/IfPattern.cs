// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public sealed class IfPattern
        : AlternationPattern
    {
        private readonly object _testContent;

        public IfPattern(object testContent, object trueContent)
            : this(testContent, trueContent, null)
        {
        }

        public IfPattern(object testContent, object trueContent, object falseContent)
            : base(trueContent, falseContent)
        {
            if (testContent == null)
            {
                throw new ArgumentNullException("testContent");
            }

            _testContent = testContent;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteIf(_testContent, TrueContent, FalseContent);
        }
    }
}
