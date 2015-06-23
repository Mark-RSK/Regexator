// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    internal sealed class IfAssert
        : QuantifiablePattern
    {
        private readonly object _testContent;
        private readonly object _trueContent;
        private readonly object _falseContent;

        public IfAssert(object testContent, object trueContent, object falseContent)
        {
            if (testContent == null)
            {
                throw new ArgumentNullException("testContent");
            }

            if (trueContent == null)
            {
                throw new ArgumentNullException("trueContent");
            }

            _testContent = testContent;
            _trueContent = trueContent;
            _falseContent = falseContent;
        }

        internal override void WriteTo(PatternWriter writer)
        {
            writer.WriteIf(_testContent, _trueContent, _falseContent);
        }
    }
}
