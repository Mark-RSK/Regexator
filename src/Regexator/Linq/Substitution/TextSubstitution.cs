// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Regexator.Linq
{
    internal sealed class TextSubstitution
        : Substitution
    {
        private readonly string _text;

        internal TextSubstitution(string text)
        {
            if (text == null)
            {
                throw new ArgumentNullException("text");
            }
            _text = text;
        }

        internal override string Value
        {
            get { return RegexUtilities.EscapeSubstitution(_text); }
        }
    }
}
