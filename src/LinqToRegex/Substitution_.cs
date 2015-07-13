// Copyright (c) Josef Pihrt. All rights reserved. Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

using System;

namespace Pihrtsoft.Text.RegularExpressions.Linq
{
    public abstract partial class Substitution
    {
        internal sealed class NamedGroupSubstitution
            : Substitution
        {
            private readonly string _groupName;

            internal NamedGroupSubstitution(string groupName)
            {
                RegexUtility.CheckGroupName(groupName);

                _groupName = groupName;
            }

            public string GroupName
            {
                get { return _groupName; }
            }

            internal override string Value
            {
                get { return Syntax.SubstituteNamedGroupStart + GroupName + Syntax.SubstituteNamedGroupEnd; }
            }
        }

        internal sealed class EntireMatchSubstitution
            : Substitution
        {
            internal EntireMatchSubstitution()
            {
            }

            internal override string Value
            {
                get { return Syntax.SubstituteEntireMatch; }
            }
        }

        internal sealed class BeforeMatchSubstitution
            : Substitution
        {
            internal BeforeMatchSubstitution()
            {
            }

            internal override string Value
            {
                get { return Syntax.SubstituteBeforeMatch; }
            }
        }

        internal sealed class AfterMatchSubstitution
            : Substitution
        {
            internal AfterMatchSubstitution()
            {
            }

            internal override string Value
            {
                get { return Syntax.SubstituteAfterMatch; }
            }
        }

        internal sealed class LastCapturedGroupSubstitution
            : Substitution
        {
            internal LastCapturedGroupSubstitution()
            {
            }

            internal override string Value
            {
                get { return Syntax.SubstituteLastCapturedGroup; }
            }
        }

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
                get { return RegexUtility.EscapeSubstitution(_text); }
            }
        }
    }
}