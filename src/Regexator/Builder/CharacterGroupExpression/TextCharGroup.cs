// Copyright (c) Josef Pihrt. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal class TextCharGroup
        : CharacterGroupExpression
    {
        private readonly string _value;

        public TextCharGroup(string value)
        {
            if (value == null) { throw new ArgumentNullException("value"); }
            _value = value;
        }

        public override string Content
        {
            get { return Utilities.Escape(_value, true); }
        }
    }
}
