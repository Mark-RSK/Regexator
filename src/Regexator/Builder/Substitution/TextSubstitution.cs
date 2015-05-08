// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Builder
{
    internal sealed class TextSubstitution
        : Substitution
    {
        private readonly string _value;

        internal TextSubstitution(string value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            _value = value;
        }

        internal override string Value
        {
            get { return RegexUtilities.EscapeSubstitution(_value); }
        }
    }
}
