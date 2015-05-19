// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Pihrtsoft.Regexator.Linq
{
    internal sealed class EntireInputSubstitution
        : Substitution
    {
        internal EntireInputSubstitution()
        {
        }

        internal override string Value
        {
            get { return Syntax.SubstituteEntireInput; }
        }
    }
}
